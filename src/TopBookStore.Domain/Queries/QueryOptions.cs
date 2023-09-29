using System.Linq.Expressions;

namespace TopBookStore.Domain.Queries;

public class QueryOptions<T>
{
    // private field, public properties for Include strings
    private string[] includes = Array.Empty<string>();

    // Includes = "Book, Author"
    // public write-only property for Include strings – accepts a string, converts it to
    // a string array, and stores in private string array field
    public string Includes
    {
        set => includes = value.Replace(" ", "").Split(",");
    }

    // public get method for Include strings - returns private string array, or
    // empty string array if private backing field is null
    public string[] GetIncludes() => includes;

    // public properties for sorting, filtering, and paging
    public Expression<Func<T, bool>> Where { get; set; } = null!;
    public Expression<Func<T, object>> OrderBy { get; set; } = null!;
    public string OrderByDirection { get; set; } = "asc"; // only if have orderby to invoke this
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public bool HasInclude => includes != Array.Empty<string>();
    public bool HasWhere => Where is not null;
    public bool HasOrderBy => OrderBy is not null;
    public bool HasPaging => PageSize > 0 && PageNumber > 0;
}