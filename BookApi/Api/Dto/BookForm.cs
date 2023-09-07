using BookApi.Domain.Books;

namespace BookApi.Api.Dto;

public record BookForm(string Title, string Author, decimal Price)
{
    public Book Create(Guid id)
    {
        return new Book(id, Title, Author, Price);
    }
}