using LenderApp.Data;
using LenderApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LenderApp.Controllers
{
    public class ExpenseTypeController : Controller
    {
        //using dependency injections

        private readonly ApplicationDbContext _db;

        //creating a constructor to access the applicationdbcontext
        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            //retrieve expenses from the database
            IEnumerable<ExpenseType> objList = _db.ExpenseTypes;
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
        public IActionResult Create(ExpenseType obj)
        {
            //server side validation
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(obj);
                _db.SaveChanges();
                //after adding and saving it to the Db, you want the return to the list of expenses.
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get Request Delete
        //sending the user to page of delete-View, after checking the Id
        public IActionResult Delete(int? id)
        {
           
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseTypes.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //Post Delete
        //will delete the item from the list of item
        [HttpPost]
        //making the application safe, only authorizer users can have access
        [ValidateAntiForgeryToken]
        //putting int id parameter for that specific item (object)
        public IActionResult DeletePost(int? id)
        {
            //finds the item by using the id
            var obj = _db.ExpenseTypes.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.ExpenseTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        //Get Request Update
        //sending the user to page of Update-View, after checking the Id
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //Post Request Update
        //updating the Db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType obj)
        {
            //server side validation
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(obj);
                _db.SaveChanges();
                //after adding and saving it to the Db, you want the return to the list of expenses.
                return RedirectToAction("Index");
            }
            return View(obj);


        }


    }
}

