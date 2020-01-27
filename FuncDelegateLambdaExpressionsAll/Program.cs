using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncDelegateLambdaExpressionsAll
{
    class ItemList<T> : List<T>
    {
        public int Sum(Func<T, int> selector)
        {
            int sum = 0;
            foreach (T item in this) sum += selector(item);
            return sum;
        }

        public double Sum(Func<T, double> selector)
        {
            double sum = 0;
            foreach (T item in this) sum += selector(item);
            return sum;
        }
    }

    class Detail
    {
        public int UnitCount;
        public double UnitPrice;
    }

    class Program
    {
        private static void SampleFuncSimple()
        {
            // string as parameter and string as return
            Func<string, string> selector = str => str.ToUpper();

            string[] words = { "life", "fruits" };

            List<string> aWords = words.Select(selector).ToList();

            aWords.ForEach(x => Console.WriteLine(x));
        }

        delegate string ConvertMethod(string inString);
        private static void SampleFuncConvertMethod()
        {
            ConvertMethod convert = UppercaseString;

            string name = "Dakota";

            Console.WriteLine(convert(name));

            string UppercaseString(string inputString)
            {
                return inputString.ToUpper();
            }
        }

        private static void SampleFuncConvertMethodSimplified()
        {
            Func<string, string> convert = UppercaseString;

            string name = "Dakota";

            Console.WriteLine(convert(name));

            string UppercaseString(string inputString)
            {
                return inputString.ToUpper();
            }
        }

        private static void SampleFuncConvertMethodSimplifiedAndAnonymous()
        {
            Func<string, string> convert = delegate (string s)
            {
                return s.ToString();
            };

            string name = "Dakota";

            Console.WriteLine(convert(name));
        }

        private static void SampleFuncConvertMethodSimplifiedAndAnonymousAndLambdaExpression()
        {
            Func<string, string> convert = s => s.ToUpper();

            string name = "Dakota";

            Console.WriteLine(convert(name));
        }

        private static void SampleActionSimple()
        {
            List<string> names = new List<string>();
            names.Add("Bruce");

            names.ForEach(Print);

            names.ForEach(delegate (string name)
            {
                Console.WriteLine(name);
            });

            void Print(string name)
            {
                Console.WriteLine(name);
            }
        }
        
        private static void ComputeSums()
        {
            ItemList<Detail> orderDetails = new ItemList<Detail>();
            orderDetails.Add(new Detail { UnitCount = 10, UnitPrice = 20 });
            orderDetails.Add(new Detail { UnitCount = 10, UnitPrice = 20 });
            orderDetails.Add(new Detail { UnitCount = 10, UnitPrice = 20 });
            int totalUnits = orderDetails.Sum(d => d.UnitCount);
            double orderTotal = orderDetails.Sum(d => d.UnitPrice * d.UnitCount);
        }

        private static void SampleWithDelegateOrLambda()
        {
            Func<int, int, int> sum = delegate (int a, int b) { return a + b; };
            Console.WriteLine(sum(3, 4));

            Func<int, int, int> sumV2 = (a, b) => a + b;
            Console.WriteLine(sumV2(3, 4));
        }

        private static void Execute(Action func)
        {
            var name = func.Method.Name;

            Console.WriteLine("============================================");
            Console.WriteLine();
            Console.WriteLine($"====== {name} start ======");
            Console.WriteLine();

            func();

            Console.WriteLine();
            Console.WriteLine($"====== {name} end ======");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Execute(SampleFuncSimple);

            Execute(SampleActionSimple);

            Execute(SampleFuncConvertMethodSimplified);

            Execute(SampleFuncConvertMethodSimplifiedAndAnonymous);

            Execute(SampleFuncConvertMethod);

            Execute(SampleFuncConvertMethodSimplifiedAndAnonymousAndLambdaExpression);

            Execute(ComputeSums);
        }
    }
}
