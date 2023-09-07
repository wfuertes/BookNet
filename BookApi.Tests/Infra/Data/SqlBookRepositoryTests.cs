using BookApi.Domain.Books;
using BookApi.Infra.Data;
using BookEntity = BookApi.Infra.Data.Entity.Book;

namespace BookApi.Tests.Infra.Data;

public class SqlBookRepositoryTests : IDisposable
{
    private readonly AppDbContext _dbContext;
    private readonly SqlBookRepository _repository;
    
    public SqlBookRepositoryTests()
    {
        _dbContext = new AppDbContext(true);
        _repository = new SqlBookRepository(_dbContext);
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _dbContext.Dispose();
    }
    
    [Fact(DisplayName = "FindAll - Should return empty list when no books are found")]
    private void FindAll_ShouldReturnEmptyListWhenNoBooksAreFound()
    {
        // Arrange
        var query = new BookQuery("My Title");
        
        // Act
        var books = _repository.FindAll(query);
        
        // Assert
        Assert.Empty(books);
    }
    
    [Fact(DisplayName = "FindAll - Should return books when books are found")]
    private void FindAll_ShouldReturnBooksWhenBooksAreFound()
    {
        // Arrange
        var query = new BookQuery("My Title");
        var book = new Book(Guid.NewGuid(), "My Title", "My Author", 1.23m);
        _dbContext.Books.Add(new BookEntity(book.Id, book.Title, book.Author, book.Price));
        _dbContext.SaveChanges();
        
        // Act
        var books = _repository.FindAll(query);
        
        // Assert
        Assert.NotEmpty(books);
        Assert.Equal(book.Id, books[0].Id);
        Assert.Equal(book.Title, books[0].Title);
        Assert.Equal(book.Author, books[0].Author);
        Assert.Equal(book.Price, books[0].Price);
    }
    
    [Fact(DisplayName = "Save - Should save book")]
    private void Save_ShouldSaveBook()
    {
        // Arrange
        var book = new Book(Guid.NewGuid(), "My Title", "My Author", 1.23m);
        
        // Act
        _repository.Save(book);
        
        // Assert
        var bookRecord = _dbContext.Books.Find(book.Id);
        Assert.NotNull(bookRecord);
        Assert.Equal(book.Id, bookRecord.Id);
        Assert.Equal(book.Title, bookRecord.Title);
        Assert.Equal(book.Author, bookRecord.Author);
        Assert.Equal(book.Price, bookRecord.Price);
    }
}