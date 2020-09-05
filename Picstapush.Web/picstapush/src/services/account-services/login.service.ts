import { AxiosInstance, AxiosResponse } from "axios";
import LoginModel from "@/models/login-model";
import Token from "@/models/token-model";

export default class LoginService {
  constructor(private http: AxiosInstance) {}

  public async login(credentials: LoginModel): Promise<AxiosResponse<Token>> {
    return await this.http.post<Token>("api/login/submit", credentials);
  }
}
