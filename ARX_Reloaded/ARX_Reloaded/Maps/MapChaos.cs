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

        public override void GenerateMap(PictureBox elem, Label loading)
        {
            base.GenerateMap(elem, loading);

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
                    if(upper(currentCase).State == ARX.State.Right)
                    {
                        upper(currentCase).State = ARX.State.Cross;
                    }
                    else
                    {
                        upper(currentCase).State = ARX.State.Down;
                    }

                    currentCase = upper(currentCase).Coord;
                }

                //Expand the labyrinth to the right
                else if (futurDirection == ARX.Direction.Right)
                {
                    if (self(currentCase).State == ARX.State.Down)
                    {
                        self(currentCase).State = ARX.State.Cross;
                    }
                    else
                    {
                        self(currentCase).State = ARX.State.Right;
                    }

                    if (righter(currentCase).State == ARX.State.Void)
                    {
                        righter(currentCase).State = ARX.State.Point;
                    }

                    currentCase = righter(currentCase).Coord;
                }

                //Expand the labyrinth to the down
                else if (futurDirection == ARX.Direction.Down)
                {
                    if (self(currentCase).State == ARX.State.Right)
                    {
                        self(currentCase).State = ARX.State.Cross;
                    }
                    else
                    {
                        self(currentCase).State = ARX.State.Down;
                    }

                    if(lower(currentCase).State == ARX.State.Void)
                    {
                        lower(currentCase).State = ARX.State.Point;
                    }

                    currentCase = lower(currentCase).Coord;
                }

                //Expand the labyrinth to the left
                else if (futurDirection == ARX.Direction.Left)
                {
                    if(lefter(currentCase).State == ARX.State.Down)
                    {
                        lefter(currentCase).State = ARX.State.Cross;
                    }
                    else
                    {
                        lefter(currentCase).State = ARX.State.Right;
                    }

                    currentCase = lefter(currentCase).Coord;
                }
            }

            for (int eachTry = 0; eachTry <= 100 && !pathsFinished(); eachTry++)
            {
                if(eachTry == 100)
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
