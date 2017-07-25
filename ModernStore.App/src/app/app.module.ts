import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

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
import { LoginPageComponent } from './Pages/login-page/login-page.component';
import { SignupPageComponent } from './Pages/signup-page/signup-page.component';
import { CartPageComponent } from './Pages/cart-page/cart-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HeadBarComponent,
    SubMenuComponent,
    ProductListComponent,
    FooterComponent,
    HomePageComponent,
    LoginPageComponent,
    SignupPageComponent,
    CartPageComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
