using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Projectiles
{
	public class HeavensFallProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heaven's Fall Projectile");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.StarWrath);
			aiType = ProjectileID.StarWrath;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.StarWrath;
			return true;
		}
	}
}