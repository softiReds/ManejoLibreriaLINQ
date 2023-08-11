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
PrintValues(linqQueries.TitlePages());

void PrintValues(IEnumerable<Book> booksList)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "Page Count", "Published Date");
    foreach (var book in booksList)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}