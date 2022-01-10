import { IMatricula } from './../../interface/imatricula';
import { IEmail } from './../../interface/iemail';
import { CartoesService } from './../../servicos/cartoes.service';
import { ICartao } from './../../interface/icartao';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ICurso } from 'src/app/interface/icurso';
import { IEstudante } from 'src/app/interface/iestudante';
import { EstudantesService } from 'src/app/servicos/estudantes.service';
import { PagamentosService } from 'src/app/servicos/pagamentos.service';
import { IPagamento } from 'src/app/interface/ipagamento';
import { EmailsService } from 'src/app/servicos/emails.service';
import { MatriculasService } from 'src/app/servicos/matriculas.service';

@Component({
  selector: 'app-estudante-detalhar',
  templateUrl: './estudante-detalhar.component.html',
  styleUrls: ['./estudante-detalhar.component.scss']
})
export class EstudanteDetalharComponent implements OnInit {

  guid = "";
  estudante = {} as IEstudante;

  listaCurso: ICurso[] = [];
  flagListaCursoVazia: Boolean = false;

  listaCartaoCredito: ICartao[] = [];
  listaPagamento: IPagamento[] = [];
  listaEmail: IEmail[] = [];
  listaMatricula: IMatricula[] = [];

  constructor(
        private activatedroute: ActivatedRoute,
        private _router:Router,
        private estudantesService:EstudantesService,
        private cartoesService: CartoesService,
        private pagamentosService: PagamentosService,
        private emailsService: EmailsService,
        private matriculasService: MatriculasService
      ) { }

  ngOnInit(): void {
    this.activatedroute.paramMap.subscribe(params => {
       console.log(params);
       var guid = params.get('guid');
        this.guid = guid+"";
      });

      this.obter(this.guid);

      this.obterCartoesCreditos(this.guid);
      this.obterPagamentos(this.guid);
      this.obterMatriculas(this.guid)
    }

    obter(guid: string){
      this.estudantesService.obter(guid).subscribe((estudante: IEstudante) => {
        this.obterEmails(estudante.email);
        this.estudante = estudante;
      });
    }

    obterCartoesCreditos(guid: string){
      this.cartoesService.obterCartoesPorEstudante(guid).subscribe((cartoes: ICartao[]) => {
        this.listaCartaoCredito = cartoes;
      });
    }

    obterPagamentos(guid: string){
      this.pagamentosService.obterPorEstudante(guid).subscribe((pagamentos: IPagamento[]) => {
        this.listaPagamento = pagamentos;
      });
    }

    obterEmails(destinatario: string){
      this.emailsService.obterPorDestinatario(destinatario).subscribe((emails: IEmail[]) => {
        this.listaEmail = emails;
      });
    }

    obterMatriculas(guid: string){
      this.matriculasService.obterPorEstudante(guid).subscribe((matriculas: IMatricula[]) => {
        this.listaMatricula = matriculas;
      });
    }


}
