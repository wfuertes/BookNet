using BookApi.Domain.Books;

namespace BookApi.Api.Dto;

public record BookView(Guid Id, string Title, string Author, decimal Price)
{
    public static BookView From(Book book)
    {
        return new BookView(book.Id, book.Title, book.Author, book.Price);
    }
}
