namespace DeathcardGenerator.HandleCardProperties.SubHandlers
{
	public class GetBones
	{
		/// <summary>
		/// This is a function in which will generate a bone cost and get the associated SP Cost value. e.g. Bone Count * 1.2,
		/// theres also a rand%9 so there more chance of other bone costs, with a range of 0-45, in otherwords 4 chances for each
		/// bone cost.
		/// </summary>
		/// <returns>The bone cost and the SP value.</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static (int bones, int SPCost) GetBonesValue()
		{
			Random random = new Random();
			int rand = random.Next(0, 45);
			return ((rand%9), (int)((rand%9) * 1.2));
		}
	}
}