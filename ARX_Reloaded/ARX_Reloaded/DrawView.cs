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
        PaintEventArgs pictureElement;

        #region Points storage
        int maxWidth;
        int maxHeight;


        //First plan walls
        double upWall;
        double downWall;

        double leftWall;
        double rightWall;


        //Inside first walls (after first panels)
        double upView;
        double downView;
        double horizonView;

        double leftView;
        double rightView;


        //Panels processing
        double downLeftPanel;
        double downRightPanel;


        //Background walls
        double leftBackWall;
        double rightBackWall;

        double downBackWall;


        //Last background
        double leftBackView;
        double rightBackView;


        //Background processing
        double upBackView;
        double downBackView;
        #endregion Points

        
        public DrawView(int plateWidth, int plateHeight, PaintEventArgs e)
        {
            pictureElement = e;

            maxWidth = plateWidth;
            maxHeight = plateHeight;

            #region Process points
            upWall = 0.05;
            downWall = 0.77;

            leftWall = 0.2;
            rightWall = 1 - leftWall;


            //Inside first walls (after first panels)
            upView = 0.15;
            downView = 0.5;
            horizonView = (upView + downView) / 2;

            leftView = 0.35;
            rightView = 1 - leftView;


            //Panels processing
            downLeftPanel = leftView - ((leftView - leftWall) / ((downWall - downView) / (1.0 - downView)));
            downRightPanel = rightView + ((rightWall - rightView) / ((downWall - downView) / (1.0 - downView)));


            //Background walls
            leftBackWall = 0.19 * (rightView - leftView) + leftView;
            rightBackWall = 1 - leftBackWall;

            downBackWall = downWall - ((downWall - downView) * ((leftBackWall - leftWall) / (leftView - leftWall)));


            //Last background
            leftBackView = 0.18 * (rightBackWall - leftBackWall) + leftBackWall;
            rightBackView = 1.0 - leftBackView;


            //Background processing
            upBackView = 0.2;
            downBackView = downWall - ((downWall - downView) * ((leftBackView - leftWall) / (leftView - leftWall)));
            #endregion Process points
        }



        public void DrawFloor()
        {
            Point[] drawFloor = {
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*horizonView)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*horizonView)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*1)),
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*1))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Blue), drawFloor);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Black), drawFloor);
        }


        public void DrawCeiling()
        {
            Point[] drawCeiling = {
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*0)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*0)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*horizonView)),
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*horizonView))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Red), drawCeiling);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.AntiqueWhite), drawCeiling);
        }

        public void DrawFrontBlock()
        {
            Point[] drawFrontBlock = {
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*downWall)),
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*downWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Brown), drawFrontBlock);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.DimGray), drawFrontBlock);
        }

        public void DrawLeftWall()
        {
            Point[] drawLeftWall = {
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*downWall)),
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*downWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Green), drawLeftWall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.DimGray), drawLeftWall);
        }

        public void DrawRightWall()
        {
            Point[] drawRightWall = {
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*downWall)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*downWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.LightGreen), drawRightWall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.DimGray), drawRightWall);
        }

        public void DrawLeftHall()
        {
            Point[] drawLeftHall = {
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*downView)),
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*downWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Orange), drawLeftHall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Gray), drawLeftHall);
        }

        public void DrawRightHall()
        {
            Point[] drawRightHall = {
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*downView)),
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*downWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.DarkOrange), drawRightHall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Gray), drawRightHall);
        }

        public void DrawLeftPanel()
        {
            Point[] drawLeftPanel = {
                new Point(0, 0),
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*downView)),
                new Point(Convert.ToInt32(maxWidth*leftWall),       Convert.ToInt32(maxHeight*downWall)),
                new Point(Convert.ToInt32(maxWidth*downLeftPanel),  Convert.ToInt32(maxHeight*1)),
                new Point(Convert.ToInt32(maxWidth*0),              Convert.ToInt32(maxHeight*1))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Violet), drawLeftPanel);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Gray), drawLeftPanel);
        }

        public void DrawRightPanel()
        {
            Point[] drawRightPanel = {
                new Point(Convert.ToInt32(maxWidth*rightWall),      Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*upWall)),
                new Point(Convert.ToInt32(maxWidth*1),              Convert.ToInt32(maxHeight*1)),
                new Point(Convert.ToInt32(maxWidth*downRightPanel), Convert.ToInt32(maxHeight*1)),
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*downView)),
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*upView)),
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Magenta), drawRightPanel);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Gray), drawRightPanel);
        }

        public void DrawBackBlock()
        {
            Point[] drawBackBlock = {
                new Point(Convert.ToInt32(maxWidth*leftBackWall),       Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),      Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),      Convert.ToInt32(maxHeight*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),       Convert.ToInt32(maxHeight*downBackWall))
            };

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.SaddleBrown), drawBackBlock);
        }

        public void DrawLeftBackWall()
        {
            Point[] drawLeftBackWall = {
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),   Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),   Convert.ToInt32(maxHeight*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*downBackWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Cyan), drawLeftBackWall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.DarkGray), drawLeftBackWall);
        }

        public void DrawRightBackWall()
        {
            Point[] drawRightBackWall = {
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),  Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),  Convert.ToInt32(maxHeight*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*downBackWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.DarkCyan), drawRightBackWall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.DarkGray), drawRightBackWall);
        }

        public void DrawLeftBackHall()
        {
            Point[] drawLeftBackHall = {
                new Point(Convert.ToInt32(maxWidth*leftBackWall),   Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackView),   Convert.ToInt32(maxHeight*upBackView)),
                new Point(Convert.ToInt32(maxWidth*leftBackView),   Convert.ToInt32(maxHeight*downBackView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),   Convert.ToInt32(maxHeight*downBackWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Indigo), drawLeftBackHall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.SlateGray), drawLeftBackHall);
        }

        public void DrawRightBackHall()
        {
            Point[] drawRightBackHall = {
                new Point(Convert.ToInt32(maxWidth*rightBackWall),  Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView),  Convert.ToInt32(maxHeight*upBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView),  Convert.ToInt32(maxHeight*downBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),  Convert.ToInt32(maxHeight*downBackWall))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Navy), drawRightBackHall);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.SlateGray), drawRightBackHall);
        }

        public void DrawLeftBackPanel()
        {
            Point[] drawLeftBackPanel = {
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),   Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*leftBackWall),   Convert.ToInt32(maxHeight*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*leftView),       Convert.ToInt32(maxHeight*downView))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.LightGray), drawLeftBackPanel);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.SlateGray), drawLeftBackPanel);
        }

        public void DrawRightBackPanel()
        {
            Point[] drawRightBackPanel = {
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),  Convert.ToInt32(maxHeight*upView)),
                new Point(Convert.ToInt32(maxWidth*rightBackWall),  Convert.ToInt32(maxHeight*downBackWall)),
                new Point(Convert.ToInt32(maxWidth*rightView),      Convert.ToInt32(maxHeight*downView))
            };

            //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.LightGray), drawRightBackPanel);
            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.SlateGray), drawRightBackPanel);
        }

        public void DrawBackground()
        {
            Point[] drawBackground = {
                new Point(Convert.ToInt32(maxWidth*leftBackView),   Convert.ToInt32(maxHeight*upBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView),  Convert.ToInt32(maxHeight*upBackView)),
                new Point(Convert.ToInt32(maxWidth*rightBackView),  Convert.ToInt32(maxHeight*downBackView)),
                new Point(Convert.ToInt32(maxWidth*leftBackView),   Convert.ToInt32(maxHeight*downBackView))
            };

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.DarkSlateGray), drawBackground);
        }


    }
}
