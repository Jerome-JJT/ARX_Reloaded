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

        protected override void generatePaths()
        {
            base.generatePaths();

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
                        if (Upper(currentPoints[currentPoint]).State == ARX.State.Right)
                        {
                            Upper(currentPoints[currentPoint]).State = ARX.State.Cross;
                        }
                        else
                        {
                            Upper(currentPoints[currentPoint]).State = ARX.State.Down;
                        }

                        currentPoints[currentPoint] = Upper(currentPoints[currentPoint]).Coord;
                    }

                    //Expand the labyrinth to the right
                    else if (futurDirection == ARX.Direction.Right)
                    {
                        if (Self(currentPoints[currentPoint]).State == ARX.State.Down)
                        {
                            Self(currentPoints[currentPoint]).State = ARX.State.Cross;
                        }
                        else
                        {
                            Self(currentPoints[currentPoint]).State = ARX.State.Right;
                        }

                        if (Righter(currentPoints[currentPoint]).State == ARX.State.Void)
                        {
                            Righter(currentPoints[currentPoint]).State = ARX.State.Point;
                        }

                        currentPoints[currentPoint] = Righter(currentPoints[currentPoint]).Coord;
                    }

                    //Expand the labyrinth to the down
                    else if (futurDirection == ARX.Direction.Down)
                    {
                        if (Self(currentPoints[currentPoint]).State == ARX.State.Right)
                        {
                            Self(currentPoints[currentPoint]).State = ARX.State.Cross;
                        }
                        else
                        {
                            Self(currentPoints[currentPoint]).State = ARX.State.Down;
                        }

                        if (Lower(currentPoints[currentPoint]).State == ARX.State.Void)
                        {
                            Lower(currentPoints[currentPoint]).State = ARX.State.Point;
                        }

                        currentPoints[currentPoint] = Lower(currentPoints[currentPoint]).Coord;
                    }

                    //Expand the labyrinth to the left
                    else if (futurDirection == ARX.Direction.Left)
                    {
                        if (Lefter(currentPoints[currentPoint]).State == ARX.State.Down)
                        {
                            Lefter(currentPoints[currentPoint]).State = ARX.State.Cross;
                        }
                        else
                        {
                            Lefter(currentPoints[currentPoint]).State = ARX.State.Right;
                        }

                        currentPoints[currentPoint] = Lefter(currentPoints[currentPoint]).Coord;
                    }
                }
            }

            for (int eachTry = 0; eachTry <= 100 && !pathsFinished(); eachTry++)
            {
                if (eachTry == 100)
                {
                    generatePaths();
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
                if (test == ARX.Direction.Up && Upper(baseSearch) != null)
                {
                    return ARX.Direction.Up;
                }
                else if (test == ARX.Direction.Right && Righter(baseSearch) != null)
                {
                    return ARX.Direction.Right;
                }
                else if (test == ARX.Direction.Down && Lower(baseSearch) != null)
                {
                    return ARX.Direction.Down;
                }
                else if (test == ARX.Direction.Left && Lefter(baseSearch) != null)
                {
                    return ARX.Direction.Left;
                }
            }

            return ARX.Direction.Null;
        } 
    }
}
