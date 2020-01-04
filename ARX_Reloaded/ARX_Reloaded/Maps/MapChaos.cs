using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public class MapChaos : Map
    {
        public MapChaos(Size mapSize, Random mapRandom) : base(mapSize, mapRandom)
        {
        }

        protected override void generatePaths()
        {
            base.generatePaths();

            cases.First().State = ARX.State.Cross;
            cases.Last().State = ARX.State.Point;

            //Choose starting testAround and initialize it
            int currentCase = rand.Next(cases.Count());
            cases[currentCase].State = ARX.State.Point;

            //Search for new testAround until stack is empty
            while (restEmptyState())
            {
                //Determine in which direction the labyrinth is expandable
                ARX.Direction futurDirection = oneRandAdjacent(currentCase);

                //Expand the labyrinth to the up
                if (futurDirection == ARX.Direction.Up)
                {
                    if(Upper(currentCase).State == ARX.State.Right)
                    {
                        Upper(currentCase).State = ARX.State.Cross;
                    }
                    else
                    {
                        Upper(currentCase).State = ARX.State.Down;
                    }

                    currentCase = Upper(currentCase).Coord;
                }

                //Expand the labyrinth to the right
                else if (futurDirection == ARX.Direction.Right)
                {
                    if (Self(currentCase).State == ARX.State.Down)
                    {
                        Self(currentCase).State = ARX.State.Cross;
                    }
                    else
                    {
                        Self(currentCase).State = ARX.State.Right;
                    }

                    if (Righter(currentCase).State == ARX.State.Void)
                    {
                        Righter(currentCase).State = ARX.State.Point;
                    }

                    currentCase = Righter(currentCase).Coord;
                }

                //Expand the labyrinth to the down
                else if (futurDirection == ARX.Direction.Down)
                {
                    if (Self(currentCase).State == ARX.State.Right)
                    {
                        Self(currentCase).State = ARX.State.Cross;
                    }
                    else
                    {
                        Self(currentCase).State = ARX.State.Down;
                    }

                    if(Lower(currentCase).State == ARX.State.Void)
                    {
                        Lower(currentCase).State = ARX.State.Point;
                    }

                    currentCase = Lower(currentCase).Coord;
                }

                //Expand the labyrinth to the left
                else if (futurDirection == ARX.Direction.Left)
                {
                    if(Lefter(currentCase).State == ARX.State.Down)
                    {
                        Lefter(currentCase).State = ARX.State.Cross;
                    }
                    else
                    {
                        Lefter(currentCase).State = ARX.State.Right;
                    }

                    currentCase = Lefter(currentCase).Coord;
                }
            }

            for (int eachTry = 0; eachTry <= 100 && !pathsFinished(); eachTry++)
            {
                if(eachTry == 100)
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
