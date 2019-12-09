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

        Size labyrinthSize = new Size(100,100);

        

        public FrmGame()
        {
            InitializeComponent();
            player = new Player();
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            map = new MapNormal(labyrinthSize);
            map.GenerateMap(null, null);
            picMap.Refresh();

            prepareMovement("none");
        }


        private void FrmGame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switchKeys(e.KeyCode);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(switchKeys(keyData))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool switchKeys(Keys key)
        {
            switch (key)
            {
                case Keys.W:
                case Keys.Up:
                    prepareMovement("up");
                    break;

                case Keys.A:
                case Keys.Left:
                    prepareMovement("left");
                    break;

                case Keys.D:
                case Keys.Right:
                    prepareMovement("right");
                    break;

                case Keys.S:
                case Keys.Down:
                    prepareMovement("down");
                    break;

                default:
                    return false;
            }
            return true;
        }

        private void prepareMovement(string direction)
        {
            Movement.Goto(ref player, map, direction, chkPacmanMoves.Checked);

            map.Cases[player.Y * map.Width + player.X].Visited = true;

            picMap.Refresh();
            picView.Refresh();
        }
        

        private void picView_Paint(object sender, PaintEventArgs e)
        {
            DrawView drawView = new DrawView(e, picView.Size);

            drawView.DrawTotalView(Movement.CanGoLeft, Movement.CanGoRight, Movement.CouldGoLeft, Movement.CouldGoRight, Movement.Vision);
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
            map.GenerateMap(picMap, lblLoading);

            prepareMovement("none");

            picMap.Refresh();
        }

        private void cmdGenChaos_Click(object sender, EventArgs e)
        {
            map = new MapChaos(labyrinthSize);
            map.GenerateMap(picMap, lblLoading);

            prepareMovement("none");

            picMap.Refresh();
        }

        private void cmdUpdateView_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < map.Cases.Count(); i++)
            {
                map.Cases[i].Visited = true;
            }

            picMap.Refresh();
        }
    }
}
