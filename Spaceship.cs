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

        private int imageCount = 1;



        //private string engineStatus = "Off";

        private Timer animationTimer = null;

        public string EngineStatus { get; set; } = "Off";

        public Spaceship()
        {
            InitializeSpaceship();
            InitializeAnimationTimer();
        }

        private void InitializeAnimationTimer()
        {
            animationTimer = new Timer();
            animationTimer.Tick += new EventHandler(AnimationTimer_Tick);
            animationTimer.Interval = 100;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            string imageName = "Rocket" + EngineStatus + imageCount.ToString();
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            imageCount++;
            if (imageCount == 5)
            {
                imageCount = 1;
            }
        }

        public void FireBullet(TheGameOfSpaceBar battlefield)
        {
            Bullet bullet = null;
            if (EngineStatus == "On")
            {
                bullet = new Bullet(15);
            }
            else
            {
                bullet = new Bullet(5);
            }
            bullet.Top = this.Top;
            bullet.Left = this.Left + (this.Width / 2 - bullet.Width / 2);
            battlefield.Controls.Add(bullet);
        }
        private void InitializeSpaceship()
        {
            this.Width = 40;
            this.Height = 80;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Properties.Resources.RocketOn1;
        }

        public void EngineOn()
        {
            EngineStatus = "On";
        }

        public void EngineOff()
        {
            EngineStatus = "Off";
        }
    }
}
