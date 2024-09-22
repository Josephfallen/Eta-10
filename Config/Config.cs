using System.ComponentModel;
using Eta.Configs;
using Eta.Roles;
using Exiled.API.Interfaces;

namespace Eta.Configs
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should debug messages be shown in a server console.")]
        public bool Debug { get; set; } = false;

        [Description("How many seconds before a spawnwave occurs should it calculate the spawn chance")]
        public int SpawnWaveCalculation { get; set; } = 10;

        [Description("Options for Eta-10 spawn:")]
        public SpawnManager SpawnManager { get; private set; } = new SpawnManager();

        [Description("Options for Eta-10 Captain:")]
        public EtaCaptian EtaCaptian { get; private set; } = new EtaCaptian();

        [Description("Options for Eta-10 Sergeant:")]
        public EtaSergeant EtaSergeant { get; private set; } = new EtaSergeant();

        [Description("Options for Eta-10 Private:")]
        public EtaPrivate EtaPrivate { get; private set; } = new EtaPrivate();

    }
}