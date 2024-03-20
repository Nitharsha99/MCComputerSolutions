using Azure.Core;
using MCComputerSolutionsAPI.DbConnection;
using MCComputerSolutionsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MCComputerSolutionsAPI.Services
{
    public class InvoiceService
    {
        private readonly DatabaseContext _databaseContext;

        public InvoiceService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Invoice> GetAllInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();

            invoices = _databaseContext.Invoices.ToList();

            return invoices;
        }

        public Product GetProductById(int id)
        {
            Product product = new Product();

            product = _databaseContext.Products.FirstOrDefault(x => x.ProductId == id);

            if(product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not found");
            }

        }

        public Invoice GenerateNewInvoice(GeneratingInvoice invoice)
        {


            var newInvoice = new Invoice
            {
                CustomerName = invoice.CustomerName,
                TransactionDate = DateTime.UtcNow,
                Discount = invoice.Discount ?? 0,
                //InvoiceItems = invoice.Items.Select(item => GetProductById(item.ParchasedProductId)).ToList(),
                TotalAmount = CalculateTotalAmount(invoice),
            };


            return newInvoice;
        }

        public double CalculateTotalAmount(GeneratingInvoice invoice)
        {
            double totalAmount = 0;

            foreach (var item in invoice.Items)
            {
                var product = GetProductById(item.ParchasedProductId);
                decimal itemPrice = product.Price ?? 0;

                decimal subTotal = itemPrice * item.Quantity;

                totalAmount += (double)subTotal;
            }

            
            if(invoice.Discount != 0)
            {
                double dicountAmount = (double)(totalAmount * invoice.Discount) / 100;
                totalAmount = totalAmount - dicountAmount;
            }

            return totalAmount;
        }

        public Invoice GetInvoice()
        {
            var latestInvoice = _databaseContext.Invoices.OrderByDescending(i => i.InvoiceId).FirstOrDefault();

            if (latestInvoice != null)
            {
                return latestInvoice;
            }
            else
            {
                throw new Exception("Invoice not found");
            }
        }
    }
}
