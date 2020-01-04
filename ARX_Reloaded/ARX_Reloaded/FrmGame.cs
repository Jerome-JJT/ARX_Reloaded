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

        Size labyrinthSize = new Size(30, 30);
        int nbZones = 6;

        int drawType = 0;

        const int minZoomLevel = 1;
        const int maxCaseDisplay = 5;

        int stageLevel = 0;
        int coinsAmount = 0;

        Random labyrinthRandom = new Random();
        //Random labyrinthRandom = new Random(6);
        //Random labyrinthRandom = new Random(5);

        

        public FrmGame()
        {
            InitializeComponent();
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            player = new Player(0, 0, 90);

            CreateMap();

            display();
        }

        #region Buttons
        private void CreateMap()
        {
            switch (labyrinthRandom.Next(10))
            {
                case 0:
                    map = new MapNormal(labyrinthSize, labyrinthRandom);
                    break;

                case 1:
                case 2:
                    map = new MapChaos(labyrinthSize, labyrinthRandom);
                    break;

                case 3:
                case 4:
                    map = new MapFastChaos(15, labyrinthSize, labyrinthRandom);
                    break;

                case 5:
                case 6:
                    map = new MapPourcent(20, labyrinthSize, labyrinthRandom);
                    break;

                case 7:
                case 8:
                case 9:
                    map = new MapMultiple(labyrinthSize, labyrinthRandom);
                    break;

                case 10:
                    map = new MapLines(labyrinthSize, labyrinthRandom);
                    break;

                default:
                    map = new MapFastChaos(15, labyrinthSize, labyrinthRandom);
                    break; 
            }

            map.Generate(player.Position, nbZones);

            moving(ARX.Direction.Null);
        }

        private void cmdUpdateView_Click(object sender, EventArgs e)
        {
            map.Cases.ForEach(eachCase => eachCase.Visible = true);

            display();
        }
        #endregion

        #region Drawings
        private void display()
        {
            picView.Refresh();
            picMap.Refresh();
        }

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

            map.Self(player.Y * map.Width + player.X).Visible = true;

            //Mark visited 3x3 case radius from player, catch NullReferenceException if case is null (outside the map)
            try { map.Upper(player.Y * map.Width + player.X).Visible = true; } catch (NullReferenceException) { }
            try { map.Righter(player.Y * map.Width + player.X).Visible = true; } catch (NullReferenceException) { }
            try { map.Lower(player.Y * map.Width + player.X).Visible = true; } catch (NullReferenceException) { }
            try { map.Lefter(player.Y * map.Width + player.X).Visible = true; } catch (NullReferenceException) { }

            try { map.Lefter(map.Upper(player.Y * map.Width + player.X).Coord).Visible = true; } catch (NullReferenceException) { }
            try { map.Righter(map.Upper(player.Y * map.Width + player.X).Coord).Visible = true; } catch (NullReferenceException) { }
            try { map.Lefter(map.Lower(player.Y * map.Width + player.X).Coord).Visible = true; } catch (NullReferenceException) { }
            try { map.Righter(map.Lower(player.Y * map.Width + player.X).Coord).Visible = true; } catch (NullReferenceException) { }

            display();
        }

        private void action()
        {
            Case playerCase = map.Cases[player.Y * map.Width + player.X];

            if (playerCase.CaseEvent.GetType() == typeof(ExitEvent))
            {
                stageLevel++;
                lblStageScore.Text = $"Étage : {stageLevel}";
                map = new MapMultiple(labyrinthSize, labyrinthRandom);
                map.Generate(player.Position, nbZones);

                moving(ARX.Direction.Null);
            }
            else if (playerCase.CaseEvent.GetType() == typeof(KeyEvent))
            {
                map.UnlockZone(((KeyEvent)playerCase.CaseEvent).ZoneToOpen);
                playerCase.CaseEvent = new NoEvent();
            }
            else if (playerCase.CaseEvent.GetType() == typeof(CoinEvent))
            {
                coinsAmount++;
                lblCoinScore.Text = $"Points : {coinsAmount}";
                playerCase.CaseEvent = new NoEvent();
            }

            display();
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
                        display();
                    }
                    break;

                case Keys.Subtract:
                    if (map.Zoom > minZoomLevel)
                    {
                        map.Zoom--;
                        display();
                    }
                    break;

                case Keys.Multiply:
                    drawType = (drawType + 1) % 3;
                    display();
                    break;

                default:
                    return false;
            }
            return true;
        }
        #endregion
    }
}
