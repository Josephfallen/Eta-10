using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using System.Collections.Generic;

namespace Eta.Roles
{
    [CustomRole(RoleTypeId.NtfSergeant)]
    public class EtaSergeant : CustomRole
    {
        public override uint Id { get; set; } = 11;
        public override RoleTypeId Role { get; set; } = RoleTypeId.NtfSergeant;
        public override int MaxHealth { get; set; } = 150;
        public override string Name { get; set; } = "Eta-10 Sergeant";
        public override string Description { get; set; } = "You're containment specialists, Lets get to work!";
        public override string CustomInfo { get; set; } = "Eta-10 Sergeant";
        public override bool IgnoreSpawnSystem { get; set; } = true;

        public override List<string> Inventory { get; set; } = new List<string>
        {
            $"{ItemType.KeycardMTFOperative}", /// Constant
            $"{ItemType.GunE11SR}", /// Constant
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
                    Role = RoleTypeId.NtfSergeant,
                    Chance = 100
                }
            }
        };

        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>
        {
            { AmmoType.Nato556, 80 },
            { AmmoType.Nato9, 80 },
        };
    }
}
