LinqQueries linqQueries = new LinqQueries();

// PrintValues(linqQueries.AllCollection());
// PrintValues(linqQueries.BooksAfter200());
// PrintValues(linqQueries.MoreThan200PagesTitleWithAction());
// Console.WriteLine({linqQueries.BooksWithStatus());
// Console.WriteLine(linqQueries.BooksIn2005());
// PrintValues(linqQueries.SpecificCategory("Python"));
// PrintValues(linqQueries.SpecificCategoryOrderedAsc("Java"));
// PrintValues(linqQueries.MoreThan450PagesOrderedDesc());
// PrintValues(linqQueries.FromJavaOrdered());
// PrintValues(linqQueries.MoreThan400Pages());
// PrintValues(linqQueries.TitlePages());
// Console.WriteLine(linqQueries.Between200And500());
// Console.WriteLine(linqQueries.LowestDate());
// Console.WriteLine(linqQueries.MaxPages());

// var book = linqQueries.LowestPages();
// Console.WriteLine($"{book.Title} - {book.PageCount}");

// var book = linqQueries.RecentBook();
// Console.WriteLine($"{book.Title} - {book.PublishedDate}");

// Console.WriteLine(linqQueries.PageCount());
// Console.WriteLine(linqQueries.BooksAfter2015());
// Console.WriteLine(linqQueries.AverageCharTitle());
// PrintGroup(linqQueries.After200GroupByYear());
// PrintDictionary(linqQueries.Dictionary(), 'S');
// PrintValues(linqQueries.After2005MoreThan500Pags());

void PrintValues(IEnumerable<Book> booksList)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "Page Count", "Published Date");
    foreach (var book in booksList)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}

void PrintGroup(IEnumerable<IGrouping<int, Book>> booksList)
{
    foreach (var group in booksList)
    {
        Console.WriteLine("");
        Console.WriteLine($"Group: {group.Key}");
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "Page Count", "Published Date");
        foreach (var book in group)
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }
}

void PrintDictionary(ILookup<char, Book> booksList, char letter)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "Page Count", "Published Date");
    foreach (var book in booksList[letter])
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}