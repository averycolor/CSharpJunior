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

struct GoodCell
{
    public Good Good { get; private set; }
    public int Count { get; private set; }

    public GoodCell(Good good, int count)
    {
        if (count <= 0)
        {
            throw new InvalidOperationException("Count cannot be non-positive");
        }

        Good = good;
        Count = count;
    }

    public GoodCell ChangeCount(int delta)
    {
        return new GoodCell(Good, Count + delta);
    }
}

abstract class GoodContainer
{
    private List<GoodCell> _contents = new List<GoodCell>();

    protected void AddGoods(GoodCell otherCell)
    {
        if (otherCell.Count < 0)
        {
            throw new InvalidOperationException("Cannot add a negative amount of goods.");
        }

        for (int i = 0; i < _contents.Count; i++)
        {
            GoodCell goodCell = _contents[i];

            if (goodCell.Good == otherCell.Good)
            {
                _contents[i] = goodCell.ChangeCount(otherCell.Count);
                return;
            }
        }

        _contents.Add(otherCell);
    }

    protected void RemoveGoods(GoodCell otherCell)
    {
        if (otherCell.Count < 0)
        {
            throw new InvalidOperationException("Cannot remove a negative amount of goods.");
        }

        for (int i = 0; i < _contents.Count; i++)
        {
            GoodCell goodCell = _contents[i];

            if (goodCell.Good == otherCell.Good)
            {
                int countDelta = goodCell.Count - otherCell.Count;

                if (countDelta == 0)
                {
                    _contents.RemoveAt(i);
                    return;
                }
                else if (countDelta < 0)
                {
                    throw new InvalidOperationException("Cannot remove amount of goods exceeding stored amount");
                }

                _contents[i] = goodCell.ChangeCount(-otherCell.Count);
                return;
            }
        }
    }

    public void Show()
    {
        foreach (GoodCell cell in _contents)
        {
            Console.WriteLine($"{cell.Count}x {cell.Good.Name}");
        }
    }

    protected List<GoodCell> Empty()
    {
        List<GoodCell> old = _contents;
        _contents = new List<GoodCell>();
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
        AddGoods(new GoodCell(good, count));
    }

    public void Dispatch(Good good, int count)
    {
        RemoveGoods(new GoodCell(good, count));
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
        GoodCell goodCell = new GoodCell(good, count);
        AddGoods(goodCell);
    }

    public Order Order()
    {
        List<GoodCell> orderedGoods = Empty();

        foreach (GoodCell goodCell in orderedGoods)
        {
            _warehouse.Dispatch(goodCell.Good, goodCell.Count);
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