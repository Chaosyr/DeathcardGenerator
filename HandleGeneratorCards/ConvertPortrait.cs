using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using System.Buffers.Text;

namespace DeathcardGenerator.HandleGeneratorCards
{
	public class ConvertPortrait
	{
		/// <summary>
		/// This loops through every portrait and converts it to a Base64String.
		/// </summary>
		/// <param name="portraits">This is a Dictionary of Name -> Image.</param>
		/// <returns>A Dictionary of Name -> Base64String</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static Dictionary<string, string> ConvertPortraits(Dictionary<string, Image<Rgba32>> portraits)
		{
			Dictionary<string, string> convertedPortraits = new Dictionary<string, string>();
			foreach (KeyValuePair<string, Image<Rgba32>> kvp in portraits)
			{
				convertedPortraits.Add(kvp.Key, kvp.Value.ToBase64String(PngFormat.Instance));
			}
			return convertedPortraits;
		}
	}
}