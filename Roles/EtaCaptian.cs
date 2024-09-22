using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using System.Collections.Generic;

namespace Eta.Roles
{
    [CustomRole(RoleTypeId.NtfCaptain)]
    public class EtaCaptian : CustomRole
    {
        public override uint Id { get; set; } = 10;
        public override RoleTypeId Role { get; set; } = RoleTypeId.NtfCaptain;
        public override int MaxHealth { get; set; } = 175;
        public override string Name { get; set; } = "Eta-10 Captain";
        public override string Description { get; set; } = "You're containment specialists, Lets get to work!";
        public override string CustomInfo { get; set; } = "Eta-10 Captain";
        public override bool IgnoreSpawnSystem { get; set; } = true;

        public override List<string> Inventory { get; set; } = new List<string>
        {
            $"{ItemType.KeycardMTFCaptain}", /// Constant
            $"{ItemType.GunFRMG0}", /// Constant
            $"{ItemType.Adrenaline}", /// Constant
            $"{ItemType.Radio}", /// Constant
            $"{ItemType.GrenadeHE}", /// Constant
            $"{ItemType.ArmorHeavy}" /// Constant
        };

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            RoleSpawnPoints = new List<RoleSpawnPoint>
            {
                new RoleSpawnPoint
                {
                    Role = RoleTypeId.NtfCaptain,
                    Chance = 100
                }
            }
        };

        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>
        {
            { AmmoType.Nato556, 100 }
        };
    }
}
