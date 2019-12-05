using System;

namespace BFS_c_sharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var generator = new RandomDataGenerator();
            var users = generator.Generate();

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
