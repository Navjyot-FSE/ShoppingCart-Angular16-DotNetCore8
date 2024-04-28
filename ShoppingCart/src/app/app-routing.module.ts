import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AddProductComponent } from './add-product/add-product.component';
import { ListProductComponent } from './list-product/list-product.component';
import { AppComponent } from './app.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

const routes: Routes = [
  {path : "Home", component : HomeComponent},
  {path : "AddProduct", component : AddProductComponent},
  {path : "ListPorducts", component:ListProductComponent},
  {path : "ProductDetails/:Id", component:ProductDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
