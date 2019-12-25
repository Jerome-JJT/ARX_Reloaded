using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARX_Reloaded
{
    public class Player
    {
        private int x;
        private int y;
        private int rotation;

        public Player(int x, int y, int r)
        {
            this.x = x;
            this.y = y;
            this.rotation = r;
        }

        public int X {
            get { return x; }
            set { x = value; }
        }

        public int Y {
            get { return y; }
            set { y = value; }
        }

        public int Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
    }
}
