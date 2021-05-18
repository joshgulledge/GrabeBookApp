using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelete(string logMessage);

    public class NewBaseType
    {

        [Fact]
        public void WriteLogDeletePointToMethod()
        {
            WriteLogDelete log;

            // log = ReturnMessage
            log = new WriteLogDelete(ReturnMessage);
            // call the delegate and pass in the method you want to use with it
            // the method passed in needs to have a same looking args

            var result = log("Hello World");
            Assert.Equal("Hello World", result);
        }

        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            setInt(ref x);

            Assert.Equal(42, x);
        }

        private void setInt(ref int z)
        {
            z=42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void PassByRef()
        {
            var book1 = GetBook("My Book");
            changeRefName(ref book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
        }

        private void changeRefName(ref InMemoryBook book, string newName)
        {
            book = new InMemoryBook(newName);
        }

        [Fact]
        public void PassByValue()
        {
            var book1 = GetBook("My Book");
            GetBookSetName(book1, "New Name");
            
            Assert.Equal("My Book", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string newName)
        {
            book = new InMemoryBook(newName);
        }

        // [Fact]
        // public void changeName()
        // {
        //     var book1 = GetBook("My Book");
        //     SetName(book1, "New Name");
            
        //     Assert.Equal("New Name", book1.Name);
        // }

        // private void SetName(Book book, string newName)
        // {
        //     book.Name = newName;
        // }

        [Fact]
        public void GetBookReturnsDifferentObj()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);

        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

        [Fact]
        public void TwoVarsReferenceSameObject()
        {
            var book3 = GetBook("Book 3");
            var book4 = book3;

            var nameOne = book3.Name;
            var nameTwo = book4.Name;

            // Assert.Equal("Book 3", book3.Name);
            // Assert.Equal("Book 3", book3.Name);

            Assert.Same(book3, book4);
            Assert.True(Object.ReferenceEquals(book3, book4));
        }
    }

}
