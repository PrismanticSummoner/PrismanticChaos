using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Prism3.Buffs.Buff;

namespace Prism3.Projectiles.SunStaff
{
	internal class SpaceProjectile : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astral Calamity");
		}

		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 26;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.tileCollide = false;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.NPCHit29, projectile.position);
			for (int i = 0; i < 6; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 54, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[Main.myPlayer];
			player.AddBuff(BuffID.Featherfall, 600);
			player.AddBuff(ModContent.BuffType<StarPOWER>(), 600);
			target.AddBuff(BuffID.Obstructed, 300);
		}

		public override void AI()
		{

			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation += MathHelper.Pi;
			}
		}
	}
}