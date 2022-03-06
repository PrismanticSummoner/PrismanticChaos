using Prism3.Tiles;
using Terraria;
using Prism3.Items;
using Terraria.ID;
using Terraria.ModLoader;
using Prism3.Items.AstrallicDamageClass;

namespace Prism3.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class FrostniteBoots : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Frostnite Boots");
			Tooltip.SetDefault("Frozen wood armor...I mean I guess its a start."
				+ "\nSlightly increases astrallic damage");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Cyan;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			var modPlayer = AstrallicDamagePlayer.ModPlayer(player);
			modPlayer.astrallicDamageMult += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Frostnite>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}