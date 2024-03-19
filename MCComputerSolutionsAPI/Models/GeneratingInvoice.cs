namespace MCComputerSolutionsAPI.Models
{
    public class GeneratingInvoice
    {
        public string CustomerName { get; set; }
        public List<ParchasedItem> Items { get; set;}

        public double? Discount { get; set; }
    }

    public class ParchasedItem
    {
        public int ParchasedProductId { get; set; }
        public int Quantity { get; set; }
    }
}
