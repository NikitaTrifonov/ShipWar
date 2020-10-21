using System;

namespace ShipsWar.Equipments
{
	public abstract class ShipEquipment
	{
		public String Name { get; protected set; }

		public virtual void GetInfo()
		{
			Console.WriteLine(Name);
		}
	}
}
