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
        private Player player;

        private int pictureWidth;
        private int pictureHeight;

        private int mapLengthX;
        private int mapLengthY;

        private double mapCaseWidth;
        private double mapCaseHeight;

        private double mapPathWidth;
        private double mapPathHeight;

        public DrawMap(PaintEventArgs elem, Size picBoxSize, Player player)
        {
            pictureElement = elem;

            pictureWidth = picBoxSize.Width;
            pictureHeight = picBoxSize.Height;

            this.player = player;
        }

        public void DrawTotalMap(Map map)
        {
            mapLengthX = map.Width;
            mapLengthY = map.Height;

            mapCaseWidth = pictureWidth / mapLengthX;
            mapCaseHeight = pictureHeight / mapLengthY;

            mapPathWidth = mapCaseWidth / 4;
            mapPathHeight = mapCaseHeight / 4;

            for (int h = 0; h < mapLengthY; h++)
            {
                for (int w = 0; w < mapLengthX; w++)
                {
                    Point[] upMiddle = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1))
                    };


                    Point[] middleLeft = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3))
                    };

                    Point[] middleMiddle = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3))
                    };

                    Point[] middleRight = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*4),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*4),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3))
                    };

                    
                    Point[] downMiddle = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*4)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*4))
                    };


                    Color pathColor;
                    
                    switch(map.Cases[h * mapLengthX + w].Zone)
                    {
                        case 1:
                            pathColor = Color.Red;
                            break;

                        case 2:
                            pathColor = Color.LawnGreen;
                            break;

                        case 3:
                            pathColor = Color.Blue;
                            break;

                        default:
                            pathColor = Color.White;
                            break;
                    }


                    if (map.Cases[h * mapLengthX + w].Visited == true)
                    {
                        if (map.Cases[h * mapLengthX + w].State != 0)
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

            Point[] playerCursor = new Point[] { };

            if (player.Rotation == 0)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*1.2)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*1.3), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2.9)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2.7), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2.9))
                };
            }
            else if (player.Rotation == 90)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2.8), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*1.1), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*1.3)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*1.1), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2.7))
                };
            }
            else if (player.Rotation == 180)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2.8)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*1.3), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*1.1)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2.7), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*1.1))
                };
            }
            else if (player.Rotation == 270)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*1.2), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2.9), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*1.3)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2.9), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2.7))
                };
            }

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Red), playerCursor);
        }
    }
}
