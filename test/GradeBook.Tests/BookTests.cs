using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculateStats()
        {
            var book = new Book("");

            //do the stuff
            var result = book.GetStats();

            //test the stuff
            Assert.Equal(90.5, result.high, 1);
            Assert.Equal(77.3, result.low, 1);
            Assert.Equal(85.6, result.average, 1); // one decimal place
            Assert.Equal('B', result.letter);

 
        }

        
    }
}
