using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectiveAppV01
{
   public abstract class Person
    {
        //Data Member
       public string FirstName { get; set; }
       public string SurName { get; set; }
       public string KNum { get; set; }
       public string PhoneNum { get; set; }

        //Constructors
        public Person()
        {
            this.FirstName = "";
            this.SurName = "";
            this.KNum = "";
            this.PhoneNum = "";
        }

        public Person(string FirstName, string SurName, string KNum, string PhoneNum)
        {
            this.FirstName = FirstName;
            this.SurName = SurName;
            this.KNum = KNum;
            this.PhoneNum = PhoneNum;
        }
        
        public Person (string KNum)
        {
            this.KNum = KNum;
        }


        //Member Functions
        public virtual void Update (string NewFirst, string NewSur, string NewKn, string newMobile)
        {
            this.FirstName = NewFirst;
            this.SurName = NewSur;
            this.KNum = NewKn;
            this.PhoneNum = newMobile;
        }

        public abstract void Print(); // inherited in the Student Class
    }
}
