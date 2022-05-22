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
    class LuminiteSMG : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luminite SMG");
            Tooltip.SetDefault("60% chance to not consume ammo\nTwo Barrels for extreme speed");
        }
        public override void SetDefaults()
        {
            item.scale = .8f;
            item.ranged = true;
            item.shoot = 10;
            item.shootSpeed = 10;
            item.useAnimation = 4;
            item.useTime = 4;
            item.useStyle = 5;
            item.reuseDelay = 4;
            item.UseSound = SoundID.Item11;
            item.damage = 42;
            item.noMelee = true;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 0f;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.sellPrice(0, 8, 34, 95);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 2);
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .60f;

        }
        private int barrel = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 1;
            float rotation = MathHelper.ToRadians(0);
            barrel++;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, 1)); // Watch out for dividing by 0 if there is only 1 projectile.
                if (barrel == 1)
                {
                    Projectile.NewProjectile(position.X - 5, position.Y - 5, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
                if (barrel == 2)
                {
                    Projectile.NewProjectile(position.X + 5, position.Y + 5, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                    barrel = 0;
                }
            }
            return false;
        }
        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            // Here we use the multiplicative damage modifier because Terraria does this approach for Ammo damage bonuses. 
            mult *= player.bulletDamage;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 6);
            recipe.SetResult(this);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.AddRecipe();
        }
    }
}