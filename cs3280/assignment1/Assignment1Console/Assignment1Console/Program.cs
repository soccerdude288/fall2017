/*
 * Taylor Earl
 * CS3280
 * 9/2/17
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable Declaration
            int number1;
            int number2;

            //Take User Input
            Console.Write("Enter first integer: ");
            number1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second integer: ");
            number2 = Convert.ToInt32(Console.ReadLine());

            //Preform Math Functions
            Console.WriteLine("");
            Console.WriteLine(number1 + " + " + number2 + " = " + (number1 + number2));
            Console.WriteLine(number1 + " - " + number2 + " = " + (number1 - number2));
            Console.WriteLine(number1 + " * " + number2 + " = " + (number1 * number2));
            Console.WriteLine(number1 + " / " + number2 + " = " + (number1 / number2));
            Console.WriteLine(number1 + " % " + number2 + " = " + (number1 % number2));

            //Check for greater/less than. Print accordingly
            Console.WriteLine("");
            if (number1 > number2)
            {
                Console.WriteLine(number1 + " is not less than " + number2);
                Console.WriteLine(number1 + " is greater than " + number2);
                Console.WriteLine(number1 + " does not equal " + number2);
            }
            else if(number1 < number2)
            {
                Console.WriteLine(number1 + " is less than " + number2);
                Console.WriteLine(number1 + " is not greater than " + number2);
                Console.WriteLine(number1 + " does not equal " + number2);
            }
            else
            {
                Console.WriteLine(number1 + " is not less than " + number2);
                Console.WriteLine(number1 + " is not greater than " + number2);
                Console.WriteLine(number1 + " equals " + number2);
            }

            //Wait for user to enter key to quit
            Console.ReadLine();


        }
    }
}
