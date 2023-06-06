class Program
{
    static void Main(string[] args)
    {
        IPaymentSystem paymentSystemA = new PaymentSystemA();
        IPaymentSystem paymentSystemB = new PaymentSystemB();
        IPaymentSystem paymentSystemC = new PaymentSystemC();
        Order order = new Order(0, 52990);

        Console.WriteLine(paymentSystemA.GetPayingLink(order));
        Console.WriteLine(paymentSystemB.GetPayingLink(order));
        Console.WriteLine(paymentSystemC.GetPayingLink(order));
    }
}

public static class UserUtils
{
    public static int IntToHash(int source)
    {
        return source.ToString().GetHashCode();
    }
}

public class Order
{
    public readonly int Id;
    public readonly int Amount;

    public Order(int id, int amount) => (Id, Amount) = (id, amount);
}

public interface IPaymentSystem
{
    public string GetPayingLink(Order order);
}

public class PaymentSystemA : IPaymentSystem
{
    public string GetPayingLink(Order order)
    {
        return $"pay.system1.ru/order?amount={order.Amount}&hash={UserUtils.IntToHash(order.Id)}";
    }
}

public class PaymentSystemB : IPaymentSystem
{
    public string GetPayingLink(Order order)
    {
        return $"order.system2.ru/pay?hash={UserUtils.IntToHash(order.Id) + order.Amount}";
    }
}

public class PaymentSystemC : IPaymentSystem
{
    private const int _secretKey = 69420;

    public string GetPayingLink(Order order)
    {
        return $"system3.com/pay?amount={order.Amount}&curency=RUB&hash={UserUtils.IntToHash(order.Id) + order.Id + _secretKey}";
    }
}