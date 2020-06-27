import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService, ApiResult } from '../base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ItemService extends BaseService {
  constructor(
    httpClient: HttpClient,
    @Inject('API_URL') apiUrl: string) {
    super(httpClient, apiUrl);
  }

  getData<ApiResult>(
    pageIndex: number,
    pageSize: number,
    sortColumn: string,
    sortOrder: string,
    filterColumn: string,
    filterQuery: string
  ): Observable<ApiResult> {
    const url = this.apiUrl + 'api/Items';
    let params = new HttpParams()
      .set("pageIndex", pageIndex.toString())
      .set("pageSize", pageSize.toString())
      .set("sortColumn", sortColumn)
      .set("sortOrder", sortOrder);
    if (filterQuery) {
      params = params
        .set("filterColumn", filterColumn)
        .set("filterQuery", filterQuery);
    }
    params = params
      .set("api-version", "1.0");
    return this.httpClient.get<ApiResult>(url, { params });
  }

  get<Item>(id: number) {
    const url = this.apiUrl + "api/Items/" + id;
    return this.httpClient.get<Item>(url);
  }


  put<Item>(item): Observable<Item> {
    const url = this.apiUrl + "api/Items/" + item.id;
    return this.httpClient.put<Item>(url, item);
  }

  post<Item>(item): Observable<Item> {
    const url = this.apiUrl + "api/Items/";
    return this.httpClient.post<Item>(url, item);
  }


  getCountries<ApiResult>(
    pageIndex: number,
    pageSize: number,
    sortColumn: string,
    sortOrder: string,
    filterColumn: string,
    filterQuery: string
  ): Observable<ApiResult> {
    const url = this.apiUrl + 'api/Countries';
    let params = new HttpParams()
      .set("pageIndex", pageIndex.toString())
      .set("pageSize", pageSize.toString())
      .set("sortColumn", sortColumn)
      .set("sortOrder", sortOrder);
    if (filterQuery) {
      params = params
        .set("filterColumn", filterColumn)
        .set("filterQuery", filterQuery);
    }
    return this.httpClient.get<ApiResult>(url, { params });
  }
}
