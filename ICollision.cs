using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WinForms_04
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle rectangle { get; }
        

    }
}
