using Terraria.ID;
using Terraria.ModLoader;
using Prism3.Tiles;
using Terraria;
using Terraria.DataStructures;

namespace Prism3.Items
{
    public class PulseateBar : ModItem
    {
        //todo:placeable
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It is pulsating with weird energy");
            // ticksperframe, frameCount
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(60, 11));
            ItemID.Sets.ItemIconPulse[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.value = 150 * 2;
            item.rare = ItemRarityID.LightPurple;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RoughtenBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<SharptenBar>(), 5);
            recipe.SetResult(this, 1);
            recipe.AddTile(ModContent.TileType<CombinationMechanism>());
            recipe.AddRecipe();
        }
    }
}