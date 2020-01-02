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
        static public double MapDrawLengthX;
        static public double MapDrawLengthY;

        static public Point MapDrawStart = new Point();
        static public Point MapDrawStop = new Point();

        static public double MapCaseWidth;
        static public double MapCaseHeight;

        static public double MapPathWidth;
        static public double MapPathHeight;

        static public Map Map;
        static public Player Player;


        static public Case ThisCase;
        static public double CasePosX;
        static public double CasePosY;

        static public SolidBrush PathColor;
        static public SolidBrush BackColor;
        static public SolidBrush AntiColor;
        static public SolidBrush ContrastColor;


        public static void PrepareMap(PaintEventArgs pictureElement, Size picBoxSize, Map map, int type, Player player, int zoom)
        {
            Player = player;
            Map = map;

            MapDrawLengthX = (double)map.Width / zoom;
            MapDrawLengthY = (double)map.Height / zoom;


            MapDrawStart.X = (int)Math.Ceiling(((int)(player.X / MapDrawLengthX)) * MapDrawLengthX);
            MapDrawStart.Y = (int)Math.Ceiling(((int)(player.Y / MapDrawLengthY)) * MapDrawLengthY);

            MapDrawStop.X = Math.Min(map.Width, (int)Math.Ceiling(((int)(player.X / MapDrawLengthX + 1)) * MapDrawLengthX));
            MapDrawStop.Y = Math.Min(map.Height, (int)Math.Ceiling(((int)(player.Y / MapDrawLengthY + 1)) * MapDrawLengthY));


            MapCaseWidth = (double)picBoxSize.Width / (MapDrawStop.X - MapDrawStart.X);
            MapCaseHeight = (double)picBoxSize.Height / (MapDrawStop.Y - MapDrawStart.Y);

            MapPathWidth = MapCaseWidth / 4.0;
            MapPathHeight = MapCaseHeight / 4.0;

        }

        public static void PrepareCase(int indexX, int indexY)
        {
            CasePosX = (indexX - MapDrawStart.X) * MapCaseWidth;
            CasePosY = (indexY - MapDrawStart.Y) * MapCaseHeight;

            ThisCase = Map.Self(indexY * Map.Width + indexX);
            PathColor = new SolidBrush(ThisCase.ZoneColor);
            BackColor = new SolidBrush(Color.Black);
            AntiColor = new SolidBrush(ThisCase.AntiColor);
            ContrastColor = new SolidBrush(ThisCase.ContrastColor);
        }

        #region Create map patterns
        static public Rectangle CaseBackground()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(CasePosX + MapPathWidth* 0)),
                Convert.ToInt32(Math.Ceiling(CasePosY + MapPathHeight* 0)),
                Convert.ToInt32(Math.Ceiling(MapPathWidth* 4)), 
                Convert.ToInt32(Math.Ceiling(MapPathHeight* 4))
            );
        }

        static public Rectangle PathUp()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(CasePosX + MapPathWidth * 1)),
                Convert.ToInt32(Math.Ceiling(CasePosY + MapPathHeight * 0)),
                Convert.ToInt32(Math.Ceiling(MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(MapPathHeight))
            );
        }

        static public Rectangle PathRight()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(CasePosX + MapPathWidth * 3)),
                Convert.ToInt32(Math.Ceiling(CasePosY + MapPathHeight * 1)),
                Convert.ToInt32(Math.Ceiling(MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(MapPathHeight * 2))
            );
        }

        static public Rectangle PathDown()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(CasePosX + MapPathWidth * 1)),
                Convert.ToInt32(Math.Ceiling(CasePosY + MapPathHeight * 3)),
                Convert.ToInt32(Math.Ceiling(MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(MapPathHeight))
            );
        }

        static public Rectangle PathLeft()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(CasePosX + MapPathWidth * 0)),
                Convert.ToInt32(Math.Ceiling(CasePosY + MapPathHeight * 1)),
                Convert.ToInt32(Math.Ceiling(MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(MapPathHeight * 2))
            );
        }

        static public Rectangle PathInside()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(CasePosX + MapPathWidth * 1)),
                Convert.ToInt32(Math.Ceiling(CasePosY + MapPathHeight * 1)),
                Convert.ToInt32(Math.Ceiling(MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(MapPathHeight * 2))
            );
        }
        #endregion Create map patterns

        #region Create events patterns
        static public Point[] CrossPoints()
        {
            return new Point[] {
                new Point(Convert.ToInt32(CasePosX+MapPathWidth*2.0),   Convert.ToInt32(CasePosY+MapPathHeight*1.8)),

                new Point(Convert.ToInt32(CasePosX+MapPathWidth*2.5),   Convert.ToInt32(CasePosY+MapPathHeight*1.3)),
                new Point(Convert.ToInt32(CasePosX+MapPathWidth*2.7),   Convert.ToInt32(CasePosY+MapPathHeight*1.5)),
                                                                                         
                new Point(Convert.ToInt32(CasePosX+MapPathWidth*2.2),   Convert.ToInt32(CasePosY+MapPathHeight*2.0)),
                                                                                     
                new Point(Convert.ToInt32(CasePosX+MapPathWidth*2.7),   Convert.ToInt32(CasePosY+MapPathHeight*2.5)),
                new Point(Convert.ToInt32(CasePosX+MapPathWidth*2.5),   Convert.ToInt32(CasePosY+MapPathHeight*2.7)),
                                                                            
                new Point(Convert.ToInt32(CasePosX+MapPathWidth*2),     Convert.ToInt32(CasePosY+MapPathHeight*2.2)),
                                                                               
                new Point(Convert.ToInt32(CasePosX+MapPathWidth*1.5),   Convert.ToInt32(CasePosY+MapPathHeight*2.7)),
                new Point(Convert.ToInt32(CasePosX+MapPathWidth*1.3),   Convert.ToInt32(CasePosY+MapPathHeight*2.5)),
                                                            
                new Point(Convert.ToInt32(CasePosX+MapPathWidth*1.8),   Convert.ToInt32(CasePosY+MapPathHeight*2.0)),

                new Point(Convert.ToInt32(CasePosX+MapPathWidth*1.3),   Convert.ToInt32(CasePosY+MapPathHeight*1.5)),
                new Point(Convert.ToInt32(CasePosX+MapPathWidth*1.5),   Convert.ToInt32(CasePosY+MapPathHeight*1.3))
            };
        }
        #endregion

        #region Create player pattern
        static public Point[] PlayerPoints()
        {
            Point[] playerCursor = new Point[] { };

            double playerCaseX = (Player.X - MapDrawStart.X) * MapCaseWidth;
            double playerCaseY = (Player.Y - MapDrawStart.Y) * MapCaseHeight;

            if (Player.Rotation == 0)
            {
                return new Point[] {
                    new Point(Convert.ToInt32(playerCaseX + MapPathWidth*2.0), Convert.ToInt32(playerCaseY + MapPathHeight*1.2)),
                    new Point(Convert.ToInt32(playerCaseX + MapPathWidth*1.3), Convert.ToInt32(playerCaseY + MapPathHeight*2.9)),
                    new Point(Convert.ToInt32(playerCaseX + MapPathWidth*2.7), Convert.ToInt32(playerCaseY + MapPathHeight*2.9))
                };
            }
            else if (Player.Rotation == 90)
            {
                return new Point[] {
                    new Point(Convert.ToInt32(playerCaseX + MapPathWidth*2.8), Convert.ToInt32(playerCaseY + MapPathHeight*2.0)),
                    new Point(Convert.ToInt32(playerCaseX + MapPathWidth*1.1), Convert.ToInt32(playerCaseY + MapPathHeight*1.3)),
                    new Point(Convert.ToInt32(playerCaseX + MapPathWidth*1.1), Convert.ToInt32(playerCaseY + MapPathHeight*2.7))
                };
            }
            else if (Player.Rotation == 180)
            {
                return new Point[] {
                    new Point(Convert.ToInt32(playerCaseX + MapPathWidth*2.0), Convert.ToInt32(playerCaseY + MapPathHeight*2.8)),
                    new Point(Convert.ToInt32(playerCaseX + MapPathWidth*1.3), Convert.ToInt32(playerCaseY + MapPathHeight*1.1)),
                    new Point(Convert.ToInt32(playerCaseX + MapPathWidth*2.7), Convert.ToInt32(playerCaseY + MapPathHeight*1.1))
                };
            }
            else if (Player.Rotation == 270)
            {
                return new Point[] {
                    new Point(Convert.ToInt32(playerCaseX + MapPathWidth*1.2), Convert.ToInt32(playerCaseY + MapPathHeight*2.0)),
                    new Point(Convert.ToInt32(playerCaseX + MapPathWidth*2.9), Convert.ToInt32(playerCaseY + MapPathHeight*1.3)),
                    new Point(Convert.ToInt32(playerCaseX + MapPathWidth*2.9), Convert.ToInt32(playerCaseY + MapPathHeight*2.7))
                };
            }

            return null;
        }
        #endregion
    }
}
