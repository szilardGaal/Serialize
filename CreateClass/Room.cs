using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CreateClass
{
    [Serializable]
    public class Room
    {
        private int _Number;
        public int Number { protected set { _Number = value; } get { return _Number; } }

        public Room(int number)
        {
            this.Number = number;
        }
    }
}
