using System;
using System.Collections.Generic;
using System.Text;

namespace ShipsWar.Equipments
{
	class Weapon : ShipEquipment
	{
		public Int32 AdditionalMinDamage { get; }
		public Int32 AdditionalMaxDamage { get; }

		public Weapon(string name, Int32 minDmg, Int32 maxDmg)
		{
			Name = name;
			AdditionalMinDamage = minDmg;
			AdditionalMaxDamage = maxDmg;
		}
		public override void GetInfo()
		{
			Console.WriteLine($"Название: {Name} Доп.мин урон: {AdditionalMinDamage} Доп.макс урон: {AdditionalMaxDamage}");
		}
	}
}
