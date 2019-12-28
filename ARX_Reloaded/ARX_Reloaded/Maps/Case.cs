using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARX_Reloaded
{
    public class Case
    {
        private ARX.State state;
        private bool visited;

        private int zone;
        private Color zoneColor;

        private int coord;

        public Case(int coord)
        {
            this.state = 0;
            this.visited = true;

            this.zone = 0;
            this.zoneColor = Color.White;

            this.coord = coord;
        }

        public ARX.State State
        {
            get { return state; }
            set { state = value; }
        }

        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }

        public int Zone
        {
            get { return zone; }
            set { zone = value; }
        }

        public Color ZoneColor
        {
            get { return zoneColor; }
            set { zoneColor = value; }
        }

        public int Coord
        {
            get { return coord; }
            set { coord = value; }
        }

        //Change state to another one (except void form)
        public ARX.State NextPathState
        {
            get { return (ARX.State)((int)state % 4 + 1); }
        }
    }
}
