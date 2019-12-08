﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public class DrawMap
    {
        private PaintEventArgs pictureElement;

        private int maxWidth;
        private int maxHeight;

        private int mapWidth;
        private int mapHeight;

        private double boxWidth;
        private double boxHeight;

        private double miniBoxWidth;
        private double miniBoxHeight;

        public DrawMap(int plateWidth, int plateHeight, PaintEventArgs e)
        {
            pictureElement = e;

            maxWidth = plateWidth;
            maxHeight = plateHeight;

            mapWidth = 30;
            mapHeight = 30;

            boxWidth = maxWidth / mapWidth;
            boxHeight = maxHeight / mapHeight;

            miniBoxWidth = boxWidth / 3;
            miniBoxHeight = boxHeight / 3;
        }

        public void DrawTotalMap(Map totalMap)
        {
            for (int h = 0; h < mapHeight; h++)
            {
                for (int w = 0; w < mapWidth; w++)
                {
                    Point[] upLeft = {
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*0),   Convert.ToInt32(h*boxHeight+miniBoxHeight*0)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*1),   Convert.ToInt32(h*boxHeight+miniBoxHeight*0)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*1),   Convert.ToInt32(h*boxHeight+miniBoxHeight*1)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*0),   Convert.ToInt32(h*boxHeight+miniBoxHeight*1))
                    };

                    Point[] upMiddle = {
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*1),   Convert.ToInt32(h*boxHeight+miniBoxHeight*0)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*2),   Convert.ToInt32(h*boxHeight+miniBoxHeight*0)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*2),   Convert.ToInt32(h*boxHeight+miniBoxHeight*1)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*1),   Convert.ToInt32(h*boxHeight+miniBoxHeight*1))
                    };

                    Point[] upRight = {
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*2),   Convert.ToInt32(h*boxHeight+miniBoxHeight*0)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*3),   Convert.ToInt32(h*boxHeight+miniBoxHeight*0)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*3),   Convert.ToInt32(h*boxHeight+miniBoxHeight*1)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*2),   Convert.ToInt32(h*boxHeight+miniBoxHeight*1))
                    };

                    Point[] middleLeft = {
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*0),   Convert.ToInt32(h*boxHeight+miniBoxHeight*1)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*1),   Convert.ToInt32(h*boxHeight+miniBoxHeight*1)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*1),   Convert.ToInt32(h*boxHeight+miniBoxHeight*2)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*0),   Convert.ToInt32(h*boxHeight+miniBoxHeight*2))
                    };

                    Point[] middleMiddle = {
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*1),   Convert.ToInt32(h*boxHeight+miniBoxHeight*1)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*2),   Convert.ToInt32(h*boxHeight+miniBoxHeight*1)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*2),   Convert.ToInt32(h*boxHeight+miniBoxHeight*2)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*1),   Convert.ToInt32(h*boxHeight+miniBoxHeight*2))
                    };

                    Point[] middleRight = {
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*2),   Convert.ToInt32(h*boxHeight+miniBoxHeight*1)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*3),   Convert.ToInt32(h*boxHeight+miniBoxHeight*1)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*3),   Convert.ToInt32(h*boxHeight+miniBoxHeight*2)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*2),   Convert.ToInt32(h*boxHeight+miniBoxHeight*2))
                    };

                    Point[] downLeft = {
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*0),   Convert.ToInt32(h*boxHeight+miniBoxHeight*2)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*1),   Convert.ToInt32(h*boxHeight+miniBoxHeight*2)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*1),   Convert.ToInt32(h*boxHeight+miniBoxHeight*3)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*0),   Convert.ToInt32(h*boxHeight+miniBoxHeight*3))
                    };

                    Point[] downMiddle = {
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*1),   Convert.ToInt32(h*boxHeight+miniBoxHeight*2)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*2),   Convert.ToInt32(h*boxHeight+miniBoxHeight*2)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*2),   Convert.ToInt32(h*boxHeight+miniBoxHeight*3)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*1),   Convert.ToInt32(h*boxHeight+miniBoxHeight*3))
                    };

                    Point[] downRight = {
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*2),   Convert.ToInt32(h*boxHeight+miniBoxHeight*2)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*3),   Convert.ToInt32(h*boxHeight+miniBoxHeight*2)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*3),   Convert.ToInt32(h*boxHeight+miniBoxHeight*3)),
                        new Point(Convert.ToInt32(w*boxWidth+miniBoxWidth*2),   Convert.ToInt32(h*boxHeight+miniBoxHeight*3))
                    };


                    //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Black), upLeft);
                    //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Blue), upMiddle);
                    //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Black), upRight);

                    //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Magenta), middleLeft);
                    //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Maroon), middleMiddle);


                    //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Black), downLeft);

                    //pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Black), downRight);

                    Color pathColor = Color.LawnGreen;

                    if(totalMap.Cases[h*30+w].value != 0)
                    {
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleMiddle);
                    }

                    if (totalMap.Cases[h * 30 + w].value == 2)
                    {
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleRight);
                    }
                    else if (totalMap.Cases[h * 30 + w].value == 3)
                    {
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), downMiddle);
                    }
                    else if (totalMap.Cases[h * 30 + w].value == 4)
                    {
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleRight);
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), downMiddle);
                    }

                    if (w > 0 && (totalMap.Cases[h * 30 + w - 1].value == 2 || totalMap.Cases[h * 30 + w - 1].value == 4))
                    {
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleLeft);
                    }
                    if (h > 0 && (totalMap.Cases[h * 30 + w - 30].value == 3 || totalMap.Cases[h * 30 + w - 30].value == 4))
                    {
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), upMiddle);
                    }
                }
            }
        }
    }
}
