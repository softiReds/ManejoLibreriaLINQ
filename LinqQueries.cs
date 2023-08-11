public class LinqQueries
{
    private List<Book> booksCollection = new List<Book>();
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Book> AllCollection()
    {
        return booksCollection;
    }

    public IEnumerable<Book> BooksAfter200()
    {
        return booksCollection.Where(e => e.PublishedDate.Year > 200);
    }

    public IEnumerable<Book> MoreThan200PagesTitleWithAction()
    {
        return booksCollection.Where(e => e.PageCount > 250 && e.Title.ToLower().Contains("in action"));
    }

    public bool BooksWithStatus()
    {
        return booksCollection.All(e => e.Status != string.Empty);
    }

    public bool BooksIn2005()
    {
        return booksCollection.Any(e => e.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> SpecificCategory(string category)
    {
        return booksCollection.Where(e => e.Categories.Contains(category));
    }

    public IEnumerable<Book> SpecificCategoryOrderedAsc(string category)
    {
        return SpecificCategory(category).OrderBy(e => e.Title);
    }

    public IEnumerable<Book> MoreThan450PagesOrderedDesc()
    {
        return booksCollection.Where(e => e.PageCount > 450).OrderByDescending(e => e.PageCount);
    }

    public IEnumerable<Book> FromJavaOrdered()
    {
        return booksCollection.Where(e => e.Categories.Contains("Java")).OrderBy(e => e.PublishedDate).TakeLast(3);
    }

    public IEnumerable<Book> MoreThan400Pages()
    {
        return booksCollection.Where(e => e.PageCount > 400).Take(4).Skip(2);
    }

    public IEnumerable<Book> TitlePages()
    {
        return booksCollection.Take(3).Select(e => new Book { Title = e.Title, PageCount = e.PageCount });
    }

    public int Between200And500()
    {
        return booksCollection.Count(e => e.PageCount >= 200 && e.PageCount <= 500);
    }

    public DateTime LowestDate()
    {
        return booksCollection.Min(e => e.PublishedDate);
    }

    public int MaxPages()
    {
        return booksCollection.Max(e => e.PageCount);
    }

    public Book LowestPages()
    {
        return booksCollection.Where(e => e.PageCount > 1).MinBy(e => e.PageCount);
    }

    public Book RecentBook()
    {
        return booksCollection.MaxBy(e => e.PublishedDate);
    }

    public int PageCount()
    {
        return booksCollection.Where(e => e.PageCount >= 0 && e.PageCount <= 500).Sum(e => e.PageCount);
    }

    public string BooksAfter2015()
    {
        return booksCollection.Where(e => e.PublishedDate.Year > 2015).Aggregate("", (BooksTitle, next) =>
        {
            if (BooksTitle != string.Empty) BooksTitle += " - " + next.Title;
            else BooksTitle += next.Title;
            return BooksTitle;
        });
    }

    public double AverageCharTitle()
    {
        return booksCollection.Average(e => e.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> After200GroupByYear()
    {
        return booksCollection.Where(e => e.PublishedDate.Year >= 200).GroupBy(e => e.PublishedDate.Year);
    }

    public ILookup<char, Book> Dictionary()
    {
        return booksCollection.ToLookup(e => e.Title[0], e => e);
    }

    public IEnumerable<Book> After2005MoreThan500Pags()
    {
        var booksAfter2005 = booksCollection.Where(e => e.PublishedDate.Year > 2005);
        var booksWithMoreThan500Pages = booksCollection.Where(e => e.PageCount > 500);

        return booksAfter2005.Join(booksWithMoreThan500Pages, e1 => e1.Title, e2 => e2.Title, (e1, e2) => e1);
    }
}