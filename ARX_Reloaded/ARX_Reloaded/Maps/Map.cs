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

        public Case self(int index)
        {
            return cases[index];
        }

        public Case upper(int index)
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

        public Case righter(int index)
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

        public Case lower(int index)
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

        public Case lefter(int index)
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

        public virtual void GenerateMap(PictureBox elem, Label loading)
        {
            cases = new List<Case>();

            //Initialize/reset map
            for (int eachCase = 0; eachCase < width * height; eachCase++)
            {
                cases.Add(new Case(eachCase));
            }
        }

        public void GenerateZones(PictureBox elem, Label loading, int nbZones)
        {
            double ratio = Math.Sqrt(((width * height) / nbZones) / Math.PI) * 1.5;

            List<List<List<int>>> zonesPoints = new List<List<List<int>>>();

            //Generate colors order
            ARX.Shuffle(rand, colorValues);

            //Generate starting points for each zones
            for (int eachZone = 0; eachZone < nbZones; eachZone++)
            {
                //Create zone's list
                zonesPoints.Add(new List<List<int>>());

                //Create storage inside each zones
                zonesPoints[eachZone].Add(new List<int>());//Actuals
                zonesPoints[eachZone].Add(new List<int>());//Futurs

                //Generate unique and separeted points in map
                int newCoord;
                do
                {
                    newCoord = rand.Next(0, width * height);
                }
                while (inZoneRadius(ratio, zonesPoints[eachZone][0], newCoord));

                zonesPoints[eachZone][0].Add(newCoord);

                //Generate zones id and colors
                cases[newCoord].Zone = eachZone + 1;
                cases[newCoord].ZoneColor =
                    Color.FromArgb(int.Parse($"FF{colorValues[eachZone % colorValues.Count]}",
                    System.Globalization.NumberStyles.HexNumber));
            }

            //Build zones on the map
            while (restEmptyZone())
            {
                //Update each zones
                foreach (List<List<int>> eachZone in zonesPoints)
                {
                    //Advance each points 
                    foreach (int eachPoint in eachZone[0])
                    {
                        if (upper(eachPoint) != null && upper(eachPoint).Zone == 0
                            && (upper(eachPoint).State == ARX.State.Down || upper(eachPoint).State == ARX.State.Cross))
                        {
                            upper(eachPoint).Zone = self(eachPoint).Zone;

                            //Get actual case color orders
                            upper(eachPoint).ZoneColor = self(eachPoint).ZoneColor;

                            eachZone[1].Add(upper(eachPoint).Coord);
                        }

                        if (righter(eachPoint) != null && righter(eachPoint).Zone == 0
                            && (self(eachPoint).State == ARX.State.Right || self(eachPoint).State == ARX.State.Cross))
                        {
                            righter(eachPoint).Zone = self(eachPoint).Zone;

                            //Get actual case color orders
                            righter(eachPoint).ZoneColor = self(eachPoint).ZoneColor;

                            eachZone[1].Add(righter(eachPoint).Coord);
                        }

                        if (lower(eachPoint) != null && lower(eachPoint).Zone == 0
                            && (self(eachPoint).State == ARX.State.Down || self(eachPoint).State == ARX.State.Cross))
                        {
                            lower(eachPoint).Zone = self(eachPoint).Zone;

                            //Get actual case color orders
                            lower(eachPoint).ZoneColor = self(eachPoint).ZoneColor;

                            eachZone[1].Add(lower(eachPoint).Coord);
                        }

                        if (lefter(eachPoint) != null && lefter(eachPoint).Zone == 0
                            && (lefter(eachPoint).State == ARX.State.Right || lefter(eachPoint).State == ARX.State.Cross))
                        {
                            lefter(eachPoint).Zone = self(eachPoint).Zone;

                            //Get actual case color orders
                            lefter(eachPoint).ZoneColor = self(eachPoint).ZoneColor;

                            eachZone[1].Add(lefter(eachPoint).Coord);
                        }
                    }

                    //Pass futurs points in actual points
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

        //Check for void case
        protected bool restEmptyState()
        {
            return !cases.TrueForAll(eachCase => eachCase.State != ARX.State.Void);
        }

        //Check for non defined zone
        protected bool restEmptyZone()
        {
            return !cases.TrueForAll(eachCase => eachCase.Zone != 0);
        }

        protected bool pathsFinished()
        {
            //Store cases to visit and cases who will be visited
            List<List<int>> visits = new List<List<int>>();
            //Store every visited cases
            List<int> visited = new List<int>();

            visits.Add(new List<int>());//Actuals
            visits.Add(new List<int>());//Futurs

            //First case to visit and reference case
            visits[0].Add(0);
            visited.Add(0);

            while (visits[0].Count > 0)
            {
                foreach (int testAround in visits[0])
                {
                    if (upper(testAround) != null //If case exists
                        && (!visits[1].Contains(upper(testAround).Coord)) && (!visited.Contains(upper(testAround).Coord)) //If case not visited or to visit
                        && (upper(testAround).State == ARX.State.Down || upper(testAround).State == ARX.State.Cross)) //If case is accessible
                    {
                        visits[1].Add(upper(testAround).Coord);
                    }

                    if (righter(testAround) != null //If case exists
                        && (!visits[1].Contains(righter(testAround).Coord)) && (!visited.Contains(righter(testAround).Coord)) //If case not visited or to visit
                        && (self(testAround).State == ARX.State.Right || self(testAround).State == ARX.State.Cross)) //If case is accessible
                    {
                        visits[1].Add(righter(testAround).Coord);
                    }

                    if (lower(testAround) != null //If case exists
                        && (!visits[1].Contains(lower(testAround).Coord)) && (!visited.Contains(lower(testAround).Coord)) //If case not visited or to visit
                        && (self(testAround).State == ARX.State.Down || self(testAround).State == ARX.State.Cross)) //If case is accessible
                    {
                        visits[1].Add(lower(testAround).Coord);
                    }

                    if (lefter(testAround) != null //If case exists
                        && (!visits[1].Contains(lefter(testAround).Coord)) && (!visited.Contains(lefter(testAround).Coord)) //If case not visited or to visit
                        && (lefter(testAround).State == ARX.State.Right || lefter(testAround).State == ARX.State.Cross)) //If case is accessible
                    {
                        visits[1].Add(lefter(testAround).Coord);
                    }
                }

                //Pass futur poi^nts to actual points and store them
                visited.AddRange(new List<int>(visits[1]));
                visits[0] = new List<int>(visits[1]);
                visits[1].Clear();
            } 

            //If the map is not in one part
            if (visited.Count != width * height)
            {
                for (int eachCase = 0; eachCase < width * height; eachCase++)
                {
                    //Affect cases not joinable from 0/0 if this part is the bigger
                    if ((!visited.Contains(eachCase)) && visited.Count > (width * height) / 2)
                    {
                        //Special right map side case
                        if (righter(eachCase) == null)
                        {
                            lefter(eachCase).State = lefter(eachCase).NextPathState;
                        }
                        //Special lower map side case
                        else if (lower(eachCase) == null)
                        {
                            upper(eachCase).State = upper(eachCase).NextPathState;
                        }

                        //Change state to another one (except void form)
                        self(eachCase).State = self(eachCase).NextPathState;
                    }

                    //Affect cases joinable from 0/0 if this part is the smallest
                    else if (visited.Contains(eachCase) && visited.Count <= (width * height) / 2)
                    {
                        self(eachCase).State = self(eachCase).NextPathState;
                    }
                }

                return false;
            }

            return true;
        }
    }
}
