using ShipsWar.Info;
using System;
using System.Collections.Generic;

namespace ShipsWar
{
	public class Game
	{
		public Dictionary<Team, List<Shot>> Shots { get; set; }
		public Team FirstTeam { get; }
		public Team SecondTeam { get; }
		public Boolean GameOver => !FirstTeam.IsAlive || !SecondTeam.IsAlive;
		public Team Winner
		{
			get
			{
				if (GameOver)
				{
					if (!FirstTeam.IsAlive && !SecondTeam.IsAlive) return null;
					if (FirstTeam.IsAlive) return FirstTeam;
					if (SecondTeam.IsAlive) return SecondTeam;
				}
				return null;
			}
		}

		public Game()
		{
			FirstTeam = new Team("Red");
			SecondTeam = new Team("Blue");
			Shots = new Dictionary<Team, List<Shot>>();
		}

		public void StartGame()
		{
			GameInfo.TeamsInfo(FirstTeam, SecondTeam);
			TeamInfo.Equipments(FirstTeam.Ships);
			TeamInfo.Equipments(SecondTeam.Ships);
			GameInfo.Start();

			while (!this.GameOver)
			{
				PhaseAim();
				PhaseShoot();
				PhaseDamage();
				GameInfo.TeamsInfo(FirstTeam, SecondTeam);
			}

			if (Winner != null) GameInfo.Winner(this.Winner.Name);
			else GameInfo.BothDefeated();
		}
		private void PhaseShoot()
		{
			Shots.Add(FirstTeam, FirstTeam.MakeTeamShots());
			Shots.Add(SecondTeam, SecondTeam.MakeTeamShots());
		}

		private void PhaseAim()
		{
			FirstTeam.GetTargets(SecondTeam, FirstTeam);
			TeamInfo.GetIdent();
			SecondTeam.GetTargets(FirstTeam, SecondTeam);
		}
		private void PhaseDamage()
		{
			FirstTeam.GetTeamDamage(Shots[SecondTeam]);
			SecondTeam.GetTeamDamage(Shots[FirstTeam]);
			ClearShots();
		}

		private void ClearShots()
		{
			foreach (KeyValuePair<Team, List<Shot>> keyValue in Shots)
			{
				Shots.Remove(keyValue.Key);
			}
		}
	}
}
