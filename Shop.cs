using System;
using System.Collections.Generic;

namespace Magazin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Market market = new Market();
            market.Work();
            Console.ReadLine();
        }
    }

    class Person
    {
        protected List<Product> Products;

        public Person(int wallet)
        {
            Wallet = wallet;
            Products = new List<Product>();
        }

        public int ProductsCount => Products.Count;

        public int Wallet { get; protected set; }

        public void AddMoney(int amount)
        {
            Wallet += amount;
        }

        public bool TrySpendMoney(int amount)
        {
            if (Wallet >= amount)
            {
                Wallet -= amount;
                return true;
            }
            return false;
        }
    }

    class Market
    {
        private const string YesCommand = "да";
        private const string ShowVendorProductsCommand = "1";
        private const string BuyProductCommand = "2";
        private const string ShowClientCartCommand = "3";
        private const string ShowVendorInfoCommand = "4";
        private const string ShowClientInfoCommand = "5";
        private const string ExitCommand = "6";

        private Vendor _vendor;
        private Client _client;
        
        public Market()
        {
            _vendor = new Vendor(0);
            _client = new Client(1500);
        }

        public void Work()
        {
            bool _isOpen=true;

            Console.Clear();

            ShowMenu();

            while (_isOpen)
            {
                string choise = Console.ReadLine();

                switch (choise)
                {
                    case ShowVendorProductsCommand:
                        ShowVendorProducts();
                        break;
                    case BuyProductCommand:
                        ProcessPurchase();
                        break;
                    case ShowClientCartCommand:
                        ShowClientCart();
                        break;
                    case ShowVendorInfoCommand:
                        ShowVendorInfo();
                        break;
                    case ShowClientInfoCommand:
                        ShowClientInfo();
                        break;
                    case ExitCommand:
                        Console.WriteLine("Досвидания! Будем вас ждать");
                        _isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ProcessPurchase()
        {
            Console.Clear();
            Console.WriteLine("=== ПОКУПКА ТОВАРА ===");

            _vendor.ShowProducts();
 
            if(!_vendor.TryGetSelectedProduct(out Product product))
            {
                WaitForContinue();
                return;
            }

            Console.WriteLine($"\nВы выбрали {product.Name} за {product.Price}");
            Console.WriteLine("Вы хотите его приобрести?(да/нет)");

            string answer = Console.ReadLine().ToLower();

            if( answer == YesCommand)
            {
                if (_client.TryBuyProduct(product))
                {
                    _vendor.AddMoney(product.Price);
                    _vendor.SellProduct(product);
                    _client.TrySpendMoney(product.Price);

                    Console.WriteLine($"Товар {product.Name} куплен!");
                    Console.WriteLine($"У покупателя осталось: {_client.Wallet}");
                }
            }
            WaitForContinue();
        } 

        private void WaitForContinue()
        {
            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
            ShowMenu();
        }

        private void ShowVendorProducts()
        {
            Console.Clear();
            Console.WriteLine("++Товары в магазине++");

            _vendor.ShowProducts();
            WaitForContinue();
        }

        private void ShowMenu( string showVendorProductsCommand=ShowVendorProductsCommand,
            string buyProductCommand=BuyProductCommand,
            string showClientCartCommand=ShowClientCartCommand,
            string showVendorInfoCommand=ShowVendorInfoCommand, 
            string showClientInfoCommand=ShowClientInfoCommand
            , string exitCommand=ExitCommand)
        {
            Console.WriteLine("=== МАГАЗИН ===");
            Console.WriteLine($"{showVendorProductsCommand} Показать товары");
            Console.WriteLine($"{buyProductCommand} Купить товар");
            Console.WriteLine($"{showClientCartCommand} Показать корзину покупателя");
            Console.WriteLine($"{showVendorInfoCommand} Информация о продавце");
            Console.WriteLine($"{showClientInfoCommand} Информация о покупателе");
            Console.WriteLine($"{exitCommand} Выйти");
            Console.Write("Выберите действие: ");
        }

        private void ShowClientInfo()
        {
            Console.Clear();
            Console.WriteLine("=== ИНФОРМАЦИЯ О ПОКУПАТЕЛЕ ===");
            Console.WriteLine($"Денег у покупателя: {_client.Wallet}");
            Console.WriteLine($"Товаров в корзине: {_client.ProductsCount}");

            if (_client.ProductsCount > 0)
            {
                Console.WriteLine("У клиента в корзине:");
                _client.ShowCart();

            }

            ShowMenu();
        }

        private void ShowVendorInfo()
        {
            Console.Clear();
            Console.WriteLine("=== ИНФОРМАЦИЯ О ПРОДАВЦЕ ===");
            Console.WriteLine($"Денег у продавца: {_vendor.Wallet}");
            Console.WriteLine($"Товаров в продаже: {_vendor.ProductsCount}");

            if (_vendor.ProductsCount > 0)
            {
                Console.WriteLine("\nОстались в продаже:");
                _vendor.ShowProducts();
            }

            WaitForContinue();
        }
        private void ShowClientCart()
        {
            Console.Clear();
            Console.WriteLine("=== КОРЗИНА ПОКУПАТЕЛЯ ===");
            _client.ShowCart();
            WaitForContinue();
        }
    }

    class Vendor : Person
    {
        public Vendor(int wallet) : base(wallet)
        {
            Products.Add(new Product("Молоко", 100));
            Products.Add(new Product("Хлеб", 40));
            Products.Add(new Product("Конфеты", 150));
            Products.Add(new Product("Помидоры", 150));
            Products.Add(new Product("Апельсин", 100));
            Products.Add(new Product("Огурец", 20));
            Products.Add(new Product("Кетчуп", 120));
            Products.Add(new Product("Соль", 30));
            Products.Add(new Product("Сахар", 50));
        }

        public bool TryGetSelectedProduct(out Product product)
        {
            product = null;

            Console.WriteLine($"Выбероите номер товара 1){Products.Count}");

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Вы ничего не выбрали");
                return false;
            }

            if (!int.TryParse(input, out int numberChoice))
            {
                Console.WriteLine("Неверный формат числа");
                return false;
            }

            if (numberChoice < 1 || numberChoice >Products.Count)
            {
                Console.WriteLine($"Число должно быть от 1 до {Products.Count}");
                return false;
            }

            int index = numberChoice - 1;
            product = GetProductInfo(index);

            if (product == null)
            {
                Console.WriteLine("Товар не найден");
                return false;
            }

            return true;
        }

        public void ShowProducts()
        {
            for (int i = 0; Products.Count > i; i++)
            {
                Product product = Products[i];
                Console.WriteLine($"{i + 1}.Товар {product.Name} цена:{product.Price}");
            }
        }

        public Product GetProductInfo(int index)
        {
            if (index >= 0 && index < Products.Count)
            {
                return Products[index];
            }
            return null;
        }

        public void SellProduct(Product product)
        {
            if (Products.Remove(product) == false)
            {
                Console.WriteLine("Товар не найден");
            }
        }

    }

    class Client : Person
    {
        public Client(int wallet) : base(wallet) { }

        public bool CanBuy(Product product)
        {
            if (product == null)
            {
                Console.WriteLine("Товар не существует!");
                return false;
            }

            bool canAfford = Wallet >= product.Price;

            if (canAfford==false)
            {
                Console.WriteLine($"Не хватает {product.Price - Wallet} денег!");
            }
            return canAfford;
        }

        public bool TryBuyProduct(Product product)
        {
            if (CanBuy(product))
            {
                TrySpendMoney(product.Price);
                Products.Add(product);

                Console.WriteLine($"Товар {product.Name} - куплен!");

                return true;
            }
            return false;
        }

        public void ShowCart()
        {
            Console.WriteLine("==Корзина ПОКУПАТЕЛЯ==");

            if (Products.Count == 0)
            {
                Console.WriteLine("Корзина пуста в данный момент, вперед за покупками!");
            }
            else
            {
                foreach (var product in Products)
                {
                    Console.WriteLine($"{product.Name} - {product.Price}");
                }

                Console.WriteLine($"Остаток денег: {Wallet}");
            }
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
