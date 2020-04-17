using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PressSpaceBarLoL
{
    class Enemy: PictureBox
    {
        private Timer timerEnemyMove;
        int verVel = 0;
        int horvel = 0;
        private int enemyStep;
        private TheGameOfSpaceBar battlefield = null;

        public Enemy(int speed, TheGameOfSpaceBar bf)
        {
            battlefield = bf;
            enemyStep = speed;
            InitializeEnemy();
            InitalizeTimerEnemyMove();
        }

        private void InitalizeTimerEnemyMove()
        {
            timerEnemyMove = new Timer();
            timerEnemyMove.Interval = 100;
            timerEnemyMove.Tick += new EventHandler(TimerBulletMove_Tick);
            verVel = enemyStep;
            timerEnemyMove.Start();
        }

        private void TimerBulletMove_Tick(object sender, EventArgs e)
        {
            this.Top += verVel;
            this.Left += horvel;
            if (this.Top > battlefield.ClientRectangle.Height)
            {
                this.Dispose();
            }
        }

        private void InitializeEnemy()
        {
            this.BackColor = Color.Yellow;
            this.Width = 50;
            this.Height = 50;
            this.Tag = "Enemy";
        }

    }
}
