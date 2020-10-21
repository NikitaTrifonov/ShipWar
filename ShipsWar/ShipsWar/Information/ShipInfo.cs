using System;

namespace ShipsWar.Info
{
	public static class ShipInfo
	{

		public static void ShipGetDamage(string shipName, Int32 damage)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"{shipName} Получил урон: {damage}");
			Console.ResetColor();
		}
		public static void ShipMissShot(string shipName)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"{shipName} промахнулся!");
			Console.ResetColor();
		}
		public static void ShipDestroy(string shipName)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"{shipName} уничтожен!");
			Console.ResetColor();
		}

		public static void TargetInfo(Ship self, Ship target)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine($"{self.Name}  атакует  {target.Name}");
			Console.ResetColor();
		}

	}
}
