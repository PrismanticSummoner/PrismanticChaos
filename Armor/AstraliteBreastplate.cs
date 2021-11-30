﻿using Prism3.Tiles;
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
			Tooltip.SetDefault("This is a modded body armor."
				+ "\nImmunity to 'Weakness, Frozen, and Mana Sickness!'"
				+ "\nIncrease all damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.LightPurple;
			item.defense = 30;
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.Weak] = true;
			player.buffImmune[BuffID.Frozen] = true;
			player.buffImmune[BuffID.ManaSickness] = true;
			player.allDamage += 0.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AstraliteBar>(), 23);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}