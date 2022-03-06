using Prism3.Tiles;
using Terraria;
using Prism3.Items.AstrallicDamageClass;
using Prism3.Items;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class FrostniteRobe : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Frostnite Robe");
			Tooltip.SetDefault("How did you even manage to make a robe from frozen woo-... you know what don't answer that."
				+ "\nSlightly increases astrallic damage");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 26;
			item.value = 10000;
			item.rare = ItemRarityID.Cyan;
			item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			var modPlayer = AstrallicDamagePlayer.ModPlayer(player);
			modPlayer.astrallicDamageMult += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Frostnite>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}