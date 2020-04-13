using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PressSpaceBarLoL
{
    class Bullet : PictureBox
    {
        private Timer timerBulletMove;
        int verVel = 0;
        int horvel = 0;
        private int bulletStep;

        public Bullet(int speed)
        {
            bulletStep = speed;
            InitializeBullet();
            InitalizeTimerBulletMove();
        }

        private void InitalizeTimerBulletMove()
        {
            timerBulletMove = new Timer();
            timerBulletMove.Interval = 20;
            timerBulletMove.Tick += new EventHandler(TimerBulletMove_Tick);
            verVel = -bulletStep;
            timerBulletMove.Start();
        }

        private void TimerBulletMove_Tick(object sender, EventArgs e)
        {
            this.Top += verVel;
            this.Left += horvel;
            if(this.Top + this.Height < 0)
            {
                this.Dispose();
            }
        }

        private void InitializeBullet()
        {
            this.BackColor = Color.Red;
            this.Width = 10;
            this.Height = 10;
        }
    }
}
