import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from './Component/main-page/main-page.component';
import { NewInvoiceComponent } from './Component/new-invoice/new-invoice.component';

const routes: Routes = [
  {path: '', component: MainPageComponent},
  {path:'new_invoice', component: NewInvoiceComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
