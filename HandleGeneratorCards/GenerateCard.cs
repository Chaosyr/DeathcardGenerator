using DeathcardGenerator.Helpers.Cards;
using DeathcardGenerator.Helpers.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Reflection;
using System.Text;

namespace DeathcardGenerator.HandleGeneratorCards
{
	public class GenerateCard
	{
		public static Assembly assembly = Assembly.GetExecutingAssembly();
		public static string DLLPath = Path.GetDirectoryName(assembly.Location);
		public static string FolderRootPath = Path.GetFullPath(DLLPath + "\\Cards\\Exports");
		public static List<string> namesGoneThrough = new List<string>();
		
		/// <summary>
		/// Generates a card from the passed in params, via Generator.Cards from Vladde, thanks to them this project is able to stand
		/// also if you want to remove the extended borders remove the '?border=true' from the URL used in the HTTPCall.
		/// </summary>
		/// <param name="card">This is the card object in which is read to get the values for the generated card.</param>
		/// <param name="portrait">This is the portrait in which is read to define the portrait for generated card.</param>
		/// <returns>A saved file for the deathcard.</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static void Generation(Card card, string portrait)
		{
			HttpClient client = new HttpClient();
			
			StringBuilder JSONToParse = new StringBuilder();
			JSONToParse.AppendLine("{");
			JSONToParse.AppendLine($"    \"name\": \"{card.Name}\",");
			if (card.BoneCost > 0)
			{
				JSONToParse.AppendLine($"    \"boneCost\": {card.BoneCost},");
			}
			if (card.BloodCost > 0)
			{
				JSONToParse.AppendLine($"    \"bloodCost\": {card.BloodCost},");
			}
			int sigilCount = 0;
			if (card.Sigil1 != "-")
			{
				sigilCount++;
			}
			if (card.Sigil2 != "-")
			{
				sigilCount++;
			}
			if (sigilCount > 0)
			{
				JSONToParse.AppendLine($"    \"abilities\": [");
				if (card.Sigil1 != "-")
					JSONToParse.AppendLine($"        {{ \"referenceId\": \"{card.Sigil1.ToLower()}\" }}{(sigilCount == 2 ? "," : "")}");
				if (card.Sigil2 != "-")
					JSONToParse.AppendLine($"        {{ \"referenceId\": \"{card.Sigil2.ToLower()}\" }}");
				JSONToParse.AppendLine($"    ],");
			}
			if (card.Tribes.Count > 0)
			{
				JSONToParse.AppendLine($"    \"tribes\": [");
				for (int i = 0; i < card.Tribes.Count; i++)
				{
					if (i != card.Tribes.Count - 1)
					{
						JSONToParse.AppendLine($"        \"{card.Tribes[i].ToLower()}\",");
					}
					else
					{
						JSONToParse.AppendLine($"        \"{card.Tribes[i].ToLower()}\"");
					}
				}
				JSONToParse.AppendLine($"    ],");
			}
			JSONToParse.AppendLine($"    \"health\": {card.Health},");
			JSONToParse.AppendLine($"    \"attack\": {card.Attack},");
			JSONToParse.AppendLine($"    \"useCustomPortrait\": true,");
			JSONToParse.AppendLine($"    \"portrait\": {{");
			JSONToParse.AppendLine($"        \"imageBase64\": \"{portrait.Trim()}\"");
			JSONToParse.AppendLine($"    }}");
			JSONToParse.AppendLine("}");
			Logger.Log("GenerateCard", "Info", $"Parsed JSON File;\n{JSONToParse.ToString()}");
			StringContent formattedJSONString = new StringContent(JSONToParse.ToString().Trim(), Encoding.UTF8, "application/json");
			HttpResponseMessage response = client.PostAsync("https://generator.cards/api/generate?border=true", formattedJSONString).Result;
			try
			{
				byte[] pngBytes = response.Content.ReadAsByteArrayAsync().Result;
				Image<Rgba32> saveFile = Image.Load<Rgba32>(pngBytes);
				if (!namesGoneThrough.Contains(card.Name))
				{
					saveFile.Save(Path.GetFullPath(FolderRootPath + $"\\{card.Name}.png"));
					namesGoneThrough.Add(card.Name);
				}
				else
				{
					bool WeNotOutOfDupeLand = true;
					int Iterator = 0;
					while (WeNotOutOfDupeLand)
					{
						if (!namesGoneThrough.Contains(card.Name + $"_{Iterator}"))
						{
							saveFile.Save(Path.GetFullPath(FolderRootPath + $"\\{card.Name}_{Iterator}.png"));
							namesGoneThrough.Add(card.Name + $"_{Iterator}");
							WeNotOutOfDupeLand = false;
						}
						Iterator++;
					}
				}
			}
			catch (HttpRequestException e)
			{
				Logger.Log("GenerateCard", "Error", "Failed to get bytes for given generation.");
			}
		}
	}
}