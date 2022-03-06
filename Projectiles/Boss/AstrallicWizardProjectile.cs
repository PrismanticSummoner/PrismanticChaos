using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Prism3.Projectiles.Boss
{
    class AstrallicWizardProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astrallic Sigil");
        }

        public override void SetDefaults()
        {
            projectile.width = 41;
            projectile.height = 41;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 500;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.scale = 1.2f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.Purple;
        }

        public override void AI()
        {
            projectile.velocity.Y += projectile.ai[0];
        }
    }
}
