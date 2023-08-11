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
}