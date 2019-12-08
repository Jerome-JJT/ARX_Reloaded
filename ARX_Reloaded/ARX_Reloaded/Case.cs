using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARX_Reloaded
{
    public class Case
    {
        private int state;
        private bool visited;

        public Case()
        {
            state = 0;
            visited = false;
        }

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }
    }
}
