﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Wyprawa
{
    class Bow : Weapon
    {
        public Bow(Game game, Point location) : base(game, location) { }

        public override string Name { get { return "Łuk"; } }

        public override void Attack(Direction direction, Random random)
        {
        }
    }
}
