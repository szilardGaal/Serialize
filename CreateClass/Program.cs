using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateClass
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            Console.WriteLine("Create new person or load the existing one?\n(please type 'new' or 'load')");
            string Answer = ui.GetAnswer();

            Person person = new Person();
            if (Answer == "new")
            {
                person = ui.NewPerson();
            }
            if (Answer == "load")
            {
                person = ui.LoadPerson();
            }

            Console.WriteLine(person.ToString() + "\n===========================\nPress 'ENTER' to begin serialization!");
            Console.ReadLine();
            ui.SerializePerson(person);

        }
    }
}
