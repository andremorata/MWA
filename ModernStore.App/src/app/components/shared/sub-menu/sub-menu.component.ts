import { Component, OnInit } from '@angular/core';
import { CartService } from '../../../services/cart.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-sub-menu',
    templateUrl: './sub-menu.component.html'
})
export class SubMenuComponent implements OnInit {
    public totalItems = 0;
    public user = '';

    constructor(private cartService: CartService, private route: Router) {
        this.cartService.cartChange.subscribe(
            (data) => {
                this.totalItems = this.cartService.getTotalItems();
            });

        const user = JSON.parse(localStorage.getItem('mws.user'));
        if (user) {
            this.user = user.name;
        }
        this.cartService.load();
    }

    ngOnInit() {
    }

    logoff() {
        localStorage.removeItem('mws.token');
        localStorage.removeItem('mws.user');
        this.route.navigateByUrl('/');
    }

}
