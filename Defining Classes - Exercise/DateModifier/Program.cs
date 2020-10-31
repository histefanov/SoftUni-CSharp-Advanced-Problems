using System;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            DateModifier dateModifier = new DateModifier();

            dateModifier.CalculateDifference(firstDate, secondDate);
            Console.WriteLine(dateModifier.Difference);          
        }
    }
}
