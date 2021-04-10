using System;

namespace Excercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(FormatOutput("Type", "Byte(s) of memory", "Min", "Max", true));
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(FormatOutput(nameof(SByte), sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue));
            Console.WriteLine(FormatOutput(nameof(Byte), sizeof(byte), byte.MinValue, byte.MaxValue));
            Console.WriteLine(FormatOutput(nameof(Int16), sizeof(short), short.MinValue, short.MaxValue));
            Console.WriteLine(FormatOutput(nameof(UInt16), sizeof(ushort), ushort.MinValue, ushort.MaxValue));
            Console.WriteLine(FormatOutput(nameof(Int32), sizeof(int), int.MinValue, int.MaxValue));
            Console.WriteLine(FormatOutput(nameof(UInt32), sizeof(uint), uint.MinValue, uint.MaxValue));
            Console.WriteLine(FormatOutput(nameof(Int64), sizeof(long), long.MinValue, long.MaxValue));
            Console.WriteLine(FormatOutput(nameof(UInt64), sizeof(ulong), ulong.MinValue, ulong.MaxValue));
            Console.WriteLine(FormatOutput(nameof(Single), sizeof(float), float.MinValue, float.MaxValue));
            Console.WriteLine(FormatOutput(nameof(Double), sizeof(double), double.MinValue, double.MaxValue));
            Console.WriteLine(FormatOutput(nameof(Decimal), sizeof(decimal), decimal.MinValue, decimal.MaxValue));
        }

        static string FormatOutput(string type, dynamic memorySize, dynamic min, dynamic max, bool isHeader = false)
        {                        
            return isHeader ? string.Format("{0,-8}{1,-17}{2,17}{3,31}", type, memorySize.ToString(), min.ToString(), max.ToString()) 
                : string.Format("{0,-8}{1,-3}{2,31}{3,31}", type, memorySize.ToString(), min.ToString(), max.ToString());
        }
    }
}
