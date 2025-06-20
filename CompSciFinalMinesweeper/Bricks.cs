using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompSciFinalMinesweeper
{
    class Bricks
    {
        public static int rowsColumns = 19;
        public static int brickDimensions = 36;
        public static int spacing = 5;
        public static int startingSpacing = 10;

        public int x, y;
        public Rectangle rect;
        public int nearMines = 0;
        public bool isRevealed = false;
        public bool isFlagged = false;

        public Bricks(int x, int y, int size)
        {
            this.x = x;
            this.y = y;
            rect = new Rectangle(x, y, size, size);
        }
        
    }
}
