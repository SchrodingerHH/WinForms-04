using Microsoft.VisualBasic;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms_04
{
    static class Game
    {
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        static public Image imageShip { get; set; }
        static public BaseObject[] objects;
        static private Bullet[] bullets;
        static private int bulletsCount = 0;
        static private Asteroid[] asteroids;
        static private Ship ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));

        static public Timer timer;

        static public int Width { get; set; }
        static public int Height { get; set; }

        static public void Init(Form form)
        {
            try
            {
                if (form.Width>1920 || form.Height>1080 || form.Width<0 || form.Height<0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }

            Graphics graphics;
            timer = new Timer() {Interval = 50};

            context = BufferedGraphicsManager.Current;
            graphics = form.CreateGraphics();

            Width = form.Width;
            Height = form.Height;

            form.KeyDown += Form_KeyDown;
            ship.MessageDie += Finish;
            buffer = context.Allocate(graphics, new Rectangle(0,0,Width,Height));

            Load();

            timer.Start();
            timer.Tick += Timer_Tick;
        }

        static public void Load()
        {
            Random rnd = new Random();
            int objectSize;
            objects = new BaseObject[30];
            //bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(5, 2));
            bullets = new Bullet[10];
            asteroids = new Asteroid[10];

            for (int i = 0; i < objects.Length; i++)
            {
                int r = rnd.Next(5, 50);
                objects[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3));
            }
            for (int i = 0; i < asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
            }
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = null;
            }
        }

        static public void Draw()
        {
            Point mousePoint = new Point(100, 200);
            buffer.Graphics.Clear(Color.Black);

            foreach (var obj in objects)
            {
                obj.Draw();
            }
            foreach (Asteroid obj in asteroids)
            {
                obj?.Draw();
            }
            foreach (var bullet in bullets)
            {
                bullet?.Draw();
            }            
            ship.Draw();
            if (ship != null)
            {
                buffer.Graphics.DrawString($"Energy: {ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
                try
                {
                    buffer.Render();
                }
                catch (Exception)
                {
                }
                
            }

            try
            {
                buffer.Render();
            }
            catch (Exception)
            {
                timer.Stop();
                MessageBox.Show("Ошибка");
                Application.Exit();
            }
        }

        static public void Update()
        {
            foreach (var obj in objects)
            {
                obj.Update();
            }
            foreach (var bullet in bullets)
            {
                bullet?.Update();
            }
            for (int i = 0; i < asteroids.Length; i++)
            {
                var rnd = new Random();
                if (asteroids[i] == null)
                {
                    continue;
                }
                asteroids[i].Update();
                for (int j = 0; j < bullets.Length; j++)
                {
                    if (bullets[j] != null && bullets[j].Collision(asteroids[i]))
                    {
                        int r = rnd.Next(5, 50);
                        System.Media.SystemSounds.Hand.Play();
                        asteroids[i] = null;
                        asteroids[i] = new Asteroid(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(100, r));
                        bullets[j] = null;
                        bulletsCount--;
                        continue;
                    }
                }

                if (!ship.Collision(asteroids[i]))
                {
                    continue;
                }
                ship.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (ship.Energy <= 0)
                {
                    ship.Die();
                }
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode == Keys.Right)
            {
                if (bulletsCount < 10)
                {
                    bullets[bulletsCount] = new Bullet(new Point(ship.rectangle.X + 10, ship.rectangle.Y + 4), new Point(4, 0), new Size(4, 1));
                    bulletsCount++;
                }
            }
            else if(e.KeyCode == Keys.Up)
            {
                ship.Up();
            } 
            else if(e.KeyCode == Keys.Down)
            {
                ship.Down();
            }
        }

        public static void Finish()
        {
            timer.Stop();
            buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 200);
            buffer.Render();
        }
    }
}