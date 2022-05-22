using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SMGPackTerraria.SMGs
{
    class SpookySMG : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spooky SMG");
        }
        public override void SetDefaults()
        {
            item.scale = 1.4f;
            item.ranged = true;
            item.shoot = 10;
            item.shootSpeed = 8;
            item.useAnimation = 7;
            item.useTime = 7;
            item.useStyle = 5;
            item.UseSound = SoundID.Item11;
            item.damage = 38;
            item.noMelee = true;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 0f;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.sellPrice(0, 1, 29, 95);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 2);
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .33f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1; //in case i wanted to change it?
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(2)); // 8 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                                                                                                                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                                // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpookyWood, 85);
            recipe.SetResult(this);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }
}