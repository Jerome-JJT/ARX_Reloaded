using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public static class DrawPacMap
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

                    Point[] upLeft = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*0)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                    };

                    Point[] upRight = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*0)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                    };


                    Point[] rightUp = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*4),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                    };

                    Point[] rightDown = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*4),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                    };


                    Point[] downLeft = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*4)),
                    };

                    Point[] downRight = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*4)),
                    };


                    Point[] leftUp = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*0),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                    };

                    Point[] leftDown = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*0),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                    };



                    Point[] inUpLeft = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                    };
                    Point[] inUpRight = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                    };

                    Point[] inRightUp = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*2)),
                    };
                    Point[] inRightDown = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*2)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                    };

                    Point[] inDownLeft = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                    };
                    Point[] inDownRight = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*2),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*3),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                    };

                    Point[] inLeftUp = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*2)),
                    };
                    Point[] inLeftDown = {
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*2)),
                        new Point(Convert.ToInt32(thisCaseX+mapPathWidth*1),   Convert.ToInt32(thisCaseY+mapPathHeight*3)),
                    };


                    Rectangle insideArc = new Rectangle(
                        Convert.ToInt32(thisCaseX + mapPathWidth * 1), Convert.ToInt32(thisCaseY + mapPathHeight * 1),
                        Convert.ToInt32(thisCaseX + mapPathWidth * 3) - Convert.ToInt32(thisCaseX + mapPathWidth * 1),
                        Convert.ToInt32(thisCaseY + mapPathHeight * 3) - Convert.ToInt32(thisCaseY + mapPathHeight * 1)
                    );


                    Rectangle upLeftArc = new Rectangle(
                        Convert.ToInt32(thisCaseX + mapPathWidth * -1), Convert.ToInt32(thisCaseY + mapPathHeight * -1),
                        Convert.ToInt32(thisCaseX + mapPathWidth * 1) - Convert.ToInt32(thisCaseX + mapPathWidth * -1),
                        Convert.ToInt32(thisCaseY + mapPathHeight * 1) - Convert.ToInt32(thisCaseY + mapPathHeight * -1)
                    );
                    Rectangle upRightArc = new Rectangle(
                        Convert.ToInt32(thisCaseX + mapPathWidth * 3), Convert.ToInt32(thisCaseY + mapPathHeight * -1),
                        Convert.ToInt32(thisCaseX + mapPathWidth * 5) - Convert.ToInt32(thisCaseX + mapPathWidth * 3),
                        Convert.ToInt32(thisCaseY + mapPathHeight * 1) - Convert.ToInt32(thisCaseY + mapPathHeight * -1)
                    );
                    Rectangle downLeftArc = new Rectangle(
                        Convert.ToInt32(thisCaseX + mapPathWidth * -1), Convert.ToInt32(thisCaseY + mapPathHeight * 3),
                        Convert.ToInt32(thisCaseX + mapPathWidth * 1) - Convert.ToInt32(thisCaseX + mapPathWidth * -1),
                        Convert.ToInt32(thisCaseY + mapPathHeight * 5) - Convert.ToInt32(thisCaseY + mapPathHeight * 3)
                    );
                    Rectangle downRightArc = new Rectangle(
                        Convert.ToInt32(thisCaseX + mapPathWidth * 3), Convert.ToInt32(thisCaseY + mapPathHeight * 3),
                        Convert.ToInt32(thisCaseX + mapPathWidth * 5) - Convert.ToInt32(thisCaseX + mapPathWidth * 3),
                        Convert.ToInt32(thisCaseY + mapPathHeight * 5) - Convert.ToInt32(thisCaseY + mapPathHeight * 3)
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
                    Pen pathColor = new Pen(thisCase.ZoneColor);
                    SolidBrush antiColor = new SolidBrush(thisCase.AntiColor);
                    SolidBrush contrastColor = new SolidBrush(thisCase.ContrastColor);

                    if (map.Self(thisCase.Coord).Visited == true)
                    {
                        if (map.CanGoUp(thisCase.Coord) && map.CanGoRight(thisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(pathColor, upRightArc, 90, 90);
                        }
                        else
                        {
                            if (map.CanGoUp(thisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(pathColor, upRight);
                            }
                            else if (map.CanGoRight(thisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(pathColor, rightUp);
                            }
                        }

                        if (map.CanGoRight(thisCase.Coord) && map.CanGoDown(thisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(pathColor, downRightArc, 180, 90);
                        }
                        else
                        {
                            if (map.CanGoRight(thisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(pathColor, rightDown);
                            }
                            else if (map.CanGoDown(thisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(pathColor, downRight);
                            }
                        }

                        if (map.CanGoDown(thisCase.Coord) && map.CanGoLeft(thisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(pathColor, downLeftArc, 270, 90);
                        }
                        else
                        {
                            if (map.CanGoDown(thisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(pathColor, downLeft);
                            }
                            else if (map.CanGoLeft(thisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(pathColor, leftDown);
                            }
                        }

                        if (map.CanGoLeft(thisCase.Coord) && map.CanGoUp(thisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(pathColor, upLeftArc, 0, 90);
                        }
                        else
                        {
                            if (map.CanGoLeft(thisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(pathColor, leftUp);
                            }
                            else if (map.CanGoUp(thisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(pathColor, upLeft);
                            }
                        }


                        if (!map.CanGoUp(thisCase.Coord) && !map.CanGoRight(thisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(pathColor, insideArc, 270, 90);
                            if (map.CanGoLeft(thisCase.Coord)) { pictureElement.Graphics.DrawPolygon(pathColor, inUpLeft); }
                            if (map.CanGoDown(thisCase.Coord)) { pictureElement.Graphics.DrawPolygon(pathColor, inRightDown); }
                        }
                        if (!map.CanGoRight(thisCase.Coord) && !map.CanGoDown(thisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(pathColor, insideArc, 0, 90);
                            if (map.CanGoUp(thisCase.Coord)) { pictureElement.Graphics.DrawPolygon(pathColor, inRightUp); }
                            if (map.CanGoLeft(thisCase.Coord)) { pictureElement.Graphics.DrawPolygon(pathColor, inDownLeft); }
                        }
                        if (!map.CanGoDown(thisCase.Coord) && !map.CanGoLeft(thisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(pathColor, insideArc, 90, 90);
                            if (map.CanGoRight(thisCase.Coord)) { pictureElement.Graphics.DrawPolygon(pathColor, inDownRight); }
                            if (map.CanGoUp(thisCase.Coord)) { pictureElement.Graphics.DrawPolygon(pathColor, inLeftUp); }
                        }
                        if (!map.CanGoLeft(thisCase.Coord) && !map.CanGoUp(thisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(pathColor, insideArc, 180, 90);
                            if (map.CanGoDown(thisCase.Coord)) { pictureElement.Graphics.DrawPolygon(pathColor, inLeftDown); }
                            if (map.CanGoRight(thisCase.Coord)) { pictureElement.Graphics.DrawPolygon(pathColor, inUpRight); }
                        }

                        if (!map.CanGoUp(thisCase.Coord) && map.CanGoLeft(thisCase.Coord) && map.CanGoRight(thisCase.Coord))
                        {
                            pictureElement.Graphics.DrawPolygon(pathColor, inUpLeft);
                            pictureElement.Graphics.DrawPolygon(pathColor, inUpRight);
                        }
                        if (!map.CanGoRight(thisCase.Coord) && map.CanGoUp(thisCase.Coord) && map.CanGoDown(thisCase.Coord))
                        {
                            pictureElement.Graphics.DrawPolygon(pathColor, inRightUp);
                            pictureElement.Graphics.DrawPolygon(pathColor, inRightDown);
                        }
                        if (!map.CanGoDown(thisCase.Coord) && map.CanGoLeft(thisCase.Coord) && map.CanGoRight(thisCase.Coord))
                        {
                            pictureElement.Graphics.DrawPolygon(pathColor, inDownLeft);
                            pictureElement.Graphics.DrawPolygon(pathColor, inDownRight);
                        }
                        if (!map.CanGoLeft(thisCase.Coord) && map.CanGoDown(thisCase.Coord) && map.CanGoUp(thisCase.Coord))
                        {
                            pictureElement.Graphics.DrawPolygon(pathColor, inLeftUp);
                            pictureElement.Graphics.DrawPolygon(pathColor, inLeftDown);
                        }

                        if (!thisCase.Accessible)
                        {
                            pictureElement.Graphics.FillPolygon(contrastColor, notAccessCross);
                        }
                    }

                    if (thisCase.Coord == map.ExitIndex)
                    {
                        pictureElement.Graphics.FillEllipse(antiColor, new Rectangle(
                            Convert.ToInt32(thisCaseX + mapPathWidth * 1),
                            Convert.ToInt32(thisCaseY + mapPathHeight * 1),
                            Convert.ToInt32(mapPathWidth*2),
                            Convert.ToInt32(mapPathHeight*2)));
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
