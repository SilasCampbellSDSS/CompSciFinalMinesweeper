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
        List<Bricks> bricks = new List<Bricks>();
        List<Mines> mines = new List<Mines>();
        List<Rectangle> clickedBrick = new List<Rectangle>();
        List<Rectangle> clickedFlag = new List<Rectangle>();

        SolidBrush brush = new SolidBrush(Color.Black);
        Rectangle click = new Rectangle(0, 0, 10, 10);

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

            mineNumber.Text = $"{mines.Count() - clickedFlag.Count()}";
            int cursorX = Cursor.Position.X;
            int cursorY = Cursor.Position.Y - 20;

            click = new Rectangle(cursorX, cursorY, 10, 10);
            Refresh();

            
        }

        private void GameScreen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                if (click.IntersectsWith(bricks[i].rect))
                {
                    if (_flagSelect)
                    {
                        if (bricks[i].isFlagged == false && bricks[i].isRevealed == false)
                        {
                            clickedFlag.Add(bricks[i].rect);
                            bricks[i].isFlagged = true;
                        }

                        if (bricks[i].isFlagged == true)
                        {
                            bricks[i].isFlagged = false;
                        }
                    }
                    else 
                    {
                        clickedBrick.Add(bricks[i].rect);
                        bricks[i].isRevealed = true;

                    }
                }
            }

            for (int i = 0; i < mines.Count(); i++)
            {
                if (click.IntersectsWith(mines[i].mineRect))
                {
                    if (_flagSelect)
                    {
                        if (mines[i].isFlagged == false)
                        {
                            clickedFlag.Add(mines[i].mineRect);
                            minesClicked++;
                            mines[i].isFlagged = true;
                        }
                        else
                        {
                            for(int j = 0; j < clickedFlag.Count(); j++)
                            {
                                clickedFlag.RemoveAt(j);
                            }

                            mines[i].isFlagged = false;
                            minesClicked--;
                        }

                        if (minesClicked == mines.Count())
                        {
                            loss = false;
                            GameOver();
                            return;
                        }
                    }
                    else
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
            for (int i = 0; i < Bricks.rowsColumns; i++)
            {
                for (int j = 0; j < Bricks.rowsColumns; j++)
                {
                    int x = j * (Bricks.brickDimensions + Bricks.spacing) + Bricks.startingSpacing;
                    int y = i * (Bricks.brickDimensions + Bricks.spacing) + 53;
                    int mineChance = randomGen.Next(1, 21);

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
                    if (mines.Any(m => orbital.IntersectsWith(m.mineRect)))
                    {
                        brick.nearMines++;
                    }
                }
            }
        }

        public void GameOver()
        {
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
                else
                {
                    e.Graphics.DrawImage(Properties.Resources.openedMine, brick.rect);
                }
                
            }

            foreach (var mine in mines)
            {
                if (loss == false)
                    e.Graphics.DrawImage(Properties.Resources.unopenedMine, mine.mineRect);
                else
                {
                    e.Graphics.DrawImage(Properties.Resources.mine, mine.mineRect);
                }
            }

            foreach (var flag in clickedFlag)
            {
                if (loss == false)
                     e.Graphics.DrawImage(Properties.Resources.flaggedMine, flag);
                else
                {
                    e.Graphics.DrawImage(Properties.Resources.openedMine, flag);
                }

            }

            e.Graphics.FillRectangle(brush, click);
        }

        private void flagSelect_Click(object sender, EventArgs e)
        {
            _flagSelect = !_flagSelect;
        }

        private void newGame_Click(object sender, EventArgs e)
        {
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
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
            
        }
    }
}
