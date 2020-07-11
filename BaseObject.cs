using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WinForms_04
{
    class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public void Draw()
        {
            Game.buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
        }

        public void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;

            if (pos.X<0 || pos.X>Game.Width) 
            {
                dir.X = -dir.X;
            }
            if (pos.Y<0 || pos.Y>Game.Height)
            {
                dir.Y = -dir.Y;
            }
        }
    }
}
