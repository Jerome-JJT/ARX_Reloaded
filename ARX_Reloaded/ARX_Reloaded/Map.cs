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
        /*List<int> oldMap = new List<int>
        {
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,2,2,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        };*/

        int mapWidth = 5;
        int mapHeight = 5;

        public List<Case> Cases = new List<Case>();
        private Stack<int> active = new Stack<int>();

        public Map()
        {
            for (int i = 0; i < mapWidth * mapHeight; i++)
            {
                Cases.Add(new Case());
            }
        }

        public void GenerateMap(PictureBox pic)
        {
            Random rand = new Random();

            active.Push(rand.Next(Cases.Count()));
            //active.Push(12);

            Cases[active.Last()].value = 1;




            Console.WriteLine($"Start {active.Last()}");




            while (active.Count() > 0)
            {
                int futurDirection = emptyAdj(active.First());
                //int futurDirection = 0;


                Console.WriteLine($"Go from {active.First()}");
                Console.WriteLine($"Go to {futurDirection}");

                if (futurDirection == -1)
                {
                    active.Pop();
                }

                else if (futurDirection == 0)
                {
                    Cases[active.First() - 5].value = 3;
                    active.Push(active.First() - 5);
                }

                else if (futurDirection == 90)
                {
                    if (Cases[active.First()].value == 3)
                    {
                        Cases[active.First()].value = 4;
                    }
                    else
                    {
                        Cases[active.First()].value = 2;
                    }

                    Cases[active.First() + 1].value = 1;
                    active.Push(active.First() + 1);
                }

                else if (futurDirection == 180)
                {
                    if (Cases[active.First()].value == 2)
                    {
                        Cases[active.First()].value = 4;
                    }
                    else
                    {
                        Cases[active.First()].value = 3;
                    }

                    Cases[active.First() + 5].value = 1;
                    active.Push(active.First() + 5);
                }

                else if (futurDirection == 270)
                {
                    Cases[active.First() - 1].value = 2;
                    active.Push(active.First() - 1);
                }

                pic.Refresh();
                foreach (var one in active)
                {
                    Console.Write($"{one} ");
                }
                Console.WriteLine("hh");
                System.Threading.Thread.Sleep(1);
            }
        }

        /*public void Shuffle<T>(this Stack<T> stack)
        {
            Random rnd = new Random();
            var values = stack.ToArray();
            stack.Clear();
            foreach (var value in values.OrderBy(x => rnd.Next()))
                stack.Push(value);

        }*/


        private void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        private int emptyAdj(int baseSearch)
        {
            List<int> possibilities = new List<int> { 0, 90, 180, 270 };

            Shuffle(possibilities);

            foreach (int test in possibilities)
            {
                if (test == 0 && baseSearch >= 5 && Cases[baseSearch - mapWidth].value == 0)
                {
                    return 0;
                }
                else if (test == 90 && baseSearch % 5 < 4 && Cases[baseSearch + 1].value == 0)
                {
                    return 90;
                }
                else if (test == 180 && baseSearch < 24-5 && Cases[baseSearch + mapWidth].value == 0)
                {
                    return 180;
                }
                else if (test == 270 && baseSearch % 5 > 0 && Cases[baseSearch - 1].value == 0)
                {
                    return 270;
                }
                Console.WriteLine($"Cant go to {test}");
            }    
            
            return -1;
        }


    }
}
