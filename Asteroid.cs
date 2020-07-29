using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WinForms_04
{
    class Asteroid : BaseObject, ICloneable, IComparable
    {
        public int Power { get; set; } = 3;

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public override void Draw()
        {
            Game.buffer.Graphics.FillEllipse(Brushes.White, pos.X, pos.Y, size.Width, size.Height);
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj is Asteroid temp)
            {
                if (Power > temp.Power) 
                {
                    return 1;
                }
                if (Power < temp.Power) 
                {
                    return -1;
                } 
                else
                {
                    return 0;
                }
                throw new ArgumentException("Parameter is not a Asteroid!");
            }
            return 0;
        }

        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height));
            asteroid.Power = Power;
            return asteroid;
        }
    }
}
