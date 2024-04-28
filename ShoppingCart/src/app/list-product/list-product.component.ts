import { Component, OnInit } from '@angular/core';
import { ShoppingService } from '../shopping.service';
import { response } from '../models/response';
import { product } from '../models/product';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnInit {
  products:product[] = [];
  res!: response;
  constructor(private shoppingService:ShoppingService){}
  
  ngOnInit(): void {
    this.refreshProducts();
  }

  refreshProducts(){
    this.shoppingService.getProducts().subscribe((data:response)=>{
      this.res=data;
      this.products = data.data;
      console.log(data);
    })
  }
}
