namespace _7_11_24;

public abstract class Product
{
    private static int id;
    public int Id { get; private set; }
    public string Name { get; set; }
    public double Price { get; set; } 
    public int Count { get; set; }
    public double TotalIncome { get; protected set; }
    public abstract void Sell();
    public abstract string ShowInfo();
    protected Product(string name,double price,int count)
    {
        Id = ++id;
        Name = name;
        Price = price;
        Count = count;
    }
}
