using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Prism3.Tiles;

namespace Prism3.Items
{
	public class SharptenBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[item.type] = 69; // influences the inventory sort order. 59 is PlatinumBar, higher is more valuable.
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 750;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.BarSharpten>();
			item.placeStyle = 0;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe.AddIngredient(ItemID.IronBar, 1);
			recipe.AddTile(ModContent.TileType<CombinationMechanism>());
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.DemoniteBar, 10);
			recipe2.AddIngredient(ItemID.IronBar, 1);
			recipe2.AddTile(ModContent.TileType<CombinationMechanism>());
			recipe2.SetResult(this);
			recipe2.AddRecipe();

			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe3.AddIngredient(ItemID.LeadBar, 1);
			recipe3.AddTile(ModContent.TileType<CombinationMechanism>());
			recipe3.SetResult(this);
			recipe3.AddRecipe();

			ModRecipe recipe4 = new ModRecipe(mod);
			recipe4.AddIngredient(ItemID.DemoniteBar, 10);
			recipe4.AddIngredient(ItemID.LeadBar, 1);
			recipe4.AddTile(ModContent.TileType<CombinationMechanism>());
			recipe4.SetResult(this);
			recipe4.AddRecipe();
		}
	}
}