using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Wyprawa
{
    class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location) : base(game, location, 6)
        { }

        public override void Move(Random random)
        {

        }
    }
}
