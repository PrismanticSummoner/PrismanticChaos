using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Projectiles
{
	public class AntimatterProjectile1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antimatter");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Meteor1);
			projectile.scale = 5;
			aiType = ProjectileID.Meteor1;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.Meteor1;
			return true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Electrified, 300);
		}
	}
}