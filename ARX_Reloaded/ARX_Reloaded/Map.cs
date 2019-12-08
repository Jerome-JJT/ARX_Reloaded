using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public class Map
    {
        private int width;
        private int height;

        private List<Case> cases;
        private Stack<int> active;

        private Random rand;


        public Map(int mapWidth, int mapHeight)
        {
            width = mapWidth;
            height = mapHeight;

            cases = new List<Case>();
            active = new Stack<int>();
            rand = new Random();

            //Initialize map
            for (int eachCase = 0; eachCase < width * height; eachCase++)
            {
                cases.Add(new Case());
            }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public List<Case> Cases
        {
            get { return cases; }
        }


        public void GenerateMap(PictureBox pic)
        {
            cases = new List<Case>();
            active = new Stack<int>();
            rand = new Random();

            //Initialize/reset map
            for (int eachCase = 0; eachCase < width * height; eachCase++)
            {
                cases.Add(new Case());
            }

            //Choose starting point and initialize it
            active.Push(rand.Next(cases.Count()));
            cases[active.Last()].State = 1;

            //Search for new point until stack is empty
            while (active.Count() > 0)
            {
                //Determine in which direction the labyrinth is expandable
                int futurDirection = emptyAdj(active.First());

                //If there isn't anywhere to go, free one space from the stack
                if (futurDirection == -1)
                {
                    active.Pop();
                }

                //Expand the labyrinth to the up
                else if (futurDirection == 0)
                {
                    if(cases[active.First() - width].State == 2)
                    {
                        cases[active.First() - width].State = 4;
                    }
                    else
                    {
                        cases[active.First() - width].State = 3;
                    }
                    
                    active.Push(active.First() - width);
                }

                //Expand the labyrinth to the right
                else if (futurDirection == 90)
                {
                    if (cases[active.First()].State == 3)
                    {
                        cases[active.First()].State = 4;
                    }
                    else
                    {
                        cases[active.First()].State = 2;
                    }

                    cases[active.First() + 1].State = 1;
                    active.Push(active.First() + 1);
                }

                //Expand the labyrinth to the down
                else if (futurDirection == 180)
                {
                    if (cases[active.First()].State == 2)
                    {
                        cases[active.First()].State = 4;
                    }
                    else
                    {
                        cases[active.First()].State = 3;
                    }

                    cases[active.First() + width].State = 1;
                    active.Push(active.First() + width);
                }

                //Expand the labyrinth to the left
                else if (futurDirection == 270)
                {
                    if(cases[active.First() - 1].State == 3)
                        {
                        cases[active.First() - 1].State = 4;
                    }
                    else
                    {
                        cases[active.First() - 1].State = 2;
                    }

                    active.Push(active.First() - 1);
                }

                //pic.Refresh();
            }
        }

        //Shuffle a list
        private void shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        //Search for an empty case around given case
        private int emptyAdj(int baseSearch)
        {
            //Decide in which order directions will be tested
            List<int> possibilities = new List<int> { 0, 90, 180, 270 };
            shuffle(possibilities);

            //Test all directions
            foreach (int test in possibilities)
            {
                if (test == 0 && baseSearch >= width && cases[baseSearch - width].State == 0)
                {
                    return 0;
                }
                else if (test == 90 && baseSearch % width < width - 1 && cases[baseSearch + 1].State == 0)
                {
                    return 90;
                }
                else if (test == 180 && baseSearch < height*width-width && cases[baseSearch + width].State == 0)
                {
                    return 180;
                }
                else if (test == 270 && baseSearch % width > 0 && cases[baseSearch - 1].State == 0)
                {
                    return 270;
                }
            }    
            
            return -1;
        }


    }
}
