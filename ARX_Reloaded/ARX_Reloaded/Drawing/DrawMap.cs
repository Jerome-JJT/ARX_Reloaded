using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public class DrawMap
    {
        private PaintEventArgs pictureElement;
        private Player player;

        private int pictureWidth;
        private int pictureHeight;

        private int mapLengthX;
        private int mapLengthY;

        private double mapCaseWidth;
        private double mapCaseHeight;

        private double mapPathWidth;
        private double mapPathHeight;

        Random shuffleColors;

        /*private static List<string> colorValues = new List<string> { "FFFFFF",
            "FF0000", "00FF00", "0000FF", "FFFF00", "FF00FF", "00FFFF",
            "800000", "008000", "000080", "808000", "800080", "008080", "808080",
            "C00000", "00C000", "0000C0", "C0C000", "C000C0", "00C0C0", "C0C0C0",
            "400000", "004000", "000040", "404000", "400040", "004040", "404040",
            "200000", "002000", "000020", "202000", "200020", "002020", "202020",
            "600000", "006000", "000060", "606000", "600060", "006060", "606060",
            "A00000", "00A000", "0000A0", "A0A000", "A000A0", "00A0A0", "A0A0A0",
            "E00000", "00E000", "0000E0", "E0E000", "E000E0", "00E0E0", "E0E0E0"
        };*/

        /*private List<string> colorValues = new List<string> {
            "FF0000", "00FF00", "0000FF", "FFFF00", "FF00FF", "00FFFF",
            "008000", "000080", "800080", "008080", "808080",
            "C00000", "00C000", "C0C000", "C000C0", "00C0C0",
            "400000", "004000", "000040", "404000", "400040", "004040",
            "E00000", "00E000", "0000E0", "E0E000", "E000E0", "00E0E0"
        };*/

        private List<string> colorValues = new List<string> {
            "00ffff", "0000ff", "a52a2a", "00008b", "008b8b", "c0c0c0",
            "006400", "bdb76b", "556b2f", "ff8c00", "8b0000", "00ff00",
            "e9967a", "9400d3", "ffd700", "008000", "4b0082",
            "ff00ff", "800000", "808000", "ffc0cb", "ff0000"
        };
        

        public DrawMap(Size picBoxSize, Player player, Random randColors)
        {
            pictureWidth = picBoxSize.Width;
            pictureHeight = picBoxSize.Height;

            this.player = player;

            shuffleColors = randColors;
            Calculus.Shuffle(shuffleColors, colorValues);
        }

        public void ShuffleColors()
        {
            Calculus.Shuffle(shuffleColors, colorValues);
        }

        public void DrawTotalMap(PaintEventArgs elem, Map map)
        {
            pictureElement = elem;

            mapLengthX = map.Width;
            mapLengthY = map.Height;

            mapCaseWidth = pictureWidth / mapLengthX;
            mapCaseHeight = pictureHeight / mapLengthY;

            mapPathWidth = mapCaseWidth / 4;
            mapPathHeight = mapCaseHeight / 4;

            for (int h = 0; h < mapLengthY; h++)
            {
                for (int w = 0; w < mapLengthX; w++)
                {
                    Point[] upMiddle = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*0)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1))
                    };


                    Point[] middleLeft = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*0),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3))
                    };

                    Point[] middleMiddle = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3))
                    };

                    Point[] middleRight = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*4),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*1)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*4),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3))
                    };

                    
                    Point[] downMiddle = {
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*3)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*3),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*4)),
                        new Point(Convert.ToInt32(w*mapCaseWidth+mapPathWidth*1),   Convert.ToInt32(h*mapCaseHeight+mapPathHeight*4))
                    };

                    Color pathColor;

                    if (map.Cases[h * mapLengthX + w].Zone == 0)
                    {
                        pathColor = Color.White;
                    }
                    else
                    {
                        pathColor = Color.FromArgb(int.Parse($"FF{colorValues[(map.Cases[h * mapLengthX + w].Zone - 1) % colorValues.Count]}", System.Globalization.NumberStyles.HexNumber));
                    }

                    if (map.Cases[h * mapLengthX + w].Visited == true)
                    {
                        if (map.Cases[h * mapLengthX + w].State != 0)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleMiddle);
                        }

                        if (map.Cases[h * mapLengthX + w].State == 2)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleRight);
                        }
                        else if (map.Cases[h * mapLengthX + w].State == 3)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), downMiddle);
                        }
                        else if (map.Cases[h * mapLengthX + w].State == 4)
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleRight);
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), downMiddle);
                        }

                        if (w > 0 && map.Cases[h * mapLengthX + w].State != 0 &&
                            (map.Cases[h * mapLengthX + w - 1].State == 2 || map.Cases[h * mapLengthX + w - 1].State == 4))
                        {
                            pictureElement.Graphics.FillPolygon(new SolidBrush(pathColor), middleLeft);
                        }
                        if (h > 0 && map.Cases[h * mapLengthX + w].State != 0 &&
                            (map.Cases[h * mapLengthX + w - mapLengthX].State == 3 || map.Cases[h * mapLengthX + w - mapLengthX].State == 4))
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
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*1.2)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*1.3), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2.9)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2.7), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2.9))
                };
            }
            else if (player.Rotation == 90)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2.8), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*1.1), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*1.3)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*1.1), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2.7))
                };
            }
            else if (player.Rotation == 180)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2.8)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*1.3), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*1.1)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2.7), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*1.1))
                };
            }
            else if (player.Rotation == 270)
            {
                playerCursor = new Point[] {
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*1.2), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2.9), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*1.3)),
                    new Point(Convert.ToInt32(player.X*mapCaseWidth + mapPathWidth*2.9), Convert.ToInt32(player.Y*mapCaseHeight + mapPathHeight*2.7))
                };
            }

            pictureElement.Graphics.FillPolygon(new SolidBrush(Color.Red), playerCursor);
        }
    }
}
