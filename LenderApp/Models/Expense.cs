using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LenderApp.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        //displays the expense, rather the property.
        [DisplayName("Expense")]
        //required annotation - must enter or else won't able to create.
        [Required]
        public string ExpenseName { get; set; }
        [Required]
        //amount must be positive amount, so from 1 to a max value of int
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0!")]
        public int Amount { get; set; }
    }
}
