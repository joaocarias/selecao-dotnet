import { IMatricula } from './../interface/imatricula';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from '../globals';
import { catchError, Observable, retry, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MatriculasService {

  constructor(private httpClient: HttpClient, private globals: Globals){ }

  url = this.globals.API_URL + "/Matricula";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  postCadastro(novo: IMatricula): Observable<IMatricula>{
    return this.httpClient.post<IMatricula>
      (this.url + '/matricular', JSON.stringify(novo), this.httpOptions)
        .pipe(
          retry(2),
          catchError(this.handleError)
        );
  }

  obterPorEstudante(id: string): Observable<IMatricula[]>
    {
      return this.httpClient.get<IMatricula[]>
          (this.url + '/obter-por-estudante/?estudanteId='+id)
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
