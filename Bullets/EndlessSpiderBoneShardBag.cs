using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SMGPackTerraria.Bullets
{
    class EndlessSpiderBoneShardBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Endless Bag of Spider Bone Fragments");
        }

        public override void SetDefaults()
        {
            item.damage = 11;
            item.ranged = true;
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.consumable = false;
            item.knockBack = 0f;
            item.value = Item.sellPrice(0, 0, 40, 95);
            item.rare = ItemRarityID.LightRed;
            item.shoot = ModContent.ProjectileType<Projectiles.SpiderBoneProj1>();
            item.ammo = ModContent.ItemType<BoneShard>(); // The first item in an ammo class sets the AmmoID to it's type
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SpiderBoneShard>(), 3996);
            recipe.SetResult(this);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }
}
