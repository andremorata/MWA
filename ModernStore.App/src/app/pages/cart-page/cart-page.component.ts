import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';
import { DataService } from '../../services/data.service';
import { NumberDirective } from '../../directives/number.directive';
import { Router } from '@angular/router';

@Component({
    selector: 'app-cart-page',
    templateUrl: './cart-page.component.html',
    providers: [DataService]
})
export class CartPageComponent implements OnInit {

    public items: any[] = [];
    public discount = 0;
    public deliveryFee = 5;

    constructor(
        private cartService: CartService,
        private dataService: DataService,
        private router: Router) { }

    ngOnInit() {
        this.items = this.cartService.items;
    }

    remove(item: any) {
        this.cartService.removeItem(item.product.id);
    }

    getSubTotal(): number {
        return this.cartService.getSubTotal();
    }

    getTotal(): number {
        return (this.getSubTotal() + this.deliveryFee - this.discount);
    }

    getTotalItems() {
        return this.cartService.getTotalItems();
    }

    checkQuantity(item) {
        if (item.quantity < 1) {
            item.quantity = 1;
        }
    }

    checkout() {
        const user = JSON.parse(localStorage.getItem('mws.user'));
        const data = {
            customer: user.id,
            deliveryFee: this.deliveryFee,
            discount: this.discount,
            items: []
        };

        for (const i of this.cartService.items) {
            data.items.push({
                product: i.product.id,
                quantity: i.quantity
            });
        }

        this.dataService
            .createOrder(data)
            .subscribe(result => {
                alert('Pedido criado com sucesso!');
                this.cartService.clear();
                this.router.navigateByUrl('/home');
            }, error => {
                console.log(error);
            });
    }

}
