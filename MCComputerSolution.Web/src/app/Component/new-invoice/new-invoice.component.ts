import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup , FormBuilder} from '@angular/forms';
import { Router } from '@angular/router';
import { GeneratedInvoice, ParchasedItem } from 'src/app/Model/GenerateInvoice';
import { Invoice } from 'src/app/Model/Invoice';
import { Product } from 'src/app/Model/Product';
import { InvoiceService } from 'src/app/Service/invoice.service';
import { ProductService } from 'src/app/Service/product.service';

@Component({
  selector: 'app-new-invoice',
  templateUrl: './new-invoice.component.html',
  styleUrls: ['./new-invoice.component.css']
})
export class NewInvoiceComponent implements OnInit{

  products: Product[] = [];
  selectedProducts: ParchasedItem[] = [];
  invoiceVisible: boolean = false;
  invoiceData!: Invoice;

  constructor(private productService: ProductService, private builder: FormBuilder, 
              private invoiceService: InvoiceService, private router: Router){
  }

  invoiceForm: FormGroup = this.builder.group({
    customerName: [''],
    discount: [0],
    items: this.builder.array([
      this.builder.group({
        parchasedProductId: [''],
        quantity: ['']
      })
    ])
  })

  get items(){
    return this.invoiceForm.get('items') as FormArray;
  }

  ngOnInit(): void {
    this.productService.GetAllProducts().subscribe((res) => {
      this.products = res;
      console.log(this.products);
    })

  }

  addProduct() {
    this.items.push(
      this.builder.group({
        parchasedProductId: [''],
        quantity: ['']
      })
    )
  }

  removeProduct(i: number){
    if(i>0){
      console.log(i);
      this.items.removeAt(i);
    }
  }

  generateInvoice(){
    const formValue = this.invoiceForm.value;
    
    if(formValue.customerName && formValue.items[0].parchasedProductId && formValue.items[0].quantity){
      alert(JSON.stringify(this.invoiceForm.value, null, 2));

      this.invoiceService.GenerateInvoice(formValue).subscribe( res => {
        this.invoiceData = res;
        console.log('response', this.invoiceData);
        this.invoiceVisible = true;
        this.invoiceForm.reset();
      })

      console.log('okk');
    }
    else{
      alert('Please fill in all fields before generating the invoice.');
    }
  }

  goToBack(){
    this.router.navigate(['']);
  }

}
