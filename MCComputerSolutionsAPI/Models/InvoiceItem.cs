namespace MCComputerSolutionsAPI.Models
{
    public class InvoiceItem
    {
        public int ItemId { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = new Invoice();
        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }

    }
}
