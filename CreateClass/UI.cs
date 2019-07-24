using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CreateClass
{
    class UI
    {
        public Person NewPerson()
        {
            Console.WriteLine("Give a new name!");
            String name = Console.ReadLine();
            DateTime birthday = DateTime.Parse(GetDateInput("when is " + name + "s' birthday?"));
            Console.WriteLine("give the persons profession!");
            String profession = Console.ReadLine();
            Console.WriteLine("give the persons gender(male/female)!");
            String gender = CreateGender();
            int salary = GetIntegerInput("please give " + name + " a salary!");
            int roomNumber = GetIntegerInput("please tell which room he/she is in!");

            return new Employee(name, birthday, gender, salary, profession, new Room(roomNumber));
        }

        public String GetAnswer()
        {
            while (true)
            {
                String answer = Console.ReadLine().ToLower();
                if (answer == "new" || answer == "load")
                {
                    return answer;
                }
                Console.WriteLine("Please type 'new' or 'load'!");
            }
        }

        public String CreateGender()
        {
            while (true)
            {
                String genderString = Console.ReadLine().ToUpper();
                if (genderString == "MALE" || genderString == "FEMALE")
                {
                    return genderString;
                }
                else
                {
                    Console.WriteLine("Invalid gender: " + genderString + "\nPlease give a valid gender!(male/female)");
                    continue;
                }
            }
        }

        public int GetIntegerInput(string message)
        {
            while (true)
            {
                Console.WriteLine(message + "!\n(should be a valid number!)");
                string salaryInput = Console.ReadLine();
                try
                {
                    int salaryInt = Int32.Parse(salaryInput);
                    return salaryInt;
                }
                catch (FormatException)
                {
                    Console.WriteLine(salaryInput + " is not a number!");
                }
            }
        }

        public string GetDateInput(string message)
        {
            while (true)
            {
                Console.WriteLine(message + "!\n(format:YYYY-MM-DD)");
                string BirthdayInput = Console.ReadLine();
                if (Regex.IsMatch(BirthdayInput, @"^((19\d{2})|(20\d{2}))-(((02)-(0[1-9]|[1-2][0-9]))|(((0(1|[3-9]))|(1[0-2]))-(0[1-9]|[1-2][0-9]|30))|((01|03|05|07|08|10|12)-(31)))$"))
                {
                    return BirthdayInput;
                }
                Console.WriteLine("Invalid Date format!");
            }
        }

        public string GetPathInput(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string PathInput = Console.ReadLine();
                if (Regex.IsMatch(PathInput, @"^(?:(?:(~?\/)(.*))|(?:((?:\\\\\?\\)?[a-zA-Z]+\:)(?:[\\\/](.*))))?$"))
                {
                    return PathInput;
                }
                Console.WriteLine("Not a valid path form!");
            }
        }

        public void SerializePerson(Person toSerialize)
        {
            String path = GetPathInput("Please give a file name and a valid path!");
            toSerialize.Serialize(path);
        }

        public Person LoadPerson()
        {
            string inputPath = GetPathInput("Please give a file name and a valid path to load from!");
            return Person.Deserialize(inputPath);
        }
    }
}
    

