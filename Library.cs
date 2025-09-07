using System;
using System.Collections.Generic;

namespace Windows
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Library library = new Library();
            library.Run(library);
        }
    }

    class Book
    {
        public Book(string nameBook, string author, int years)
        {
            _nameBook = nameBook;
            _author = author;
            _years = years;
        }

        public string _nameBook { get; private set; }
        public string _author { get; private set; }
        public int _years { get; private set; }
    }

    class Library
    {
        private const string ShowAllBookCommand = "1";
        private const string AddBooksCommand = "2";
        private const string SearchByNameCommand = "3";
        private const string SearchByAuthorCommand = "4";
        private const string PutBookBackCommand = "5";
        private const string ExitCommand = "6";

        private bool _isOpen = true;
        private List<Book> Books = new List<Book>();

        private void ShowAllBook()
        {
            Console.WriteLine("СПИСОК ВСЕХ КНИГ В НАЛИЧИИ\n\n");
            Books.Add(new Book("Капитанская дочка", "А.С Пушкин", 1836));
            Books.Add(new Book("Унесенные Ветром", "Маргарет Митчелл", 1936));
            Books.Add(new Book("Скотный Двор", "Джордж Оруэлл", 1945));
            Books.Add(new Book("Макбет", "Уильям Шекспир", 1623));
            Books.Add(new Book("12 Стульев", "Илья Ильф и Евгений Петров", 1927));
            Books.Add(new Book("Анна Каренина", "Л.Н Толстой", 1836));

            foreach (var books in Books)
            {
                Console.WriteLine($"Название книги:{books._nameBook}--|Год выпуска:{books._years}--|Автор:{books._author}\n");
            }
        }

        private void AddBooks()
        {
            Console.WriteLine("Для добавления книги в библиотеку следуйте инструкции");

            Console.WriteLine("Впишите +Название+");
            string bookName = Console.ReadLine();
            Console.WriteLine("Впишите +Автора книги+");
            string authorName = Console.ReadLine();
            Console.WriteLine("Укажите +Год издания+");
            int yearsBook = int.Parse(Console.ReadLine());

            Books.Add(new Book(bookName, authorName, yearsBook));
        }

        private void SearchByName()
        {
            Console.WriteLine("Введите название интересующей книги:");

            string name = Console.ReadLine();

            foreach (Book book in Books)
            {
                if (book._nameBook.Equals(name))
                {
                    name = book._nameBook;
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
                if (book._author.Equals(author))
                {
                    author = book._author;

                    Console.WriteLine($"{author}");
                }
            }
        }

        private void PutBookBack()
        {
            Console.WriteLine("Для возврата книги напишите ее название");

            string choiceBookForRemove = Console.ReadLine();

            Book bookToRemove = null;

            foreach (Book book in Books)
            {
                if (book._nameBook.Equals(choiceBookForRemove))
                {
                    bookToRemove = book;
                    break;
                }
            }

            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
                Console.WriteLine($"Книга {bookToRemove._nameBook} успешно возвращена!");
            }
            else
            {
                Console.WriteLine("Такой книги нет.");
            }
        }

        public void Run(Library library)
        {


            while (_isOpen)
            {
                Console.WriteLine("Добро пожаловать в библиотеку!\n Отправьте  в строку номер команды");
                Console.WriteLine($"Команды Меню:\n{ShowAllBookCommand})Показать все книги\n{AddBooksCommand})Добавить книгу\n{SearchByNameCommand})Поиск по названию\n{SearchByAuthorCommand})Поиск по автору\n{PutBookBackCommand})Отдать книгу\n{ExitCommand})Выход.");

                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case ShowAllBookCommand:
                        library.ShowAllBook();
                        break;
                    case AddBooksCommand:
                        library.AddBooks();
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
