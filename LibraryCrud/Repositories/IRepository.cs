using LibraryCrud.Models;

namespace LibraryCrud.Repositories;

public interface IRepository
{
    public Task<List<Book>> GetBooks();
    
    public Task<Book> GetBookId(int bookId);
    
    public Task<Book> CreateBook(Book createBook);
    
    public Task<Book> UpdateBook(int bookId, Book updateBook);
    
    public Task DeleteBook(int bookId);
}