import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ICurso } from '../interface/icurso';
import { Observable, throwError } from 'rxjs';
import { retry, catchError} from 'rxjs/operators';
import { Globals } from '../globals';

@Injectable({
  providedIn: 'root'
})

export class CursosService {

  url = this.globals.API_URL + "/Curso";

  constructor(private httpClient: HttpClient, private globals: Globals){ }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  public obterTodos(): Observable<ICurso[]>{
    return this.httpClient.get<ICurso[]>(this.url +'/obter-todos')
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  postCurso(curso: ICurso): Observable<ICurso>{
    return this.httpClient.post<ICurso>(this.url + '/novo', JSON.stringify(curso), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  handleError(error: HttpErrorResponse){
    let errorMessage = '';
    if(error.error instanceof ErrorEvent){
      errorMessage = error.error.message;
    }else{
      errorMessage = `Código do erro: ${error.status}, `+ `mensagem: ${error.message}`;
    }

    console.log(errorMessage);
    return throwError(errorMessage);
  }

}
