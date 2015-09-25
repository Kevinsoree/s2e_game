using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SE2Game.Entities;
using SE2Game.Game;
using SE2Game.Utils;

namespace SE2Game
{
    public partial class SE2GameForm : Form
    {
        private long timeStarted;

        public SE2GameForm()
        {
            InitializeComponent();

            World.Instance.Create(picGameWorld.ClientSize);
        }

        private void picGameWorld_Paint(object sender, PaintEventArgs e)
        {
            World.Instance.Draw(e.Graphics);
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            World.Instance.Update();
            lbHP.Text = Convert.ToString(World.Instance.Player.Hitpoints);
            picGameWorld.Refresh();

            if (World.Instance.GameOver)
            {
                SetGameRunning(false);
                MessageBox.Show(String.Format("You were killed! Time survived: {0:0.0} seconds.",
                                              (World.Instance.Time - timeStarted) / 1000.0));
            }
            else if (World.Instance.GameWon)
            {
                SetGameRunning(false);
                MessageBox.Show(String.Format("Victory! Time taken: {0:0.0} seconds.",
                                              (World.Instance.Time - timeStarted) / 1000.0));
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timeStarted = World.Instance.Time;
            SetGameRunning(true);
        }

        private void SetGameRunning(bool running)
        {
            timerAnimation.Enabled = running;
            btnStart.Enabled = !running;
            btnRandomMap.Enabled = !running;
        }

        private void btnRandomMap_Click(object sender, EventArgs e)
        {
            World.Instance.Create(picGameWorld.ClientSize);
            picGameWorld.Refresh();
        }
    }
}
