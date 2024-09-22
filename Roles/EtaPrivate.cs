using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using System.Collections.Generic;

namespace Eta.Roles
{
    [CustomRole(RoleTypeId.NtfPrivate)]
    public class EtaPrivate : CustomRole
    {
        public override uint Id { get; set; } = 14;
        public override RoleTypeId Role { get; set; } = RoleTypeId.NtfPrivate;
        public override int MaxHealth { get; set; } = 125;
        public override string Name { get; set; } = "Eta-10 Private";
        public override string Description { get; set; } = "You're containment specialists, Lets get to work!";
        public override string CustomInfo { get; set; } = "Eta-10 Private";
        public override bool IgnoreSpawnSystem { get; set; } = true;

        public override List<string> Inventory { get; set; } = new List<string>
        {
            $"{ItemType.KeycardMTFPrivate}", /// Constant
            $"{ItemType.GunCrossvec}", /// Constant
            $"{ItemType.GunCOM18}",
            $"{ItemType.Medkit}",
            $"{ItemType.Adrenaline}", /// Constant
            $"{ItemType.Radio}", /// Constant
            $"{ItemType.GrenadeHE}", /// Constant
            $"{ItemType.ArmorCombat}" /// Constant
        };

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            RoleSpawnPoints = new List<RoleSpawnPoint>
            {
                new RoleSpawnPoint
                {
                    Role = RoleTypeId.NtfPrivate,
                    Chance = 100
                }
            }
        };

        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>
        {
            { AmmoType.Nato556, 80 },
            { AmmoType.Nato9, 100 },
        };
    }
}
