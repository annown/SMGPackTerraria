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
    class JungleSMG : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle SMG");
            Tooltip.SetDefault("Converts bullets into Poisoned bullets");
        }
        public override void SetDefaults()
        {
            item.scale = 1.2f;
            item.ranged = true;
            item.shoot = 10;
            item.shootSpeed = 5;
            item.useAnimation = 10;
            item.useTime = 10;
            item.useStyle = 5;
            item.UseSound = SoundID.Item11;
            item.damage = 8;
            item.noMelee = true;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 0f;
            item.rare = 2;
            item.value = Item.sellPrice(0, 0, 14, 95);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 2);
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .25f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = ModContent.ProjectileType<Projectiles.JungleBullet>();
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores, 6);
            recipe.AddIngredient(ItemID.Vine, 2);
            recipe.AddIngredient(ItemID.Stinger, 3);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }
}