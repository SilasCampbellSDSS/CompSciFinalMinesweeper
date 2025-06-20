namespace CompSciFinalMinesweeper
{
    partial class GameScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.mineNumber = new System.Windows.Forms.Label();
            this.infoSelect = new System.Windows.Forms.PictureBox();
            this.flagSelect = new System.Windows.Forms.PictureBox();
            this.newGame = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.instructionsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.infoSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flagSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newGame)).BeginInit();
            this.SuspendLayout();
            // 
            // mineNumber
            // 
            this.mineNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(45)))));
            this.mineNumber.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mineNumber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mineNumber.Location = new System.Drawing.Point(0, 0);
            this.mineNumber.Name = "mineNumber";
            this.mineNumber.Size = new System.Drawing.Size(800, 50);
            this.mineNumber.TabIndex = 2;
            this.mineNumber.Text = "000";
            this.mineNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoSelect
            // 
            this.infoSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(45)))));
            this.infoSelect.Image = global::CompSciFinalMinesweeper.Properties.Resources.questionmark__1_;
            this.infoSelect.Location = new System.Drawing.Point(750, 0);
            this.infoSelect.Name = "infoSelect";
            this.infoSelect.Size = new System.Drawing.Size(50, 50);
            this.infoSelect.TabIndex = 6;
            this.infoSelect.TabStop = false;
            this.infoSelect.Click += new System.EventHandler(this.infoSelect_Click);
            // 
            // flagSelect
            // 
            this.flagSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(45)))));
            this.flagSelect.Image = global::CompSciFinalMinesweeper.Properties.Resources.flag__1_;
            this.flagSelect.Location = new System.Drawing.Point(315, 0);
            this.flagSelect.Name = "flagSelect";
            this.flagSelect.Size = new System.Drawing.Size(50, 50);
            this.flagSelect.TabIndex = 5;
            this.flagSelect.TabStop = false;
            this.flagSelect.Click += new System.EventHandler(this.flagSelect_Click);
            // 
            // newGame
            // 
            this.newGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(45)))));
            this.newGame.Image = global::CompSciFinalMinesweeper.Properties.Resources.plus__1_;
            this.newGame.Location = new System.Drawing.Point(0, 0);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(50, 50);
            this.newGame.TabIndex = 3;
            this.newGame.TabStop = false;
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(45)))));
            this.instructionsLabel.Font = new System.Drawing.Font("Cambria", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.instructionsLabel.Location = new System.Drawing.Point(200, 200);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(400, 400);
            this.instructionsLabel.TabIndex = 7;
            this.instructionsLabel.Text = resources.GetString("instructionsLabel.Text");
            this.instructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.instructionsLabel.Visible = false;
            this.instructionsLabel.Click += new System.EventHandler(this.instructionsLabel_Click);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.infoSelect);
            this.Controls.Add(this.flagSelect);
            this.Controls.Add(this.newGame);
            this.Controls.Add(this.mineNumber);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(800, 850);
            this.Click += new System.EventHandler(this.GameScreen_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.infoSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flagSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label mineNumber;
        private System.Windows.Forms.PictureBox newGame;
        private System.Windows.Forms.PictureBox flagSelect;
        private System.Windows.Forms.PictureBox infoSelect;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label instructionsLabel;
    }
}
