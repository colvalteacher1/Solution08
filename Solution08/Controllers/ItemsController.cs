
using Solution08.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Solution08.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public IActionResult Index()
        {
            var list = _context.Items
                                .OrderBy(i => i.Title)
                                .ToList();
            return View(list);
        }

        
        // GET: Items/Details/5
        public IActionResult Details(int id)
        {
            var item =  _context.Items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        // GET: Items/Delete/5
        public IActionResult Delete(int id)
        {
            var item =  _context.Items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET : charger le formulaire
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(new Item());
        }

        //POST : après la soumission du formulaire
        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                //traitement
                _context.Items.Add(item);
                _context.SaveChanges(); //le commit dans la DB
                return RedirectToAction(nameof(Index));
            }

            //en cas d'erreur
            ViewBag.Categories = _context.Categories.ToList();
            return View(item);
        }

        // GET
        public IActionResult Edit(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
                return NotFound();

            ViewBag.Categories = _context.Categories.ToList();
            return View(item);
        }

        //POST : Edit à compléter
        [HttpPost]
        public IActionResult EditConfirmed(Item item)
        {
            if (ModelState.IsValid)
            {
                //traitement
                _context.Items.Update(item);
                _context.SaveChanges(); //le commit dans la DB
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(item);
        }
    }
}
