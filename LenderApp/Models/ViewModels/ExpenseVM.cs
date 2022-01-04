using Microsoft.AspNetCore.Mvc.Rendering;

namespace LenderApp.Models.ViewModels
{
    public class ExpenseVM
    {
        //connect the ViewBag and return View() from Create Controller (strongly Typed Views)
        public Expense Expense { get; set; }
        public IEnumerable<SelectListItem>? TypeDropDown { get; set; }
    }
}
