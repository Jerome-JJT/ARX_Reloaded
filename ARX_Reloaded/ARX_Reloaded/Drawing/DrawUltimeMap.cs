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
                    double thisCaseX = (w - mapDrawStart.X) * mapCaseWidth;
                    double thisCaseY = (h - mapDrawStart.Y) * mapCaseHeight;

                    Rectangle caseBackground = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*0)), 
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*0)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth*4)),   Convert.ToInt32(Math.Ceiling(mapPathHeight*4))
                    );

                    Rectangle insideArc = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*1)), 
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*1)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth*2)),   Convert.ToInt32(Math.Ceiling(mapPathHeight*2))
                    );
                    Rectangle outsideArc = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*-1)), 
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*-1)),
                        Convert.ToInt32(Math.Floor(mapPathWidth*2)),   Convert.ToInt32(Math.Floor(mapPathHeight*2))
                    );

                    Rectangle upLeftArc = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*0)), 
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*0)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),   Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle upRightArc = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*3)), 
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*0)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),   Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle downLeftArc = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*0)), 
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*3)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),   Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle downRightArc = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*3)), 
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*3)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),   Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );


                    Rectangle inUpLeft = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*1)),   
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*1)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle inUpRight = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*2)),   
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*1)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle inDownLeft = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*1)),   
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*2)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle inDownRight = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*2)),   
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*2)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );


                    Rectangle outUp = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*1)),   
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*0)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth*2)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle outRight = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*3)),   
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*1)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight*2))
                    );
                    Rectangle outDown = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*1)),  
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*3)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth*2)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight))
                    );
                    Rectangle outLeft = new Rectangle (
                        Convert.ToInt32(Math.Ceiling(thisCaseX+mapPathWidth*0)),   
                        Convert.ToInt32(Math.Ceiling(thisCaseY+mapPathHeight*1)),
                        Convert.ToInt32(Math.Ceiling(mapPathWidth)),
                        Convert.ToInt32(Math.Ceiling(mapPathHeight*2))
                    );

                    Point[] notAccessCross = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2.0),   Convert.ToInt32(thisCaseY+mapPathHeight*1.8)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2.5),   Convert.ToInt32(thisCaseY+mapPathHeight*1.3)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2.7),   Convert.ToInt32(thisCaseY+mapPathHeight*1.5)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2.2),   Convert.ToInt32(thisCaseY+mapPathHeight*2.0)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2.7),   Convert.ToInt32(thisCaseY+mapPathHeight*2.5)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2.5),   Convert.ToInt32(thisCaseY+mapPathHeight*2.7)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2),   Convert.ToInt32(thisCaseY+mapPathHeight*2.2)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1.5),   Convert.ToInt32(thisCaseY+mapPathHeight*2.7)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1.3),   Convert.ToInt32(thisCaseY+mapPathHeight*2.5)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1.8),   Convert.ToInt32(thisCaseY+mapPathHeight*2.0)),

                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1.3),   Convert.ToInt32(thisCaseY+mapPathHeight*1.5)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1.5),   Convert.ToInt32(thisCaseY+mapPathHeight*1.3))
                    };

                    Case thisCase = map.Cases[h * map.Width + w];

                    SolidBrush pathColor = new SolidBrush(thisCase.ZoneColor);
                    SolidBrush backColor = new SolidBrush(Color.Black);
                    SolidBrush antiColor = new SolidBrush(thisCase.AntiColor);

                    if (thisCase.Visited == true)
                    {
                        pictureElement.Graphics.FillRectangle(backColor, caseBackground);

                        //Create internal angles
                        if (!map.CanGoUp(thisCase.Coord) && !map.CanGoRight(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillPie(pathColor, insideArc, 270, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(pathColor, inUpRight);
                        }
                        if (!map.CanGoRight(thisCase.Coord) && !map.CanGoDown(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillPie(pathColor, insideArc, 0, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(pathColor, inDownRight);
                        }
                        if (!map.CanGoDown(thisCase.Coord) && !map.CanGoLeft(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillPie(pathColor, insideArc, 90, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(pathColor, inDownLeft);
                        }
                        if (!map.CanGoLeft(thisCase.Coord) && !map.CanGoUp(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillPie(pathColor, insideArc, 180, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(pathColor, inUpLeft);
                        }

                        //Create path between cases
                        if (map.CanGoUp(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(pathColor, outUp);
                        }
                        if (map.CanGoRight(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(pathColor, outRight);
                        }
                        if (map.CanGoDown(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(pathColor, outDown);
                        }
                        if (map.CanGoLeft(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(pathColor, outLeft);
                        }

                        //Create externals angles
                        if (map.CanGoUp(thisCase.Coord) && map.CanGoRight(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(pathColor, upRightArc);
                        }
                        if (map.CanGoRight(thisCase.Coord) && map.CanGoDown(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(pathColor, downRightArc);
                        }
                        if (map.CanGoDown(thisCase.Coord) && map.CanGoLeft(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(pathColor, downLeftArc);
                        }
                        if (map.CanGoLeft(thisCase.Coord) && map.CanGoUp(thisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(pathColor, upLeftArc);
                        }

                        if (!thisCase.Accessible)
                        {
                            pictureElement.Graphics.FillPolygon(antiColor, notAccessCross);
                        }

                        pictureElement.Graphics.FillEllipse(backColor, outsideArc);
                    }

                    if (thisCase.Coord == map.ExitIndex)
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
