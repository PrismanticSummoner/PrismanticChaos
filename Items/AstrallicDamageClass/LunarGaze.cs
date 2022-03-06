using Microsoft.Xna.Framework;
using Terraria;
using Prism3.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Items.AstrallicDamageClass
{
	public class LunarGaze : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Further Increases Starpower Regen Rate!"
				+ "\n Increases Astrallic Damage");
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
			modPlayer.astrallicResourceMax2 += 100;
			modPlayer.astrallicResourceRegenRate -= 0.75f;
			modPlayer.astrallicDamageMult += 0.3f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<StarryGaze>(), 1);
			recipe.AddIngredient(ItemID.ManaCrystal, 1);
			recipe.AddTile(ModContent.TileType<CombinationMechanism>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
