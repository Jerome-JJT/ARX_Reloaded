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

        private static void goForward(ref Player player, Map map)
        {
            if (player.Rotation == 0 && player.Y > 0 &&
                (map.upper(player.Y * map.Width + player.X).State == ARX.State.Down ||
                 map.upper(player.Y * map.Width + player.X).State == ARX.State.Cross))
            {
                player.Y -= 1;
            }
            else if (player.Rotation == 90 && player.X < map.Width &&
                (map.self(player.Y * map.Width + player.X).State == ARX.State.Right ||
                 map.self(player.Y * map.Width + player.X).State == ARX.State.Cross))
            {
                player.X += 1;
            }
            else if (player.Rotation == 180 && player.Y < map.Height &&
                (map.self(player.Y * map.Width + player.X).State == ARX.State.Down ||
                 map.self(player.Y * map.Width + player.X).State == ARX.State.Cross))
            {
                player.Y += 1;
            }
            else if (player.Rotation == 270 && player.X > 0 &&
                (map.lefter(player.Y * map.Width + player.X).State == ARX.State.Right ||
                 map.lefter(player.Y * map.Width + player.X).State == ARX.State.Cross))
            {
                player.X -= 1;
            }
        }

        public static void Goto(ref Player player, Map map, string direction, bool pacmanMode)
        {
            if (pacmanMode)
            {
                if (direction == "up")
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

                    goForward(ref player, map);
                }
                else if (direction == "right")
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

                    goForward(ref player, map);
                }
                else if (direction == "down")
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

                    goForward(ref player, map);
                }
                else if (direction == "left")
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

                    goForward(ref player, map);
                }
            }

            else
            {
                if (direction == "up")
                {
                    if (player.Rotation == 0)
                    {
                        goForward(ref player, map);
                    }
                    else if (player.Rotation == 90 && player.X < map.Width &&
                        (map.Cases[player.Y * map.Width + player.X].State == ARX.State.Right ||
                         map.Cases[player.Y * map.Width + player.X].State == ARX.State.Cross))
                    {
                        player.X += 1;
                    }
                    else if (player.Rotation == 180 && player.Y < map.Height &&
                        (map.Cases[player.Y * map.Width + player.X].State == ARX.State.Down ||
                         map.Cases[player.Y * map.Width + player.X].State == ARX.State.Cross))
                    {
                        player.Y += 1;
                    }
                    else if (player.Rotation == 270 && player.X > 0 &&
                        (map.Cases[player.Y * map.Width + player.X - 1].State == ARX.State.Right ||
                         map.Cases[player.Y * map.Width + player.X - 1].State == ARX.State.Cross))
                    {
                        player.X -= 1;
                    }
                }
                else if (direction == "right")
                {
                    player.Rotation = (player.Rotation + 90) % 360;
                }
                else if (direction == "down")
                {
                    if (player.Rotation == 0 && player.Y < map.Height &&
                        (map.Cases[player.Y * map.Width + player.X].State == ARX.State.Down ||
                         map.Cases[player.Y * map.Width + player.X].State == ARX.State.Cross))
                    {
                        player.Y += 1;
                    }
                    else if (player.Rotation == 90 && player.X > 0 &&
                        (map.Cases[player.Y * map.Width + player.X - 1].State == ARX.State.Right ||
                         map.Cases[player.Y * map.Width + player.X - 1].State == ARX.State.Cross))
                    {
                        player.X -= 1;
                    }
                    else if (player.Rotation == 180 && player.Y > 0 &&
                        (map.Cases[player.Y * map.Width + player.X - map.Width].State == ARX.State.Down ||
                         map.Cases[player.Y * map.Width + player.X - map.Width].State == ARX.State.Cross))
                    {
                        player.Y -= 1;
                    }
                    else if (player.Rotation == 270 && player.Y < map.Width &&
                        (map.Cases[player.Y * map.Width + player.X].State == ARX.State.Right ||
                         map.Cases[player.Y * map.Width + player.X].State == ARX.State.Cross))
                    {
                        player.X += 1;
                    }
                }
                else if (direction == "left")
                {
                    player.Rotation = (player.Rotation + 270) % 360;
                }
            }

            canGoRight = false;
            canGoLeft = false;

            couldGoRight = false;
            couldGoLeft = false;

            if (player.Rotation == 0)
            {
                if ((map.Cases[player.Y * map.Width + player.X].State == ARX.State.Right 
                    || map.Cases[player.Y * map.Width + player.X].State == ARX.State.Cross))
                {
                    canGoRight = true;
                }

                if (player.X > 0 &&
                    (map.Cases[player.Y * map.Width + player.X - 1].State == ARX.State.Right 
                    || map.Cases[player.Y * map.Width + player.X - 1].State == ARX.State.Cross))
                {
                    canGoLeft = true;
                }

                if (player.Y > 0 &&
                    (map.Cases[player.Y * map.Width + player.X - map.Width].State == ARX.State.Right 
                    || map.Cases[player.Y * map.Width + player.X - map.Width].State == ARX.State.Cross))
                {
                    couldGoRight = true;
                }

                if (player.X > 0 && player.Y > 0 &&
                    (map.Cases[player.Y * map.Width + player.X - map.Width - 1].State == ARX.State.Right 
                    || map.Cases[player.Y * map.Width + player.X - map.Width - 1].State == ARX.State.Cross))
                {
                    couldGoLeft = true;
                }

                if (player.Y > 0 &&
                    (map.Cases[player.Y * map.Width + player.X - map.Width].State == ARX.State.Down 
                    || map.Cases[player.Y * map.Width + player.X - map.Width].State == ARX.State.Cross))
                {
                    vision = 1;

                    if (player.Y > 1 &&
                    (map.Cases[player.Y * map.Width + player.X - map.Width * 2].State == ARX.State.Down 
                    || map.Cases[player.Y * map.Width + player.X - map.Width * 2].State == ARX.State.Cross))
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
                if ((map.Cases[player.Y * map.Width + player.X].State == ARX.State.Down 
                    || map.Cases[player.Y * map.Width + player.X].State == ARX.State.Cross))
                {
                    canGoRight = true;
                }

                if (player.Y > 0 &&
                    (map.Cases[player.Y * map.Width + player.X - map.Width].State == ARX.State.Down 
                    || map.Cases[player.Y * map.Width + player.X - map.Width].State == ARX.State.Cross))
                {
                    canGoLeft = true;
                }

                if (player.X < map.Width - 1 && 
                    (map.Cases[player.Y * map.Width + player.X + 1].State == ARX.State.Down 
                    || map.Cases[player.Y * map.Width + player.X + 1].State == ARX.State.Cross))
                {
                    couldGoRight = true;
                }

                if (player.X < map.Width - 1 && player.Y > 0 &&
                    (map.Cases[player.Y * map.Width + player.X - map.Width + 1].State == ARX.State.Down 
                    || map.Cases[player.Y * map.Width + player.X - map.Width + 1].State == ARX.State.Cross))
                {
                    couldGoLeft = true;
                }

                if ((map.Cases[player.Y * map.Width + player.X].State == ARX.State.Right 
                    || map.Cases[player.Y * map.Width + player.X].State == ARX.State.Cross))
                {
                    vision = 1;

                    if (player.X < map.Width - 1 &&
                    (map.Cases[player.Y * map.Width + player.X + 1].State == ARX.State.Right 
                    || map.Cases[player.Y * map.Width + player.X + 1].State == ARX.State.Cross))
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
                if (player.X > 0 &&
                    (map.Cases[player.Y * map.Width + player.X - 1].State == ARX.State.Right 
                    || map.Cases[player.Y * map.Width + player.X - 1].State == ARX.State.Cross))
                {
                    canGoRight = true;
                }

                if ((map.Cases[player.Y * map.Width + player.X].State == ARX.State.Right 
                    || map.Cases[player.Y * map.Width + player.X].State == ARX.State.Cross))
                {
                    canGoLeft = true;
                }

                if (player.X > 0 && player.Y < map.Height - 1 &&
                    (map.Cases[player.Y * map.Width + player.X + map.Width - 1].State == ARX.State.Right 
                    || map.Cases[player.Y * map.Width + player.X + map.Width - 1].State == ARX.State.Cross))
                {
                    couldGoRight = true;
                }

                if (player.Y < map.Height - 1 &&
                    (map.Cases[player.Y * map.Width + player.X + map.Width].State == ARX.State.Right 
                    || map.Cases[player.Y * map.Width + player.X + map.Width].State == ARX.State.Cross))
                {
                    couldGoLeft = true;
                }

                if ((map.Cases[player.Y * map.Width + player.X].State == ARX.State.Down 
                    || map.Cases[player.Y * map.Width + player.X].State == ARX.State.Cross))
                {
                    vision = 1;

                    if (player.Y < map.Height &&
                    (map.Cases[player.Y * map.Width + player.X + map.Width].State == ARX.State.Down 
                    || map.Cases[player.Y * map.Width + player.X + map.Width].State == ARX.State.Cross))
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
                    if (player.Y > 0 &&
                        (map.Cases[player.Y * map.Width + player.X - map.Width].State == ARX.State.Down 
                        || map.Cases[player.Y * map.Width + player.X - map.Width].State == ARX.State.Cross))
                    {
                        canGoRight = true;
                    }

                    if ((map.Cases[player.Y * map.Width + player.X].State == ARX.State.Down 
                        || map.Cases[player.Y * map.Width + player.X].State == ARX.State.Cross))
                    {
                        canGoLeft = true;
                    }

                    if (player.X > 0 && player.Y > 0 &&
                        (map.Cases[player.Y * map.Width + player.X - map.Width - 1].State == ARX.State.Down 
                        || map.Cases[player.Y * map.Width + player.X - map.Width - 1].State == ARX.State.Cross))
                    {
                        couldGoRight = true;
                    }

                    if (player.X > 0 &&
                        (map.Cases[player.Y * map.Width + player.X - 1].State == ARX.State.Down 
                        || map.Cases[player.Y * map.Width + player.X - 1].State == ARX.State.Cross))
                    {
                        couldGoLeft = true;
                    }

                    if (player.X > 0 &&
                        (map.Cases[player.Y * map.Width + player.X - 1].State == ARX.State.Right 
                        || map.Cases[player.Y * map.Width + player.X - 1].State == ARX.State.Cross))
                    {
                        vision = 1;

                        if (player.X > 1 &&
                        (map.Cases[player.Y * map.Width + player.X - 2].State == ARX.State.Right 
                        || map.Cases[player.Y * map.Width + player.X - 2].State == ARX.State.Cross))
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
