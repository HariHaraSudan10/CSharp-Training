using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//4. Write a console program that uses delegate object as an argument
//to call Calculator Functionalities like 1. Addition, 2. Subtraction and 3. Multiplication
//by taking 2 integers and returning the output to the user. You should display all the return values accordingly.

namespace Assessment2
{
    public delegate int CalculatorDelegate(int a, int b);
    
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public static int Calculate(CalculatorDelegate operation, int num1, int num2)
        {
            return operation(num1, num2);
        }
    }
    
    
    internal class Question4
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            CalculatorDelegate addDel = c.Add;
            CalculatorDelegate subDel = c.Subtract;
            CalculatorDelegate mulDel = c.Multiply;
            
            Console.WriteLine("Enter the first number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            int num2 = int.Parse(Console.ReadLine());

            int add = Calculator.Calculate(addDel, num1, num2);
            int sub = Calculator.Calculate(subDel, num1, num2);
            int mul = Calculator.Calculate(mulDel, num1, num2);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("------------------Results-------------------");
            Console.WriteLine($"\nAddition: {num1} + {num2} = {add}");
            Console.WriteLine($"Subtraction: {num1} - {num2} = {sub}");
            Console.WriteLine($"Multiplication: {num1} * {num2} = {mul}");
        }
    }
}
