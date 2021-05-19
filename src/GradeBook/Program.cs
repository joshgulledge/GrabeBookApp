using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Josh's GradeBook");
            book.GradeAdded += OnGradeAdded;  // uses the delegate
            

            // book.GetGrades();
            book.AddGrade(25.1);
            book.AddGrade(95.5);
            book.AddGrade(87.5);
            var stats = book.GetStats();
            Console.WriteLine($"For {book.Name}");
            Console.WriteLine($"The Average of all the grades is {stats.average}");
            Console.WriteLine($"The Highest of all the grades is {stats.high}");
            Console.WriteLine($"The Lowest of all the grades is {stats.low}");
            Console.WriteLine($"The Letter is {stats.letter}");

        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }

    }
}
