using Prism3.Tiles;
using Terraria;
using Prism3.Items;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class AstraliteHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Astralite Hat");
			Tooltip.SetDefault("Armor forged from the purest of Astralite"
				+ "\nImmunity to 'Broken Armor, Ichor, and Cursed'");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.LightPurple;
			item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.BrokenArmor] = true;
			player.buffImmune[BuffID.Ichor] = true;
			player.buffImmune[BuffID.Cursed] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AstraliteBar>(), 13);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}