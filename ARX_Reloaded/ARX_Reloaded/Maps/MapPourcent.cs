using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public class MapPourcent : MapNormal
    {
        private int ratio;

        public MapPourcent(int ratio, Size mapSize, Random mapRandom) : base(mapSize, mapRandom)
        {
            this.ratio = ratio;
        }

        public override void GenerateMap(PictureBox elem, Label loading)
        {
            base.GenerateMap(elem, loading);

            foreach(Case eachCase in cases)
            {
                if(rand.Next(100) < ratio)
                {
                    if(Righter(eachCase.Coord) != null && Lower(eachCase.Coord) != null)
                    {
                        eachCase.State = ARX.State.Cross;
                    }
                }
            }
        }
    }
}
