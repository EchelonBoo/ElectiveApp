using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectiveAppV01
{
    class Program
    {


        static void Main(string[] args)
        {
            List<Student> students = new List<Student>(); //This stores a list of Students and their data
            List<Electives> electives = new List<Electives>(); //This stores a list of Electives and their data

            int option = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("********Elective Application*******");
                Console.WriteLine();
                Console.WriteLine("1.   Add Students");
                Console.WriteLine("2.   Display Students");
                Console.WriteLine("3.   Display KNumbers");
                Console.WriteLine("4.   Change Elective Details");
                Console.WriteLine("5.   Add an Elective");
                Console.WriteLine("6.   Management Information");
                Console.WriteLine("7.   Exit");

                Console.WriteLine("Please choose an option from the menu:");
                option = Convert.ToInt32(Console.ReadLine());

                Console.Write("You Chose Option: ");
                Console.WriteLine(option);

                switch (option)
                {
                    case 1:
                        //Working
                        AddData(students, electives);

                        break;
                    case 2:
                        //Working
                        DisplayStudents(students);

                        break;
                    case 3:
                        // Display a list of Knums by elective
                        DisplayKnum(students, electives);
                        break;
                    case 4:
                        // enter a knum and change elective details
                        SearchKnum(students, electives);
                        //countStudent(students, electives);
                        break;
                    case 5:
                        #region case 5
                        // add an elective to the system

                        Console.WriteLine("New Elective Code:");
                        string ElectiveCode = Convert.ToString(Console.ReadLine());

                        Console.WriteLine("New Elective Name:");
                        string ElectiveName = Convert.ToString(Console.ReadLine());

                        Console.WriteLine("New Elective Maximum:");
                        int ElectiveMax = Convert.ToInt32((Console.ReadLine()));

                        Console.WriteLine("New Elective Minimum:");
                        int ElectiveMin = Convert.ToInt32((Console.ReadLine()));

                        Electives newElective = new Electives(ElectiveCode, ElectiveName, ElectiveMax, ElectiveMin);
                        electives.Add(newElective);
                        #endregion
                         
                        break;
                    case 6:
                        //Calls the Submenu 
                        Submenu(electives,students);
                        break;
                    default:
                        break;

                }
            } while (option != 7);

        }

        //This fucntion adds all the  hard coded data to the system and assigns the electives to each student
        public static void AddData(List<Student> students, List<Electives> electives)
        {
            electives.Add(new Electives("GPH","Graphics", 1, 0));
            electives.Add(new Electives("AED", "Advanced Enterprise Development", 10, 9));
            electives.Add(new Electives("MAD", "Mobile Application Development", 8, 3));
            electives.Add(new Electives("HCM", "Human Computer Interaction", 9, 3));

            students.Add(new Student("Sarah", "Hier", "K001", "0851323404", 2017, "Soft Dev", new List<Electives>() {electives.ElementAt(0),electives.ElementAt(3)}));
            students.Add(new Student("John", "Snith", "K002", "0851323404", 2016, "Soft Dev", new List<Electives>() {electives.ElementAt(0)}));
            students.Add(new Student("Dylan", "Cummins", "K005", "0851323404", 2018, "Businness", new List<Electives>() {electives.ElementAt(0),electives.ElementAt(3)}));
            students.Add(new Student("Callum", "Mudge", "K009", "0851323404", 2011, "Social Care", new List<Electives>() {electives.ElementAt(2),electives.ElementAt(0)}));
            students.Add(new Student("Kathlyn", "Coleman", "K003", "0851323404", 2015, "Tourism", new List<Electives>() {electives.ElementAt(2),electives.ElementAt(1)}));
            students.Add(new Student("Mark", "Dee", "K007", "0851323404", 2014, "Social Care", new List<Electives>() {electives.ElementAt(2),electives.ElementAt(0)}));
            students.Add(new Student("Bethany", "Han", "K004", "0851323404", 2013, "Soft Dev", new List<Electives>() {electives.ElementAt(3)}));
            students.Add(new Student("Andy", "Yu", "K006", "0851323404", 2018, "Tourism", new List<Electives>() {electives.ElementAt(2)}));
            students.Add(new Student("Mike", "Han", "K008", "0851323404", 2017, "Social Care", new List<Electives>() {electives.ElementAt(2),electives.ElementAt(1)}));
            students.Add(new Student("Jackie", "Cullen", "K0010", "0851323404", 2017, "Soft Dev", new List<Electives>() {electives.ElementAt(1)}));


            Console.WriteLine();
            Console.WriteLine("Students have been added to the system :)");
            Console.WriteLine();

        }

        //This function displays each student and their details
        public static void DisplayStudents(List<Student> students)
        {
            foreach (Student s in students)
            {
                s.Print();
            }
            Console.WriteLine();
        }

        //This function displays a list of Knumbers per elective
        public static void DisplayKnum(List<Student> students, List<Electives> electives)
        {
            foreach (var elect in electives)
            {
                Console.Write(elect.Code + "  "); //ouputs the elective code

                foreach (var stud in students)
                {
                    foreach (var StudElect in stud.electives)
                    {
                        if (StudElect.Code == elect.Code)
                        {
                            Console.Write("{0}, ", stud.KNum);// outputs the Knumber per elective code
                            
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        //This allows you to search by Knumber and update their elective choices
        public static void SearchKnum(List<Student> students, List<Electives> electives)
        {
            Console.WriteLine("Please enter a K Number: ");
            string Knumber = Console.ReadLine();

            Student s = new Student();
                foreach(var stud in students) // searches for the entered Knum
                {
                       if(stud.KNum == Knumber)
                       {
                             s = stud;
                       }
                }

                foreach(Electives e in s.electives) // gets the elective code for the Knumber
                {
                         Console.WriteLine(e.Code);
                }

            Console.WriteLine("Please choose an elective to change, 1 or 2:"); // gives you the option choose which elective to change elect1 or elect2
            int option = Convert.ToInt32(Console.ReadLine());
            option--;

            Console.WriteLine("Please enter the new elective");
            int x = 1;

                foreach(Electives e in electives) // displays each elective and a corresponding number
                {
                     Console.Write("{0} {1} ", x, e.Code);
                     x++;
                }

            int option2 = Convert.ToInt32(Console.ReadLine());
            option2--;

            s.electives[option] = electives[option2]; // changes the original elective to the new one

                
        }

        //Counts the number of students per elective
        public static int CountStudent(Electives e, List<Student> students)
        {

            int amount = 0;
            foreach( Student s in students)
            {
                if (s.electives.Contains(e))
                {
                    amount++;
                }
            }
            return amount;
        }

        //Ouputs the electives in order of popularity and the number of students who chose them
        public static void MostPop(List<Electives> electives,List<Student> students )
        {
            foreach (Electives e in electives)
            {
                e.studs = CountStudent(e, students); //Calls the CountStudents function and adds up a number of students per elective
            }

            var mostPop = electives.OrderByDescending(o => o.studs); //Orders the electives by the one with the highest number of students first

            foreach (var el in mostPop) // outputs the number id students and the elective
            {
                Console.WriteLine();
                Console.WriteLine("Number of Students:{0}", el.studs);
                Console.WriteLine("Elective:{0}",el.Code);
                Console.WriteLine();
            }
        }

        //Allows user to enter in 2 electives and the K numbers who chose BOTH of them are output
        public static void BothElec(List<Electives> electives, List<Student> students)
        {
            int x = 1;

                foreach(Electives el in electives) // ouputs each code and a corresponding number to choose from
                {
                    Console.Write("{0} {1} || ", x, el.Code);
                    x++;
                }
            Console.WriteLine();

            Console.WriteLine("Select 1st elective"); 
            int option1 = Convert.ToInt32(Console.ReadLine());
            option1--;

            Console.WriteLine("Select 2nd elective");
            int option2 = Convert.ToInt32(Console.ReadLine());
            option2--;

            foreach(Student stu in students)
            {
                if(stu.electives.Contains(electives[option1]) && stu.electives.Contains(electives[option2]))//They have to have chosen both entered electives
                {
                    Console.WriteLine(stu.KNum);
                }
            }

        }

        //Allows user to enter in 2 electives and the K numbers who chose EITHER of them are output
        public static void EitherElec(List<Electives> electives, List<Student> students)
        {
            int x = 1;

            foreach (Electives el in electives)// ouputs each code and a corresponding number to choose from
            {
                Console.Write("{0} {1} || ", x, el.Code);
                x++;
            }
            Console.WriteLine();
            Console.WriteLine("Select 1st elective");
            int option1 = Convert.ToInt32(Console.ReadLine());
            option1--;

            Console.WriteLine("Select 2nd elective");
            int option2 = Convert.ToInt32(Console.ReadLine());
            option2--;

            foreach (Student stu in students)
            {
                if (stu.electives.Contains(electives[option1]) || stu.electives.Contains(electives[option2])) // They only had to have chosen either elective entered
                {
                    Console.WriteLine(stu.KNum);
                }
            }
        }

        //Outputs the electives that fail to meet the minimm number of enrolled students and the students who chose them
        public static void FailMin(List<Electives> electives, List<Student> students)
        {
            foreach (Electives el in electives)
            {
                el.studs = CountStudent(el, students); // calls the countStudents functions which adds up all the students for each elective
            }

            foreach (Electives el in electives)
            {
                if (el.studs < el.Min) // is the number of students per elective less than the required minimum
                {
                    Console.WriteLine(el.Code); // if it is output out ouput the elective
                    foreach (Student stu in students)
                    {
                        if (stu.electives.Contains(el))
                        {
                            Console.WriteLine(stu.KNum); // then output the students who chose that elective
                        }
                    }
                }
               // else
               // {
               //     Console.WriteLine("All electives meet the minimum requirements :)"); //This is shown if all the electives have the required number of students enrolled and breaks out of the loop
               //     break;
               // }
            }


        }

        //This function outputs the electives that have too many people enrolled  and the students who chose them
        public static void ExceededMax(List<Electives> electives, List<Student> students)
        {
            foreach (Electives el in electives)
            {
                el.studs = CountStudent(el, students); // calls the countStudents functions which adds up all the students for each elective
            }

            foreach(Electives el in electives) // is the number of students per elective greater than the maximum number of students allowed
            {
                if (el.studs > el.Max)
                {
                    Console.WriteLine(el.Code);// if it is output out ouput the elective
                    foreach (Student stu in students)
                    {
                        if (stu.electives.Contains(el))
                        {
                            Console.WriteLine(stu.KNum); // then output the students who chose that elective
                        }
                    }
                }
                else Console.WriteLine("No electives exceed the max num of students :)");//This is shown if all the electives have the required number of students enrolled and breaks out of the loop
                break;
            }
        }

        //This function ouputs the most popular elective combination
        public static void MostPopCombo(List<Electives> electives, List<Student> students)
        {
            Dictionary<string, int> combo = new Dictionary<string, int>(); // creates a dictionary to store the combinations

            foreach(Electives e in electives)
            {
                foreach(Electives el in electives) // both foreach loops run through every possible combination
                {
                    string combon = e.Code + " " + el.Code; // Creates the key for the dictionary

                    foreach(Student stu in students) // checks each student
                    {
                        if( e!= el && stu.electives.Contains(e) && stu.electives.Contains(el)) // if both of the electives are taken by the student and the electives aren't equal to eachother
                        {
                            if (combo.ContainsKey(combon)) // checks to see if the key is in the dictionary
                            {
                                combo[combon]++; //if it is in the dictionary increase the value by 1
                            }
                            else
                                combo.Add(combon, 1);  // if not add it to the dictionary and set the value to 1
                        }
                    }      
                }                
            }
            combo.OrderBy(o => o.Value); //orders the dictionary by the value
            Console.WriteLine(combo.Last());//outputs the last value in the dictionary i.e. the most popular
        }

        //This is the submenu function for option 6
        public static void Submenu(List<Electives> electives, List<Student> students)
        {
            Console.WriteLine();
            Console.WriteLine("\t\t*****Option 6 Submenu*****");
            Console.WriteLine("\t\t1.  Electives by Popularity");
            Console.WriteLine("\t\t2.  Knumbers by Elective (both)");
            Console.WriteLine("\t\t3.  Knumbers by Elective (either");
            Console.WriteLine("\t\t4.  Fail to Meet Minimum");
            Console.WriteLine("\t\t5.  Exceed Maximum ");
            Console.WriteLine("\t\t6.  Two Most Popular Electives");
            Console.WriteLine();

            int option2 = 0;
            option2 = Convert.ToInt16(Console.ReadLine());

            Console.Write("You Chose Option: ");
            Console.WriteLine(option2);

            switch (option2)
            {
                case 1:
                    //Display electives by popularity + num of students
                   MostPop(electives,students);
                    break;
                case 2:
                    //displays students that have chosen a combination of entered electives
                    BothElec(electives, students);
                    break;
                case 3:
                    //displays students that have chosen either of the entered electives
                    EitherElec(electives,students);
                    break;
                case 4:
                    //display electives that fail to meet minimum students
                    FailMin(electives, students);
                    break;
                case 5:
                    //display electives that exceed max students
                    ExceededMax(electives, students);
                    break;
                case 6:
                    // display teo most popular elective combinations
                    MostPopCombo(electives, students);
                    break;
                default:
                    break;
            }
        }

        #region TestFunctions
        //Testing - adds 4 electives
        public static void AddElectives(List<Electives> electives)
        {
            electives.Add(new Electives("MAD", "Mobile Application Developent", 10, 3));
            electives.Add(new Electives("AED", "Advanced Enterprise Development", 5, 2));
            electives.Add(new Electives("GPH", "Graphics", 8, 5));
            electives.Add(new Electives("HCM", "Human Computer Interaction", 9, 1));
        }

        //Testing - Displays electives
        public static void DisplayElectives(List<Electives> electives)
        {
            foreach (Electives e in electives)
            {
                e.DisplayDetails();
            }
            Console.WriteLine();
        }
        #endregion
    }
}
