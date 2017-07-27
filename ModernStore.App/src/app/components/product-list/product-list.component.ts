import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';
import { CartService } from '../../services/cart.service';
import { Ui } from '../../utils/ui';

@Component({
    selector: 'app-product-list',
    templateUrl: './product-list.component.html',
    providers: [DataService, Ui]
})
export class ProductListComponent implements OnInit {

    public products: any[];

    constructor(private dataService: DataService, private cartService: CartService, private ui: Ui) { }

    ngOnInit() {
        this.dataService.getProducts().subscribe(result => {
            this.products = result;
        });
    }

    addToCart(product) {
        this.ui.lock('prod-' + product.id);
        setTimeout(() => {
            this.cartService.addItem({ product: product, quantity: 1 });
            this.ui.unlock('prod-' + product.id);
        }, 1000);
    }

}
