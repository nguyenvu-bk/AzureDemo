import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DemoServiceService {
  constructor(private http: HttpClient) {}
  private baseURL = '/api/mainpage';
  getItem(itemId: number) {
    return this.http.get(environment.rootURL + this.baseURL + `/item/${itemId}`);
  }

  getAllItems() {
    return this.http.get(environment.rootURL + this.baseURL + `/items`);
  }
}
