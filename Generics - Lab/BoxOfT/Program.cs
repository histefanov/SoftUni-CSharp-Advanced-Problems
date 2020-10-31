using System;

namespace BoxOfT
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var box = new Box<int>();

            for (int i = 1; i < 10; i++)
            {
                box.Add(i);
            }

            box.Print();

            Console.WriteLine(box.Remove()); 
            box.Remove();



            box.Print();
            Console.WriteLine(box.Count);
        }
    }
}
