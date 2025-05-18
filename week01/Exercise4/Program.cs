using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");// this show and I  writte on A
        int question = -1;
        while (question != 0)
        {
            Console.Write("Enter number: "); // this is A and this will be the line to writte 
            string input = Console.ReadLine();
            question = int.Parse(input);

            // this will help to add the numbers on the list 
            if (question != 0)
            {
                numbers.Add(question);
            }

        }

        int sum = 0;

        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");

        double average = numbers.Count > 0 ? numbers.Average() : 0.0;
        Console.WriteLine($"The average is:{average}");

        int maxnumber = numbers.Max();
        Console.WriteLine($"The Largest number is: {maxnumber}");
    }
}