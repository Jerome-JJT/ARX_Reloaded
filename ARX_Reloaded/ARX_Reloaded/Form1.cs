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

        private void draw(PaintEventArgs ee)
        {
            Point[] drawBackBlock = {
                new Point(30,30),
                new Point(70,45),
                new Point(30,90)
            };

            ee.Graphics.FillPolygon(new SolidBrush(Color.NavajoWhite), drawBackBlock);
        }

        private void picView_Paint(object sender, PaintEventArgs e)
        {
            DrawView drawing = new DrawView(picView.Size.Width, picView.Size.Height, e);


            drawing.DrawFloor();
            drawing.DrawCeiling();

            drawing.DrawLeftWall();
            drawing.DrawRightWall();

            drawing.DrawLeftHall();
            drawing.DrawRightHall();

            //drawing.DrawLeftPanel();
            drawing.DrawRightPanel();


            drawing.DrawLeftBackWall();
            drawing.DrawRightBackWall();

            drawing.DrawLeftBackHall();
            drawing.DrawRightBackHall();

            //drawing.DrawLeftBackPanel();
            drawing.DrawRightBackPanel();

            drawing.DrawBackground();
            //drawing.DrawBackBlock();
            //drawing.DrawFrontBlock();



        }


    }
}
