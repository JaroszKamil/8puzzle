using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _8Puzzle
{
    public class Puzzle : Button 
    {
        public enum AllCorner
        {
            LeftUP,
            MiddleUp,
            RightUp,
            LeftMiddle,
            MiddleMiddle,
            RightMiddle,
            LeftDown,
            MiddleDown,
            RightDown
        }

        public AllCorner Corner
        {
            get;
            set;
        }

        public int IntName
        {
            get;
            set;
        }
    }
}
