
using System.Diagnostics.CodeAnalysis;

namespace TheSocialNetwork
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        List<Person> friends = new List<Person>();

        public void AddFriend(Person p)
        {
            if (p.Id == this.Id || this.friends.Contains(p)) return;
            friends.Add(p);
            p.friends.Add(this);
        }
        public string ShowFriends()
        {
            string a = string.Empty;

            var myfriend = friends.Select(x => new string(x.Name));
            a = string.Join(", ", myfriend);
            return a + "\n";
        }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }

    class SocialNetwork
    {
        List<Person> members = new List<Person>();

        public void AddMember(Person p)
        {
            members.Add(p);
        }

        public string ShowNetwork()
        {
            string a = "";
            foreach (Person p in members)
            {
                a += $"{p.Name}'s friends are :-\n";
                a += p.ShowFriends() == "\n" ? $"{p.Name} is a lonely boy\n" : p.ShowFriends();
            }

            return a;
        }

        public bool AddFriend(Person p1, Person p2, out Person? p3)
        {
            if (!members.Contains(p1) || !members.Contains(p2))
            {
                p3 = members.Contains(p1) ? p2 : p1;
                return false;
            }
            p1.AddFriend(p2);
            p3 = null;
            return true;
        }
    }


    internal class GraphSocialNetwork
    {
        static void Main(string[] args)
        {
            Person aaroh = new Person(1, "Aaroh");
            Person hritik = new Person(2, "Hritik");
            Person sahil = new Person(3, "Sahil");
            Person tushar = new Person(4, "Tushar");
            Person mayank = new Person(5, "Mayank");

            SocialNetwork socialNetwork = new SocialNetwork();

            socialNetwork.AddMember(tushar);
            socialNetwork.AddMember(hritik);
            socialNetwork.AddMember(sahil);
            socialNetwork.AddMember(mayank);

            Person? p3;

            if (!socialNetwork.AddFriend(sahil, tushar, out p3))
                Console.WriteLine($"{p3.Name} does not exist in the network");

            if (!socialNetwork.AddFriend(tushar, hritik, out p3))
                Console.WriteLine($"{p3.Name} does not exist in the network");

            if (!socialNetwork.AddFriend(tushar, sahil, out p3))
                Console.WriteLine($"{p3.Name} does not exist in the network");

            if (!socialNetwork.AddFriend(aaroh, sahil, out p3))
                Console.WriteLine($"{p3.Name} does not exist in the network");

            Console.WriteLine(socialNetwork.ShowNetwork());

        }
    }
}
