using _7_11_24.Exceptions;
using System;

namespace _7_11_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kitabxanaya xosh gelmisiniz");
            Console.WriteLine("Kitabxana limitini teyin edin:");

        CorrectLimit:
            string stringLimit = Console.ReadLine();
            int limit;
            if (!(int.TryParse(stringLimit, out limit) && limit >= 0))
            {
                Console.WriteLine("Limiti duzgun daxil et");
                goto CorrectLimit;
            }

            Library library = new(limit);

        Menu:
            Console.WriteLine("1. Kitab elave et\n" +
                "2. Kitab sat\n" +
                "3. Kitab tap\n" +
                "4. Kitab sil\n" +
                "5. Butun kitablari goster");
            Console.WriteLine("Secim et");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    try
                    {
                        Console.WriteLine("Kitabin adi:");
                        string bookName = Console.ReadLine();

                        double bookPrice;
                    CorrectPrice:
                        Console.WriteLine("Kitabin qiymeti:");
                        if (!double.TryParse(Console.ReadLine(), out bookPrice))
                        {
                            Console.WriteLine("Qiymeti duzgun daxil et");
                            goto CorrectPrice;
                        }

                        int countOfBooks;
                    CorrectCount:
                        Console.WriteLine("Kitabin sayisi:");
                        if (!int.TryParse(Console.ReadLine(), out countOfBooks))
                        {
                            Console.WriteLine("Sayini duzgun daxil et");
                            goto CorrectCount;
                        }

                        Console.WriteLine("Muellifin adi:");
                        string authorName = Console.ReadLine();

                        int pageCount;
                    CorrectPageCount:
                        Console.WriteLine("Kitabin sehve sayi:");
                        if (!int.TryParse(Console.ReadLine(), out pageCount))
                        {
                            Console.WriteLine("Səhifə sayını duzgun daxil et");
                            goto CorrectPageCount;
                        }

                        Book book = new(bookName, bookPrice, countOfBooks, authorName, pageCount);
                        library.AddBook(book);
                        Console.WriteLine($"{book.Name} yaradildi ");
                    }
                    catch (CapacityLimitException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    goto Menu;

                case "2":
                    try
                    {
                        if (library.GetAllBooks().Count == 0)
                        {
                            Console.WriteLine("Kitab yoxdur ki, satasiniz");
                        }
                        else
                        {
                            Console.WriteLine("Satmaq istediyiniz kitabin id'i yazin");
                            int idOfBook;
                        CorrectIdForSell:
                            if (!int.TryParse(Console.ReadLine(), out idOfBook))
                            {
                                Console.WriteLine("ID-ni duzgun daxil et");
                                goto CorrectIdForSell;
                            }

                            library.GetBookById(idOfBook).Sell();
                            var book = library.GetBookById(idOfBook);
                            Console.WriteLine($"Satilan kitab {book.Name} Qalan sayi - {book.Count} Toplam gelir - {book.TotalIncome}");
                        }
                    }
                    catch (NotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (ProductCountIsZeroException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    goto Menu;

                case "3":
                    try
                    {
                        Console.WriteLine("Tapmaq istediyin kitabin id'i daxil et:");
                        int id;
                    CorrectIdForFind:
                        if (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.WriteLine("ID-ni duzgun daxil et");
                            goto CorrectIdForFind;
                        }

                        Console.WriteLine(library.GetBookById(id).ShowInfo());
                    }
                    catch (NotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    goto Menu;

                case "4":
                    try
                    {
                        Console.WriteLine("Silmek istediyin kitabin id'i daxil et:");
                        int idForRemove;
                    CorrectIdForRemove:
                        if (!int.TryParse(Console.ReadLine(), out idForRemove))
                        {
                            Console.WriteLine("ID-ni duzgun daxil et");
                            goto CorrectIdForRemove;
                        }

                        library.RemoveById(idForRemove);
                        Console.WriteLine($"Silindi");
                    }
                    catch (NotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    goto Menu;

                case "5":
                    if (library.GetAllBooks().Count == 0)
                    {
                        Console.WriteLine("Kitabxana bosdur");
                    }
                    else
                    {
                        foreach (var item in library.GetAllBooks())
                        {
                            Console.WriteLine(item.ShowInfo());
                        }
                    }
                    goto Menu;
            }
        }
    }
}
