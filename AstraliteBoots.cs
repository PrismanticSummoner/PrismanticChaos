using Prism3.Tiles;
using Terraria;
using Prism3.Items;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class AstraliteBoots : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Astralite Leggings");
			Tooltip.SetDefault("Armor forged from the purest of Astralite"
				+ "\nImmunity to 'On Fire, Bleeding, and Poisoned!'");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.LightPurple;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Bleeding] = true;
			player.buffImmune[BuffID.Poisoned] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AstraliteBar>(), 15);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}