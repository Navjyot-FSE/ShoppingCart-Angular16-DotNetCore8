import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShoppingService } from '../shopping.service';
import { response } from '../models/response'
import { product } from '../models/product';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product!:product;
  res!: response;
  constructor(private route:ActivatedRoute, private shoppingservice:ShoppingService){}

  ngOnInit(): void {
    const routeParam = this.route.snapshot.paramMap;
    const id = Number(routeParam.get("Id"));
    this.getProductById(id);
  }

  getProductById(id:number){
    this.shoppingservice.getProduct(id).subscribe((data:response)=>{
      this.res = data;
      this.product = data.data;
      console.log(data);
    });
  }

}
