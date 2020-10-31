using System;
using System.Linq;
using System.Text;

namespace ThreeupleTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = firstLine[0] + " " + firstLine[1];
            string address = firstLine[2];
            var sb = new StringBuilder();
            for (int i = 3; i < firstLine.Length; i++)
            {
                sb.Append(firstLine[i] + " ");
            }
            string town = sb.ToString().TrimEnd();

            string[] secondLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = secondLine[0];
            int litersOfBeer = int.Parse(secondLine[1]);
            bool isDrunk = secondLine[2] == "drunk";

            string[] thirdLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string customer = thirdLine[0];
            double balance = double.Parse(thirdLine[1]);
            string bankName = thirdLine[2];

            Threeuple<string, string, string> nameAndAdress = 
                new Threeuple<string, string, string>(fullName, address, town);

            Threeuple<string, int, bool> nameAndLitersOfBeer = 
                new Threeuple<string, int, bool>(name, litersOfBeer, isDrunk);

            Threeuple<string, double, string> bankDetails = 
                new Threeuple<string, double, string>(customer, balance, bankName);

            Console.WriteLine(
                nameAndAdress.ToString() + "\n" +
                nameAndLitersOfBeer.ToString() + "\n" +
                bankDetails.ToString());
        }
    }
}

