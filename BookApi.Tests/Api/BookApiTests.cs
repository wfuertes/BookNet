using BookApi.Domain.Books;
using Moq;

namespace BookApi.Tests.Api;

public class BookApiTests : IDisposable
{
    private readonly Mock<IBookService> _serviceMock;
    private readonly BookApi.Api.BookApi _api;

    public BookApiTests()
    {
        _serviceMock = new Mock<IBookService>();
        _api = new BookApi.Api.BookApi(_serviceMock.Object);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _serviceMock.Reset();
    }

    [Fact(DisplayName = "FindAll - Must call service property")]
    private void FindAll_MustCallServiceProperty()
    {
        // Arrange
        _serviceMock.Setup(service => service.FindAll(It.IsAny<BookQuery>())).Returns(new List<Book>());

        // Act
        var query = new BookQuery("My Title");
        _api.FindAll(query);

        // Assert
        _serviceMock.Verify(service => service.FindAll(query), Times.Once);
        _serviceMock.VerifyNoOtherCalls();
    }
}