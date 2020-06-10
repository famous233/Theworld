using Dissonance;
using EXILED;
using GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple
{
    public class Plugin : EXILED.Plugin
    {
        private EventHandlers EventHandlers;

        public override void OnDisable()
        {
            Events.PlayerSpawnEvent -= EventHandlers.OnPlayerSpawn;
            Events.PlayerHurtEvent -= EventHandlers.OnPlayerHurt;
            Events.PlayerDeathEvent -= EventHandlers.OnPlayerDeath;
        }

        public override void OnEnable()
        {
            EventHandlers = new EventHandlers(this);
            EXILED.Log.Info("加载成功了啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊");
            Events.PlayerSpawnEvent += EventHandlers.OnPlayerSpawn;
            Events.PlayerHurtEvent += EventHandlers.OnPlayerHurt;
            Events.PlayerDeathEvent += EventHandlers.OnPlayerDeath;
        }

        public override void OnReload()
        {
            
        }
        public override string getName { get; } = "Nmsl";
    }
}
