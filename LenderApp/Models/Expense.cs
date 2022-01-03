using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LenderApp.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense")]
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
    }
}
