import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { response } from './models/response';
import { newProduct } from './models/newProduct';

@Injectable({
  providedIn: 'root'
})
export class ShoppingService {
  private apiBaseUrl = "http://localhost:5120/api/Shopping/";
  httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  }
  constructor(public httpClient:HttpClient) {}

  getProducts() : Observable<response>{
    return this.httpClient.get<response>(this.apiBaseUrl+"GetProducts");
  }

  addProduct(product:newProduct) : Observable<response>{
    return this.httpClient.post<response>(this.apiBaseUrl+"AddProducts", JSON.stringify(product), this.httpOptions);
  }

  getProduct(id:number){
    return this.httpClient.get<response>(this.apiBaseUrl+"GetProduct?Id="+id);
  }
}
