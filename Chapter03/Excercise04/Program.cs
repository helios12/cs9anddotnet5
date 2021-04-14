using System;

namespace Excercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10 & 8;
            int y = 10 | 7;
            Console.WriteLine(x);
            Console.WriteLine(y);
            return;

            Console.Write("Enter a number between 0 and 255: ");
            string number1 = Console.ReadLine();
            Console.Write("Enter another number between 0 and 255: ");
            string number2 = Console.ReadLine();

            try
            {
                int parsedNumber1 = int.Parse(number1);
                int parsedNumber2 = int.Parse(number2);
                Console.WriteLine($"{parsedNumber1} / {parsedNumber2} = {parsedNumber1 / parsedNumber2}");
            }
            catch (FormatException ex)
            {
                WriteException(ex);
            }
            catch (DivideByZeroException ex)
            {
                WriteException(ex);
            }
            catch (OverflowException ex)
            {
                WriteException(ex);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        static void WriteException(Exception ex)
        {
            Console.WriteLine($"{ex.GetType()}: {ex.Message}");
        }
    }
}
