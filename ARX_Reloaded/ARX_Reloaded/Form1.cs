using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public partial class FrmGame : Form
    {
        public FrmGame()
        {
            InitializeComponent();
           
        }



        /*public double Map(double value, double fromLow, double fromHigh, double toLow, double toHigh)
        {
            return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }*/


        bool canGoLeft = true;
        bool canGoRight = true;

        bool couldGoLeft = true;
        bool couldGoRight = true;
        int vision = 2;

        Map map = new Map(5,5);
        


        private void picView_Paint(object sender, PaintEventArgs e)
        {
            DrawView drawing = new DrawView(picView.Size.Width, picView.Size.Height, e);

            drawing.DrawTotalView(canGoLeft, canGoRight, couldGoLeft, couldGoRight, vision);
        }

        private void picMap_Paint(object sender, PaintEventArgs e)
        {
            DrawMap drawing = new DrawMap(picMap.Size.Width, picMap.Size.Height, e);

            drawing.DrawTotalMap(map);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            canGoLeft = false;
            picView.Refresh();

            map = new Map(5, 5);
            map.GenerateMap(picMap);
            picMap.Refresh();
        }

        
    }
}
