using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SMGPackTerraria.Projectiles
{
    class SpiderBombSpider : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spider");
            Main.projFrames[projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 360;
            projectile.penetrate = 1;
            projectile.aiStyle = -1;
            projectile.width = 21;
            projectile.height = 7;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.knockBack = 1f;
            projectile.scale = 0.7f;
        }
        private int FrameTimer = 0;
        private int Direction = Main.rand.Next(2);
        private int velocityY = 1;
        private int velYTimer = 0;

        public override void AI()
        {
            if (Direction == 0)
            {
                projectile.velocity.X = -2;
            }
            if (Direction == 1)
            {
                projectile.velocity.X = 2;
            }
            if (projectile.oldPosition.Y < projectile.position.Y && velocityY <= 6)
            {
                if (velYTimer == 5)
                {
                    velocityY += 1;
                    velYTimer = 0;
                }
                velYTimer += 1;
            }
            if (projectile.oldPosition.Y == projectile.position.Y)
            {
                velocityY = 1;
            }
            projectile.velocity.Y = velocityY;
            FrameTimer += 1;
            if (FrameTimer == 7)
            {
                projectile.frame += 1;
                FrameTimer = 0;
            }
            if (projectile.frame >= 2)
            {
                projectile.frame = 0;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
        public override void Kill(int timeLeft)
        {
            int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
            Main.dust[dustIndex].velocity *= 1.4f;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.velocity.X < 0)
            {
                projectile.spriteDirection = 1;
            }
            if (projectile.velocity.X > 0)
            {
                projectile.spriteDirection = -1;
            }
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 7;
        }
    }
}