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
        Size labyrinthSize = new Size(30, 30);
        Player player;

        Random labyrinthRandom = new Random();
        //Random labyrinthRandom = new Random(6);
        //Random labyrinthRandom = new Random(7);

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

        }

        private void cmdGenNormal_Click(object sender, EventArgs e)
        {

        }

        private void cmdGenChaos_Click(object sender, EventArgs e)
        {

        }

        private void cmdGenFaos_Click(object sender, EventArgs e)
        {

        }

        private void cmdGenPourcent_Click(object sender, EventArgs e)
        {

        }

        private void cmdGenMultiple_Click(object sender, EventArgs e)
        {

        }

        private void cmdGenLines_Click(object sender, EventArgs e)
        {

        }

        private void cmdUpdateView_Click(object sender, EventArgs e)
        {


            picMap.Refresh();
        }


        private void picView_Paint(object sender, PaintEventArgs e)
        {
            DrawView.DrawTotalView(e, picView.Size, Movement.CanGoLeft, Movement.CanGoRight, Movement.CouldGoLeft, Movement.CouldGoRight, Movement.Vision);
        }

        private void picMap_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Moving(ARX.Direction direction)
        {


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
                    Moving(ARX.Direction.Up);
                    break;

                case Keys.A:
                case Keys.Left:
                    Moving(ARX.Direction.Left);
                    break;

                case Keys.D:
                case Keys.Right:
                    Moving(ARX.Direction.Right);
                    break;

                case Keys.S:
                case Keys.Down:
                    Moving(ARX.Direction.Down);
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
