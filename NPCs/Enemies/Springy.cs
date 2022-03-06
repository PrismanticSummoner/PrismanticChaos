using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Prism3.NPCs.Enemies
{
    class Springy : ModNPC
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Springy");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            npc.width = 36;
            npc.height = 36;
            npc.aiStyle = 3;
            npc.damage = 10;
            npc.defense = 3;
            npc.lifeMax = 50;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.4f;
            npc.value = 60f;
            aiType = NPCID.Slimeling;
            animationType = NPCID.BlueSlime;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.3f;
        }
    }
}
