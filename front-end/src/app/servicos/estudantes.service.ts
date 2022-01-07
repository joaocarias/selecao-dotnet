import { IEstudante } from './../interface/iestudante';
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class EstudantesService {

  url = "https://localhost:44376/api/Estudante";

  constructor(private httpClient: HttpClient){ }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  public obterTodos(): Observable<IEstudante[]>{
    return this.httpClient.get<IEstudante[]>(this.url +'/obter-todos')
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  public obter(id: string): Observable<IEstudante>{
    return this.httpClient.get<IEstudante>(this.url +'/obter/id='+id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  postEstudante(estudante: IEstudante): Observable<IEstudante>{
    return this.httpClient.post<IEstudante>(this.url + '/novo', JSON.stringify(estudante), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  updateEstudante(estudante: IEstudante): Observable<IEstudante>{
    return this.httpClient.put<IEstudante>(this.url + '/' + estudante.id, JSON.stringify(estudante), this.httpOptions )
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
