using System.Collections.Generic;

namespace BFS_c_sharp.Model
{
    public class UserNode
    {
        public UserNode() { }

        public UserNode(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public HashSet<UserNode> Friends { get; } = new HashSet<UserNode>();

        public void AddFriend(UserNode friend)
        {
            Friends.Add(friend);
            friend.Friends.Add(this);
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + "(" + Friends.Count + ")";
        }
    }
}
