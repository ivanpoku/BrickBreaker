/*  Created by: 
 *  Project: Brick Breaker
 *  Date: 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Xml;
using BrickBreaker.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Resources;
using System.IO;
using BrickBreaker.Screens;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Drawing.Drawing2D;
using static System.Net.Mime.MediaTypeNames;


namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        bool timerKills = false; //Set to true if you want the game to have a timer that can kill you
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown;

        // Game values
        public const int MAX_LIVES = 4;
        public static int lives;
        int blocksNum;

        int x, y, width, height, id;
        public bool isPaused = false;
        public static int right, down;
        int timerIncreases = 0;

        // Paddle and Ball objects
        public static Paddle paddle;
        public static Ball ball;

        public static PointF sunPoint;

        // list of all blocks for current level
        List<Block> blocks = new List<Block>();


        System.Drawing.Image player = Properties.Resources.Friend2;
        System.Drawing.Image hearts = Properties.Resources.heart_flash;
        System.Drawing.Image fullXpBar = Properties.Resources.xpBarFull;

        Rectangle xpBarRegion;

        Rectangle xpFullRect;


        ResourceManager rm = Resources.ResourceManager;

        public static List<Powerup> activePowerups = new List<Powerup>();
        List<Powerup> fallingPowerups = new List<Powerup>();
        public static List<Projectile> projectiles = new List<Projectile>();

        SolidBrush sunlightBrush = new SolidBrush(Color.FromArgb(43, 255, 255, 120));
        SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(75, 6, 5, 25));

        public static Color sunColorTwo, sunColorOne, shadowColorTwo, shadowColorOne;

        List<PointF[]> shadowPolygons = new List<PointF[]>();
        List<PointF[]> exclusionShadowPolygons = new List<PointF[]>();
        const double LIGHT_STRENGTH = 100;
        double currentLightStrength;


        //Displaying Powerups
        Font powerupFont = new Font(DefaultFont.Name, 10);
        int powerUpImageSize = 40;
        int powerUpOffset = 10;

        PointF timeDisplayPoint;
        int timeLimit;
        int currentTime;
        const int MAX_FONT_SIZE = 40;
        const int MIN_FONT_SIZE = 15;
        double fontIncrease;
        double timerToSecondsConversion;

        const int TIMER_POWER = 85;

        #endregion
        public GameScreen(bool immidiateStart)
        {
            InitializeComponent();
            this.Size = new Size(975, 667);
            SetLevelColors(Form1.currentLevel);
            OnStart(immidiateStart);
        }

        #region Set Colors On Start
        void SetLevelColors(int currentLevel)
        {
            currentLevel--;
            Color[][] colors = new Color[][]
            {
                //Lv1
                new Color[]
                {
                Color.FromArgb(33, 120, 140, 200), //SunOne 
                Color.FromArgb(43, 255, 255, 120), //SunTwo
                Color.FromArgb(55, 1, 5, 25), //ShadowOne
                Color.FromArgb(75, 6, 5, 25), //ShadowTwo
                },
                //Lv2
                new Color[]
                {
                Color.FromArgb(43, 255, 255, 120), //SunOne
                Color.FromArgb(33, 180, 120, 200), //SunTwo 
                Color.FromArgb(75, 6, 5, 25), //ShadowOne
                Color.FromArgb(85, 1, 5, 15), //ShadowTwo
                },
                //Lv3
                new Color[]
                {
                Color.FromArgb(33, 180, 120, 200), //SunOne
                Color.FromArgb(23, 130, 160, 220), //SunTwo 
                Color.FromArgb(85, 1, 5, 15), //ShadowOne
                Color.FromArgb(95, 2, 1, 7), //ShadowTwo
                },
                //Lv4
                new Color[]
                {
                Color.FromArgb(23, 130, 160, 220), //SunOne
                Color.FromArgb(43, 255, 255, 120), //SunTwo
                Color.FromArgb(95, 2, 1, 7), //ShadowOne
                Color.FromArgb(75, 6, 5, 25), //ShadowTwo
                },
                //Lv5
                new Color[]
                {
                Color.FromArgb(33, 120, 140, 200), //SunOne 
                Color.FromArgb(43, 255, 255, 120), //SunTwo
                Color.FromArgb(55, 1, 5, 25), //ShadowOne
                Color.FromArgb(75, 6, 5, 25), //ShadowTwo
                },
                //Lv6
                new Color[]
                {
                Color.FromArgb(43, 255, 255, 120), //SunOne
                Color.FromArgb(33, 180, 120, 200), //SunTwo 
                Color.FromArgb(75, 6, 5, 25), //ShadowOne
                Color.FromArgb(85, 1, 5, 15), //ShadowTwo
                },
                //Lv7
                new Color[]
                {
                Color.FromArgb(33, 180, 120, 200), //SunOne
                Color.FromArgb(23, 220, 160, 120), //SunTwo 
                Color.FromArgb(85, 1, 5, 15), //ShadowOne
                Color.FromArgb(95, 12, 1, 7), //ShadowTwo
                },
                //Lv8
                new Color[]
                {
                Color.FromArgb(23, 220, 160, 120), //SunOne
                Color.FromArgb(53, 255, 100, 120), //SunTwo
                Color.FromArgb(95, 12, 1, 7), //ShadowOne
                Color.FromArgb(75, 6, 5, 25), //ShadowTwo
                },
                //Lv9
                new Color[]
                {
                Color.FromArgb(53, 255, 100, 120), //SunOne
                Color.FromArgb(43, 255, 150, 120), //SunTwo
                Color.FromArgb(75, 6, 5, 25), //ShadowOne
                Color.FromArgb(85, 65, 5, 25), //ShadowTwo
                },
                //Lv10
                new Color[]
                {
                Color.FromArgb(43, 255, 150, 120), //SunOne
                Color.FromArgb(60, 255, 50, 220), //SunTwo
                Color.FromArgb(85, 65, 5, 25), //ShadowOne
                Color.FromArgb(85, 65, 5, 50), //ShadowTwo
                },
                //Lv11
                new Color[]
                {
                Color.FromArgb(60, 255, 50, 220), //SunOne
                Color.FromArgb(50, 105, 50, 250), //SunTwo
                Color.FromArgb(85, 65, 5, 50), //ShadowOne
                Color.FromArgb(65, 5, 25, 70), //ShadowTwo
                },
                //Lv12
                new Color[]
                {
                Color.FromArgb(50, 105, 50, 250), //SunOne
                Color.FromArgb(150, 255, 255, 255), //SunTwo
                Color.FromArgb(65, 5, 25, 70), //ShadowOne
                Color.FromArgb(80, 0, 0, 0), //ShadowTwo
                },
            };

            sunColorOne = colors[currentLevel][0];
            sunColorTwo = colors[currentLevel][1];
            shadowColorOne = colors[currentLevel][2];
            shadowColorTwo = colors[currentLevel][3];
        }
        #endregion

        #region On Start

        public void OnStart(bool immidiateStart)
        {
            projectiles.Clear();
            activePowerups.Clear();
            fallingPowerups.Clear();

            lives = MAX_LIVES;
            timerToSecondsConversion = (double)1000 / (double)(gameTimer.Interval);

            if (Form1.IsWithinRange(Form1.currentLevel, 1, 7) || (Form1.IsWithinRange(Form1.currentLevel, 10, 11)))
            {
                BackgroundImage = Properties.Resources.minecraftBkgd;
            }
            if (Form1.IsWithinRange(Form1.currentLevel, 8, 9))
            {
                BackgroundImage = Properties.Resources.netherackBkgd1;
            }
            if (Form1.IsWithinRange(Form1.currentLevel, 12, 12))
            {
                BackColor = Color.Black;
                BackgroundImage = null;
            }

            //Start immidiately, or give the player a StartLevelScreen first.
            if (immidiateStart) { gameTimer.Enabled = true; }
            else
            {
                StartLevelScreen sls = new StartLevelScreen(this);
                sls.Location = new Point((this.Width - sls.Width) / 2, 10);
                this.Controls.Add(sls);
            }

            right = this.Right;
            down = this.Bottom;
            timeDisplayPoint = new PointF(right / 2, this.Bottom - 30);
            xpFullRect = xpBarRegion = new Rectangle(0, this.Bottom - 35, this.Right, 35);

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 30;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = 9;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = this.Height - paddle.height - 90;

            // Creates a new ball
            int xSpeed = 5;
            int ySpeed = 5;
            int ballSize = 20;

            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);
            resetBall();
            LevelReader(Form1.currentLevel);
        }
        #endregion

        #region Level Reader
        public void LevelReader(int levelNumber)
        {
            int totalLevelHp = 0;
            Random random = new Random();

            string path = "Resources/Level" + levelNumber + ".xml";
            XmlReader reader = XmlReader.Create(path);


            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    x = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("y");
                    y = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("width");
                    width = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("height");
                    height = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("id");
                    id = Convert.ToInt32(reader.ReadString());


                    //Create a new block
                    Block newBlock = new Block(x, y, width, height, id, random.Next(0, 101));

                    //Add the blocks health to the health total of the level
                    totalLevelHp += newBlock.hp;

                    //Add the block
                    blocks.Add(newBlock);
                }
            }


            blocksNum = blocks.Count;
            timeLimit = currentTime = totalLevelHp * TIMER_POWER;
            fontIncrease = (double)(MAX_FONT_SIZE - MIN_FONT_SIZE) / timeLimit;
        }

        #endregion

        #region inputKeys

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.A:
                    leftArrowDown = true;
                    break;
                case Keys.D:
                    rightArrowDown = true;
                    break;
                case Keys.Escape:
                    //If the game is not paused, pause the game
                    if (!isPaused)
                    {
                        isPaused = true;
                        // Goes to pause screen
                        gameTimer.Enabled = false;
                        //Draw overlay
                        Refresh();
                        PauseScreen ps = new PauseScreen(this, calculateScore());
                        Form form = this.FindForm();
                        ps.Location = new Point((this.Width - ps.Width) / 2, (this.Height - ps.Height) / 2);
                        ps.Focus();
                        this.Controls.Add(ps);
                    }
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.A:
                    leftArrowDown = false;
                    break;
                case Keys.D:
                    //Application.Exit();//blow up
                    rightArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        #endregion

        void resetBall()
        {
            paddle.x = (this.Width / 2) - (paddle.width / 2);
            paddle.y = (this.Height - paddle.height) - 60;

            ball.x = ((paddle.x - (ball.radius * 2)) + (paddle.width / 2));
            ball.y = paddle.y - (ball.radius * 2) - paddle.height;
            ball.yVel = -1 * Math.Abs(ball.yVel);

            Refresh();
            Graphics g = this.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 0, 0, 0)), new Rectangle(0, 0, right, down));

            Task.Delay(800).Wait();

        }

        void BlockCollision(Block b, List<String> tools, int strength, int initialHitStrength)
        {
            //WinCondition(); //used for testing

            b.runCollision(tools, strength, initialHitStrength); //should be switched to entirely, no lines below
            if (b.hp < 1)
            {
                foreach (Powerup p in b.powerupList)
                {
                    fallingPowerups.Add(p);
                }
                blocks.Remove(b);

                double xpBarPercent = (Double)blocks.Count / blocksNum;
                if (xpBarPercent != 1)
                {
                    xpBarRegion.Width = (int)(right * xpBarPercent);
                    xpBarRegion.X = (right - xpBarRegion.Width);
                };

                if (blocks.Count == 0)
                {
                    gameTimer.Enabled = false;
                    WinCondition();
                }
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            timerIncreases++;
            currentTime--;
            if (currentTime < 0 && timerKills) { lives = 0; } //This was another thing we used for when you could also die from the timer running out, we just decided it doesnt fit the game.

            sunPoint = new PointF(right - (float)(((double)right / (double)timeLimit) * (double)currentTime), 0);

            currentLightStrength = LIGHT_STRENGTH + Math.Sin((double)currentTime / (double)100) * (double)30;
            shadowPolygons.Clear();
            exclusionShadowPolygons.Clear();

            Form1.globalTimer++;
            paddle.Move(Convert.ToUInt16(rightArrowDown) - Convert.ToUInt16(leftArrowDown), this);

            ball.Move();
            ball.PaddleCollision(paddle);

            for (int p = 0; p < projectiles.Count; p++)
            {
                projectiles[p].Move();
            }


            #region Blocks 
            //Check if ball has collided with any blocks
            for (int i = 0; i < blocks.Count; i++)
            {
                Block b = blocks[i];

                //Get the blocks shadows at the current point in the day
                shadowPolygons.Add(b.shadowPoints(sunPoint, currentLightStrength));
                exclusionShadowPolygons.Add(b.shadowPoints(sunPoint, 1000));

                for (int p = 0; p < projectiles.Count; p++)
                {
                    if (projectiles[p].rectangle.IntersectsWith(new Rectangle(b.x, b.y, b.width, b.height)))
                    {
                        BlockCollision(b, projectiles[p].tools, projectiles[p].strength, 0);
                        if (p < projectiles.Count) { projectiles[p].OnCollision(); }
                    }
                }

                if (ball.BlockCollision(b))
                {
                    BlockCollision(b, ball.tools, ball.strength, 1);
                }
            }
            #endregion
            #region Falling Powerups
            for (int p = 0; p < fallingPowerups.Count; p++)
            {
                //Choose to despawn or activate a powerup
                bool[] removeAndActivate = fallingPowerups[p].Move(this.Bottom, new Rectangle(paddle.x, paddle.y, paddle.width, paddle.height));
                if (removeAndActivate[1])
                {
                    //If the powerup hits the player, check to see if the powerup already exists and boost its strength, if not add it to the active list
                    bool addAsNewPowerup = true;
                    int ghostID = fallingPowerups[p].id;
                    foreach (Powerup q in activePowerups)
                    {
                        //If the powerups list already has this type of powerup, increase its active time and strength instaed of adding a new one.
                        if (q.id == ghostID)
                        {
                            addAsNewPowerup = false;
                            q.strength++;
                            q.activeTime += fallingPowerups[p].activeTime;
                            q.lifeSpan = q.activeTime;
                        }
                    }
                    if (addAsNewPowerup)
                    {
                        activePowerups.Add(fallingPowerups[p]);

                    }
                    fallingPowerups[p].OnPickup();
                }
                if (removeAndActivate[0])
                {
                    //If the powerup hits the player, or the screen end, remove it from the list
                    fallingPowerups.RemoveAt(p);
                };
            }
            #endregion
            #region Active Powerups
            for (int p = 0; p < activePowerups.Count; p++)
            {
                activePowerups[p].WhileActive();
                if (activePowerups[p].activeTime < 0)
                {
                    activePowerups[p].OnDeath();
                    activePowerups.RemoveAt(p);
                }
            }
            #endregion

            for (int p = 0; p < projectiles.Count; p++)
            {
                if (projectiles[p].shouldRemove) { projectiles.RemoveAt(p); }
            }
            #region Change Light/Shadow Colors
            //Change Light Color depending on Current Time
            double dayPercentage = ((double)(currentTime) / (double)timeLimit);

            double aValue = (((double)sunColorOne.A * (dayPercentage)) + ((double)sunColorTwo.A * (1 - dayPercentage)));
            double rValue = (((double)sunColorOne.R * (dayPercentage)) + ((double)sunColorTwo.R * (1 - dayPercentage)));
            double gValue = (((double)sunColorOne.G * (dayPercentage)) + ((double)sunColorTwo.G * (1 - dayPercentage)));
            double bValue = (((double)sunColorOne.B * (dayPercentage)) + ((double)sunColorTwo.B * (1 - dayPercentage)));
            sunlightBrush.Color = Color.FromArgb((int)aValue, (int)rValue, (int)gValue, (int)bValue);

            aValue = (((double)shadowColorOne.A * (dayPercentage)) + ((double)shadowColorTwo.A * (1 - dayPercentage)));
            rValue = (((double)shadowColorOne.R * (dayPercentage)) + ((double)shadowColorTwo.R * (1 - dayPercentage)));
            gValue = (((double)shadowColorOne.G * (dayPercentage)) + ((double)shadowColorTwo.G * (1 - dayPercentage)));
            bValue = (((double)shadowColorOne.B * (dayPercentage)) + ((double)shadowColorTwo.B * (1 - dayPercentage)));

            aValue = (aValue < 0) ? 0 : aValue;
            rValue = (rValue < 0) ? 0 : rValue;
            gValue = (gValue < 0) ? 0 : gValue;
            bValue = (bValue < 0) ? 0 : bValue;

            shadowBrush.Color = Color.FromArgb((int)aValue, (int)rValue, (int)gValue, (int)bValue);
            #endregion

            if (ball.WallCollision(this))
            { //run wall collision and respond if the ball has touched the bottom

                lives--;

                // Moves the ball back to origin
                resetBall();
            }

            if (lives == 0)
            {
                gameTimer.Enabled = false;
                OnEnd();
            }
            Refresh();
        }


        public void WinCondition()
        {
            if (Form1.currentLevel == 12)
            {
                Form1.currentLevel = 1;
                gameTimer.Enabled = false;

                Form form = this.FindForm();
                WinScreen ws = new WinScreen();

                ws.Location = new Point((form.Width - ws.Width) / 2, (form.Height - ws.Height) / 2);

                form.Controls.Add(ws);
                form.Controls.Remove(this);
            }
            else
            {
                Form1.currentLevel++;
                gameTimer.Enabled = false;

                Form form = this.FindForm();
                GameScreen gs = new GameScreen(false);

                gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);

                form.Controls.Add(gs);
                form.Controls.Remove(this);
            }
        }

        double calculateScore()
        {
            int innitialScore = (int)(((double)(blocksNum - blocks.Count)) / (double)blocksNum * 10000);
            double scoreAsDouble = (double)innitialScore / 100;
            return scoreAsDouble;
        }
        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();
            EndScreen es = new EndScreen(calculateScore());

            es.Location = new Point((form.Width - es.Width) / 2, (form.Height - es.Height) / 2);

            form.Controls.Add(es);
            form.Controls.Remove(this);

        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {

            #region Shadows
            //Draws shadows so everything else is on top
            GraphicsPath gp = new GraphicsPath();
            Region shadowRegion = new Region(gp);
            Region exclusionShadows = new Region(gp);
            gp.AddRectangle(new RectangleF(0, 0, right, this.Bottom));
            Region sunlightRegion = new Region(gp);
            foreach (PointF[] p in shadowPolygons)
            {
                gp.Reset();
                gp.AddPolygon(p);
                shadowRegion.Union(gp);
                //e.Graphics.DrawPolygon(new Pen(new SolidBrush(Color.Beige),2),p); //Turn on to see polygons 
            }
            foreach (PointF[] p in exclusionShadowPolygons)
            {
                gp.Reset();
                gp.AddPolygon(p);
                exclusionShadows.Union(gp);
                //e.Graphics.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(50,0,0,255))), p); //Turn on to see polygons
            }
            sunlightRegion.Exclude(exclusionShadows);

            e.Graphics.FillRegion(shadowBrush, shadowRegion);
            #endregion

            // Draws paddle
            Rectangle paddleRect = new Rectangle(paddle.x, paddle.y, paddle.width, paddle.height);

            e.Graphics.DrawImage(player, paddleRect);


            #region Blocks
            // Draws blocks
            foreach (Block b in blocks)
            {
                e.Graphics.DrawImage(b.image, b.x, b.y, b.width + 2, b.height + 2);
                if (b.alphaValue != 0)
                {
                    int newAlpha = (b.alphaValue * 2 > 220) ? 220 : b.alphaValue * 2;
                    Color color = shadowBrush.Color;
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(newAlpha, color.R, color.G, color.B)), b.overlay);
                }

            }
            #endregion

            #region Xp Bar
            //Draw Xp Bar
            Color barColor = Color.FromArgb(18, 0, 0, 0);
            SolidBrush barBrush = new SolidBrush(barColor);

            Rectangle fadeRect = xpFullRect;
            for (int i = 0; i < 10; i++)
            {
                fadeRect.Y -= i;
                fadeRect.Height += i;
                e.Graphics.FillRectangle(barBrush, fadeRect);
            }
            e.Graphics.DrawImage(fullXpBar, xpFullRect);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(180, 0, 0, 0)), xpBarRegion);
            // e.Graphics.DrawImage(xpBar, xpRect);
            #endregion

            //Draw Falling Powerups
            foreach (Powerup p in fallingPowerups)
            {
                e.Graphics.DrawImage(p.image, p.rectangle);
            }

            //Draw Projectiles 
            foreach (Projectile p in projectiles)
            {
                e.Graphics.DrawImage(p.image, p.rectangle);
            }

            // Draws ball
            Rectangle ballRect = new Rectangle(ball.x, ball.y, 30, 30);
            e.Graphics.DrawImage(ball.image, ballRect);

            //Draw sunlight over everything to get nice sunbeams coloring your paddle effects!
            e.Graphics.FillRegion(sunlightBrush, sunlightRegion);

            #region UI elements

            #region Time Limit
            //Draw Time Limit
            int percentage = (timeLimit - currentTime);
            int fontSize = (int)(percentage * fontIncrease) + MIN_FONT_SIZE;
            int colorSize = (int)(percentage * ((double)255 / (double)timeLimit));
            colorSize = (colorSize > 255) ? 255 : colorSize;
            Color fontColor = Color.FromArgb(255, colorSize, 255, colorSize);
            //We found this a bit confusing on the final days because its pretty much random whether you go faster or slower, so we changed this to just be a timer up.
            string timeLimitString = "" + timerIncreases / timerToSecondsConversion;
            if (timerKills)
            {
                timeLimitString = "" + (double)currentTime / timerToSecondsConversion; //This would display your time compared to the max time in the level,
            }
            fontSize = (fontSize > MAX_FONT_SIZE) ? MAX_FONT_SIZE : fontSize;
            e.Graphics.DrawString(timeLimitString, new Font(Form1.pfc.Families[0], fontSize), new SolidBrush(fontColor), new PointF(timeDisplayPoint.X - fontSize, timeDisplayPoint.Y - fontSize));
            #endregion

            double sinChange = (int)(Math.Sin((double)currentTime / (double)40) * (double)6);

            //Draw Active Powerups
            int powerupYCoord = 80;
            foreach (Powerup p in activePowerups)
            {
                Double age = p.Age();
                int newSize = (int)(powerUpImageSize * age) + 3;
                e.Graphics.DrawImage(p.image, new Rectangle(powerUpOffset + ((powerUpImageSize - newSize) / 2), (int)((double)(powerupYCoord + ((powerUpImageSize - newSize) / 2)) + sinChange), newSize, newSize));
                // e.Graphics.DrawString("x" + p.strength, powerupFont, new SolidBrush(Color.FromArgb(180, 255, 255, 255)), new Point(powerUpImageSize + (2 * powerUpOffset), powerupYCoord + (powerUpImageSize / 2)));
                powerupYCoord += 45;
            }

            //Draw Hearts
            for (int i = 0; i < lives; i++)
            {
                e.Graphics.DrawImage(hearts, new Rectangle(10 + (i * 50), (int)((double)20 + sinChange), 35, 35));
            }

            #endregion

            if (!gameTimer.Enabled)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(180, 0, 0, 0)), new Rectangle(new Point(0, 0), this.Size));
            }
        }
    }
}