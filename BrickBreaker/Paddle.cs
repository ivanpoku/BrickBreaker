using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker {
    public class Paddle {
        public int x, y, width, height, speed, lastCollisionTimeStamp;
        public Color colour;

        public Paddle ( int _x, int _y, int _width, int _height, int _speed, Color _colour ) {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            speed = _speed;
            colour = _colour;
        }   

        public void Move ( int movementInput, UserControl screen) {
            x += speed * movementInput;
            if (x < 0 - speed || x > screen.Width - width + speed) { x += (x < 0) ? speed : -speed; } //'shove' the paddle back onscreen depending on which direction its' out of bounds in
        }
    }
}
