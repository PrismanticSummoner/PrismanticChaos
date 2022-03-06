using Prism3.Tiles;
using Prism3.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Prism3.Items.AstrallicDamageClass;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace Prism3
{
	public class Prism3 : Mod
	{
		private UserInterface _starpowerResourceBarUserInterface;

		internal StarpowerBar StarpowerBar;




        public override void Load()
        {
			StarpowerBar = new StarpowerBar();
			_starpowerResourceBarUserInterface = new UserInterface();
			_starpowerResourceBarUserInterface.SetState(StarpowerBar);
		}

        public override void UpdateUI(GameTime gameTime)
        {
			_starpowerResourceBarUserInterface?.Update(gameTime);	
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (resourceBarIndex != -1)
			{
				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
					"PrismanticChaos: Starpower Bar",
					delegate {
						_starpowerResourceBarUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
    }
}