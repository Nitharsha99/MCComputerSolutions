import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/Model/Invoice';
import { InvoiceService } from 'src/app/Service/invoice.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit{

  invoices: Invoice[] = [];

  constructor(private invoiceService: InvoiceService){}

  ngOnInit(): void {
    this.invoiceService.GetAllInvoices().subscribe((res:Invoice[]) => {
      this.invoices = res;
      console.log(res);
    })
  }

}
