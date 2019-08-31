using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Wyprawa
{
    class Bat : Enemy
    {
        public Bat(Game game, Point location) : base(game, location, 6)
        { }

        public override void Move(Random random)
        {
            int randomInt = random.Next(1, 3);
            if (randomInt == 1)
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            else
                location = Move((Direction)random.Next(1, 5), game.Boundaries);
            if (Nearby(game.PlayerLocation, 10))
                game.HitPlayer(2, random);
        }
    }
}
