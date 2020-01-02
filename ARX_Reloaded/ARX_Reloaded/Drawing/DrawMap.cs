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
        public static double MapDrawLengthX;
        public static double MapDrawLengthY;

        public static Point MapDrawStart = new Point();
        public static Point MapDrawStop = new Point();

        public static double MapCaseWidth;
        public static double MapCaseHeight;

        public static double MapPathWidth;
        public static double MapPathHeight;

        public static Map Map;
        public static Player Player;


        public static Case ThisCase;
        public static double CasePosX;
        public static double CasePosY;

        public static Pen PathPen;
        public static SolidBrush PathBrush;
        public static SolidBrush BackBrush;
        public static SolidBrush AntiBrush;
        public static SolidBrush ContrastBrush;


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

            PathBrush = new SolidBrush(ThisCase.ZoneColor);
            PathPen = new Pen(ThisCase.ZoneColor);
            BackBrush = new SolidBrush(Color.Black);
            AntiBrush = new SolidBrush(ThisCase.AntiColor);
            ContrastBrush = new SolidBrush(ThisCase.ContrastColor);
        }

        #region Create map patterns
        public static Rectangle CaseBackground()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(CasePosX + MapPathWidth * 0)),
                Convert.ToInt32(Math.Ceiling(CasePosY + MapPathHeight * 0)),
                Convert.ToInt32(Math.Ceiling(MapPathWidth * 4)), 
                Convert.ToInt32(Math.Ceiling(MapPathHeight * 4))
            );
        }

        public static Rectangle PathUp()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(CasePosX + MapPathWidth * 1)),
                Convert.ToInt32(Math.Ceiling(CasePosY + MapPathHeight * 0)),
                Convert.ToInt32(Math.Ceiling(MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(MapPathHeight))
            );
        }

        public static Rectangle PathRight()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(CasePosX + MapPathWidth * 3)),
                Convert.ToInt32(Math.Ceiling(CasePosY + MapPathHeight * 1)),
                Convert.ToInt32(Math.Ceiling(MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(MapPathHeight * 2))
            );
        }

        public static Rectangle PathDown()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(CasePosX + MapPathWidth * 1)),
                Convert.ToInt32(Math.Ceiling(CasePosY + MapPathHeight * 3)),
                Convert.ToInt32(Math.Ceiling(MapPathWidth * 2)),
                Convert.ToInt32(Math.Ceiling(MapPathHeight))
            );
        }

        public static Rectangle PathLeft()
        {
            return new Rectangle(
                Convert.ToInt32(Math.Ceiling(CasePosX + MapPathWidth * 0)),
                Convert.ToInt32(Math.Ceiling(CasePosY + MapPathHeight * 1)),
                Convert.ToInt32(Math.Ceiling(MapPathWidth)),
                Convert.ToInt32(Math.Ceiling(MapPathHeight * 2))
            );
        }

        public static Rectangle PathInside()
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
        public static Point[] CrossPoints()
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
        public static Point[] PlayerPoints()
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
