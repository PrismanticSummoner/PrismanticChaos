using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Items
{
	public class CombineMech : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Combination Mechanism");
			Tooltip.SetDefault("A machine made to create, otherwise unheard of, mixtures of elements");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150;
			item.createTile = ModContent.TileType<Tiles.CombinationMechanism>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wire, 10);
			recipe.AddIngredient(ItemID.Bottle, 2);
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.Wire, 10);
			recipe2.AddIngredient(ItemID.Bottle, 2);
			recipe2.AddIngredient(ItemID.LeadBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
}