using Microsoft.VisualBasic;
using System;
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
        

        static public int Width { get; set; }
        static public int Height { get; set; }

        static public void Init(Form form)
        {
            Graphics graphics;
            Timer timer = new Timer() {Interval = 25};

            context = BufferedGraphicsManager.Current;
            graphics = form.CreateGraphics();

            Width = form.Width;
            Height = form.Height;

            buffer = context.Allocate(graphics, new Rectangle(0,0,Width,Height));

            Load();

            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        static public void Update()
        {
            foreach (var obj in objects)
            {
                obj.Update();
            }
        }

        static public void Draw()
        {
            Point mousePoint = new Point(100,200);
            buffer.Graphics.Clear(Color.Black);

            foreach (var obj in objects)
            {
                obj.Draw();
            }

            //imageShip = Image.FromFile(@"C:\Users\lrgcr\OneDrive\Изображения\ship.png");
            //buffer.Graphics.DrawImage(imageShip, mousePoint);
            //buffer.Graphics.FillRectangle(Brushes.White,new Rectangle(50, 50, 50, 25));        
            buffer.Render();
        }

        static public void Load()
        {
            Random rnd = new Random();
            int objectSize;
            objects = new BaseObject[30];
            for (int i = 0; i < objects.Length/2; i++)
            {
                objectSize = rnd.Next(10,25);
                objects[i] = new BaseObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(objectSize,objectSize));
            }
            for (int i = objects.Length/2; i < objects.Length; i++)
            {
                objects[i] = new Star(new Point(Convert.ToInt32(600), i * 25), new Point(i,i), new Size(25,25));
            }
        }
    }
}
