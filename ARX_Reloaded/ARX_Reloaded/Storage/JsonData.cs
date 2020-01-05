using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARX_Reloaded
{
    public class JsonData
    {
        private int coinAmount = 0;
        private int stageLevel = 0;

        private int zoomLevel = 1;
        private int drawType = 0;

        private Point windowLocation = new Point(200, 200);
        private Size windowSize = new Size(1250, 700);

        private int randomSeed = -1;
        private Point player = new Point(0, 0);

        public int CoinAmount
        {
            get { return coinAmount; }
            set { coinAmount = value; }
        }

        public int StageLevel
        {
            get { return stageLevel; }
            set { stageLevel = value; }
        }

        public int ZoomLevel
        {
            get { return zoomLevel; }
            set { zoomLevel = value; }
        }

        public int DrawType
        {
            get { return drawType; }
            set { drawType = value; }
        }


        public Point WindowLocation
        {
            get { return windowLocation; }
            set { windowLocation = value; }
        }

        public Size WindowSize
        {
            get { return windowSize; }
            set { windowSize = value; }
        }


        public int RandomSeed
        {
            get { return randomSeed; }
            set { randomSeed = value; }
        }

        public Point Player
        {
            get { return player; }
            set { player = value; }
        }
    }
}
