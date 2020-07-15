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
        public Star(Point pos,Point dir, Size size) : base(pos, dir, size)
        {
            
        }

        public override void Draw()
        {
            img = Image.FromFile($"{Application.StartupPath}/rsz_pixelart.png");
            Game.buffer.Graphics.DrawImage(img, base.pos);
        }

    }
}
