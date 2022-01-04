using LenderApp.Data;
using LenderApp.Models;
using LenderApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

            //user can select a type of expense by creating a enumerable of all expense types
            //IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString(),
            //});
            ////a way to pass data from controller to the view
            //ViewBag.TypeDropDown = TypeDropDown;
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                })
            };
            return View(expenseVM);
        }

        //Post Create - need to send it over.
        [HttpPost]
        //making the application safe, only authorizer users can have access
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM obj)
        {

            //server side validation
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj.Expense);
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
            var obj = _db.Expenses.Find(id);
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
            var obj = _db.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(obj);
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
            var obj = _db.Expenses.Find(id);
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
        public IActionResult Update(Expense obj)
        {
            //server side validation
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                //after adding and saving it to the Db, you want the return to the list of expenses.
                return RedirectToAction("Index");
            }
            return View(obj);


        }


    }
}

