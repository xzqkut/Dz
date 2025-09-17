using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Windows
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Library library = new Library();
            library.Run();
        }
    }

    class Book
    {
        public Book(string nameBook, string author, int years)
        {
            NameBook = nameBook;
            Author = author;
            Years = years;
        }

        public string NameBook { get; private set; }
        public string Author { get; private set; }
        public int Years { get; private set; }
    }

    class Library
    {
        private bool _isOpen = true;
        private List<Book> Books = new List<Book>();

        public Library()
        {
            Books.Add(new Book("Капитанская дочка", "А.С Пушкин", 1836));
            Books.Add(new Book("Унесенные Ветром", "Маргарет Митчелл", 1936));
            Books.Add(new Book("Скотный Двор", "Джордж Оруэлл", 1945));
            Books.Add(new Book("Макбет", "Уильям Шекспир", 1623));
            Books.Add(new Book("12 Стульев", "Илья Ильф и Евгений Петров", 1927));
            Books.Add(new Book("Анна Каренина", "Л.Н Толстой", 1836));
        }

        private void ShowAllBook()
        {
            Console.WriteLine("СПИСОК ВСЕХ КНИГ В НАЛИЧИИ\n\n");

            PrintBooks();
        }

        private void AddBook()
        {
            Console.WriteLine("Для добавления книги в библиотеку следуйте инструкции");

            Console.WriteLine("Впишите +Название+");
            string bookName = Console.ReadLine();

            Console.WriteLine("Впишите +Автора книги+");
            string authorName = Console.ReadLine();

            Console.WriteLine("Укажите +Год издания+");

            if (int.TryParse(Console.ReadLine(), out int yearsBook) && yearsBook > 0)
            {
                Books.Add(new Book(bookName, authorName, yearsBook));
            }
            else
            {
                Console.WriteLine("Некоректный ввод");
            }
        }

        private void SearchByName()
        {
            Console.WriteLine("Введите название интересующей книги:");

            string name = Console.ReadLine();

            foreach (Book book in Books)
            {
                if (book.NameBook.Equals(name))
                {
                    Console.WriteLine($"Книга с таким названием есть.\n{name}");
                }
                else
                {
                    Console.WriteLine("Книга с таким названием отсутствует");
                }
            }
        }

        private void SearchByAuthor()
        {
            Console.WriteLine("#Поиск книги по автору#\nВведите имя автора");

            string author = Console.ReadLine();

            foreach (Book book in Books)
            {
                if (book.Author.Equals(author))
                {
                    author = book.Author;

                    Console.WriteLine($"{author} его книги {book.NameBook}");
                }
            }
        }

        private void PutBookBack()
        {
            PrintBooks();

            Console.WriteLine(new string('=', 100));

            int value = Convert.ToInt32(Console.ReadLine()) - 1;

            if (value >= 0 && value < Books.Count)
            {
                var removedBook = Books[value];
                Books.RemoveAt(value);
                Console.WriteLine($"Книга {removedBook.NameBook} была удалена");
            }
            else
            {
                Console.WriteLine("Некорректный номер.");
            }
        }

        public void PrintBooks()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                var books = Books[i];
                Console.WriteLine($"№{i + 1}##Название книги:{books.NameBook}##Автор:{books.Author}##Год издания:{books.Years} ");
                Console.WriteLine();
            }
        }

        public void Run()
        {
            const string ShowAllBookCommand = "1";
            const string AddBooksCommand = "2";
            const string SearchByNameCommand = "3";
            const string SearchByAuthorCommand = "4";
            const string PutBookBackCommand = "5";
            const string ExitCommand = "6";

            Library library = new Library();

            while (_isOpen)
            {
                Console.WriteLine("Добро пожаловать в библиотеку!\nОтправьте  в строку номер команды");
                Console.WriteLine($"Команды Меню:\n{ShowAllBookCommand})Показать все книги\n{AddBooksCommand})Добавить книгу\n{SearchByNameCommand})Поиск по названию\n{SearchByAuthorCommand})Поиск по автору\n{PutBookBackCommand})Отдать книгу\n{ExitCommand})Выход.");

                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case ShowAllBookCommand:
                        library.ShowAllBook();
                        break;

                    case AddBooksCommand:
                        library.AddBook();
                        break;

                    case SearchByNameCommand:
                        library.SearchByName();
                        break;

                    case SearchByAuthorCommand:
                        library.SearchByAuthor();
                        break;

                    case PutBookBackCommand:
                        library.PutBookBack();
                        break;

                    case ExitCommand:
                        _isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Нет такого действия");
                        break;
                }
            }
        }
    }
}
