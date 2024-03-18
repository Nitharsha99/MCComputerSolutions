namespace MCComputerSolutionsAPI.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
        public double? Discount { get; set; }
        public double TotalAmount { get; set; }
    }
}
