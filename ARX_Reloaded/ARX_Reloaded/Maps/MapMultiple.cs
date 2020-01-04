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

        protected override void generatePaths()
        {
            base.generatePaths();

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
                        if (eachDirection == ARX.Direction.Up && !points[1].Contains(Upper(currentActive).Coord))
                        {
                            if (Upper(currentActive).State == ARX.State.Right)
                            {
                                Upper(currentActive).State = ARX.State.Cross;
                            }
                            else
                            {
                                Upper(currentActive).State = ARX.State.Down;
                            }

                            points[1].Add(Upper(currentActive).Coord);
                        }

                        //Expand the labyrinth to the right
                        else if (eachDirection == ARX.Direction.Right && !points[1].Contains(Righter(currentActive).Coord))
                        {
                            if (Self(currentActive).State == ARX.State.Down)
                            {
                                Self(currentActive).State = ARX.State.Cross;
                            }
                            else
                            {
                                Self(currentActive).State = ARX.State.Right;
                            }

                            if (Righter(currentActive).State == ARX.State.Void)
                            {
                                Righter(currentActive).State = ARX.State.Point;
                            }

                            points[1].Add(Righter(currentActive).Coord);
                        }

                        //Expand the labyrinth to the down
                        else if (eachDirection == ARX.Direction.Down && !points[1].Contains(Lower(currentActive).Coord))
                        {
                            if (Self(currentActive).State == ARX.State.Right)
                            {
                                Self(currentActive).State = ARX.State.Cross;
                            }
                            else
                            {
                                Self(currentActive).State = ARX.State.Down;
                            }

                            if (Lower(currentActive).State == ARX.State.Void)
                            {
                                Lower(currentActive).State = ARX.State.Point;
                            }

                            points[1].Add(Lower(currentActive).Coord);
                        }

                        //Expand the labyrinth to the left
                        else if (eachDirection == ARX.Direction.Left && !points[1].Contains(Lefter(currentActive).Coord))
                        {
                            if (Lefter(currentActive).State == ARX.State.Down)
                            {
                                Lefter(currentActive).State = ARX.State.Cross;
                            }
                            else
                            {
                                Lefter(currentActive).State = ARX.State.Right;
                            }

                            points[1].Add(Lefter(currentActive).Coord);
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
                    generatePaths();
                }
            }
        }

        //Search for an empty case around given case
        private List<ARX.Direction> someRandAdjacent(int baseSearch)
        {
            //Decide in which order directions will be tested
            List<ARX.Direction> possibilities = new List<ARX.Direction> {
                ARX.Direction.Up, ARX.Direction.Right, ARX.Direction.Down, ARX.Direction.Left };

            if (!(Upper(baseSearch) != null))
            {
                possibilities.Remove(ARX.Direction.Up);
            }
            if (!(Righter(baseSearch) != null))
            {
                possibilities.Remove(ARX.Direction.Right);
            }
            if (!(Lower(baseSearch) != null))
            {
                possibilities.Remove(ARX.Direction.Down);
            }
            if (!(Lefter(baseSearch) != null))
            {
                possibilities.Remove(ARX.Direction.Left);
            }

            ARX.Shuffle(rand, possibilities);

            possibilities.RemoveRange(0, (int)Math.Ceiling(possibilities.Count/2.0));

            return possibilities;
        }
    }
}
