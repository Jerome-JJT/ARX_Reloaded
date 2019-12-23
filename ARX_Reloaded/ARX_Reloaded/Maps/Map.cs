using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public abstract class Map
    {
        protected int width;
        protected int height;

        protected List<Case> cases;
        protected Stack<int> active;

        protected Random rand = new Random();

        public Map(Size mapSize, Random mapRandom)
        {
            width = mapSize.Width;
            height = mapSize.Height;

            rand = mapRandom;
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public List<Case> Cases
        {
            get { return cases; }
        }

        public abstract void GenerateMap(PictureBox elem, Label loading);

        public void GenerateZones(PictureBox elem, Label loading)
        {
            int zones = 5;

            List<List<List<int>>> points = new List<List<List<int>>>();
            List<int> usedCoords = new List<int>();

            double ratio = Math.Sqrt((Width * Height / (zones)) / Math.PI) * 1.5;

            for (int i = 0; i < zones; i++)
            {
                points.Add(new List<List<int>>());

                points[i].Add(new List<int>());//Present
                points[i].Add(new List<int>());//Futur

                int newCoord;
                do
                {
                    newCoord = rand.Next(0, Width * Height);
                }
                while (inZoneRadius(ratio, usedCoords, newCoord));

                usedCoords.Add(newCoord);
                points[i][0].Add(newCoord);
                cases[newCoord].Zone = i + 1;
            }

            while (restEmptyZone())
            {
                foreach (List<List<int>> zone in points)
                {
                    foreach (int point in zone[0])
                    {
                        if (point > Width - 1 && cases[point - Width].Zone == 0
                            && (cases[point - Width].State == 3 || cases[point - Width].State == 4))
                        {
                            cases[point - Width].Zone = cases[point].Zone;

                            zone[1].Add(point - Width);
                        }

                        if (point % Width < Width - 1 && cases[point + 1].Zone == 0
                            && (cases[point].State == 2 || cases[point].State == 4))
                        {
                            cases[point + 1].Zone = cases[point].Zone;

                            zone[1].Add(point + 1);
                        }

                        if (point < Height * Width - Width && cases[point + Width].Zone == 0
                            && (cases[point].State == 3 || cases[point].State == 4))
                        {
                            cases[point + Width].Zone = cases[point].Zone;

                            zone[1].Add(point + Width);
                        }

                        if (point % Width > 0 && cases[point - 1].Zone == 0
                            && (cases[point - 1].State == 2 || cases[point - 1].State == 4))
                        {
                            cases[point - 1].Zone = cases[point].Zone;

                            zone[1].Add(point - 1);
                        }
                    }

                    zone[0] = new List<int>(zone[1]);
                    zone[1].Clear();
                }

                if (elem != null)
                {
                    elem.Refresh();
                    System.Threading.Thread.Sleep(5);
                }
            }
        }

        private bool inZoneRadius(double ratio, List<int> placedPoints, int newPoint)
        {
            foreach (int point in placedPoints)
            {
                if(Math.Sqrt(Math.Pow(Math.Abs((point%Width) - (newPoint%Width)), 2) + Math.Pow(Math.Abs(Math.Floor((double)point/Width) - Math.Floor((double)newPoint/Width)), 2)) < ratio)
                {
                    return true;
                }
            }
            return false;
        }

        private bool restEmptyZone()
        {
            foreach (Case eachCase in cases)
            {
                if (eachCase.Zone == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
