using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using Prism3.Items;

namespace Prism3.Items
{
    public class UniversalGoldAccessorie : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glistening Accessorie");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(20);
            item.accessory = true;
            item.value = Item.sellPrice(silver: 12);
            item.rare = ItemRarityID.Blue;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        { 
            player.allDamageMult += 0.15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}