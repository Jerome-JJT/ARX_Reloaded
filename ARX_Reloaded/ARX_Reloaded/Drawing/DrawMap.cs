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
                        if (map.Cases[h * map.Width + w].State != ARX.State.Void)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleMiddle);
                        }

                        if (map.Cases[h * map.Width + w].State == ARX.State.Right)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleRight);
                        }
                        else if (map.Cases[h * map.Width + w].State == ARX.State.Down)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), downMiddle);
                        }
                        else if (map.Cases[h * map.Width + w].State == ARX.State.Cross)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleRight);
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), downMiddle);
                        }

                        if (w > 0 && map.Cases[h * map.Width + w].State != ARX.State.Void &&
                            (map.Cases[h * map.Width + w - 1].State == ARX.State.Right || map.Cases[h * map.Width + w - 1].State == ARX.State.Cross))
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleLeft);
                        }
                        if (h > 0 && map.Cases[h * map.Width + w].State != ARX.State.Void &&
                            (map.Cases[h * map.Width + w - map.Width].State == ARX.State.Down || map.Cases[h * map.Width + w - map.Width].State == ARX.State.Cross))
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
