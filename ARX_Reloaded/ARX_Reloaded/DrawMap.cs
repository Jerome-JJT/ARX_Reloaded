using System;
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

        private int pictureWidth;
        private int pictureHeight;

        private int mapLengthX;
        private int mapLengthY;

        private double mapCaseWidth;
        private double mapCaseHeight;

        private double mapPathWidth;
        private double mapPathHeight;

        public DrawMap(int picBoxWidth, int picBoxHeight, PaintEventArgs elem)
        {
            pictureElement = elem;

            pictureWidth = picBoxWidth;
            pictureHeight = picBoxHeight;
        }

        public void DrawTotalMap(Map map)
        {
            mapLengthX = map.Width;
            mapLengthY = map.Height;

            mapCaseWidth = pictureWidth / mapLengthX;
            mapCaseHeight = pictureHeight / mapLengthY;

            mapPathWidth = mapCaseWidth / 3;
            mapPathHeight = mapCaseHeight / 3;

            for (int h = 0; h < mapLengthY; h++)
            {
                for (int w = 0; w < mapLengthX; w++)
                {
                    /*
                    Point[] upLeft = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1))
                    };
                    */

                    Point[] upMiddle = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*2),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*2),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1))
                    };

                    /*
                    Point[] upRight = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*2),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*2),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1))
                    };
                    */

                    Point[] middleLeft = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*2)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*2))
                    };

                    Point[] middleMiddle = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*2),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*2),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*2)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*2))
                    };

                    Point[] middleRight = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*2),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*2)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*2),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*2))
                    };

                    /*
                    Point[] downLeft = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*2)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*2)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3))
                    };
                    */
                    
                    Point[] downMiddle = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*2)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*2),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*2)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*2),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3))
                    };

                    /*
                    Point[] downRight = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*2),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*2)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*2)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*2),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3))
                    };
                    */

                    /*
                    pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Blue), upLeft);
                    pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Blue), upRight);
                    pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Blue), downLeft);
                    pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Blue), downRight);
                    */

                    Color pathColor = Color.LawnGreen;

                    if(map.Cases[h * mapLengthX + w].State != 0)
                    {
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleMiddle);
                    }

                    if (map.Cases[h * mapLengthX + w].State == 2)
                    {
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleRight);
                    }
                    else if (map.Cases[h * mapLengthX + w].State == 3)
                    {
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), downMiddle);
                    }
                    else if (map.Cases[h * mapLengthX + w].State == 4)
                    {
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleRight);
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), downMiddle);
                    }

                    if (w > 0 && map.Cases[h * mapLengthX + w].State != 0 && 
                        (map.Cases[h * mapLengthX + w - 1].State == 2 || map.Cases[h * mapLengthX + w - 1].State == 4))
                    {
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleLeft);
                    }
                    if (h > 0 && map.Cases[h * mapLengthX + w].State != 0 &&
                        (map.Cases[h * mapLengthX + w - mapLengthX].State == 3 || map.Cases[h * mapLengthX + w - mapLengthX].State == 4))
                    {
                        pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), upMiddle);
                    }
                }
            }
        }
    }
}
