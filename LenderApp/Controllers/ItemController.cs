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
    }
}
