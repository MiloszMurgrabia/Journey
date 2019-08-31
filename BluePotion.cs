using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Wyprawa
{
    class BluePotion : Weapon, IPotion
    {

        public BluePotion(Game game, Point location) : base(game, location) { }

        public bool Used { get; }

        public override string Name { get { return "Niebieska mikstura"; } }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(5, random);
        }
    }
}
