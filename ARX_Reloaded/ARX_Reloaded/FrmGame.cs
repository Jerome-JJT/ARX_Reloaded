using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARX_Reloaded
{
    public partial class FrmGame : Form
    {
        Map map;
        Player player;

        Size labyrinthSize = new Size(20, 20);

        bool canGoLeft = true;
        bool canGoRight = true;

        bool couldGoLeft = true;
        bool couldGoRight = true;
        int vision = 2;

        public FrmGame()
        {
            InitializeComponent();
            player = new Player();
        }

        private void FrmGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show("Form.KeyPress: '" + e.KeyChar.ToString() + "' pressed.");
            switch (e.KeyChar)
            {
                case 'w':
                    Move("up");
                    break;
                case 'a':
                    Move("left");
                    break;
                case 'd':
                    Move("right");
                    break;
                case 's':
                    Move("down");
                    break;
            }
        }

        public void Move(string direction)
        {
            if(chkPacmanMoves.Checked)
            {

            }
            else
            {
                if (direction == "up")
                {
                    if (player.Rotation == 0 && player.Y > 0 &&
                        (map.Cases[player.Y * map.Width + player.X - map.Width].State == 3 || 
                         map.Cases[player.Y * map.Width + player.X - map.Width].State == 4))
                    {
                        player.Y -= 1;
                    }
                    else if (player.Rotation == 90 && player.X < map.Width &&
                        (map.Cases[player.Y * map.Width + player.X].State == 2 ||
                         map.Cases[player.Y * map.Width + player.X].State == 4))
                    {
                        player.X += 1;
                    }
                    else if (player.Rotation == 180 && player.Y < map.Height &&
                        (map.Cases[player.Y * map.Width + player.X].State == 3 ||
                         map.Cases[player.Y * map.Width + player.X].State == 4))
                    {
                        player.Y += 1;
                    }
                    else if (player.Rotation == 270 && player.X > 0 &&
                        (map.Cases[player.Y * map.Width + player.X - 1].State == 2 ||
                         map.Cases[player.Y * map.Width + player.X - 1].State == 4))
                    {
                        player.X -= 1;
                    }
                }
                else if (direction == "left")
                {
                    player.Rotation = (player.Rotation + 270) % 360;
                }
                else if (direction == "right")
                {
                    player.Rotation = (player.Rotation + 90) % 360;
                }
                else if (direction == "down")
                {
                    if (player.Rotation == 0 && player.Y < map.Height &&
                        (map.Cases[player.Y * map.Width + player.X].State == 3 ||
                         map.Cases[player.Y * map.Width + player.X].State == 4))
                    {
                        player.Y += 1;
                    }
                    else if (player.Rotation == 90 && player.X > 0 &&
                        (map.Cases[player.Y * map.Width + player.X - 1].State == 2 ||
                         map.Cases[player.Y * map.Width + player.X - 1].State == 4))
                    {
                        player.X -= 1;
                    }
                    else if (player.Rotation == 180 && player.Y > 0 &&
                        (map.Cases[player.Y * map.Width + player.X - map.Width].State == 3 ||
                         map.Cases[player.Y * map.Width + player.X - map.Width].State == 4))
                    {
                        player.Y -= 1;
                    }
                    else if (player.Rotation == 270 && player.Y < map.Width &&
                        (map.Cases[player.Y * map.Width + player.X].State == 2 ||
                         map.Cases[player.Y * map.Width + player.X].State == 4))
                    {
                        player.X += 1;
                    }
                }
            }

            picMap.Refresh();
        }

        private void picView_Paint(object sender, PaintEventArgs e)
        {
            DrawView drawView = new DrawView(e, picView.Size);

            drawView.DrawTotalView(canGoLeft, canGoRight, couldGoLeft, couldGoRight, vision);
        }

        private void picMap_Paint(object sender, PaintEventArgs e)
        {
            if(map != null)
            {
                DrawMap drawMap = new DrawMap(e, picMap.Size, player);
                drawMap.DrawTotalMap(map);

                drawMap.DrawTotalMap(map);
            }
        }

        private void cmdGenNormal_Click(object sender, EventArgs e)
        {
            map = new MapNormal(labyrinthSize);
            map.GenerateMap();
            picMap.Refresh();
        }

        private void cmdGenChaos_Click(object sender, EventArgs e)
        {
            map = new MapChaos(labyrinthSize);
            map.GenerateMap();
            picMap.Refresh();
        }

        private void cmdUpdateView_Click(object sender, EventArgs e)
        {
            canGoLeft = false;
            picView.Refresh();
        }
    }
}
