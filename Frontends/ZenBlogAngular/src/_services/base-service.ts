import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ResultDTO} from '../_models/Base/ResultDTO';

export abstract class BaseService<TResponse, TCreate, TUpdate, TResponseById> {
  protected abstract baseUrl: string;

  protected constructor(protected http: HttpClient) {
  }

  get(): Observable<ResultDTO<TResponse[]>> {
    return this.http.get<ResultDTO<TResponse[]>>(this.baseUrl);
  }

  getById(id: string): Observable<ResultDTO<TResponseById>> {
    return this.http.get<ResultDTO<TResponseById>>(`${this.baseUrl}/${id}`);
  }

  create(dto: TCreate): Observable<ResultDTO<TResponse>> {
    return this.http.post<ResultDTO<TResponse>>(this.baseUrl, dto);
  }

  update(dto: TUpdate & { id?: string }): Observable<ResultDTO<TResponse>> {
    return this.http.put<ResultDTO<TResponse>>(`${this.baseUrl}/${dto.id}`, dto);
  }

  remove(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
