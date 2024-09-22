using Exiled.API.Features;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Server;
using Exiled.Loader;
using MEC;
using PlayerRoles;
using Respawning;
using System;
using System.Collections.Generic;

namespace Eta
{
    internal sealed class EventHandlers
    {
        private int Respawns = 0;
        private int EtaRespawns = 0;
        private CoroutineHandle calcuationCoroutine;

        public void OnRoundStarted()
        {
            Eta.Instance.IsSpawnable = false;
            Eta.Instance.NextIsForced = false;
            Respawns = 0;
            EtaRespawns = 0;

            if (calcuationCoroutine.IsRunning)
                Timing.KillCoroutines(calcuationCoroutine);

            calcuationCoroutine = Timing.RunCoroutine(spawnCalculation());
        }

        private IEnumerator<float> spawnCalculation()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(1f);

                if (Round.IsEnded)
                    break;

                if (Math.Round(Respawn.TimeUntilSpawnWave.TotalSeconds, 0) != Eta.Instance.Config.SpawnWaveCalculation)
                    continue;

                if (Respawn.NextKnownTeam == SpawnableTeamType.NineTailedFox)
                    Eta.Instance.IsSpawnable = (Loader.Random.Next(100) <= Eta.Instance.Config.SpawnManager.Probability &&
                        Respawns >= Eta.Instance.Config.SpawnManager.Respawns &&
                        EtaRespawns < Eta.Instance.Config.SpawnManager.MaxSpawns) || Eta.Instance.NextIsForced;
            }
        }

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (Eta.Instance.IsSpawnable || Eta.Instance.NextIsForced)
            {
                List<Player> players = new List<Player>();
                if (ev.Players.Count > Eta.Instance.Config.SpawnManager.MaxSquad)
                    players = ev.Players.GetRange(0, Eta.Instance.Config.SpawnManager.MaxSquad);
                else
                    players = ev.Players.GetRange(0, ev.Players.Count);

                Queue<RoleTypeId> queue = ev.SpawnQueue;
                foreach (RoleTypeId role in queue)
                {
                    if (players.Count <= 0)
                        break;
                    Player player = players.RandomItem();
                    players.Remove(player);
                    switch (role)
                    {
                        case RoleTypeId.NtfCaptain:
                            Eta.Instance.Config.EtaCaptian.AddRole(player);
                            break;
                        case RoleTypeId.NtfSergeant:
                            Eta.Instance.Config.EtaSergeant.AddRole(player);
                            break;
                        case RoleTypeId.NtfPrivate:
                            Eta.Instance.Config.EtaPrivate.AddRole(player);
                            break;
                    }
                }
                EtaRespawns++;

                ev.NextKnownTeam = SpawnableTeamType.None;
            }
            Respawns++;
        }

        public void OnAnnouncingNtfEntrance(AnnouncingNtfEntranceEventArgs ev)
        {
            string cassieMessage = string.Empty;
            string cassieText = string.Empty;
            if (Eta.Instance.IsSpawnable || Eta.Instance.NextIsForced)
            {
                if (ev.ScpsLeft == 0 && !string.IsNullOrEmpty(Eta.Instance.Config.SpawnManager.RRRAnnouncmentCassieNoScp))
                {
                    ev.IsAllowed = false;
                    cassieMessage = Eta.Instance.Config.SpawnManager.RRRAnnouncmentCassieNoScp;
                    cassieText = Eta.Instance.Config.SpawnManager.CassieTextUiuNoSCPs;
                }
                else if (ev.ScpsLeft >= 1 && !string.IsNullOrEmpty(Eta.Instance.Config.SpawnManager.RRRAnnouncementCassie))
                {
                    ev.IsAllowed = false;
                    cassieMessage = Eta.Instance.Config.SpawnManager.RRRAnnouncementCassie;
                    cassieText = Eta.Instance.Config.SpawnManager.CassieTextUiuSCPs;
                }
                Eta.Instance.NextIsForced = false;
                Eta.Instance.IsSpawnable = false;
            }
            else
            {
                if (ev.ScpsLeft == 0 && !string.IsNullOrEmpty(Eta.Instance.Config.SpawnManager.NtfAnnouncmentCassieNoScp))
                {
                    ev.IsAllowed = false;
                    cassieMessage = Eta.Instance.Config.SpawnManager.NtfAnnouncmentCassieNoScp;
                    cassieText = Eta.Instance.Config.SpawnManager.CassieTextMtfNoSCPs;
                }
                else if (ev.ScpsLeft >= 1 && !string.IsNullOrEmpty(Eta.Instance.Config.SpawnManager.NtfAnnouncementCassie))
                {
                    ev.IsAllowed = false;
                    cassieMessage = Eta.Instance.Config.SpawnManager.NtfAnnouncementCassie;
                    cassieText = Eta.Instance.Config.SpawnManager.CassieTextMtfSCPs;
                }
            }

            cassieMessage = cassieMessage.Replace("{scpnum}", $"{ev.ScpsLeft} scpsubject");
            cassieText = cassieText.Replace("{scpnum}", $"{ev.ScpsLeft} SCP subject");

            if (ev.ScpsLeft > 1)
            {
                cassieMessage = cassieMessage.Replace("scpsubject", "scpsubjects");
                cassieText = cassieText.Replace("SCP subject", "SCP subjects");
            }
            cassieMessage = cassieMessage.Replace("{designation}", $"nato_{ev.UnitName[0]} {ev.UnitNumber}");
            cassieText = cassieText.Replace("{designation}", GetNatoName(ev.UnitName) + " " + ev.UnitNumber);

            if (!string.IsNullOrEmpty(cassieMessage))
                Cassie.MessageTranslated(cassieMessage, cassieText, isSubtitles: Eta.Instance.Config.SpawnManager.Subtitles);
        }
        public string GetNatoName(string unitName)
        {
            Dictionary<string, string> natoAlphabet = new Dictionary<string, string>()
            {
                {"a", "ALPHA"},
                {"b", "BRAVO"},
                {"c", "CHARLIE"},
                {"d", "DELTA"},
                {"e", "ECHO"},
                {"f", "FOXTROT"},
                {"g", "GOLF"},
                {"h", "HOTEL"},
                {"i", "INDIA"},
                {"j", "JULIET"},
                {"k", "KILO"},
                {"l", "LIMA"},
                {"m", "MIKE"},
                {"n", "NOVEMBER"},
                {"o", "OSCAR"},
                {"p", "PAPA"},
                {"q", "QUEBEC"},
                {"r", "ROMEO"},
                {"s", "SIERRA"},
                {"t", "TANGO"},
                {"u", "UNIFORM"},
                {"v", "VICTOR"},
                {"w", "WHISKEY"},
                {"x", "XRAY"},
                {"y", "YANKEE"},
                {"z", "ZULU" },
            };

            string firstLetter = unitName[0].ToString().ToLower();

            if (natoAlphabet.ContainsKey(firstLetter))
            {
                return natoAlphabet[firstLetter];
            }
            else
            {
                return $"nato_{firstLetter}";
            }
        }
    }
}