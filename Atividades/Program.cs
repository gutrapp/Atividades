using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividades
{
    internal class Hangman
    {
        public string word;
        public List<char> guesses = new List<char>();
        public int lives = 5;
        public bool win = false;
        public char[] display;

        public Hangman(string word) 
        {
            this.word = word;
            while (word == "")
            {
                Console.WriteLine("\nTente novamente, palavra invalida");
                word = Console.ReadLine();
            }

            this.display = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                this.display[i] = '_';
            }
        }

        public void DisplayCurrentGuesses()
        {
            Console.WriteLine($"\nVidas: {this.lives}");

            if (guesses.Count != 0)
            {
                Console.WriteLine("\nChutes:");
                foreach (char guess in this.guesses)
                {
                    Console.Write($"{guess}, ");
                }
            }

            Console.WriteLine("\n\nPalavra");
            for (int i = 0; i < this.display.Length; i++)
            {
                Console.Write($"{display[i]}, ");
            }
        }

        public void CheckGuess(char guess)
        {
            for (int i = 0; i < this.guesses.Count; i++)
            {
                if (this.guesses[i] == guess)
                {
                    Console.WriteLine("\nVoce ja tentou esta letra!");
                    return;
                }
            }

            this.guesses.Add(guess);
            bool flag = false;

            for (int i = 0; i < this.word.Length; i++)
            {
                if (this.word[i] == guess)
                {
                    this.display[i] = guess;
                    flag = true;
                }
            }

            if (!flag) lives--;

            if (this.word == new string(this.display)) this.win = true;
        }
    }

    internal class SortNumbers
    {
        public List<int> numbers = new List<int>();
    
        public SortNumbers()
        {
            int option = 0;

            while (option != 2)
            {
                Console.WriteLine("\n1-Adicionar numero\n2-Sair");
                option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.WriteLine("\nNumero para adicionar:");
                    this.numbers.Add(int.Parse(Console.ReadLine()));
                }
            }
        }

        public void DisplayNumbersSorted()
        {
            if (this.numbers.Count == 0) 
            {
                Console.WriteLine("\nNenhuma numero encontrado");
                return; 
            }

            for (int i = 0; i < this.numbers.Count; i++)
            {
                for (int j = 0; j < this.numbers.Count; j++)
                {
                    if (this.numbers[i] < this.numbers[j])
                    {
                        int helper = this.numbers[j];
                        this.numbers[j] = this.numbers[i];
                        this.numbers[i] = helper;
                    }
                }
            }

            foreach (int num in this.numbers)
            {
                Console.Write($"{num}, ");
            }
        }
    }

    internal class CheckPalindrome
    {
        public string word;

        public CheckPalindrome()
        {
            Console.WriteLine("Digite a palavra que voce quer checkar:");
            this.word = Console.ReadLine();
        }

        public bool Check()
        {
            if (this.word.Length == 0) return false;
            if (this.word.Length == 1) return true;

            int left = 0;
            int right = this.word.Length - 1;

            while (left < right) 
            {
                if (this.word[left] != this.word[right])
                {
                    return false;
                }
                else
                {
                    left++;
                    right--;
                }
            }

            return true;
        }
    
    }

    internal class Program
    {
        static void PlayHangman()
        {
            Console.WriteLine("\nEscolha qual vai ser a palavra:");
            Hangman game = new Hangman(Console.ReadLine());

            while (game.lives != 0 && !game.win)
            {
                game.DisplayCurrentGuesses();

                Console.WriteLine("\nFaca um chute:");
                char guess = char.Parse(Console.ReadLine());

                game.CheckGuess(guess);
            }

            if (game.win)
            {
                Console.WriteLine("\nVOCE GANHOU!");
            }
            else
            {
                Console.WriteLine("\nVOCE PERDEU!");
            }
        }

        static void Palindrome()
        {
            CheckPalindrome word = new CheckPalindrome();
            bool isPalindrome = word.Check();

            Console.WriteLine(isPalindrome ? $"A string {word.word} é um palíndromo" : $"A string {word.word} não é um palíndromo");
        }

        static void SortNumbers()
        {
            SortNumbers numbers = new SortNumbers();

            numbers.DisplayNumbersSorted();
        }

        static void Main(string[] args)
        {

            // Palindrome();
            // SortNumbers();
            // PlayHangman();

            Console.ReadKey();
        }
    }
}
