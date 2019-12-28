using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public static class DrawView
    {
        #region Points storage
        private static int maxWidth;
        private static int maxHeight;


        //First plan walls
        private static double upWall;
        private static double downWall;

        private static double leftWall;
        private static double rightWall;


        //Inside first walls (after first panels)
        private static double upView;
        private static double downView;
        private static double horizonView;

        private static double leftView;
        private static double rightView;


        //Panels processing
        private static double upLeftPanel;
        private static double upRightPanel;

        private static double downLeftPanel;
        private static double downRightPanel;


        //Background walls
        private static double leftBackWall;
        private static double rightBackWall;

        private static double downBackWall;


        //Last background
        private static double leftBackView;
        private static double rightBackView;


        //Background processing
        private static double upBackView;
        private static double downBackView;
        #endregion Points


        private static void drawFloor(PaintEventArgs pictureElement)
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

        private static void drawCeiling(PaintEventArgs pictureElement)
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

        private static void drawFrontBlock(PaintEventArgs pictureElement)
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

        private static void drawLeftWall(PaintEventArgs pictureElement)
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

        private static void drawRightWall(PaintEventArgs pictureElement)
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

        private static void drawLeftHall(PaintEventArgs pictureElement)
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

        private static void drawRightHall(PaintEventArgs pictureElement)
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

        private static void drawLeftPanel(PaintEventArgs pictureElement)
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

        private static void drawRightPanel(PaintEventArgs pictureElement)
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

        private static void drawBackBlock(PaintEventArgs pictureElement)
        {
            Point[] drawBackBlock = {
                new Point(Convert.ToInt32(maxWidth*leftBackWall),       Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),      Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),      Convert.ToInt32(maxHeight*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),       Convert.ToInt32(maxHeight*downBackWall))
            };

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(78, 78, 78)), drawBackBlock);
        }

        private static void drawLeftBackWall(PaintEventArgs pictureElement)
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

        private static void drawRightBackWall(PaintEventArgs pictureElement)
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

        private static void drawLeftBackHall(PaintEventArgs pictureElement)
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

        private static void drawRightBackHall(PaintEventArgs pictureElement)
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

        private static void drawLeftBackPanel(PaintEventArgs pictureElement)
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

        private static void drawRightBackPanel(PaintEventArgs pictureElement)
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

        private static void drawBackground(PaintEventArgs pictureElement)
        {
            Point[] drawBackground = {
                new Point(Convert.ToInt32(maxWidth*leftBackView),   Convert.ToInt32(maxHeight*upBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView),  Convert.ToInt32(maxHeight*upBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView),  Convert.ToInt32(maxHeight*downBackView)),
                new Point(Convert.ToInt32(maxWidth*leftBackView),   Convert.ToInt32(maxHeight*downBackView))
            };

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(12,12,12)), drawBackground);
        }


        public static void DrawTotalView(PaintEventArgs elem, Size pictureSize, bool canGoLeft, bool canGoRight, bool couldGoLeft, bool couldGoRight, int vision)
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
            horizonView = (upView + downView) / 2;

            leftView = 0.36;
            rightView = 1 - leftView;


            //Panels processing
            upLeftPanel = leftView - ((leftView - leftWall) / ((upView - upWall) / (upView - 0.0)));
            upRightPanel = rightView + ((rightWall - rightView) / ((upView - upWall) / (upView - 0.0)));

            downLeftPanel = leftView - ((leftView - leftWall) / ((downWall - downView) / (1.0 - downView)));
            downRightPanel = rightView + ((rightWall - rightView) / ((downWall - downView) / (1.0 - downView)));


            //Background walls
            leftBackWall = 0.24 * (rightView - leftView) + leftView;
            rightBackWall = 1 - leftBackWall;

            downBackWall = downWall - ((downWall - downView) * ((leftBackWall - leftWall) / (leftView - leftWall)));


            //Last background
            leftBackView = 0.19 * (rightBackWall - leftBackWall) + leftBackWall;
            rightBackView = 1.0 - leftBackView;


            //Background processing
            upBackView = 0.18;
            downBackView = downWall - ((downWall - downView) * ((leftBackView - leftWall) / (leftView - leftWall)));
            #endregion Process points


            drawFloor(elem);
            drawCeiling(elem);

            drawLeftHall(elem);
            drawRightHall(elem);

            if (canGoLeft)
            {
                drawLeftWall(elem);
            }
            else
            {
                drawLeftPanel(elem);
            }

            if (canGoRight)
            {
                drawRightWall(elem);
            }
            else
            {
                drawRightPanel(elem);
            }

            drawLeftBackHall(elem);
            drawRightBackHall(elem);

            if (couldGoLeft)
            {
                drawLeftBackWall(elem);
            }
            else
            {
                drawLeftBackPanel(elem);
            }

            if (couldGoRight)
            {
                drawRightBackWall(elem);
            }
            else
            {
                drawRightBackPanel(elem);
            }

            if (vision == 0)
            {
                drawFrontBlock(elem);
            }
            else if (vision == 1)
            {
                drawBackBlock(elem);
            }
            else
            {
                drawBackground(elem);
            }
        }
    }
}
