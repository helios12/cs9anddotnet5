using System;

namespace NullHandling
{
    class Address
    {
        public string? Building;
        public string Street = string.Empty;
        public string City = string.Empty;
        public string Region = string.Empty;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int thisCannotBeNull = 4;
            // thisCannotBeNull = null;
            int? thisCouldBeNull = null;

            Console.WriteLine(thisCouldBeNull);
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());
            thisCouldBeNull = 7;
            Console.WriteLine(thisCouldBeNull);
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());

            if (thisCouldBeNull != null)
            {
                
            }

            Address address = new();
            address.Building = null;
            address.Street = "";
            address.City = "London";
            address.Region = "";

            int? buildingLength = address.Building?.Length ?? 100;
            Console.WriteLine(buildingLength);
        }
    }
}
