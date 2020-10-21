using System;
using System.Collections.Generic;
using System.Text;

namespace ShipsWar.Info
{
	public static class GameInfo
	{
		public static void Start()
		{
			Console.WriteLine();
			Console.WriteLine("БОЙ НАЧИНАЕТСЯ");
		}
		public static void Winner(string teamName)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"Победила команда: {teamName}");
			Console.ResetColor();
		}
		public static void BothDefeated()
		{
			Console.WriteLine("Ничья");
		}
		public static void TeamsInfo(Team team1, Team team2)
		{
			Console.WriteLine();
			Console.WriteLine("Информция о командах:");
			Console.WriteLine();
			Console.WriteLine($"{team1.Name}:");
			team1.GetInfo();
			Console.WriteLine();
			Console.WriteLine($"{team2.Name}:");
			team2.GetInfo();
			Console.WriteLine("--------------------------------------------------------");
		}
	}
}
