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
        public static void DrawTotalMap(PaintEventArgs pictureElement)
        {
            for (int h = DrawMap.MapDrawStart.Y; h < DrawMap.MapDrawStop.Y; h++)
            {
                for (int w = DrawMap.MapDrawStart.X; w < DrawMap.MapDrawStop.X; w++)
                {
                    DrawMap.PrepareCase(w, h);

                    if (DrawMap.Map.Self(DrawMap.ThisCase.Coord).Visited == true)
                    {
                        pictureElement.Graphics.FillRectangle(DrawMap.BackBrush, DrawMap.CaseBackground());

                        #region Case pattern drawing
                        if (DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(DrawMap.PathPen, ArcUpRight(), 90, 90);
                        }
                        else
                        {
                            if (DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, OutUpRight());
                            }
                            else if (DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, OutRightUp());
                            }
                        }

                        if (DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(DrawMap.PathPen, ArcDownRight(), 180, 90);
                        }
                        else
                        {
                            if (DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, OutRightDown());
                            }
                            else if (DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, OutDownRight());
                            }
                        }

                        if (DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(DrawMap.PathPen, ArcDownLeft(), 270, 90);
                        }
                        else
                        {
                            if (DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, OutDownLeft());
                            }
                            else if (DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, OutLeftDown());
                            }
                        }

                        if (DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(DrawMap.PathPen, ArcUpLeft(), 0, 90);
                        }
                        else
                        {
                            if (DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, OutLeftUp());
                            }
                            else if (DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord))
                            {
                                pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, OutUpLeft());
                            }
                        }


                        if (!DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord) && !DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(DrawMap.PathPen, InsideArc(), 270, 90);
                            if (DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord)) { pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InUpLeft()); }
                            if (DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord)) { pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InRightDown()); }
                        }
                        if (!DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord) && !DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(DrawMap.PathPen, InsideArc(), 0, 90);
                            if (DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord)) { pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InRightUp()); }
                            if (DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord)) { pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InDownLeft()); }
                        }
                        if (!DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord) && !DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(DrawMap.PathPen, InsideArc(), 90, 90);
                            if (DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord)) { pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InDownRight()); }
                            if (DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord)) { pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InLeftUp()); }
                        }
                        if (!DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord) && !DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.DrawArc(DrawMap.PathPen, InsideArc(), 180, 90);
                            if (DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord)) { pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InLeftDown()); }
                            if (DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord)) { pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InUpRight()); }
                        }

                        if (!DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InUpLeft());
                            pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InUpRight());
                        }
                        if (!DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InRightUp());
                            pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InRightDown());
                        }
                        if (!DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InDownLeft());
                            pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InDownRight());
                        }
                        if (!DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InLeftUp());
                            pictureElement.Graphics.DrawPolygon(DrawMap.PathPen, InLeftDown());
                        }
                        #endregion

                        if (!DrawMap.ThisCase.Accessible)
                        {
                            pictureElement.Graphics.FillPolygon(DrawMap.AntiBrush, DrawMap.CrossPoints());
                        }
                    }

                    if (DrawMap.ThisCase.Coord == DrawMap.Map.ExitIndex)
                    {
                        pictureElement.Graphics.FillEllipse(DrawMap.AntiBrush, new Rectangle(
                            Convert.ToInt32(DrawMap.CasePosX + DrawMap.MapPathWidth * 1),
                            Convert.ToInt32(DrawMap.CasePosY + DrawMap.MapPathHeight * 1),
                            Convert.ToInt32(DrawMap.MapPathWidth*2),
                            Convert.ToInt32(DrawMap.MapPathHeight*2)));
                    }
                }
            }

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Red), DrawMap.PlayerPoints());
            pictureElement.Graphics.DrawPolygon(new Pen(Color.Black), DrawMap.PlayerPoints());
        }

        #region Inside walls
        public static Point[] InUpLeft()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*1)),  
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*1))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*2)),  
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*1)))
            };
        }
        public static Point[] InUpRight()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*2)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*1))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*3)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*1)))
            };
        }
        public static Point[] InRightUp()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*3)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*1))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*3)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*2)))
            };
        }
        public static Point[] InRightDown()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*3)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*2))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*3)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*3)))
            };
        }
        public static Point[] InDownLeft()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*1)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*3))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*2)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*3)))
            };
        }
        public static Point[] InDownRight()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*2)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*3))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*3)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*3)))
            };
        }
        public static Point[] InLeftUp()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*1)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*1))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*1)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*2)))
            };
        }
        public static Point[] InLeftDown()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*1)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*2))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*1)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*3)))
            };
        }
        #endregion

        #region Outside walls
        public static Point[] OutUpLeft()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 1)), 
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 0))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 1)), 
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 1)))
            };
        }
        public static Point[] OutUpRight()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 3)), 
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 0))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 3)), 
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 1)))
            };
        }
        public static Point[] OutRightUp()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 3)), 
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 1))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 4)), 
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 1)))
            };
        }

        public static Point[] OutRightDown()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 3)), 
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 3))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 4)), 
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 3)))
            };
        }
        public static Point[] OutDownLeft()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 1)), 
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 3))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 1)), 
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 4)))
            };
        }
        public static Point[] OutDownRight()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth * 3)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight * 3))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth * 3)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight * 4)))
            };
        }
        public static Point[] OutLeftUp()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*0)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*1))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*1)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*1))),
            };
        }
        public static Point[] OutLeftDown()
        {
            return new Point[] {
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*0)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*3))),
                new Point(Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX+DrawMap.MapPathWidth*1)),   
                          Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY+DrawMap.MapPathHeight*3))),
            };
        }
        #endregion

        #region Arc walls
        public static Rectangle InsideArc()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 1)), 
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 1)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight * 2))
            );
        }
        public static Rectangle ArcUpLeft()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * -1)), 
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * -1)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight * 2))
            );
        }
        public static Rectangle ArcUpRight()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 3)), 
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * -1)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight * 2))
            );
        }
        public static Rectangle ArcDownLeft()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * -1)), 
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 3)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight * 2))
            );
        }
        public static Rectangle ArcDownRight()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 3)), 
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 3)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight * 2))
            );
        }
        #endregion
    }
}
