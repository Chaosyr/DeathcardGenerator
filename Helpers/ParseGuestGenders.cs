using DeathcardGenerator.Helpers.Logging;
using System.Reflection;

namespace DeathcardGenerator.Helpers
{
	public static class ParseGuestGenders
	{
		public static Assembly assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(assembly.Location);
		public static string FolderRootPath = Path.GetFullPath(DLLPath + "\\Cards");
		public static string GendersFile = Path.GetFullPath(FolderRootPath + "\\Genders.txt");
		
		/// <summary>
		/// Parses through 'Genders.txt' located in the DLLPath's executing directory under Cards for the Genders associated with an entry.
		/// </summary>
		/// <returns>A list of Genders.</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static List<string> ParseGenders()
		{
			List<string> genders = new List<string>();
			foreach (string line in File.ReadAllLines(GendersFile))
			{
				Logger.Log("ParseGenders", "Info", $"Found guest that goes by {line.Trim()}");
				genders.Add(line.Trim());
			}
			return genders;
		}
	}
}