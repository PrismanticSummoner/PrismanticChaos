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
	public class JungleScepter : AstrallicDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle Scepter ( Stage 4 : Jungle )");
			Tooltip.SetDefault("'STUPID ENEMIES, WHY IS THERE A GIANT TURTLE, BATS EVERYWHERE, BEES NOT THE BEEESSSSSS!!!!");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 30;
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
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item83;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<JungleScepterProjectile>();
			item.shootSpeed = 9f;
			item.crit = 8;

			astrallicResourceCost = 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleGrassSeeds, 5);
			recipe.AddIngredient(ModContent.ItemType<SunStaffL3>(), 1);
			recipe.AddIngredient(ItemID.Moonglow, 2);
			recipe.AddIngredient(ItemID.RichMahogany, 20);
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
				Projectile.NewProjectile(position.X, position.Y, speedX2, speedY2, ModContent.ProjectileType<JungleProjectile>(), (int)((double)damage * 2.0), knockBack, player.whoAmI);
			}
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}