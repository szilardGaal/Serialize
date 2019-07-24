using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CreateClass
{
    [Serializable]
    public class Person
    {
        public String Name { get; protected set; }
        public DateTime BirthDate { get; }
        public Gender Gender { get; }
        public int Age { get { return (DateTime.Now - BirthDate).Days / 365; } }

        public Person() { }

        public Person(String name, DateTime birthDate, String gender)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            Gender genderEnum;
            Enum.TryParse<Gender>(gender, out genderEnum);
            this.Gender = genderEnum;
        }

        public void Serialize(String output)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(output, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, this);
                stream.Close();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access to {0} is denied. Maybe the file is hidden.", output);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Path {0} does not exist", output);
            }
        }

        public static Person Deserialize(String input)
        {
            Person newPerson = new Person();
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(input, FileMode.Open, FileAccess.Read, FileShare.Read);
                newPerson = (Person)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access to {0} is denied. Maybe the file is hidden.", input);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
            return newPerson;
        }


        public override string ToString()
        {
            string genderString = Gender.ToString();
            return "\nNAME:" + Name + "\nAGE: " + Age + "\nBIRTH:" + BirthDate + "\nGENDER: "+ genderString;
        }
    }

    public enum Gender
    {
        MALE,
        FEMALE
    }
}
