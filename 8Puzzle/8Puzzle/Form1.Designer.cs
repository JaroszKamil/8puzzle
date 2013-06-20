namespace _8Puzzle
{
    partial class Form1
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
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.Solve = new System.Windows.Forms.Button();
            this.button9 = new _8Puzzle.Puzzle();
            this.button6 = new _8Puzzle.Puzzle();
            this.button3 = new _8Puzzle.Puzzle();
            this.button8 = new _8Puzzle.Puzzle();
            this.button5 = new _8Puzzle.Puzzle();
            this.button2 = new _8Puzzle.Puzzle();
            this.button7 = new _8Puzzle.Puzzle();
            this.button4 = new _8Puzzle.Puzzle();
            this.button1 = new _8Puzzle.Puzzle();
            this.instruction = new System.Windows.Forms.TextBox();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.Solve);
            this.buttonPanel.Controls.Add(this.button9);
            this.buttonPanel.Controls.Add(this.button6);
            this.buttonPanel.Controls.Add(this.button3);
            this.buttonPanel.Controls.Add(this.button8);
            this.buttonPanel.Controls.Add(this.button5);
            this.buttonPanel.Controls.Add(this.button2);
            this.buttonPanel.Controls.Add(this.button7);
            this.buttonPanel.Controls.Add(this.button4);
            this.buttonPanel.Controls.Add(this.button1);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(553, 497);
            this.buttonPanel.TabIndex = 0;
            // 
            // Solve
            // 
            this.Solve.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Solve.Location = new System.Drawing.Point(0, 409);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(553, 88);
            this.Solve.TabIndex = 9;
            this.Solve.Text = "Solve";
            this.Solve.UseVisualStyleBackColor = true;
            this.Solve.Click += new System.EventHandler(this.Solve_Click);
            // 
            // button9
            // 
            this.button9.Corner = _8Puzzle.Puzzle.AllCorner.LeftUP;
            this.button9.Location = new System.Drawing.Point(356, 242);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(157, 109);
            this.button9.TabIndex = 8;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button6
            // 
            this.button6.Corner = _8Puzzle.Puzzle.AllCorner.LeftUP;
            this.button6.Location = new System.Drawing.Point(356, 127);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(157, 109);
            this.button6.TabIndex = 7;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button3
            // 
            this.button3.Corner = _8Puzzle.Puzzle.AllCorner.LeftUP;
            this.button3.Location = new System.Drawing.Point(356, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 109);
            this.button3.TabIndex = 6;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button8
            // 
            this.button8.Corner = _8Puzzle.Puzzle.AllCorner.LeftUP;
            this.button8.Location = new System.Drawing.Point(193, 242);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(157, 109);
            this.button8.TabIndex = 5;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button5
            // 
            this.button5.Corner = _8Puzzle.Puzzle.AllCorner.LeftUP;
            this.button5.Location = new System.Drawing.Point(193, 127);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(157, 109);
            this.button5.TabIndex = 4;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Corner = _8Puzzle.Puzzle.AllCorner.LeftUP;
            this.button2.Location = new System.Drawing.Point(193, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 109);
            this.button2.TabIndex = 3;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button7
            // 
            this.button7.Corner = _8Puzzle.Puzzle.AllCorner.LeftUP;
            this.button7.Location = new System.Drawing.Point(30, 242);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(157, 109);
            this.button7.TabIndex = 2;
            this.button7.Text = "7";
            this.button7.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button4
            // 
            this.button4.Corner = _8Puzzle.Puzzle.AllCorner.LeftUP;
            this.button4.Location = new System.Drawing.Point(30, 127);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(157, 109);
            this.button4.TabIndex = 1;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button1
            // 
            this.button1.Corner = _8Puzzle.Puzzle.AllCorner.LeftUP;
            this.button1.Location = new System.Drawing.Point(30, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 109);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // instruction
            // 
            this.instruction.Location = new System.Drawing.Point(557, 6);
            this.instruction.Multiline = true;
            this.instruction.Name = "instruction";
            this.instruction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.instruction.Size = new System.Drawing.Size(157, 393);
            this.instruction.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 497);
            this.Controls.Add(this.instruction);
            this.Controls.Add(this.buttonPanel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.TextBox instruction;
        private _8Puzzle.Puzzle button6;
        private _8Puzzle.Puzzle button3;
        private _8Puzzle.Puzzle button8;
        private _8Puzzle.Puzzle button5;
        private _8Puzzle.Puzzle button2;
        private _8Puzzle.Puzzle button7;
        private _8Puzzle.Puzzle button4;
        private _8Puzzle.Puzzle button1;
        private _8Puzzle.Puzzle button9;
        private System.Windows.Forms.Button Solve;
    }
}

