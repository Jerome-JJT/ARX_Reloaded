﻿using System;
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
        #region Class business
        protected int width;
        protected int height;

        private int zoom;

        protected List<Case> cases;
        private int exitIndex;

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

            zoom = 1;

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

        public int Zoom
        {
            get { return zoom; }
            set { zoom = value; }
        }

        public int ExitIndex
        {
            get { return exitIndex; }
        }
        #endregion Class business

        #region Cases management
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
        #endregion Cases management

        #region Verifications functions
        //Check for void case
        protected bool restEmptyState()
        {
            return !cases.TrueForAll(eachCase => eachCase.State != ARX.State.Void);
        }

        //Check for non defined zone
        protected bool restEmptyZone()
        {
            return !cases.TrueForAll(eachCase => eachCase.Zone != -1);
        }

        private bool inZoneRadius(double ratio, List<List<List<int>>> allZones, int newPoint)
        {
            foreach (List<List<int>> eachZone in allZones)
            {
                int firstZonePoint = eachZone[0][0];
                if (inRadius(ratio, firstZonePoint, newPoint))
                {
                    return true;
                }
            }

            return false;
        }

        private bool inRadius(double ratio, int oldPoint, int newPoint)
        {
            if (Math.Sqrt(Math.Pow(Math.Abs((oldPoint % width) - (newPoint % width)), 2) + Math.Pow(Math.Abs(Math.Floor((double)oldPoint / width) - Math.Floor((double)newPoint / width)), 2)) < ratio)
            {
                return true;
            }

            return false;
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
        #endregion Verifications functions

        public void Generate(int startZone, int nbZones)
        {
            generatePaths();
            generateZones(nbZones);
            generateEvents(startZone);

            UnlockZone(Self(startZone).Zone);

            //ProcessPath(playerPos, exitIndex);
        }

        #region Generation
        protected virtual void generatePaths()
        {
            cases = new List<Case>();

            //Initialize/reset map
            for (int eachCase = 0; eachCase < width * height; eachCase++)
            {
                cases.Add(new Case(eachCase));
            }
        }

        private void generateZones(int nbZones)
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
                cases[newCoord].Zone = eachZone;
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
                        if (CanGoUp(eachPoint) && Upper(eachPoint).Zone == -1)
                        {
                            Upper(eachPoint).Zone = Self(eachPoint).Zone;

                            //Get actual case color orders
                            Upper(eachPoint).ZoneColor = Self(eachPoint).ZoneColor;

                            eachZone[1].Add(Upper(eachPoint).Coord);
                        }

                        if (CanGoRight(eachPoint) && Righter(eachPoint).Zone == -1)
                        {
                            Righter(eachPoint).Zone = Self(eachPoint).Zone;

                            //Get actual case color orders
                            Righter(eachPoint).ZoneColor = Self(eachPoint).ZoneColor;

                            eachZone[1].Add(Righter(eachPoint).Coord);
                        }

                        if (CanGoDown(eachPoint) && Lower(eachPoint).Zone == -1)
                        {
                            Lower(eachPoint).Zone = Self(eachPoint).Zone;

                            //Get actual case color orders
                            Lower(eachPoint).ZoneColor = Self(eachPoint).ZoneColor;

                            eachZone[1].Add(Lower(eachPoint).Coord);
                        }

                        if (CanGoLeft(eachPoint) && Lefter(eachPoint).Zone == -1)
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

        private void generateEvents(int startIndex)
        {
            int ratio = (width + height) / 3;

            //Create exit point
            int exitZone;
            do
            {
                exitZone = rand.Next(0, width * height);
            }
            while (inRadius(ratio, startIndex, exitZone));

            exitIndex = exitZone;

            //Create start and end events on cases
            cases[startIndex].CaseEvent = new BaseEvent();
            cases[exitIndex].CaseEvent = new ExitEvent();

            generateZonesKey(startIndex, exitIndex);

            cases.ForEach(eachCase => { if (rand.Next(100) < 15 && eachCase.CaseEvent.GetType() == typeof(NoEvent)) { eachCase.CaseEvent = new CoinEvent(); } });
        }
        #endregion


        #region Path management
        private void processDistances(int startIndex)
        {
            List<List<int>> points = new List<List<int>>();

            points.Add(new List<int>());//Actuals
            points.Add(new List<int>());//Futurs

            points[0].Add(startIndex);

            while (points[0].Count > 0)
            {
                foreach (int testAround in points[0])
                {
                    if (CanGoUp(testAround))
                    {
                        int score;
                        if (Self(testAround).Zone == Upper(testAround).Zone) { score = 1; } else { score = cases.Count; }

                        if (Upper(testAround).ScoreDistance < 0 || Upper(testAround).ScoreDistance > Self(testAround).ScoreDistance + score)
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
                }

                points[0] = new List<int>(points[1]);
                points[1].Clear();
            }
        }

        private List<int> zonesInPath(int startPoint, int endPoint)
        {
            List<int> result = new List<int>();

            //Start with the end point and check previous path's case, add case's zone once in result
            int currentPoint = endPoint;
            while (startPoint != currentPoint)
            {
                if (!result.Contains(Self(currentPoint).Zone))
                {
                    result.Add(Self(currentPoint).Zone);
                }
                currentPoint = Self(currentPoint).OriginDistance;
            }
            result.Reverse();

            return result;
        }
        #endregion


        #region Key management
        private List<List<int>> getZonesUnions()
        {
            List<List<int>> unions = new List<List<int>>();
            foreach (Case eachCase in cases)
            {
                if (CanGoUp(eachCase.Coord) && eachCase.Zone != Upper(eachCase.Coord).Zone)
                {
                    List<int> oneUnion = new List<int> { eachCase.Zone, Upper(eachCase.Coord).Zone };
                    oneUnion.Sort();
                    if (unions.TrueForAll(eachUnion => !(oneUnion[0] == eachUnion[0] && oneUnion[1] == eachUnion[1])))
                    {
                        unions.Add(oneUnion);
                    }
                }
                if (CanGoRight(eachCase.Coord) && eachCase.Zone != Righter(eachCase.Coord).Zone)
                {
                    List<int> oneUnion = new List<int> { eachCase.Zone, Righter(eachCase.Coord).Zone };
                    oneUnion.Sort();
                    if (unions.TrueForAll(eachUnion => !(oneUnion[0] == eachUnion[0] && oneUnion[1] == eachUnion[1])))
                    {
                        unions.Add(oneUnion);
                    }
                }
                if (CanGoDown(eachCase.Coord) && eachCase.Zone != Lower(eachCase.Coord).Zone)
                {
                    List<int> oneUnion = new List<int> { eachCase.Zone, Lower(eachCase.Coord).Zone };
                    oneUnion.Sort();
                    if (unions.TrueForAll(eachUnion => !(oneUnion[0] == eachUnion[0] && oneUnion[1] == eachUnion[1])))
                    {
                        unions.Add(oneUnion);
                    }
                }
                if (CanGoLeft(eachCase.Coord) && eachCase.Zone != Lefter(eachCase.Coord).Zone)
                {
                    List<int> oneUnion = new List<int> { eachCase.Zone, Lefter(eachCase.Coord).Zone };
                    oneUnion.Sort();
                    if (unions.TrueForAll(eachUnion => !(oneUnion[0] == eachUnion[0] && oneUnion[1] == eachUnion[1])))
                    {
                        unions.Add(oneUnion);
                    }
                }
            }

            return unions;
        }

        private void generateZonesKey(int playerIndex, int exitZone)
        {
            processDistances(playerIndex);

            //Get all zones in minimum path
            List<int> zonesPath = zonesInPath(playerIndex, exitZone);

            //Get all crossing zones who haven't been checked
            List<List<int>> allUnions = getZonesUnions();

            //Contains zone who already have their key generated
            //First zone in path (player's zone) doesn't need a key
            List<int> zonesKeyed = new List<int> { zonesPath[0] };

            //Check all zones in player's path
            foreach (int oneZonePath in zonesPath)
            {
                //Get all unions linked to the zone being checked
                List<List<int>> zoneUnion = allUnions.Where(oneUnion => oneUnion[0] == oneZonePath || oneUnion[1] == oneZonePath).ToList();

                //Try to generate a key for each unions from this zone
                foreach (List<int> oneUnion in zoneUnion)
                {
                    //Filter this union from external union
                    int newZone = oneUnion.Where(oneZone => oneZone != oneZonePath).Single();

                    //If there's no key for this zone, create one
                    if (!zonesKeyed.Contains(newZone))
                    {
                        putKeyInZone(oneZonePath, newZone);
                        zonesKeyed.Add(newZone);
                    }
                    allUnions.Remove(oneUnion);
                }
            }

            //Unions who are not next to a zone in player's path
            while (allUnions.Any())
            {
                //Get the first union from the list
                List<int> restUnion = allUnions.First();

                //If key have already been generated (special cases)
                if (zonesKeyed.Contains(restUnion[0]) && zonesKeyed.Contains(restUnion[1]))
                {
                    allUnions.Remove(restUnion);
                }
                else
                {
                    //Check which zone already have a key
                    List<int> keyedZone = restUnion.Where(oneZone => zonesKeyed.Contains(oneZone)).ToList();

                    //If neither zone already have a key, if so remove union from list and readd it at the end
                    if(!keyedZone.Any())
                    {
                        allUnions.Remove(restUnion);
                        allUnions.Add(restUnion);
                    }
                    else
                    {
                        //Choose the zone without a key and add it
                        int nonKeyedZone = restUnion.Where(oneZone => oneZone != keyedZone.Single()).Single();
                        putKeyInZone(keyedZone.Single(), nonKeyedZone);
                        zonesKeyed.Add(nonKeyedZone);
                        allUnions.Remove(restUnion);
                    }
                }
            }
        }

        private void putKeyInZone(int keyZone, int zoneToOpen)
        {
            List<Case> possibilities = cases.Where(eachCase => eachCase.Zone == keyZone && eachCase.CaseEvent.GetType() == typeof(NoEvent)).ToList();
            Case keyCase = possibilities[rand.Next(possibilities.Count)];

            keyCase.CaseEvent = new KeyEvent(zoneToOpen);
        }
        #endregion


        #region Zone management
        private void showZoneAccessible(int zoneToShow)
        {
            foreach(Case zoneCase in cases.Where(eachCase => eachCase.Zone == zoneToShow))
            {
                if (CanGoUp(zoneCase.Coord) && Upper(zoneCase.Coord).Accessible == true)
                {
                    zoneCase.Visible = true;
                }
                if (CanGoRight(zoneCase.Coord) && Righter(zoneCase.Coord).Accessible == true)
                {
                    zoneCase.Visible = true;
                }
                if (CanGoDown(zoneCase.Coord) && Lower(zoneCase.Coord).Accessible == true)
                {
                    zoneCase.Visible = true;
                }
                if (CanGoLeft(zoneCase.Coord) && Lefter(zoneCase.Coord).Accessible == true)
                {
                    zoneCase.Visible = true;
                }
            }
        }

        public void UnlockZone(int zoneToAffect)
        {
            showZoneAccessible(zoneToAffect);

            foreach (Case eachCase in cases)
            {
                if(eachCase.Zone == zoneToAffect)
                {
                    eachCase.Accessible = true;
                }
            }
        }
        #endregion


        public void ProcessPath(Point playerPos, int exitZone)
        {
            int playerIndex = playerPos.Y * width + playerPos.X;

            processDistances(playerIndex);

            //Trace path from player to end
            int currentPoint = exitZone;
            Self(currentPoint).Accessible = false;
            while (playerIndex != currentPoint)
            {
                currentPoint = Self(currentPoint).OriginDistance;
                Self(currentPoint).Accessible = false;
            }
        }
    }
}
