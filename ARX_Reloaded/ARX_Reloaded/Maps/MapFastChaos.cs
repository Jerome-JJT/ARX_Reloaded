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
        private int fastPaths;

        public MapFastChaos(int fastPaths, Size mapSize, Random mapRandom) : base(mapSize, mapRandom)
        {
            this.fastPaths = fastPaths;
        }

        public override void GenerateMap(PictureBox elem, Label loading)
        {
            cases = new List<Case>();

            //Initialize/reset map
            for (int eachCase = 0; eachCase < width * height; eachCase++)
            {
                cases.Add(new Case(eachCase % width, (int)(eachCase / height)));
            }

            cases[0].State = 4;
            cases[cases.Count() - 1].State = 1;

            List<int> lastCases = new List<int>();

            //Choose starting points and initialize them
            for (int i = 0; i < fastPaths; i++)
            {
                int newCoord;
                do
                {
                    newCoord = rand.Next(cases.Count());
                }
                while (lastCases.Contains(newCoord));

                cases[newCoord].State = 1;
                lastCases.Add(newCoord);
            }

            //Search for new testAround until stack is empty
            while (emptyCase())
            {
                for (int i = 0; i < lastCases.Count; i++)
                {
                    //Determine in which direction the labyrinth is expandable
                    int futurDirection = emptyAdj(lastCases[i]);

                    //Expand the labyrinth to the up
                    if (futurDirection == 0)
                    {
                        if (cases[lastCases[i] - width].State == 2)
                        {
                            cases[lastCases[i] - width].State = 4;
                        }
                        else
                        {
                            cases[lastCases[i] - width].State = 3;
                        }

                        lastCases[i] = lastCases[i] - width;
                    }

                    //Expand the labyrinth to the right
                    else if (futurDirection == 90)
                    {
                        if (cases[lastCases[i]].State == 3)
                        {
                            cases[lastCases[i]].State = 4;
                        }
                        else
                        {
                            cases[lastCases[i]].State = 2;
                        }

                        if (cases[lastCases[i] + 1].State == 0)
                        {
                            cases[lastCases[i] + 1].State = 1;
                        }

                        lastCases[i] = lastCases[i] + 1;
                    }

                    //Expand the labyrinth to the down
                    else if (futurDirection == 180)
                    {
                        if (cases[lastCases[i]].State == 2)
                        {
                            cases[lastCases[i]].State = 4;
                        }
                        else
                        {
                            cases[lastCases[i]].State = 3;
                        }

                        if (cases[lastCases[i] + width].State == 0)
                        {
                            cases[lastCases[i] + width].State = 1;
                        }

                        lastCases[i] = lastCases[i] + width;
                    }

                    //Expand the labyrinth to the left
                    else if (futurDirection == 270)
                    {
                        if (cases[lastCases[i] - 1].State == 3)
                        {
                            cases[lastCases[i] - 1].State = 4;
                        }
                        else
                        {
                            cases[lastCases[i] - 1].State = 2;
                        }

                        lastCases[i] = lastCases[i] - 1;
                    }
                }
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
                else if (test == 180 && baseSearch < height * width - width)
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

        
    }
}
