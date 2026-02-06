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

        public bool CanAfford(int amount)
        {
            return Wallet >= amount;
        }

        public void AddMoney(int amount)
        {
            Wallet += amount;
        }

        public bool SpendMoney(int amount)
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
        private Vendor _vendor;
        private Client _client;
        private bool _isRunning;

        public Market()
        {
            _vendor = new Vendor(0);
            _client = new Client(1500);
            _isRunning = true;
        }

        public void Work()
        {
            Console.Clear();
            ShowMenu();
            while (_isRunning)
            {
                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        ShowProducts();
                        break;
                    case "2":
                        BuyProduct();
                        break;
                    case "3":
                        ShowClientCart();
                        break;
                    case "4":
                        ShowVendorInfo();
                        break;
                    case "5":
                        ShowClientOnfo();
                        break;
                    case "6":
                        Console.WriteLine("Досвидания! Будем вас ждать");
                        _isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        private void BuyProduct()
        {
            Console.Clear();
            Console.WriteLine("=== ПОКУПКА ТОВАРА ===");

            _vendor.ShowProducts();

            if (!TryGetSelectedProduct(out Product product, out int index))
            {
                WaitForContinue();
                return;
            }

            Console.WriteLine($"\nВы выбрали: {product.Name} за {product.Price}");
            Console.Write("Хотите купить? (да/нет): ");

            string answer = Console.ReadLine().ToLower();
            if (answer != "да")
            {
                Console.WriteLine("Покупка отменена.");
                WaitForContinue();
                return;
            }

            if (_client.TryBuyProduct(product))
            {
                _vendor.AddMoney(product.Price);

                Product soldProduct = _vendor.SellProduct(index);

                if (soldProduct != null)
                {
                    Console.WriteLine($"\nТовар {product.Name} успешно куплен!");

                    Console.WriteLine($"\nПродавец получил: {product.Price}");
                    Console.WriteLine($"У покупателя осталось: {_client.Wallet}");
                }
            }
            else
            {
                Console.WriteLine("Не удалось купить товар.");
            }

            WaitForContinue();
        }

        private bool TryGetSelectedProduct(out Product product, out int index)
        {
            product = null;
            index = -1;

            Console.WriteLine($"Выбероите номер товара 1){_vendor.ProductsCount}");

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

            if (numberChoice < 1 || numberChoice > _vendor.ProductsCount)
            {
                Console.WriteLine($"Число должно быть от 1 до {_vendor.ProductsCount}");
                return false;
            }

            index = numberChoice - 1;
            product = _vendor.GetProductInfo(index);

            if (product == null)
            {
                Console.WriteLine("Товар не найден");
                return false;
            }

            return true;
        }

        private void WaitForContinue()
        {
            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
            ShowMenu();
        }

        private void ShowProducts()
        {
            Console.Clear();
            Console.WriteLine("++Товары в магазине++");
            _vendor.ShowProducts();
            WaitForContinue();
        }

        private void ShowMenu()
        {
            Console.WriteLine("=== МАГАЗИН ===");
            Console.WriteLine("1. Показать товары");
            Console.WriteLine("2. Купить товар");
            Console.WriteLine("3. Показать корзину покупателя");
            Console.WriteLine("4. Информация о продавце");
            Console.WriteLine("5. Информация о покупателе");
            Console.WriteLine("6. Выйти");
            Console.Write("Выберите действие: ");
        }

        private void ShowClientOnfo()
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

        public void ShowProducts()
        {
            for (int i = 0; Products.Count > i; i++)
            {
                Console.WriteLine($"{i + 1}.Товар {Products[i].Name} цена:{Products[i].Price}");
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

        public Product SellProduct(int index)
        {
            if (index >= 0 && index < Products.Count)
            {
                Product productToSell = Products[index];
                Products.RemoveAt(index);

                return productToSell;
            }
            else
            {
                Console.WriteLine("Товара с таким индексом не существует");
                return null;
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

            if (!canAfford)
            {
                Console.WriteLine($"Не хватает {product.Price - Wallet} денег!");
            }
            return canAfford;
        }

        public bool TryBuyProduct(Product product)
        {
            if (CanBuy(product))
            {
                SpendMoney(product.Price);
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

        private int _price;
        public int Price
        {
            get { return _price; }
        }

        public Product(string name, int price)
        {
            Name = name;
            _price = price;
        }

        public string Name { get; private set; }
    }
}
