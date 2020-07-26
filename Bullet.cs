using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WinForms_04
{
    class Bullet : BaseObject 
    {
        public Bullet(Point pos,Point dir,Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.Red, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Update()
        {
            pos.X = pos.X + 3;
        }

    }
}
