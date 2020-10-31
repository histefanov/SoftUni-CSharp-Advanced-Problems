using System;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] initialInput = Console.ReadLine()
                .Substring(6)
                .TrimStart()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var listyIterator = new ListyIterator<string>(initialInput);

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                switch (cmd)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "PrintAll":
                        listyIterator.PrintAll();
                        break;
                    default: break;
                }
            }
        }
    }
}
