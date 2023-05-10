using System;

namespace ConsoleApplication1
{
    struct MyFrac
    {
        public long Numerator, Denominator;
        public MyFrac(long Numerator_, long Denominator_)
        {
            Numerator = Numerator_;
            Denominator = Denominator_;
            if ((Denominator < 0 && Numerator >= 0) || (Denominator < 0 && Numerator < 0))
            {
                Denominator *= -1;
                Numerator *= -1;
            }
            long a = Math.Abs(Numerator);
            long b = Math.Abs(Denominator);
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            Numerator /= a;
            Denominator /= a;
        }

        public override string ToString() => Denominator != 1 ? $"{Numerator}/{Denominator}" : $"{Numerator}";

        /*
        public override string ToString()
        {
            if (Denominator == 1)
            {
                return $"{Numerator}";
            }
            else if (Math.Abs(Numerator) > Denominator)
            {
                int whole = Numerator / Denominator;
                int numerator = Math.Abs(Numerator) % Denominator;
                return $"{whole}({numerator}/{Denominator})";
            }
            else
            {
                return $"({Numerator}/{Denominator})";
            }
        }
        */
    }
    internal class Program
    {
        static string ToStringWithIntegerPart(MyFrac f)
        {
            var Numerator = f.Numerator;
            var Denominator = f.Denominator;
            if (Math.Abs(Numerator) > Math.Abs(Denominator))
            {
                return Numerator < 0 ? $"-({Math.Abs(Numerator / Denominator)} + {Math.Abs(Numerator % Denominator)}/{Denominator})" : $"{Numerator / Denominator} + {Numerator % Denominator}/{Denominator}";
            }
            else
            {
                return $"{Numerator}/{Denominator}";
            }
        }

        static double DoubleValue(MyFrac f)
        {
            return Convert.ToDouble(f.Numerator) / Convert.ToDouble(f.Denominator);
        }

        static MyFrac Plus(MyFrac f1, MyFrac f2)
        {
            long numerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
            long Denominatorinator = f1.Denominator * f2.Denominator;
            return new MyFrac(numerator, Denominatorinator);
        }
        static MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            long numerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
            long Denominatorinator = f1.Denominator * f2.Denominator;
            return new MyFrac(numerator, Denominatorinator);
        }

        static MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            long numerator = f1.Numerator * f2.Numerator;
            long Denominatorinator = f1.Denominator * f2.Denominator;
            return new MyFrac(numerator, Denominatorinator);
        }
        static MyFrac Divide(MyFrac f1, MyFrac f2)
        {
            long numerator = f1.Numerator * f2.Denominator;
            long Denominatorinator = f1.Denominator * f2.Numerator;
            return new MyFrac(numerator, Denominatorinator);
        }

        static MyFrac CalcSum1(int n)
        {
            MyFrac first = new MyFrac(1, 2);
            for (int j = 2; j <= n; j++)
            {
                MyFrac flex = new MyFrac(1, j * (j + 1));
                first = Plus(first, flex);
            }
            return first;
        }
        static MyFrac CalcSum2(int n)
        {
            MyFrac first = new MyFrac(3, 4);
            for (int j = 3; j <= n; j++)
            {
                MyFrac cringe = new MyFrac(j * j - 1, j * j);
                first = Multiply(first, cringe);
            }
            return first;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Введіть чисельник та знаменник першого дробу через пробіл:");
            string[] input1 = Console.ReadLine().Split();
            MyFrac res1 = new MyFrac(long.Parse(input1[0]), long.Parse(input1[1]));
            Console.WriteLine("Введіть чисельник та знаменник другого дробу через пробіл:");
            string[] input2 = Console.ReadLine().Split();
            MyFrac res2 = new MyFrac(long.Parse(input2[0]), long.Parse(input2[1]));
            Console.WriteLine($"Результат додавання двох дробів: {Plus(res1, res2)}");
            Console.WriteLine($"Результат віднімання двох дробів:{Minus(res1, res2)}");
            Console.WriteLine($"Результат множення двох дробів: {Multiply(res1, res2)}");
            Console.WriteLine($"Результат ділення двох дробів: {Divide(res1, res2)}");
            Console.WriteLine($"{CalcSum1(int.Parse(Console.ReadLine()))}");
            Console.WriteLine($"{CalcSum2(int.Parse(Console.ReadLine()))}");
        }
    }
}