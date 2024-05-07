using BrickBreaker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Automation;

namespace BrickBreaker
{
    public class Powerup
    {
        public int id, x, y, radius;
        int fallSpeed;
        public double lifeSpan, activeTime;
        public Image image;
        int time = 0;
        public Rectangle rectangle;
        public int strength = 1;
        public Powerup(int _id, int _x, int _y)
        {
            #region Powerup Data
            string[][] powerupData = new string[][]
            {
                new string[]{"Fallspeed", "Activetime", "Png", "Radius" },

                new string[]{"3", "400", "apple", "10"},
                new string[]{"3", "400", "seeds", "10"},
                new string[]{"3", "700", "stone_pickaxe", "10"},
                new string[]{"4", "70", "iron_ingot", "10"},
                new string[]{"4", "30", "gold_ingot", "10"},

                new string[]{"4", "50", "diamond", "10"},
                new string[]{"4", "300", "quartz", "10"},
                new string[]{"4", "300", "netherite_ingot", "10"},
                new string[]{"4", "700", "ender_eye", "10"},
                new string[]{"4", "700", "brick", "10"},

                new string[]{"4", "700", "coal", "10"},
                new string[]{"4", "700", "water_breathing_effect", "10"},
                new string[]{"4", "700", "bucket_lava", "10"},
            };
            #endregion

            id = _id;
            x = _x;
            y = _y;
            fallSpeed = Convert.ToInt16(powerupData[id][0]);
            activeTime = lifeSpan = Convert.ToDouble(powerupData[id][1]);
            radius = Convert.ToInt16(powerupData[id][3]);
            ResourceManager rm = Resources.ResourceManager;
            image = (Image)rm.GetObject(powerupData[id][2]);
        }


        public double Age()
        {
            time++;
            activeTime -= 1;
            return activeTime / lifeSpan;
        }
        public bool[] Move(int bottom, Rectangle paddleRect)
        {
            bool[] removeMyself = new bool[] { false, false };
            time++;
            y += fallSpeed;
            rectangle = new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius);

            if (y > bottom)
            {
                removeMyself[0] = true;
            }
            if (paddleRect.IntersectsWith(rectangle))
            {
                removeMyself[0] = true;
                removeMyself[1] = true;
            }

            return removeMyself;
        }

        public void OnPickup()
        {
            switch (id)
            {
                case 1: //Apple
                    if (GameScreen.lives < GameScreen.MAX_LIVES)
                    {
                        GameScreen.lives++;
                    }
                    break;
                case 2: //Seeds
                    break;
                case 3: //Stone Pick
                    GameScreen.ball.image = Resources.stone_pickaxe;
                    GameScreen.ball.tools.Add("Pick");
                    GameScreen.ball.strength = strength + 1;
                    break;
                case 4: //Iron Ingot
                    GameScreen.ball.image = Resources.iron_pickaxe;
                    GameScreen.ball.tools.Add("Pick");
                    GameScreen.ball.strength = strength + 2;
                    break;
                case 5: //Gold Ingot
                    GameScreen.ball.image = Resources.gold_pickaxe;
                    GameScreen.ball.tools.Add("Pick");
                    GameScreen.ball.strength = strength + 3;
                    break;
                case 6: //Diamond
                    GameScreen.ball.image = Resources.diamond_pickaxe;
                    GameScreen.ball.tools.Add("Pick");
                    GameScreen.ball.strength = strength + 4;
                    break;
                case 7: //Quartz
                    break;
                case 8: //Netherite
                    GameScreen.ball.image = Resources.netherite_pickaxe;
                    GameScreen.ball.tools.Add("Pick");
                    GameScreen.ball.strength = strength + 5;
                    break;
                case 9: //Ender Eye
                    break;
                case 10: //Brick
                    break;
                case 11: //Coal
                    break;
                case 12: //Water
                    for (int i = 0; i < GameScreen.activePowerups.Count; i++)
                    {
                        if (GameScreen.activePowerups[i].id == 13) { GameScreen.activePowerups.RemoveAt(i); }
                    }
                    break;
                case 13: //Lava
                    for (int i = 0; i < GameScreen.activePowerups.Count; i++)
                    {
                        if (GameScreen.activePowerups[i].id == 12) { GameScreen.activePowerups.RemoveAt(i); }
                    }
                    break;
            }
        }
        public void WhileActive()
        {
            switch (id)
            {
                case 1: //Apple
                    if (activeTime % (57 - (3 * strength)) == 0)
                    {
                        string[] tools = new string[]
                     {
                            "Shears", "Axe", "Shovel"
                    };
                        Projectile p = new Projectile(0, -4 - (3 * strength), Resources.heart, 10 + (3 * strength), tools, strength);
                        GameScreen.projectiles.Add(p);
                    }
                    break;
                case 2: //Seeds
                    if (activeTime % (14 - (3 * strength)) == 0)
                    {
                        string[] tools = new string[]
                        {
                            "Shears", "Shovel"
                        };
                        Projectile p = new Projectile((int)(10.1 * Math.Sin(activeTime)), -12 - (3 * strength), Resources.wheat, 7 + (3 * strength), tools, strength);
                        GameScreen.projectiles.Add(p);
                    }
                    break;
                case 3: //Stone Pickaxe
                    break;
                case 4: //Iron Ingot
                    if (activeTime % Math.Abs(4 - (3 * strength)) == 0)
                    {
                        string[] tools = new string[]
                        {
                            "Pick"
                        };
                        Projectile p = new Projectile((int)(10.1 * Math.Sin(activeTime)), (int)(10.1 * (Math.Cos(activeTime))), Resources.iron_ingot, 8 + (3 * strength), tools, strength, new Point(GameScreen.ball.x, GameScreen.ball.y));
                        GameScreen.projectiles.Add(p);
                    }
                    break;
                case 5: //Gold Ingot
                    if (activeTime % (2 - Math.Abs(3 * strength)) == 0)
                    {
                        string[] tools = new string[]
                        {
                            "Pick"
                        };
                        Projectile p = new Projectile((int)(10.1 * Math.Sin(activeTime)), (int)(10.1 * (Math.Cos(activeTime))), Resources.gold_ingot, 8 + (3 * strength), tools, strength, new Point(GameScreen.ball.x, GameScreen.ball.y));
                        GameScreen.projectiles.Add(p);
                    }
                    break;
                case 6: //Diamond
                    if (activeTime % 3 == 0)
                    {
                        string[] tools = new string[]
                        {
                            "Pick"
                        };
                        Projectile p = new Projectile((int)(10.1 * Math.Sin(activeTime)), (int)(10.1 * (Math.Cos(activeTime))), Resources.diamond, (8 + (3 * strength) > 20) ? 20 : (8 + (3 * strength)), tools, strength, new Point(GameScreen.ball.x, GameScreen.ball.y));
                        GameScreen.projectiles.Add(p);
                    }
                    break;
                case 7: //Quartz
                    if (activeTime % (37 - (3 * strength)) == 0)
                    {
                        string[] tools = new string[]
                     {
                            "Pick"
                    };
                        Projectile p = new Projectile(0, -4 - (3 * strength), Resources.quartz, 10 + (3 * strength), tools, strength);
                        GameScreen.projectiles.Add(p);
                    }
                    break;
                case 8: //Netherite
                    if (activeTime % 28 == 0)
                    {
                        string[] tools = new string[]
                        {
                            "Pick"
                        };
                        Projectile pOne = new Projectile(9, 0, Resources.netherite_ingot, (8 + (3 * strength) > 20) ? 20 : (8 + (3 * strength)), tools, strength, new Point(GameScreen.ball.x, GameScreen.ball.y));
                        Projectile pTwo = new Projectile(0, 9, Resources.netherite_ingot, (8 + (3 * strength) > 20) ? 20 : (8 + (3 * strength)), tools, strength, new Point(GameScreen.ball.x, GameScreen.ball.y));
                        Projectile pThree = new Projectile(-9, 0, Resources.netherite_ingot, (8 + (3 * strength) > 20) ? 20 : (8 + (3 * strength)), tools, strength, new Point(GameScreen.ball.x, GameScreen.ball.y));
                        Projectile pFour = new Projectile(0, -9, Resources.netherite_ingot, (8 + (3 * strength) > 20) ? 20 : (8 + (3 * strength)), tools, strength, new Point(GameScreen.ball.x, GameScreen.ball.y));
                        GameScreen.projectiles.Add(pOne);
                        GameScreen.projectiles.Add(pTwo);
                        GameScreen.projectiles.Add(pThree);
                        GameScreen.projectiles.Add(pFour);
                    }
                    break;
                case 9: //Ender Eye
                    break;
                case 10: //Brick
                    if (activeTime % (37 - (3 * strength)) == 0)
                    {
                        string[] tools = new string[]
                     {
                            "Shears", "Axe", "Shovel", "Pick", "Sword"
                    };
                        Projectile p = new Projectile(0, -4 - (3 * strength), Resources.brick, 10 + (3 * strength), tools, strength);
                        GameScreen.projectiles.Add(p);
                    }
                    break;
                case 11: //Coal
                    break;
                case 12: //Water
                    if (activeTime % 8 == 0)
                    {
                        string[] tools = new string[]
                        {
                            "Shears", "Axe", "Shovel", "Pick", "Sword"
                        };
                        Projectile p = new Projectile((int)(10.1 * Math.Sin(activeTime)), (int)Math.Abs(10.1 * (Math.Cos(activeTime))), Resources.bubble, (8 + (3 * strength) > 20) ? 20 : (8 + (3 * strength)), tools, strength, new Point((int)GameScreen.sunPoint.X, (int)GameScreen.sunPoint.Y));
                        GameScreen.projectiles.Add(p);
                        GameScreen.sunColorTwo = Color.FromArgb(43, 105, 105, 255);
                        GameScreen.sunColorOne = Color.FromArgb(43, 105, 105, 255);
                    }
                    break;
                case 13: //Lava
                    if (activeTime % 8 == 0)
                    {
                        string[] tools = new string[]
                        {
                            "Shears", "Axe", "Shovel", "Pick", "Sword"
                        };
                        Projectile p = new Projectile((int)(10.1 * Math.Sin(activeTime)),(int)Math.Abs(10.1 * (Math.Cos(activeTime))), Resources.magma_cream, (8 + (3 * strength) > 20) ? 20 : (8 + (3 * strength)), tools, strength, new Point((int)GameScreen.sunPoint.X, (int)GameScreen.sunPoint.Y));
                        GameScreen.projectiles.Add(p);
                        GameScreen.sunColorTwo = Color.FromArgb(43, 255, 105, 5);
                        GameScreen.sunColorOne = Color.FromArgb(43, 255, 105, 5);
                    }
                    break;

            }
        }
        public void OnDeath()
        {
            switch (id)
            {
                case 1: //Apple
                    break;
                case 2: //Seeds
                    break;
                case 3: //Stone Pick
                    GameScreen.ball.tools.Remove("Pick");
                    GameScreen.ball.image = Resources.snowball;
                    break;
                case 4: //Iron Ingot
                    GameScreen.ball.tools.Remove("Pick");
                    GameScreen.ball.image = Resources.snowball;
                    break;
                case 5: //Gold Ingot
                    GameScreen.ball.tools.Remove("Pick");
                    GameScreen.ball.image = Resources.snowball;
                    break;
                case 6: //Diamond
                    GameScreen.ball.tools.Remove("Pick");
                    GameScreen.ball.image = Resources.snowball;
                    break;
                case 7: //Quartz
                    break;
                case 8: //Netherite
                    GameScreen.ball.tools.Remove("Pick");
                    GameScreen.ball.image = Resources.snowball;
                    break;
                case 9: //Ender Eye
                    break;
                case 10: //Brick
                    break;
                case 11: //Coal
                    break;
                case 12: //Water
                    GameScreen.sunColorOne = Color.FromArgb(33, 180, 120, 200); //SunOne
                    GameScreen.sunColorTwo = Color.FromArgb(23, 130, 160, 220); //SunTwo 
                    break;
                case 13: //Lava
                    GameScreen.sunColorOne = Color.FromArgb(33, 180, 120, 200); //SunOne
                    GameScreen.sunColorTwo = Color.FromArgb(23, 130, 160, 220); //SunTwo 
                    break;
            }
        }
    }
}
