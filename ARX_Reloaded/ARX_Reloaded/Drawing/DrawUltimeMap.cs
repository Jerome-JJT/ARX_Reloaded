using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public static class DrawUltimeMap
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
                    Rectangle caseBackground = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*0)), 
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*0)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth*4)),   Convert.ToInt32(Math.Ceiling(mapPathHeight*4))
                    );

                    Rectangle insideArc = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1)), 
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth*2)),   Convert.ToInt32(Math.Ceiling(mapPathHeight*2))
                    );
                    Rectangle outsideArc = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*-1)), 
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*-1)),
                        Convert.ToInt32(Math.Floor(mapPathWidth*2)),   Convert.ToInt32(Math.Floor(mapPathHeight*2))
                    );

                    Rectangle upLeftArc = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*0)), 
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*0)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),   Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle upRightArc = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*3)), 
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*0)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),   Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle downLeftArc = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*0)), 
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*3)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),   Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle downRightArc = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*3)), 
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*3)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),   Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );


                    Rectangle inUpLeft = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1)),   
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle inUpRight = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*2)),   
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle inDownLeft = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1)),   
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*2)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle inDownRight = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*2)),   
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*2)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );


                    Rectangle outUp = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1)),   
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*0)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth*2)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle outRight = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*3)),   
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight*2))
                    );
                    Rectangle outDown = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*1)),  
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*3)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth*2)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle outLeft = new Rectangle (
                        Convert.ToInt32(Math.Ceiling((w-mapDrawStart.X)*mapCaseWidth+mapPathWidth*0)),   
                        Convert.ToInt32(Math.Ceiling((h-mapDrawStart.Y)*mapCaseHeight+mapPathHeight*1)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight*2))
                    );


                    int thisCase = h * map.Width + w;

                    SolidBrush newPathColor = new SolidBrush(map.Self(thisCase).ZoneColor);
                    SolidBrush newBackColor = new SolidBrush(Color.Black);

                    if (map.Self(thisCase).Visited == true)
                    {
                        pictureElement.Graphics.FillRectangle(newBackColor, caseBackground);

                        //Create internal angles
                        if (!map.CanGoUp(thisCase) && !map.CanGoRight(thisCase))
                        {
                            pictureElement.Graphics.FillPie(newPathColor, insideArc, 270, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(newPathColor, inUpRight);
                        }
                        if (!map.CanGoRight(thisCase) && !map.CanGoDown(thisCase))
                        {
                            pictureElement.Graphics.FillPie(newPathColor, insideArc, 0, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(newPathColor, inDownRight);
                        }
                        if (!map.CanGoDown(thisCase) && !map.CanGoLeft(thisCase))
                        {
                            pictureElement.Graphics.FillPie(newPathColor, insideArc, 90, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(newPathColor, inDownLeft);
                        }
                        if (!map.CanGoLeft(thisCase) && !map.CanGoUp(thisCase))
                        {
                            pictureElement.Graphics.FillPie(newPathColor, insideArc, 180, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(newPathColor, inUpLeft);
                        }

                        //Create path between cases
                        if (map.CanGoUp(thisCase))
                        {
                            pictureElement.Graphics.FillRectangle(newPathColor, outUp);
                        }
                        if (map.CanGoRight(thisCase))
                        {
                            pictureElement.Graphics.FillRectangle(newPathColor, outRight);
                        }
                        if (map.CanGoDown(thisCase))
                        {
                            pictureElement.Graphics.FillRectangle(newPathColor, outDown);
                        }
                        if (map.CanGoLeft(thisCase))
                        {
                            pictureElement.Graphics.FillRectangle(newPathColor, outLeft);
                        }

                        //Create externals angles
                        if (map.CanGoUp(thisCase) && map.CanGoRight(thisCase))
                        {
                            pictureElement.Graphics.FillRectangle(newPathColor, upRightArc);
                        }
                        if (map.CanGoRight(thisCase) && map.CanGoDown(thisCase))
                        {
                            pictureElement.Graphics.FillRectangle(newPathColor, downRightArc);
                        }
                        if (map.CanGoDown(thisCase) && map.CanGoLeft(thisCase))
                        {
                            pictureElement.Graphics.FillRectangle(newPathColor, downLeftArc);
                        }
                        if (map.CanGoLeft(thisCase) && map.CanGoUp(thisCase))
                        {
                            pictureElement.Graphics.FillRectangle(newPathColor, upLeftArc);
                        }

                        pictureElement.Graphics.FillEllipse(newBackColor, outsideArc);
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
