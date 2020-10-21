using System;
using System.Collections.Generic;
using System.Text;

namespace ShipsWar.Equipments
{
	public class TargetSystem : ShipEquipment
	{
		public Int32 AdditionalAccuracy { get; }

		public TargetSystem(string name, Int32 accuracy)
		{
			Name = name;
			AdditionalAccuracy = accuracy;
		}

		public override void GetInfo()
		{
			Console.WriteLine($"Название: {Name}  Доп. точность: {AdditionalAccuracy}");
		}
	}
}
