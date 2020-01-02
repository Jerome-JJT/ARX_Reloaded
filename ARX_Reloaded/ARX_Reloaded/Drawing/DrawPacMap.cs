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
            for (int h = DrawMap.MapDrawStart.Y; h < DrawMap.MapDrawStop.Y; h++)
            {
                for (int w = DrawMap.MapDrawStart.X; w < DrawMap.MapDrawStop.X; w++)
                {
                    double thisCaseX = (w - DrawMap.MapDrawStart.X) * DrawMap.MapCaseWidth;
                    double thisCaseY = (h - DrawMap.MapDrawStart.Y) * DrawMap.MapCaseHeight;

                    Point[] upLeft = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*1),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*0)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*1),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*1)),
                    };

                    Point[] upRight = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*3),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*0)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*3),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*1)),
                    };


                    Point[] rightUp = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*3),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*4),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*1)),
                    };

                    Point[] rightDown = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*3),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*4),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*3)),
                    };


                    Point[] downLeft = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*1),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*1),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*4)),
                    };

                    Point[] downRight = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*3),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*3),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*4)),
                    };


                    Point[] leftUp = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*0),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*1),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*1)),
                    };

                    Point[] leftDown = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*0),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*1),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*3)),
                    };



                    Point[] inUpLeft = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*1),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*2),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*1)),
                    };
                    Point[] inUpRight = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*2),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*3),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*1)),
                    };

                    Point[] inRightUp = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*3),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*3),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*2)),
                    };
                    Point[] inRightDown = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*3),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*2)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*3),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*3)),
                    };

                    Point[] inDownLeft = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*1),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*2),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*3)),
                    };
                    Point[] inDownRight = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*2),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*3)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*3),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*3)),
                    };

                    Point[] inLeftUp = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*1),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*1)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*1),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*2)),
                    };
                    Point[] inLeftDown = {
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*1),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*2)),
                        new Point(Convert.ToInt32(thisCaseX+DrawMap.MapPathWidth*1),   Convert.ToInt32(thisCaseY+DrawMap.MapPathHeight*3)),
                    };


                    Rectangle insideArc = new Rectangle(
                        Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * 1), Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * 1),
                        Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * 3) - Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * 1),
                        Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * 3) - Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * 1)
                    );


                    Rectangle upLeftArc = new Rectangle(
                        Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * -1), Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * -1),
                        Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * 1) - Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * -1),
                        Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * 1) - Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * -1)
                    );
                    Rectangle upRightArc = new Rectangle(
                        Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * 3), Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * -1),
                        Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * 5) - Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * 3),
                        Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * 1) - Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * -1)
                    );
                    Rectangle downLeftArc = new Rectangle(
                        Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * -1), Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * 3),
                        Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * 1) - Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * -1),
                        Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * 5) - Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * 3)
                    );
                    Rectangle downRightArc = new Rectangle(
                        Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * 3), Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * 3),
                        Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * 5) - Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * 3),
                        Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * 5) - Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * 3)
                    );


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
                            pictureElement.Graphics.FillPolygon(contrastColor, DrawMap.CrossPoints());
                        }
                    }

                    if (thisCase.Coord == map.ExitIndex)
                    {
                        pictureElement.Graphics.FillEllipse(antiColor, new Rectangle(
                            Convert.ToInt32(thisCaseX + DrawMap.MapPathWidth * 1),
                            Convert.ToInt32(thisCaseY + DrawMap.MapPathHeight * 1),
                            Convert.ToInt32(DrawMap.MapPathWidth*2),
                            Convert.ToInt32(DrawMap.MapPathHeight*2)));
                    }
                }
            }

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Red), DrawMap.PlayerPoints());
            pictureElement.Graphics.DrawPolygon(new Pen(Color.Black), DrawMap.PlayerPoints());
        }
    }
}
