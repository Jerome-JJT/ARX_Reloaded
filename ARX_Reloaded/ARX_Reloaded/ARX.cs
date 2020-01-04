using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARX_Reloaded
{
    public static class ARX
    {
        public enum Direction
        {
            Null = -1,
            Up = 0,
            Right = 90,
            Down = 180,
            Left = 270
        }

        public enum State
        {
            Void = 0,
            Point = 1,
            Right = 2,
            Down = 3,
            Cross = 4
        }

        public enum MapType
        {
            Normal,
            Pacman,
            Fill
        }

        //Shuffle a list
        public static void Shuffle<T>(Random random, IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
