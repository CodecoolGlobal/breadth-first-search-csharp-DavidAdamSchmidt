﻿using System;

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

            Console.WriteLine("\n--- GetDistanceFromUser ---");
            var user1 = users[0];
            var user2 = users[7];
            var distance = user1.GetDistanceFromUser(user2.Id);
            Console.WriteLine($"The distance between {user1} and {user2} is {distance ?? -1}");

            Console.WriteLine("\n--- GetFriendsOfFriends ---");
            distance = 1;
            var friendsOfFriends = user1.GetFriendsOfFriends((int) distance);
            Console.WriteLine($"Friends of friends of {user1} at distance {distance}:");
            Console.WriteLine(string.Join(", ", friendsOfFriends));
            Console.WriteLine($"Count: {friendsOfFriends.Count}");

            Console.WriteLine("\n--- GetShortestPaths ---");
            var shortestPaths = user1.GetShortestPaths(user2.Id);
            Console.WriteLine($"The shortest path between {user1} and {user2} are:");
            foreach (var path in shortestPaths)
            {
                Console.WriteLine(string.Join(", ", path));
            }

            Console.WriteLine("\nDone");
            Console.ReadKey();
        }
    }
}
