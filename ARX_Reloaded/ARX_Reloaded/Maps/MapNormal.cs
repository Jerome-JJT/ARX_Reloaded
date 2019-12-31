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
                    if(Upper(active.First()).State == ARX.State.Right)
                    {
                        Upper(active.First()).State = ARX.State.Cross;
                    }
                    else
                    {
                        Upper(active.First()).State = ARX.State.Down;
                    }
                    
                    active.Push(Upper(active.First()).Coord);
                }

                //Expand the labyrinth to the right
                else if (futurDirection == ARX.Direction.Right)
                {
                    if (Self(active.First()).State == ARX.State.Down)
                    {
                        Self(active.First()).State = ARX.State.Cross;
                    }
                    else
                    {
                        Self(active.First()).State = ARX.State.Right;
                    }

                    if (Righter(active.First()).State == ARX.State.Void)
                    {
                        Righter(active.First()).State = ARX.State.Point;
                    }

                    active.Push(Righter(active.First()).Coord);
                }

                //Expand the labyrinth to the down
                else if (futurDirection == ARX.Direction.Down)
                {
                    if (Self(active.First()).State == ARX.State.Right)
                    {
                        Self(active.First()).State = ARX.State.Cross;
                    }
                    else
                    {
                        Self(active.First()).State = ARX.State.Down;
                    }

                    if (Lower(active.First()).State == ARX.State.Void)
                    {
                        Lower(active.First()).State = ARX.State.Point;
                    }

                    active.Push(Lower(active.First()).Coord);
                }

                //Expand the labyrinth to the left
                else if (futurDirection == ARX.Direction.Left)
                {
                    if (Lefter(active.First()).State == ARX.State.Down)
                    {
                        Lefter(active.First()).State = ARX.State.Cross;
                    }
                    else
                    {
                        Lefter(active.First()).State = ARX.State.Right;
                    }

                    active.Push(Lefter(active.First()).Coord);
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
                if (test == ARX.Direction.Up && Upper(baseSearch) != null && Upper(baseSearch).State == ARX.State.Void)
                {
                    return ARX.Direction.Up;
                }
                else if (test == ARX.Direction.Right && Righter(baseSearch) != null && Righter(baseSearch).State == ARX.State.Void)
                {
                    return ARX.Direction.Right;
                }
                else if (test == ARX.Direction.Down && Lower(baseSearch) != null && Lower(baseSearch).State == ARX.State.Void)
                {
                    return ARX.Direction.Down;
                }
                else if (test == ARX.Direction.Left && Lefter(baseSearch) != null && Lefter(baseSearch).State == ARX.State.Void)
                {
                    return ARX.Direction.Left;
                }
            }    
            
            return ARX.Direction.Null;
        }
    }
}
