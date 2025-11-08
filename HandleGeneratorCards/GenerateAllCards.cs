using DeathcardGenerator.Helpers.Cards;

namespace DeathcardGenerator.HandleGeneratorCards
{
	public class GenerateAllCards
	{
		/// <summary>
		/// This loops through every card and calls for a generation for each one.
		/// </summary>
		/// <param name="cards">This is a Dictionary of Name -> Card association.</param>
		/// <param name="portraits">This is a Dictionary of Name -> Image association.</param>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static void ParseAndGenerateAllCards(Dictionary<string, Card> cards, Dictionary<string, string> portraits)
		{
			foreach (KeyValuePair<string, Card> kvp in cards)
			{
				GenerateCard.Generation(cards[kvp.Key], portraits[kvp.Key]);	
			}
		}
	}
}