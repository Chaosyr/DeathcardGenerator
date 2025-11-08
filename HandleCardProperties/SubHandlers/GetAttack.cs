namespace DeathcardGenerator.HandleCardProperties.SubHandlers
{
	public static class GetAttack
	{
		/// <summary>
		/// This is a function in which will generate a attack value and get the associated SP value.
		/// <list type="table">
		///     <listheader>
		///         <term>Attack Power</term>
		///         <description>SP</description>
		///     </listheader>
		///     <item>
		///         <term>0</term>
		///         <description>0</description>
		///     </item>
		///     <item>
		///         <term>1</term>
		///         <description>2</description>
		///     </item>
		///     <item>
		///         <term>2</term>
		///         <description>4</description>
		///     </item>
		///     <item>
		///         <term>3</term>
		///         <description>6</description>
		///     </item>
		///     <item>
		///         <term>4</term>
		///         <description>8</description>
		///     </item>
		///     <item>
		///         <term>5</term>
		///         <description>10</description>
		///     </item>
		///     <item>
		///         <term>6</term>
		///         <description>12</description>
		///     </item>
		///     <item>
		///         <term>7</term>
		///         <description>14</description>
		///     </item>
		///     <item>
		///         <term>8</term>
		///         <description>16</description>
		///     </item>
		///		<item>
		///         <term>9</term>
		///         <description>18</description>
		///     </item>
		/// </list>
		/// </summary>
		/// <returns>The attack power and the SP value.</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static (int count, int SP) GetAttackValue()
		{
			Random random = new Random();
			int randomNum = random.Next(0, 10);

			switch (randomNum)
			{
				case 1:
					return (1, 2);
				case 2:
					return (2, 4);
				case 3:
					return (3, 6);
				case 4:
					return (4, 8);
				case 5:
					return (5, 10);
				case 6:
					return (6, 12);
				case 7:
					return (7, 14);
				case 8:
					return (8, 16);
				case 9:
					return (9, 18);
			}
			return (0, 0);
		}
	}
}