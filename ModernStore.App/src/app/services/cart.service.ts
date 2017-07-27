import { Injectable } from '@angular/core';
import { Observer } from 'rxjs/Observer';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CartService {

    public items: any[] = [];
    cartChange: Observable<any>;
    cartChangeObserver: Observer<any>;

    constructor() {
        this.cartChange = new Observable((observer: Observer<any>) => {
            this.cartChangeObserver = observer;
        });
    }

    addItem(item) {
        this.load();
        if (this.hasItem(item.product.id)) {
            this.updateQuantity(item.product.id, 1);
        } else {
            this.items.push(item);
        }
        localStorage.setItem('mws.cart', JSON.stringify(this.items));
        this.cartChangeObserver.next(this.items);
        console.log(item.product.id);
    }

    removeItem(id) {
        for (const item of this.items) {
            if (item.product.id === id) {
                const index = this.items.indexOf(item);
                this.items.splice(index, 1);
            }
        }
        this.save();
        this.cartChangeObserver.next(this.items);
    }

    hasItem(id): boolean {
        for (const i of this.items) {
            if (i.product.id === id) {
                return true;
            }
            return false;
        }
    }

    getItem(): any[] {
        const data = localStorage.getItem('mws.cart');
        if (data) {
            this.items = JSON.parse(data);
        }
        this.cartChangeObserver.next(this.items);
        return this.items;
    }

    updateQuantity(id, quantity) {
        for (const i of this.items) {
            if (i.product.id === id) { i.quantity += +quantity; }
        }
        this.cartChangeObserver.next(this.items);
    }

    save() {
        localStorage.setItem('mws.cart', JSON.stringify(this.items));
    }

    load() {
        const data = localStorage.getItem('mws.cart');
        if (data) {
            this.items = JSON.parse(data);
        }
        this.cartChangeObserver.next(this.items);
    }

    getSubTotal(): number {
        let result = 0;
        for (const i of this.items) {
            result += +(+i.product.price * +i.quantity);
        }
        this.cartChangeObserver.next(this.items);
        return result;
    }

    clear() {
        this.items = [];
        localStorage.removeItem('mws.cart');
        this.cartChangeObserver.next(this.items);
    }

    getTotalItems(): number {
        let result = 0;
        for (const i of this.items) {
            result += +i.quantity;
        }
        return result;
    }
}
