import { Component } from '@angular/core';
import { newProduct } from '../models/newProduct';
import { ShoppingService } from '../shopping.service';
import { product } from '../models/product';
import { response } from '../models/response';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {
  newProduct:newProduct = {
    name:"",
    price:0,
    description:""
  };
  products:product[] = [];
  res!: response;

  constructor(private shoppingService:ShoppingService){}

  addProduct(product:newProduct){
    console.log(JSON.stringify(product));
    this.shoppingService.addProduct(product).subscribe((data:response)=>{
      this.res=data;
      this.products = data.data;
      console.log(data);
    })
  }
}
