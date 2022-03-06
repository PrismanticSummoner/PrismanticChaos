using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Prism3.Projectiles
{
    public class HeavensTear : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavens Tear");
        }

        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.hide = true;
            projectile.ownerHitCheck = false;
            projectile.magic = true;
            projectile.alpha = 30;
        }

        public override void AI()
        {
            projectile.soundDelay--;
            if (projectile.soundDelay <= 0)
            {
                //sound 2 = item sound.
                Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 15);
                projectile.soundDelay = 45;
            }
            Player player = Main.player[projectile.owner];
            if (Main.myPlayer == projectile.owner)
            {
                if (!player.channel || player.noItems || player.CCed)
                {
                    projectile.Kill();
                }
                else
                {
                    projectile.ai[0] -= 1f;
                    if (projectile.ai[0] <= 0f)
                    {
                        CreateTear();
                        projectile.ai[0] = 3f;
                    }
                }
            }
            Lighting.AddLight(projectile.Center, 0.3f, 1f, 0.3f);
            projectile.Center = player.MountedCenter;
            projectile.position.X += player.width / 2 * player.direction;
            projectile.spriteDirection = player.direction;
            projectile.timeLeft = 2;
            if (projectile.rotation > MathHelper.TwoPi)
            {
                projectile.rotation -= MathHelper.TwoPi;
            }
            else if (projectile.rotation < 0)
            {
                projectile.rotation += MathHelper.TwoPi;
            }
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = projectile.rotation;
        }

        private void CreateTear()
        {
            Player player = Main.player[projectile.owner];
            float x = player.Center.X + 2f * Main.rand.Next(-300, 301);
            float y = player.Center.Y - 400f;
            Projectile.NewProjectile(x, y, 0f, 12f, mod.ProjectileType("TearOfGods"), projectile.damage, projectile.knockBack, projectile.owner);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 5;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
    }
}