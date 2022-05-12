using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SMGPack.Bullets
{
    class BoneShard : ModItem
    {
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Fragments of Bone that cause bleeding");
        }

        public override void SetDefaults()
        {
            item.damage = 6;
            item.ranged = true;
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 0f;
            item.value = Item.sellPrice(0, 0, 0, 1);
            item.rare = ItemRarityID.White;
            item.shoot = ModContent.ProjectileType<Projectiles.BoneProj1>();
            item.ammo = item.type; // The first item in an ammo class sets the AmmoID to it's type
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 1);
            recipe.SetResult(this, 25);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }
}
