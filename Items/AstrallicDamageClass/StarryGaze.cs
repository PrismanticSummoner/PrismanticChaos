using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Items.AstrallicDamageClass
{
	public class StarryGaze : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("\nDrastically increased sarpower regen rate");
		}

		public override void SetDefaults()
		{
			item.Size = new Vector2(32);
			item.rare = ItemRarityID.Red;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var modPlayer = AstrallicDamagePlayer.ModPlayer(player);
			modPlayer.astrallicResourceMax2 += 50; 
			modPlayer.astrallicResourceRegenRate -= 0.5f; 
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 1);
			recipe.AddIngredient(ItemID.Lens, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
