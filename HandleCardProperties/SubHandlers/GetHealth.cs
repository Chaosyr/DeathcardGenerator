namespace DeathcardGenerator.HandleCardProperties.SubHandlers
{
	public class GetHealth
	{
		/// <summary>
		/// This is a function in which will generate a health value and get the associated SP value.
		/// <list type="table">
		///     <listheader>
		///         <term>Health</term>
		///         <description>SP</description>
		///     </listheader>
		///     <item>
		///         <term>0</term>
		///         <description>0</description>
		///     </item>
		///     <item>
		///         <term>1</term>
		///         <description>1</description>
		///     </item>
		///     <item>
		///         <term>2</term>
		///         <description>2</description>
		///     </item>
		///     <item>
		///         <term>3</term>
		///         <description>3</description>
		///     </item>
		///     <item>
		///         <term>4</term>
		///         <description>4</description>
		///     </item>
		///     <item>
		///         <term>5</term>
		///         <description>5</description>
		///     </item>
		///     <item>
		///         <term>6</term>
		///         <description>6</description>
		///     </item>
		///     <item>
		///         <term>7</term>
		///         <description>7</description>
		///     </item>
		///     <item>
		///         <term>8</term>
		///         <description>8</description>
		///     </item>
		///		<item>
		///         <term>9</term>
		///         <description>9</description>
		///     </item>
		/// </list>
		/// </summary>
		/// <returns>The health and the SP value.</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static (int count, int SP) GetHealthValue()
		{
			Random random = new Random();
			int randomNum = random.Next(1, 10);

			switch (randomNum)
			{
				case 1:
					return (1, 1);
				case 2:
					return (2, 2);
				case 3:
					return (3, 3);
				case 4:
					return (4, 4);
				case 5:
					return (5, 5);
				case 6:
					return (6, 6);
				case 7:
					return (7, 7);
				case 8:
					return (8, 8);
				case 9:
					return (9, 9);
			}
			return (1, 1);
		}
	}
}