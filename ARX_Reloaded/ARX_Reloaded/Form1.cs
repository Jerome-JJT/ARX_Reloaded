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


        private void picView_Paint(object sender, PaintEventArgs e)
        {
            int maxWidth = picView.Size.Width;
            int maxHeight = picView.Size.Height;


            //First plan walls
            double downWall = 0.77;

            double leftWall = 0.2;
            double rightWall = 1-leftWall;


            //Inside first walls (after first panels)
            double upView = 0.15;
            double downView = 0.5;
            double horizonView = (upView+downView)/2;

            double leftView = 0.35;
            double rightView = 1-leftView;


            //Panels processing
            double downLeftPanel = leftView-((leftView-leftWall) / ((downWall-downView) / (1.0-downView)));
            double downRightPanel = rightView+((rightWall-rightView) / ((downWall-downView) / (1.0-downView)));


            //Background walls
            double leftBackWall = 0.19*(rightView-leftView)+leftView;
            double rightBackWall = 1-leftBackWall;

            double downBackWall = downWall-((downWall-downView) * ((leftBackWall-leftWall) / (leftView-leftWall)));


            //Last background
            double leftBackView = 0.18*(rightBackWall-leftBackWall)+leftBackWall;
            double rightBackView = 1.0-leftBackView;


            //Background processing
            double upBackView = 0.2;
            double downBackView = downWall - ((downWall-downView) * ((leftBackView-leftWall) / (leftView-leftWall)));


            Point[] drawFloor = {
                new Point(0, Convert.ToInt32(maxHeight*horizonView)),
                new Point(maxWidth, Convert.ToInt32(maxHeight*horizonView)),
                new Point(maxWidth, maxHeight),
                new Point(0, maxHeight)
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.Blue), drawFloor);


            Point[] drawCeiling = {
                new Point(0, 0),
                new Point(maxWidth, 0),
                new Point(maxWidth, Convert.ToInt32(maxHeight*horizonView)),
                new Point(0, Convert.ToInt32(maxHeight*horizonView))
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.Red), drawCeiling);


            Point[] drawLeftWall = {
                new Point(0, 0),
                new Point(Convert.ToInt32(maxWidth*leftWall), 0),
                new Point(Convert.ToInt32(maxWidth*leftWall), Convert.ToInt32(maxWidth*downWall)),
                new Point(0, Convert.ToInt32(maxWidth*downWall))
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.Green), drawLeftWall);


            Point[] drawRightWall = {
                new Point(maxWidth, 0),
                new Point(Convert.ToInt32(maxWidth*rightWall), 0),
                new Point(Convert.ToInt32(maxWidth*rightWall), Convert.ToInt32(maxWidth*downWall)),
                new Point(maxWidth, Convert.ToInt32(maxWidth*downWall))
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.LightGreen), drawRightWall);



            Point[] drawLeftHall = {
                new Point(Convert.ToInt32(maxWidth*leftWall), 0),
                new Point(Convert.ToInt32(maxWidth*leftView), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*leftView), Convert.ToInt32(maxWidth*downView)),
                new Point(Convert.ToInt32(maxWidth*leftWall), Convert.ToInt32(maxWidth*downWall))
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.Orange), drawLeftHall);


            Point[] drawRightHall = {
                new Point(Convert.ToInt32(maxWidth*rightWall), 0),

                new Point(Convert.ToInt32(maxWidth*rightView), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*rightView), Convert.ToInt32(maxWidth*downView)),

                new Point(Convert.ToInt32(maxWidth*rightWall), Convert.ToInt32(maxWidth*downWall))
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.DarkOrange), drawRightHall);


            Point[] drawLeftPanel = {
                new Point(0, 0),
                new Point(Convert.ToInt32(maxWidth*leftWall), 0),
                new Point(Convert.ToInt32(maxWidth*leftView), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*leftView), Convert.ToInt32(maxWidth*downView)),
                new Point(Convert.ToInt32(maxWidth*leftWall), Convert.ToInt32(maxWidth*downWall)),
                new Point(Convert.ToInt32(maxWidth*downLeftPanel), maxHeight),
                new Point(0, maxHeight)
            };

            //e.Graphics.FillPolygon(new SolidBrush(Color.Violet), drawLeftPanel);


            Point[] drawRightPanel = {
                new Point(Convert.ToInt32(maxWidth*rightWall), 0),
                new Point(maxWidth, 0),
                new Point(maxWidth, maxHeight),
                new Point(Convert.ToInt32(maxWidth*downRightPanel), maxHeight),
                new Point(Convert.ToInt32(maxWidth*rightView), Convert.ToInt32(maxWidth*downView)),
                new Point(Convert.ToInt32(maxWidth*rightView), Convert.ToInt32(maxWidth*upView)),
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.Magenta), drawRightPanel);



            Point[] drawLeftBackWall = {
                new Point(Convert.ToInt32(maxWidth*leftView), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall), Convert.ToInt32(maxWidth*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*leftView), Convert.ToInt32(maxWidth*downBackWall))
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.Cyan), drawLeftBackWall);


            Point[] drawRightBackWall = {
                new Point(Convert.ToInt32(maxWidth*rightView), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall), Convert.ToInt32(maxWidth*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*rightView), Convert.ToInt32(maxWidth*downBackWall))
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.DarkCyan), drawRightBackWall);



            Point[] drawLeftBackPanel = {
                new Point(Convert.ToInt32(maxWidth*leftView), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall), Convert.ToInt32(maxWidth*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*leftView), Convert.ToInt32(maxWidth*downView))
            };

            //e.Graphics.FillPolygon(new SolidBrush(Color.YellowGreen), drawLeftBackPanel);


            Point[] drawRightBackPanel = {
                new Point(Convert.ToInt32(maxWidth*rightView), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall), Convert.ToInt32(maxWidth*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*rightView), Convert.ToInt32(maxWidth*downView))
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.GreenYellow), drawRightBackPanel);





            Point[] drawLeftBackHall = {
                new Point(Convert.ToInt32(maxWidth*leftBackWall), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackView), Convert.ToInt32(maxWidth*upBackView)),
                new Point(Convert.ToInt32(maxWidth*leftBackView), Convert.ToInt32(maxWidth*downBackView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall), Convert.ToInt32(maxWidth*downBackWall))
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.Indigo), drawLeftBackHall);


            Point[] drawRightBackHall = {
                new Point(Convert.ToInt32(maxWidth*rightBackWall), Convert.ToInt32(maxWidth*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView), Convert.ToInt32(maxWidth*upBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView), Convert.ToInt32(maxWidth*downBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall), Convert.ToInt32(maxWidth*downBackWall))
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.Navy), drawRightBackHall);






            Point[] drawBackground = {
                new Point(Convert.ToInt32(maxWidth*leftBackView), Convert.ToInt32(maxWidth*upBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView), Convert.ToInt32(maxWidth*upBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView), Convert.ToInt32(maxWidth*downBackView)),
                new Point(Convert.ToInt32(maxWidth*leftBackView), Convert.ToInt32(maxWidth*downBackView))
            };

            e.Graphics.FillPolygon(new SolidBrush(Color.DarkSlateGray), drawBackground);
        }


    }
}
