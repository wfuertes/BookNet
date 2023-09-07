namespace BookApi.Domain.Books;

public interface IBookRepository
{
    List<Book> FindAll(BookQuery query);
    
    void Save(Book book);
}