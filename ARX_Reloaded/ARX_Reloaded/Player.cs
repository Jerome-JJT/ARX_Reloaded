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

        public Player()
        {
            x = 2;
            y = 2;
            rotation = 270;
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
