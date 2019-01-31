using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        static InfoGenerator infoGen = new InfoGenerator(DateTime.Now.Millisecond);//only one
        
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();// klass pisat v List<syda> i dat novoe imya listy



            //people.Add(new Person("Alhazur", "Ispajhanov", 28));// imya lista + add chtobu dobavit chto ygodno .Add(new Person(string, string, int));
            //people.Add(new Person("Lechi", "Ispajhanov", 27));// iz public Person(string firstName, string lastName, int age) eto variable
            //people.Add(new Person("Adam", "Ispajhanov", 18));
            //people.Add(CreatePerson());//tak soedinyaet konstryktor k Listy i zpyskaet ee

            //people.ForEach(x => x.SayHello());//eto do knopki pokajet cho est v liste

            //// est dva sposoba up eto mnogo za ras
            ////down pisat otdelno kajdogo

            //Person alhazur = new Person();//esli pisat tak to posle klass Eto Person nado dat to imya chto bydet na ekrane
            //alhazur.FirstName = "Alhazur";// imya, familiya, vozrost i.t
            //alhazur.lastName = "Ispajhanov";
            //alhazur.SayHello();//i iz public void SayHello() nyjno pisat dlya kajdomy iz predmetov ili cheloveka 

            //Person lechi = new Person();
            //lechi.FirstName = "Lechi";
            //lechi.lastName = "Ispajhanov";
            ////lechi.age = 99// går ej på grund av private
            //lechi.SayHello();

            bool stay = true;
            while (stay)
            {
                Console.WriteLine("--- People menu ---\n"
                    + "1: Add Person to list\n"
                    + "2: Show list\n"
                    + "3 Add Random Person tolist\n"
                    + "4 Remove Person from list\n"
                    + "0: Exit program");
                int selection = AskUserForNumberX("Select");//ispolzyet AskUserForNumberX no pri eto nado sozdat nazvanie int
                switch (selection)
                {
                    case 1:
                        people.Add(CreatePerson());//nazvanie Lista.add + metod
                        break;
                    case 2:
                        PrintList(people);// dobavlyaet v List i pokazivaet
                        break;
                    case 3:
                        people.Add(CreateRandomPerson());// dobavlyaet slychayniy cheloveka v List i pokazivaet
                        break;
                    case 4:
                        RemovePersonFromList(people);// ydalyaet cheloveka iz List
                        break;
                    case 0:
                        stay = false;
                        Console.WriteLine("Thanks for using this program!");
                        break;
                    default:
                        Console.WriteLine("Not a valid selection.");
                        break;
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
                Console.Clear();
            }
            

        }
        static void RemovePersonFromList(List<Person> people)//ydalit
        {
            bool notFound = true;

            Console.WriteLine("--- Remove person ---");
            PrintList(people);// iz list
            int selected = AskUserForNumberX("number of person: ");//sdelat vibor!
            foreach (Person item in people)
            {
                if (item.Id == selected)
                {
                    people.Remove(item);
                    notFound = false;
                    break;
                }
            }
            if (notFound)
            {
                Console.WriteLine("No Person whith that number was found.");
            }
            else
            {
                Console.WriteLine("Person whit " + selected + "has bin removed.");
            }
        }
        private static Person CreateRandomPerson()
        {
            return new Person(
                infoGen.NextFirstName(),//random imya, Next doljen bit
                infoGen.NextLastName(),
                infoGen.Next(1, 120));
        }

        static void PrintList(List<Person> people)//vizozivaet List<Person>
        {
            foreach (Person item in people)//pokazivaet iz Lista
            {
                Console.WriteLine(item);
            }
            //people.ForEach(x => x.SayHello());
        }
        static Person CreatePerson()//sozdaet novogo cheloveka ili predmet
        {
            string firstName = AskUserForX("First name");
            string lastName = AskUserForX("last name");
            int age = AskUserForNumberX("age");

            return new Person(firstName, lastName, age);//ispolzovat kostryktor 
        }


        static string AskUserForX(string x)//prosit text imya ili nazvanie
        {
            string Input = "";
            while (Input.Length == 0)
            {
                Console.Write("Please input " + x + ": ");
                Input = Console.ReadLine();
            }
            return Input;// while zavershit svoe dejstvie return vernet k nachala dejstvi
        }
        static int AskUserForNumberX(string x)//prosit nomer ili vozrost pri sozdani chegoto
        {
            int number = 0;
            bool noNumber = true;
            while (noNumber)
            {
                try
                {
                    number = Convert.ToInt32(AskUserForX(x));
                    noNumber = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a number, Please try once more.");
                }
            }
            return number; // vozvroshaet k metody a v metode vaible togda nado pisat nazvanie variabla
        }
    }
}
