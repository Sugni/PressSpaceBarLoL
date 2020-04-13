using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PressSpaceBarLoL
{
    public partial class TheGameOfSpaceBar : Form
    {
        Spaceship spaceship = null;
        Bullet bullet = null;
        Timer mainTimer = null;

        bool moveLeft = false;
        bool moveRight = false;
        bool gameOver = false;
        bool bulletFired = false;

        public TheGameOfSpaceBar()
        {
            InitializeComponent();
            InitializeBattlefield();
            InitializeMainTimer();
        }

        private void InitializeBattlefield()
        {
            spaceship = new Spaceship();
            spaceship.Top = ClientRectangle.Height - (spaceship.Height + 50);
            spaceship.Left = ClientRectangle.Width - (ClientRectangle.Width / 2 + spaceship.Width / 2);
            this.Controls.Add(spaceship);
        }

        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Interval = 50;
            mainTimer.Tick += new EventHandler(MainTimer_click);
            mainTimer.Start();
        }

        private void MainTimer_click(object sender, EventArgs e)
        {
            if(moveRight && spaceship.Left + spaceship.Width < ClientRectangle.Width)
            {
                spaceship.Left += 5;
            }
            if(moveLeft && spaceship.Left > 0)
            {
                spaceship.Left -= 5;
            }
        }

        private void FireBullet()
        {
            if(spaceship.EngineStatus == "On")
            {
                bullet = new Bullet(15);
            }
            else
            {
                bullet = new Bullet(5);
            }
            bullet.Top = spaceship.Top;
            bullet.Left = spaceship.Left + (spaceship.Width / 2 - bullet.Width / 2);
            this.Controls.Add(bullet);
        }

        private void TheGameOfSpaceBar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && !bulletFired)
            {
                FireBullet();
                bulletFired = true;
            }
            if(e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                moveLeft = true;
            }
            else if(e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                moveRight = true;
            }
            else if(e.KeyCode == Keys.O)
            {
                if(spaceship.EngineStatus == "Off")
                {
                    spaceship.EngineOn();
                }
                else
                {
                    spaceship.EngineOff();
                }
                
            }
        }

        private void TheGameOfSpaceBar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                bulletFired = false;
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                moveLeft = false;
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                moveRight = false;
            }
        }
    }
}
