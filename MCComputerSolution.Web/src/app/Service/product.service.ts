import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Product } from '../Model/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  baseUrl = 'https://localhost:44383/api/product';

  GetAllProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(this.baseUrl);
  }
}
