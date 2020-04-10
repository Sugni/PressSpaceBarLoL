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
        Spaceship spaceship;
        Bullet bullet;

        public TheGameOfSpaceBar()
        {
            InitializeComponent();
            InitializeBattlefield();
        }

        private void InitializeBattlefield()
        {
            spaceship = new Spaceship();
            spaceship.Top = ClientRectangle.Height - (spaceship.Height + 100);
            spaceship.Left = ClientRectangle.Width - (ClientRectangle.Width / 2 + spaceship.Width / 2);
            this.Controls.Add(spaceship);
        }

        private void FireBullet()
        {
            bullet = new Bullet();
            bullet.Top = spaceship.Top;
            bullet.Left = spaceship.Left + (spaceship.Width / 2 - bullet.Width / 2);
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }

        private void TheGameOfSpaceBar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                FireBullet();
            }
            if(e.KeyCode == Keys.Left)
            {
                spaceship.Left -= 5;
            }
            else if(e.KeyCode == Keys.Right)
            {
                spaceship.Left += 5;
            }
        }
    }
}
