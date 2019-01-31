using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Person
    {
        static int countId = 0;// mojno sozdat skolko ygodno chelovek
        public int Id { get; private set; }

        public string FirstName { get; set; } // propety
        public string lastName; // field
        public string FullName { get { return FirstName + " " + lastName; } }//pokazivaet obasrazy  ++

        int age; // toje field, eto nazivaetsya pole
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Age can't be Zero or lower");
                }
                else
                {
                    age = value;//sparar znachenie
                }
            }
        }
        public Person() { } // kostryktor samma namn som klass, zero kostryktor
        public Person(string firstName, string lastName) // vse chto v skobkah (string + imya) eto variable, 
        {
            Id = ++countId;//tak pribovlyaet znacheni
            FirstName = firstName;
            this.lastName = lastName;// this.lastName eto to chto iz propety public string lastName; 

        }
        public Person(string firstname, string lastname, int age) : this(firstname, lastname)//eto : soedinyaet metod this(string int)
        {
            this.age = age; // vse chto iz pole(field) nujno zapisat kostryktor i nado this.age + nazvanie iz kostryktora
            if (true)
            {

            }
            else if (true)
            {

            }
        }
        public void SayHello()
        {
            // Console.Write("My name is " + FirstName + " " + lastName);
            //Console.Write("My name is " + FullName);// eto ydobnee++ no daet oba srazy
            if (age > 0)//eto pervij sposob
            {
                Console.Write(" Im " + age + " years old");
            }
            Console.WriteLine();
            //Console.WriteLine(age);// i ne zabit zapisat syda vse cnto tu hochesh, pole i konstrykot
        }
        override public string ToString()
        {
            return Id + ": " + FullName;
        }

    }
}