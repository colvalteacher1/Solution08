
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

        //POST: Create à compléter
    }
}
