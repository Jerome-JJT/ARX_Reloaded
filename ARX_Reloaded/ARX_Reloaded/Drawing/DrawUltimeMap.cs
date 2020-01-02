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
                        pictureElement.Graphics.FillRectangle(DrawMap.BackBrush, DrawMap.CaseBackground());

                        #region Case pattern drawing
                        //Create internal angles
                        if (!map.CanGoUp(DrawMap.ThisCase.Coord) && !map.CanGoRight(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillPie(DrawMap.PathBrush, DrawMap.PathInside(), 270, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, InUpRight());
                        }
                        if (!map.CanGoRight(DrawMap.ThisCase.Coord) && !map.CanGoDown(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillPie(DrawMap.PathBrush, DrawMap.PathInside(), 0, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, InDownRight());
                        }
                        if (!map.CanGoDown(DrawMap.ThisCase.Coord) && !map.CanGoLeft(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillPie(DrawMap.PathBrush, DrawMap.PathInside(), 90, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, InDownLeft());
                        }
                        if (!map.CanGoLeft(DrawMap.ThisCase.Coord) && !map.CanGoUp(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillPie(DrawMap.PathBrush, DrawMap.PathInside(), 180, 90);
                        }
                        else
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, InUpLeft());
                        }

                        //Create path between cases
                        if (map.CanGoUp(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DrawMap.PathUp());
                        }
                        if (map.CanGoRight(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DrawMap.PathRight());
                        }
                        if (map.CanGoDown(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DrawMap.PathDown());
                        }
                        if (map.CanGoLeft(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DrawMap.PathLeft());
                        }

                        //Create externals angles
                        if (map.CanGoUp(DrawMap.ThisCase.Coord) && map.CanGoRight(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, UpRightArc());
                        }
                        if (map.CanGoRight(DrawMap.ThisCase.Coord) && map.CanGoDown(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DownRightArc());
                        }
                        if (map.CanGoDown(DrawMap.ThisCase.Coord) && map.CanGoLeft(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DownLeftArc());
                        }
                        if (map.CanGoLeft(DrawMap.ThisCase.Coord) && map.CanGoUp(DrawMap.ThisCase.Coord))
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, UpLeftArc());
                        }

                        pictureElement.Graphics.FillEllipse(DrawMap.BackBrush, OutsideArc());
                        #endregion

                        if (!DrawMap.ThisCase.Accessible)
                        {
                            pictureElement.Graphics.FillPolygon(DrawMap.ContrastBrush, DrawMap.CrossPoints());
                        }
                    }

                    if (DrawMap.ThisCase.Coord == map.ExitIndex)
                    {
                        pictureElement.Graphics.FillEllipse(DrawMap.AntiBrush, new Rectangle(
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
        public static Rectangle UpLeftArc()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 0)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 0)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        public static Rectangle UpRightArc()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 3)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 0)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        public static Rectangle DownLeftArc()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 0)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 3)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        public static Rectangle DownRightArc()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 3)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 3)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }

        //Empty externals corners
        public static Rectangle OutsideArc()
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
        public static Rectangle InUpLeft()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 1)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 1)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        public static Rectangle InUpRight()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 1)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        public static Rectangle InDownLeft()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosX + DrawMap.MapPathWidth * 1)),
                Convert.ToInt32(Math.Ceiling(DrawMap.CasePosY + DrawMap.MapPathHeight * 2)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(DrawMap.MapPathHeight))
            );
        }
        public static Rectangle InDownRight()
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
