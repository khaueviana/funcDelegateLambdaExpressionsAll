using System;

namespace TutorialsTeacher
{
    class DelegateTutorials
    {
        public delegate void Print(int val);

        static void ConsolePrint(int i)
        {
            Console.WriteLine(i);
        }

        public void Execute()
        {
            Print prnt = ConsolePrint;
            prnt(10);

            Action<int> printActionDel = ConsolePrint;
            printActionDel(10);

            Action<int> printActionDel2 = new Action<int>(ConsolePrint);

            Action<int> printActionDel3 = delegate (int i)
            {
                Console.WriteLine(i);
            };

            Action<int> printActionDel4 = (int i) =>
            {
                Console.WriteLine(i);
            };

            Action<int> printActionDel5 = i => Console.WriteLine(i);
        }
    }

    class PredicateTutorials
    {
        private bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }

        public void Execute()
        {
            Predicate<string> isUpper = IsUpperCase;

            Predicate<string> isUpper2 = delegate (string s) { return s.Equals(s.ToUpper()); };

            Predicate<string> isUpper3 = s => s.Equals(s.ToUpper());

            bool result = isUpper("hello worlds");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new DelegateTutorials().Execute();
        }
    }
}
