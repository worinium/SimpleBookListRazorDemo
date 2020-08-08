using bookapi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace bookapi.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {

        private ApplicationDbContext db;

        public BookController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        [BindProperty]
        public Book Book { get; set; }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = db.Books.ToList() });
        }
        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await db.Books.AddAsync(Book);
                await db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

        }

    }
}