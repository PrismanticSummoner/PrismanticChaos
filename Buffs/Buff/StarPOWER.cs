using Terraria;
using Terraria.ModLoader;
using Prism3.Items.AstrallicDamageClass;

namespace Prism3.Buffs.Buff
{
    public class StarPOWER : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("StarPOWER");
            Description.SetDefault("POWERRRRR");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var modPlayer = AstrallicDamagePlayer.ModPlayer(player);
            modPlayer.astrallicResourceMax2 += 50;
            modPlayer.astrallicResourceRegenRate -= 0.2f;
            modPlayer.astrallicDamageMult += 0.3f;
        }
    }
}
