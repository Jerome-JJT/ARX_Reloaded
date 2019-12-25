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
        int lastCase;

        public MapChaos(Size mapSize, Random mapRandom) : base(mapSize, mapRandom)
        {
        }

        public override void GenerateMap(PictureBox elem, Label loading)
        {
            cases = new List<Case>();
            
            //Initialize/reset map
            for (int eachCase = 0; eachCase < width * height; eachCase++)
            {
                cases.Add(new Case(0));
            }

            cases[0].State = 4;
            cases[cases.Count()-1].State = 1;

            //Choose starting testAround and initialize it
            lastCase = rand.Next(cases.Count());
            cases[lastCase].State = 1;

            //Search for new testAround until stack is empty
            //for(int iteration = 0; iteration < 100000; iteration++)
            while(emptyCase())
            {
                //Determine in which direction the labyrinth is expandable
                int futurDirection = emptyAdj(lastCase);

                //Expand the labyrinth to the up
                if (futurDirection == 0)
                {
                    if(cases[lastCase - width].State == 2)
                    {
                        cases[lastCase - width].State = 4;
                    }
                    else
                    {
                        cases[lastCase - width].State = 3;
                    }

                    lastCase = lastCase - width;
                }

                //Expand the labyrinth to the right
                else if (futurDirection == 90)
                {
                    if (cases[lastCase].State == 3)
                    {
                        cases[lastCase].State = 4;
                    }
                    else
                    {
                        cases[lastCase].State = 2;
                    }

                    if (cases[lastCase + 1].State == 0)
                    {
                        cases[lastCase + 1].State = 1;
                    }

                    lastCase = lastCase + 1;
                }

                //Expand the labyrinth to the down
                else if (futurDirection == 180)
                {
                    if (cases[lastCase].State == 2)
                    {
                        cases[lastCase].State = 4;
                    }
                    else
                    {
                        cases[lastCase].State = 3;
                    }

                    if(cases[lastCase + width].State == 0)
                    {
                        cases[lastCase + width].State = 1;
                    }

                    lastCase = lastCase + width;
                }

                //Expand the labyrinth to the left
                else if (futurDirection == 270)
                {
                    if(cases[lastCase - 1].State == 3)
                    {
                        cases[lastCase - 1].State = 4;
                    }
                    else
                    {
                        cases[lastCase - 1].State = 2;
                    }

                    lastCase = lastCase - 1;
                }

                //elem.Refresh();
                //loading.Text = $"Iteration : {iteration}";
                //loading.Refresh();
                //System.Threading.Thread.Sleep(1);
            }

            while (!pathsFinished()) { }
        }

        //Search for an empty case around given case
        private int emptyAdj(int baseSearch)
        {
            //Decide in which order directions will be tested
            List<int> possibilities = new List<int> { 0, 90, 180, 270 };
            Calculus.Shuffle(rand, possibilities);

            //Test all directions
            foreach (int test in possibilities)
            {
                if (test == 0 && baseSearch >= width)
                {
                    return 0;
                }
                else if (test == 90 && baseSearch % width < width - 1)
                {
                    return 90;
                }
                else if (test == 180 && baseSearch < height*width-width)
                {
                    return 180;
                }
                else if (test == 270 && baseSearch % width > 0)
                {
                    return 270;
                }
            }
            return -1;
        }

        private bool emptyCase()
        {
            for (int i = 0; i < cases.Count; i++)
            {
                if (cases[i].State == 0)
                {
                    return true;
                }
                else if (cases[i].State == 1 &&
                    ((i >= width && cases[i - width].State != 3 && cases[i - width].State != 4) &&
                    (i % width > 0 && cases[i - 1].State != 2 && cases[i - 1].State != 4)))
                {
                    return true;
                }
            }
            return false;
        }

        private bool pathsFinished()
        {
            List<List<int>> visits = new List<List<int>>();
            List<int> unique = new List<int> { 0 };

            visits.Add(new List<int>());//Present
            visits.Add(new List<int>());//Futur

            visits[0].Add(0);

            do
            {
                foreach (int testAround in visits[0])
                {
                    if (testAround > width - 1 && (!visits[1].Contains(testAround - width)) && (!unique.Contains(testAround - width))
                        && (cases[testAround - width].State == 3 || cases[testAround - width].State == 4))
                    {
                        visits[1].Add(testAround - width);
                    }

                    if (testAround % width < width - 1 && (!visits[1].Contains(testAround + 1)) && (!unique.Contains(testAround + 1))
                        && (cases[testAround].State == 2 || cases[testAround].State == 4))
                    {
                        visits[1].Add(testAround + 1);
                    }

                    if (testAround < height * width - width && (!visits[1].Contains(testAround + width)) && (!unique.Contains(testAround + width))
                        && (cases[testAround].State == 3 || cases[testAround].State == 4))
                    {
                        visits[1].Add(testAround + width);
                    }

                    if (testAround % width > 0 && (!visits[1].Contains(testAround - 1)) && (!unique.Contains(testAround - 1))
                        && (cases[testAround - 1].State == 2 || cases[testAround - 1].State == 4))
                    {
                        visits[1].Add(testAround - 1);
                    }
                }

                unique.AddRange(new List<int>(visits[1]));
                visits[0] = new List<int>(visits[1]);
                visits[1].Clear();

            } while (visits[0].Count > 0);

            if (unique.Count != width * height)
            {
                for (int i = 0; i < width * height; i++)
                {
                    if (!unique.Contains(i))
                    {
                        if (i % width == width - 1)
                        {
                            cases[i - 1].State = (cases[i - 1].State % 4) + 1;
                        }
                        else if (i > (height * width) - width - 1)
                        {
                            cases[i - width].State = (cases[i - width].State % 4) + 1;
                        }
                        else
                        {
                            cases[i].State = (cases[i].State % 4) + 1;
                        }
                    }
                }
                return false;
            }
            return true;
        }
    }
}
