using _7_11_24.Exceptions;
using static System.Reflection.Metadata.BlobBuilder;

namespace _7_11_24;

public class Library
{
    public int BookLimit { get; set; }
    private List<Book> Books { get; set; }

    public Library(int bookLimit)
    {
        BookLimit = bookLimit;
        Books = new List<Book>();
    }
    public void AddBook(Book book)
    {
        if (Books.Count >= BookLimit)
            throw new CapacityLimitException("Limite catilib");
        else Books.Add(book);
    }
    public Book GetBookById(int id)
    {
        foreach (Book book in Books)
        {
            if(book.Id== id) return book;
        }
        throw new NotFoundException("Kitab Tapilmadi");
    }
    public List<Book> GetAllBooks()
    {
        return new List<Book>(Books);
    }
    public void RemoveById(int id)
    {
        foreach (var item in Books)
        {
            if (item.Id == id)
            {
                Books.Remove(item);
                return;
            }
        }
            throw new NotFoundException("Kitab tapilmadi");
    }
}
