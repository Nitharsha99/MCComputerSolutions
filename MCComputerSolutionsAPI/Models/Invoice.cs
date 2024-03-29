﻿using System.ComponentModel.DataAnnotations;

namespace MCComputerSolutionsAPI.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        public List<InvoiceItem>? InvoiceItems { get; set; }
        public double? Discount { get; set; }
        [Required]
        public double TotalAmount { get; set; }
    }
}
