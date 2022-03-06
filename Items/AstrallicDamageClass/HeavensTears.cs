using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.Items.AstrallicDamageClass
{
    public class HeavensTears : AstrallicDamageItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The gods have seen what you've done and they weep"
                + "\n Summons the tears of gods to rain down on your enemies");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 20;
            item.magic = true;
            item.width = 28;
            item.height = 30;
            item.useTime = 10;
            item.useAnimation = 10;
            item.channel = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.useStyle = 100;
            item.knockBack = 8f;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.autoReuse = false;
            item.mana = 0;
            item.shoot = mod.ProjectileType("HeavensTear");
            item.shootSpeed = 0f;

            astrallicResourceCost = 5;
        }

        public override bool UseItemFrame(Player player)
        {
            player.bodyFrame.Y = 3 * player.bodyFrame.Height;
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddIngredient(ModContent.ItemType<AstraliteBar>(), 4);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}