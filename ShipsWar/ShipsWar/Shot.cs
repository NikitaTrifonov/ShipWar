using System;
using System.Collections.Generic;
using System.Text;

namespace ShipsWar
{
	public class Shot
	{
		public Ship Target { get; set; }
		public Int32 ComingDamage { get; set; }

		public Shot(Ship target, int comingDamage)
		{
			Target = target;
			ComingDamage = comingDamage;
		}
	}
}
