using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public class MapFastChaos : Map
    {
        private int pathInstances;

        public MapFastChaos(int pathInstances, Size mapSize, Random mapRandom) : base(mapSize, mapRandom)
        {
            this.pathInstances = pathInstances;
        }

        public override void GenerateMap(PictureBox elem, Label loading)
        {
            base.GenerateMap(elem, loading);

            cases.First().State = ARX.State.Cross;
            cases.Last().State = ARX.State.Point;

            List<int> currentPoints = new List<int>();

            //Choose starting points and initialize them
            for (int eachInstance = 0; eachInstance < pathInstances; eachInstance++)
            {
                int newCoord;
                do
                {
                    newCoord = rand.Next(cases.Count());
                }
                while (currentPoints.Contains(newCoord));

                cases[newCoord].State = ARX.State.Point;
                currentPoints.Add(newCoord);
            }

            //Search for new testAround until stack is empty
            while (restEmptyState())
            {
                for (int currentPoint = 0; currentPoint < currentPoints.Count; currentPoint++)
                {
                    //Determine in which direction the labyrinth is expandable
                    ARX.Direction futurDirection = oneRandAdjacent(currentPoints[currentPoint]);

                    //Expand the labyrinth to the up
                    if (futurDirection == ARX.Direction.Up)
                    {
                        if (upper(currentPoints[currentPoint]).State == ARX.State.Right)
                        {
                            upper(currentPoints[currentPoint]).State = ARX.State.Cross;
                        }
                        else
                        {
                            upper(currentPoints[currentPoint]).State = ARX.State.Down;
                        }

                        currentPoints[currentPoint] = upper(currentPoints[currentPoint]).Coord;
                    }

                    //Expand the labyrinth to the right
                    else if (futurDirection == ARX.Direction.Right)
                    {
                        if (self(currentPoints[currentPoint]).State == ARX.State.Down)
                        {
                            self(currentPoints[currentPoint]).State = ARX.State.Cross;
                        }
                        else
                        {
                            self(currentPoints[currentPoint]).State = ARX.State.Right;
                        }

                        if (righter(currentPoints[currentPoint]).State == ARX.State.Void)
                        {
                            righter(currentPoints[currentPoint]).State = ARX.State.Point;
                        }

                        currentPoints[currentPoint] = righter(currentPoints[currentPoint]).Coord;
                    }

                    //Expand the labyrinth to the down
                    else if (futurDirection == ARX.Direction.Down)
                    {
                        if (self(currentPoints[currentPoint]).State == ARX.State.Right)
                        {
                            self(currentPoints[currentPoint]).State = ARX.State.Cross;
                        }
                        else
                        {
                            self(currentPoints[currentPoint]).State = ARX.State.Down;
                        }

                        if (lower(currentPoints[currentPoint]).State == ARX.State.Void)
                        {
                            lower(currentPoints[currentPoint]).State = ARX.State.Point;
                        }

                        currentPoints[currentPoint] = lower(currentPoints[currentPoint]).Coord;
                    }

                    //Expand the labyrinth to the left
                    else if (futurDirection == ARX.Direction.Left)
                    {
                        if (lefter(currentPoints[currentPoint]).State == ARX.State.Down)
                        {
                            lefter(currentPoints[currentPoint]).State = ARX.State.Cross;
                        }
                        else
                        {
                            lefter(currentPoints[currentPoint]).State = ARX.State.Right;
                        }

                        currentPoints[currentPoint] = lefter(currentPoints[currentPoint]).Coord;
                    }
                }
            }

            for (int eachTry = 0; eachTry <= 100 && !pathsFinished(); eachTry++)
            {
                if (eachTry == 100)
                {
                    GenerateMap(elem, loading);
                }
            }
        }

        //Search for a case around given case
        private ARX.Direction oneRandAdjacent(int baseSearch)
        {
            //Decide in which order directions will be tested
            List<ARX.Direction> possibilities = new List<ARX.Direction> {
                ARX.Direction.Up, ARX.Direction.Right, ARX.Direction.Down, ARX.Direction.Left };

            ARX.Shuffle(rand, possibilities);

            //Test all directions
            foreach (ARX.Direction test in possibilities)
            {
                if (test == ARX.Direction.Up && upper(baseSearch) != null)
                {
                    return ARX.Direction.Up;
                }
                else if (test == ARX.Direction.Right && righter(baseSearch) != null)
                {
                    return ARX.Direction.Right;
                }
                else if (test == ARX.Direction.Down && lower(baseSearch) != null)
                {
                    return ARX.Direction.Down;
                }
                else if (test == ARX.Direction.Left && lefter(baseSearch) != null)
                {
                    return ARX.Direction.Left;
                }
            }

            return ARX.Direction.Null;
        } 
    }
}
