using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LenderApp.Models
{
    public class Item
    {
        //identifier for every item , default identifier
        [Key]
        public int Id { get; set; }
        public string? Borrower { get; set; }
        public string? Lender { get; set; } 
        //using data annotation to have a better display name
        [DisplayName("Item Name")]
        public string? ItemName { get; set; }

    }
}
