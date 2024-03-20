import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/Model/Invoice';
import { InvoiceService } from 'src/app/Service/invoice.service';
import { Router } from '@angular/router';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit{

  invoices: Invoice[] = [];
  pagedInvoices: Invoice[] = [];
  pageSize = 5; // Number of items per page
  pageSizeOptions: number[] = [5, 10, 25, 100];

  constructor(private invoiceService: InvoiceService, private router: Router){}

  ngOnInit(): void {
    this.invoiceService.GetAllInvoices().subscribe((res:Invoice[]) => {
        res.forEach(element => {
          const date = new Date(element.transactionDate);
        console.log('date', element.transactionDate);
      });
      this.invoices = res;
      console.log(res);
      this.updatePagedInvoices();
    });
  }

  onNavigate(){
    this.router.navigate(['/new_invoice']);
  }

  onPageChange(event: PageEvent) {
    const startIndex = event.pageIndex * event.pageSize;
    const endIndex = startIndex + event.pageSize;
    this.pagedInvoices = this.invoices.slice(startIndex, endIndex);
  }

  updatePagedInvoices() {
    this.pagedInvoices = this.invoices.slice(0, this.pageSize);
    console.log("pages", this.pagedInvoices);
  }

}
