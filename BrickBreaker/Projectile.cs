using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Projectile
    {
        public bool shouldRemove = false;
        public Rectangle rectangle;
        public Image image;
        Point location;
        int radius;
        int xSpeed;
        int ySpeed;
        public int strength = 0;
        public List<string> tools = new List<string>();
        public Projectile(int _xSpeed, int _ySpeed, Image _image, int _radius, string[] _tools, int _strength)
        {
            strength = _strength;
            location = new Point(GameScreen.paddle.x + (GameScreen.paddle.width / 2), GameScreen.paddle.y + (GameScreen.paddle.height / 2));
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            image = _image;
            radius = _radius;
            tools.AddRange(_tools);
        }
        public Projectile(int _xSpeed, int _ySpeed, Image _image, int _radius, string[] _tools, int _strength, Point _location)
        {
            strength = _strength;
            location = _location;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            image = _image;
            radius = _radius;
            tools.AddRange(_tools);
        }

        public void Move()
        {
            location.X += xSpeed;
            location.Y += ySpeed;

            rectangle = new Rectangle(location.X - radius, location.Y - radius, radius * 2, radius * 2);

            if (location.X > GameScreen.right || location.X < 0 || location.Y > GameScreen.down || location.Y < 0)
            {
                shouldRemove = true;
            }
        }

        public void OnCollision()
        {
            shouldRemove = true;
        }
    }
}