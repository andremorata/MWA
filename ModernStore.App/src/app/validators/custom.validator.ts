import { FormControl } from '@angular/forms';

export class CustomValidator {
    static EmailValidator(control: FormControl) {
        const re = new RegExp([
            '^(([^<>()\\[\\]\\\.,;:\\s@"]+(\\.[^<>()\\[\\]\\\.,;:\\s@"]+)*)|(".+"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}',
            '\\\.[0-9]{1,3}\\.[0-9]{1,3}])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$'].join(''));
        if (!re.test(control.value)) {
            return {
                'E-mail inválido': true
            };
        }
        return null;
    }

    static NegativeNumberValidator(control: FormControl) {
        const value: number = control.value.toString().replace(/[^0-9]/g, '');
        if (value < 0) {
            return { 'Número inválido': true };
        }
        return null;
    }

    static ZipCodeValidator(control: FormControl) {
        const value: string = control.value.toString().replace(/[^0-9]/g, '');
        if (value.length !== 8) {
            return { 'CEP inválido': true };
        }
        return null;
    }

    static SelectValidator(control: FormControl) {
        const value: number = control.value.toString();
        if (value === 0) {
            return { 'Selecione uma opção ': true };
        }
        return null;
    }

    static ControlValueEqualsValidator(control1: FormControl, control2: FormControl) {
        const v1 = control1.value.toString();
        const v2 = control2.value.toString();
        if (v1 !== v2) {
            return { 'Os valores nao coincidem': true };
        }
        return null;
    }
}
