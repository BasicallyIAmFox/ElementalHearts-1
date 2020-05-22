using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.DevStuff.CAT
{
	[AutoloadEquip(EquipType.Head)]
	public class MaskOfCAT : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Maskof");
			Tooltip.SetDefault("'Great for impersonating devs!'");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = 9;
			item.vanity = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<RobeOfCAT>()/* && legs.type == ItemType<ExampleLeggings>()*/;
		}

		public override void UpdateEquip(Player player) {
			if (player.name == "CAT") {
				player.buffImmune[39] = true;
				player.statManaMax2 += 20;
				player.maxMinions++;
				player.magicDamage -= .5f;
			}
			if (player.name == "AstralCat") {
				player.buffImmune[39] = true;
				player.statManaMax2 += 20;
				player.maxMinions++;
				player.magicDamage += .5f;
			}
		}
	}
}