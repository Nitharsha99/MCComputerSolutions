namespace MCComputerSolutionsAPI.Models
{
    public class ResponseInvoiceData
    {
        public Invoice? NewInvoice { get; set; }
        public List<ParchasedItem>? ParchasedData { get; set; }
    }
}
