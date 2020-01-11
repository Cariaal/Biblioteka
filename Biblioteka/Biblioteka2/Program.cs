using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Program
    {
        public static void displayMenu()
        {
            Console.Clear();
            Console.WriteLine("[1] - Wyswietl liste książek w bazie:");
            Console.WriteLine("[2] - Wyswietl liste książek wypożyczonych:");
            Console.WriteLine("[3] - Dodaj książkę do biblioteki:");
            Console.WriteLine("[4] - Wypożycz książkę:");
            Console.WriteLine("[5] - Oddaj książkę:");
            Console.WriteLine("[6] - Szukaj po ilości stron:");
            Console.WriteLine("[0] - Zamknij program:");
            Console.Write("Wybierz opcję > ");
        }

        public static void displayMenuBooks()
        {
            Console.Clear();
            Console.WriteLine("[1] - Podręczniki: ");
            Console.WriteLine("[2] - Książki rozrywkowe: ");
            Console.WriteLine("[3] - Biografie: ");
            Console.WriteLine("[0] - Powrót");
            Console.Write("Wybierz opcję > ");
        }

    public class sthWentWrongException : Exception
    {
        public sthWentWrongException()
        { }

        public sthWentWrongException(string message)
        {
            message = "Coś poszło nie tak";
        }
    }
        static void run()
        {
        int choice = 0, choiceBooks = 0, choiceToFile = 0;
        List<Book> listOfBooks = new List<Book> { };
        List<Book> booksAtLoan = new List<Book> { };
        List<Book> listOfBooksTemp = new List<Book> { };
        do
            {
                displayMenu();
                while (!int.TryParse(Console.ReadLine(), out choice))
                { Console.WriteLine("Podaj liczbę!"); }
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Koniec pracy!");
                    break;

                case 1:
                    if (listOfBooks.Count == 0)
                    { Console.WriteLine("Brak książek w systemie!"); }
                    else
                    { listOfBooks.ForEach(Console.WriteLine);
                        Console.WriteLine("Czy zapisać listę do pliku? (0 - NIE / 1 - TAK)");
                        while (!int.TryParse(Console.ReadLine(), out choiceToFile))
                        { Console.WriteLine("Podaj liczbę!"); }
                        if (choiceToFile == 1)
                        {
                            Console.WriteLine("Podaj nazwę pliku: ");
                            string my_file = Console.ReadLine();
                            if (!File.Exists($"C:/Users/Amadeusz/{my_file}.txt"))
                            {
                                foreach (var item in listOfBooks)
                                {
                                    File.AppendAllTextAsync($"C:/Users/Amadeusz/{my_file}.txt", item.ToString());
                                }
                                Console.WriteLine($"Zapisano plik {my_file}");
                            }
                            else Console.WriteLine("Plik istnieje!");
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("Nie zapisano");
                    }
                    Console.ReadKey();
                    break;

                case 2:
                    if (booksAtLoan.Count == 0)
                    { Console.WriteLine("Brak wypożyczonych książek!"); }
                    else
                    { booksAtLoan.ForEach(Console.WriteLine); }
                    Console.ReadKey();
                    break;

                case 3:
                    do
                    {
                        displayMenuBooks();
                        while (!int.TryParse(Console.ReadLine(), out choiceBooks))
                        { Console.WriteLine("Podaj liczbę!"); }
                        switch (choiceBooks)
                        {
                            case 0:
                                break;

                            case 1:
                                studentsBook sbook = new studentsBook();
                                sbook.insertData();
                                listOfBooks.Add(sbook);
                                Console.WriteLine($"Dodano książkę: {sbook.ToString()}");
                                Console.ReadKey();
                                break;

                            case 2:
                                entertainBook ebook = new entertainBook();
                                ebook.insertData();
                                listOfBooks.Add(ebook);
                                Console.WriteLine($"Dodano książkę: {ebook.ToString()}");
                                Console.ReadKey();
                                break;

                            case 3:
                                biographyBook bbook = new biographyBook();
                                bbook.insertData();
                                listOfBooks.Add(bbook);
                                Console.WriteLine($"Dodano książkę: {bbook.ToString()}");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("Podaj liczbę z zakresu 1 - 5");
                                Console.ReadKey();
                                break;
                        }

                    } while (choiceBooks != 0);
                    break;

                case 4:
                    int index = 0;
                    if (listOfBooks.Count == 0)
                    {
                        Console.WriteLine("Brak książek do wypożyczenia");
                    }
                    else
                    {
                        for (int i = 0; i < listOfBooks.Count; i++)
                        {
                            Console.WriteLine($"[{i}]: {listOfBooks.ElementAt(i)}");
                        }
                        Console.WriteLine("Podaj numer książki do wypożyczenia: ");
                        while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= listOfBooks.Count)
                        { Console.WriteLine($"Podaj NUMER KATALOGOWY wybranej książki (liczba od 0 --> {listOfBooks.Count - 1})"); }
                        Console.WriteLine($"Książka: {listOfBooks.ElementAt(index)} została wypożyczona");
                        booksAtLoan.Add(listOfBooks.ElementAt(index));
                        listOfBooks.RemoveAt(index);
                    }
                    Console.ReadKey();
                    break;

                case 5:
                    index = 0;
                    if (booksAtLoan.Count == 0)
                    {
                        Console.WriteLine("Brak książek do oddania");
                    }
                    else
                    {
                        for (int i = 0; i < booksAtLoan.Count; i++)
                        {
                            Console.WriteLine($"[{i}]: {booksAtLoan.ElementAt(i)}");
                        }
                        Console.WriteLine("Podaj numer książki do oddania: ");
                        while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= booksAtLoan.Count)
                        { Console.WriteLine($"Podaj NUMER KATALOGOWY wybranej książki (liczba od 0 --> {booksAtLoan.Count - 1})"); }
                        Console.WriteLine($"Książka: {booksAtLoan.ElementAt(index)} została oddana");
                        listOfBooks.Add(booksAtLoan.ElementAt(index));
                        booksAtLoan.RemoveAt(index);
                    }
                    Console.ReadKey();
                    break;

                case 6:
                    if (listOfBooks.Count == 0)
                    {
                        Console.WriteLine("Brak książek w bazie");
                    }
                    else
                    {
                        int pagesFrom = 0, pagesTo = 0;
                        listOfBooks.ForEach(Console.WriteLine);
                        Console.WriteLine("Podaj ilość stron od:");
                        while (!int.TryParse(Console.ReadLine(), out pagesFrom))
                        { Console.WriteLine("Liczba!"); }
                        Console.WriteLine("Podaj ilość stron do:");
                        while (!int.TryParse(Console.ReadLine(), out pagesTo))
                        { Console.WriteLine("Liczba!"); }
                        if (pagesFrom < 0 || pagesTo <= 0 || pagesFrom > pagesTo)
                        {
                            Console.WriteLine("Niepoprawne dane");
                        }
                        else
                        {
                            listOfBooksTemp = new List<Book>();
                            foreach (var book in listOfBooks)
                            {
                               if (( book.Pages >= pagesFrom) && (book.Pages <= pagesTo))
                                {
                                    listOfBooksTemp.Add(book);
                                }
                            }
                            if (listOfBooksTemp.Count == 0)
                            {
                                Console.WriteLine("Brak książek dla tego kryterium");
                            }
                            else
                            {
                                listOfBooksTemp.ForEach(Console.WriteLine);
                            }
                        }
                    }
                    Console.ReadKey();
                    break;


                default:
                    Console.WriteLine("Podaj liczbę z zakresu 1 - 5");
                    Console.ReadKey();
                    break;
                }
            } while (choice !=0);
        }

    static void Main(string[] args)
            {
        try
        {
            run();
        }
        catch (sthWentWrongException exc)
        {
            Console.WriteLine(exc.Message);
        }
        
    }
    
}
