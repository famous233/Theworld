using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CustomPlayerEffects;
using EXILED;
using EXILED.Extensions;
using EXILED.Patches;
using Grenades;
using LiteNetLib.Utils; 
using MEC;
using Mirror;
using UnityEngine;
using Utf8Json;
using Waits;
using System.Security.Cryptography;

namespace simple
{
	public class EventHandlers
	{
		private Plugin Plugin;
		public EventHandlers(Plugin plugin) => Plugin = plugin;
		public static int GetOnlyRandom(int min, int max)
		{
			bool flag = min >= max || min < 0;
			int result;
			if (flag)
			{
				result = min;
			}
			else
			{
				int num = max - min;
				RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider();
				byte[] array = new byte[4];
				rngcryptoServiceProvider.GetBytes(array);
				int num2 = BitConverter.ToInt32(array, 0) % num;
				System.Random random = new System.Random((int)DateTime.Now.Ticks + num2 + min);
				result = random.Next(min, max);
			}
			return result;
		}
		public void OnPlayerSpawn(EXILED.PlayerSpawnEvent ev)
		{
			if (ev.Player.GetRole() == RoleType.Scp173)
			{
				ev.Player.SetRank("『SCP-173·世界』", "red", true);
				ev.Player.Broadcast(15, "<color=red>『SCP-173·世界』</color> \n 能力:出生后全局锁门9秒,以后在敌人攻击后概率时停 \n 时停期间你不受门禁影响(测试期间可能会有BUG)", false);
				Map.Broadcast("SCP-173:<color=red>『THE WORLD』!</color>", 2, false);
				Map.TurnOffAllLights(10f, true);
				ev.Player.SetBypassMode(true);
				foreach (Door door in UnityEngine.Object.FindObjectsOfType<Door>())
				{
					door.Networklocked = true;
				}
				Timing.CallDelayed(10f, () =>
				{
					foreach (Door door in UnityEngine.Object.FindObjectsOfType<Door>())
					{
						door.Networklocked = false;
					}
				});
				Map.Broadcast("SCP-173:<color=red>1秒过去了!</color>", 1, false);
				Map.Broadcast("SCP-173:<color=red>2秒过去了!</color>", 1, false);
				Map.Broadcast("SCP-173:<color=red>3秒过去了!</color>", 1, false);
				Map.Broadcast("SCP-173:<color=red>4秒过去了!</color>", 1, false);
				Map.Broadcast("SCP-173:<color=red>5秒过去了!</color>", 1, false);
				Map.Broadcast("SCP-173:<color=red>6秒过去了!</color>", 1, false);
				Map.Broadcast("SCP-173:<color=red>7秒过去了!</color>", 1, false);
				Map.Broadcast("SCP-173:<color=red>8秒过去了!</color>", 1, false);
				Map.Broadcast("SCP-173:<color=red>9秒过去了!</color>", 1, false);
				Map.Broadcast("SCP-173:<color=red>然后时间开始流动!</color>", 3, false);
				Timing.WaitForSeconds(10f);
				ev.Player.SetBypassMode(false);
			}
		}
		public void OnPlayerHurt(ref EXILED.PlayerHurtEvent ev)
		{
			int number = GetOnlyRandom(1, 100);
			int luckyNumber = 15;
			if (number <= luckyNumber)
			{
				if (ev.Player.GetRole() == RoleType.Scp173)
				{
					Map.Broadcast("SCP-173:<color=red>『THE WORLD』!</color>", 2, false);
					Map.TurnOffAllLights(10f, true);
					foreach (Door door in UnityEngine.Object.FindObjectsOfType<Door>())
					{
						door.Networklocked = true;
					}
					ev.Player.SetBypassMode(true);
					Timing.CallDelayed(10f, () =>
					{
						foreach (Door door in UnityEngine.Object.FindObjectsOfType<Door>())
						{
							door.Networklocked = false;
						}
					});
					Map.Broadcast("SCP-173:<color=red>1秒过去了!</color>", 1, false);
					Map.Broadcast("SCP-173:<color=red>2秒过去了!</color>", 1, false);
					Map.Broadcast("SCP-173:<color=red>3秒过去了!</color>", 1, false);
					Map.Broadcast("SCP-173:<color=red>4秒过去了!</color>", 1, false);
					Map.Broadcast("SCP-173:<color=red>5秒过去了!</color>", 1, false);
					Map.Broadcast("SCP-173:<color=red>6秒过去了!</color>", 1, false);
					Map.Broadcast("SCP-173:<color=red>7秒过去了!</color>", 1, false);
					Map.Broadcast("SCP-173:<color=red>8秒过去了!</color>", 1, false);
					Map.Broadcast("SCP-173:<color=red>9秒过去了!</color>", 1, false);
					Map.Broadcast("SCP-173:<color=red>然后时间开始流动!</color>", 3, false);
					Timing.WaitForSeconds(10f);
					ev.Player.SetBypassMode(false);
				}
			}
		}
		public void OnPlayerDeath(ref PlayerDeathEvent ev)
		{
			if (ev.Player.GetRole() == RoleType.Scp173)
			{
				ev.Player.SetRank("再起不能の『SCP-173·世界』", "red", true);		
			}
		}
	}
}