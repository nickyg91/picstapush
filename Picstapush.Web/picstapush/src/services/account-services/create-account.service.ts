import { AxiosRequestConfig, AxiosInstance, AxiosResponse } from 'axios';
import User from '@/models/user-model';
import SignupModel from '@/models/signup-model';

export default class CreateAccountService {
    constructor(private http: AxiosInstance) {

    }

    public async createAccount(user: SignupModel): Promise<AxiosResponse<User>> {
        const response = await this.http.post<User>('api/login/create', user);
        return response;
    }
}