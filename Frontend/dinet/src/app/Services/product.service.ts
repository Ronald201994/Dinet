import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Product } from '../Interfaces/Product.interface';
import { map } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class ProductService {
    BaseApi: string = 'https://localhost:44325/api';
    baseUrl: string = 'products';
    constructor(
        private _http: HttpClient
    ) {}

    getProducts() {
        return this._http.get<Product[]>(`${this.BaseApi}/${this.baseUrl}`).pipe(
            map((result: Product[]) => {
                return result;
            })
        )
    }

    addProduct(request: Product) {
        return this._http.post<number>(`${this.BaseApi}/${this.baseUrl}`, request).pipe(
            map((result: number) => {
                return result;
            })
        )
    }
}