import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../viewModels/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }
  getAllCubes(): Observable<Book[]> {
    //return this.http.get<Book[]>(`api/Book/GetAllBooks`);
  }
}
