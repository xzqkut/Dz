using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.Work();
        }
    }

    class Shop
    {
        private Salesman _salesman;
        private Buyer _buyer;


        public Shop()
        {
            _salesman = new Salesman(0);
            _buyer = new Buyer(1000);
        }

        public void Work()
        {
            const string ShowAllProductsCommand = "1";
            const string TradeCommand = "2";
            const string ShowCartProtuctsCommand= "3";
            const string ExitCommand = "4";

            Shop shop = new Shop();

            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("\nПриветствуем в магазине!\n");
                Console.WriteLine($"Команды магазина:\n{ShowAllProductsCommand}Показать все продукты.\n{TradeCommand}Покупка\n{ShowCartProtuctsCommand}Посмотреть тележку с приобритеным\n{ExitCommand}Выход");
                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case ShowAllProductsCommand:
                        _salesman.ShowProducts();
                        break;
                    case TradeCommand:
                        Trade();
                        break;
                    case ShowCartProtuctsCommand:
                        _buyer.ShowCart();
                        break;
                    case ExitCommand:
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод!");
                        break;
                }
            }
        }

        public void Trade()
        {
            if (_salesman.TryGetProduct(out Product products))
            {
                if (_buyer.Money >= products.Price)
                {
                    if (_buyer.SpendMoney(products.Price))
                    {
                        _buyer.BuyProduct(products);
                        Console.WriteLine($"Товар {products.Name} успешно куплен!");
                        _salesman.SellProduct(products);
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно денег");
                    }
                }
            }
        }
    }

    class Trader
    {
        protected List<Product> Products;

        public Trader(int money)
        {
            Money = money;
            Products = new List<Product>();
        }

        public int Money { get; protected set; }

        public void ShowProducts()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}{Products[i].Name},цена {Products[i].Price}");
            }
        }

        public bool TryGetProduct(out Product product)
        {
            ShowProducts();

            Console.WriteLine("Введите номер товара.");
            string choice = Console.ReadLine();


            if (int.TryParse(choice, out int number) == true)
            {
                int index = number - 1;
                if (index >= 0 && index < Products.Count)
                {
                    product = Products[index];
                    return true;
                }
            }

            Console.WriteLine("Ошибка");
            product = null;
            return false;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
        }

        public bool SpendMoney(int amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                return true;
            }
            return false;
        }
    }

    class Buyer : Trader
    {
        public Buyer(int money) : base(money)
        {
            Money = money;
        }

        public void BuyProduct(Product product)
        {
            Products.Add(product);
        }

        public void ShowCart()
        {
            Console.WriteLine("\nКорзина");

            if (Products.Count == 0)
            {
                Console.WriteLine("Корзина пуста");
            }
            else
            {
                foreach (var product in Products)
                {
                    Console.WriteLine($"{product.Name} - {product.Price}");
                }
            }
            Console.WriteLine($"Остаток денег {Money}\n");
        }
    }

    class Salesman : Trader
    {
        public Salesman(int moneyEarned) : base(moneyEarned)
        {
            Products.Add(new Product("Апельсин", 40));
            Products.Add(new Product("Молоко", 100));
            Products.Add(new Product("Батон", 30));
            Products.Add(new Product("Сосиски", 250));
            Products.Add(new Product("Мармеладки", 100));
            Products.Add(new Product("Мороженное", 120));
            Products.Add(new Product("Вода", 58));

        }

        public int ProductsCount => Products.Count;

        public void SellProduct(Product product)
        {
            Money += product.Price;

            Products.Remove(product);
        }
    }

    class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }
    }
}
