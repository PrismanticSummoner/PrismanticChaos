using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Prism3.Projectiles
{
    public class TearOfGods : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tear of Gods");
        }

        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 90;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.alpha = 30;
        }

        public override void AI()
        {
            if (projectile.position.Y > Main.player[projectile.owner].position.Y + 400)
            {
                projectile.Kill();
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.CornflowerBlue * 0.8f;
        }
    }
}