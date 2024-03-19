using MCComputerSolutionsAPI.DbConnection;
using MCComputerSolutionsAPI.Models;
using MCComputerSolutionsAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace MCComputerSolutionsAPI.Controllers
{
    [Route("api/invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        private readonly InvoiceService _invoiceService;
        private readonly DatabaseContext _databaseContext;

        public InvoiceController(InvoiceService invoiceService, DatabaseContext databaseContext)
        {
           _invoiceService = invoiceService;
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoice()
        {

            List<Invoice> invoices = await _databaseContext.Invoices.Include(invoice => invoice.InvoiceItems).ToListAsync(); 

            if (invoices != null)
            {
                return Ok(invoices);
            }
            else
            {
                return BadRequest("No data");
            }
        }

        [HttpPost]
        public async Task<IActionResult> GenerateNewInvoice( GeneratingInvoice invoiceData)
        {
            try
            {

                if (invoiceData == null)
                {
                    return BadRequest("Invoice data is null");
                }
                else
                {
                    var newInvoice = _invoiceService.GenerateNewInvoice(invoiceData);

                    _databaseContext.Invoices.Add(newInvoice);

                    await _databaseContext.SaveChangesAsync();

                    Invoice latestInvoice = new Invoice(); 
                    List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
                    latestInvoice = _invoiceService.GetInvoice();

                    if(latestInvoice != null)
                    {
                        
                        foreach(var product in invoiceData.Items)
                        {
                            var productItem = _invoiceService.GetProductById(product.ParchasedProductId);

                            InvoiceItem invoiceItem = new InvoiceItem
                            {
                                InvoiceId = latestInvoice.InvoiceId,
                                ProductName = productItem.ProductName,
                                Price = (double)productItem.Price,
                                Quantity = product.Quantity
                            };

                            invoiceItems.Add(invoiceItem);
                            _databaseContext.InvoicesItems.Add(invoiceItem);
                            await _databaseContext.SaveChangesAsync();
                        }

                    }

                    newInvoice.InvoiceItems = invoiceItems;

                    //var Response = new ResponseInvoiceData
                    //{
                    //    NewInvoice = newInvoice,
                    //    ParchasedData = invoiceData.Items,
                    //};

                    return Ok(newInvoice);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
