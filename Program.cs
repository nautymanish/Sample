using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElevatorProblem;
using System.Threading;

namespace WindowsFormsApplication1
{
    class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Person
    {
        public int LanguageId { get; set; }
        public string FirstName { get; set; }
    }

    public delegate void MathDelegate(int No1, int No2);
    static class Program
    {
       
        public static void Add(int x, int y)
        {
            Console.WriteLine("THE SUM IS : " + (x + y));
        }
        public static void Sub(int x, int y)
        {
            Console.WriteLine("THE SUB IS : " + (x - y));
        }
        public static void Mul(int x, int y)
        {
            Console.WriteLine("THE MUL IS : " + (x * y));
        }
        public static void Div(int x, int y)
        {

            try
            {
                Console.WriteLine("THE DIV IS : " + (x / y));
            }
            catch (Exception ex) { }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Sample_GroupJoin_Lambda()
        {
            Language[] languages = new Language[]
            {
        new Language {Id = 1, Name = "English"},
        new Language {Id = 2, Name = "Russian"}
            };

            Person[] persons = new Person[]
            {
        new Person { LanguageId = 1, FirstName = "Tom" },
        new Person { LanguageId = 1, FirstName = "Sandy" },
        new Person { LanguageId = 3, FirstName = "Vladimir" },
        new Person { LanguageId = 4, FirstName = "Mikhail" },
            };

            var result = languages.Join(persons, lang => lang.Id, pers => pers.LanguageId,
                (lang, ps) => new { Key = lang.Name, Persons = ps });


            //foreach (var language in result)
            //{
            //    Console.WriteLine(String.Format("Persons speaking {0}:", language.Key));

            //    foreach (var person in language.Persons)
            //    {
            //        Debug.WriteLine(person.FirstName);
            //    }
            //}
        }
        private static string result;
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Hey Jude");
            John();
            Console.WriteLine(result);
            Paul();
            Console.WriteLine(result);
            Ringo();
            Console.WriteLine(result);
            George();
            Console.WriteLine(result);
            Console.ReadLine();


            var obj = new A();
            var x = obj.Check();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Sample_GroupJoin_Lambda();
            //ElevatorProblem.ElevatorController ec = new ElevatorProblem.ElevatorController();
            //ec.Attach(new Elevator("E1", 7, Direction.UP));
            //ec.Attach(new Elevator("E2", 4, Direction.DOWN));
            //ec.Attach(new Elevator("E3", -2, Direction.UP));
            //Person p = null;// new Person() { CurrentFloor=3, DirectionPressed= Direction.DOWN};
            //ec.PersonRequested = p;
            //ec.NotifyPersonForTheLift();
            MathDelegate del4 = new MathDelegate(Div);
            MathDelegate del1 = new MathDelegate(Add);
            MathDelegate del2 = new MathDelegate(Sub);
            MathDelegate del3 = new MathDelegate(Mul);

            //In this example del5 is a multicast delegate. We can use +(plus) 
            // operator to chain delegates together and -(minus) operator to remove.
            MathDelegate del5 = del4 + del2 + del3 + del1;
            del5(2, 0);

            string s = "occurence";
           
            var res1 = s.GroupBy(t => t).Select(e => new { ch=e.Key, count=e.Count() });
            foreach (var r in res1)
            {
                Console.WriteLine(r.ch + "" + r.count);
            }

            Application.Run(new Form1());

        }
        static async Task John()
        {
            await Task.Delay(5);
            result = "Don't make it bad";
        }
        static async Task<object> Paul()
        {
            await Task.Delay(0);
            result = "Don't be afraid";
            return Task.FromResult<object>(null);
        }
        static async Task<bool> Ringo()
        {
            Thread.Sleep(5);
            result = "Don't let me down";
            return false;
        }
        static async Task<string> George()
        {
            Thread.Sleep(-1);
            result = "You'll do";
            return "Beatles!";
        }

    }

public class A
    {

        public async Task<int> Check()
        {
            await TestAsync();
            Console.WriteLine("A");
            var x =TestAsyncAgain();
            Console.WriteLine("B");
            await x;
            Console.WriteLine("C");
            return 0;
        }
        async Task<int> TestAsync()
        {
            await Task.Delay(10000);
            Console.WriteLine("TestAsync");
            return 1;
        }
        async Task<int> TestAsyncAgain()
        {
            await Task.Delay(10000);
            Console.WriteLine("TestAsyncAgain");
            return 2;
        }



    }

}
