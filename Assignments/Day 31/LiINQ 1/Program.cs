using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace LINQ
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;

        public override string ToString()
        {
            return $"{Id} {Name} {Class} {Marks}";
        }
    }

    class Employee
    {
        public int Id;
        public string Name;
        public string Dept;
        public double Salary;
        public DateOnly JoinDate;

        public override string ToString()
        {
            return $"{Id} {Name} {Dept} {Salary} {JoinDate}";
        }
    }

    class Product
    { public int Id; public string Name; public string Category; public double Price; }
    class Sale
    { public int ProductId; public int Qty; }

    class Book
    {
        public string Title;
        public string Author;
        public string Genre;
        public int Year;
        public double Price;

        public override string ToString()
        {
            return $"{Title} {Author} {Genre} {Year} {Price}";
        }
    }

    class Movie
    {
        public string Title;
        public string Genre;
        public double Rating;
        public int Year;

        public override string ToString()
        {
            return $"{Title} {Genre} {Rating} {Year}";
        }
    }

    class Transaction
    {
        public int Acc;
        public double Amount;
        public string Type;

        public override string ToString()
        {
            return $"{Acc} {Amount} {Type}";
        }
    }

    class CartItem
    { public string Name; public string Category; public double Price; public int Qty; }

    class User
    { public int Id; public string Name; public string Country; }
    class Post
    { public int UserId; public int Likes; }


    internal class Program
    {
        static void School()
        {
            var students = new List<Student>
            {
                new Student{Id=1, Name="Amit", Class="10A", Marks=85},
                new Student{Id=2, Name="Neha", Class="10A", Marks=72},
                new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
                new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
                new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
            };

            Console.WriteLine("\nGet top 3 students by marks");
            var top3 = students.OrderByDescending(x => x.Marks).Take(3);
            Console.WriteLine(string.Join('\n', top3));

            Console.WriteLine("\nGroup students by Class and calculate average marks");
            var avgMarks = students.GroupBy(x => x.Class).Select(p => new { p.Key, Avg = p.Average(h => h.Marks) });
            foreach (var avg in avgMarks)
            {
                Console.WriteLine($"Group {avg.Key} has {avg.Avg} marks");
            }

            Console.WriteLine("\nList students who scored below class average");
            var belowAverage = students.Where(p => p.Marks < students.Where(a => a.Class == p.Class).Average(x => x.Marks));
            Console.WriteLine(string.Join('\n', belowAverage));

            Console.WriteLine("\nOrder students by Class then by Marks descending");
            var orderByClass = students.OrderBy(x => x.Class).OrderByDescending(p => p.Marks);
            Console.WriteLine(string.Join('\n', orderByClass));
        }

        static void Office()
        {
            var employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateOnly(2019,1,10)},
                new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateOnly(2021,3,5)},
                new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateOnly(2018,7,15)},
                new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateOnly(2022,9,1)}
            };

            Console.WriteLine("\nGet highest and lowest salary in each department");
            var highestAndLowest = employees.GroupBy(x => x.Dept).Select(p => new { p.Key, Max = p.Max(a => a.Salary), Min = p.Min(a => a.Salary) });
            foreach (var hanl in highestAndLowest)
            {
                Console.WriteLine($"In group {hanl.Key} highest salary is {hanl.Max} and lowest salary is {hanl.Min}");
            }

            Console.WriteLine("\nCount employees per department");
            var empPerDept = employees.GroupBy(x => x.Dept);
            foreach (var emp in empPerDept)
            {
                Console.WriteLine($"{emp.Key} has {emp.Count()} employees");
            }

            Console.WriteLine("\nFilter employees joined after 2020");
            var employeeAfter2020 = employees.Where(e => e.JoinDate.Year > 2020);
            Console.WriteLine(string.Join('\n', employeeAfter2020));

            Console.WriteLine("\nProject anonymous objects with Name and AnnualSalary");
            var anonObject = employees.Select(p => new { p.Name, p.Salary });
            Console.WriteLine(string.Join('\n', anonObject));
        }

        static void Inventory()
        {
            var products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
                new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
                new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
            };

            var sales = new List<Sale>
            {
                new Sale{ProductId=1, Qty=10},
                new Sale{ProductId=2, Qty=20}
            };

            //var joinedData = products.Join(sales,p => p.Id,s=> s.ProductId, (i,o) => new {i.});

        }

        static void Library()
        {
            var books = new List<Book>
            {
                new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
                new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
                new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
            };

            Console.WriteLine("\nFind books published after 2015");
            var after2015 = books.Where(x => x.Year > 2015);
            Console.WriteLine(string.Join('\n', after2015));

            Console.WriteLine("\nGroup by Genre and count books");
            var groupandCount = books.GroupBy(x => x.Genre);
            foreach (var book in groupandCount)
            {
                Console.WriteLine($"{book.Key} has {book.Count()} books");
            }

            Console.WriteLine("\nGet most expensive book per Genre");
            var mostExpensivePerGenre = books.GroupBy(x => x.Genre).Select(p => new { p.Key, Max = p.Max(a => a.Price) });
            foreach (var book in mostExpensivePerGenre)
            {
                Console.WriteLine($"{book.Key} genre's most expensive book is {book.Max}");
            }

            Console.WriteLine("\nReturn distinct authors list");
            var distinctAuthor = books.Select(x => x.Author).Distinct();
            Console.WriteLine(distinctAuthor);

        }

        static void Theatre()
        {
            var movies = new List<Movie>
            {
                new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
                new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
                new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
            };

            Console.WriteLine("\nFilter movies with rating > 8");
            var ratingMoreThan8 = movies.Where(x => x.Rating > 8);
            Console.WriteLine(string.Join('\n', ratingMoreThan8));

            Console.WriteLine("\nGroup movies by Genre and get average rating");
            var groupGenre = movies.GroupBy(x => x.Genre).Select(p => new { p.Key, Avg = p.Average(a => a.Rating) });
            foreach (var group in groupGenre)
            {
                Console.WriteLine($"{group.Key} genre has an average rating of {group.Avg}");
            }

            Console.WriteLine("\nFind latest movie per Genre");
            var latestMovie = movies.Max(x => x.Year);
            Console.WriteLine(latestMovie);

            Console.WriteLine("\nGet top 5 highest-rated movies");
            var top3 = movies.OrderByDescending(x => x.Rating).Take(3);
            Console.WriteLine(string.Join('\n', top3));
        }

        static void Bank()
        {
            var transactions = new List<Transaction>
            {
                new Transaction{Acc=101, Amount=5000, Type="Credit"},
                new Transaction{Acc=101, Amount=2000, Type="Debit"},
                new Transaction{Acc=102, Amount=10000, Type="Debit"}
            };

            Console.WriteLine("\nCalculate total balance per account");
            var totalBalance = transactions.Sum(x => x.Amount);
            Console.WriteLine(totalBalance);

            //Console.WriteLine("\nList suspicious accounts with total debit > credit");

            //Console.WriteLine("\nGroup transactions by month");
            //var groupByMonth = transactions.GroupBy(x=)

            Console.WriteLine("\nFind highest transaction amount per account");
            var highestTransaction = transactions.GroupBy(x => x.Acc).Select(p => new { p.Key, Max = p.Max(a => a.Amount) });
            foreach (var transaction in highestTransaction)
            {
                Console.WriteLine($"{transaction.Key} account's maxiumum is {transaction.Max}");
            }

        }

        static void Ecommerce()
        {
            var cart = new List<CartItem>
            {
                new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
                new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
            };

            Console.WriteLine("\nCalculate total cart value");
            var totalCartValue = cart.Sum(x => x.Price);
            Console.WriteLine(totalCartValue);

            Console.WriteLine("\nGroup by Category and total category cost");
            var groupByCategory = cart.GroupBy(x => x.Category).Select(a => new { a.Key, Sum = a.Sum(p => p.Price) });
            foreach (var category in groupByCategory) { Console.WriteLine($"{category.Key} category has total price of {category.Sum}"); }

            Console.WriteLine("\nApply 10% discount for Electronics category");
            var discountOnElectronics = cart.Where(x => x.Category == "Electronics").Select(x => new { Name = x.Name, newPrice = x.Price - (int)(x.Price / 10) });
            foreach (var discount in discountOnElectronics)
            {
                Console.WriteLine($"After Discount value for {discount.Name} is {discount.newPrice}");
            }
        }

        static void SocialMedia()
        {
            var users = new List<User>
            {
                new User{Id=1, Name="A", Country="India"},
                new User{Id=2, Name="B", Country="USA"}
            };

            var posts = new List<Post>
            {
                new Post{UserId=1, Likes=100},
                new Post{UserId=1, Likes=50}
            };

            Console.WriteLine("\nGet top users by total likes");
            var topByLikes = users.Join(posts, p => p.Id, s => s.UserId, (s, d) => new { Id = s.Id, Name = s.Name, Likes = d.Likes }).OrderByDescending(a => a.Likes).FirstOrDefault();
            Console.WriteLine(string.Join('\n', topByLikes));

            Console.WriteLine("\nGroup Users by Country");
            var groupByCountry = users.GroupBy(x => x.Country);
            foreach (var group in groupByCountry)
            {
                Console.WriteLine($"{group.Key} has {group.Count()} Users");
            }

            Console.WriteLine("\nList incative users (no posts)");
            var inactiveUsers = users.GroupJoin(posts, i => i.Id, o => o.UserId, (o, d) => new { Id = o.Id, Name = o.Name, Active = d.Any() }).Where(a => a.Active == false);
            foreach (var user in inactiveUsers)
            {
                Console.WriteLine($"{user.Id} {user.Name}");
            }

        }
        static void Main(string[] args)
        {
            School();
            Office();
            Inventory();
            Library();
            Theatre();
            Bank();
            Ecommerce();
            SocialMedia();
        }
    }
}
