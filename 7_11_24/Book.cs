using _7_11_24.Exceptions;

namespace _7_11_24;

public class Book:Product
{

    public Book(string name, double price,int count, string authorName, int pageCount) : base(name, price, count)
    {
        AuthorName = authorName;

        PageCount = pageCount;

    }
    public string AuthorName { get; set; }
    public int PageCount { get; set; }

    public override void Sell()
    {
        if (Count != 0)
        {
            Count--;
            TotalIncome += Price;
        }
        else
            throw new ProductCountIsZeroException("kitablar bitib");

    }

    public override string ShowInfo()
    {
        return $"Book ID: {Id}\nName: {Name}\nPrice: {Price}\nCount: {Count}\nTotal Income: {TotalIncome}\nAuthor Name: {AuthorName}\nPage Count: {PageCount}";
    }
}
