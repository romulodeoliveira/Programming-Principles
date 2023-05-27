using System;

namespace Exemple01
{
    class Program
    {
        static void Main(string[] args)
        {
            int result01 = Multiplication.Multiply(2, 5);
            System.Console.WriteLine(result01);

            int result02 = Division.ToDivide(result01, 2);
            System.Console.WriteLine(result02);
        }
    }
}