using BookApi.Api.Dto;
using BookApi.Domain.Books;

namespace BookApi.Api;

public class BookApi : IBookApi
{
    private readonly IBookService _bookService;

    public BookApi(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    public IEnumerable<BookView> FindAll(BookQuery query)
    {
        return _bookService.FindAll(query).Select(BookView.From).ToList();
    }
    
    public void Save(BookForm bookForm)
    {
        var book = bookForm.Create(Guid.NewGuid());
        _bookService.Save(book);
    }
}