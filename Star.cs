using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms_04
{
    class Star : BaseObject
    {
        private Image img;
        private Point secondpos;
        public Star(Point pos,Point dir, Size size) : base(pos, dir, size)
        {
            img = Image.FromFile($"{Application.StartupPath}/rsz_pixelart.png");
            secondpos = new Point(pos.X+img.Width, pos.Y+img.Height);
        }

        public override void Draw()
        {            
            Game.buffer.Graphics.DrawImage(img, base.pos);
        }

        public override void Update()
        {
            secondpos.X = secondpos.X + dir.X;
            secondpos.Y = secondpos.Y + dir.Y;
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;

            if (pos.X < 0 ||  secondpos.X > Game.Width)
            {
                dir.X = -dir.X;
            }
            if (pos.Y < 0 ||  secondpos.Y > Game.Height)
            {
                dir.Y = -dir.Y;
            }
        }

    }
}
