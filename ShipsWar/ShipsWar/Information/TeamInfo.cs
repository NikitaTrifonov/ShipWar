using ShipsWar.Equipments;
using System;

namespace ShipsWar.Info
{
	public static class TeamInfo
	{
		public static void GetIdent()
		{
			Console.WriteLine();
		}
		public static void Tactic(string teamName, Tactics tactic)
		{
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine($"Команда {teamName} выбрала тактику {tactic}");
			Console.ResetColor();
		}
		public static void ShipsState(Ship[] ships)
		{
			foreach (Ship ship in ships)
			{
				string liveState;
				if (ship.IsAlive)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					liveState = "Жив";
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					liveState = "УНИЧТОЖЕН";
				}
				Console.WriteLine($"{ship.Name}: {ship.TotalHealth} hp  {liveState}");
				Console.ResetColor();
			}
		}
		public static void Equipments(Ship[] ships)
		{
			foreach (Ship ship in ships)
			{
				Console.WriteLine();
				Console.WriteLine(ship.Name);
				Console.WriteLine("--------------------------------------------------------");
				foreach (ShipEquipment equipment in ship.Equipments)
				{
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					equipment.GetInfo();
				}
				Console.ResetColor();
				Console.WriteLine("--------------------------------------------------------");
			}
		}
		public static void TeamDestroy(string teamName)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine();
			Console.WriteLine($"Команда {teamName} уничтожена!");
			Console.ResetColor();
		}
	}
}
