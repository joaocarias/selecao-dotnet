import { CartoesService } from './../../servicos/cartoes.service';
import { ICartao } from './../../interface/icartao';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IPagamento } from 'src/app/interface/ipagamento';
import { PagamentosService } from 'src/app/servicos/pagamentos.service';

@Component({
  selector: 'app-pagamento-cadastrar',
  templateUrl: './pagamento-cadastrar.component.html',
  styleUrls: ['./pagamento-cadastrar.component.scss']
})
export class PagamentoCadastrarComponent implements OnInit {

  pagamento = {} as IPagamento;
  listaCartaoCredito: ICartao[] = [];

  constructor(
    private activatedroute: ActivatedRoute,
    private router: Router,
    private pagamentosService: PagamentosService,
    private cartoesService: CartoesService,
  ) { }

  ngOnInit(): void {
    this.activatedroute.paramMap.subscribe(params => {
      console.log(params);
      var guid = params.get('guid');
       this.pagamento.estudanteId = guid+"";
     });

     this.obterCartoesCreditos(this.pagamento.estudanteId);
  }

  obterCartoesCreditos(guid: string){
    this.cartoesService.obterCartoesPorEstudante(guid).subscribe((cartoes: ICartao[]) => {
      this.listaCartaoCredito = cartoes;
    });
  }

  save(form: NgForm){

    this.pagamentosService.postCadastro(this.pagamento).subscribe(() => {
      this.cleanForm(form);
    })

  }

cleanForm(form: NgForm){
  form.resetForm;
  var estudanteId = this.pagamento.estudanteId;
  this.pagamento = {} as IPagamento;
  this.router.navigateByUrl("/estudantes/"+ estudanteId);
}

}
