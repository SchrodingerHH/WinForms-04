using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms_04
{
    abstract class BaseObject : ICollision
    {
        public bool Collision(ICollision obj) => obj.rectangle.IntersectsWith(this.rectangle);
        public Rectangle rectangle => new Rectangle(pos, size);
        public delegate void Message();

        protected Point pos;
        protected Point dir;
        protected Size size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public abstract void Draw();
        /*{
            Game.buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
        }*/

        public abstract void Update();
            
        /*{
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
        }*/
    }
}
