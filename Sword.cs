using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Wyprawa
{
    class Sword : Weapon
    {
        public Sword(Game game, Point location) : base(game, location) { }

        public override string Name { get { return "Miecz"; } }

        public override void Attack(Direction direction, Random random)
        {
            if (DamageEnemy(direction, 10, 3, random))
                return;
            if (DamageEnemy((Direction)direction + 1, 10, 3, random))
                return;
            if (DamageEnemy((Direction)direction - 1, 10, 3, random))
                return;
        }
    }
}
