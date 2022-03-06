using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Prism3.Items.Boss
{
    class AstrallicWizardTreasureBag : ModItem
    {
        public override int BossBagNPC => mod.NPCType("AstrallicWizard");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("<right> to open");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Cyan;
            item.expert = true;
        }

        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(ItemID.GoldCoin, 5);
            player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 10));
            player.QuickSpawnItem(ItemID.GreaterManaPotion, Main.rand.Next(5, 10));
            player.QuickSpawnItem(ModContent.ItemType<AstraliteOre>(), 30);
            if(Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("EerieGlobe"));
            }
            if(Main.rand.Next(100) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("AstrallicWizardTreasureBag"));
            }
        }
    }
}
