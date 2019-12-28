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

        public Case Meme(int index)
        {
            return cases[index];
        }

        public Case Upper(int index)
        {
            if (index >= width)
            {
                return cases[index - width];
            }
            else
            {
                return null;
            }
        }

        public Case Righter(int index)
        {
            if (index % width < width - 1)
            {
                return cases[index + 1];
            }
            else
            {
                return null;
            }
        }

        public Case Lower(int index)
        {
            if (index < (height-1) * width)
            {
                return cases[index + width];
            }
            else
            {
                return null;
            }
        }

        public Case Lefter(int index)
        {
            if (index % width > 0)
            {
                return cases[index - 1];
            }
            else
            {
                return null;
            }
        }

        public abstract void GenerateMap(PictureBox elem, Label loading);

        public void GenerateZones(PictureBox elem, Label loading, int zones)
        {
            List<List<List<int>>> points = new List<List<List<int>>>();
            List<int> usedCoords = new List<int>();

            double ratio = Math.Sqrt((width * height / (zones)) / Math.PI) * 1.5;

            ARX.Shuffle(rand, colorValues);

            //Generate starting points for each zones
            for (int eachZone = 0; eachZone < zones; eachZone++)
            {
                points.Add(new List<List<int>>());

                points[eachZone].Add(new List<int>());//Present
                points[eachZone].Add(new List<int>());//Futur

                int newCoord;
                do
                {
                    newCoord = rand.Next(0, width * height);
                }
                while (inZoneRadius(ratio, usedCoords, newCoord));

                usedCoords.Add(newCoord);
                points[eachZone][0].Add(newCoord);

                cases[newCoord].Zone = eachZone + 1;

                //Generate color orders
                cases[newCoord].ZoneColor =
                    Color.FromArgb(int.Parse($"FF{colorValues[eachZone % colorValues.Count]}",
                    System.Globalization.NumberStyles.HexNumber));
            }

            //Build zones on the map
            while (restEmptyZone())
            {
                foreach (List<List<int>> eachZone in points)
                {
                    foreach (int point in eachZone[0])
                    {
                        if (Upper(point) != null && Upper(point).Zone == 0
                            && (Upper(point).State == ARX.State.Down || Upper(point).State == ARX.State.Cross))
                        {
                            Upper(point).Zone = Meme(point).Zone;

                            //Generate color orders
                            if (Upper(point).Zone == 0)
                            {
                                Upper(point).ZoneColor = Color.White;
                            }
                            else
                            {
                                Upper(point).ZoneColor = 
                                    Color.FromArgb(int.Parse($"FF{colorValues[(Upper(point).Zone - 1) % colorValues.Count]}", 
                                    System.Globalization.NumberStyles.HexNumber));
                            }

                            eachZone[1].Add(Upper(point).Coord);
                        }

                        if (Righter(point) != null && Righter(point).Zone == 0
                            && (Meme(point).State == ARX.State.Right || Meme(point).State == ARX.State.Cross))
                        {
                            Righter(point).Zone = Meme(point).Zone;

                            //Generate color orders
                            if (Righter(point).Zone == 0)
                            {
                                Righter(point).ZoneColor = Color.White;
                            }
                            else
                            {
                                Righter(point).ZoneColor = 
                                    Color.FromArgb(int.Parse($"FF{colorValues[(Righter(point).Zone - 1) % colorValues.Count]}", 
                                    System.Globalization.NumberStyles.HexNumber));
                            }

                            eachZone[1].Add(Righter(point).Coord);
                        }

                        if (Lower(point) != null && Lower(point).Zone == 0
                            && (Meme(point).State == ARX.State.Down || Meme(point).State == ARX.State.Cross))
                        {
                            Lower(point).Zone = Meme(point).Zone;

                            //Generate color orders
                            if (Lower(point).Zone == 0)
                            {
                                Lower(point).ZoneColor = Color.White;
                            }
                            else
                            {
                                Lower(point).ZoneColor =
                                    Color.FromArgb(int.Parse($"FF{colorValues[(Lower(point).Zone - 1) % colorValues.Count]}",
                                    System.Globalization.NumberStyles.HexNumber));
                            }

                            eachZone[1].Add(Lower(point).Coord);
                        }

                        if (Lefter(point) != null && Lefter(point).Zone == 0
                            && (Lefter(point).State == ARX.State.Right || Lefter(point).State == ARX.State.Cross))
                        {
                            Lefter(point).Zone = Meme(point).Zone;

                            //Generate color orders
                            if (Lefter(point).Zone == 0)
                            {
                                Lefter(point).ZoneColor = Color.White;
                            }
                            else
                            {
                                Lefter(point).ZoneColor =
                                    Color.FromArgb(int.Parse($"FF{colorValues[(Lefter(point).Zone - 1) % colorValues.Count]}",
                                    System.Globalization.NumberStyles.HexNumber));
                            }

                            eachZone[1].Add(Lefter(point).Coord);
                        }
                    }

                    eachZone[0] = new List<int>(eachZone[1]);
                    eachZone[1].Clear();
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

        protected bool restEmptyState()
        {
            return !cases.TrueForAll(eachCase => eachCase.State != 0);
        }

        protected bool restEmptyZone()
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

            while (visits[0].Count > 0)
            {
                foreach (int testAround in visits[0])
                {
                    if (Upper(testAround) != null
                        && (!visits[1].Contains(Upper(testAround).Coord)) && (!unique.Contains(Upper(testAround).Coord))
                        && (Upper(testAround).State == ARX.State.Down || Upper(testAround).State == ARX.State.Cross))
                    {
                        visits[1].Add(Upper(testAround).Coord);
                    }

                    if (Righter(testAround) != null 
                        && (!visits[1].Contains(Righter(testAround).Coord)) && (!unique.Contains(Righter(testAround).Coord))
                        && (Meme(testAround).State == ARX.State.Right || Meme(testAround).State == ARX.State.Cross))
                    {
                        visits[1].Add(Righter(testAround).Coord);
                    }

                    if (Lower(testAround) != null 
                        && (!visits[1].Contains(Lower(testAround).Coord)) && (!unique.Contains(Lower(testAround).Coord))
                        && (Meme(testAround).State == ARX.State.Down || Meme(testAround).State == ARX.State.Cross))
                    {
                        visits[1].Add(Lower(testAround).Coord);
                    }

                    if (Lefter(testAround) != null 
                        && (!visits[1].Contains(Lefter(testAround).Coord)) && (!unique.Contains(Lefter(testAround).Coord))
                        && (Lefter(testAround).State == ARX.State.Right || Lefter(testAround).State == ARX.State.Cross))
                    {
                        visits[1].Add(Lefter(testAround).Coord);
                    }
                }

                unique.AddRange(new List<int>(visits[1]));
                visits[0] = new List<int>(visits[1]);
                visits[1].Clear();
            } 

            //If the map is separeted in multiple parts
            if (unique.Count != width * height)
            {
                for (int eachCase = 0; eachCase < width * height; eachCase++)
                {
                    //Affect cases not joinable from 0/0 if this part is the bigger
                    if ((!unique.Contains(eachCase)) && unique.Count > (width * height) / 2)
                    {
                        //Special right side case
                        if (Righter(eachCase) == null)
                        {
                            Lefter(eachCase).State = Lefter(eachCase).NextPathState;
                        }
                        //Special lower side case
                        else if (Lower(eachCase) == null)
                        {
                            Upper(eachCase).State = Upper(eachCase).NextPathState;
                        }

                        //Change state to another one (except void form)
                        Meme(eachCase).State = Meme(eachCase).NextPathState;
                    }

                    //Affect cases joinable from 0/0 if this part is the smallest
                    else if (unique.Contains(eachCase) && unique.Count <= (width * height) / 2)
                    {
                        Meme(eachCase).State = Meme(eachCase).NextPathState;
                    }
                }

                return false;
            }

            return true;
        }
    }
}
