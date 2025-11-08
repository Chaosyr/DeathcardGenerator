namespace DeathcardGenerator.HandleCardProperties.SubHandlers
{
	public class GetSigil
	{
		/// <summary>
		/// This is a function in which will generate a sigil and get the associated SP value. Due to how many there are see;
		/// https://inscryption.fandom.com/wiki/Sigils for the sigil -> value association, keep in mind this is only Act 1 sigils
		/// and the in code names.
		/// </summary>
		/// <param name="num">Takes a value of 1 or 2, which is utilized to determine if the rand range is 0-50, or 0-75.</param>
		/// <returns>The sigil and the SP value.</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static (string sigil, int SP) GetSigilValue(int num)
		{
			Random random = new Random();
			int rand = 0;
			if (num == 1)
			{
				rand = random.Next(0, 50);
			} else if (num == 2)
			{
				rand = random.Next(0, 75);	
			}
			switch (rand)
			{
				case 0:
					return ("DrawRabbits", 3);
				case 1:
					return ("BeesOnHit", 3);
				case 2:
					return ("Strafe", 1);
				case 3:
					return ("Deathtouch", 4);
				case 4:
					return ("Evolve", 2);
				case 5:
					return ("CreateDams", 3);
				case 6:
					return ("Tutor", 4);
				case 7:
					return ("WhackAMole", 1);
				case 8:
					return ("DrawCopy", 3);
				case 9:
					return ("TailOnHit", 2);
				case 10:
					return ("CorpseEater", 3);
				case 11:
					return ("QuadrupleBones", 2);
				case 12:
					return ("Submerge", 1);
				case 13:
					return ("DrawCopyOnDeath", 2);
				case 14:
					return ("Sharp", 2);
				case 15:
					return ("StrafePush", 1);
				case 16:
					return ("DrawAnt", 3);
				case 17:
					return ("GuardDog", 1);
				case 18:
					return ("Flying", 0);
				case 19:
					return ("Sacrificial", 4);
				case 20:
					return ("PreventAttack", 4);
				case 21:
					return ("TripleBlood", 2);
				case 22:
					return ("Reach", 1);
				case 23:
					return ("SplitStrike", 4);
				case 24:
					return ("TriStrike", 5);
				case 25:
					return ("IceCube", 3);
				case 26:
					return ("RandomConsumable", 5);
				case 27:
					return ("SteelTrap", 5);
				case 28:
					return ("RandomAbility", 3);
				case 29:
					return ("SquirrelOrbit", 5);
				case 30:
					return ("AllStrike", 5);
				case 31:
					return ("BuffNeighbours", 3);
				case 32:
					return ("CreateBells", 4);
				case 33:
					return ("DebuffEnemy", 2);
				default:
					return ("-", 0);
			}
		}
	}
}