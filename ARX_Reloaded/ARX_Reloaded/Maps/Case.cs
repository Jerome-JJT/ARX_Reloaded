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
        private int zone;
        private bool visited;

        public Case(int zone)
        {
            this.state = 0;
            this.zone = zone;
            this.visited = true;
        }

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        public int Zone
        {
            get { return zone; }
            set { zone = value; }
        }

        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }
    }
}
