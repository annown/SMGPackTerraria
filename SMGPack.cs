using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace SMGPackTerraria
{
	public class SMGPackTerraria : Mod
	{
        public SMGPackTerraria()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadBackgrounds = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
    }
}