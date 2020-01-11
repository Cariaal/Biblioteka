using System;
using System.Collections.Generic;
using System.Text;

    class studentsBook : Book
    {

    public studentsBook() : base()
    { }

    public studentsBook(string Title, string Author, string Type, int Pages) : base (Title, Author, Type, Pages)
    { }

    public override void insertData()
    {
        int checkPages;
        Console.Write("Tytuł: ");
        Title = Console.ReadLine();
        Console.Write("Autor: ");
        Author = Console.ReadLine();
        Console.Write("Strony: ");
        while (!int.TryParse(Console.ReadLine(), out checkPages))
        { Console.WriteLine("Podaj liczbę!"); }
        Pages = checkPages;
        Type = "Podręcznik";
    }

    public override string showType() => $"{Type}";
    public override string showTitle() => $"{Title}";
    public override string showAuthor() => $"{Author}";
    public override int showPages() => Pages;
}
