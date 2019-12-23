using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public class DrawView
    {
        private PaintEventArgs pictureElement;

        #region Points storage
        private int maxWidth;
        private int maxHeight;


        //First plan walls
        private double upWall;
        private double downWall;

        private double leftWall;
        private double rightWall;


        //Inside first walls (after first panels)
        private double upView;
        private double downView;
        private double horizonView;

        private double leftView;
        private double rightView;


        //Panels processing
        private double upLeftPanel;
        private double upRightPanel;

        private double downLeftPanel;
        private double downRightPanel;


        //Background walls
        private double leftBackWall;
        private double rightBackWall;

        private double downBackWall;


        //Last background
        private double leftBackView;
        private double rightBackView;


        //Background processing
        private double upBackView;
        private double downBackView;
        #endregion Points


        public DrawView(Size pictureSize)
        {
            maxWidth = pictureSize.Width;
            maxHeight = pictureSize.Height;

            #region Process points
            upWall = 0.05;
            downWall = 0.77;

            leftWall = 0.21;
            rightWall = 1 - leftWall;


            //Inside first walls (after first panels)
            upView = 0.13;
            downView = 0.5;
            horizonView = (upView+downView)/2;

            leftView = 0.36;
            rightView = 1-leftView;


            //Panels processing
            upLeftPanel = leftView - ((leftView - leftWall) / ((upView-upWall) / (upView-0.0)));
            upRightPanel = rightView + ((rightWall-rightView) / ((upView-upWall) / (upView-0.0)));

            downLeftPanel = leftView - ((leftView-leftWall) / ((downWall-downView) / (1.0-downView)));
            downRightPanel = rightView + ((rightWall-rightView) / ((downWall-downView) / (1.0-downView)));


            //Background walls
            leftBackWall = 0.24*(rightView-leftView)+leftView;
            rightBackWall = 1-leftBackWall;

            downBackWall = downWall - ((downWall-downView) * ((leftBackWall-leftWall) / (leftView-leftWall)));


            //Last background
            leftBackView = 0.19*(rightBackWall-leftBackWall)+leftBackWall;
            rightBackView = 1.0-leftBackView;


            //Background processing
            upBackView = 0.18;
            downBackView = downWall - ((downWall-downView) * ((leftBackView-leftWall) / (leftView-leftWall)));
            #endregion Process points
        }



        private void drawFloor()
        {
            Point[] drawFloor = {
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*horizonView)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*horizonView)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*1)),
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*1))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Blue), drawFloor);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(00,00,00)), drawFloor);
        }

        private void drawCeiling()
        {
            Point[] drawCeiling = {
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*0)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*0)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*horizonView)),
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*horizonView))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Red), drawCeiling);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(250, 231, 215)), drawCeiling);
        }

        private void drawFrontBlock()
        {
            Point[] drawFrontBlock = {
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*downWall)),
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*downWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Brown), drawFrontBlock);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(128, 128, 128)), drawFrontBlock);
        }

        private void drawLeftWall()
        {
            Point[] drawLeftWall = {
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*downWall)),
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*downWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Green), drawLeftWall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(144, 144, 144)), drawLeftWall);
        }

        private void drawRightWall()
        {
            Point[] drawRightWall = {
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*downWall)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*downWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.LightGreen), drawRightWall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(144, 144, 144)), drawRightWall);
        }

        private void drawLeftHall()
        {
            Point[] drawLeftHall = {
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*downView)),
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*downWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Orange), drawLeftHall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(128, 128, 128)), drawLeftHall);
        }

        private void drawRightHall()
        {
            Point[] drawRightHall = {
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*downView)),
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*downWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.DarkOrange), drawRightHall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(128, 128, 128)), drawRightHall);
        }

        private void drawLeftPanel()
        {
            Point[] drawLeftPanel = {
                new Point(0, 0),
                new Point(Convert.ToInt32(maxWidth*upLeftPanel),    Convert.ToInt32(maxHeight*0)),
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*downView)),
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*downWall)),
                new Point(Convert.ToInt32(maxWidth*downLeftPanel),  Convert.ToInt32(maxHeight*1)),
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*1))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Violet), drawLeftPanel);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(128, 128, 128)), drawLeftPanel);
        }

        private void drawRightPanel()
        {
            Point[] drawRightPanel = {
                new Point(Convert.ToInt32(maxWidth*upRightPanel),   Convert.ToInt32(maxHeight*0)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*0)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*1)),
                new Point(Convert.ToInt32(maxWidth*downRightPanel), Convert.ToInt32(maxHeight*1)),
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*downView)),
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*upView)),
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Magenta), drawRightPanel);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(128, 128, 128)), drawRightPanel);
        }

        private void drawBackBlock()
        {
            Point[] drawBackBlock = {
                new Point(Convert.ToInt32(maxWidth*leftBackWall),       Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),      Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),      Convert.ToInt32(maxHeight*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),       Convert.ToInt32(maxHeight*downBackWall))
            };

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(78, 78, 78)), drawBackBlock);
        }

        private void drawLeftBackWall()
        {
            Point[] drawLeftBackWall = {
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),   Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),   Convert.ToInt32(maxHeight*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*downBackWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Cyan), drawLeftBackWall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(94, 94, 94)), drawLeftBackWall);
        }

        private void drawRightBackWall()
        {
            Point[] drawRightBackWall = {
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),  Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),  Convert.ToInt32(maxHeight*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*downBackWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.DarkCyan), drawRightBackWall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(94, 94, 94)), drawRightBackWall);
        }

        private void drawLeftBackHall()
        {
            Point[] drawLeftBackHall = {
                new Point(Convert.ToInt32(maxWidth*leftBackWall),   Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackView),   Convert.ToInt32(maxHeight*upBackView)),
                new Point(Convert.ToInt32(maxWidth*leftBackView),   Convert.ToInt32(maxHeight*downBackView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),   Convert.ToInt32(maxHeight*downBackWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Indigo), drawLeftBackHall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(78, 78, 78)), drawLeftBackHall);
        }

        private void drawRightBackHall()
        {
            Point[] drawRightBackHall = {
                new Point(Convert.ToInt32(maxWidth*rightBackWall),  Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView),  Convert.ToInt32(maxHeight*upBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView),  Convert.ToInt32(maxHeight*downBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),  Convert.ToInt32(maxHeight*downBackWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Navy), drawRightBackHall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(78, 78, 78)), drawRightBackHall);
        }

        private void drawLeftBackPanel()
        {
            Point[] drawLeftBackPanel = {
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),   Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),   Convert.ToInt32(maxHeight*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*downView))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.LightGray), drawLeftBackPanel);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(78, 78, 78)), drawLeftBackPanel);
        }

        private void drawRightBackPanel()
        {
            Point[] drawRightBackPanel = {
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),  Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),  Convert.ToInt32(maxHeight*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*downView))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.LightGray), drawRightBackPanel);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(78, 78, 78)), drawRightBackPanel);
        }

        private void drawBackground()
        {
            Point[] drawBackground = {
                new Point(Convert.ToInt32(maxWidth*leftBackView),   Convert.ToInt32(maxHeight*upBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView),  Convert.ToInt32(maxHeight*upBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView),  Convert.ToInt32(maxHeight*downBackView)),
                new Point(Convert.ToInt32(maxWidth*leftBackView),   Convert.ToInt32(maxHeight*downBackView))
            };

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(12,12,12)), drawBackground);
        }

        public void DrawTotalView(PaintEventArgs elem, bool canGoLeft, bool canGoRight, bool couldGoLeft, bool couldGoRight, int vision)
        {
            pictureElement = elem;

            drawFloor();
            drawCeiling();

            drawLeftHall();
            drawRightHall();

            if (canGoLeft)
            {
                drawLeftWall();
            }
            else
            {
                drawLeftPanel();
            }

            if (canGoRight)
            {
                drawRightWall();
            }
            else
            {
                drawRightPanel();
            }

            drawLeftBackHall();
            drawRightBackHall();

            if (couldGoLeft)
            {
                drawLeftBackWall();
            }
            else
            {
                drawLeftBackPanel();
            }

            if (couldGoRight)
            {
                drawRightBackWall();
            }
            else
            {
                drawRightBackPanel();
            }

            if (vision == 0)
            {
                drawFrontBlock();
            }
            else if (vision == 1)
            {
                drawBackBlock();
            }
            else
            {
                drawBackground();
            }
        }
    }
}
