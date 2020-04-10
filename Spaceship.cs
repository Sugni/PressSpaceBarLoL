using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PressSpaceBarLoL
{
    class Spaceship:PictureBox
    {
        public Spaceship()
        {
            InitializeSpaceship();
        }

        private void InitializeSpaceship()
        {
            this.Width = 60;
            this.Height = 60;
            this.BackColor = Color.Gray;

        }
    }
}
