using DeathcardGenerator.HandleCardProperties;
using DeathcardGenerator.HandleGeneratorCards;
using DeathcardGenerator.HandlePortraits;
using DeathcardGenerator.Helpers;
using DeathcardGenerator.Helpers.Cards;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace DeathcardGenerator
{
	public class Program
	{
		public static void Main()
		{
			List<string> names = ParseGuests.ParseNames();
			List<string> genders = ParseGuestGenders.ParseGenders();
			(List<Image<Rgba32>> FHeads, List<Image<Rgba32>> MHeads, List<Image<Rgba32>> NHeads, List<Image<Rgba32>> Eyes, List<Image<Rgba32>> Mouths) = GetPeices.ChoosePeices();
			Dictionary<string, List<Image<Rgba32>>> portraitsToAssemble = CompilePortrait.GetImagePeices(names, genders, FHeads, MHeads, NHeads, Eyes, Mouths);
			Dictionary<string, Image<Rgba32>> Portraits = GeneratePortraits.GenPortraits(names, portraitsToAssemble);
			Dictionary<string, Card> Cards = CreateCard.Create(names);
			Dictionary<string, string> convertedPortraits = ConvertPortrait.ConvertPortraits(Portraits);
			GenerateAllCards.ParseAndGenerateAllCards(Cards, convertedPortraits);
		}
	}
}