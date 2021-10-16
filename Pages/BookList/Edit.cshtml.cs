using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        [BindProperty]
        public Book Book { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
            Console.WriteLine(Book.Name);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var booksToUpdate = await _db.Book.FindAsync(Book.Id);
                booksToUpdate.Id = Book.Id;
                booksToUpdate.Name = Book.Name;
                booksToUpdate.Author = Book.Author;
                booksToUpdate.ISBN = Book.ISBN;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}