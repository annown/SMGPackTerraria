using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace SMGPackTerraria
{
    class SMGGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool BBleed;
        public bool BPoison;

        public override void ResetEffects(NPC npc)
        {
            BBleed = false;
            BPoison = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (BBleed)
            {
                if(npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 24;
            }
            if (BPoison)
            {
                if(npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 16;
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (BBleed)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), 2, 2, DustID.Blood, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, Color.Red, 1f);
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
            }
            if (BPoison)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), 2, 2, DustID.Poisoned, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, Color.DarkSeaGreen, 1f);
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
            }
        }
    }
}
