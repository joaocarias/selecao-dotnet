import { IPagamento } from './../interface/ipagamento';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Globals } from '../globals';
import { Observable } from 'rxjs/internal/Observable';
import { throwError } from 'rxjs/internal/observable/throwError';
import { catchError, retry } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PagamentosService {

  constructor(private httpClient: HttpClient, private globals: Globals){ }

  url = this.globals.API_URL + "/Pagamento";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }


postCadastro(novo: IPagamento): Observable<IPagamento>{
  return this.httpClient.post<IPagamento>
    (this.url + '/novo', JSON.stringify(novo), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
}

obterPorEstudante(id: string): Observable<IPagamento[]>
  {
    return this.httpClient.get<IPagamento[]>
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
