using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number?");
        string random_number = Console.ReadLine();
        int magic = int.Parse(random_number);
        Console.Write("What is your guess?");
        string think = Console.ReadLine();
        int guess = int.Parse(think);

        if (guess > magic)
        {
            Console.WriteLine("Lower");
        }
        else if (guess < magic)
        {
            Console.WriteLine($"Higher");
        }
        else
        {
            Console.WriteLine("You got it");
        }

    }
}