using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARX_Reloaded
{
    public class KeyEvent : CaseEvent
    {
        private int zoneToOpen;

        public KeyEvent(int zoneToOpen)
        {
            this.zoneToOpen = zoneToOpen;
        }

        public int ZoneToOpen
        {
            get { return zoneToOpen; }
        }
    }
}
