namespace DeathcardGenerator.HandleCardProperties.SubHandlers
{
	public class GetBlood
	{
		/// <summary>
		/// This is a function in which will generate a blood cost and get the associated SP Cost value. e.g. 1 blood -> 3 SP,
		/// 2 blood -> 8 SP, 3 blood -> 14 SP, 4 blood -> 21 SP.
		/// </summary>
		/// <returns>The blood cost and the SP value.</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static (int blood, int SPCost) GetBloodValue()
		{
			Random random = new Random();
			int rand = random.Next(0, 16);
			switch (rand)
			{
				case 1:
				case 2:
				case 3:
				case 4:
					return (1, 3);
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
					return (2, 8);
				case 13:
				case 14:
					return (3, 14);
				case 15:
					return (4, 21);
			}
			return (0, 0);
		}
	}
}