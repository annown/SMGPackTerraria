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

namespace SMGPackTerraria
{
    public class SMGPlayer : ModPlayer
    {
        public bool BBleed;
        public bool BPoison;

        public override void ResetEffects()
        {
            BBleed = false;
            BPoison = false;
        }
        public override void UpdateDead()
        {
            BBleed = false;
            BPoison = false;
        }
        public override void UpdateBadLifeRegen()
        {
            if (BBleed)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 12;
            }
            if (BPoison)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 8;
            }
        }
    }
}
