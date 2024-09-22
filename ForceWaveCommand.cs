using CommandSystem;
using Exiled.Permissions.Extensions;
using Exiled.API.Features;
using Exiled.API.Enums;
using PlayerRoles;
using System;
using Eta;

namespace Eta
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class ForceWaveCommand : ICommand
    {
        public string Command { get; set; } = "forceEtawave";
        public string Description { get; set; } = "Forces Alpha-1 on next spawn wave!";
        public string[] Aliases { get; set; } = new string[] { };
        public bool Execute(ArraySegment<string> args, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(PlayerPermissions.RoundEvents))
            {
                response = "You do not have permission to use this command!";
                return false;
            }

            Eta.Instance.NextIsForced = true;
            Eta.Instance.IsSpawnable = true;

            response = "Next MTF wave will be Eta-10!";
            return true;
        }
    }
}