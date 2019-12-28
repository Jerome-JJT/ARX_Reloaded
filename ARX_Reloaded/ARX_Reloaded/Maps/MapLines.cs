using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public class MapLines : Map
    {
        public MapLines(Size mapSize, Random mapRandom) : base(mapSize, mapRandom)
        {
        }

        public override void GenerateMap(PictureBox elem, Label loading)
        {
            cases = new List<Case>();
            List<List<int>> active = new List<List<int>>
            {
                new List<int>(),//Present
                new List<int>()//Futur
            };

            //Initialize/reset map
            for (int eachCase = 0; eachCase < width * height; eachCase++)
            {
                cases.Add(new Case(eachCase));
            }

            //Choose starting point and initialize it
            active[0].Add(rand.Next(cases.Count()));
            cases[active[0][0]].State = ARX.State.Point;

            //Search for new point until list present is empty
            while (active[0].Count() > 0)
            {
                foreach (int currentActive in active[0])
                {
                    //Determine in which direction the labyrinth is expandable
                    List<ARX.Direction> futurDirection = emptyAdj(currentActive);

                    foreach (ARX.Direction eachDirection in futurDirection)
                    {
                        //Expand the labyrinth to the up
                        if (eachDirection == ARX.Direction.Up && !active[1].Contains(Upper(currentActive).Coord))
                        {
                            if (Upper(currentActive).State == ARX.State.Right)
                            {
                                Upper(currentActive).State = ARX.State.Cross;
                            }
                            else
                            {
                                Upper(currentActive).State = ARX.State.Down;
                            }

                            active[1].Add(Upper(currentActive).Coord);
                        }

                        //Expand the labyrinth to the right
                        else if (eachDirection == ARX.Direction.Right && !active[1].Contains(Righter(currentActive).Coord))
                        {
                            if (Meme(currentActive).State == ARX.State.Down)
                            {
                                Meme(currentActive).State = ARX.State.Cross;
                            }
                            else
                            {
                                Meme(currentActive).State = ARX.State.Right;
                            }

                            if (Righter(currentActive).State == ARX.State.Void)
                            {
                                Righter(currentActive).State = ARX.State.Point;
                            }

                            active[1].Add(Righter(currentActive).Coord);
                        }

                        //Expand the labyrinth to the down
                        else if (eachDirection == ARX.Direction.Down && !active[1].Contains(Lower(currentActive).Coord))
                        {
                            if (Meme(currentActive).State == ARX.State.Right)
                            {
                                Meme(currentActive).State = ARX.State.Cross;
                            }
                            else
                            {
                                Meme(currentActive).State = ARX.State.Down;
                            }

                            if (Lower(currentActive).State == ARX.State.Void)
                            {
                                Lower(currentActive).State = ARX.State.Point;
                            }

                            active[1].Add(Lower(currentActive).Coord);
                        }

                        //Expand the labyrinth to the left
                        else if (eachDirection == ARX.Direction.Left && !active[1].Contains(Lefter(currentActive).Coord))
                        {
                            if (Lefter(currentActive).State == ARX.State.Down)
                            {
                                Lefter(currentActive).State = ARX.State.Cross;
                            }
                            else
                            {
                                Lefter(currentActive).State = ARX.State.Right;
                            }

                            active[1].Add(Lefter(currentActive).Coord);
                        }
                    }
                }

                active[0] = new List<int>(active[1]);
                active[1].Clear();

                if (elem != null)
                {
                    elem.Refresh();
                    System.Threading.Thread.Sleep(1);
                }
            }
        }



        //Search for an empty case around given case
        private List<ARX.Direction> emptyAdj(int baseSearch)
        {
            //Decide in which order directions will be tested
            List<ARX.Direction> possibilities = new List<ARX.Direction> {
                ARX.Direction.Up, ARX.Direction.Right, ARX.Direction.Down, ARX.Direction.Left };

            ARX.Shuffle(rand, possibilities);

            if (!(Upper(baseSearch) != null && Upper(baseSearch).State == ARX.State.Void))
            {
                possibilities.Remove(ARX.Direction.Up);
            }
            if (!(Righter(baseSearch) != null && Righter(baseSearch).State == ARX.State.Void))
            {
                possibilities.Remove(ARX.Direction.Right);
            }
            if (!(Lower(baseSearch) != null && Lower(baseSearch).State == ARX.State.Void))
            {
                possibilities.Remove(ARX.Direction.Down);
            }
            if (!(Lefter(baseSearch) != null && Lefter(baseSearch).State == ARX.State.Void))
            {
                possibilities.Remove(ARX.Direction.Left);
            }

            return possibilities;
        }
    }
}
