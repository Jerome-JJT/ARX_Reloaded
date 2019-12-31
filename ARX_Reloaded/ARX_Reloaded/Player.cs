using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARX_Reloaded
{
    public class Player
    {
        private Point pos;
        private int rotation;

        public Player(int x, int y, int r)
        {
            this.pos = new Point(x, y);
            this.rotation = r;
        }

        public int X {
            get { return pos.X; }
            set { pos.X = value; }
        }

        public int Y {
            get { return pos.Y; }
            set { pos.Y = value; }
        }

        public int Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Point Position
        {
            get { return pos; }
            set { pos = value; }
        }
    }
}
