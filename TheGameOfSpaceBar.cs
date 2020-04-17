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
        Timer mainTimer = null;
        Timer createEnemies = null;
        Enemy enemy = null;
        Random rand = new Random();


        bool moveLeft = false;
        bool moveRight = false;
        bool gameOver = false;
        bool bulletFired = false;

        public TheGameOfSpaceBar()
        {
            InitializeComponent();
            InitializeBattlefield();
            InitializeMainTimer();
            InitializeEnemyCreatorTimer();
        }


        private void EnemyBulletCollision()
        {
            foreach (Control c in this.Controls)
            {
                if ((string)c.Tag == "enemy")
                {
                    foreach (Control b in this.Controls)
                    {
                        if ((string)b.Tag == "bullet")
                        {
                            if (c.Bounds.IntersectsWith(b.Bounds))
                            {
                                c.Dispose();
                                b.Dispose();
                            }
                        }
                    }
                }
            }
        }

        private void EnemySpaceshipCollision()
        {
            foreach(Control ctrl in this.Controls)
            {
                if((string)ctrl.Tag == "Enemy" && ctrl.Bounds.IntersectsWith(spaceship.Bounds))
                {
                    GameOver();
                    ctrl.Dispose();
                    spaceship.Dispose();
                }
            }
        }

        private void GameOver()
        {
            mainTimer.Stop();
            MessageBox.Show("Game Over!");
        }

        private void InitializeEnemyCreatorTimer()
        {
            createEnemies = new Timer();
            createEnemies.Interval = 1000;
            createEnemies.Tick += new EventHandler(CreateEnemies_Tick);
            createEnemies.Start();
        }

        private void CreateEnemies_Tick(object sender, EventArgs e)
        {
            enemy = new Enemy(rand.Next(1, 10), this);
            enemy.Left = rand.Next(0, ClientRectangle.Width - enemy.Width);
            enemy.Top = 0 - enemy.Height;
            this.Controls.Add(enemy);
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
            EnemyBulletCollision();
            EnemySpaceshipCollision();
        }



        private void TheGameOfSpaceBar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && !bulletFired)
            {
                spaceship.FireBullet(this);
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
