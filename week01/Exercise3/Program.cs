using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1, 100);

        int response = 0;

        while (response != magic_number)
        {
            Console.Write("What is the magic number?");
            response = int.Parse(Console.ReadLine());

            if (magic_number > response)
            {
                Console.WriteLine("Higher");
            }
            else if (magic_number < response)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You got it the number is {magic_number}!!");
            }
        }



    }
}