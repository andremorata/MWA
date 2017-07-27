import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { CustomValidator } from '../../validators/custom.validator';
import { DataService } from '../../services/data.service';
import { Ui } from '../../utils/ui';
import { Router } from '@angular/router';


@Component({
    selector: 'app-login-page',
    templateUrl: './login-page.component.html',
    providers: [Ui, DataService]
})
export class LoginPageComponent implements OnInit {

    public form: FormGroup;
    public errors: any[] = [];

    constructor(
        private fb: FormBuilder,
        private ui: Ui,
        private dataService: DataService,
        private router: Router) {
        this.form = this.fb.group({
            username: ['', Validators.compose([
                Validators.minLength(5),
                Validators.maxLength(160),
                Validators.required
            ])],
            password: ['', Validators.compose([
                Validators.minLength(6),
                Validators.maxLength(20),
                Validators.required
            ])]
        });

        this.checkToken();
    }

    ngOnInit() {
    }

    checkToken() {
        const token = localStorage.getItem('mws.token');
        const isValid = (token !== null && this.dataService.validateToken(token));
        if (isValid) {
            this.router.navigateByUrl('/home');
        }
    }

    // checkEmail() {
    //     this.form.controls.email.disable();
    //     this.ui.lock('usernameControl');
    //     setTimeout(() => {
    //         console.log(this.form.controls.email.value);
    //         this.ui.unlock('usernameControl');
    //         this.form.controls.email.enable();
    //     }, 1000);
    // }

    showUseTerms() {
        this.ui.setActive('divTermosDeUso');
    }

    hideUseTerms() {
        this.ui.setInactive('divTermosDeUso');
    }

    submit() {
        this.ui.lock('btnSignin');
        this.dataService
            .authenticate(this.form.value)
            .subscribe(result => {
                localStorage.setItem('mws.token', result.token);
                localStorage.setItem('mws.user', JSON.stringify(result.user));
                this.errors = [];
                this.router.navigateByUrl('/home');
                this.ui.unlock('btnSignin');
            }, error => {
                this.errors = JSON.parse(error._body).errors;
                this.ui.unlock('btnSignin');
            });
    }

}
