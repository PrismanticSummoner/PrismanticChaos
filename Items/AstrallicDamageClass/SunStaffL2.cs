using Prism3.Projectiles.SunStaff;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Prism3.Items.AstrallicDamageClass
{
	public class SunStaffL2 : AstrallicDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sun Stave ( Stage 2 )");
			Tooltip.SetDefault("'See what did I say..? Keep pressing on!'");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 10;
			item.magic = true;
			item.mana = 0;
			item.width = 36;
			item.height = 32;
			item.useTime = 48;
			item.useAnimation = 48;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 12);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item83;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<StaveProjectileL2>();
			item.shootSpeed = 9f;
			item.crit = 8;

			astrallicResourceCost = 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sunflower, 5);
			recipe.AddIngredient(ModContent.ItemType<SunStaffL1>(), 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.NextBool(10))
			{
				float speedX2 = speedX * 2.0f;
				float speedY2 = speedY * 2.0f;
				Projectile.NewProjectile(position.X, position.Y, speedX2, speedY2, ModContent.ProjectileType<StaveProjectileL2>(), (int)((double)damage * 2.0), knockBack, player.whoAmI);
			}
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}