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
            "00ffff", "0000ff", "a52a2a", "008b8b", "c0c0c0",
            "bdb76b", "556b2f", "ff8c00", "8b0000", "00ff00",
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

        public Case Self(int index)
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

        public bool CanGoUp(int index)
        {
            if (Upper(index) != null && (Upper(index).State == ARX.State.Down || Upper(index).State == ARX.State.Cross))
            {
                return true;
            }

            return false;
        }

        public bool CanGoRight(int index)
        {
            if (Righter(index) != null && (Self(index).State == ARX.State.Right || Self(index).State == ARX.State.Cross))
            {
                return true;
            }

            return false;
        }

        public bool CanGoDown(int index)
        {
            if (Lower(index) != null && (Self(index).State == ARX.State.Down || Self(index).State == ARX.State.Cross))
            {
                return true;
            }

            return false;
        }

        public bool CanGoLeft(int index)
        {
            if (Lefter(index) != null && (Lefter(index).State == ARX.State.Right || Lefter(index).State == ARX.State.Cross))
            {
                return true;
            }

            return false;
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
            double ratio = Math.Sqrt(((width * height) / nbZones) / Math.PI);

            List<List<List<int>>> zonesPoints = new List<List<List<int>>>();

            //Generate colors order
            ARX.Shuffle(rand, colorValues);

            //Generate starting points for each zones
            for (int eachZone = 0; eachZone < nbZones; eachZone++)
            {
                //Generate unique and separeted points in map
                int newCoord;
                do
                {
                    newCoord = rand.Next(0, width * height);
                }
                while (inZoneRadius(ratio, zonesPoints, newCoord));

                //Create zone's list
                zonesPoints.Add(new List<List<int>>());

                //Create storage inside each zones
                zonesPoints[eachZone].Add(new List<int>());//Actuals
                zonesPoints[eachZone].Add(new List<int>());//Futurs

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
                        if (CanGoUp(eachPoint) && Upper(eachPoint).Zone == 0)
                        {
                            Upper(eachPoint).Zone = Self(eachPoint).Zone;

                            //Get actual case color orders
                            Upper(eachPoint).ZoneColor = Self(eachPoint).ZoneColor;

                            eachZone[1].Add(Upper(eachPoint).Coord);
                        }

                        if (CanGoRight(eachPoint) && Righter(eachPoint).Zone == 0)
                        {
                            Righter(eachPoint).Zone = Self(eachPoint).Zone;

                            //Get actual case color orders
                            Righter(eachPoint).ZoneColor = Self(eachPoint).ZoneColor;

                            eachZone[1].Add(Righter(eachPoint).Coord);
                        }

                        if (CanGoDown(eachPoint) && Lower(eachPoint).Zone == 0)
                        {
                            Lower(eachPoint).Zone = Self(eachPoint).Zone;

                            //Get actual case color orders
                            Lower(eachPoint).ZoneColor = Self(eachPoint).ZoneColor;

                            eachZone[1].Add(Lower(eachPoint).Coord);
                        }

                        if (CanGoLeft(eachPoint) && Lefter(eachPoint).Zone == 0)
                        {
                            Lefter(eachPoint).Zone = Self(eachPoint).Zone;

                            //Get actual case color orders
                            Lefter(eachPoint).ZoneColor = Self(eachPoint).ZoneColor;

                            eachZone[1].Add(Lefter(eachPoint).Coord);
                        }
                    }

                    //Pass futurs points in actual points
                    eachZone[0] = new List<int>(eachZone[1]);
                    eachZone[1].Clear();
                }
            }
        }

        private bool inZoneRadius(double ratio, List<List<List<int>>> allZones, int newPoint)
        {
            foreach (List<List<int>> eachZone in allZones)
            {
                int firstZonePoint = eachZone[0][0];
                if (Math.Sqrt(Math.Pow(Math.Abs((firstZonePoint % width) - (newPoint%width)), 2) + Math.Pow(Math.Abs(Math.Floor((double)firstZonePoint / width) - Math.Floor((double)newPoint/width)), 2)) < ratio)
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
                    if (CanGoUp(testAround) //If case exists and is accessible
                        && (!visits[1].Contains(Upper(testAround).Coord)) && (!visited.Contains(Upper(testAround).Coord))) //If case not visited or to visit
                    {
                        visits[1].Add(Upper(testAround).Coord);
                    }

                    if (CanGoRight(testAround) //If case exists and is accessible
                        && (!visits[1].Contains(Righter(testAround).Coord)) && (!visited.Contains(Righter(testAround).Coord))) //If case not visited or to visit
                    {
                        visits[1].Add(Righter(testAround).Coord);
                    }

                    if (CanGoDown(testAround) //If case exists and is accessible
                        && (!visits[1].Contains(Lower(testAround).Coord)) && (!visited.Contains(Lower(testAround).Coord))) //If case not visited or to visit
                    {
                        visits[1].Add(Lower(testAround).Coord);
                    }

                    if (CanGoLeft(testAround) //If case exists and is accessible
                        && (!visits[1].Contains(Lefter(testAround).Coord)) && (!visited.Contains(Lefter(testAround).Coord))) //If case not visited or to visit
                    {
                        visits[1].Add(Lefter(testAround).Coord);
                    }
                }

                //Pass futur points to actual points and store them
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
                        if (Upper(eachCase) != null && visited.Contains(Upper(eachCase).Coord))
                        {
                            if (Upper(eachCase).State == ARX.State.Right)
                            {
                                Upper(eachCase).State = ARX.State.Cross;
                            }
                            else
                            {
                                Upper(eachCase).State = ARX.State.Down;
                            }
                        }
                        else if (Righter(eachCase) != null && visited.Contains(Righter(eachCase).Coord))
                        {
                            if (Self(eachCase).State == ARX.State.Down)
                            {
                                Self(eachCase).State = ARX.State.Cross;
                            }
                            else
                            {
                                Self(eachCase).State = ARX.State.Right;
                            }
                        }
                        else if (Lower(eachCase) != null && visited.Contains(Lower(eachCase).Coord))
                        {
                            if (Self(eachCase).State == ARX.State.Right)
                            {
                                Self(eachCase).State = ARX.State.Cross;
                            }
                            else
                            {
                                Self(eachCase).State = ARX.State.Down;
                            }
                        }
                        else if (Lefter(eachCase) != null && visited.Contains(Lefter(eachCase).Coord))
                        {
                            if (Lefter(eachCase).State == ARX.State.Down)
                            {
                                Lefter(eachCase).State = ARX.State.Cross;
                            }
                            else
                            {
                                Lefter(eachCase).State = ARX.State.Right;
                            }
                        }
                    }

                    //Affect cases joinable from 0/0 if this part is the smallest
                    else if (visited.Contains(eachCase) && visited.Count <= (width * height) / 2)
                    {
                        Self(eachCase).State = Self(eachCase).NextPathState;
                    }
                }

                return false;
            }

            return true;
        }

        /*public void ProcessPath(Point playerPos, Point exitPos)
        {
            int playerIndex = playerPos.Y * width + playerPos.X;
            int exitIndex = exitPos.Y * width + exitPos.X;

            Self(playerIndex).OriginDistance = 0;

            List<int> bestPath = new List<int>();
            bestPath.Add(0);

            do
            {
                int minIndex = 0;
                foreach (Case eachCase in cases)
                {
                    if (eachCase.OriginDistance != -1 && !bestPath.Contains(minIndex)
                        && eachCase.OriginDistance < Self(bestPath.Last()).OriginDistance)
                    {
                        minIndex = eachCase.Coord;
                    }
                }
                bestPath.Add(minIndex);

                if (CanGoUp(minIndex)) //If case exists and is accessible
                {
                    Upper(minIndex).OriginDistance = Self(minIndex).OriginDistance + 1;
                }

                if (CanGoRight(minIndex)) //If case exists and is accessible
                {
                    Righter(minIndex).OriginDistance = Self(minIndex).OriginDistance + 1;
                }

                if (CanGoDown(minIndex)) //If case exists and is accessible
                {
                    Lower(minIndex).OriginDistance = Self(minIndex).OriginDistance + 1;
                }

                if (CanGoLeft(minIndex)) //If case exists and is accessible
                {
                    Lefter(minIndex).OriginDistance = Self(minIndex).OriginDistance + 1;
                }
            } while (bestPath.Last() != exitIndex);

            foreach (int eachCase in bestPath)
            {
                Self(eachCase).Accessible = false;
            }
        }*/

        public void ProcessPath(Point playerPos, Point exitPos)
        {
            int playerIndex = playerPos.Y * width + playerPos.X;
            int exitIndex = exitPos.Y * width + exitPos.X;

            //Self(playerIndex).OriginDistance = 0;

            List<List<int>> points = new List<List<int>>();

            points.Add(new List<int>());//Actuals
            points.Add(new List<int>());//Futurs

            points[0].Add(playerIndex);

            while(!points[0].Contains(exitIndex))
            {
                foreach(int testAround in points[0])
                {
                    if (CanGoUp(testAround))
                    {
                        int score;
                        if(Self(testAround).Zone == Upper(testAround).Zone) { score = 1; } else { score = cases.Count; }

                        if(Upper(testAround).ScoreDistance < 0 || Upper(testAround).ScoreDistance > Self(testAround).ScoreDistance + score)
                        {
                            Upper(testAround).OriginDistance = Self(testAround).Coord;
                            Upper(testAround).ScoreDistance = Self(testAround).ScoreDistance + score;
                            points[1].Add(Upper(testAround).Coord);
                        }
                    }

                    if (CanGoRight(testAround))
                    {
                        int score;
                        if (Self(testAround).Zone == Righter(testAround).Zone) { score = 1; } else { score = cases.Count; }

                        if (Righter(testAround).ScoreDistance < 0 || Righter(testAround).ScoreDistance > Self(testAround).ScoreDistance + score)
                        {
                            Righter(testAround).OriginDistance = Self(testAround).Coord;
                            Righter(testAround).ScoreDistance = Self(testAround).ScoreDistance + score;
                            points[1].Add(Righter(testAround).Coord);
                        }
                    }

                    if (CanGoDown(testAround))
                    {
                        int score;
                        if (Self(testAround).Zone == Lower(testAround).Zone) { score = 1; } else { score = cases.Count; }

                        if (Lower(testAround).ScoreDistance < 0 || Lower(testAround).ScoreDistance > Self(testAround).ScoreDistance + score)
                        {
                            Lower(testAround).OriginDistance = Self(testAround).Coord;
                            Lower(testAround).ScoreDistance = Self(testAround).ScoreDistance + score;
                            points[1].Add(Lower(testAround).Coord);
                        }
                    }

                    if (CanGoLeft(testAround))
                    {
                        int score;
                        if (Self(testAround).Zone == Lefter(testAround).Zone) { score = 1; } else { score = cases.Count; }

                        if (Lefter(testAround).ScoreDistance < 0 || Lefter(testAround).ScoreDistance > Self(testAround).ScoreDistance + score)
                        {
                            Lefter(testAround).OriginDistance = Self(testAround).Coord;
                            Lefter(testAround).ScoreDistance = Self(testAround).ScoreDistance + score;
                            points[1].Add(Lefter(testAround).Coord);
                        }
                    }




                    /*
                    if (CanGoUp(testAround) && Upper(testAround).OriginDistance == -1 && !points[1].Contains(testAround)) 
                    {
                        Upper(testAround).OriginDistance = Self(testAround).Coord;
                        points[1].Add(Upper(testAround).Coord);
                    }

                    if (CanGoRight(testAround) && ((1 == 1) ||
                        (Righter(testAround).OriginDistance == -1 && !points[1].Contains(testAround))))
                    {
                        Righter(testAround).OriginDistance = Self(testAround).Coord;
                        points[1].Add(Righter(testAround).Coord);
                    }

                    if (CanGoDown(testAround) && Lower(testAround).OriginDistance == -1 && !points[1].Contains(testAround))
                    {
                        Lower(testAround).OriginDistance = Self(testAround).Coord;
                        points[1].Add(Lower(testAround).Coord);
                    }

                    if (CanGoLeft(testAround) && Lefter(testAround).OriginDistance == -1 && !points[1].Contains(testAround))
                    {
                        Lefter(testAround).OriginDistance = Self(testAround).Coord;
                        points[1].Add(Lefter(testAround).Coord);
                    }*/
                }

                points[0] = new List<int>(points[1]);
                points[1].Clear();
            }

            int currentPoint = exitIndex;
            Self(currentPoint).Accessible = false;
            while (playerIndex != currentPoint)
            {
                currentPoint = Self(currentPoint).OriginDistance;
                Self(currentPoint).Accessible = false;
            }
        }
    }
}
