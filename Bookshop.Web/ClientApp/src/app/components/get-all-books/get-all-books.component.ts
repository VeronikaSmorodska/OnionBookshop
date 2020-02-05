import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { Book } from 'src/app/viewModels/book';

@Component({
  selector: 'app-get-all-books',
  templateUrl: './get-all-books.component.html',
  styleUrls: ['./get-all-books.component.css']
})
export class GetAllBooksComponent implements OnInit {
public books:Book[];
  constructor(private bookService: BookService) { }

  ngOnInit() {
    this.getAllBooks();
  }
  getAllBooks()
  {
    debugger;
    this.bookService.getAllCubes().subscribe(books=>{
      this.books=books;
    })
  }
}
