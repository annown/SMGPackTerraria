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
    class SpiderSMG : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spider Fang SMG");
            Tooltip.SetDefault("Uses Bone Fragments as ammo\nRight Click to Shoot Spiders");
        }
        public override void SetDefaults()
        {
            item.scale = 1.2f;
            item.ranged = true;
            item.shootSpeed = 10;
            item.useAnimation = 9;
            item.useTime = 9;
            item.useTime = 9;
            item.useAnimation = 9;
            item.damage = 32;
            item.useStyle = 5;
            item.UseSound = SoundID.Item11;
            item.noMelee = true;
            item.autoReuse = true;
            item.knockBack = 0f;
            item.rare = 3;
            item.value = Item.sellPrice(0, 0, 28, 95);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 2);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = 5;
                item.useTime = 24;
                item.useAnimation = 24;
                item.damage = 8;
                item.useAmmo = ProjectileID.None;
                item.shoot = ModContent.ProjectileType<Projectiles.SpiderBombProj>();
            }
            else
            {
                item.useStyle = 5;
                item.useTime = 9;
                item.useAnimation = 9;
                item.damage = 34;
                item.useAmmo = ModContent.ItemType<Bullets.BoneShard>();
                item.shoot = ModContent.ProjectileType<Projectiles.BoneProj1>();
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1; //in case i wanted to change it?
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3)); // 6 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                                                                                                                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                                // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            // Here we use the multiplicative damage modifier because Terraria does this approach for Ammo damage bonuses. 
            mult *= player.bulletDamage;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpiderFang, 16);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }
}