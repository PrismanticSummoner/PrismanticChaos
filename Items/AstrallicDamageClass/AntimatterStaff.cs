using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Prism3.Dusts;
using Prism3.Projectiles;
using Terraria.ID;

namespace Prism3.Items.AstrallicDamageClass
{
	public class AntimatterStaff : AstrallicDamageItem
	{
		// This is a staff that uses the example damage class stuff you've set up before, but uses exampleResource instead of mana.
		// This is a very simple way of doing it, and if you plan on multiple items using exampleResource then I'd suggest making a new abstract ModItem class that inherits ExampleDamageItem,
		// and doing the CanUseItem and UseItem in a more generalized way there, so you can just define the resource usage in SetDefaults and it'll do it automatically for you.
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antimatter Staff");
			Tooltip.SetDefault("Creates a meteor of antimatter to crush enemies and inflict the shocked debuff!");
		}

		public override void SafeSetDefaults()
		{
			item.CloneDefaults(ItemID.MeteorStaff);
			item.Size = new Vector2(32, 32);
			item.damage = 32;
			item.knockBack = 3;
			item.rare = ItemRarityID.Red;
			item.mana = 0; // Make sure to nullify the mana usage of the staff here, as it still copies the setdefaults of the amethyst staff.
			item.useStyle = ItemUseStyleID.HoldingUp;

			// exampleResourceCost is a field in the base class ExampleDamageItem. This item consumes 10 Example Resource to use.
			astrallicResourceCost = 10;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ModContent.ProjectileType<AntimatterProjectile1>();
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WandofSparking, 1);
			recipe.AddIngredient(ModContent.ItemType<AstraliteOre>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
