using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace SMGPackTerraria.Buffs
{
    public class PoisonBulletBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Poisoned");
            Description.SetDefault("Poisoned Bullet fragments are inflicting damage");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<SMGPlayer>().BPoison = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<SMGGlobalNPC>().BPoison = true;
        }
    }
}
