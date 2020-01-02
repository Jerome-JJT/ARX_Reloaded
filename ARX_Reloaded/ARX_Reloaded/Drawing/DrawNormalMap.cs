using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public static class DrawNormalMap
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
                        //Self path draw
                        if (DrawMap.ThisCase.State != ARX.State.Void)
                        {
                            pictureElement.Graphics.FillRectangle(DrawMap.PathBrush, DrawMap.PathInside());
                        }

                        //Externals paths draw
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
                        #endregion

                        //Cross draw
                        if(!DrawMap.ThisCase.Accessible)
                        {
                            pictureElement.Graphics.FillPolygon(DrawMap.ContrastBrush, DrawMap.CrossPoints());
                        }
                    }

                    if(DrawMap.ThisCase.Coord == map.ExitIndex)
                    {
                        pictureElement.Graphics.FillEllipse(DrawMap.AntiBrush, new Rectangle(
                            Convert.ToInt32(DrawMap.CasePosX + DrawMap.MapPathWidth * 1),
                            Convert.ToInt32(DrawMap.CasePosY + DrawMap.MapPathHeight * 1),
                            Convert.ToInt32(DrawMap.MapPathWidth * 2),
                            Convert.ToInt32(DrawMap.MapPathHeight * 2)));
                    }
                }
            }

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Red), DrawMap.PlayerPoints());
            pictureElement.Graphics.DrawPolygon(new Pen(Color.Black), DrawMap.PlayerPoints());
        }
    }
}
