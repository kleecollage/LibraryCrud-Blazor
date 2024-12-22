using System.ComponentModel.DataAnnotations;

namespace LibraryCrud.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Author is required")]
    public string Author { get; set; }
    
    [Required(ErrorMessage = "The number of pages is required")]
    public int Pages { get; set; }

    [Required(ErrorMessage = "Price is required")]
    public decimal  Price { get; set; }
    
    public DateTime CreatedAt { get; set; }
}