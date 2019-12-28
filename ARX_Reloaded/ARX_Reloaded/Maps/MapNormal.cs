using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public class MapNormal : Map
    {
        public MapNormal(Size mapSize, Random mapRandom) : base(mapSize, mapRandom)
        {
        }

        public override void GenerateMap(PictureBox elem, Label loading)
        {
            base.GenerateMap(elem, loading);

            Stack<int> active = new Stack<int>();

            //Choose starting point and initialize it
            active.Push(rand.Next(cases.Count()));
            cases[active.Last()].State = ARX.State.Point;

            //Search for new point until stack is empty
            while (active.Count() > 0)
            {
                //Determine in which direction the labyrinth is expandable
                ARX.Direction futurDirection = oneRandEmpty(active.First());

                //If there isn't anywhere to go, free one space from the stack
                if (futurDirection == ARX.Direction.Null)
                {
                    active.Pop();
                }

                //Expand the labyrinth to the up
                else if (futurDirection == ARX.Direction.Up)
                {
                    if(upper(active.First()).State == ARX.State.Right)
                    {
                        upper(active.First()).State = ARX.State.Cross;
                    }
                    else
                    {
                        upper(active.First()).State = ARX.State.Down;
                    }
                    
                    active.Push(upper(active.First()).Coord);
                }

                //Expand the labyrinth to the right
                else if (futurDirection == ARX.Direction.Right)
                {
                    if (self(active.First()).State == ARX.State.Down)
                    {
                        self(active.First()).State = ARX.State.Cross;
                    }
                    else
                    {
                        self(active.First()).State = ARX.State.Right;
                    }

                    if (righter(active.First()).State == ARX.State.Void)
                    {
                        righter(active.First()).State = ARX.State.Point;
                    }

                    active.Push(righter(active.First()).Coord);
                }

                //Expand the labyrinth to the down
                else if (futurDirection == ARX.Direction.Down)
                {
                    if (self(active.First()).State == ARX.State.Right)
                    {
                        self(active.First()).State = ARX.State.Cross;
                    }
                    else
                    {
                        self(active.First()).State = ARX.State.Down;
                    }

                    if (lower(active.First()).State == ARX.State.Void)
                    {
                        lower(active.First()).State = ARX.State.Point;
                    }

                    active.Push(lower(active.First()).Coord);
                }

                //Expand the labyrinth to the left
                else if (futurDirection == ARX.Direction.Left)
                {
                    if (lefter(active.First()).State == ARX.State.Down)
                    {
                        lefter(active.First()).State = ARX.State.Cross;
                    }
                    else
                    {
                        lefter(active.First()).State = ARX.State.Right;
                    }

                    active.Push(lefter(active.First()).Coord);
                }
            }
        }

        //Search for an empty case around given case
        private ARX.Direction oneRandEmpty(int baseSearch)
        {
            //Decide in which order directions will be tested
            List<ARX.Direction> possibilities = new List<ARX.Direction> {
                ARX.Direction.Up, ARX.Direction.Right, ARX.Direction.Down, ARX.Direction.Left };

            ARX.Shuffle(rand, possibilities);

            //Test all directions
            foreach (ARX.Direction test in possibilities)
            {
                if (test == ARX.Direction.Up && upper(baseSearch) != null && upper(baseSearch).State == ARX.State.Void)
                {
                    return ARX.Direction.Up;
                }
                else if (test == ARX.Direction.Right && righter(baseSearch) != null && righter(baseSearch).State == ARX.State.Void)
                {
                    return ARX.Direction.Right;
                }
                else if (test == ARX.Direction.Down && lower(baseSearch) != null && lower(baseSearch).State == ARX.State.Void)
                {
                    return ARX.Direction.Down;
                }
                else if (test == ARX.Direction.Left && lefter(baseSearch) != null && lefter(baseSearch).State == ARX.State.Void)
                {
                    return ARX.Direction.Left;
                }
            }    
            
            return ARX.Direction.Null;
        }


    }
}
