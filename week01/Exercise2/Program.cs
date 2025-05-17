using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade porcentage?");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        //pass or fail 
        if (grade >= 70)
        {
            Console.WriteLine($"Congratulation you passed the with {letter} the curse");
        }
        else
        {
            Console.WriteLine($"Sorry, you have not been able to pass you got {letter}, try harder for the next one.");  
        }

    }
}