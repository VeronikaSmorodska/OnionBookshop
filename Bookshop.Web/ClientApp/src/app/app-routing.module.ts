import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GetAllBooksComponent } from './components/get-all-books/get-all-books.component';


const routes: Routes = [
    { path: 'book', component: GetAllBooksComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
