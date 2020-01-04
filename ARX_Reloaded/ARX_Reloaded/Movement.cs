using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARX_Reloaded
{
    public static class Movement
    {
        private static bool canGoLeft;
        private static bool canGoRight;

        private static bool couldGoLeft;
        private static bool couldGoRight;
        private static int vision;

        public static bool CanGoLeft
        {
            get { return canGoLeft; }
        }

        public static bool CanGoRight
        {
            get { return canGoRight; }
        }

        public static bool CouldGoLeft
        {
            get { return couldGoLeft; }
        }

        public static bool CouldGoRight
        {
            get { return couldGoRight; }
        }

        public static int Vision
        {
            get { return vision; }
        }

        private static void goForward(Player player, Map map)
        {
            int playerIndex = player.Y * map.Width + player.X;

            if (player.Rotation == 0 && map.CanGoUp(playerIndex) && map.Upper(playerIndex).Accessible)
            {
                player.Y -= 1;
            }
            else if (player.Rotation == 90 && map.CanGoRight(playerIndex) && map.Righter(playerIndex).Accessible)
            {
                player.X += 1;
            }
            else if (player.Rotation == 180 && map.CanGoDown(playerIndex) && map.Lower(playerIndex).Accessible)
            {
                player.Y += 1;
            }
            else if (player.Rotation == 270 && map.CanGoLeft(playerIndex) && map.Lefter(playerIndex).Accessible)
            {
                player.X -= 1;
            }
        }

        public static void Goto(Player player, Map map, ARX.Direction direction, bool pacmanMode)
        {
            int playerIndexBefore = player.Y * map.Width + player.X;

            if (pacmanMode)
            {
                if (direction == ARX.Direction.Up)
                {
                    if (player.Rotation == 0)
                    {
                    }
                    else if (player.Rotation == 90)
                    {
                        player.Rotation = (player.Rotation + 270) % 360;
                    }
                    else if (player.Rotation == 180)
                    {
                        player.Rotation = (player.Rotation + 180) % 360;
                    }
                    else if (player.Rotation == 270)
                    {
                        player.Rotation = (player.Rotation + 90) % 360;
                    }

                    goForward(player, map);
                }
                else if (direction == ARX.Direction.Right)
                {
                    if (player.Rotation == 90)
                    { 
                    }
                    else if (player.Rotation == 180)
                    {
                        player.Rotation = (player.Rotation + 270) % 360;
                    }
                    else if (player.Rotation == 270)
                    {
                        player.Rotation = (player.Rotation + 180) % 360;
                    }
                    else if (player.Rotation == 0)
                    {
                        player.Rotation = (player.Rotation + 90) % 360;
                    }

                    goForward(player, map);
                }
                else if (direction == ARX.Direction.Down)
                {
                    if (player.Rotation == 180)
                    {
                    }
                    else if (player.Rotation == 270)
                    {
                        player.Rotation = (player.Rotation + 270) % 360;
                    }
                    else if (player.Rotation == 0)
                    {
                        player.Rotation = (player.Rotation + 180) % 360;
                    }
                    else if (player.Rotation == 90)
                    {
                        player.Rotation = (player.Rotation + 90) % 360;
                    }

                    goForward(player, map);
                }
                else if (direction == ARX.Direction.Left)
                {
                    if (player.Rotation == 270)
                    {
                    }
                    else if (player.Rotation == 0)
                    {
                        player.Rotation = (player.Rotation + 270) % 360;
                    }
                    else if (player.Rotation == 90)
                    {
                        player.Rotation = (player.Rotation + 180) % 360;
                    }
                    else if (player.Rotation == 180)
                    {
                        player.Rotation = (player.Rotation + 90) % 360;
                    }

                    goForward(player, map);
                }
            }

            else
            {
                if (direction == ARX.Direction.Up)
                {
                    if (player.Rotation == 0 && map.Upper(playerIndexBefore).Accessible)
                    {
                        goForward(player, map);
                    }
                    else if (player.Rotation == 90 && map.CanGoRight(playerIndexBefore) && map.Righter(playerIndexBefore).Accessible)
                    {
                        player.X += 1;
                    }
                    else if (player.Rotation == 180 && map.CanGoDown(playerIndexBefore) && map.Lower(playerIndexBefore).Accessible)
                    {
                        player.Y += 1;
                    }
                    else if (player.Rotation == 270 && map.CanGoLeft(playerIndexBefore) && map.Lefter(playerIndexBefore).Accessible)
                    {
                        player.X -= 1;
                    }
                }
                else if (direction == ARX.Direction.Right)
                {
                    player.Rotation = (player.Rotation + 90) % 360;
                }
                else if (direction == ARX.Direction.Down)
                {
                    if (player.Rotation == 0 && map.CanGoDown(playerIndexBefore) && map.Lower(playerIndexBefore).Accessible)
                    {
                        player.Y += 1;
                    }
                    else if (player.Rotation == 90 && map.CanGoLeft(playerIndexBefore) && map.Lefter(playerIndexBefore).Accessible)
                    {
                        player.X -= 1;
                    }
                    else if (player.Rotation == 180 && map.CanGoUp(playerIndexBefore) && map.Upper(playerIndexBefore).Accessible)
                    {
                        player.Y -= 1;
                    }
                    else if (player.Rotation == 270 && map.CanGoRight(playerIndexBefore) && map.Righter(playerIndexBefore).Accessible)
                    {
                        player.X += 1;
                    }
                }
                else if (direction == ARX.Direction.Left)
                {
                    player.Rotation = (player.Rotation + 270) % 360;
                }
            }

            int playerIndexAfter = player.Y * map.Width + player.X;

            canGoRight = false;
            canGoLeft = false;

            couldGoRight = false;
            couldGoLeft = false;

            if (player.Rotation == 0)
            {
                if (map.CanGoRight(playerIndexAfter))
                {
                    canGoRight = true;
                }

                if (map.CanGoLeft(playerIndexAfter))
                {
                    canGoLeft = true;
                }

                if (map.Upper(playerIndexAfter) != null && map.CanGoRight(map.Upper(playerIndexAfter).Coord))
                {
                    couldGoRight = true;
                }

                if (map.Upper(playerIndexAfter) != null && map.CanGoLeft(map.Upper(playerIndexAfter).Coord))
                {
                    couldGoLeft = true;
                }

                if (map.CanGoUp(playerIndexAfter))
                {
                    vision = 1;

                    if (map.Upper(playerIndexAfter) != null && map.CanGoUp(map.Upper(playerIndexAfter).Coord))
                    {
                        vision = 2;
                    }
                }
                else
                {
                    vision = 0;
                }
            }
            else if (player.Rotation == 90)
            {
                if (map.CanGoDown(playerIndexAfter))
                {
                    canGoRight = true;
                }

                if (map.CanGoUp(playerIndexAfter))
                {
                    canGoLeft = true;
                }

                if (map.Righter(playerIndexAfter) != null && map.CanGoDown(map.Righter(playerIndexAfter).Coord))
                {
                    couldGoRight = true;
                }

                if (map.Righter(playerIndexAfter) != null && map.CanGoUp(map.Righter(playerIndexAfter).Coord))
                {
                    couldGoLeft = true;
                }

                if (map.CanGoRight(playerIndexAfter))
                {
                    vision = 1;

                    if (map.CanGoRight(map.Righter(playerIndexAfter).Coord))
                    {
                        vision = 2;
                    }
                }
                else
                {
                    vision = 0;
                }
            }
            else if (player.Rotation == 180)
            {
                if (map.CanGoLeft(playerIndexAfter))
                {
                    canGoRight = true;
                }

                if (map.CanGoRight(playerIndexAfter))
                {
                    canGoLeft = true;
                }

                if (map.Lower(playerIndexAfter) != null && map.CanGoLeft(map.Lower(playerIndexAfter).Coord))
                {
                    couldGoRight = true;
                }

                if (map.Lower(playerIndexAfter) != null && map.CanGoRight(map.Lower(playerIndexAfter).Coord))
                {
                    couldGoLeft = true;
                }

                if (map.CanGoDown(playerIndexAfter))
                {
                    vision = 1;

                    if (map.Lower(playerIndexAfter) != null && map.CanGoDown(map.Lower(playerIndexAfter).Coord))
                    {
                        vision = 2;
                    }
                }
                else
                {
                    vision = 0;
                }
            }
            else
            {
                if (player.Rotation == 270)
                {
                    if (map.CanGoUp(playerIndexAfter))
                    {
                        canGoRight = true;
                    }

                    if (map.CanGoDown(playerIndexAfter))
                    {
                        canGoLeft = true;
                    }

                    if (map.Lefter(playerIndexAfter) != null && map.CanGoUp(map.Lefter(playerIndexAfter).Coord))
                    {
                        couldGoRight = true;
                    }

                    if (map.Lefter(playerIndexAfter) != null && map.CanGoDown(map.Lefter(playerIndexAfter).Coord))
                    {
                        couldGoLeft = true;
                    }

                    if (map.CanGoLeft(playerIndexAfter))
                    {
                        vision = 1;

                        if (map.Lefter(playerIndexAfter) != null && map.CanGoLeft(map.Lefter(playerIndexAfter).Coord))
                        {
                            vision = 2;
                        }
                    }
                    else
                    {
                        vision = 0;
                    }
                }
            }
        }
    }
}
