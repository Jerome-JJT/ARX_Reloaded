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
            cases = new List<Case>();
            List<List<int>> active = new List<List<int>>
            {
                new List<int>(),//Present
                new List<int>()//Futur
            };

            //Initialize/reset map
            for (int eachCase = 0; eachCase < width * height; eachCase++)
            {
                cases.Add(new Case(eachCase % width, (int)(eachCase / height)));
            }

            //Choose starting point and initialize it
            active[0].Add(rand.Next(cases.Count()));
            cases[active[0][0]].State = 1;

            //Search for new point until list present is empty
            //while (active[0].Count() > 0)
            while (restEmptyState())
            {
                Calculus.Shuffle(rand, active[0]);

                foreach (int testActive in active[0])
                {
                    //Determine in which direction the labyrinth is expandable
                    List<int> futurDirection = emptyAdj(testActive);

                    foreach (int eachDirection in futurDirection)
                    {
                        //Expand the labyrinth to the up
                        if (eachDirection == 0 && !active[1].Contains(testActive - width))
                        {
                            if (cases[testActive - width].State == 2)
                            {
                                cases[testActive - width].State = 4;
                            }
                            else
                            {
                                cases[testActive - width].State = 3;
                            }

                            active[1].Add(testActive - width);
                        }

                        //Expand the labyrinth to the right
                        else if (eachDirection == 90 && !active[1].Contains(testActive + 1))
                        {
                            if (cases[testActive].State == 3)
                            {
                                cases[testActive].State = 4;
                            }
                            else
                            {
                                cases[testActive].State = 2;
                            }

                            if (cases[testActive + 1].State == 0)
                            {
                                cases[testActive + 1].State = 1;
                            }

                            active[1].Add(testActive + 1);
                        }

                        //Expand the labyrinth to the down
                        else if (eachDirection == 180 && !active[1].Contains(testActive + width))
                        {
                            if (cases[testActive].State == 2)
                            {
                                cases[testActive].State = 4;
                            }
                            else
                            {
                                cases[testActive].State = 3;
                            }

                            if (cases[testActive + width].State == 0)
                            {
                                cases[testActive + width].State = 1;
                            }

                            active[1].Add(testActive + width);
                        }

                        //Expand the labyrinth to the left
                        else if (eachDirection == 270 && !active[1].Contains(testActive - 1))
                        {
                            if (cases[testActive - 1].State == 3)
                            {
                                cases[testActive - 1].State = 4;
                            }
                            else
                            {
                                cases[testActive - 1].State = 2;
                            }

                            active[1].Add(testActive - 1);
                        }
                    }
                }

                active[0] = new List<int>(active[1]);
                active[1].Clear();

                if (elem != null)
                {
                    elem.Refresh();
                    System.Threading.Thread.Sleep(2);
                }
            }

            while (!pathsFinished()) {
                if (elem != null)
                {
                    elem.Refresh();
                    System.Threading.Thread.Sleep(2);
                }
            }
        }


        private bool restEmptyState()
        {
            return !cases.TrueForAll(eachCase => eachCase.State != 0);
        }

        //Search for an empty case around given case
        private List<int> emptyAdj(int baseSearch)
        {
            //Decide in which order directions will be tested
            List<int> possibilities = new List<int> { 0, 90, 180, 270 };

            if (!(baseSearch >= width))
            {
                possibilities.Remove(0);
            }
            if (!(baseSearch % width < width - 1))
            {
                possibilities.Remove(90);
            }
            if (!(baseSearch < height * width - width))
            {
                possibilities.Remove(180);
            }
            if (!(baseSearch % width > 0))
            {
                possibilities.Remove(270);
            }

            Calculus.Shuffle(rand, possibilities);

            possibilities.RemoveRange(0, (int)Math.Ceiling(possibilities.Count/2.0));

            return possibilities;
        }
    }
}
