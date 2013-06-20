using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _8Puzzle
{
    public class Pathfinding
    {

        bool calculate = false;

        Calculate first;

        public string Solve(Panel curentStateOld)
        {
            first = new Calculate();
            first.curentState = new PuzzleState();
            first.AddCurentState(curentStateOld);
            first.endState = new PuzzleState();

            calculate = first.CreateEnd();

            while (calculate)
            {          
                calculate = first.CalculateSteps();
            }
   
            return first.ReturnSolve();
        }
        
  
    }

    class Calculate
    {
        List<MyPuzzle> Open = new List<MyPuzzle>();
        Point[][] map = 
             {   new Point[] { new Point(25, 25), new Point(125, 25), new Point(225,25)},
                new Point[] {new Point(25,125), new Point(125,125), new Point(225,125)},
                new Point [] {new Point(25,225), new Point (125,225), new Point(225,225)}
              };
        List<PuzzleState> allState = new List<PuzzleState>();
        List<PuzzleState> closeState = new List<PuzzleState>();
        public String nextStep = string.Empty;
        public PuzzleState curentState, endState;
        public MyPuzzle curentPuzzle = new MyPuzzle();
        public string name = "button";
        private int numberStep = 0;
        bool calculate = false;
        int steps = 0;
        bool first = true;

        public bool CreateEnd()
        {
            for (int i = 0; i < 9; i++)
            {
                MyPuzzle bufor = new MyPuzzle();

                bufor.curentBlock.Corner = Puzzle.AllCorner.LeftUP + i;
                bufor.curentBlock.Name = name + (i + 1).ToString();
                bufor.curentBlock.IntName = i + 1;

                endState.allButton.Add(bufor);
            }


            curentPuzzle = curentState.allButton[8];
            calculate = CheckStatus(curentState,endState);

            return calculate;
        }

        public void AddCurentState(Panel curentStateOld)
        {
            foreach (Control control in curentStateOld.Controls)
            {
                if (name != "Solve")
                {
                    if (control is Puzzle)
                    {
                        Puzzle button = control as Puzzle;
                        MyPuzzle newButton = new MyPuzzle();

                        #region SetButtonCorner

                        if (button.Corner == Puzzle.AllCorner.LeftDown)
                        {
                            newButton.curentBlock.Corner = Puzzle.AllCorner.LeftDown;
                        }

                        else if (button.Corner == Puzzle.AllCorner.LeftMiddle)
                        {
                            newButton.curentBlock.Corner = Puzzle.AllCorner.LeftMiddle;
                        }

                        else if (button.Corner == Puzzle.AllCorner.LeftUP)
                        {
                            newButton.curentBlock.Corner = Puzzle.AllCorner.LeftUP;
                        }

                        else if (button.Corner == Puzzle.AllCorner.MiddleDown)
                        {
                            newButton.curentBlock.Corner = Puzzle.AllCorner.MiddleDown;
                        }

                        else if (button.Corner == Puzzle.AllCorner.MiddleMiddle)
                        {
                            newButton.curentBlock.Corner = Puzzle.AllCorner.MiddleMiddle;
                        }

                        else if (button.Corner == Puzzle.AllCorner.MiddleUp)
                        {
                            newButton.curentBlock.Corner = Puzzle.AllCorner.MiddleUp;
                        }

                        else if (button.Corner == Puzzle.AllCorner.RightDown)
                        {
                            newButton.curentBlock.Corner = Puzzle.AllCorner.RightDown;
                        }

                        else if (button.Corner == Puzzle.AllCorner.RightMiddle)
                        {
                            newButton.curentBlock.Corner = Puzzle.AllCorner.RightMiddle;
                        }
                        
                        else if (button.Corner == Puzzle.AllCorner.RightUp)
                        {
                            newButton.curentBlock.Corner = Puzzle.AllCorner.RightUp;
                        }
                        #endregion

                        newButton.curentBlock.Name = button.Name;

                        if (button.Name == "button1")
                        {
                            newButton.curentBlock.IntName = 1;
                        }

                        else if (button.Name == "button2") 
                        {
                            newButton.curentBlock.IntName = 2;
                        }

                        else if (button.Name == "button3")
                        {
                            newButton.curentBlock.IntName = 3;
                        }

                        else if (button.Name == "button4") 
                        {
                            newButton.curentBlock.IntName = 4;
                        }

                        else if (button.Name == "button5")
                        {
                            newButton.curentBlock.IntName = 5;
                        }

                        else if (button.Name == "button6") 
                        {
                            newButton.curentBlock.IntName = 6;
                        }

                        else if (button.Name == "button7")
                        {
                            newButton.curentBlock.IntName = 7;
                        }

                        else if (button.Name == "button8") 
                        {
                            newButton.curentBlock.IntName = 8;
                        }

                        else if (button.Name == "button9") 
                        {
                            newButton.curentBlock.IntName = 9;
                        }

                        newButton.ManhatanChange = false;

                        curentState.allButton.Add(newButton);
                    }
                }
            }

            for (int i = 0; i < curentState.allButton.Count - 1; i++)
            {
                if (curentState.allButton[i].curentBlock.Name != "button" + (i + 1).ToString())
                {
                    foreach (MyPuzzle button in curentState.allButton)
                    {
                        if (button.curentBlock.Name == "button" + (i + 1).ToString())
                        {
                            curentState.allButton.Insert(i, button);
                            break;
                        }
                    }

                }
            }

            curentState.allButton.RemoveRange(9, curentState.allButton.Count - 9);
        }

        public bool CheckStatus(PuzzleState curentState, PuzzleState endState)
        {
            bool calculate = false;

            for (int i = 0; i < curentState.allButton.Count; i++)
            {
                if (curentState.allButton[i].curentBlock.Corner != endState.allButton[i].curentBlock.Corner)
                {
                    calculate = true;
                    break;
                }
                else
                {
                    calculate = false;
                }
            }


            return calculate;
        }

        public string ReturnSolve()
        {

            bool calculate = true;
            Puzzle puzzle = new Puzzle();
            PuzzleState parent = new PuzzleState();

            List<PuzzleState> finish = new List<PuzzleState>();

            finish.Add(closeState[closeState.Count - 1]);
          
            parent = closeState[closeState.Count - 1].parent;
            finish.Add(parent);

            while (calculate) 
            {
                parent = FindParent(parent);
                finish.Add(parent);
                calculate = CheckStatus(parent, closeState[0]);
            }

            //foreach (PuzzleState state in finish)
            //{
            //    foreach (MyPuzzle myPuzzle in state.allButton)
            //    {
            //        if (myPuzzle.curentBlock.Name == "button9")
            //        {
            //            numberStep++;
            //            nextStep += numberStep.ToString() + " - " + myPuzzle.curentBlock.Corner + "\r\n";
            //        }
            //    }
            //}
            for (int i = finish.Count - 1; i != -1; i--)
            {
                for (int j = 8; j != -1; j--)
                {
                    numberStep++;
                    nextStep += numberStep.ToString() + " - " + finish[i].allButton[j].curentBlock.Corner + "\r\n";
                    break;
                }
            }

            return nextStep;
        }

        private PuzzleState FindParent(PuzzleState parent)
        {
            bool value = true;
            PuzzleState stateValue = new PuzzleState();

            foreach (PuzzleState state in closeState)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (state.allButton[i].curentBlock.Corner == parent.allButton[i].curentBlock.Corner)
                    {
                        value = true;
                    }
                    else
                    {
                        value = false;
                        break;
                    }
                }

                if (value)
                {
                    stateValue = state;
                    break;
                }
            }

            return stateValue.parent;
        }

        public bool CalculateSteps()
        {
            calculate = CheckStatus(curentState, endState);

            if (calculate)
            {
                steps += 10;
                SearchNeighbours(curentPuzzle);
                curentPuzzle = SearchNext();
                MovePuzzle();
            }

            return calculate;           
        }

        private bool IsOnOpenList(MyPuzzle buttonNew)
        {
            foreach (MyPuzzle button in Open)
            {
                if (buttonNew == button)
                {
                    return true;
                }
            }

            return false;
        }

        private void ChoseBetterPath(MyPuzzle buttonNew)
        {
            foreach (MyPuzzle button in Open)
            {
                if (buttonNew == button)
                {
                    if (buttonNew.allMoves < button.allMoves)
                    {
                        button.allMoves = buttonNew.allMoves;
                    }
                }
            }

      
        }

        private void SearchNeighbours(MyPuzzle curentPuzzle)
        {
            if (curentPuzzle.curentBlock.Corner - 3 >= 0 && Convert.ToInt32(curentPuzzle.curentBlock.Corner) != 0
                && Convert.ToInt32(curentPuzzle.curentBlock.Corner) != 1 && Convert.ToInt32(curentPuzzle.curentBlock.Corner) != 2)
            {
                MyPuzzle neighboursUp = new MyPuzzle();
                neighboursUp.curentBlock.Corner = curentPuzzle.curentBlock.Corner - 3;
        
             for(int i=0; i< 9; i++)
             {
                //   foreach (MyPuzzle element in curentState.allButton)
                
                    if (curentState.allButton[i].curentBlock.Corner == neighboursUp.curentBlock.Corner)
                    {                        
                        neighboursUp.curentBlock = curentState.allButton[i].curentBlock;
                        //neighboursUp.allMoves = curentPuzzle.allMoves + 10; 
                        //neighboursUp.parent = curentPuzzle.curentBlock;
                      //  CalculateManhatan(neighboursUp);
                        
                        Open.Add(neighboursUp);
   
                        //neighboursUp.F = neighboursUp.allMoves + neighboursUp.Manhatan;                        
                    }
                }
            }

            if (Convert.ToInt32(curentPuzzle.curentBlock.Corner + 3) <= 8 && Convert.ToInt32(curentPuzzle.curentBlock.Corner) != 6
                && Convert.ToInt32(curentPuzzle.curentBlock.Corner) != 7 && Convert.ToInt32(curentPuzzle.curentBlock.Corner) != 8)
            {
                MyPuzzle neighboursDown = new MyPuzzle();
                neighboursDown.curentBlock.Corner = curentPuzzle.curentBlock.Corner + 3;

                foreach (MyPuzzle element in curentState.allButton)
                {
                    if (element.curentBlock.Corner == neighboursDown.curentBlock.Corner)
                    {
                        neighboursDown.curentBlock = element.curentBlock;
                        //neighboursDown.allMoves = curentPuzzle.allMoves + 10;
                        //neighboursDown.parent = curentPuzzle.curentBlock;
                      //  CalculateManhatan(neighboursDown);

                        Open.Add(neighboursDown);
                        
                        //neighboursDown.F = neighboursDown.allMoves + neighboursDown.Manhatan;                       
                    }
                }

            }

            if (curentPuzzle.curentBlock.Corner - 1 >= 0 && Convert.ToInt32(curentPuzzle.curentBlock.Corner) != 3
                && Convert.ToInt32(curentPuzzle.curentBlock.Corner) != 6 && Convert.ToInt32(curentPuzzle.curentBlock.Corner) != 0)
            {
                MyPuzzle neighboursLeft = new MyPuzzle();
                neighboursLeft.curentBlock.Corner = curentPuzzle.curentBlock.Corner - 1;

                foreach (MyPuzzle element in curentState.allButton)
                {
                    if (element.curentBlock.Corner == neighboursLeft.curentBlock.Corner)
                    {
                        neighboursLeft.curentBlock = element.curentBlock;
                        //neighboursLeft.allMoves = curentPuzzle.allMoves + 10;
                        //neighboursLeft.parent = curentPuzzle.curentBlock;
                       // CalculateManhatan(neighboursLeft);

                        Open.Add(neighboursLeft);

                        //neighboursLeft.F = neighboursLeft.allMoves + neighboursLeft.Manhatan;
                        
                    }
                }
            }

            if (Convert.ToInt32(curentPuzzle.curentBlock.Corner + 1) <= 8 && Convert.ToInt32(curentPuzzle.curentBlock.Corner) != 2
                && Convert.ToInt32(curentPuzzle.curentBlock.Corner) != 5)
            {
                MyPuzzle neighboursRight = new MyPuzzle();
                neighboursRight.curentBlock.Corner = curentPuzzle.curentBlock.Corner + 1;

                foreach (MyPuzzle element in curentState.allButton)
                {
                    if (element.curentBlock.Corner == neighboursRight.curentBlock.Corner)
                    {
                        neighboursRight.curentBlock = element.curentBlock;
                        //neighboursRight.allMoves = curentPuzzle.allMoves + 10;
                        //neighboursRight.parent = curentPuzzle.curentBlock;
                        
                        //CalculateManhatan(neighboursRight);

                        Open.Add(neighboursRight);

                        //neighboursRight.F = neighboursRight.allMoves + neighboursRight.Manhatan;
                        
                    }
                }
            }
        }

        private void CalculateManhatan(MyPuzzle curentPuzzle)
        {
            if (curentPuzzle.ManhatanChange)
            {
                for (int i = 0; i < endState.allButton.Count - 1; i++)
                {
                    float value = 0;

                    if (curentPuzzle.curentBlock.IntName == endState.allButton[i].curentBlock.IntName)
                    {
                        if (curentPuzzle.curentBlock.Location.X < endState.allButton[i].curentBlock.Location.X)
                        {
                            value = (endState.allButton[i].curentBlock.Location.X - curentPuzzle.curentBlock.Location.X);

                        }
                        else
                        {
                            value = (curentPuzzle.curentBlock.Location.X - endState.allButton[i].curentBlock.Location.X);
                        }

                        if (curentPuzzle.curentBlock.Location.Y < endState.allButton[i].curentBlock.Location.Y)
                        {
                            value += (endState.allButton[i].curentBlock.Location.Y - curentPuzzle.curentBlock.Location.Y);

                        }
                        else
                        {
                            value += (curentPuzzle.curentBlock.Location.Y - endState.allButton[i].curentBlock.Location.Y);
                        }

                        curentPuzzle.Manhatan = value / 10;
                        break;
                    }
                }
            }
        }

        private void CalculateLocation(PuzzleState state)
        {
            for(int i=0; i < 9; i++)
            {
         //   foreach (MyPuzzle myPuzzle in state.allButton)
            
                #region Up
                ///////////////////////////////Up//////////////////////////////////
                if (state.allButton[i].curentBlock.Corner == Puzzle.AllCorner.LeftUP)
                {
                    state.allButton[i].curentBlock.Location = map[0][0];
                    break;
                }

                else if (state.allButton[i].curentBlock.Corner == Puzzle.AllCorner.MiddleUp)
                {
                    state.allButton[i].curentBlock.Location = map[0][1];
                    break;
                }

                else if (state.allButton[i].curentBlock.Corner == Puzzle.AllCorner.RightUp)
                {
                    state.allButton[i].curentBlock.Location = map[0][2];
                    break;
                }

                #endregion

                #region Middle
                ////////////////////////////Middle/////////////////////
                else if (state.allButton[i].curentBlock.Corner == Puzzle.AllCorner.LeftMiddle)
                {
                    state.allButton[i].curentBlock.Location = map[1][0];
                    break;
                }

                else if (state.allButton[i].curentBlock.Corner == Puzzle.AllCorner.MiddleMiddle)
                {
                    state.allButton[i].curentBlock.Location = map[1][1];
                    break;
                }

                else if (state.allButton[i].curentBlock.Corner == Puzzle.AllCorner.RightMiddle)
                {
                    state.allButton[i].curentBlock.Location = map[1][2];
                    break;
                }

                #endregion

                #region Down
                ////////////////// Down ///////////////////////////////

                else if (state.allButton[i].curentBlock.Corner == Puzzle.AllCorner.LeftDown)
                {
                    state.allButton[i].curentBlock.Location = map[2][0];
                    break;
                }

                else if (state.allButton[i].curentBlock.Corner == Puzzle.AllCorner.MiddleDown)
                {
                    state.allButton[i].curentBlock.Location = map[2][1];
                    break;
                }

                else if (state.allButton[i].curentBlock.Corner == Puzzle.AllCorner.RightDown)
                {
                    state.allButton[i].curentBlock.Location = map[2][2];
                    break;
                }

                #endregion

            }
        }

        private PuzzleState CopyState(PuzzleState myState)
        {
            PuzzleState buforState = new PuzzleState();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (myState.allButton[i].curentBlock.Corner == Puzzle.AllCorner.LeftUP + j)
                    {
                        MyPuzzle bufor = new MyPuzzle();
                        bufor.curentBlock.Name = myState.allButton[i].curentBlock.Name;
                        bufor.curentBlock.IntName = myState.allButton[i].curentBlock.IntName;
                        bufor.curentBlock.Corner = Puzzle.AllCorner.LeftUP + j;
                        buforState.allButton.Add(bufor);
                    }
                }
            }


            return buforState;
        }

        private void CalculateManhatanState(PuzzleState buforState)
        {
            CalculateLocation(buforState);
            CalculateLocation(endState);

            foreach (MyPuzzle state in buforState.allButton)
            {
                CalculateManhatan(state);
            }

            buforState.CalculateAllMoves();
        }

        private MyPuzzle SearchNext() 
        {
            PuzzleState newState = new PuzzleState();
            int index = 0;

            for(int i=0; i< Open.Count ;i++)
            {
                PuzzleState old = new PuzzleState();
                old = CopyState(curentState);
                MyPuzzle bufor = new MyPuzzle();
                bool canAdd = true;
                
                if (first)
                {
                    closeState.Add(old);
                    first = false;
                }
                
                for (int j = 0; j < 9; j++)
                {
                    if (Open[i].curentBlock.Corner == Puzzle.AllCorner.LeftUP + j)
                    {
                        bufor.curentBlock.Corner = Puzzle.AllCorner.LeftUP + j;
                        bufor.curentBlock.Name = Open[i].curentBlock.Name; // zmienić w przyszłośći na nameInt
                        break;
                    }
                }

                curentPuzzle = bufor;
                MovePuzzle();
                newState = CopyState(curentState);
                newState.numberOfMove += steps;


                //if (allState.Count != 0)
                //{
                //    foreach (PuzzleState myState in allState)
                //    {
                //        if (myState == newState)
                //        {
                //            canAdd = false;
                //        }
                //    }
                //}

                if (canAdd)
                {
                    if (!IsOnAllState(newState))
                    {
                        newState.parent = old;
                        allState.Add(newState);
                    }
                }

                curentState = CopyState(old);

            }

            foreach (PuzzleState state in allState)
            {
                CalculateManhatanState(state);
                state.f = state.numberOfMove + state.allManhatan;
            }


            for (int i = 0; i < allState.Count; i++)
            {
                if (allState[index].f > allState[i].f)
                {
                    index = i;
                }
            }

            curentState = CopyState(allState[index]);

            closeState.Add(allState[index]);
            allState.Remove(allState[index]);
            Open.Clear();

            return closeState[closeState.Count-1].allButton[8];
        }

        private bool CheckBoolState(PuzzleState myState, List<PuzzleState> ListState)
        {
            bool value = false;
            bool next = false;

            foreach (PuzzleState state in ListState)
            {

                if (state.allButton[8].curentBlock.Corner != myState.allButton[8].curentBlock.Corner)
                {
                    value = false;
                    next = false;
                }
                else
                {
                    foreach (MyPuzzle puzzle in state.allButton)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (myState.allButton[i].curentBlock.IntName == puzzle.curentBlock.IntName)
                            {
                                if (myState.allButton[i].curentBlock.Corner != puzzle.curentBlock.Corner)
                                {
                                    value = false;
                                    next = false;
                                    break;
                                }
                                else
                                {
                                    value = true;
                                    next = false;
                                }
                            }
                            else
                            {
                                next = true;
                            }
                        }

                        if (!next)
                        {
                            if (value)
                            {
                                return true;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

            }

            return false;
        }

        public bool IsOnAllState(PuzzleState myState)
        {
            PuzzleState value = new PuzzleState();
            bool valueCloseState = true;
            bool valueAllState = true;

            if (allState.Count == 0)
            {
                return false;
            }

            valueAllState = CheckBoolState(myState, allState);

            if (!valueAllState)
            {

                valueCloseState = CheckBoolState(myState, closeState);
            }

            if (valueAllState || valueCloseState)
            {
                if (myState.f > value.f)
                {
                    myState.f = value.f;
                    myState.parent = value.parent;
                }
                return true;
            }

            return false;
        }

        private void MovePuzzle()
        {
            foreach (MyPuzzle puzzle in curentState.allButton)
            {
                puzzle.ManhatanChange = false;

                if (curentPuzzle.curentBlock.Name == puzzle.curentBlock.Name)
                {
                    Puzzle bufor = new Puzzle();

                    for (int i = 0; i < 9; i++)
                    {
                        if (puzzle.curentBlock.Corner == Puzzle.AllCorner.LeftUP + i)
                        {
                            bufor.Corner = Puzzle.AllCorner.LeftUP + i;
                            break;
                        }
                    }

                    for (int i = 0; i < 9; i++)
                    {
                        if (curentState.allButton[8].curentBlock.Corner == Puzzle.AllCorner.LeftUP + i)
                        {
                            puzzle.curentBlock.Corner = Puzzle.AllCorner.LeftUP + i;
                            puzzle.ManhatanChange = true;
                            break;
                        }
                    }

                    curentState.allButton[8].curentBlock.Corner = bufor.Corner;
                    curentState.allButton[8].ManhatanChange = true;

                    break;
                }
            }
        }

    }

    public class MyPuzzle
    {
        public Puzzle curentBlock = new Puzzle();
        public float allMoves {get;set;}
        public float Manhatan;
        public float F;
        public bool ManhatanChange;
        public Puzzle parent = new Puzzle();
    }

    public class PuzzleState
    {
        public List<MyPuzzle> allButton;
        public float allManhatan;
        public float numberOfMove;
        public float f;
        public PuzzleState parent;

       public PuzzleState()
       {
           allButton = new List<MyPuzzle>();
       }

       public void CalculateAllMoves()
       {
           for (int i = 0; i < allButton.Count; i++)
           {
               allManhatan += allButton[i].Manhatan;
           }

           allManhatan = allManhatan / 2;
       }
    }
}
