using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public abstract class Map
    {
        protected int width;
        protected int height;

        protected List<Case> cases;
        protected Stack<int> active;

        protected Random rand;

        public Map(Size mapSize)
        {
            width = mapSize.Width;
            height = mapSize.Height;

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

        public abstract void GenerateMap(PictureBox elem, Label loading);

        //Shuffle a list
        protected void shuffle<T>(IList<T> list)
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
    }
}
