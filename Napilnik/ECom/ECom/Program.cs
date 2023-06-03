Good iPhone12 = new Good("IPhone 12");
Good iPhone11 = new Good("IPhone 11");

Warehouse warehouse = new Warehouse();

Shop shop = new Shop(warehouse);

warehouse.Deliver(iPhone12, 10);
warehouse.Deliver(iPhone11, 1);

Console.WriteLine("Warehouse Contents:");
warehouse.Show();

Cart cart = shop.Cart();
cart.Add(iPhone12, 4);
cart.Add(iPhone11, 3);

Console.WriteLine("Cart Contents:");
cart.Show();

Console.WriteLine(cart.Order().Paylink);

cart.Add(iPhone12, 9);

abstract class GoodContainer
{
    private Dictionary<Good, int> _contents = new Dictionary<Good, int>();

    protected void AddGoods(Good good, int count)
    {
        if (count < 0)
        {
            throw new InvalidOperationException("Cannot add a negative amount of goods.");
        }

        if (_contents.ContainsKey(good))
        {
            _contents[good] += count;
        }
        else if (count != 0)
        {
            _contents[good] = count;
        }
    }

    protected void RemoveGoods(Good good, int count)
    {
        if (count < 0)
        {
            throw new InvalidOperationException("Cannot remove a negative amount of goods.");
        }

        if (_contents.ContainsKey(good))
        {
            int newCount = _contents[good] - count;

            if (newCount > 0)
            {
                _contents[good] = newCount;
            }
            else if (newCount == 0)
            {
                _contents.Remove(good);
            }
            else
            {
                throw new InvalidOperationException("Cannot remove more than is stored");
            }
        }
        else
        {
            throw new InvalidOperationException("Cannot remove goods that are not stored");
        }
    }

    public void Show()
    {
        foreach (var (good, count) in _contents)
        {
            Console.WriteLine($"{count}x {good.Name}");
        }
    }

    protected Dictionary<Good, int> Empty()
    {
        Dictionary<Good, int> old = new Dictionary<Good, int>();

        foreach (var (good, count) in _contents)
        {
            old.Add(good, count);
        }

        _contents.Clear();
        return old;
    }
}

class Good
{
    public string Name { get; private set; }

    public Good(string name)
    {
        Name = name;
    }
}

class Warehouse : GoodContainer
{
    public void Deliver(Good good, int count)
    {
        AddGoods(good, count);
    }

    public void Dispatch(Good good, int count)
    {
        RemoveGoods(good, count);
    }
}

class Shop
{
    private Warehouse _warehouse;

    public Shop(Warehouse warehouse)
    {
        _warehouse = warehouse;
    }

    public Cart Cart()
    {
        return new Cart(_warehouse);
    }
}

class Cart : GoodContainer
{
    private Warehouse _warehouse;

    public Cart(Warehouse warehouse)
    {
        _warehouse = warehouse;
    }

    public void Add(Good good, int count)
    {
        AddGoods(good, count);
    }

    public Order Order()
    {
        Dictionary<Good, int> orderedGoods = Empty();

        foreach (var orderedGood in orderedGoods)
        {
            _warehouse.Dispatch(orderedGood.Key, orderedGood.Value);
        }

        return new Order();
    }
}

class Order
{
    public string Paylink { get; private set; }
    public int Number { get; private set; }

    private static int _nextNumber;

    public Order()
    {
        Number = _nextNumber;
        _nextNumber++;

        Paylink = $"pay.hulisexpress/n={Number}";
    }
}