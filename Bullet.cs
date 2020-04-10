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
        public Bullet()
        {
            InitializeBullet();
        }

        private void InitializeBullet()
        {
            this.BackColor = Color.Red;
            this.Width = 10;
            this.Height = 60;
        }
    }
}
