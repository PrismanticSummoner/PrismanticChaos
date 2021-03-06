using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Projectiles.SunStaff
{
	internal class StaveProjectileL2 : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunflower");
		}

		public override void SetDefaults()
		{
			projectile.width = 34;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.tileCollide = false;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.NPCHit29, projectile.position);

			for (int i = 0; i < 3; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 292, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[Main.myPlayer];
			player.AddBuff(BuffID.Sunflower, 360);
			target.AddBuff(BuffID.OnFire, 120);
		}

		public override void AI()
		{
			if (projectile.timeLeft > 180)
				projectile.timeLeft = 180;

			Player player = Main.player[projectile.owner];
			float distanceFromTarget = 700f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;

			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				if (between < 2000f)
				{
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget)
			{
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy())
					{
						float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
						{
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}

			projectile.friendly = foundTarget;

			float speed = 8f;
			float inertia = 20f;

			if (foundTarget)
			{
				if (distanceFromTarget > 40f)
				{
					Vector2 direction = targetCenter - projectile.Center;
					direction.Normalize();
					direction *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			else
			{
				if (!foundTarget)
				{
					speed = 4f;
					inertia = 60f;
				}
				else
				{
					speed = 8f;
					inertia = 300f;
				}

				if (projectile.spriteDirection == -1)
				{
					projectile.rotation += MathHelper.Pi;
				}
			}

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