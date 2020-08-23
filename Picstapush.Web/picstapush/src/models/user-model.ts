import Token from './token-model';

export default class User {
    public username!: string;
    public email!: string;
    public id!: number;
    public token!: Token;
}