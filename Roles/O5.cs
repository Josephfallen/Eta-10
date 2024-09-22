using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using System.Collections.Generic;

namespace Eta.Roles
{
    [CustomRole(RoleTypeId.NtfSpecialist)]
    public class O5 : CustomRole
    {
        public override uint Id { get; set; } = 11;
        public override RoleTypeId Role { get; set; } = RoleTypeId.NtfSpecialist;
        public override int MaxHealth { get; set; } = 200;
        public override string Name { get; set; } = "O5 Representative";
        public override string Description { get; set; } = "You're an O5 representative, Take Control of the Site";
        public override string CustomInfo { get; set; } = "O5 Representative";
        public override bool IgnoreSpawnSystem { get; set; } = true;

        public override List<string> Inventory { get; set; } = new List<string>
        {
            $"{ItemType.KeycardO5}", /// Constant
            $"{ItemType.GunE11SR}", /// Constant
            $"{ItemType.MicroHID}",
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
                    Role = RoleTypeId.NtfSpecialist,
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
