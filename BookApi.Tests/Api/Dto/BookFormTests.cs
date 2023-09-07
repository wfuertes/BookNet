using BookApi.Api.Dto;
using BookApi.Domain.Books;

namespace BookApi.Tests.Api.Dto;

public class BookFormTests
{
    [Fact(DisplayName = "Create - Must create book property")]
    private void Create_MustCreateBookProperty()
    {
        // Arrange
        var bookForm = new BookForm("title", "author", 1.23m);
        var bookId = Guid.NewGuid();
        
        // Act
        var book = bookForm.Create(bookId);
        
        // Assert
        var expectedBook = new Book(bookId, "title", "author", 1.23m);
        Assert.Equal(expectedBook, book);
    }
}