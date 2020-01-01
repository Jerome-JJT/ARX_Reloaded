using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public static class DrawMap
    {
        public static void DrawTotalMap(PaintEventArgs pictureElement, Size picBoxSize, Map map, Player player, int zoom)
        {
            Point mapDrawStart = new Point();
            Point mapDrawStop = new Point();


            double mapDrawLengthX = (double)map.Width  / zoom;
            double mapDrawLengthY = (double)map.Height / zoom;


            mapDrawStart.X = (int)Math.Ceiling(((int)(player.X / mapDrawLengthX)) * mapDrawLengthX);
            mapDrawStart.Y = (int)Math.Ceiling(((int)(player.Y / mapDrawLengthY)) * mapDrawLengthY);

            mapDrawStop.X = Math.Min(map.Width,  (int)Math.Ceiling(((int)(player.X / mapDrawLengthX + 1)) * mapDrawLengthX));
            mapDrawStop.Y = Math.Min(map.Height, (int)Math.Ceiling(((int)(player.Y / mapDrawLengthY + 1)) * mapDrawLengthY));


            double mapCaseWidth = (double)picBoxSize.Width / (mapDrawStop.X - mapDrawStart.X);
            double mapCaseHeight = (double)picBoxSize.Height / (mapDrawStop.Y - mapDrawStart.Y);

            double mapPathWidth = mapCaseWidth / 4.0;
            double mapPathHeight = mapCaseHeight / 4.0;


            for (int h = mapDrawStart.Y; h < mapDrawStop.Y; h++)
            {
                for (int w = mapDrawStart.X; w < mapDrawStop.X; w++)
                {
                    double thisCaseX = (w - mapDrawStart.X) * mapCaseWidth;
                    double thisCaseY = (h - mapDrawStart.Y) * mapCaseHeight;

                    Point[] upMiddle = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*0)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*0)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*1))
                    };


                    Point[] middleLeft = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*0),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*0),   Convert.ToInt32(thisCaseY+mapPathHeight*3))
                    };

                    Point[] middleMiddle = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*3))
                    };

                    Point[] middleRight = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*4),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*4),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*3))
                    };

                    
                    Point[] downMiddle = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*4)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*4))
                    };

                    Point[] notAccessCross = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2.0),   Convert.ToInt32(thisCaseY+mapPathHeight*1.8)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2.8),   Convert.ToInt32(thisCaseY+mapPathHeight*1.0)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3.0),   Convert.ToInt32(thisCaseY+mapPathHeight*1.2)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2.2),   Convert.ToInt32(thisCaseY+mapPathHeight*2.0)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3.0),   Convert.ToInt32(thisCaseY+mapPathHeight*2.8)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2.8),   Convert.ToInt32(thisCaseY+mapPathHeight*3.0)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2),   Convert.ToInt32(thisCaseY+mapPathHeight*2.2)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1.2),   Convert.ToInt32(thisCaseY+mapPathHeight*3.0)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1.0),   Convert.ToInt32(thisCaseY+mapPathHeight*2.8)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1.8),   Convert.ToInt32(thisCaseY+mapPathHeight*2.0)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1.0),   Convert.ToInt32(thisCaseY+mapPathHeight*1.2)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1.2),   Convert.ToInt32(thisCaseY+mapPathHeight*1.0))
                    };

                    Case thisCase = map.Self(h * map.Width + w);
                    SolidBrush pathColor = new SolidBrush(thisCase.ZoneColor);
                    SolidBrush antiColor = new SolidBrush(thisCase.AntiColor);
                    SolidBrush contrastColor = new SolidBrush(thisCase.ContrastColor);
                    
                    if (thisCase.Visited == true)
                    {
                        if (thisCase.State != ARX.State.Void)
                        {
                            pictureElement.Graphics.FillPolygon(pathColor, middleMiddle);
                        }

                        if (map.CanGoUp(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillPolygon(pathColor, upMiddle);
                        }
                        if (map.CanGoRight(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillPolygon(pathColor, middleRight);
                        }
                        if (map.CanGoDown(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillPolygon(pathColor, downMiddle);
                        }
                        if (map.CanGoLeft(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillPolygon(pathColor, middleLeft);
                        }

                        if(!thisCase.Accessible)
                        {
                            pictureElement.Graphics.FillPolygon(contrastColor, notAccessCross);
                        }
                    }

                    if(thisCase.Coord == map.ExitIndex)
                    {
                        pictureElement.Graphics.FillEllipse(antiColor, new Rectangle(
                            Convert.ToInt32(thisCaseX + mapPathWidth * 1),
                            Convert.ToInt32(thisCaseY + mapPathHeight * 1),
                            Convert.ToInt32(mapPathWidth * 2),
                            Convert.ToInt32(mapPathHeight * 2)));
                    }
                }
            }

            Point[] playerCursor = new Point[] { };

            double playerCaseX = (player.X - mapDrawStart.X) * mapCaseWidth;
            double playerCaseY = (player.Y - mapDrawStart.Y) * mapCaseHeight;

            if (player.Rotation == 0)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32(playerCaseX + mapPathWidth*2.0), Convert.ToInt32(playerCaseY + mapPathHeight*1.2)),
                    new Point(Convert.ToInt32(playerCaseX + mapPathWidth*1.3), Convert.ToInt32(playerCaseY + mapPathHeight*2.9)),
                    new Point(Convert.ToInt32(playerCaseX + mapPathWidth*2.7), Convert.ToInt32(playerCaseY + mapPathHeight*2.9))
                };
            }
            else if (player.Rotation == 90)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32(playerCaseX + mapPathWidth*2.8), Convert.ToInt32(playerCaseY + mapPathHeight*2.0)),
                    new Point(Convert.ToInt32(playerCaseX + mapPathWidth*1.1), Convert.ToInt32(playerCaseY + mapPathHeight*1.3)),
                    new Point(Convert.ToInt32(playerCaseX + mapPathWidth*1.1), Convert.ToInt32(playerCaseY + mapPathHeight*2.7))
                };
            }
            else if (player.Rotation == 180)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32(playerCaseX + mapPathWidth*2.0), Convert.ToInt32(playerCaseY + mapPathHeight*2.8)),
                    new Point(Convert.ToInt32(playerCaseX + mapPathWidth*1.3), Convert.ToInt32(playerCaseY + mapPathHeight*1.1)),
                    new Point(Convert.ToInt32(playerCaseX + mapPathWidth*2.7), Convert.ToInt32(playerCaseY + mapPathHeight*1.1))
                };
            }
            else if (player.Rotation == 270)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32(playerCaseX + mapPathWidth*1.2), Convert.ToInt32(playerCaseY + mapPathHeight*2.0)),
                    new Point(Convert.ToInt32(playerCaseX + mapPathWidth*2.9), Convert.ToInt32(playerCaseY + mapPathHeight*1.3)),
                    new Point(Convert.ToInt32(playerCaseX + mapPathWidth*2.9), Convert.ToInt32(playerCaseY + mapPathHeight*2.7))
                };
            }

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Red), playerCursor);
            pictureElement.Graphics.DrawPolygon(new Pen(Color.Black), playerCursor);
        }
    }
}
