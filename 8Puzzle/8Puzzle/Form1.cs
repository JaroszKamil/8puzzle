using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace _8Puzzle
{
    public partial class Form1 : Form
    {
        string emptyPuzzle = string.Empty;
        Point[] []map = 
             {   new Point[] { new Point(25, 25), new Point(125, 25), new Point(225,25)},
                new Point[] {new Point(25,125), new Point(125,125), new Point(225,125)},
                new Point [] {new Point(25,225), new Point (125,225), new Point(225,225)}
              };
        Pathfinding mySolve;
        string bufor = string.Empty;

        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            this.Size = new Size(800, 600);
            buttonPanel.Width = this.Size.Width - (this.Size.Width /3);
            buttonPanel.Height = this.ClientSize.Height;
            buttonPanel.Top = 200;
            buttonPanel.Left = 25;
            instruction.Size = new Size(220, 400);
            instruction.Left = buttonPanel.Left + buttonPanel.Width + 10;

            foreach (Control button in buttonPanel.Controls)
            {
                button.Height = 100;
                button.Width = 100;
            }

            Start(); 

            mySolve = new Pathfinding();
                
        }

        private void Start()
        {

            //button1.Corner = Puzzle.AllCorner.LeftDown;
            //button2.Corner = Puzzle.AllCorner.RightDown;
            //button3.Corner = Puzzle.AllCorner.MiddleMiddle;
            //button4.Corner = Puzzle.AllCorner.RightUp;
            //button5.Corner = Puzzle.AllCorner.MiddleUp;
            //button6.Corner = Puzzle.AllCorner.MiddleDown;
            //button7.Corner = Puzzle.AllCorner.RightMiddle;
            //button8.Corner = Puzzle.AllCorner.LeftMiddle;
            //button9.Corner = Puzzle.AllCorner.LeftUP;

            //button1.Corner = Puzzle.AllCorner.LeftUP;
            //button2.Corner = Puzzle.AllCorner.MiddleUp;
            //button3.Corner = Puzzle.AllCorner.RightUp;
            //button4.Corner = Puzzle.AllCorner.LeftMiddle;
            //button5.Corner = Puzzle.AllCorner.MiddleDown;
            //button6.Corner = Puzzle.AllCorner.MiddleMiddle;
            //button7.Corner = Puzzle.AllCorner.LeftDown;
            //button8.Corner = Puzzle.AllCorner.RightDown;
            //button9.Corner = Puzzle.AllCorner.RightMiddle;

            //button1.Corner = Puzzle.AllCorner.MiddleUp;
            //button2.Corner = Puzzle.AllCorner.RightUp;
            //button3.Corner = Puzzle.AllCorner.RightMiddle;
            //button4.Corner = Puzzle.AllCorner.LeftUP;
            //button5.Corner = Puzzle.AllCorner.MiddleDown;
            //button6.Corner = Puzzle.AllCorner.LeftMiddle;
            //button7.Corner = Puzzle.AllCorner.LeftDown;
            //button8.Corner = Puzzle.AllCorner.RightDown;
            //button9.Corner = Puzzle.AllCorner.MiddleMiddle;


            button1.Corner = Puzzle.AllCorner.MiddleUp;
            button2.Corner = Puzzle.AllCorner.RightUp;
            button3.Corner = Puzzle.AllCorner.RightMiddle;
            button4.Corner = Puzzle.AllCorner.LeftMiddle;
            button5.Corner = Puzzle.AllCorner.MiddleMiddle;
            button6.Corner = Puzzle.AllCorner.LeftDown;
            button7.Corner = Puzzle.AllCorner.MiddleDown;
            button8.Corner = Puzzle.AllCorner.RightDown;
            button9.Corner = Puzzle.AllCorner.LeftUP;


            //button1.Corner = Puzzle.AllCorner.MiddleUp;
            //button2.Corner = Puzzle.AllCorner.RightMiddle;
            //button3.Corner = Puzzle.AllCorner.MiddleMiddle;
            //button4.Corner = Puzzle.AllCorner.LeftMiddle;
            //button5.Corner = Puzzle.AllCorner.RightUp;
            //button6.Corner = Puzzle.AllCorner.LeftDown;
            //button7.Corner = Puzzle.AllCorner.MiddleDown;
            //button8.Corner = Puzzle.AllCorner.RightDown;
            //button9.Corner = Puzzle.AllCorner.LeftUP;   // the Best 9:32.564

            //button1.Corner = Puzzle.AllCorner.LeftDown;
            //button2.Corner = Puzzle.AllCorner.LeftMiddle;
            //button3.Corner = Puzzle.AllCorner.MiddleDown;
            //button4.Corner = Puzzle.AllCorner.MiddleUp;
            //button5.Corner = Puzzle.AllCorner.MiddleMiddle;
            //button6.Corner = Puzzle.AllCorner.RightMiddle;
            //button7.Corner = Puzzle.AllCorner.RightUp;
            //button8.Corner = Puzzle.AllCorner.LeftUP;
            //button9.Corner = Puzzle.AllCorner.RightDown;

     
            SetPuzzle();
        }

        private void SetPuzzle()
        {
            foreach (Control button in buttonPanel.Controls)
            {
                if (button is Puzzle)
                {
                    Puzzle myPuzzle = button as Puzzle;

                    #region Up
                    ///////////////////////////////Up//////////////////////////////////
                    if (myPuzzle.Corner == Puzzle.AllCorner.LeftUP)
                    {
                        myPuzzle.Location = map[0][0];
                    }

                    if (myPuzzle.Corner == Puzzle.AllCorner.MiddleUp)
                    {
                        myPuzzle.Location = map[0][1];
                    }

                    if (myPuzzle.Corner == Puzzle.AllCorner.RightUp)
                    {
                        myPuzzle.Location = map[0][2];
                    }

                    #endregion

                    #region Middle
                    ////////////////////////////Middle/////////////////////
                    if (myPuzzle.Corner == Puzzle.AllCorner.LeftMiddle)
                    {
                        myPuzzle.Location = map[1][0];
                    }

                    if (myPuzzle.Corner == Puzzle.AllCorner.MiddleMiddle)
                    {
                        myPuzzle.Location = map[1][1];
                    }

                    if (myPuzzle.Corner == Puzzle.AllCorner.RightMiddle)
                    {
                        myPuzzle.Location = map[1][2];
                    }

                    #endregion

                    #region Down
                    ////////////////// Down ///////////////////////////////

                    if (myPuzzle.Corner == Puzzle.AllCorner.LeftDown)
                    {
                        myPuzzle.Location = map[2][0];
                    }

                    if (myPuzzle.Corner == Puzzle.AllCorner.MiddleDown)
                    {
                        myPuzzle.Location = map[2][1];
                    }

                    if (myPuzzle.Corner == Puzzle.AllCorner.RightDown)
                    {
                        myPuzzle.Location = map[2][2];
                    }

                    #endregion
                }
            }

            if (button1.Location == map[0][0] &&
                button2.Location == map[0][1] &&
                button3.Location == map[0][2] &&
                button4.Location == map[1][0] &&
                button5.Location == map[1][1] &&
                button6.Location == map[1][2] &&
                button7.Location == map[2][0] &&
                button8.Location == map[2][1])
            {
                DialogResult result = MessageBox.Show("Wygrales restart gry ?","Koniec Gry !", MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Start();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private bool CheckMove(object sender)
        {
            if (sender is Puzzle)
            {
                Puzzle button = sender as Puzzle;

                if (button.Location.X + 100 ==  button9.Location.X && button.Location.Y == button9.Location.Y
                    || button.Location.X - 100 == button9.Location.X && button.Location.Y == button9.Location.Y
                    || button.Location.X == button9.Location.X && button.Location.Y == button9.Location.Y + 100
                    || button.Location.X == button9.Location.X && button.Location.Y == button9.Location.Y - 100)
                {
                    return true;
                }
            }

            return false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Puzzle bufor = new Puzzle();

            if (sender is Puzzle)
            {
                Puzzle button = sender as Puzzle;

                if (CheckMove(button))
                {
                    bufor.Corner = button.Corner;
                    button.Corner = button9.Corner;
                    button9.Corner = bufor.Corner;
                }

                SetPuzzle();
            }
        }

        private void Solve_Click(object sender, EventArgs e)
        {
            System.DateTime clock = new DateTime();
            System.DateTime end = new DateTime();
            clock = DateTime.Now;

            Thread first = new Thread(dupa);

            first.Start();
            first.Join();

            instruction.Text = bufor;

            end = DateTime.Now;

            instruction.Text += end - clock;
        }

        private void dupa()
        {   
            bufor = mySolve.Solve(buttonPanel);
        }

    }
}
