﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables.Bosses.CrossMod
{
    internal class RadiantHeart : AncientsAwakaenedCrossModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 15");
            DisplayName.SetDefault("Radiant Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Expert;
            item.value = 0;
            item.expert = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().RadiantLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 15;
            player.statLife += 15;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(15, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().RadiantLife += 1;
            return true;
        }
    }
}
