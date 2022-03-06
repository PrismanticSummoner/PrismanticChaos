using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Prism3
{
    public class PrismPlayer : ModPlayer
    {
        public bool eFlames;
        public bool badHeal;

        public override void ResetEffects()
        {
            eFlames = false;
            badHeal = false;
        }
    }
}
