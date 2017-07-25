import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

// routes
import { Routing, RoutingProviders } from './app.routing';

// root
import { AppComponent } from './app.component';

// shared
import { HeadBarComponent } from './components/shared/head-bar/head-bar.component';
import { SubMenuComponent } from './components/shared/sub-menu/sub-menu.component';
import { FooterComponent } from './components/shared/footer/footer.component';

// components
import { ProductListComponent } from './components/product-list/product-list.component';

// home page
import { HomePageComponent } from './pages/home-page/home-page.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { SignupPageComponent } from './pages/signup-page/signup-page.component';
import { CartPageComponent } from './pages/cart-page/cart-page.component';
import { ErrorPage404Component } from './pages/error-page404/error-page404.component';

@NgModule({
    declarations: [
        AppComponent,
        HeadBarComponent,
        SubMenuComponent,
        FooterComponent,
        ProductListComponent,
        HomePageComponent,
        LoginPageComponent,
        SignupPageComponent,
        CartPageComponent,
        ErrorPage404Component
    ],
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        Routing
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
