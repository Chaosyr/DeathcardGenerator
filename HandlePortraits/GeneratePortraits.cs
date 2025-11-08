using DeathcardGenerator.Helpers.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Reflection;

namespace DeathcardGenerator.HandlePortraits
{
	public class GeneratePortraits
	{
		public static Assembly assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(assembly.Location);
		public static string FolderRootPath = Path.GetFullPath(DLLPath + "\\Cards\\AssembledPortraits");
		List<string> namesGoneThrough = new List<string>();
		
		/// <summary>
		/// This compiles the passed in Portrait Peices into a Portrait.
		/// </summary>
		/// <param name="names">This is the List of Names its used almost everywhere and comes from ParseGuests.</param>
		/// <param name="portraits">This is not the most accurate name but its essentially a Dictionary of Name ->
		/// List of Images e.g. the peices of the portrait in which will be compiled and associated with the given entry.</param>
		/// <returns>A dictionary of Name -> Image associations, specifically the portrait image.</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static Dictionary<string, Image<Rgba32>> GenPortraits(List<string> names, Dictionary<string, List<Image<Rgba32>>> portraits)
		{
			List<string> namesGoneThrough = new List<string>();
			Dictionary<string, Image<Rgba32>> AssembledPortraits = new Dictionary<string, Image<Rgba32>>();
			foreach (KeyValuePair<string, List<Image<Rgba32>>> kvp in portraits)
			{
				Image<Rgba32> basePortrait = kvp.Value[0];
				Image<Rgba32> eyes = kvp.Value[1];
				Image<Rgba32> mouth = kvp.Value[2];
				Image<Rgba32> Portrait = new Image<Rgba32>(114, 94);
				Portrait.Mutate(img =>
				{
					img.DrawImage(basePortrait, new Point(0, 0), 1.0f);
					img.DrawImage(eyes, new Point(0, 0), 1.0f);
					img.DrawImage(mouth, new Point(0, 0), 1.0f);
				});
				
				if (!namesGoneThrough.Contains(kvp.Key))
				{
					AssembledPortraits.Add(kvp.Key, Portrait.Clone());
					namesGoneThrough.Add(kvp.Key);
				}
				else
				{
					bool WeNotOutOfDupeLand = true;
					int Iterator = 0;
					while (WeNotOutOfDupeLand)
					{
						if (!namesGoneThrough.Contains(kvp.Key + $"_{Iterator}"))
						{
							AssembledPortraits.Add(kvp.Key + $"_{Iterator}", Portrait.Clone());
							namesGoneThrough.Add(kvp.Key + $"_{Iterator}");
							WeNotOutOfDupeLand = false;
						}
						Iterator++;
					}
				}
				
				if (!namesGoneThrough.Contains(kvp.Key))
				{
					AssembledPortraits.Add(kvp.Key, Portrait.Clone());
					namesGoneThrough.Add(kvp.Key);
				}
				else
				{
					bool WeNotOutOfDupeLand = true;
					int Iterator = 0;
					while (WeNotOutOfDupeLand)
					{
						if (!namesGoneThrough.Contains(kvp.Key + $"_{Iterator}"))
						{
							AssembledPortraits.Add(kvp.Key + $"_{Iterator}", Portrait.Clone());
							namesGoneThrough.Add(kvp.Key + $"_{Iterator}");
							WeNotOutOfDupeLand = false;
						}
						Iterator++;
					}
				}
				Portrait.SaveAsPng(Path.GetFullPath(FolderRootPath + $"\\{kvp.Key}.png"));
				Portrait.Dispose();
				Logger.Log("GeneratePortraits", "Info", $"Created portrait for guest; {kvp.Key}");
			}
			return AssembledPortraits;
		}
	}
}