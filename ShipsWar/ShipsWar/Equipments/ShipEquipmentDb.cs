using System;

namespace ShipsWar.Equipments
{
	public class ShipEquipmentDb
	{
		public String Id { get; set; }
		public String Name { get; set; }
		public EquipmentType Type { get; set; }
		public Int32? AdditionalMinDamage { get; set; }
		public Int32? AdditionalMaxDamage { get; set; }
		public Int32? AdditionalAccuracy { get; set; }
		public Int32? AdditionalHealth { get; set; }

	}
}
