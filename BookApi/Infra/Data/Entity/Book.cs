namespace BookApi.Infra.Data.Entity;


public record Book(Guid Id, string Title, string Author, decimal Price);
