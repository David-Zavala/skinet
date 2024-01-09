import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './models/product';
import { Pagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Skinet';
  products: Product[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<Pagination<Product[]>>('https://localhost:5001/api/products?pageSize=5,pageIndex=2').subscribe({
      next: (response) => this.products = response.data,
      error: error => console.log(error),
      complete: () => {
        console.log("Request Completed");
        console.log("extra statement");
      },
    });
  }
}
