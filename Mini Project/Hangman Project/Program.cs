namespace Hangman_Project
{
    class Game
    {
        public List<string> words = new List<string>()
        {
            "Apple",
            "Bright",
            "Cloud",
            "Dream",
            "Forest",
            "Garden",
            "Happy",
            "Island",
            "Journey",
            "Kindle",
            "Lemon",
            "Mountain",
            "Night",
            "Ocean",
            "Planet",
            "Quiet",
            "River",
            "Smile",
            "Tiger",
            "Valley"
        };

        public string Guess { get; set; }

        public Game()
        {
            Random random = new Random();
            string a = string.Empty;
            int num = random.Next(words.Count);
            Guess = words[num].ToLower();
        }

        public string CreateString()
        {
            string a = string.Empty;
            for (int i = 0; i < Guess.Length; i++) a += '_';
            return a;
        }

        private int lives;

        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        private int found;

        public int Found
        {
            get { return found; }
            set { found = 0; }
        }

        public string Exists { get; set; }


        public bool Validate(string s)
        {
            return char.IsAsciiLetter(s[0]);
        }


        public string UpdateString(string s, char curr)
        {
            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (curr == Guess[i])
                {
                    arr[i] = curr;
                    found++;
                }
            }
            return new string(arr);
        }

        public bool IsFound()
        {
            return Found == Guess.Length;
        }

        public bool AlreadyExists(char curr)
        {
            if (string.IsNullOrEmpty(Exists)) return false;
            return Exists.Contains(curr);
        }

        public string PrintGuessed()
        {
            string print = string.Empty;
            if (!string.IsNullOrEmpty(Exists))
                foreach (char c in Exists) print = print + c + ' ';
            return print;
        }

    }
    internal class HangMan
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hangman game :-");


            Game game = new Game();

            string tbf = game.CreateString();

            game.Lives = 6;

            while (game.Lives > 0)
            {
                Console.WriteLine("\n**************\n");
                Console.WriteLine(tbf + "\n");
                Console.WriteLine($"Lives left : {game.Lives}");
                Console.WriteLine($"Guessed : {game.PrintGuessed()}");
                Console.Write("Enter your guess = ");
                string? check = Console.ReadLine();

                char ch = char.ToLower(check[0]);
                if (game.Validate(check))
                {
                    if (game.AlreadyExists(ch))
                    {
                        Console.WriteLine("\nAlready Guessed");
                        continue;
                    }
                    if (game.Guess.Contains(ch))
                    {
                        Console.WriteLine("\nGood guess");
                        tbf = game.UpdateString(tbf, ch);
                        game.Exists += ch;
                        if (game.IsFound()) break;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("\nNot found");
                        game.Exists += check[0];
                        game.Lives--;
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease Input a letter");
                    continue;
                }

            }
            if (game.IsFound()) Console.WriteLine("\nCongratulation you found the word");
            else Console.WriteLine($"\nGame Over. The word was {game.Guess.ToUpper()}");

            Console.ReadLine();

        }
    }
}s