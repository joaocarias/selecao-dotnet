import { ICartao } from './../interface/icartao';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from '../globals';
import { catchError, Observable, retry, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartoesService {

  constructor(private httpClient: HttpClient, private globals: Globals){ }

  url = this.globals.API_URL + "/CartaoCredito";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  postCadastro(novo: ICartao): Observable<ICartao>{
    return this.httpClient.post<ICartao>
      (this.url + '/novo', JSON.stringify(novo), this.httpOptions)
        .pipe(
          retry(2),
          catchError(this.handleError)
        );
  }

  obterCartoesPorEstudante(id: string): Observable<ICartao[]>
  {
    return this.httpClient.get<ICartao[]>
        (this.url + '/obter-cartoes-creditos-por-estudante/?estudanteId='+id)
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
