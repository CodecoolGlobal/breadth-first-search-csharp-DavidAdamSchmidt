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

            var user1 = users[0];
            var user2 = users[7];
            var distance = user1.GetDistanceFromUser(user2.Id);
            Console.WriteLine($"The distance between {user1} and {user2} is {distance ?? -1}");

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
