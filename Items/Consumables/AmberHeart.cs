﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class AmberHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 5");
			DisplayName.SetDefault("Amber Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = ItemRarityID.LightRed;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().AmberLife <
				   player.GetModPlayer<ElementalHeartsPlayer>().ElementalHeartMax;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 5;
			player.statLife += 5;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(5, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().AmberLife += 1;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amber, 25);
			recipe.AddIngredient(ItemID.StoneBlock, 75);
			recipe.AddTile(TileID.Extractinator);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
