using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public class MapMultiple : Map
    {
        public MapMultiple(Size mapSize, Random mapRandom) : base(mapSize, mapRandom)
        {
        }

        public override void GenerateMap(PictureBox elem, Label loading)
        {
            base.GenerateMap(elem, loading);

            List<List<int>> points = new List<List<int>>
            {
                new List<int>(),//Actuals
                new List<int>()//Futurs
            };

            //Choose starting point and initialize it
            points[0].Add(rand.Next(cases.Count()));
            cases[points[0][0]].State = ARX.State.Point;

            //Search for new point until list present is empty
            while (restEmptyState())
            {
                ARX.Shuffle(rand, points[0]);

                foreach (int currentActive in points[0])
                {
                    //Determine in which direction the labyrinth is expandable
                    List<ARX.Direction> futurDirection = someRandAdjacent(currentActive);

                    foreach (ARX.Direction eachDirection in futurDirection)
                    {
                        //Expand the labyrinth to the up
                        if (eachDirection == ARX.Direction.Up && !points[1].Contains(upper(currentActive).Coord))
                        {
                            if (upper(currentActive).State == ARX.State.Right)
                            {
                                upper(currentActive).State = ARX.State.Cross;
                            }
                            else
                            {
                                upper(currentActive).State = ARX.State.Down;
                            }

                            points[1].Add(upper(currentActive).Coord);
                        }

                        //Expand the labyrinth to the right
                        else if (eachDirection == ARX.Direction.Right && !points[1].Contains(righter(currentActive).Coord))
                        {
                            if (self(currentActive).State == ARX.State.Down)
                            {
                                self(currentActive).State = ARX.State.Cross;
                            }
                            else
                            {
                                self(currentActive).State = ARX.State.Right;
                            }

                            if (righter(currentActive).State == ARX.State.Void)
                            {
                                righter(currentActive).State = ARX.State.Point;
                            }

                            points[1].Add(righter(currentActive).Coord);
                        }

                        //Expand the labyrinth to the down
                        else if (eachDirection == ARX.Direction.Down && !points[1].Contains(lower(currentActive).Coord))
                        {
                            if (self(currentActive).State == ARX.State.Right)
                            {
                                self(currentActive).State = ARX.State.Cross;
                            }
                            else
                            {
                                self(currentActive).State = ARX.State.Down;
                            }

                            if (lower(currentActive).State == ARX.State.Void)
                            {
                                lower(currentActive).State = ARX.State.Point;
                            }

                            points[1].Add(lower(currentActive).Coord);
                        }

                        //Expand the labyrinth to the left
                        else if (eachDirection == ARX.Direction.Left && !points[1].Contains(lefter(currentActive).Coord))
                        {
                            if (lefter(currentActive).State == ARX.State.Down)
                            {
                                lefter(currentActive).State = ARX.State.Cross;
                            }
                            else
                            {
                                lefter(currentActive).State = ARX.State.Right;
                            }

                            points[1].Add(lefter(currentActive).Coord);
                        }
                    }
                }

                points[0] = new List<int>(points[1]);
                points[1].Clear();
            }

            for (int eachTry = 0; eachTry <= 100 && !pathsFinished(); eachTry++)
            {
                if (eachTry == 100)
                {
                    GenerateMap(elem, loading);
                }
            }
        }

        //Search for an empty case around given case
        private List<ARX.Direction> someRandAdjacent(int baseSearch)
        {
            //Decide in which order directions will be tested
            List<ARX.Direction> possibilities = new List<ARX.Direction> {
                ARX.Direction.Up, ARX.Direction.Right, ARX.Direction.Down, ARX.Direction.Left };

            if (!(upper(baseSearch) != null))
            {
                possibilities.Remove(ARX.Direction.Up);
            }
            if (!(righter(baseSearch) != null))
            {
                possibilities.Remove(ARX.Direction.Right);
            }
            if (!(lower(baseSearch) != null))
            {
                possibilities.Remove(ARX.Direction.Down);
            }
            if (!(lefter(baseSearch) != null))
            {
                possibilities.Remove(ARX.Direction.Left);
            }

            ARX.Shuffle(rand, possibilities);

            possibilities.RemoveRange(0, (int)Math.Ceiling(possibilities.Count/2.0));

            return possibilities;
        }
    }
}
