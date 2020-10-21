using System;
using System.Collections.Generic;
using System.Text;

namespace ShipsWar.Equipments
{
	public class Armor : ShipEquipment
	{
		public Int32 AdditionalHealth { get; }

		public Armor(string name, Int32 health)
		{
			Name = name;
			AdditionalHealth = health;
		}

		public override void GetInfo()
		{
			Console.WriteLine($"Название: {Name}  Доп. здоровье: {AdditionalHealth}");
		}
	}
}
