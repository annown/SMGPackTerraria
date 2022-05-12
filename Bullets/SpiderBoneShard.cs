using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SMGPackTerraria.Bullets
{
    class SpiderBoneShard : ModItem
    {
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Deals Additional Damage and Applies Bleeding");
        }

        public override void SetDefaults()
        {
            item.damage = 11;
            item.ranged = true;
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 0f;
            item.value = Item.sellPrice(0, 0, 0, 1);
            item.rare = ItemRarityID.LightRed;
            item.shoot = ModContent.ProjectileType<Projectiles.SpiderBoneProj1>();
            item.ammo = ModContent.ItemType<BoneShard>(); // The first item in an ammo class sets the AmmoID to it's type
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpiderFang, 1);
            recipe.SetResult(this, 100);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }
}
