import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { Product } from 'src/app/Interfaces/Product.interface';
import { ProductService } from 'src/app/Services/product.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { CreateProductModalComponent } from './create-product-modal/create-product-modal.component';

@Component({
    selector: 'app-products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit, OnDestroy {
    private dataSubscription: Subscription = Subscription.EMPTY;
    productsList: Product[] = [];
    displayedColumns: string[] = ['Name', 'Price'];
    dataSource = new MatTableDataSource<Product>();
    @ViewChild(MatPaginator) paginator!: MatPaginator;
    @ViewChild(MatSort) sort!: MatSort;

    constructor(
        private _productService: ProductService,
        public dialog: MatDialog
    ) { }

    ngOnInit(): void {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        this.getProducts();
    }

    getProducts() {
        this.dataSubscription = this._productService.getProducts().subscribe(result => {
            this.productsList = result;
            this.recargarTabla();
        })
    }

    addProduct() {
        const dialogRef = this.dialog.open(CreateProductModalComponent, {
            width: '300px'
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result) {
                // Añadir el nuevo producto a la lista
                let request: Product = {
                    name: result.name,
                    price: result.price
                }
                this._productService.addProduct(request).subscribe(result => {
                    this.getProducts();
                })
            }
        });
    }

    recargarTabla() {
        this.dataSource = new MatTableDataSource<Product>(this.productsList);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }

    ngOnDestroy(): void {
        if (this.dataSubscription) {
          this.dataSubscription.unsubscribe();
        }
    }
}
