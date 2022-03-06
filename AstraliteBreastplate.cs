using Prism3.Tiles;
using Terraria;
using Prism3.Items;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class AstraliteBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Astralite Breastplate");
			Tooltip.SetDefault("Armor forged from the purest of Astralite"
				+ "\nImmunity to 'Weakness, Frozen, and Cursed Flames!'");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.LightPurple;
			item.defense = 20;
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.Weak] = true;
			player.buffImmune[BuffID.Frozen] = true;
			player.buffImmune[BuffID.CursedInferno] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AstraliteBar>(), 23);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}