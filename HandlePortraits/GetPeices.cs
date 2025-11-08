using DeathcardGenerator.Helpers.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Reflection;

namespace DeathcardGenerator.HandlePortraits
{
	public class GetPeices
	{
		public static Assembly assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(assembly.Location);
		public static string FolderRootPath = Path.GetFullPath(DLLPath + "\\Cards\\Portrait Peices");
		
		/// <summary>
		/// Gets and stores the Peices associated with the death card setup. In specific the present code checks
		/// the Heads subfolder of `Portrait Peices` for the Head bases, the Mouths subfolder of `Portrait Peices` for the Mouths,
		/// and lastly the Eyes subfolder of `Portrait Peices` for the eyes. Also with the Heads F- at the beginning of the
		/// file name determines the head as feminine, N- does the same but Neuter, and M- also does the same but Masculine.
		/// </summary>
		/// <returns>A list of Images associated with Feminine, Neuter, and Masculine Heads.
		/// A list of Images associated with Mouths.
		/// A list of Images associated with Eyes.</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static (List<Image<Rgba32>> FHeads, List<Image<Rgba32>> MHeads, List<Image<Rgba32>> NHeads, List<Image<Rgba32>> Mouths, List<Image<Rgba32>> Eyes) ChoosePeices()
		{
			List<Image<Rgba32>> FHeads = new List<Image<Rgba32>>();
			List<Image<Rgba32>> MHeads = new List<Image<Rgba32>>();
			List<Image<Rgba32>> NHeads = new List<Image<Rgba32>>();
			List<Image<Rgba32>> Mouths = new List<Image<Rgba32>>();
			List<Image<Rgba32>> Eyes = new List<Image<Rgba32>>();
			foreach (string subPath in Directory.GetDirectories(Path.GetFullPath(FolderRootPath)))
			{
				string dirName = Path.GetFileName(subPath);
				if (dirName == "Heads")
				{
					foreach (string file in Directory.GetFiles(Path.GetFullPath(subPath)))
					{
						string fileName = Path.GetFileName(file);
						if (fileName.StartsWith("F-"))
						{
							Image<Rgba32> head = Image.Load(file).CloneAs<Rgba32>();
							FHeads.Add(head);
						}
						if (fileName.StartsWith("M-"))
						{
							Image<Rgba32> head = Image.Load(file).CloneAs<Rgba32>();
							MHeads.Add(head);
						}
						if (fileName.StartsWith("N-"))
						{
							Image<Rgba32> head = Image.Load(file).CloneAs<Rgba32>();
							NHeads.Add(head);
						}
						
						Logger.Log("ChoosePeices", "Info", $"File Found in {Path.GetFileName(subPath)}; {file}");
					}
				} else if (dirName == "Eyes")
				{
					foreach (string file in Directory.GetFiles(Path.GetFullPath(subPath)))
					{
						Image<Rgba32> eyes = Image.Load(file).CloneAs<Rgba32>();
						Eyes.Add(eyes);
						Logger.Log("ChoosePeices", "Info", $"File Found in {Path.GetFileName(subPath)}; {file}");
					}
				} else if (dirName == "Mouths")
				{
					foreach (string file in Directory.GetFiles(Path.GetFullPath(subPath)))
					{
						Image<Rgba32> mouth = Image.Load(file).CloneAs<Rgba32>();
						Mouths.Add(mouth);
						Logger.Log("ChoosePeices", "Info", $"File Found in {Path.GetFileName(subPath)}; {file}");
					}
				}
			}
			return (FHeads, NHeads, MHeads, Mouths, Eyes);
		}
	}
}