using BookApi.Domain.Books;
using Microsoft.EntityFrameworkCore;
using BookEntity = BookApi.Infra.Data.Entity.Book;

namespace BookApi.Infra.Data;

public class SqlBookRepository : IBookRepository
{
    private readonly AppDbContext _dbContext;
    
    public SqlBookRepository(AppDbContext dbContext) 
    {
        _dbContext = dbContext;
    }
    
    public List<Book> FindAll(BookQuery query)
    {
        var bookRecords = _dbContext.Books.AsQueryable();

        if (!string.IsNullOrEmpty(query.Title))
        {
            bookRecords = bookRecords.Where(b => EF.Functions.Like(b.Title, $"%{query.Title}%"));
        }
        
        return bookRecords
            .Select(b => new Book(b.Id, b.Title, b.Author, b.Price))
            .ToList();
    }

    public void Save(Book book)
    {
        _dbContext.Books.Add(new BookEntity(book.Id, book.Title, book.Author, book.Price));
        _dbContext.SaveChanges();
    }
}