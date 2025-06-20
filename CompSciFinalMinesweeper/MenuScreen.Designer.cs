namespace CompSciFinalMinesweeper
{
    partial class MenuScreen
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.play = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Cambria", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.titleLabel.Location = new System.Drawing.Point(-3, 120);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(800, 130);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "MINESWEEPER";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Image = global::CompSciFinalMinesweeper.Properties.Resources.bomb_37077_1280__1_;
            this.label1.Location = new System.Drawing.Point(250, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 300);
            this.label1.TabIndex = 4;
            // 
            // play
            // 
            this.play.AutoSize = true;
            this.play.BackColor = System.Drawing.Color.Transparent;
            this.play.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play.ForeColor = System.Drawing.Color.DarkRed;
            this.play.Image = global::CompSciFinalMinesweeper.Properties.Resources.bomb_37077_1280__1_;
            this.play.Location = new System.Drawing.Point(347, 360);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(105, 43);
            this.play.TabIndex = 5;
            this.play.Text = "PLAY";
            this.play.Click += new System.EventHandler(this.label2_Click);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(45)))));
            this.BackgroundImage = global::CompSciFinalMinesweeper.Properties.Resources.background;
            this.Controls.Add(this.play);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLabel);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(800, 850);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label play;
    }
}
