import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IShowing } from '../models/showing';
import { ShowingParams } from '../models/showingParams';
import { IPagination } from '../models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ShowingService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getShowings(showingParams: ShowingParams) {
    let params = new HttpParams();
    params = params.append('pageIndex', showingParams.pageNumber.toString());
    params = params.append('pageSize', showingParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'showings', { params });
  }

  getTodaysShowing() {
    return this.http.get<IShowing>(this.baseUrl + 'today');
  }

  getTommorowShowing() {
    return this.http.get<IShowing>(this.baseUrl + 'tommorow');
  }
}
