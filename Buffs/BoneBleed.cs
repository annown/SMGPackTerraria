using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace SMGPackTerraria.Buffs
{
    public class BoneBleed : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bleed");
            Description.SetDefault("Bone Shards are causing blood loss");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<SMGPlayer>().BBleed = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<SMGGlobalNPC>().BBleed = true;
        }
    }
}
