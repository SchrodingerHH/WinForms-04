using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WinForms_04
{
    class Ship : BaseObject
    {
        public event Message MessageDie;
        private int energy = 100;
        public int Energy => energy;        

        public void EnergyLow(int n)
        {
            energy -= n;
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.buffer.Graphics.FillEllipse(Brushes.Wheat, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Update()
        {

        }


        public void Up()
        {
            if (pos.Y>0)
            {
                pos.Y = pos.Y + dir.Y;
            }
        }

        public void Down()
        {
            if (pos.Y < Game.Height)
            {
                pos.Y = pos.Y + dir.Y;
            }
        }

        public void Die()
        {
            MessageDie.Invoke();
        }        
    }
}
