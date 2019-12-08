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
        public int mapWidth;
        public int mapHeight;

        public List<Case> Cases = new List<Case>();
        private Stack<int> active = new Stack<int>();

        Random rand = new Random();


        public Map(int width, int height)
        {
            mapWidth = width;
            mapHeight = height;

            for (int i = 0; i < mapWidth * mapHeight; i++)
            {
                Cases.Add(new Case());
            }
        }

        public void GenerateMap(PictureBox pic)
        {
            

            active.Push(rand.Next(Cases.Count()));
            Cases[active.Last()].value = 1;


            while (active.Count() > 0)
            {
                int futurDirection = emptyAdj(active.First());


                if (futurDirection == -1)
                {
                    active.Pop();
                }

                else if (futurDirection == 0)
                {
                    Cases[active.First() - mapHeight].value = 3;
                    active.Push(active.First() - mapHeight);
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

                    Cases[active.First() + mapHeight].value = 1;
                    active.Push(active.First() + mapHeight);
                }

                else if (futurDirection == 270)
                {
                    Cases[active.First() - 1].value = 2;
                    active.Push(active.First() - 1);
                }

                //pic.Refresh();
            }
        }


        private void Shuffle<T>(IList<T> list)
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


        private int emptyAdj(int baseSearch)
        {
            List<int> possibilities = new List<int> { 0, 90, 180, 270 };

            Shuffle(possibilities);

            foreach (int test in possibilities)
            {
                if (test == 0 && baseSearch >= mapWidth && Cases[baseSearch - mapWidth].value == 0)
                {
                    return 0;
                }
                else if (test == 90 && baseSearch % mapHeight < mapHeight-1 && Cases[baseSearch + 1].value == 0)
                {
                    return 90;
                }
                else if (test == 180 && baseSearch < mapHeight*mapWidth-mapWidth && Cases[baseSearch + mapWidth].value == 0)
                {
                    return 180;
                }
                else if (test == 270 && baseSearch % mapHeight > 0 && Cases[baseSearch - 1].value == 0)
                {
                    return 270;
                }
            }    
            
            return -1;
        }


    }
}
