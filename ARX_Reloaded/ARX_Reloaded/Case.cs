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

        public Case()
        {
            state = 0;
        }

        public int State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
