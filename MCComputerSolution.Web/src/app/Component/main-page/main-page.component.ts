import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/Model/Invoice';
import { InvoiceService } from 'src/app/Service/invoice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit{

  invoices: Invoice[] = [];

  constructor(private invoiceService: InvoiceService, private router: Router){}

  ngOnInit(): void {
    this.invoiceService.GetAllInvoices().subscribe((res:Invoice[]) => {
        res.forEach(element => {
          const date = new Date(element.transactionDate);
        console.log('date', element.transactionDate);
      });
      this.invoices = res;
      console.log(res);
    })
  }

  onNavigate(){
    this.router.navigate(['/new_invoice']);
  }

}
