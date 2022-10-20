import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DemoServiceService {
  constructor(private http: HttpClient) {}

  getItem(itemId: number) {
    return this.http.get(environment.rootURL + `/item/${itemId}`);
  }

  getAllItems(query: string) {
    return this.http.get(environment.rootURL + `/items/${query}`);
  }
}
