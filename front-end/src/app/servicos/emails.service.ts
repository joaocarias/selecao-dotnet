import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, retry, throwError } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { Globals } from '../globals';
import { IEmail } from '../interface/iemail';

@Injectable({
  providedIn: 'root'
})
export class EmailsService {

  constructor(private httpClient: HttpClient, private globals: Globals){ }

  url = this.globals.API_URL + "/Email";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  obterPorDestinatario(id: string): Observable<IEmail[]>
  {
    return this.httpClient.get<IEmail[]>
        (this.url + '/obter-por-destinatario/?destinatario='+id)
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
