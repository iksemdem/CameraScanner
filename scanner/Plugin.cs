using System;
using Exiled;
using Exiled.API.Features;

namespace CharlieScanner
{
    internal class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        public override string Author => "Bum";
        public override string Name => "CharlieScanner";
        public override Version Version => new Version(1,0,1);

        public static Plugin Instance { get; private set; }
        public override void OnEnabled()
        {
            Instance = this;
            eventHandlers = new EventHandlers();
            RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            UnRegisterEvents();

            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            Exiled.Events.Handlers.Server.RespawningTeam += eventHandlers.OnSpawn;
        }

        private void UnRegisterEvents()
        {
            Exiled.Events.Handlers.Server.RespawningTeam -= eventHandlers.OnSpawn;
        }
    }
}
