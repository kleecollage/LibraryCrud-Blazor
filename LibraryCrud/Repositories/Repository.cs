using LibraryCrud.Data;
using LibraryCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryCrud.Repositories;

public class Repository: IRepository
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Task<List<Book>> GetBooks()
    {
        return _context.Books.ToListAsync();
    }

    public async Task<Book> GetBookId(int bookId)
    {
        var bookFromDb = await _context.Books.FindAsync(bookId);
        return bookFromDb ?? new Book();
    }

    public async Task<Book> CreateBook(Book createBook)
    {
        if (createBook != null)
        {
            createBook.CreatedAt = DateTime.Now;
            await _context.Books.AddAsync(createBook);
            await _context.SaveChangesAsync();
            return createBook;
        }
        else
        {
            return new Book();
        }
    }

    public async Task<Book> UpdateBook(int bookId, Book updateBook)
    {
        var bookFromDb = await _context.Books.FindAsync(bookId);
        bookFromDb.Title = updateBook.Title;
        bookFromDb.Description = updateBook.Description;
        bookFromDb.Author = updateBook.Author;
        bookFromDb.Pages = updateBook.Pages;
        bookFromDb.Price = updateBook.Price;
        
        await _context.SaveChangesAsync();
        return bookFromDb;
    }

    public async Task DeleteBook(int bookId)
    {
        var bookFromDb = await _context.Books.FindAsync(bookId);
        _context.Remove(bookFromDb);
        await _context.SaveChangesAsync();
    }
}














