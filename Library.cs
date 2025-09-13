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
        public Library()
        {
            Books.Add(new Book("Капитанская дочка", "А.С Пушкин", 1836));
            Books.Add(new Book("Унесенные Ветром", "Маргарет Митчелл", 1936));
            Books.Add(new Book("Скотный Двор", "Джордж Оруэлл", 1945));
            Books.Add(new Book("Макбет", "Уильям Шекспир", 1623));
            Books.Add(new Book("12 Стульев", "Илья Ильф и Евгений Петров", 1927));
            Books.Add(new Book("Анна Каренина", "Л.Н Толстой", 1836));
        }

        private bool _isOpen = true;
        private List<Book> Books = new List<Book>();

        private void ShowAllBook()
        {
            Console.WriteLine("СПИСОК ВСЕХ КНИГ В НАЛИЧИИ\n\n");
            
            for(int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine($"№{i+1}##Название книги:{Books[i]._nameBook}##Автор:{Books[i]._author}##Год издания:{Books[i]._years}");
                Console.WriteLine();
            }
        }

        private void AddBook()
        {
            Console.WriteLine("Для добавления книги в библиотеку следуйте инструкции");

            Console.WriteLine("Впишите +Название+");
            string bookName = Console.ReadLine();

            Console.WriteLine("Впишите +Автора книги+");
            string authorName = Console.ReadLine();

            Console.WriteLine("Укажите +Год издания+");
            int yearsBook = Convert.ToInt32(Console.ReadLine());

            if (yearsBook <= 0&&string.IsNullOrWhiteSpace(bookName)&&string.IsNullOrWhiteSpace(authorName))
            {
                Console.WriteLine("Некорректный ввод");
            }
            else
            {
                Books.Add(new Book(bookName, authorName, yearsBook));
            }
        }

        private void SearchByName()
        {
            Console.WriteLine("Введите название интересующей книги:");

            string name = Console.ReadLine();

            foreach (Book book in Books)
            {
                if (book._nameBook.Equals(name))
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
                if (book._author.Equals(author))
                {
                    author = book._author;

                    Console.WriteLine($"{author} его книги {book._nameBook}");
                }
            }
        }

        private void PutBookBack(Library library)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine($"№{i + 1}##Название книги:{Books[i]._nameBook}##Автор:{Books[i]._author}##Год издания:{Books[i]._years} ");
                Console.WriteLine();
            }
            Console.WriteLine(new string( '=',100));

            int value = Convert.ToInt32(Console.ReadLine())-1;

            for(int i = 0;i < Books.Count;i++)
            {
                if (i==value)
                {
                    var removedBook = Books[i];
                    Books.RemoveAt(i);
                    Console.WriteLine($"Книга {removedBook._nameBook} была удалена");
                    break;
                }
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
                        library.PutBookBack(library);
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
