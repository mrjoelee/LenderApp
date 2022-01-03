﻿using System.ComponentModel.DataAnnotations;

namespace LenderApp.Models
{
    public class Item
    {
        //identifier for every item , default identifier
        [Key]
        public int Id { get; set; }
        public string Borrower { get; set; }

    }
}
