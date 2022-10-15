namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Supermarket(4, new List<Product>
            {
                new Product("Яблоко", 100),
                new Product("Сок", 80),
                new Product("Мясо", 200)
            }).Work();
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    class Customer
    {
        private Dictionary<Product, int> _basket = new Dictionary<Product, int>();
        private int _money;
        private int _minMoney = 100;
        private int _maxMoney = 600;
        private Random _random = new Random();

        public int TotalBasketValue { get; private set; }

        public Customer()
        {
            _money = _random.Next(_minMoney, _maxMoney + 1);
        }

        public void AddToBasket(Product product)
        {
            if (_basket.ContainsKey(product)) 
                _basket[product]++;
            else 
                _basket.Add(product, 1);
            TotalBasketValue += product.Price;
        }

        public void ShowSummary()
        {
            foreach (var basketProduct in _basket)
            {
                Console.WriteLine($"{basketProduct.Key.Name} - {basketProduct.Value}x");
            }

            Console.WriteLine($"Total Basket Value: {TotalBasketValue}");
        }

        public bool TryPay(out int moneyPaid)
        {
            if (TotalBasketValue <= _money)
            {
                _money -= TotalBasketValue;
                moneyPaid = TotalBasketValue;
                _basket.Clear();
                return true;
            } else
            {
                moneyPaid = 0;
                return false;
            }
        }

        public void RemoveRandomProduct()
        {
            if (_basket.Count > 0)
            {
                int removedProductIndex = _random.Next(_basket.Count);
                TotalBasketValue -= _basket.Keys.ToList()[removedProductIndex].Price * _basket.Values.ToList()[removedProductIndex];
                _basket.Remove(_basket.Keys.ToList()[removedProductIndex]);
            }
        }
    }

    class Supermarket
    {
        private int _money;
        private Queue<Customer> _customers;
        private List<Product> _productsForSale;
        private int _maxProductsPerCustomer = 10;
        private Random _random = new Random();

        public Supermarket (int customersInQueue, List<Product> productsForSale)
        {
            _productsForSale = productsForSale;
            _customers = new Queue<Customer>();

            for (int i = 0; i < customersInQueue; i++)
            {
                AddNewCustomer();
            }
        }

        public void Work()
        {
            while (ServeCustomer())
            {
                Console.Clear();
                Console.WriteLine($"У магазина {_money} денег.");
                Console.WriteLine("Нажмите на любую клавишу, чтобы обслужить покупателя.");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        private void AddNewCustomer()
        {
            Customer newCustomer = new Customer();
            int newCustomerProductCount = _random.Next(_maxProductsPerCustomer + 1);

            for (int j = 0; j < newCustomerProductCount; j++)
                newCustomer.AddToBasket(_productsForSale[_random.Next(_productsForSale.Count)]);

            _customers.Enqueue(newCustomer);
        }

        private bool ServeCustomer()
        {
            Customer customer;

            if (_customers.TryDequeue(out customer))
            {
                Console.WriteLine("К кассе подходит покупатель.");
                customer.ShowSummary();
                int moneyPaid;

                while (customer.TryPay(out moneyPaid) == false)
                {
                    customer.RemoveRandomProduct();
                }

                Console.WriteLine($"Клиент заплатил {moneyPaid} и ушел");
                _money += moneyPaid;

                Console.WriteLine("Нажмите на любую клавишу, чтобы закончить обслуживание покупателя");
                Console.ReadKey(true);

                return true;
            } else
            {
                Console.WriteLine("Сегодня больше нет покупателей");
                return false;
            }
        }
    }
}
