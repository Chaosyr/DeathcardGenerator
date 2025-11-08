using DeathcardGenerator.Helpers.Logging;
using System.Reflection;

namespace DeathcardGenerator.Helpers
{
	public static class ParseGuests
	{
		public static Assembly assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(assembly.Location);
		public static string FolderRootPath = Path.GetFullPath(DLLPath + "\\Cards");
		public static string GuestsFile = Path.GetFullPath(FolderRootPath + "\\Names.txt");
		
		/// <summary>
		/// Parses through 'Names.txt' located in the DLLPath's executing directory under Cards for the Guests.
		/// </summary>
		/// <returns>A list of Names.</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static List<string> ParseNames()
		{
			List<string> guests = new List<string>();
			foreach (string line in File.ReadAllLines(GuestsFile))
			{
				Logger.Log("ParseGuests", "Info", $"Found guest that goes by {line.Trim()}");
				guests.Add(line.Trim());
			}
			return guests;
		}
	}
}