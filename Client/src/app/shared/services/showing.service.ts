import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Showing } from '../models/showing';
import { ShowingParams } from '../models/showingParams';
import { IPagination } from '../models/pagination';
import { environment } from '../../../environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShowingService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getShowings(showingParams: ShowingParams) {
    let params = new HttpParams();
    params = params.append('pageIndex', showingParams.pageNumber.toString());
    params = params.append('pageSize', showingParams.pageSize.toString());
    var showings = this.http.get<IPagination>(this.baseUrl + 'showings', { params })
      .pipe(
        map((response: IPagination) => {
          response.data.map(showing => new Showing(showing));
          return response;
        })
      );
    return showings;
  }

  getTodaysShowing() {
    return this.http.get<Showing>(this.baseUrl + 'showings/today')
      .pipe(
       // map((response: Showing) => { return new Showing(response) })
      );
  }

  getTommorowShowing() {
    return this.http.get<Showing>(this.baseUrl + 'showings/tommorow')
      .pipe(
       // map((response: Showing) => { return new Showing(response) })
      );
  }
}
