namespace tictactoe_ass
{
    partial class Image_Sliding_Puzzle
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image_Sliding_Puzzle));
            list_lbl = new Label();
            stat_lbl = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            exitbtn = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // list_lbl
            // 
            list_lbl.AutoSize = true;
            list_lbl.Location = new Point(50, 30);
            list_lbl.Margin = new Padding(4, 0, 4, 0);
            list_lbl.Name = "list_lbl";
            list_lbl.Size = new Size(38, 18);
            list_lbl.TabIndex = 9;
            list_lbl.Text = "List";
            list_lbl.Click += list_lbl_Click;
            // 
            // stat_lbl
            // 
            stat_lbl.AutoSize = true;
            stat_lbl.Location = new Point(15, 70);
            stat_lbl.Margin = new Padding(4, 0, 4, 0);
            stat_lbl.Name = "stat_lbl";
            stat_lbl.Size = new Size(111, 18);
            stat_lbl.TabIndex = 10;
            stat_lbl.Text = "Game_Status";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 2, 0, 2);
            menuStrip1.Size = new Size(1000, 26);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem });
            fileToolStripMenuItem.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(52, 22);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(130, 26);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += Open_File;
            // 
            // exitbtn
            // 
            exitbtn.Location = new Point(906, 25);
            exitbtn.Name = "exitbtn";
            exitbtn.Size = new Size(94, 29);
            exitbtn.TabIndex = 12;
            exitbtn.Text = "X";
            exitbtn.UseVisualStyleBackColor = true;
            exitbtn.Click += exitbtn_Click;
            // 
            // Image_Sliding_Puzzle
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1000, 519);
            Controls.Add(exitbtn);
            Controls.Add(stat_lbl);
            Controls.Add(list_lbl);
            Controls.Add(menuStrip1);
            Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Image_Sliding_Puzzle";
            Text = "Image_Sliding_Puzzle";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label list_lbl;
        private Label stat_lbl;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private Button exitbtn;
    }
}