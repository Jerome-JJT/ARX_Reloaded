using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public static class DrawNormal
    {
        public static void Draw()
        {
            //Self path draw
            if (DrawMap.ThisCase.State != ARX.State.Void)
            {
                DrawMap.PictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DrawMap.PathInside());
            }

            //Externals paths draw
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
        }
    }
}
