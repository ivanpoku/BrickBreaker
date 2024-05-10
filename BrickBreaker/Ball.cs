using BrickBreaker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;


namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, radius, lastCollisionTimeStamp;
        public float xVel, yVel;
        public List<string> tools = new List<string>();
        public int strength = 0;
        private float startingXVel, startingYVel;
        public Image image;
        public static Random rand = new Random();

        public Ball(int _x, int _y, int _xVel, int _yVel, int _ballSize)
        {
            image = Resources.snowball;
            x = _x;
            y = _y;
            xVel = startingXVel = _xVel;
            yVel = startingYVel = _yVel;
            radius = _ballSize / 2;
        }

        public void Move()
        {
            x += (int)xVel;
            y += (int)yVel;
        }

        public bool BlockCollision(Block brick)
        {
            //currently unused code, trying to 'weigh' the velocity randomization so we never stray too far from the normal values
            int xVelDeviation = (int)((Math.Abs(xVel / startingXVel) - 1) * 100);
            int yVelDeviation = (int)((Math.Abs(yVel / startingYVel) - 1) * 100);

            Random rand = new Random();
            float speedMultX = (float)(rand.Next((-10 - xVelDeviation), (10 - xVelDeviation)) * 0.01 + 1);
            float speedMultY = (float)(rand.Next((-10 - yVelDeviation), (10 - yVelDeviation)) * 0.01 + 1);

            switch (Form1.CheckCollision(this, brick, brick.lastCollisionTimeStamp))
            {
                case 0:
                    return false;
                case 1: //top
                    yVel *= Form1.isNegative(yVel) ? 1 : -1;
                    xVel *= speedMultX;
                    this.y -= (int)yVel;

                    brick.lastCollisionTimeStamp = Form1.globalTimer;
                    break;
                case 2: //right side
                    xVel *= Form1.isNegative(xVel) ? -1 : 1;
                    yVel *= speedMultY;
                    this.x += (int)xVel;

                    brick.lastCollisionTimeStamp = Form1.globalTimer;
                    break;
                case 3: //bottom
                    yVel *= Form1.isNegative(yVel) ? -1 : 1;
                    xVel *= speedMultX;
                    this.y += (int)yVel;

                    brick.lastCollisionTimeStamp = Form1.globalTimer;
                    break;
                case 4: //left
                    xVel *= Form1.isNegative(xVel) ? 1 : -1;
                    yVel *= speedMultY;
                    this.x -= (int)xVel;

                    brick.lastCollisionTimeStamp = Form1.globalTimer;
                    break;
            }

            return true;
        }

        public bool PaddleCollision(Paddle paddle)
        {
            //currently unused code, trying to 'weigh' the velocity randomization so we never stray too far from the normal values
            int xVelDeviation = (int)((Math.Abs(xVel / startingXVel) - 1) * 100);
            int yVelDeviation = (int)((Math.Abs(yVel / startingYVel) - 1) * 100);

            Random rand = new Random();
            float speedMultX = (float)(rand.Next((-10 - xVelDeviation), (10 - xVelDeviation)) * 0.01 + 1);
            float speedMultY = (float)(rand.Next((-10 - yVelDeviation), (10 - yVelDeviation)) * 0.01 + 1);

            switch (Form1.CheckCollision(this, paddle, paddle.lastCollisionTimeStamp))
            {
                case 0:
                    return false;
                case 1: //top
                    yVel *= Form1.isNegative(yVel) ? 1 : -1;
                    xVel *= speedMultX;
                    this.y -= (int)yVel;

                    paddle.lastCollisionTimeStamp = Form1.globalTimer;
                    break;
                case 2: //right
                    xVel *= Form1.isNegative(xVel) ? -1 : 1;
                    yVel *= speedMultY;
                    this.x += (int)xVel;

                    paddle.lastCollisionTimeStamp = Form1.globalTimer;
                    break;
                case 3:
                    yVel *= Form1.isNegative(yVel) ? -1 : 1;
                    xVel *= speedMultX;
                    this.y += (int)yVel;

                    paddle.lastCollisionTimeStamp = Form1.globalTimer;
                    break;
                case 4:
                    xVel *= Form1.isNegative(xVel) ? 1 : -1;
                    yVel *= speedMultY;
                    this.x -= (int)xVel;

                    paddle.lastCollisionTimeStamp = Form1.globalTimer;
                    break;
            }

            return true;
        }

        public bool WallCollision(UserControl UC)
        {

            xVel *= (x <= 0 || x >= (UC.Width - radius)) ? -1 : 1;
            yVel *= (y <= radius) ? -1 : 1;

            return (y >= UC.Height - radius);
        }
    }
}