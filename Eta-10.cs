using System;
using Exiled.API.Features;
using Exiled.CustomRoles.API;
using Exiled.CustomRoles.API.Features;

using MapEvent = Exiled.Events.Handlers.Map;
using ServerEvent = Exiled.Events.Handlers.Server;

namespace Eta
{
    public class Eta : Plugin<Configs.Config>
    {
        public override string Name { get; } = "Eta-10 \"See No Evil\"";
        public override string Author { get; } = "Joseph_fallen";
        public override string Prefix { get; } = "Eta-10 \"See No Evil\"";
        public override Version Version { get; } = new Version(5, 3, 2);
        public override Version RequiredExiledVersion => new Version(8, 11, 0);

        public static Eta Instance;

        public bool IsSpawnable = false;
        public bool NextIsForced = false;

        private EventHandlers eventHandlers;

        public override void OnEnabled()
        {
            Instance = this;
            Config.EtaPrivate.Register();
            Config.EtaSergeant.Register();
            Config.EtaCaptian.Register();

            eventHandlers = new EventHandlers();

            ServerEvent.RoundStarted += eventHandlers.OnRoundStarted;
            ServerEvent.RespawningTeam += eventHandlers.OnRespawningTeam;
            MapEvent.AnnouncingNtfEntrance += eventHandlers.OnAnnouncingNtfEntrance;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Config.EtaPrivate.Unregister();
            Config.EtaSergeant.Unregister();
            Config.EtaCaptian.Unregister();

            ServerEvent.RoundStarted -= eventHandlers.OnRoundStarted;
            ServerEvent.RespawningTeam -= eventHandlers.OnRespawningTeam;
            MapEvent.AnnouncingNtfEntrance -= eventHandlers.OnAnnouncingNtfEntrance;

            eventHandlers = null;
            Instance = null;
            base.OnDisabled();
        }
    }
}
