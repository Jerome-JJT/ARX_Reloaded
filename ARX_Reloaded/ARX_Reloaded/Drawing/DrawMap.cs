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
            double mapDrawLengthX;
            double mapDrawLengthY;

            Point mapDrawStart = new Point();

            Point mapDrawStop = new Point();

            double mapCaseWidth;
            double mapCaseHeight;

            double mapPathWidth;
            double mapPathHeight;

            mapDrawLengthX = (double)map.Width  / zoom;
            mapDrawLengthY = (double)map.Height / zoom;

            //mapDrawStart.X = Math.Floor(player.X / Math.Ceiling(map.Width / (double)zoom)) * Math.Ceiling();
            //mapDrawStart.Y = Math.Floor(player.Y / Math.Ceiling(map.Height / (double)zoom)) * Math.Ceiling();

            mapDrawStart.X = (int)Math.Ceiling(((int)(player.X / mapDrawLengthX)) * mapDrawLengthX);
            mapDrawStart.Y = (int)Math.Ceiling(((int)(player.Y / mapDrawLengthY)) * mapDrawLengthY);

            //mapDrawStop.X = Math.Min(map.Width, Math.Round(mapDrawStart.X + (map.Width / (double)zoom)));
            //mapDrawStop.Y = Math.Min(map.Height, Math.Round(mapDrawStart.Y + (map.Height / (double)zoom)));

            mapDrawStop.X = Math.Min(map.Width,  (int)Math.Ceiling(((int)(player.X / mapDrawLengthX + 1)) * mapDrawLengthX));
            mapDrawStop.Y = Math.Min(map.Height, (int)Math.Ceiling(((int)(player.Y / mapDrawLengthY + 1)) * mapDrawLengthY));

            mapCaseWidth  = (double)picBoxSize.Width / (mapDrawStop.X - mapDrawStart.X);
            mapCaseHeight = (double)picBoxSize.Height / (mapDrawStop.Y - mapDrawStart.Y);

            mapPathWidth = mapCaseWidth / 4.0;
            mapPathHeight = mapCaseHeight / 4.0;

            for (int h = mapDrawStart.Y; h < mapDrawStop.Y; h++)
            {
                for (int w = mapDrawStart.X; w < mapDrawStop.X; w++)
                {
                    Point[] upMiddle = {
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1))
                    };


                    Point[] middleLeft = {
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*3))
                    };

                    Point[] middleMiddle = {
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*3))
                    };

                    Point[] middleRight = {
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*4),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*4),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*3))
                    };

                    
                    Point[] downMiddle = {
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*4)),
                        new Point(Convert.ToInt32((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*4))
                    };

                    Color pathColor = map.Cases[h * map.Width + w].ZoneColor;

                    if (map.Cases[h * map.Width + w].Visited == true)
                    {
                        if (map.Cases[h * map.Width + w].State != 0)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleMiddle);
                        }

                        if (map.Cases[h * map.Width + w].State == 2)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleRight);
                        }
                        else if (map.Cases[h * map.Width + w].State == 3)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), downMiddle);
                        }
                        else if (map.Cases[h * map.Width + w].State == 4)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleRight);
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), downMiddle);
                        }

                        if (w > 0 && map.Cases[h * map.Width + w].State != 0 &&
                            (map.Cases[h * map.Width + w - 1].State == 2 || map.Cases[h * map.Width + w - 1].State == 4))
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleLeft);
                        }
                        if (h > 0 && map.Cases[h * map.Width + w].State != 0 &&
                            (map.Cases[h * map.Width + w - map.Width].State == 3 || map.Cases[h * map.Width + w - map.Width].State == 4))
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
                    new Point(Convert.ToInt32((player.X-mapDrawStart.X)*mapCaseWidth + mapPathWidth*2.0), Convert.ToInt32((player.Y-mapDrawStart.Y)*mapCaseHeight + mapPathHeight*1.2)),
                    new Point(Convert.ToInt32((player.X-mapDrawStart.X)*mapCaseWidth + mapPathWidth*1.3), Convert.ToInt32((player.Y-mapDrawStart.Y)*mapCaseHeight + mapPathHeight*2.9)),
                    new Point(Convert.ToInt32((player.X-mapDrawStart.X)*mapCaseWidth + mapPathWidth*2.7), Convert.ToInt32((player.Y-mapDrawStart.Y)*mapCaseHeight + mapPathHeight*2.9))
                };
            }
            else if (player.Rotation == 90)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32((player.X-mapDrawStart.X)*mapCaseWidth + mapPathWidth*2.8), Convert.ToInt32((player.Y-mapDrawStart.Y)*mapCaseHeight + mapPathHeight*2.0)),
                    new Point(Convert.ToInt32((player.X-mapDrawStart.X)*mapCaseWidth + mapPathWidth*1.1), Convert.ToInt32((player.Y-mapDrawStart.Y)*mapCaseHeight + mapPathHeight*1.3)),
                    new Point(Convert.ToInt32((player.X-mapDrawStart.X)*mapCaseWidth + mapPathWidth*1.1), Convert.ToInt32((player.Y-mapDrawStart.Y)*mapCaseHeight + mapPathHeight*2.7))
                };
            }
            else if (player.Rotation == 180)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32((player.X-mapDrawStart.X)*mapCaseWidth + mapPathWidth*2.0), Convert.ToInt32((player.Y-mapDrawStart.Y)*mapCaseHeight + mapPathHeight*2.8)),
                    new Point(Convert.ToInt32((player.X-mapDrawStart.X)*mapCaseWidth + mapPathWidth*1.3), Convert.ToInt32((player.Y-mapDrawStart.Y)*mapCaseHeight + mapPathHeight*1.1)),
                    new Point(Convert.ToInt32((player.X-mapDrawStart.X)*mapCaseWidth + mapPathWidth*2.7), Convert.ToInt32((player.Y-mapDrawStart.Y)*mapCaseHeight + mapPathHeight*1.1))
                };
            }
            else if (player.Rotation == 270)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32((player.X-mapDrawStart.X)*mapCaseWidth + mapPathWidth*1.2), Convert.ToInt32((player.Y-mapDrawStart.Y)*mapCaseHeight + mapPathHeight*2.0)),
                    new Point(Convert.ToInt32((player.X-mapDrawStart.X)*mapCaseWidth + mapPathWidth*2.9), Convert.ToInt32((player.Y-mapDrawStart.Y)*mapCaseHeight + mapPathHeight*1.3)),
                    new Point(Convert.ToInt32((player.X-mapDrawStart.X)*mapCaseWidth + mapPathWidth*2.9), Convert.ToInt32((player.Y-mapDrawStart.Y)*mapCaseHeight + mapPathHeight*2.7))
                };
            }

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Red), playerCursor);
            pictureElement.Graphics.DrawPolygon(new Pen(Color.Black), playerCursor);
        }
    }
}
