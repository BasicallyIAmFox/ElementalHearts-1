using ElementalHearts.Items.Accessories;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using ElementalHearts.NPCs.Bosses.MenacingHeart;

namespace ElementalHearts.Items.Boss
{
	public class AbominationBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Menacing Heart Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Expert;
			item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) {
			player.TryGettingDevArmor();
			if (Main.rand.NextBool(7)) {
				//player.QuickSpawnItem(ItemType<AbominationMask>());
			}
			player.QuickSpawnItem(ItemType<MenacingLookingPendant>());
		}

		public override int BossBagNPC => NPCType<MenacingHeart>();
	}
}