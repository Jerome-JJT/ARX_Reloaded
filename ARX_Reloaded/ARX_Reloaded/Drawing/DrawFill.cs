using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public static class DrawFill
    {
        public static void Draw()
        {
            //Create internal angles
            if (!DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord) && !DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord))
            {
                DrawMap.PictureElement.Graphics.FillPie(DrawMap.PathBrush, DrawMap.PathInside(), 270, 90);
            }
            else
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, InUpRight());
            }
            if (!DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord) && !DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord))
            {
                DrawMap.PictureElement.Graphics.FillPie(DrawMap.PathBrush, DrawMap.PathInside(), 0, 90);
            }
            else
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, InDownRight());
            }
            if (!DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord) && !DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord))
            {
                DrawMap.PictureElement.Graphics.FillPie(DrawMap.PathBrush, DrawMap.PathInside(), 90, 90);
            }
            else
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, InDownLeft());
            }
            if (!DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord) && !DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord))
            {
                DrawMap.PictureElement.Graphics.FillPie(DrawMap.PathBrush, DrawMap.PathInside(), 180, 90);
            }
            else
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, InUpLeft());
            }

            //Create path between cases
            if (DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord))
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DrawMap.PathUp());
            }
            if (DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord))
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DrawMap.PathRight());
            }
            if (DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord))
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DrawMap.PathDown());
            }
            if (DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord))
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DrawMap.PathLeft());
            }

            //Create externals angles
            if (DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord))
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, UpRightArc());
            }
            if (DrawMap.Map.CanGoRight(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord))
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DownRightArc());
            }
            if (DrawMap.Map.CanGoDown(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord))
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DownLeftArc());
            }
            if (DrawMap.Map.CanGoLeft(DrawMap.ThisCase.Coord) && DrawMap.Map.CanGoUp(DrawMap.ThisCase.Coord))
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, UpLeftArc());
            }

            DrawMap.PictureElement.Graphics.FillEllipse(DrawMap.BackBrush, OutsideArc());
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
