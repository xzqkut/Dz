using System;
using System.Collections.Generic;

namespace Windows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;

           Library library = new Library();
            
            while (isOpen)
            {
                Console.WriteLine("Добро пожаловать в библиотеку!\n Отправьте  в строку номер команды");
                Console.WriteLine($"Команды Меню:\n1)Показать все книги\n2)Добавить книгу\n3)Поиск по названию\n4)Поиск по автору\n5)Отдать книгу\n6)Выход.");

                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        library.ShowAllBook();
                        break;
                    case "2":
                        library.AddBooks();
                        break;
                    case "3":
                        string bookName = Console.ReadLine();
                        library.SearchByName(bookName);
                        break;
                    case "4":
                       string author = Console.ReadLine();
                        library.SearchByAuthor(author);
                        break;
                    case "5":
                        library.PutBookBack();
                        break;
                    case "6":
                        isOpen= false;
                        break;
                    default:
                        Console.WriteLine("Нет такого действия");
                        break;
                }
            }
        }
    }

    class Book
    {
        public string NameBook { get; private set; }
        public string Author { get; private set; }
        public int Years { get; private set; }

        public Book(string nameBook, string author, int years)
        {
            NameBook = nameBook;
            Author = author;
            Years = years;
        }
    }

    class Library
    {
        public List<Book> Books = new List<Book>();

        public void ShowAllBook()
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
                Console.WriteLine($"Название книги:{books.NameBook}--|Год выпуска:{books.Years}--|Автор:{books.Author}\n");
            }

        }

        public void AddBooks()
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

        public void SearchByName(string name)
        {
            Console.WriteLine("Введите название интересующей книги:");

            name = Console.ReadLine();

            foreach (Book book in Books)
            {
                if (book.NameBook.Equals(name))
                {
                    name = book.NameBook;
                    Console.WriteLine($"Книга с таким названием есть.\n{name}");
                }
                else
                {
                    Console.WriteLine("Книга с таким названием отсутствует");
                }
            }
        }

        public void SearchByAuthor(string author)
        {
            Console.WriteLine("#Поиск книги по автору#\nВведите имя автора");

            author = Console.ReadLine();

            foreach (Book book in Books)
            {
                if (book.Author.Equals(author))
                {
                    author = book.Author;

                    Console.WriteLine($"{author}");
                }
            }
        }

        public void PutBookBack()
        {
            Console.WriteLine("Для возврата книги напишите ее название");

            string choiceBookForRemove = Console.ReadLine();

            Book bookToRemove = null;

            foreach (Book book in Books)
            {
                if (book.NameBook.Equals(choiceBookForRemove))
                {
                    bookToRemove = book;
                    break;
                } 
            }

            if(bookToRemove!= null)
            {
                Books.Remove(bookToRemove);
                Console.WriteLine($"Книга {bookToRemove.NameBook} успешно возвращена!");
            }
            else
            {
                Console.WriteLine("Такой книги нет.");
            }
        }
    }
}
