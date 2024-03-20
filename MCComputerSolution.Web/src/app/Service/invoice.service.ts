import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Invoice } from '../Model/Invoice';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  constructor(private http: HttpClient) { }

  baseUrl = 'https://localhost:44383/api/invoice';

  GetAllInvoices(): Observable<Invoice[]>{
    return this.http.get<Invoice[]>(this.baseUrl);
  }

  GenerateInvoice(value: any): Observable<any>{
    return this.http.post<any>(this.baseUrl, value);
  }
}
