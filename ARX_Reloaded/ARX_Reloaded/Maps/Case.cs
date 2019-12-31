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
        private bool accessible;

        private int zone;
        private Color zoneColor;

        private int coord;
        private int originDistance;
        private int scoreDistance;

        public Case(int coord)
        {
            this.state = 0;
            this.visited = false;
            this.accessible = false;

            this.zone = 0;
            this.zoneColor = Color.White;

            this.coord = coord;
            this.originDistance = -1;
            this.scoreDistance = -1;
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

        public bool Accessible
        {
            get { return accessible; }
            set { accessible = value; }
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

        public Color AntiColor
        {
            get { return Color.FromArgb(255 - zoneColor.R, 255 - zoneColor.G, 255 - zoneColor.B); }
        }

        public int Coord
        {
            get { return coord; }
            set { coord = value; }
        }

        public int OriginDistance
        {
            get { return originDistance; }
            set { originDistance = value; }
        }

        public int ScoreDistance
        {
            get { return scoreDistance; }
            set { scoreDistance = value; }
        }

        //Change state to another one (except void form)
        public ARX.State NextPathState
        {
            get { return (ARX.State)((int)state % 4 + 1); }
        }
    }
}
