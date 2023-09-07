namespace BookApi.Domain.Books;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }
    
    public List<Book> FindAll(BookQuery query)
    {
        return _repository.FindAll(query);
    }
    
    public void Save(Book book)
    {
        _repository.Save(book);
    }
}