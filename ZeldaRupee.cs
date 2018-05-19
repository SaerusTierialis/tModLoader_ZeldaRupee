using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZeldaRupee
{
	class ZeldaRupee : Mod
	{
        public static Texture2D[] backupCoinItem = new Texture2D[4];
        public static Texture2D[] backupCoinGround = new Texture2D[4];
        public static SoundEffect[] backupCoinSound = new SoundEffect[5];

        public ZeldaRupee()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadSounds = true
			};
		}

        public override void Load()
        {
            if (!Main.dedServ)
            {
                /* ~~~~~~~~~~~~~~~~~~~~~~~ SPRITES ~~~~~~~~~~~~~~~~~~~~~~~ */

                //copper coin
                LoadCoinTexture(this, 0, ItemID.CopperCoin, "Items/CopperCoin", "Items/CopperCoin_Ground");

                //silver coin
                LoadCoinTexture(this, 1, ItemID.SilverCoin, "Items/SilverCoin", "Items/SilverCoin_Ground");

                //gold coin
                LoadCoinTexture(this, 2, ItemID.GoldCoin, "Items/GoldCoin", "Items/GoldCoin_Ground");

                //platinum coin
                LoadCoinTexture(this, 3, ItemID.PlatinumCoin, "Items/PlatinumCoin", "Items/PlatinumCoin_Ground");

                /* ~~~~~~~~~~~~~~~~~~~~~~~ SOUNDS ~~~~~~~~~~~~~~~~~~~~~~~ */
                LoadCoinSounds(this, "Sounds/OOT_Get_Rupee");
            }
        }

        public override void Unload()
        {
            if (!Main.dedServ)
            {
                /* ~~~~~~~~~~~~~~~~~~~~~~~ SPRITES ~~~~~~~~~~~~~~~~~~~~~~~ */
                UnloadCoinTexture(this, 0, ItemID.CopperCoin);
                UnloadCoinTexture(this, 1, ItemID.SilverCoin);
                UnloadCoinTexture(this, 2, ItemID.GoldCoin);
                UnloadCoinTexture(this, 3, ItemID.PlatinumCoin);

                /* ~~~~~~~~~~~~~~~~~~~~~~~ SOUNDS ~~~~~~~~~~~~~~~~~~~~~~~ */
                UnloadCoinSounds();
            }
        }

        public static void LoadCoinTexture(Mod mod, int coinInd, short coinID, string pathTextureItem, string pathTextureGround)
        {
            //backup
            backupCoinItem[coinInd] = Main.itemTexture[coinID];
            backupCoinGround[coinInd] = Main.coinTexture[coinInd];
            //set
            Main.itemTexture[coinID] = mod.GetTexture(pathTextureItem);
            Main.coinTexture[coinInd] = mod.GetTexture(pathTextureGround);
        }

        public static void UnloadCoinTexture(Mod mod, int coinInd, short coinID)
        {
            //set
            Main.itemTexture[coinID] = backupCoinItem[coinInd];
            Main.coinTexture[coinInd] = backupCoinGround[coinInd];
        }

        public static void LoadCoinSounds(Mod mod, string pathSound)
        {
            //backup
            for (int i = 0; i<4; i++)
            {
                backupCoinSound[i] = Main.soundCoin[i];
            }
            backupCoinSound[4] = Main.soundCoins;

            //set
            SoundEffect sound = mod.GetSound(pathSound);
            for (int i = 0; i < 4; i++)
            {
                Main.soundCoin[i] = sound;
            }
            Main.soundCoins = sound;
        }

        public static void UnloadCoinSounds()
        {
            //set
            for (int i = 0; i < 4; i++)
            {
                Main.soundCoin[i] = backupCoinSound[i];
            }
            Main.soundCoins = backupCoinSound[4];
        }

    }
}
