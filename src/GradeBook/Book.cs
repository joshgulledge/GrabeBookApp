using System;
using System.Collections.Generic;


namespace GradeBook
{
    public class Book
    {

        private List<double> GradeList;
        // public string Name
        // {
        //     get
        //     {
        //         return _name;
        //     }
        //     set
        //     {
        //         _name = value; // available in the setter, incoming value
        //     }
        // }
        public string Name
        {
            get; set;
        }


        public Book(string name)
        {
             GradeList = new List<double>();
             Name = name;
        }

        public void AddGrade (double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                GradeList.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }



        public Stats GetStats ()
        {
            Stats result = new Stats();
            result.average = 0.0;
            result.high = double.MinValue;
            result.low = double.MaxValue;
            result.letter = 'U';

            // foreach (double grade in GradeList)
            // {
            //     // if (grade > highGrade)
            //     // {
            //     //     highGrade = grade;
            //     // }
            //         result.high = Math.Max(grade, result.high);
            //         result.low = Math.Min(grade, result.low);
            //         result.average += grade;
            // }

            // int index = 0;
            // do
            // {
            //     result.high = Math.Max(GradeList[index], result.high);
            //     result.low = Math.Min(GradeList[index], result.low);
            //     result.average += GradeList[index];
            //     index++;
            // } while (index < GradeList.Count);

            // int index = 0;
            // while (index < GradeList.Count)
            // {
            //     result.high = Math.Max(GradeList[index], result.high);
            //     result.low = Math.Min(GradeList[index], result.low);
            //     result.average += GradeList[index];
            //     index++;   
            // }

            for (int index = 0; index < GradeList.Count; index++)
            {
                result.high = Math.Max(GradeList[index], result.high);
                result.low = Math.Min(GradeList[index], result.low);
                result.average += GradeList[index];
            }

            result.average /= GradeList.Count;

            AddLetterGrade(result);

            return result;
        }

        public void GetGrades()
        {

            while(true)
            {
                Console.WriteLine("Please enter the grade, press Q to quit");
                string input = Console.ReadLine();

                if(input == "Q" || input == "q")
                {
                    break;
                }

                try
                {
                    AddGrade(double.Parse(input));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }

        public void AddLetterGrade (Stats stats)
        {
            switch (stats.average)
            {
                case var x when x >= 90.0:
                    stats.letter = 'A';
                    break;
                case var x when x >= 80.0:
                    stats.letter = 'B';
                    break;
                case var x when x >= 70.0:
                    stats.letter = 'C';
                    break;
                case var x when x >= 60.0:
                    stats.letter = 'D';
                    break;
                default:
                    stats.letter = 'F';
                    break;
            }

        }

    
    }
}