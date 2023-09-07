namespace BookApi.Domain.Books;

public interface IBookService
{
    List<Book> FindAll(BookQuery query);

    void Save(Book book);
}