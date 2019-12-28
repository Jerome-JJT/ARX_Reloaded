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
        Size labyrinthSize = new Size(20, 20);
        Player player;

        DrawView drawView;  

        Random labyrinthRandom = new Random();

        int nbZones = 5;
        int zoomLevel = 1;
        const int minZoomLevel = 1;
        const int maxZoomLevel = 5;

        public FrmGame()
        {
            InitializeComponent();
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            map = new MapNormal(labyrinthSize, labyrinthRandom);
            //map = new MapChaos(labyrinthSize, labyrinthRandom);
            //map = new MapN50(labyrinthSize, labyrinthRandom);


            player = new Player(0,0,90);

            drawView = new DrawView(picView.Size);

            map.GenerateMap(null, null);
            //map.GenerateZones(picMap, lblLoading);
            map.GenerateZones(null, null, nbZones);

            Moving("none");
        }

        private void cmdGenNormal_Click(object sender, EventArgs e)
        {
            map = new MapNormal(labyrinthSize, labyrinthRandom);

            //map.GenerateMap(picMap, lblLoading);
            map.GenerateMap(null, null);

            //map.GenerateZones(picMap, lblLoading);
            map.GenerateZones(null, null, nbZones);

            Moving("none");
        }

        private void cmdGenChaos_Click(object sender, EventArgs e)
        {
            map = new MapChaos(labyrinthSize, labyrinthRandom);

            //map.GenerateMap(picMap, lblLoading);
            map.GenerateMap(null, null);

            //map.GenerateZones(picMap, lblLoading);
            map.GenerateZones(null, null, nbZones);

            Moving("none");
        }

        private void cmdGenFaos_Click(object sender, EventArgs e)
        {
            map = new MapFastChaos(10, labyrinthSize, labyrinthRandom);

            //map.GenerateMap(picMap, lblLoading);
            map.GenerateMap(null, null);

            //map.GenerateZones(picMap, lblLoading);
            map.GenerateZones(null, null, nbZones);

            Moving("none");
        }

        private void cmdGenPourcent_Click(object sender, EventArgs e)
        {
            map = new MapPourcent(20, labyrinthSize, labyrinthRandom);

            //map.GenerateMap(picMap, lblLoading);
            map.GenerateMap(null, null);

            //map.GenerateZones(picMap, lblLoading);
            map.GenerateZones(null, null, nbZones);

            Moving("none");
        }

        private void cmdGenMultiple_Click(object sender, EventArgs e)
        {
            map = new MapMultiple(labyrinthSize, labyrinthRandom);

            //map.GenerateMap(picMap, lblLoading);
            map.GenerateMap(null, null);

            //map.GenerateZones(picMap, lblLoading);
            map.GenerateZones(null, null, nbZones);

            Moving("none");
        }

        private void cmdGenLines_Click(object sender, EventArgs e)
        {
            map = new MapLines(labyrinthSize, labyrinthRandom);

            //map.GenerateMap(picMap, lblLoading);
            map.GenerateMap(null, null);

            //map.GenerateZones(picMap, lblLoading);
            map.GenerateZones(null, null, nbZones);

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
                DrawMap.DrawTotalMap(e, picMap.Size, map, player, zoomLevel);
            }
        }

        private void Moving(string direction)
        {
            Movement.Goto(ref player, map, direction, chkPacmanMoves.Checked);

            map.Cases[player.Y * map.Width + player.X].Visited = true;

            picMap.Refresh();
            picView.Refresh();
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
                    if (zoomLevel < maxZoomLevel)
                    {
                        zoomLevel++;
                        picMap.Refresh();
                    }
                    break;

                case Keys.Subtract:
                    if (zoomLevel > minZoomLevel)
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
