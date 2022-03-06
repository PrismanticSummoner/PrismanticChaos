using Prism3.Tiles;
using Terraria;
using Prism3.Items;
using Prism3.Items.AstrallicDamageClass;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class FrostniteHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Frostnite Hat");
			Tooltip.SetDefault("A hat made of wood...not the weirdest thing I've seen honestly"
				+ "\nSlightly increases astrallic damage");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 14;
			item.value = 10000;
			item.rare = ItemRarityID.Cyan;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			var modPlayer = AstrallicDamagePlayer.ModPlayer(player);
			modPlayer.astrallicDamageMult += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Frostnite>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}