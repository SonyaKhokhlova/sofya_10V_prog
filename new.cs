using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2811
{
    internal class Program
    {
        public class Author
        {
            public string Name { get; set; }
        }
        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public Author Author { get; set; }

            public Book(int id, string title, Author author)
            {
                Id = id;
                Title = title;
                Author = author;
            }

            public static explicit operator int(Book book)
            {
                return book.Id;
            }

            public static explicit operator string(Book book)
            {
                return book.Title;
            }

            public static implicit operator string(Book book)
            {
                return $"Name = {book.Author.Name}"; //Я не совсем понимаю, как это реализовать
            }
        }
            static void Main(string[] args)
        {
            Author a1 = new Author();
            string name = a1.Name;
            Book b1 = new Book(30, "Poems", a1);
            Console.WriteLine((int)b1);
            Console.WriteLine((string)b1);
            Author q = b1;
            Console.WriteLine(q);
        }
    }
}
