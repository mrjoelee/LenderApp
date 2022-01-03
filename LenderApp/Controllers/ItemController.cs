using LenderApp.Data;
using LenderApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LenderApp.Controllers
{
    public class ItemController : Controller
    {
        //using dependency injections

        private readonly ApplicationDbContext _db;

        //creating a constructor to access the applicationdbcontext
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //retrieve items from the database
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }
        // Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Post Create - need to send it over.
        [HttpPost]
        //making the application safe, only authorizer users can have access
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            //after adding and saving it to the Db, you want the return to the list of items.
            return RedirectToAction("Index");
        }
    }
}
