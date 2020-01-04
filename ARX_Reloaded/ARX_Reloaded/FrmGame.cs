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
        Size labyrinthSize = new Size(30, 30);
        Player player;

        //Random labyrinthRandom = new Random();
        //Random labyrinthRandom = new Random(6);
        Random labyrinthRandom = new Random(5);

        int drawType = 0;

        int nbZones = 6;
        const int minZoomLevel = 1;
        const int maxCaseDisplay = 5;

        public FrmGame()
        {
            InitializeComponent();
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            //map = new MapNormal(labyrinthSize, labyrinthRandom);
            map = new MapMultiple(labyrinthSize, labyrinthRandom);

            player = new Player(0,0,90);

            map.PrepareMap(player.Position, nbZones);

            moving(ARX.Direction.Null);
        }

        #region Buttons
        private void cmdGenNormal_Click(object sender, EventArgs e)
        {
            map = new MapNormal(labyrinthSize, labyrinthRandom);

            map.PrepareMap(player.Position, nbZones);

            moving(ARX.Direction.Null);
        }

        private void cmdGenChaos_Click(object sender, EventArgs e)
        {
            map = new MapChaos(labyrinthSize, labyrinthRandom);

            map.PrepareMap(player.Position, nbZones);

            moving(ARX.Direction.Null);
        }

        private void cmdGenFaos_Click(object sender, EventArgs e)
        {
            map = new MapFastChaos(15, labyrinthSize, labyrinthRandom);

            map.PrepareMap(player.Position, nbZones);

            moving(ARX.Direction.Null);
        }

        private void cmdGenPourcent_Click(object sender, EventArgs e)
        {
            map = new MapPourcent(20, labyrinthSize, labyrinthRandom);

            map.PrepareMap(player.Position, nbZones);

            moving(ARX.Direction.Null);
        }

        private void cmdGenMultiple_Click(object sender, EventArgs e)
        {
            map = new MapMultiple(labyrinthSize, labyrinthRandom);

            map.PrepareMap(player.Position, nbZones);

            moving(ARX.Direction.Null);
        }

        private void cmdGenLines_Click(object sender, EventArgs e)
        {
            map = new MapLines(labyrinthSize, labyrinthRandom);

            map.PrepareMap(player.Position, nbZones);

            moving(ARX.Direction.Null);
        }

        private void cmdUpdateView_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < map.Cases.Count(); i++)
            {
                map.Cases[i].Visited = true;
            }

            picMap.Refresh();
            picView.Refresh();
        }
        #endregion

        #region Drawings
        private void picView_Paint(object sender, PaintEventArgs e)
        {
            DrawView.DrawTotalView(e, picView.Size, Movement.CanGoLeft, Movement.CanGoRight, Movement.CouldGoLeft, Movement.CouldGoRight, Movement.Vision);
        }

        private void picMap_Paint(object sender, PaintEventArgs e)
        {
            if(map != null)
            {
                if (drawType == 0)
                {
                    DrawMap.Draw(e, picMap.Size, map, player, ARX.MapType.Normal);
                }
                else if (drawType == 1)
                {
                    DrawMap.Draw(e, picMap.Size, map, player, ARX.MapType.Pacman);
                }
                else if (drawType == 2)
                {
                    DrawMap.Draw(e, picMap.Size, map, player, ARX.MapType.Fill);
                }
            }
        }
        #endregion

        private void moving(ARX.Direction direction)
        {
            Movement.Goto(player, map, direction, chkPacmanMoves.Checked);

            map.Self(player.Y * map.Width + player.X).Visited = true;

            //Mark visited 3x3 case radius from player, catch NullReferenceException if case is null (outside the map)
            try { map.Upper(player.Y * map.Width + player.X).Visited = true; } catch (NullReferenceException) { }
            try { map.Righter(player.Y * map.Width + player.X).Visited = true; } catch (NullReferenceException) { }
            try { map.Lower(player.Y * map.Width + player.X).Visited = true; } catch (NullReferenceException) { }
            try { map.Lefter(player.Y * map.Width + player.X).Visited = true; } catch (NullReferenceException) { }

            try { map.Lefter(map.Upper(player.Y * map.Width + player.X).Coord).Visited = true; } catch (NullReferenceException) { }
            try { map.Righter(map.Upper(player.Y * map.Width + player.X).Coord).Visited = true; } catch (NullReferenceException) { }
            try { map.Lefter(map.Lower(player.Y * map.Width + player.X).Coord).Visited = true; } catch (NullReferenceException) { }
            try { map.Righter(map.Lower(player.Y * map.Width + player.X).Coord).Visited = true; } catch (NullReferenceException) { }

            picMap.Refresh();
            picView.Refresh();
        }

        private void action()
        {

        }

        #region User inputs
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
                    moving(ARX.Direction.Up);
                    break;

                case Keys.A:
                case Keys.Left:
                    moving(ARX.Direction.Left);
                    break;

                case Keys.D:
                case Keys.Right:
                    moving(ARX.Direction.Right);
                    break;

                case Keys.S:
                case Keys.Down:
                    moving(ARX.Direction.Down);
                    break;

                case Keys.Enter:
                case Keys.Space:
                    action();
                    break;

                case Keys.Add:
                    if (Math.Min(map.Width, map.Height) / map.Zoom > maxCaseDisplay)
                    {
                        map.Zoom++;
                        picMap.Refresh();
                    }
                    break;

                case Keys.Subtract:
                    if (map.Zoom > minZoomLevel)
                    {
                        map.Zoom--;
                        picMap.Refresh();
                    }
                    break;

                case Keys.Multiply:
                    drawType = (drawType + 1) % 3;
                    picMap.Refresh();
                    break;

                default:
                    return false;
            }
            return true;
        }
        #endregion
    }
}
