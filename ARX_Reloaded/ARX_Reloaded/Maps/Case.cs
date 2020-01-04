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
        private bool visible;
        private bool accessible;

        private int zone;
        private Color zoneColor;

        private int coord;
        private int originDistance;
        private int scoreDistance;

        private CaseEvent caseEvent;

        public Case(int coord)
        {
            this.state = 0;
            this.visible = false;
            this.accessible = false;

            this.zone = -1;
            this.zoneColor = Color.White;

            this.coord = coord;
            this.originDistance = -1;
            this.scoreDistance = -1;

            this.caseEvent = new NoEvent();
        }

        public ARX.State State
        {
            get { return state; }
            set { state = value; }
        }

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
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

        public Color ContrastColor
        {
            get
            {
                //int nThreshold = 105;
                int nThreshold = 145;
                int bgDelta = Convert.ToInt32((zoneColor.R * 0.299) + (zoneColor.G * 0.587) + (zoneColor.B * 0.114));

                Color foreColor = (255 - bgDelta < nThreshold) ? Color.Black : Color.White;
                return foreColor;
            }
        }

        public int Coord
        {
            get { return coord; }
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

        public CaseEvent CaseEvent
        {
            get { return caseEvent; }
            set { caseEvent = value; }
        }
    }
}
