using LenderApp.Data;
using LenderApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LenderApp.Controllers
{
    public class ExpenseController : Controller
    {
        //using dependency injections

        private readonly ApplicationDbContext _db;

        //creating a constructor to access the applicationdbcontext
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //retrieve expenses from the database
            IEnumerable<Expense> objList = _db.Expenses;
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            //server side validation
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                //after adding and saving it to the Db, you want the return to the list of expenses.
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}

