using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectiveAppV01
{
    class Student :Person
    {
        //Data Members
        public int YearOfReg { get; set;}
        public string Course { get; set; }
        public List<Electives> electives { get; set; } // This allows you to assign electives from the elective list to a student

        //Constructors
        public Student() : base()
        {
            this.YearOfReg = 0;
            this.Course = "";
            electives = new List<Electives>();
        }
        public Student(string KNum) : base(KNum)
        {
            this.YearOfReg = YearOfReg;
            this.Course = "";
            electives= new List<Electives>();
        }

        public Student(string FirstName, string SurName, string KNum, string PhoneNum, int YearOfReg, string Course, List<Electives> electives) : base(FirstName, SurName, KNum, PhoneNum)
        {
            this.YearOfReg = YearOfReg;
            this.Course = Course;
            this.electives = electives;
        }

        //Member Function
        //Inherited from the parent class Person
        public override void Print()
        {
            Console.WriteLine("\n\tFirstname:\t" + this.FirstName);
            Console.WriteLine("\tSurname:\t" + this.SurName);
            Console.WriteLine("\tKNumber:\t" + this.KNum);
            Console.WriteLine("\tContact Number:\t" + PhoneNum);
            Console.WriteLine("\tRegistration Year:\t" + YearOfReg);
            Console.WriteLine("\tCourse:\t" + this.Course);
            for (int i = 0; i < this.electives.Count; i++)
            {
                Console.WriteLine("\tElective: \t" + this.electives[i].Code);
               
            }            
        }
    }
}
