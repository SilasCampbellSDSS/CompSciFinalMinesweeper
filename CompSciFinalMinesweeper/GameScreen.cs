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

    //Lists for creating bricks, mines and overlays
        List<Bricks> bricks = new List<Bricks>();
        List<Mines> mines = new List<Mines>();
        List<Rectangle> clickedBrick = new List<Rectangle>();
        List<Rectangle> clickedFlag = new List<Rectangle>();

    //Creating the rectangle that follows the cursor. We use that to track where you're clicking
        SolidBrush brush = new SolidBrush(Color.Black);
        Rectangle click = new Rectangle(0, 0, 10, 10);

    //Basic global variables
        Random randomGen = new Random();
        bool _flagSelect = false;
        bool loss = false;
        int minesClicked;

        public GameScreen()
        {
        //Calling methods
            InitializeComponent();
            CreateBricks();
            CalculateNearMines();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
        //Displaying number of mines that remain based on how many flags you're put down
            mineNumber.Text = $"{mines.Count - clickedFlag.Count}";
            
        //Grabbing cursor coordinates 
            int cursorX = Cursor.Position.X;
            int cursorY = Cursor.Position.Y - 20;

        //Creating rectangle
            click = new Rectangle(cursorX, cursorY, 10, 10);
            Refresh();
        }

        private void GameScreen_Click(object sender, EventArgs e)
        {
        //Where all of our code for flagging and revealing bricks is
            for (int i = 0; i < bricks.Count; i++)
            {
                if (click.IntersectsWith(bricks[i].rect))
                {
                //If flagging is toggled on
                    if (_flagSelect)
                    {
                    //If brick has not already been flagged or revealed, flag it.
                        if (!bricks[i].isFlagged && !bricks[i].isRevealed)
                        {

                        //Making sure we don't add two flags to the same overlay
                            if (!clickedFlag.Contains(bricks[i].rect))
                            {
                                clickedFlag.Add(bricks[i].rect);
                            }
                                
                            bricks[i].isFlagged = true;
                        }
                        else if (bricks[i].isFlagged)
                        {
                        //Unflag it if it is already flagged
                            clickedFlag.Remove(bricks[i].rect);
                            bricks[i].isFlagged = false;
                        }
                    }
                    else
                    {
                    //If you click on a flagged brick nothing happens. If it isn't reveal it.
                        if (!bricks[i].isFlagged)
                        {
                            clickedBrick.Add(bricks[i].rect);
                            bricks[i].isRevealed = true;
                        }
                    }
                }
            }

            for (int i = 0; i < mines.Count; i++)
            {
                if (click.IntersectsWith(mines[i].mineRect))
                {
                //Flag the mine if flagging is on, blow you up if not
                    if (_flagSelect)
                    {
                        if (!mines[i].isFlagged)
                        {
                        //Making sure we don't double overlay
                            if (!clickedFlag.Contains(mines[i].mineRect))
                            {
                                clickedFlag.Add(mines[i].mineRect);
                            }

                            mines[i].isFlagged = true;
                            minesClicked++;
                        }
                        else
                        {
                            clickedFlag.Remove(mines[i].mineRect);
                            mines[i].isFlagged = false;
                            minesClicked--;
                        }

                    //If all of the mines are correctly flagged, you win
                        bool allCorrect = mines.All(m => m.isFlagged);
                        if (allCorrect)
                        {
                            loss = false;
                            GameOver();
                            return;
                        }
                    }
                    //If you click on a mine when flagging is off and the mine is not flagged, you lose
                    else if (!mines[i].isFlagged)
                    {
                        loss = true;
                        GameOver();
                        return;
                    }
                }
            }
        }

        public void CreateBricks()
        {
        //Create a whole lotta bricks
            for (int i = 0; i < Bricks.rowsColumns; i++)
            {
                for (int j = 0; j < Bricks.rowsColumns; j++)
                {
                    int x = j * (Bricks.brickDimensions + Bricks.spacing) + Bricks.startingSpacing;
                    int y = i * (Bricks.brickDimensions + Bricks.spacing) + 53;
                    int mineChance = randomGen.Next(1, 21);

                //Make 15% mines
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
        //Creating an orbital of rectangles that are spaced out the same as the bricks around your main rectangle then add it to an array
            foreach (var brick in bricks)
            {
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

            //If any of the orbitals intersect with a mine, add it to the variable
                foreach (var orbital in orbitals)
                {
                    if (mines.Any(m => orbital.IntersectsWith(m.mineRect)))
                    {
                        brick.nearMines++;
                    }
                }
            }
        }

        public void GameOver()
        {
        //Display a message based on whether you won or lost
            instructionsLabel.Visible = true;

            if (loss)
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
        //Return an image based on how many mines are around (nearmine variable)
            switch (nearMines)
            {
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
        //Draw each brick. If it has been revealed grab an image from the Image method. Else just have it as a default
        //If it has been flagged grab that image from properties.resources
        //If you lose, make all bricks blank
            foreach (var brick in bricks)
            {
                if (loss)
                {
                    e.Graphics.DrawImage(Properties.Resources.openedMine, brick.rect);
                }
                else
                {
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
                }
            }

        //Same case for bricks
            foreach (var mine in mines)
            {
                e.Graphics.DrawImage(loss ? Properties.Resources.mine : Properties.Resources.unopenedMine, mine.mineRect);
            }

            foreach (var flag in clickedFlag)
            {
                e.Graphics.DrawImage(loss ? Properties.Resources.openedMine : Properties.Resources.flaggedMine, flag);
            }

            e.Graphics.FillRectangle(brush, click);
        }

        private void flagSelect_Click(object sender, EventArgs e)
        {
            _flagSelect = !_flagSelect;
        }

//Reset values
        private void newGame_Click(object sender, EventArgs e)
        {
            bricks.Clear();
            mines.Clear();
            clickedBrick.Clear();
            clickedFlag.Clear();
            minesClicked = 0;
            loss = false;

            CreateBricks();
            CalculateNearMines();
            Refresh();

            instructionsLabel.Text = "- Click on flag icon to toggle to flagging items, click to switch back\r\n- Click on plus icon to restart game\r\n- Click ESC key to leave game\r\n- When a square is uncovered and does not display a number that means that there are no mines nearby\r\n- Click on this label to close it :)";
            instructionsLabel.Visible = false;
        }

    //Show instruction label
        private void infoSelect_Click(object sender, EventArgs e)
        {
            instructionsLabel.Visible = true;
        }

        private void instructionsLabel_Click(object sender, EventArgs e)
        {
            instructionsLabel.Visible = false;
        }

    //Allow you to leave the game
        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }

}
