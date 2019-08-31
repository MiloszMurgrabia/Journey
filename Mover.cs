using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Wyprawa
{
    abstract class Mover
    {
        private const int MoveInterval= 10;
        protected Point location;
        public Point Location { get { return location; } }
        protected Game game;

        public Mover(Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }
        public bool Nearby(Point locationToCheck, int distance)
        {
            Point location = this.location;
            return Nearby(location, locationToCheck, distance);
            //if (Math.Abs(location.X - locationToCheck.X) < distance &&
            //    Math.Abs(location.Y - locationToCheck.Y) < distance)
            //    return true;
            //else return false;
        }
        public bool Nearby(Point location, Point locationToCheck, int distance)
        {
            if (Math.Abs(location.X - locationToCheck.X) <= distance &&
                Math.Abs(location.Y - locationToCheck.Y) <= distance)
                return true;
            else return false;
        }
        public Point Move(Direction direction, Point target, Rectangle boundaries, int moveInterval)
        {
            Point newLocation = target;
            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - moveInterval >= boundaries.Top)
                        newLocation.Y -= moveInterval;
                    break;
                case Direction.Down:
                    if (newLocation.Y + moveInterval <= boundaries.Bottom)
                        newLocation.Y += moveInterval;
                    break;
                case Direction.Left:
                    if (newLocation.X - moveInterval >= boundaries.Left)
                        newLocation.X -= moveInterval;
                    break;
                case Direction.Right:
                    if (newLocation.X + moveInterval <= boundaries.Right)
                        newLocation.X += moveInterval;
                    break;
            }
            return newLocation;
        }

        public Point Move(Direction direction, Rectangle boundaries)
        {
            return Move(direction, location, boundaries, MoveInterval);
        }
    }
}
