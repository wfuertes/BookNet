using BookApi.Domain.Books;
using Moq;

namespace BookApi.Tests.Domain.Books;

public class BookServiceTests : IDisposable
{
    private readonly Mock<IBookRepository> _repositoryMock;
    private readonly BookService _service;
    
    public BookServiceTests()
    {
        _repositoryMock = new Mock<IBookRepository>();
        _service = new BookService(_repositoryMock.Object);
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _repositoryMock.Reset();    
    }
    
    [Fact(DisplayName = "Should call repository to save book")]
    private void ShouldCallRepositoryToSaveBook()
    {
        // Arrange
        var book = new Book(Guid.NewGuid(), "title", "author", 1.23m);
        
        // Act
        _service.Save(book);
        
        // Assert
        _repositoryMock.Verify(r => r.Save(book), Times.Once);
        _repositoryMock.VerifyNoOtherCalls();
    }
    
    [Fact(DisplayName = "Should call repository to find all books")]
    private void ShouldCallRepositoryToFindAllBooks()
    {
        // Arrange
        var query = new BookQuery("My Title");
        _repositoryMock.Setup(r => r.FindAll(query)).Returns(new List<Book>());
        
        // Act
        _service.FindAll(query);
        
        // Assert
        _repositoryMock.Verify(r => r.FindAll(query), Times.Once);
        _repositoryMock.VerifyNoOtherCalls();
    }
}