import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
    selector: 'app-create-product-modal',
    templateUrl: './create-product-modal.component.html',
    styleUrls: ['./create-product-modal.component.scss']
})
export class CreateProductModalComponent implements OnInit {
    newProduct = {
        name: '',
        price: null
      };
    constructor(
        public dialogRef: MatDialogRef<CreateProductModalComponent>
    ) { }

    ngOnInit(): void { }

    onAdd(): void {
        this.dialogRef.close(this.newProduct);
    }

    onCancel(): void {
        this.dialogRef.close();
    }
}
