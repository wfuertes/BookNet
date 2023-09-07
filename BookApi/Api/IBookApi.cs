using BookApi.Api.Dto;
using BookApi.Domain.Books;

namespace BookApi.Api;

public interface IBookApi
{
    public IEnumerable<BookView> FindAll(BookQuery query);


    public void Save(BookForm bookForm);
}