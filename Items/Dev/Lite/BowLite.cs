﻿using ElementalHearts.Items.Dev.CAT;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;

namespace ElementalHearts.Items.Dev.Lite
{
	public class BowLite : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Great for impersonating devs!' \nShoots 4 homing chlorophyte bullets when shot. \nHas a chance to shoot ichor darts in the direction of fire. \nHas a chance to spawn an array of homing chlorophyte bullets on impact. \nHas a chance to deploy rockets from the player upon impact. \nHas a small chance to deploy fireworks upon impact.");
			DisplayName.SetDefault("Bow Lite");
		}
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.autoReuse = true;
			item.useAnimation = 24;
			item.useTime = 24;
			item.width = 50;
			item.height = 18;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.damage = 60;
			item.crit = 3;
			item.knockBack = 1.5f;
			item.rare = ItemRarityID.Cyan;
		}
		//TestTestT
		public override void OnConsumeAmmo(Player player)
		{
			if (Main.rand.NextBool(2))
			{
				if (Main.rand.NextBool(4))
				{
					Projectile.NewProjectile(player.position, player.velocity + new Vector2(0, 10), ProjectileID.RocketIII, 150 / 2, 0f, player.whoAmI);
					Projectile.NewProjectile(player.position, player.velocity + new Vector2(0, -10), ProjectileID.RocketIII, 150 / 2, 0f, player.whoAmI);
				}
				if (Main.rand.NextBool(4))
				{
					Projectile.NewProjectile(player.position, player.velocity + new Vector2(10, 0), ProjectileID.RocketIII, 150 / 2, 0f, player.whoAmI);
					Projectile.NewProjectile(player.position, player.velocity + new Vector2(-10, 0), ProjectileID.RocketIII, 150 / 2, 0f, player.whoAmI);
				}
			} else {
				if (Main.rand.NextBool(4))
				{
					Projectile.NewProjectile(player.position, new Vector2(10, 0), ProjectileID.RocketFireworkRed, 100 / 2, 0f, player.whoAmI);
				}
				if (Main.rand.NextBool(4))
				{
					Projectile.NewProjectile(player.position, new Vector2(-10, 0), ProjectileID.RocketFireworkGreen, 125 / 2, 0f, player.whoAmI);
				}
				if (Main.rand.NextBool(4))
				{
					Projectile.NewProjectile(player.position, new Vector2(0, 10), ProjectileID.RocketFireworkBlue, 150 / 2, 0f, player.whoAmI);
				}
				if (Main.rand.NextBool(4))
				{
					Projectile.NewProjectile(player.position, new Vector2(0, -10), ProjectileID.RocketFireworkYellow, 200 / 2, 0f, player.whoAmI);
				}
			}			
			base.OnConsumeAmmo(player);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(player.position, new Vector2(speedX + 5, speedY), ProjectileID.ChlorophyteBullet, 15 / 2, 1.5f, player.whoAmI);
			Projectile.NewProjectile(player.position, new Vector2(speedX - 5, speedY), ProjectileID.ChlorophyteBullet, 15 / 2, 1.5f, player.whoAmI);
			Projectile.NewProjectile(player.position, new Vector2(speedX + 10, speedY), ProjectileID.ChlorophyteBullet, 15 / 2, 1.5f, player.whoAmI);
			Projectile.NewProjectile(player.position, new Vector2(speedX - 10, speedY), ProjectileID.ChlorophyteBullet, 15 / 2, 1.5f, player.whoAmI);

			if (Main.rand.NextBool(2))
			{
				Projectile.NewProjectile(player.position, new Vector2(speedX, speedY), ProjectileID.IchorDart, 10 / 2, 2f, player.whoAmI);
				if (Main.rand.NextBool(4))
				{
					Projectile.NewProjectile(player.position, new Vector2(speedX, speedY), ProjectileID.IchorDart, 15 / 2, 2f, player.whoAmI);
					if (Main.rand.NextBool(6))
					{
						Projectile.NewProjectile(player.position, new Vector2(speedX, speedY), ProjectileID.IchorDart, 20 / 2, 2f, player.whoAmI);
						if (Main.rand.NextBool(8))
						{
							Projectile.NewProjectile(player.position, new Vector2(speedX, speedY), ProjectileID.IchorDart, 25 / 2, 2f, player.whoAmI);
						}
					}
				}
			}
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}
