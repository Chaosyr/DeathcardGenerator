using DeathcardGenerator.Helpers.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace DeathcardGenerator.HandlePortraits
{
	public class CompilePortrait
	{
		/// <summary>
		/// This gets a randomized peice from the passed in Lists of Images, its specific though so keep that in mind.
		/// </summary>
		/// <param name="Names">This is the List of Names its used almost everywhere and comes from ParseGuests.</param>
		/// <param name="Genders">This is the List of Genders its used almost everywhere and comes from ParseGuests.</param>
		/// <param name="FHeads">This is the List of Images associated with Feminine Heads.</param>
		/// <param name="MHeads">This is the List of Images associated with Masculine Heads.</param>
		/// <param name="NHeads">This is the List of Images associated with Neuter Heads.</param>
		/// <param name="Eyes">This is the List of Images associated with Eyes.</param>
		/// <param name="Mouths">This is the List of Images associated with Mouths.</param>
		/// <returns>A dictionary of Name -> Portrait Peices e.g. a List of Images which resemble each peice.</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static Dictionary<string, List<Image<Rgba32>>> GetImagePeices(List<string> Names, List<string> Genders, List<Image<Rgba32>> FHeads, List<Image<Rgba32>> MHeads, List<Image<Rgba32>> NHeads, List<Image<Rgba32>> Eyes, List<Image<Rgba32>> Mouths)
		{
			List<string> namesGoneThrough = new List<string>();
			Dictionary<string, List<Image<Rgba32>>> ImagePeices = new Dictionary<string, List<Image<Rgba32>>>();
			for (int i = 0; i < Names.Count(); i++)
			{
				string name = Names[i];
				string gender = Genders[i];
				Random random = new Random();
				int randNum = random.Next(0, FHeads.Count);
				int randNum2 = random.Next(0, MHeads.Count);
				int randNum3 = random.Next(0, NHeads.Count);
				int randNum4 = random.Next(0, Eyes.Count);
				int randNum5 = random.Next(0, Mouths.Count);
				List<Image<Rgba32>> portraitPeices = new List<Image<Rgba32>>();
				if (gender == "F")
				{
					portraitPeices.Add(FHeads[randNum]);
					Logger.Log("CompilePortrait", "Info", $"Chosen Head for {name} is Head-{randNum}");
				} else if (gender == "M")
				{
					portraitPeices.Add(MHeads[randNum2]);
					Logger.Log("CompilePortrait", "Info", $"Chosen Head for {name} is Head-{randNum}");
				} else if (gender == "N")
				{
					portraitPeices.Add(NHeads[randNum3]);
					Logger.Log("CompilePortrait", "Info", $"Chosen Head for {name} is Head-{randNum}");
				}
				portraitPeices.Add(Eyes[randNum4]);
				Logger.Log("CompilePortrait", "Info", $"Chosen Eyes for {name} is Eyes-{randNum}");
				portraitPeices.Add(Mouths[randNum5]);
				Logger.Log("CompilePortrait", "Info", $"Chosen Mouth for {name} is Mouth-{randNum}");
				if (!namesGoneThrough.Contains(name))
				{
					ImagePeices.Add(name, portraitPeices);
					namesGoneThrough.Add(name);
				}
				else
				{
					bool WeNotOutOfDupeLand = true;
					int Iterator = 0;
					while (WeNotOutOfDupeLand)
					{
						if (!namesGoneThrough.Contains(name + $"_{Iterator}"))
						{
							ImagePeices.Add(name + $"_{Iterator}", portraitPeices);
							namesGoneThrough.Add(name + $"_{Iterator}");
							WeNotOutOfDupeLand = false;
						}
						Iterator++;
					}
				}
			}
			return ImagePeices;
		}
	}
}