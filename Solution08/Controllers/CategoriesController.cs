
using Solution08.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Solution08.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list =  _context.Categories
                                .OrderBy(c => c.Name)
                                .ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View(new Category());
        }

        //POST : après la soumission du formulaire
        [HttpPost]
        public IActionResult CreateConfirmed(Category category)
        {
            if (ModelState.IsValid)
            {
                //traitement
                _context.Categories.Add(category);
                _context.SaveChanges(); //le commit dans la DB
                return RedirectToAction(nameof(Index));
            }

            //en cas d'erreur
            return View(category);
        }
    }
}
