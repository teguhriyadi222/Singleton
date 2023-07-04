// using System;

// public class Calculator
// {
//     // private static Calculator instance;

//     private static readonly Calculator instance = new Calculator();
//     private static object lockObject = new object();

//     private Calculator()
//     {
        
//     }

//     // public static Calculator Instance
//     // {
//     //     get
//     //     {
//     //         if (instance == null)
//     //         {
//     //                 if (instance == null)
//     //                 {
//     //                     instance = new Calculator();
//     //                 }
                
//     //         }
//     //         return instance;
//     //     }
//     // }

//     public static Calculator Instance
//     {
//         get
//         {
//             return instance;
//         }
//     }

//     public int Add(int a, int b)
//     {
//         return a + b;
//     }

//     public int Subtract(int a, int b)
//     {
//         return a - b;
//     }

//     public int Multiply(int a, int b)
//     {
//         return a * b;
//     }

//     public int Divide(int a, int b)
//     {
//         if (b != 0)
//         {
//             return a / b;
//         }
//         else
//         {
//             throw new DivideByZeroException("Cannot divide by zero.");
//         }
//     }
// }

// public class ClassA
// {
//     public void PerformCalculation()
//     {
//         Calculator calculator = Calculator.Instance;
//         int result = calculator.Add(5, 3);
//         Console.WriteLine("Class A - Result: " + result);
//     }
// }

// public class ClassB
// {
//     public void PerformCalculation()
//     {
//         Calculator calculator = Calculator.Instance;
//         int result = calculator.Add(8, 4);
//         Console.WriteLine("Class B - Result: " + result);
//     }
// }

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         ClassA classA = new ClassA();
//         ClassB classB = new ClassB();

//         classA.PerformCalculation();
//         classB.PerformCalculation();
//     }
// }