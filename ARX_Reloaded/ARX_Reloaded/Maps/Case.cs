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
        private int state;
        private bool visited;

        private int zone;
        private Color zoneColor;

        private Point pos;

        public Case(int posX, int posY)
        {
            this.state = 0;
            this.visited = true;

            this.zone = 0;
            this.zoneColor = Color.White;

            this.Pos = new Point(posX, posY);
        }

        public int State
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

        public Point Pos
        {
            get { return pos; }
            set { pos = value; }
        }
    }
}
