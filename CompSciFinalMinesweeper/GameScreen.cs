using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace CompSciFinalMinesweeper
{
    public partial class GameScreen : UserControl
    {
    //Lists for bricks, mines and our flags (no class for flags, just rectangles)
        List<Bricks> bricks = new List<Bricks>();
        List<Mines> mines = new List<Mines>();
        List<Rectangle> clickedBrick = new List<Rectangle>();
        List<Rectangle> clickedFlag = new List<Rectangle>();

    //Rectangle to see precisely where you're clicking
        SolidBrush brush = new SolidBrush(Color.Black);
        Rectangle click = new Rectangle(0, 0, 10, 10);

    //Random generator for mines and bool variables
        Random randomGen = new Random();
        bool _flagSelect = false;
        bool loss = false;
        int minesClicked;

        public GameScreen()
        {
            InitializeComponent();
            CreateBricks();
            CalculateNearMines();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
        //How many mines remain
            mineNumber.Text = $"{mines.Count() - clickedFlag.Count()}";

        //Getting cursor position
            int cursorX = Cursor.Position.X;
            int cursorY = Cursor.Position.Y - 20;

        //Placing rectangle at cursor coordinates
            click = new Rectangle(cursorX, cursorY, 10, 10);
            Refresh();

            
        }

        private void GameScreen_Click(object sender, EventArgs e)
        {

            //If you click a brick
            for (int i = 0; i < bricks.Count; i++)
            {
                if (click.IntersectsWith(bricks[i].rect))
                {
                    if (_flagSelect)
                    {
                    //If you have flag toggled on flag it, add it to the list and keep track of it
                        clickedFlag.Add(bricks[i].rect);
                        bricks[i].isFlagged = true;
                    }
                    else
                    {
                    //If you don't have flag toggled on, add the brick to a seperate list and keep track of it
                        clickedBrick.Add(bricks[i].rect);
                        bricks[i].isRevealed = true;

                    }
                }
            }

            foreach (var mine in mines)
            {
                if (click.IntersectsWith(mine.mineRect))
                {
                    if (_flagSelect)
                    {
                    //Same case as bricks
                        clickedFlag.Add(mine.mineRect);
                        minesClicked++;

                        if (minesClicked == mines.Count())
                        {
                            loss = false;
                            GameOver();
                            return;
                        }
                    }
                    else
                    {

                    //If you click on a mine when you don't have flag toggled on then call Game Over

                        loss = true;

                        GameOver();
                        return;
                    }
                }
            }
        }

        public void CreateBricks()
        {
        //Create a column of bricks, then create rows of each of those so that the whole board is covered
            for (int i = 0; i < Bricks.rowsColumns; i++)
            {
                for (int j = 0; j < Bricks.rowsColumns; j++)
                {
                //Calculations for where to place bricks
                    int x = j * (Bricks.brickDimensions + Bricks.spacing) + Bricks.startingSpacing;
                    int y = i * (Bricks.brickDimensions + Bricks.spacing) + 53;
                    int mineChance = randomGen.Next(1, 21);

                //Making 15% mines, rest bricks
                    if (mineChance < 4)
                    {
                        mines.Add(new Mines(x, y, Mines.mineDimensions));
                    }
                    else
                    {
                        bricks.Add(new Bricks(x, y, Bricks.brickDimensions));
                    }
                }
            }
        }

        public void CalculateNearMines()
        {
            foreach (var brick in bricks)
            {
            //Array of rectangles orbiting the main rectangle (cursor). 
            //I use these to intercect with bricks around the one the player is clicking on, 
            //then I can keep track of where mines are and update visuals accordingly
            
                Rectangle[] orbitals =
                {
                    new Rectangle(brick.x + 42, brick.y, 10, 10),
                    new Rectangle(brick.x - 42, brick.y, 10, 10),
                    new Rectangle(brick.x, brick.y + 42, 10, 10),
                    new Rectangle(brick.x, brick.y - 42, 10, 10),
                    new Rectangle(brick.x + 42, brick.y + 42, 10, 10),
                    new Rectangle(brick.x - 42, brick.y + 42, 10, 10),
                    new Rectangle(brick.x + 42, brick.y - 42, 10, 10),
                    new Rectangle(brick.x - 42, brick.y - 42, 10, 10),
                };

                foreach (var orbital in orbitals)
                {
                //If these orbitals intercect with a mine then tally that off on a non static variable that applies to all bricks 
                //This took me forever to figure out how to do properly 
                
                    if (mines.Any(m => orbital.IntersectsWith(m.mineRect)))
                    {
                        brick.nearMines++;
                    }
                }
            }
        }

        public void GameOver()
        {
        //Update bool variable
            loss = true;

        //Display message
            instructionsLabel.Visible = true;

            if (loss == true)
            {
                instructionsLabel.Text = "YOU LOST, PRESS + TO PLAY AGAIN";
            }
            else
            {
                instructionsLabel.Text = "YOU WON, PRESS + TO PLAY AGAIN";
            }
            
        }

        private Image DisplayNearMines(int nearMines)
        {
            switch (nearMines)
            {
            //Creating a method that grabs how many mines are near and display the appropriate image
            //Learned how to do this from Alistair in the brick breaker project so shout out to him
                case 0: return Properties.Resources.openedMine;
                case 1: return Properties.Resources._1near;
                case 2: return Properties.Resources._2near;
                case 3: return Properties.Resources._3near;
                case 4: return Properties.Resources._4near;
                case 5: return Properties.Resources._5near;
                case 6: return Properties.Resources._6near;
                case 7: return Properties.Resources._7near;
                case 8: return Properties.Resources._8near;
                default: return Properties.Resources.unopenedMine;
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (var brick in bricks)
            {
            //If the game is active display bricks accordingly
                if (loss == false)
                    if (brick.isRevealed)
                    {
                        e.Graphics.DrawImage(DisplayNearMines(brick.nearMines), brick.rect);
                    }
                    else if (brick.isFlagged)
                    {
                        e.Graphics.DrawImage(Properties.Resources.flaggedMine, brick.rect);
                    }
                    else
                    {
                        e.Graphics.DrawImage(Properties.Resources.unopenedMine, brick.rect);
                    }
                //If the game is over make all non mines transparent 
                else
                {
                    e.Graphics.DrawImage(Properties.Resources.openedMine, brick.rect);
                }
                
            }

            foreach (var mine in mines)
            {
            //Same as above except that when you lose show where the mines are
                if (loss == false)
                    e.Graphics.DrawImage(Properties.Resources.unopenedMine, mine.mineRect);
                else
                {
                    e.Graphics.DrawImage(Properties.Resources.mine, mine.mineRect);
                }
            }

            foreach (var flag in clickedFlag)
            {
            //Same code but with flags
                if (loss == false)
                     e.Graphics.DrawImage(Properties.Resources.flaggedMine, flag);
                else
                {
                    e.Graphics.DrawImage(Properties.Resources.openedMine, flag);
                }

            }

        //Fill in the cursor rectangle
            e.Graphics.FillRectangle(brush, click);
        }

        private void flagSelect_Click(object sender, EventArgs e)
        {
        //Toggling flagging on and off
            _flagSelect = !_flagSelect;
        }

        private void newGame_Click(object sender, EventArgs e)
        {
        //Creating new values and resetting messages
            bricks.Clear();
            mines.Clear();
            clickedBrick.Clear();
            clickedFlag.Clear();
            CreateBricks();
            CalculateNearMines();
            Refresh();

            instructionsLabel.Text = "- Click on flag icon to toggle to flagging items, click to switch back\r\n- Click on plus icon to restart game\r\n- Click ESC key to leave game\r\n- When a square is uncovered and does not display a number that means that there are no mines nearby\r\n- Click on this label to close it :)\r\n";
            instructionsLabel.Visible = false;
            loss = false;

        }

        private void infoSelect_Click(object sender, EventArgs e)
        {
            instructionsLabel.Visible = true;
        }

        private void instructionsLabel_Click(object sender, EventArgs e)
        {
            if (instructionsLabel.Visible == true)
            {
                instructionsLabel.Visible = false;
            }
        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
        //Letting you get out of the game
        
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
            
        }
    }
}
