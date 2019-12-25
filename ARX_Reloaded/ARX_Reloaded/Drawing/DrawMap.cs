using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public static class DrawMap
    {
        

        private static List<string> colorValues = new List<string> {
            "00ffff", "0000ff", "a52a2a", "00008b", "008b8b", "c0c0c0",
            "006400", "bdb76b", "556b2f", "ff8c00", "8b0000", "00ff00",
            "e9967a", "9400d3", "ffd700", "008000", "4b0082",
            "ff00ff", "800000", "808000", "ffc0cb", "ff0000"
        };
        
        public static void ShuffleColors(Random randColors)
        {
            Calculus.Shuffle(randColors, colorValues);
        }

        public static void DrawTotalMap(PaintEventArgs pictureElement, Size picBoxSize, Map map, Player player, int zoom)
        {
            double mapDrawLengthX;
            double mapDrawLengthY;

            int mapDrawStartX;
            int mapDrawStartY;
            int mapDrawStopX;
            int mapDrawStopY;

            double mapCaseWidth;
            double mapCaseHeight;

            double mapPathWidth;
            double mapPathHeight;

            mapDrawLengthX = (double)map.Width  / zoom;
            mapDrawLengthY = (double)map.Height / zoom;

            //mapDrawStartX = Math.Floor(player.X / Math.Ceiling(map.Width / (double)zoom)) * Math.Ceiling();
            //mapDrawStartY = Math.Floor(player.Y / Math.Ceiling(map.Height / (double)zoom)) * Math.Ceiling();

            mapDrawStartX = (int)Math.Ceiling(((int)(player.X / mapDrawLengthX)) * mapDrawLengthX);
            mapDrawStartY = (int)Math.Ceiling(((int)(player.Y / mapDrawLengthY)) * mapDrawLengthY);

            //mapDrawStopX = Math.Min(map.Width, Math.Round(mapDrawStartX + (map.Width / (double)zoom)));
            //mapDrawStopY = Math.Min(map.Height, Math.Round(mapDrawStartY + (map.Height / (double)zoom)));

            mapDrawStopX = Math.Min(map.Width,  (int)Math.Ceiling(((int)(player.X / mapDrawLengthX + 1)) * mapDrawLengthX));
            mapDrawStopY = Math.Min(map.Height, (int)Math.Ceiling(((int)(player.Y / mapDrawLengthY + 1)) * mapDrawLengthY));

            mapCaseWidth  = picBoxSize.Width / (mapDrawStopX - mapDrawStartX);
            mapCaseHeight = picBoxSize.Height / (mapDrawStopY - mapDrawStartY);

            mapPathWidth = mapCaseWidth / 4;
            mapPathHeight = mapCaseHeight / 4;

            for (int h = mapDrawStartY; h < mapDrawStopY; h++)
            {
                for (int w = mapDrawStartX; w < mapDrawStopX; w++)
                {
                    Point[] upMiddle = {
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*1))
                    };


                    Point[] middleLeft = {
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*3))
                    };

                    Point[] middleMiddle = {
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*3))
                    };

                    Point[] middleRight = {
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*4),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*4),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*3))
                    };

                    
                    Point[] downMiddle = {
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*4)),
                        new Point(Convert.ToInt32((w-mapDrawStartX)*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32((h-mapDrawStartY)*mapCaseHeight+mapPathHeight*4))
                    };

                    Color pathColor;

                    if (map.Cases[h * map.Width + w].Zone == 0)
                    {
                        pathColor = Color.White;
                    }
                    else
                    {
                        pathColor = Color.FromArgb(int.Parse($"FF{colorValues[(map.Cases[h * map.Width + w].Zone - 1) % colorValues.Count]}", System.Globalization.NumberStyles.HexNumber));
                    }

                    if (map.Cases[h * map.Width + w].Visited == true)
                    {
                        if (map.Cases[h * map.Width + w].State != 0)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleMiddle);
                        }

                        if (map.Cases[h * map.Width + w].State == 2)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleRight);
                        }
                        else if (map.Cases[h * map.Width + w].State == 3)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), downMiddle);
                        }
                        else if (map.Cases[h * map.Width + w].State == 4)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleRight);
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), downMiddle);
                        }

                        if (w > 0 && map.Cases[h * map.Width + w].State != 0 &&
                            (map.Cases[h * map.Width + w - 1].State == 2 || map.Cases[h * map.Width + w - 1].State == 4))
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleLeft);
                        }
                        if (h > 0 && map.Cases[h * map.Width + w].State != 0 &&
                            (map.Cases[h * map.Width + w - map.Width].State == 3 || map.Cases[h * map.Width + w - map.Width].State == 4))
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), upMiddle);
                        }
                    }
                }
            }

            Point[] playerCursor = new Point[] { };

            if (player.Rotation == 0)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32((player.X-mapDrawStartX)*mapCaseWidth + mapPathWidth*2.0), Convert.ToInt32((player.Y-mapDrawStartY)*mapCaseHeight + mapPathHeight*1.2)),
                    new Point(Convert.ToInt32((player.X-mapDrawStartX)*mapCaseWidth + mapPathWidth*1.3), Convert.ToInt32((player.Y-mapDrawStartY)*mapCaseHeight + mapPathHeight*2.9)),
                    new Point(Convert.ToInt32((player.X-mapDrawStartX)*mapCaseWidth + mapPathWidth*2.7), Convert.ToInt32((player.Y-mapDrawStartY)*mapCaseHeight + mapPathHeight*2.9))
                };
            }
            else if (player.Rotation == 90)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32((player.X-mapDrawStartX)*mapCaseWidth + mapPathWidth*2.8), Convert.ToInt32((player.Y-mapDrawStartY)*mapCaseHeight + mapPathHeight*2.0)),
                    new Point(Convert.ToInt32((player.X-mapDrawStartX)*mapCaseWidth + mapPathWidth*1.1), Convert.ToInt32((player.Y-mapDrawStartY)*mapCaseHeight + mapPathHeight*1.3)),
                    new Point(Convert.ToInt32((player.X-mapDrawStartX)*mapCaseWidth + mapPathWidth*1.1), Convert.ToInt32((player.Y-mapDrawStartY)*mapCaseHeight + mapPathHeight*2.7))
                };
            }
            else if (player.Rotation == 180)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32((player.X-mapDrawStartX)*mapCaseWidth + mapPathWidth*2.0), Convert.ToInt32((player.Y-mapDrawStartY)*mapCaseHeight + mapPathHeight*2.8)),
                    new Point(Convert.ToInt32((player.X-mapDrawStartX)*mapCaseWidth + mapPathWidth*1.3), Convert.ToInt32((player.Y-mapDrawStartY)*mapCaseHeight + mapPathHeight*1.1)),
                    new Point(Convert.ToInt32((player.X-mapDrawStartX)*mapCaseWidth + mapPathWidth*2.7), Convert.ToInt32((player.Y-mapDrawStartY)*mapCaseHeight + mapPathHeight*1.1))
                };
            }
            else if (player.Rotation == 270)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32((player.X-mapDrawStartX)*mapCaseWidth + mapPathWidth*1.2), Convert.ToInt32((player.Y-mapDrawStartY)*mapCaseHeight + mapPathHeight*2.0)),
                    new Point(Convert.ToInt32((player.X-mapDrawStartX)*mapCaseWidth + mapPathWidth*2.9), Convert.ToInt32((player.Y-mapDrawStartY)*mapCaseHeight + mapPathHeight*1.3)),
                    new Point(Convert.ToInt32((player.X-mapDrawStartX)*mapCaseWidth + mapPathWidth*2.9), Convert.ToInt32((player.Y-mapDrawStartY)*mapCaseHeight + mapPathHeight*2.7))
                };
            }

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Red), playerCursor);
            pictureElement.Graphics.DrawPolygon(new Pen(Color.Black), playerCursor);
        }
    }
}
