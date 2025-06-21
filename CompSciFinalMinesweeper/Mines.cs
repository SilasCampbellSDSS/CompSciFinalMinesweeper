using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompSciFinalMinesweeper
{
    class Mines
    {
        //Creating mines in a class
        public static int mineDimensions = 36;
        public Rectangle mineRect;

        public Mines(int x, int y, int size)
        {
            mineRect = new Rectangle(x, y, size, size);
        }
    }
}
