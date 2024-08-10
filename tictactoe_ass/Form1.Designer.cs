namespace tictactoe_ass
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            tictaclbl = new Label();
            EXITBTN = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(263, 114);
            label1.Name = "label1";
            label1.Size = new Size(69, 18);
            label1.TabIndex = 0;
            label1.Text = "Player1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(488, 114);
            label2.Name = "label2";
            label2.Size = new Size(70, 18);
            label2.TabIndex = 1;
            label2.Text = "Player2";
            // 
            // button1
            // 
            button1.Location = new Point(263, 165);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(96, 87);
            button1.TabIndex = 2;
            button1.Text = "-";
            button1.UseVisualStyleBackColor = true;
            button1.Click += PlayerClick;
            // 
            // button2
            // 
            button2.Location = new Point(366, 165);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(96, 87);
            button2.TabIndex = 3;
            button2.Text = "-";
            button2.UseVisualStyleBackColor = true;
            button2.Click += PlayerClick;
            // 
            // button3
            // 
            button3.Location = new Point(469, 165);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(96, 87);
            button3.TabIndex = 4;
            button3.Text = "-";
            button3.UseVisualStyleBackColor = true;
            button3.Click += PlayerClick;
            // 
            // button4
            // 
            button4.Location = new Point(263, 259);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(96, 87);
            button4.TabIndex = 5;
            button4.Text = "-";
            button4.UseVisualStyleBackColor = true;
            button4.Click += PlayerClick;
            // 
            // button5
            // 
            button5.Location = new Point(366, 259);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(96, 87);
            button5.TabIndex = 6;
            button5.Text = "-";
            button5.UseVisualStyleBackColor = true;
            button5.Click += PlayerClick;
            // 
            // button6
            // 
            button6.Location = new Point(469, 259);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(96, 87);
            button6.TabIndex = 7;
            button6.Text = "-";
            button6.UseVisualStyleBackColor = true;
            button6.Click += PlayerClick;
            // 
            // button7
            // 
            button7.Location = new Point(263, 354);
            button7.Margin = new Padding(3, 4, 3, 4);
            button7.Name = "button7";
            button7.Size = new Size(96, 87);
            button7.TabIndex = 8;
            button7.Text = "-";
            button7.UseVisualStyleBackColor = true;
            button7.Click += PlayerClick;
            // 
            // button8
            // 
            button8.Location = new Point(366, 354);
            button8.Margin = new Padding(3, 4, 3, 4);
            button8.Name = "button8";
            button8.Size = new Size(96, 87);
            button8.TabIndex = 9;
            button8.Text = "-";
            button8.UseVisualStyleBackColor = true;
            button8.Click += PlayerClick;
            // 
            // button9
            // 
            button9.Location = new Point(469, 354);
            button9.Margin = new Padding(3, 4, 3, 4);
            button9.Name = "button9";
            button9.Size = new Size(96, 87);
            button9.TabIndex = 10;
            button9.Text = "-";
            button9.UseVisualStyleBackColor = true;
            button9.Click += PlayerClick;
            // 
            // button10
            // 
            button10.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button10.Location = new Point(379, 479);
            button10.Margin = new Padding(3, 4, 3, 4);
            button10.Name = "button10";
            button10.Size = new Size(96, 43);
            button10.TabIndex = 11;
            button10.Text = "restart";
            button10.UseVisualStyleBackColor = true;
            button10.Click += Restart_Game_X;
            // 
            // timer1
            // 
            timer1.Tick += TurnTimer_Tick;
            // 
            // tictaclbl
            // 
            tictaclbl.AutoSize = true;
            tictaclbl.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            tictaclbl.Location = new Point(325, 31);
            tictaclbl.Name = "tictaclbl";
            tictaclbl.Size = new Size(182, 35);
            tictaclbl.TabIndex = 12;
            tictaclbl.Text = "TIC TAC TOE ";
            // 
            // EXITBTN
            // 
            EXITBTN.Location = new Point(776, 16);
            EXITBTN.Name = "EXITBTN";
            EXITBTN.Size = new Size(73, 23);
            EXITBTN.TabIndex = 13;
            EXITBTN.Text = "X";
            EXITBTN.UseVisualStyleBackColor = true;
            EXITBTN.Click += EXITBTN_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(861, 600);
            Controls.Add(EXITBTN);
            Controls.Add(tictaclbl);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private System.Windows.Forms.Timer timer1;
        private Label tictaclbl;
        private Button EXITBTN;
    }
}