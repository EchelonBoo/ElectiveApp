
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace ElectiveAppV01
    {
        class Electives
        {
            //Data Members
            public string Code { get; set; }
            public string Name { get; set; }
            public int Max { get; set; }
            public int Min { get; set; }
            public int studs { get; set; } // This is to help keep track of the total number of students in the CountStudents function

        //Constructors
        public Electives() : base()
            {
                this.Name = "";
                this.Code = "";
                this.Max = 0;
                this.Min = 0;
            }
            public Electives( string code, string name, int max, int min)
            {
                this.Code = code;
                this.Name = name;  
                this.Max = max;
                this.Min = min;
            }

            public Electives(string name)
            {
                this.Name = name;
            }
        
            //Member Functions
            //This is just for testing to check if there are electives
            public void DisplayDetails()
            {
                Console.WriteLine("\t{0}  {1,10} {2,10} {3,10} ", Code, Name, Max, Min);
            }
        }
    }

