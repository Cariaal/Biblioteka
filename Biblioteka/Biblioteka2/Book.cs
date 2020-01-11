using System;
using System.Collections.Generic;
using System.Text;


    abstract class Book
    {
    public Book()
    {
        this.Title = "";
        this.Author = "";
        this.Type = "";
        this.Pages = 0;
    }

    public Book(string title, string author, string type, int pages)
    {
        this.Title = title;
        this.Author = author;
        this.Type = type;
        this.Pages = pages;
    }

    public string Title
    {get;protected set;}

    public string Author
    {get;protected set;}

    public string Type
    {get;protected set;}

    public int Pages
    { get; protected set; }

    public override string ToString()
    {
        string book = $"[{showType()}] [{showTitle()}] [{showAuthor()}] [{showPages()} stron]"; 
        return book;
    }
    public abstract void insertData();
    public abstract string showType();
    public abstract string showTitle();
    public abstract string showAuthor();
    public abstract int showPages();
}



