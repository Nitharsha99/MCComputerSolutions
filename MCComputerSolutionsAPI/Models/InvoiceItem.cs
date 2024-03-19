using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MCComputerSolutionsAPI.Models
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }
        [Required]
        [ForeignKey("InvoiceId")]
        public int InvoiceId { get; set; }
 
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
