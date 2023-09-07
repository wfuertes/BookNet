namespace BookApi.Domain.Books;

public record Book(Guid Id, string Title, string Author, decimal Price);