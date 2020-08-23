export default class LoginModel {
    constructor(value: Partial<LoginModel>) {
        Object.assign(this, value);
    }
    public username!: string;
    public password!: string;
}