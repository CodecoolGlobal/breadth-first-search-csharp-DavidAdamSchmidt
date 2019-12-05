using System;
using System.Collections.Generic;
using System.Linq;

namespace BFS_c_sharp.Model
{
    public class UserNode
    {
        public UserNode()
        {
            Id = Guid.NewGuid().ToString();
        }

        public UserNode(string firstName, string lastName)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public HashSet<UserNode> Friends { get; } = new HashSet<UserNode>();

        public void AddFriend(UserNode friend)
        {
            Friends.Add(friend);
            friend.Friends.Add(this);
        }

        public int? GetDistanceFromUser(string userId)
        {
            var toCheck = new Queue<UserNode>(Friends);
            var visited = new HashSet<UserNode>();
            var distance = 1;
            var nodesLeftOnLevel = toCheck.Count;

            while (toCheck.Count > 0)
            {
                var node = toCheck.Dequeue();
                visited.Add(node);

                if (node.Id == userId)
                {
                    return distance;
                }

                foreach (var friend in node.Friends.Where(friend => !visited.Contains(friend)))
                {
                    toCheck.Enqueue(friend);
                }

                if (--nodesLeftOnLevel == 0)
                {
                    distance++;
                    nodesLeftOnLevel = toCheck.Count;
                }
            }

            return null;
        }

        public HashSet<UserNode> GetFriendsOfFriends(int distance)
        {
            var depth = 1;
            var collected = new HashSet<UserNode>();
            var toCheck = new HashSet<UserNode> { this };

            while (depth <= distance)
            {
                var temp = new HashSet<UserNode>();

                foreach (var friend in toCheck.SelectMany(n => n.Friends))
                {
                    if (friend != this && !collected.Contains(friend))
                    {
                        temp.Add(friend);
                    }
                }

                collected.UnionWith(temp);
                toCheck = temp;
                depth++;
            }

            return collected;
        }

        public List<List<string>> GetShortestPaths(string userId)
        {
            var paths = new List<List<string>>();
            var currentPath = new Stack<UserNode>();
            currentPath.Push(this);
            var distance = GetDistanceFromUser(userId);

            if (distance != null)
            {
                FillPathList(this);
            }

            return paths;

            void FillPathList(UserNode currentNode)
            {
                foreach (var friend in currentNode.Friends.Where(f => !currentPath.Contains(f)))
                {
                    if (currentPath.Count > distance)
                    {
                        break;
                    }
                    currentPath.Push(friend);
                    if (friend.Id == userId)
                    {
                        paths.Add(currentPath.Reverse().Select(node => node.ToString()).ToList());
                        currentPath.Pop();
                        break;
                    }
                    FillPathList(friend);
                }

                if (currentPath.Count > 0)
                {
                    currentPath.Pop();
                }
            }
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + "(" + Friends.Count + ")";
        }
    }
}
