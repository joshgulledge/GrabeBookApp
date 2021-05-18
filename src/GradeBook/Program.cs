using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Josh's GradeBook");
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);
            // double[] numbers = new double[3];
            // numbers[0] = 12.7;
            // numbers[1] = 23.6;
            // numbers[2] = 48.89;
            // double[] numbers = new[] {12.7, 23.6, 48.89};

            book.GetGrades();
            var stats = book.GetStats();
            Console.WriteLine($"For {book.Name}");
            Console.WriteLine($"The Average of all the grades is {stats.average}");
            Console.WriteLine($"The Highest of all the grades is {stats.high}");
            Console.WriteLine($"The Lowest of all the grades is {stats.low}");
            Console.WriteLine($"The Letter is {stats.letter}");

        }

    }
}
