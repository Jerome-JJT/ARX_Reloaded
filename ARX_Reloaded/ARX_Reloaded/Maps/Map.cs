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

        protected Random rand = new Random();

        private List<string> colorValues = new List<string> {
            "00ffff", "0000ff", "a52a2a", "00008b", "008b8b", "c0c0c0",
            "006400", "bdb76b", "556b2f", "ff8c00", "8b0000", "00ff00",
            "e9967a", "9400d3", "ffd700", "008000", "4b0082",
            "ff00ff", "800000", "808000", "ffc0cb", "ff0000"
        };


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

        public void GenerateZones(PictureBox elem, Label loading, int zones)
        {
            List<List<List<int>>> points = new List<List<List<int>>>();
            List<int> usedCoords = new List<int>();

            double ratio = Math.Sqrt((width * height / (zones)) / Math.PI) * 1.5;

            Calculus.Shuffle(rand, colorValues);

            //Generate starting points for each zones
            for (int i = 0; i < zones; i++)
            {
                points.Add(new List<List<int>>());

                points[i].Add(new List<int>());//Present
                points[i].Add(new List<int>());//Futur

                int newCoord;
                do
                {
                    newCoord = rand.Next(0, width * height);
                }
                while (inZoneRadius(ratio, usedCoords, newCoord));

                usedCoords.Add(newCoord);
                points[i][0].Add(newCoord);

                cases[newCoord].Zone = i + 1;

                //Generate color orders
                cases[newCoord].ZoneColor =
                    Color.FromArgb(int.Parse($"FF{colorValues[i % colorValues.Count]}",
                    System.Globalization.NumberStyles.HexNumber));
            }

            //Build zones on the map
            while (restEmptyZone())
            {
                foreach (List<List<int>> zone in points)
                {
                    foreach (int point in zone[0])
                    {
                        if (point > width - 1 && cases[point - width].Zone == 0
                            && (cases[point - width].State == 3 || cases[point - width].State == 4))
                        {
                            cases[point - width].Zone = cases[point].Zone;

                            //Generate color orders
                            if (cases[point - width].Zone == 0)
                            {
                                cases[point - width].ZoneColor = Color.White;
                            }
                            else
                            {
                                cases[point - width].ZoneColor = 
                                    Color.FromArgb(int.Parse($"FF{colorValues[(cases[point - width].Zone - 1) % colorValues.Count]}", 
                                    System.Globalization.NumberStyles.HexNumber));
                            }

                            zone[1].Add(point - width);
                        }

                        if (point % width < width - 1 && cases[point + 1].Zone == 0
                            && (cases[point].State == 2 || cases[point].State == 4))
                        {
                            cases[point + 1].Zone = cases[point].Zone;

                            //Generate color orders
                            if (cases[point + 1].Zone == 0)
                            {
                                cases[point + 1].ZoneColor = Color.White;
                            }
                            else
                            {
                                cases[point + 1].ZoneColor = 
                                    Color.FromArgb(int.Parse($"FF{colorValues[(cases[point + 1].Zone - 1) % colorValues.Count]}", 
                                    System.Globalization.NumberStyles.HexNumber));
                            }

                            zone[1].Add(point + 1);
                        }

                        if (point < height * width - width && cases[point + width].Zone == 0
                            && (cases[point].State == 3 || cases[point].State == 4))
                        {
                            cases[point + width].Zone = cases[point].Zone;

                            //Generate color orders
                            if (cases[point + width].Zone == 0)
                            {
                                cases[point + width].ZoneColor = Color.White;
                            }
                            else
                            {
                                cases[point + width].ZoneColor =
                                    Color.FromArgb(int.Parse($"FF{colorValues[(cases[point + width].Zone - 1) % colorValues.Count]}",
                                    System.Globalization.NumberStyles.HexNumber));
                            }

                            zone[1].Add(point + width);
                        }

                        if (point % width > 0 && cases[point - 1].Zone == 0
                            && (cases[point - 1].State == 2 || cases[point - 1].State == 4))
                        {
                            cases[point - 1].Zone = cases[point].Zone;

                            //Generate color orders
                            if (cases[point - 1].Zone == 0)
                            {
                                cases[point - 1].ZoneColor = Color.White;
                            }
                            else
                            {
                                cases[point - 1].ZoneColor =
                                    Color.FromArgb(int.Parse($"FF{colorValues[(cases[point - 1].Zone - 1) % colorValues.Count]}",
                                    System.Globalization.NumberStyles.HexNumber));
                            }

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
                if(Math.Sqrt(Math.Pow(Math.Abs((point%width) - (newPoint%width)), 2) + Math.Pow(Math.Abs(Math.Floor((double)point/width) - Math.Floor((double)newPoint/width)), 2)) < ratio)
                {
                    return true;
                }
            }
            return false;
        }

        private bool restEmptyZone()
        {
            return !cases.TrueForAll(eachCase => eachCase.Zone != 0);
        }


        protected bool pathsFinished()
        {
            List<List<int>> visits = new List<List<int>>();
            List<int> unique = new List<int> { 0 };

            visits.Add(new List<int>());//Present
            visits.Add(new List<int>());//Futur

            visits[0].Add(0);

            do
            {
                foreach (int testAround in visits[0])
                {
                    if (testAround > width - 1 && (!visits[1].Contains(testAround - width)) && (!unique.Contains(testAround - width))
                        && (cases[testAround - width].State == 3 || cases[testAround - width].State == 4))
                    {
                        visits[1].Add(testAround - width);
                    }

                    if (testAround % width < width - 1 && (!visits[1].Contains(testAround + 1)) && (!unique.Contains(testAround + 1))
                        && (cases[testAround].State == 2 || cases[testAround].State == 4))
                    {
                        visits[1].Add(testAround + 1);
                    }

                    if (testAround < height * width - width && (!visits[1].Contains(testAround + width)) && (!unique.Contains(testAround + width))
                        && (cases[testAround].State == 3 || cases[testAround].State == 4))
                    {
                        visits[1].Add(testAround + width);
                    }

                    if (testAround % width > 0 && (!visits[1].Contains(testAround - 1)) && (!unique.Contains(testAround - 1))
                        && (cases[testAround - 1].State == 2 || cases[testAround - 1].State == 4))
                    {
                        visits[1].Add(testAround - 1);
                    }
                }

                unique.AddRange(new List<int>(visits[1]));
                visits[0] = new List<int>(visits[1]);
                visits[1].Clear();

            } while (visits[0].Count > 0);

            if (unique.Count != width * height)
            {
                for (int i = 0; i < width * height; i++)
                {
                    if ((!unique.Contains(i)) && unique.Count > (width * height) / 2)
                    {
                        if (i % width == width - 1)
                        {
                            cases[i - 1].State = (cases[i - 1].State % 4) + 1;
                        }
                        else if (i > (height * width) - width - 1)
                        {
                            cases[i - width].State = (cases[i - width].State % 4) + 1;
                        }

                        cases[i].State = (cases[i].State % 4) + 1;
                    }
                    else if (unique.Contains(i) && unique.Count <= (width * height) / 2)
                    {
                        cases[i].State = (cases[i].State % 4) + 1;
                    }
                }
                return false;
            }
            return true;
        }
    }
}
