namespace DeathcardGenerator.HandleCardProperties.SubHandlers
{
	public class GetTribes
	{
		/// <summary>
		/// This is a function in which will generate a list of tribes and get the associated SP value.
		/// <list type="table">
		///     <listheader>
		///         <term>Tribe</term>
		///         <description>SP</description>
		///     </listheader>
		///     <item>
		///         <term>Bird</term>
		///         <description>0</description>
		///     </item>
		///     <item>
		///         <term>Canine</term>
		///         <description>0</description>
		///     </item>
		///     <item>
		///         <term>Hooved</term>
		///         <description>0</description>
		///     </item>
		///     <item>
		///         <term>Reptile</term>
		///         <description>0</description>
		///     </item>
		///     <item>
		///         <term>Insect</term>
		///         <description>0</description>
		///     </item>
		///     <item>
		///         <term>Squirrel</term>
		///         <description>0</description>
		///     </item>
		/// </list>
		/// </summary>
		/// <returns>The tribes and the SP value always a zero in this case.</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static (List<String> Tribes, int SP) GetTribeValues()
		{
			List<string> tribes = new List<string>();
			for (int i = 0; i < 5; i++)
			{
				Random random = new Random();
				int rand = random.Next(0, 2);
				if (i == 0) {
					switch (rand)
					{
						case 0:
							break;
						case 1:
							tribes.Add("Bird");
							break;
					}
				} else if (i == 1) {
					switch (rand)
					{
						case 0:
							break;
						case 1:
							tribes.Add("Canine");
							break;
					}
				} else if (i == 2) {
					switch (rand)
					{
						case 0:
							break;
						case 1:
							tribes.Add("Hooved");
							break;
					}
				} else if (i == 3) {
					switch (rand)
					{
						case 0:
							break;
						case 1:
							tribes.Add("Reptile");
							break;
					}
				} else if (i == 4) {
					switch (rand)
					{
						case 0:
							break;
						case 1:
							tribes.Add("Insect");
							break;
					}
				} else if (i == 5) {
					switch (rand)
					{
						case 0:
							break;
						case 1:
							tribes.Add("Squirrel");
							break;
					}
				}
			}
			return (tribes, 0);
		}
	}
}