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
        //Values for organization when making bricks
        public static int rowsColumns = 19;
        public static int brickDimensions = 36;
        public static int spacing = 5;
        public static int startingSpacing = 10;

        //More variables. Part of my problem was as simple as having nearMines on public static instead of public.
        public int x, y;
        public Rectangle rect;
        public int nearMines = 0;
        public bool isRevealed = false;
        public bool isFlagged = false;

        //Creating the rectangles
        public Bricks(int x, int y, int size)
        {
            this.x = x;
            this.y = y;
            rect = new Rectangle(x, y, size, size);
        }
        
    }
}
