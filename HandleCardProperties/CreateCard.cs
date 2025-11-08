using DeathcardGenerator.HandleCardProperties.SubHandlers;
using DeathcardGenerator.Helpers.Cards;
using DeathcardGenerator.Helpers.Logging;

namespace DeathcardGenerator.HandleCardProperties
{
	public class CreateCard
	{
		public static List<string> namesGoneThrough = new List<string>();
		
		/// <summary>
		/// This creates a card for each guest, completely randomized with several SP checks as its random we gotta balance
		/// it somehow. Mainly we make sure that SP follows Daniel Mullins Games formula with some slight tweaks. e.g.
		/// SP = (Power * 2) + Toughness + Power Levels Of Abilities + (if 1 sigil +/- 1 must be valid, else if 2 sigil
		/// +/- 2 must be valid else +/- 0 as no flex is needed) It's a very dumb thing but it works within the Use case,
		/// each of the values needed for this comes from the individual function that handles each element. Than the checks
		/// done are boiled down to SP !> SPCost, and Card attack and Card power are not above 7 in a given generation, oh
		/// we also make sure sigils are always unique unless their both N/A so that cards don't have duped sigils.
		/// </summary>
		/// <param name="Names">This is the List of Names its used almost everywhere and comes from ParseGuests.</param>
		/// <returns>A dictionary of Name -> Card [see the card object for more info].</returns>
		/// <remarks>This code is provided by Creator/Chaosyr/SaxbyMod/The Stoat Lord.</remarks>
		public static Dictionary<string, Card> Create(List<string> Names)
		{
			Dictionary<string, Card> Cards = new Dictionary<string, Card>();
			foreach (string name in Names)
			{
				bool SPInvalid = true;
				Card card = new Card(name, 0,1, null, "-", "-", 0, 0);
				int SP = 0;
				int SPCost = 0;
				int blood = 0;
				int bones = 0;
				while (SPInvalid)
				{
					blood = 0;
					bones = 0;
					SP = 0;
					(int attackValue, int SPNew) = GetAttack.GetAttackValue();
					SP += SPNew;
					(int healthValue, SPNew) = GetHealth.GetHealthValue();
					SP += SPNew;
					(List<string> tribes, SPNew) = GetTribes.GetTribeValues();
					bool ununiqueSigils = true;
					string sigil = "";
					string sigil2 = "";
					int nonNullSigils = 0;
					while (ununiqueSigils)
					{
						int SPCurr = 0;
						(sigil, SPNew) = GetSigil.GetSigilValue(1);
						SPCurr += SPNew;
						(sigil2, SPNew) = GetSigil.GetSigilValue(2);
						SPCurr += SPNew;
						if (!(sigil.Equals(sigil2) && !sigil.Equals("-")))
						{
							SP += SPCurr;
							if (sigil != "-")
							{
								nonNullSigils += 1;
							}
							if (sigil2 != "-")
							{
								nonNullSigils += 1;
							}
							ununiqueSigils = false;
						}
					}
					SPCost = 0;
					Random rand = new Random();
					int cost = rand.Next(0, 2);
					if (cost == 0)
					{
						(blood, int SPCostNew) = GetBlood.GetBloodValue();
						SPCost += SPCostNew;
					} 
					if (cost == 1)
					{
						(bones, int SPCostNew) = GetBones.GetBonesValue();
						SPCost += SPCostNew;
					}
					if (nonNullSigils == 0)
					{
						if (SP + 2 < SPCost && SP - 2 < SPCost && !(card.Attack > 7 && card.Health > 7))
						{
							SPInvalid = false;
							card = new Card(name, attackValue, healthValue, tribes, sigil, sigil2, blood, bones);
						}
					}
					else if (nonNullSigils == 1)
					{
						if (SP + 2 < SPCost && SP - 2 < SPCost && !(card.Attack > 7 && card.Health > 7))
						{
							SPInvalid = false;
							card = new Card(name, attackValue, healthValue, tribes, sigil, sigil2, blood, bones);
						}
					}
					else if (nonNullSigils == 2)
					{
						if (SP + 2 < SPCost && SP - 2 < SPCost && !(card.Attack > 7 && card.Health > 7))
						{
							SPInvalid = false;
							card = new Card(name, attackValue, healthValue, tribes, sigil, sigil2, blood, bones);
						}
					}
				}
				
				if (!namesGoneThrough.Contains(name))
				{
					Cards.Add(name, card);
					namesGoneThrough.Add(card.Name);
				}
				else
				{
					bool WeNotOutOfDupeLand = true;
					int Iterator = 0;
					while (WeNotOutOfDupeLand)
					{
						if (!namesGoneThrough.Contains(name + $"_{Iterator}"))
						{
							Cards.Add(name +$"_{Iterator}", card);
							namesGoneThrough.Add(name + $"_{Iterator}");
							WeNotOutOfDupeLand = false;
						}
						Iterator++;
					}
				}
				
				Logger.Log("CreateCard", "Info", $"Card {name} Content; ");
				Logger.Log("CreateCard", "Info", $"Power Value: {card.Attack}");
				Logger.Log("CreateCard", "Info", $"Health Value: {card.Health}");
				foreach (string str in card.Tribes)
				{
					Logger.Log("CreateCard", "Info", $"Tribe Entry: {str}");
				}
				Logger.Log("CreateCard", "Info", $"Sigil1 Value: {card.Sigil1}");
				Logger.Log("CreateCard", "Info", $"Sigil2 Value: {card.Sigil2}");
				Logger.Log("CreateCard", "Info", $"Blood Value: {card.BloodCost}");
				Logger.Log("CreateCard", "Info", $"Bones Value: {card.BoneCost}");
				Logger.Log("CreateCard", "Info", $"SP Value: {SP}");
				Logger.Log("CreateCard", "Info", $"SPCost Value: {SPCost}");
			}
			return Cards;
		}
	}
}