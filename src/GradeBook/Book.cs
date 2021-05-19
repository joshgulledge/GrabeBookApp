using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Stats GetStats();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject
    {
        protected Book(string name) : base(name)
        {
        }
        public abstract Stats GetStats();

        public abstract void AddGrade(double grade);

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

    public class InMemoryBook : Book, IBook
    {
        // after the : the first is a parent class and any more are interfaces
        public event GradeAddedDelegate GradeAdded;

        private List<double> GradeList;

        // references the constructor of the parent class, uses the same name arg
        public InMemoryBook(string name) : base(name) 
        {
             GradeList = new List<double>();
             Name = name;
        }

        // this overrides the inherited method from bookbase
        public override void AddGrade (double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                GradeList.Add(grade);

                if(GradeAdded != null)
                {
                    // the sender is the object that is being used
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override Stats GetStats ()
        {
            Stats result = new Stats();
            result.CalculateStats(GradeList);

            AddLetterGrade(result);

            return result;
        }

    }
        public class DiskBook : Book, IBook
        {
            private List<double> GradeList;

            public DiskBook(string name) : base(name)
            {
                GradeList = new List<double>();
                Name = name;
            }
            public event GradeAddedDelegate GradeAdded;

            public override Stats GetStats()
            {
                Stats result = new Stats();
                
                using(var reader = File.OpenText($"{Name}.txt"))
                {
                    var line = reader.ReadLine();

                    while(line != null)
                    {
                        double number = double.Parse(line);
                        GradeList.Add(number);
                        line = reader.ReadLine();
                    }
                }

                result.CalculateStats(GradeList);

                AddLetterGrade(result);

                return result;
            }

            public override void AddGrade(double grade)
            {
                // doing the code like this allows us to close and dispose of the object when we are done with it
                using (StreamWriter AddText = File.AppendText($"{Name}.text"))
                {
                    AddText.WriteLine(grade);
                    
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }

            }

        }
}
