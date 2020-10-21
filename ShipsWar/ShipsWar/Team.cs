using ShipsWar.Info;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipsWar
{
	public class Team
	{
		private List<Ship> _ships;
		public String Name { get; }
		public Ship[] Ships => _ships.ToArray();
		public Tactics Tactic { get; set; }
		public Boolean IsAlive => !Ships.All(s => !s.IsAlive);

		public Team(string teamName)
		{
			Name = teamName;
			_ships = CreateShips(teamName);
			Tactic = Tactics.Random;
		}

		public static List<Ship> CreateShips(String teamName, Int32 type1Count = 5, Int32 type2Count = 5)
		{
			List<Ship> result = new List<Ship>();

			for (int i = 0; i < type1Count; i++)
			{
				result.Add(Ship.CreateShipType1(teamName + "_ship_1_" + (i + 1)));
			}

			for (int i = 0; i < type2Count; i++)
			{
				result.Add(Ship.CreateShipType2(teamName + "_ship_2_" + (i + 1)));
			}

			return result;
		}
		public List<Shot> MakeTeamShots()
		{
			List<Shot> result = new List<Shot>();
			foreach (Ship ship in this.Ships)
			{
				if (!ship.IsAlive) continue;
				result.Add(ship.Shoot());				
			}
			ClearTargets();
			return result;
		}
		private void ClearTargets()
		{
			foreach (Ship s in Ships)
			{
				s.Target = null;
			}
		}
		public void GetTargets(Team enemyTeam, Team selfTeam)
		{
			GetTactic();
			foreach (Ship ship in Ships)
			{
				if (ship.IsAlive && ship.Target == null)
				{
					ship.GetTarget(enemyTeam, selfTeam, Tactic);
				}
			}
		}
		public void GetTeamDamage(List<Shot> enemyShots)
		{
			TeamInfo.GetIdent();
			enemyShots.ForEach(s => s.Target.GetDamage(s.ComingDamage));
			this.CheckTeamIsAlive();
		}
		private void GetTactic()
		{
			int tacticNumber = new Random().Next(0, Enum.GetNames(typeof(Tactics)).Length);
			this.Tactic = (Tactics)tacticNumber;
			TeamInfo.Tactic(Name, Tactic);
		}
		private void CheckTeamIsAlive()
		{
			if (!this.IsAlive) TeamInfo.TeamDestroy(Name);
		}
		public void GetInfo()
		{
			TeamInfo.ShipsState(Ships);
		}
	}
}
