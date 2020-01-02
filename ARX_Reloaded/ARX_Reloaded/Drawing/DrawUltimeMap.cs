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
            for (int h = DrawMap.MapDrawStart.Y; h < DrawMap.MapDrawStop.Y; h++)
            {
                for (int w = DrawMap.MapDrawStart.X; w < DrawMap.MapDrawStop.X; w++)
                {
                    DrawMap.PrepareCase(w, h);

                    if (DrawMap.ThisCase.Visited == true)
                    {
                        pictureElement.Graphics.FillRectangle(DrawMap.BackColor, DrawMap.CaseBackground());

                        #region Case pattern drawing
                        //Create internal angles
                        if (!map.CanGoUp(DrawMap.ThisCase.Coord) && !map.CanGoRight(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillPie(DrawMap.PathColor, DrawMap.PathInside(), 270, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathColor, InUpRight());
                        }
                        if (!map.CanGoRight(DrawMap.ThisCase.Coord) && !map.CanGoDown(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillPie(DrawMap.PathColor, DrawMap.PathInside(), 0, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathColor, InDownRight());
                        }
                        if (!map.CanGoDown(DrawMap.ThisCase.Coord) && !map.CanGoLeft(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillPie(DrawMap.PathColor, DrawMap.PathInside(), 90, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathColor, InDownLeft());
                        }
                        if (!map.CanGoLeft(DrawMap.ThisCase.Coord) && !map.CanGoUp(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillPie(DrawMap.PathColor, DrawMap.PathInside(), 180, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathColor, InUpLeft());
                        }

                        //Create path between cases
                        if (map.CanGoUp(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathColor, DrawMap.PathUp());
                        }
                        if (map.CanGoRight(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathColor, DrawMap.PathRight());
                        }
                        if (map.CanGoDown(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathColor, DrawMap.PathDown());
                        }
                        if (map.CanGoLeft(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathColor, DrawMap.PathLeft());
                        }

                        //Create externals angles
                        if (map.CanGoUp(DrawMap.ThisCase.Coord) && map.CanGoRight(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathColor, UpRightArc());
                        }
                        if (map.CanGoRight(DrawMap.ThisCase.Coord) && map.CanGoDown(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathColor, DownRightArc());
                        }
                        if (map.CanGoDown(DrawMap.ThisCase.Coord) && map.CanGoLeft(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathColor, DownLeftArc());
                        }
                        if (map.CanGoLeft(DrawMap.ThisCase.Coord) && map.CanGoUp(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathColor, UpLeftArc());
                        }

                        pictureElement.Graphics.FillEllipse(DrawMap.BackColor, OutsideArc());
                        #endregion

                        if (!DrawMap.ThisCase.Accessible)
                        {
                            pictureElement.Graphics.FillPolygon(DrawMap.ContrastColor, DrawMap.CrossPoints());
                        }
                    }

                    if (DrawMap.ThisCase.Coord == map.ExitIndex)
                    {
                        pictureElement.Graphics.FillEllipse(DrawMap.AntiColor, new Rectangle(
                            Convert.ToInt32(DrawMap.CasePosX + DrawMap.MapPathWidth * 1),
                            Convert.ToInt32(DrawMap.CasePosY + DrawMap.MapPathHeight * 1),
                            Convert.ToInt32(DrawMap.MapPathWidth * 2),
                            Convert.ToInt32(DrawMap.MapPathHeight * 2)));
                    }

                    /*pictureElement.Graphics.DrawString(thisCase.Zone.ToString(), new Font(new FontFamily("Arial"), 8), contrastColor, new Rectangle(
                            Convert.ToInt32(DrawMap.CasePosX + DrawMap.MapPathWidth * 0.8),
                            Convert.ToInt32(DrawMap.CasePosY + DrawMap.MapPathHeight * 0.6),
                            Convert.ToInt32(DrawMap.MapPathWidth * 3),
                            Convert.ToInt32(DrawMap.MapPathHeight * 3)));*/
                }
            }


            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Red), DrawMap.PlayerPoints());
            pictureElement.Graphics.DrawPolygon(new Pen(Color.Black), DrawMap.PlayerPoints());
        }

        #region ARC drawing
        static public Rectangle UpLeftArc()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 0)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 0)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        static public Rectangle UpRightArc()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 3)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 0)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        static public Rectangle DownLeftArc()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 0)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 3)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        static public Rectangle DownRightArc()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 3)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 3)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }

        //Empty externals corners
        static public Rectangle OutsideArc()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * -1)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * -1)),
                Convert.ToInt32(Math.Floor(DrawMap.MapPathWidth * 2)),
                Convert.ToInt32(Math.Floor(DrawMap.MapPathHeight * 2))
            );
        }
        #endregion

        #region Inside paths drawing
        static public Rectangle InUpLeft()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 1)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 1)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        static public Rectangle InUpRight()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 1)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        static public Rectangle InDownLeft()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 1)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 2)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        static public Rectangle InDownRight()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 2)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        #endregion
    }
}
