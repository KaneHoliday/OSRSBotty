﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Scripts
{
    internal class Granite
    {

        Inventory inv = new Inventory();
        public Player player = new Player();
        Peripherals peripherals = new Peripherals();
        Interfaces interfaces = new Interfaces();

        public int[] gameScreenCoords = new int[2] { 0, 0 };

        public bool spec;

        public async void startScript()
        {
            firstRock();
        }

        public async void firstRock()
        {
            if (xpDrop())
            {
                drop();
                await Task.Delay(800);
                tick();
                await Task.Delay(250);
                peripherals.leftClick(394, 51);
                await Task.Delay(1000);
                secondRock();
            }
            else
            {
                await Task.Delay(50);
                firstRock();
            }
        }
        public async void secondRock()
        {
            if(xpDrop())
            {
                tick();
                await Task.Delay(250);
                peripherals.leftClick(344, 248);
                await Task.Delay(1000);
                thirdRock();
            } else
            {
                await Task.Delay(50);
                secondRock();
            }
        }
        public async void thirdRock()
        {
            if (xpDrop())
            {
                tick();
                await Task.Delay(250);
                peripherals.leftClick(342, 262);
                await Task.Delay(1000);
                fourthRock();
            }
            else
            {
                await Task.Delay(50);
                thirdRock();
            }
        }
        public async void fourthRock()
        {
            if (xpDrop())
            {
                tick();
                await Task.Delay(250);
                peripherals.leftClick(187, 266);
                await Task.Delay(1000);
                firstRock();
            }
            else
            {
                await Task.Delay(50);
                fourthRock();
            }
        }

        public async void tick()
        {
            peripherals.fastLeftClick(618, 226);
            while (peripherals.busy)
            {
                await Task.Delay(10);
            }
            peripherals.fastLeftClick(662, 262);
            while (peripherals.busy)
            {
                await Task.Delay(10);
            }
        }

        public async void drop()
        {
            peripherals.busy = true;
            peripherals.fastLeftClick(618, 258);
            while (peripherals.busy)
            {
                await Task.Delay(10);
            }
            peripherals.busy = true;
            peripherals.fastLeftClick(576, 259);
            while (peripherals.busy)
            {
                await Task.Delay(10);
            }
            peripherals.busy = true;
            peripherals.fastLeftClick(576, 294);
            while (peripherals.busy)
            {
                await Task.Delay(10);
            }
            peripherals.busy = true;
            peripherals.fastLeftClick(617, 295);
            while (peripherals.busy)
            {
                await Task.Delay(10);
            }
            peripherals.busy = true;
            peripherals.fastLeftClick(662, 292);
            while (peripherals.busy)
            {
                await Task.Delay(10);
            }
            peripherals.busy = true;
            peripherals.fastLeftClick(703, 297);
            while (peripherals.busy)
            {
                await Task.Delay(10);
            }
            if(checkSpec() && spec)
            {
                peripherals.busy = true;
                peripherals.fastLeftClick(585, 144);
                while (peripherals.busy)
                {
                    await Task.Delay(10);
                }
            }
        }


        public bool checkSpec()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(20, 20))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(gameScreenCoords[0] + 553, gameScreenCoords[1] + 145, 0, 0, new Size(20, 20));
                }

                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (bitmap.GetPixel(i, j).G == 255)
                        {
                            if (bitmap.GetPixel(i, j).R <= 255)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;

            }
        }
        public bool xpDrop()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(27, 67))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(gameScreenCoords[0] + 485, gameScreenCoords[1] + 85, 0, 0, new Size(27, 67));
                }

                for (int i = 0; i < 27; i++)
                {
                    for (int j = 0; j < 67; j++)
                    {
                        if (bitmap.GetPixel(i, j).G == 255 && bitmap.GetPixel(i, j).R == 255 && bitmap.GetPixel(i, j).B == 255)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void setCoords(int x, int y)
        {
            gameScreenCoords[0] = x;
            gameScreenCoords[1] = y;
            player.setCoords(x, y);
            interfaces.setCoords(x, y);
            peripherals.setCoords(x, y);
        }
    }
}
