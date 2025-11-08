namespace DeathcardGenerator.Helpers.Cards
{
	public class Card
	{
		/// <summary>
		/// Gets or Determines the Name for the given card.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Gets or Determines the Health for the given card.
		/// </summary>
		public int Attack { get; set; }
		/// <summary>
		/// Gets or Determines the Attack for the given card.
		/// </summary>
		public int Health { get; set; }
		/// <summary>
		/// Gets or Determines the Tribes for the given card.
		/// </summary>
		public List<string> Tribes { get; set; }
		/// <summary>
		/// Gets or Determines the First Sigil for the given card.
		/// </summary>
		public string Sigil1 { get; set; }
		/// <summary>
		/// Gets or Determines the Second Sigil for the given card.
		/// </summary>
		public string Sigil2 { get; set; }
		/// <summary>
		/// Gets or Determines the Blood Cost for the given card.
		/// </summary>
		public int BloodCost { get; set; }
		/// <summary>
		/// Gets or Determines the Bone Cost of the given card.
		/// </summary>
		public int BoneCost { get; set; }
		
		/// <summary>
		/// An object in which stores data associated with a given card so that it can later be generated.
		/// </summary>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public Card(string name, int attack, int health, List<string> tribes, string sigil1, string sigil2, int bloodCost, int boneCost)
		{
			Name = name;
			Attack = attack;
			Health = health;
			Tribes = tribes;
			Sigil1 = sigil1;
			Sigil2 = sigil2;
			BloodCost = bloodCost;
			BoneCost = boneCost;
		}
	}
}