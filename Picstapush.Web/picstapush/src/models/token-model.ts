export default class Token {
    public userId!: number;
    public tokenString!: string;
    public refreshToken!: string;
    public expiresAt!: Date;
    public refreshTokenExpiresAt!: Date;
    public username!: string;
    public email!: string;
}