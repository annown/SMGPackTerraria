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
    class ShroomiteSMG : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite SMG");
            Tooltip.SetDefault("25% chance to not consume ammo +/n Sometimes shoots spores");
        }
        public override void SetDefaults()
        {
            item.scale = 1.2f;
            item.ranged = true;
            item.shoot = 10;
            item.shootSpeed = 8;
            item.useAnimation = 9;
            item.useTime = 9;
            item.useStyle = 5;
            item.UseSound = SoundID.Item11;
            item.damage = 44;
            item.noMelee = true;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 1f;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.sellPrice(0, 3, 24, 95);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 2);
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .25f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(20) == 1)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Projectiles.Spore>(), damage, knockBack, player.whoAmI);
            }
            return true;
        }
        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            // Here we use the multiplicative damage modifier because Terraria does this approach for Ammo damage bonuses. 
            mult *= player.bulletDamage;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 5);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }
}