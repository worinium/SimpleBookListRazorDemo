using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext db;

        public CreateModel(ApplicationDbContext applicationDbContext)
        {
            db = applicationDbContext;
        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {

        }

    }
}