import { ICartao } from './../../interface/icartao';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CartoesService } from 'src/app/servicos/cartoes.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-cartao-cadastrar',
  templateUrl: './cartao-cadastrar.component.html',
  styleUrls: ['./cartao-cadastrar.component.scss']
})
export class CartaoCadastrarComponent implements OnInit {

  cartao = {} as ICartao;

  constructor(
    private activatedroute: ActivatedRoute,
    private router: Router,
    private cartoesService: CartoesService) { }

  ngOnInit(): void {
    this.activatedroute.paramMap.subscribe(params => {
      console.log(params);
      var guid = params.get('guid');
       this.cartao.estudanteId = guid+"";
     });
  }

  save(form: NgForm){

    this.cartoesService.postCadastro(this.cartao).subscribe(() => {
      this.cleanForm(form);
    })

  }

cleanForm(form: NgForm){
  form.resetForm;
  var estudanteId = this.cartao.estudanteId;
  this.cartao = {} as ICartao;
  this.router.navigateByUrl("/estudantes/"+ estudanteId);
}

}
