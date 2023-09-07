using BookApi.Api.Dto;
using BookApi.Domain.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Infra.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookApi.Api.BookApi _api;

    public BooksController(BookApi.Api.BookApi api)
    {
        _api = api;
    }

    [HttpGet(Name = "GetBooks")]
    public IEnumerable<BookView> Get(string? title)
    { 
        return _api.FindAll(new BookQuery(title));
    }
    
    [HttpPost(Name = "CreateBook")]
    public void Post(BookForm bookForm)
    {
        _api.Save(bookForm);
    }
}