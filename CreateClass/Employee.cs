using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CreateClass
{
    [Serializable]
    public class Employee : Person
    {
        public int Salary { get; private set; }
        public string Profession { get; private set; }
        public Room Room { get; private set; }

        public Employee(String name, DateTime birtrhDate, String gender, int salary, string profession, Room room) : base(name, birtrhDate, gender)
        {
            this.Salary = salary;
            this.Profession = profession;
            this.Room = room;
        }
        
        override public string ToString()
        {
            return base.ToString() + "\nPROFESSION:" + Profession + "\nSALARY: " + Salary + "\nCurrently in Room #" + Room.Number;
        }
    }
}
