using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ElementalHearts.Projectiles.Bosses.MenacingHeart;
using System;
using Microsoft.Xna.Framework.Audio;

namespace ElementalHearts.NPCs.Bosses.MenacingHeart
{
    public class MenacingHeartClone : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Heart");
        }
        public override void SetDefaults()
        {
            npc.aiStyle = 0;
            npc.alpha = 128;
            npc.width = 128;
            npc.height = 128;
            npc.damage = 50;
            npc.defense = -10;
            npc.lifeMax = 10;
            npc.HitSound = SoundID.Item35;
            npc.DeathSound = SoundID.Item25;
            npc.value = 10000;
            npc.buffImmune[BuffID.Confused] = true;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.timeLeft = 1;
            base.SetDefaults();
        }
    }
}