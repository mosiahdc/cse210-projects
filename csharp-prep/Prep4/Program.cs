using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int inputNumber = -1;

        while (inputNumber != 0)
        {
            Console.Write("Enter number: ");
            inputNumber = int.Parse(Console.ReadLine());

            if (inputNumber != 0)
            {
                numbers.Add(inputNumber);
            }
        }

        int sum = 0;
        int max = numbers[0];

        foreach (int number in numbers)
        {
            sum += number;

            if (number > max)
            {
                max = number;
            }
        }

        float average = (float)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}