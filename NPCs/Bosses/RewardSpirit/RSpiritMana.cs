using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ElementalHearts.NPCs.Bosses.RewardSpirit
{
    public class RSpiritMana : ModProjectile
    {
        private float velX = 0;
        private int time = 0;
        private float velIncreaseY = 0.0f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal");
            Main.projFrames[projectile.type] = 8;
        }
        public override void SetDefaults()
        {
            projectile.penetrate = -1;
            projectile.width = 22;
            projectile.height = 24;
            projectile.alpha = 0;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = false;
            projectile.timeLeft = 1000;
            if (Main.rand.NextBool(3))
            { velX = -1.5f; }
            else if (Main.rand.NextBool(3))
            { velX = 0f; }
            else { velX = 1.5f; }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.ai[1] == 1.0f)
            {
                return Color.Red;
            }
            return Color.Goldenrod;
        }
        public override void AI()
        {
            if (projectile.alpha > 255)
            {
                projectile.Kill();
            }
            projectile.rotation += 0.08f;
            projectile.velocity.X = velX;

            if (projectile.ai[1] == 0.0f)
            {
                velIncreaseY += 0.05f;
                projectile.velocity.Y = 3f + velIncreaseY;
                if (time++ > 60)
                { projectile.velocity.Y = 2f + velIncreaseY; }
                else if (time++ > 120)
                { projectile.velocity.Y = 1f + velIncreaseY; }
            }
            else
            {
                projectile.velocity.X = velX;
                projectile.rotation -= 0.16f;
                velIncreaseY += 0.05f;
                projectile.velocity.Y = -3f - velIncreaseY;
                if (time++ > 60)
                { projectile.velocity.Y = -2f - velIncreaseY; }
                else if (time++ > 120)
                { projectile.velocity.Y = -1f - velIncreaseY; }
            }

            projectile.frameCounter++;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
                if (projectile.frame > 7)
                {
                    projectile.frame = 0;
                }
            }
        }
    }
}