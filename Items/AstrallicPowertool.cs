using Prism3.Items;
using Prism3;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Items
{
	public class AstrallicPowertool : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A tool to serve all of your basic needs....except hammering");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 2;
			item.useAnimation = 10;
			item.pick = 50;
			item.axe = 50;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AstraliteBar>(), 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}