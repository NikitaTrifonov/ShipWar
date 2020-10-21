using ShipsWar.Equipments;
using ShipsWar.Info;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipsWar
{
	public class Ship
	{
		private List<ShipEquipment> _shipEquipments;
		private Int32 _totalHealth;
		public Int32 Health { get; }
		public Int32 MaxDamage { get; }
		public Int32 MinDamage { get; }
		public Int32 Accuracy { get; }
		public String Name { get; }
		public Ship Target { get; set; }
		public ShipEquipment[] Equipments => _shipEquipments.ToArray();
		public Boolean IsAlive => TotalHealth <= 0 ? false : true;
		public Int32 TotalHealth
		{
			get => _totalHealth + Equipments.OfType<Armor>().Sum(a => a.AdditionalHealth);
			private set => _totalHealth -= value;
		}
		public Int32 TotalMaxDamage => MaxDamage + Equipments.OfType<Weapon>().Sum(w => w.AdditionalMaxDamage);
		public Int32 TotalMinDamage => MinDamage + Equipments.OfType<Weapon>().Sum(w => w.AdditionalMinDamage);
		public Int32 TotalAccuracy => Accuracy + Equipments.OfType<TargetSystem>().Sum(ts => ts.AdditionalAccuracy);

		public Ship(Int32 health, Int32 minDamage, Int32 maxDamage, Int32 accuracy, string name, List<ShipEquipment> equipments)
		{
			Health = health;
			MaxDamage = maxDamage;
			MinDamage = minDamage;
			Accuracy = accuracy;
			Name = name;
			_shipEquipments = equipments;
			_totalHealth = health;
		}

		public static Ship CreateShipType1(String name)
		{
			return new Ship(25, 3, 5, 80, name,
				new List<ShipEquipment> { new Armor("DragonSkin", 5), new TargetSystem("HawkEae", 10), new Weapon("Cricket", 1, 3) });
		}

		public static Ship CreateShipType2(String name)
		{
			return new Ship(20, 5, 10, 80, name,
				new List<ShipEquipment> { new Armor("Giant", 5), new TargetSystem("GodEae", 5), new Weapon("BFG", 1, 3) });
		}

		public Shot Shoot()
		{
			return new Shot(Target, this.CalculateShotDamage());
		}

		public void GetDamage(Int32 comingDamage)
		{
			this.TotalHealth = comingDamage;
			ShipInfo.ShipGetDamage(Name, comingDamage);
			this.CheckIsAlive();
		}

		public void GetTarget(Team enemyTeam, Team selfTeam, Tactics tactic)
		{
			switch (tactic)
			{
				case Tactics.Random:
					while (true)
					{
						Ship[] targets = enemyTeam.Ships.ToArray();
						Target = targets[new Random().Next(0, targets.Length)];
						if (Target.IsAlive) break;
						continue;
					}
					return;

				case Tactics.LessHp:
					int lessHp = enemyTeam.Ships.Where(s => s.TotalHealth > 0).Min(s => s.TotalHealth);
					Target = enemyTeam.Ships.FirstOrDefault(s => s.TotalHealth == lessHp);
					return;

				case Tactics.MostHp:
					int mostHp = enemyTeam.Ships.Where(s => s.TotalHealth > 0).Max(s => s.TotalHealth);
					Target = enemyTeam.Ships.FirstOrDefault(s => s.TotalHealth == mostHp);
					return;

				case Tactics.FocusOne:
					Target = enemyTeam.Ships.FirstOrDefault(s => s.IsAlive && s.FocusIsNeed(s, selfTeam));
					ShipInfo.TargetInfo(this, Target);
					return;

				default: throw new Exception();
			}
		}

		private Boolean FocusIsNeed(Ship enemyShip, Team selfTeam)
		{
			Int32 enoughDamage = Convert.ToInt32(Math.Round(enemyShip.TotalHealth * 1.5));
			Int32 focusDamage = selfTeam.Ships.Where(s => s.Target == enemyShip).Sum(s => s.GetAverageDamage());
			Int32 targetingAllies = selfTeam.Ships.Where(s => s.Target == enemyShip).Count();

			if (enoughDamage > focusDamage || targetingAllies < 2) return true;
			return false;
		}

		private Int32 GetAverageDamage()
		{
			Int32 result = Convert.ToInt32(Math.Floor(((TotalMinDamage + TotalMaxDamage) / 2.0) * (TotalAccuracy / 100.0)));
			return result;
		}
		private Int32 CalculateShotDamage()
		{
			if (new Random().Next(0, 100) > this.TotalAccuracy)
			{
				ShipInfo.ShipMissShot(Name);
				return 0;
			}

			return this.CalculateDamage();
		}

		private int CalculateDamage()
		{
			int random = new Random().Next(0, 10);
			if (random >= 5) return this.TotalMaxDamage;

			return this.TotalMinDamage;
		}

		private void CheckIsAlive()
		{
			if (!this.IsAlive) ShipInfo.ShipDestroy(Name);
		}
	}
}
