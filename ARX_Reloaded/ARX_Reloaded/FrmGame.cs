using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        const int minZoomLevel = 1;
        const int maxCaseDisplay = 5;

        Random labyrinthSeed = new Random();
        Random labyrinthRandom;
        //Random labyrinthRandom = new Random(6);
        //Random labyrinthRandom = new Random(5);

        JsonManagement jsonFile = new JsonManagement();
        JsonData data;

        #region Form events
        public FrmGame()
        {
            InitializeComponent();
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            formLoading();
        }

        private void formLoading()
        {
            try
            {
                data = jsonFile.ExtractData();
            }
            catch (FileNotFoundException)
            {
                //If file doesn't exist
                data = new JsonData();
                jsonFile.InsertData(data);
            }
            catch (NullReferenceException)
            {
                //If the json file is empty
                data = new JsonData();
                jsonFile.InsertData(data);
            }

            data.RandomSeed = data.RandomSeed != -1 ? data.RandomSeed : labyrinthSeed.Next();
            player = new Player(data.Player.X, data.Player.Y, 0);

            CreateMap();

            map.Zoom = data.ZoomLevel;
            chkPacmanMoves.Checked = data.PacmanMode;

            this.Location = data.WindowLocation;
            this.Size = data.WindowSize;

            responsive();
            display();
            scores();
        }

        private void FrmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            data.ZoomLevel = map.Zoom;
            data.PacmanMode = chkPacmanMoves.Checked;

            data.WindowLocation = this.Location;
            data.WindowSize = this.Size;

            jsonFile.InsertData(data);
        }

        private void FrmGame_SizeChanged(object sender, EventArgs e)
        {
            responsive();
            display();
        }
        #endregion

        private void CreateMap()
        {
            labyrinthRandom = new Random(data.RandomSeed);

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

            map.Generate(player.Y * map.Width + player.X, nbZones);

            moving(ARX.Direction.Null);
        }

        #region Buttons
        private void cmdUpdateView_Click(object sender, EventArgs e)
        {
            map.Cases.ForEach(eachCase => eachCase.Visible = true);

            display();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            jsonFile.InsertData(new JsonData());

            formLoading();
        }
        #endregion

        #region Display
        private void scores()
        {
            lblStageScore.Text = $"Étage : {data.StageLevel}";
            lblCoinScore.Text = $"Points : {data.CoinAmount}";
        }

        private void responsive()
        {
            picView.Size = new Size(
                Convert.ToInt32(Math.Min(Size.Width / 2.0 - 40, Size.Height - 100)),
                Convert.ToInt32(Math.Min(Size.Width / 2.0 - 40, Size.Height - 100)));

            picView.Location = new Point(
                Convert.ToInt32(Size.Width / 2.0 - 30 - Math.Min(Size.Width / 2.0 - 40, Size.Height - 100)),
                Convert.ToInt32(30));


            picMap.Size = new Size(
                Convert.ToInt32(Math.Min(Size.Width / 2.0 - 40, Size.Height - 100)),
                Convert.ToInt32(Math.Min(Size.Width / 2.0 - 40, Size.Height - 100)));

            picMap.Location = new Point(
                Convert.ToInt32(Size.Width / 2.0 + 10),
                Convert.ToInt32(30));
        }

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
                if (data.DrawType == 0)
                {
                    DrawMap.Draw(e, picMap.Size, map, player, ARX.MapType.Normal);
                }
                else if (data.DrawType == 1)
                {
                    DrawMap.Draw(e, picMap.Size, map, player, ARX.MapType.Pacman);
                }
                else if (data.DrawType == 2)
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
                data.StageLevel++;
                scores();
                
                data.RandomSeed = labyrinthSeed.Next();
                data.Player = new Point(player.X, player.Y);
                CreateMap();
            }
            else if (playerCase.CaseEvent.GetType() == typeof(KeyEvent))
            {
                map.UnlockZone(((KeyEvent)playerCase.CaseEvent).ZoneToOpen);
                playerCase.CaseEvent = new NoEvent();
            }
            else if (playerCase.CaseEvent.GetType() == typeof(CoinEvent))
            {
                data.CoinAmount++;
                scores();

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
                    data.DrawType = (data.DrawType + 1) % 3;
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
