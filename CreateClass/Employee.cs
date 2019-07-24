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

        public Employee(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("null");
            }
            this.Salary = (int)info.GetValue("salary", typeof(int));
            this.Profession = (string)info.GetValue("profession", typeof(string));
            this.Room = (Room)info.GetValue("room", typeof(Room));
        }

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

        override public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new System.ArgumentNullException("null");
            }
            info.AddValue("name", this.Name);
            info.AddValue("gender", this.Gender);
            info.AddValue("birthdate", this.BirthDate);
            info.AddValue("profession", this.Profession);
            info.AddValue("salary", this.Salary);
            info.AddValue("room", this.Room);
        }
    }
}
