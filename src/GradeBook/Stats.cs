using System;
using System.Collections.Generic;


namespace GradeBook
{
    public class Stats
    {
        public double average;
        public double low;
        public double high;
        public char letter;

         // constructor
         public Stats()
         {
            average = 0.0;
            low = double.MaxValue;
            high = double.MinValue;
            letter = 'U';

         }

         public void CalculateStats(List<double> GradeList)
         {
             for (int index = 0; index < GradeList.Count; index++)
            {
               high = Math.Max(GradeList[index],high);
               low = Math.Min(GradeList[index],low);
               average += GradeList[index];
            }

           average /= GradeList.Count;
         }
    }
}