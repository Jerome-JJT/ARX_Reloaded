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
        Size labyrinthSize = new Size(21, 17);
        Player player;

        DrawMap drawMap;
        DrawView drawView;  

        Random labyrinthRandom = new Random();

        int zoomLevel = 1;

        public FrmGame()
        {
            InitializeComponent();
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            map = new MapNormal(labyrinthSize, labyrinthRandom);
            player = new Player();

            drawMap = new DrawMap(picMap.Size, player, labyrinthRandom);
            drawView = new DrawView(picView.Size);

            map.GenerateMap(null, null);
            map.GenerateZones(picMap, lblLoading);

            Moving("none");
        }

        private void Moving(string direction)
        {
            Movement.Goto(ref player, map, direction, chkPacmanMoves.Checked);

            map.Cases[player.Y * map.Width + player.X].Visited = true;

            picMap.Refresh();
            picView.Refresh();
        }


        private void cmdGenNormal_Click(object sender, EventArgs e)
        {
            map = new MapNormal(labyrinthSize, labyrinthRandom);
            drawMap.ShuffleColors();

            //map.GenerateMap(picMap, lblLoading);
            map.GenerateMap(null, null);

            map.GenerateZones(picMap, lblLoading);

            Moving("none");
        }

        private void cmdGenChaos_Click(object sender, EventArgs e)
        {
            map = new MapChaos(labyrinthSize, labyrinthRandom);
            drawMap.ShuffleColors();

            //map.GenerateMap(picMap, lblLoading);
            map.GenerateMap(null, null);

            map.GenerateZones(picMap, lblLoading);

            Moving("none");
        }

        private void cmdUpdateView_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < map.Cases.Count(); i++)
            {
                map.Cases[i].Visited = true;
            }

            picMap.Refresh();
        }


        private void picView_Paint(object sender, PaintEventArgs e)
        {
            drawView.DrawTotalView(e, Movement.CanGoLeft, Movement.CanGoRight, Movement.CouldGoLeft, Movement.CouldGoRight, Movement.Vision);
        }

        private void picMap_Paint(object sender, PaintEventArgs e)
        {
            if(map != null)
            {
                drawMap.DrawTotalMap(e, map, zoomLevel);
            }
        }

        private void FrmGame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switchKeys(e.KeyCode);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (switchKeys(keyData))
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
                    Moving("up");
                    break;

                case Keys.A:
                case Keys.Left:
                    Moving("left");
                    break;

                case Keys.D:
                case Keys.Right:
                    Moving("right");
                    break;

                case Keys.S:
                case Keys.Down:
                    Moving("down");
                    break;

                case Keys.Add:
                    if (zoomLevel < 4)
                    {
                        zoomLevel++;
                        picMap.Refresh();
                    }
                    break;

                case Keys.Subtract:
                    if (zoomLevel > 1)
                    {
                        zoomLevel--;
                        picMap.Refresh();
                    }
                    break;

                default:
                    return false;
            }
            return true;
        }
    }
}
