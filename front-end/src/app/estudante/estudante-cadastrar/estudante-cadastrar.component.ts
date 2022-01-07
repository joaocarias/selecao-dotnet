import { IEstudante } from './../../interface/iestudante';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { EstudantesService } from 'src/app/servicos/estudantes.service';

@Component({
  selector: 'app-estudante-cadastrar',
  templateUrl: './estudante-cadastrar.component.html',
  styleUrls: ['./estudante-cadastrar.component.scss']
})
export class EstudanteCadastrarComponent implements OnInit {

  estudante = {} as IEstudante;

  constructor(private router: Router, private estudantesService: EstudantesService) { }

  ngOnInit(): void {
  }

  saveEstudante(form: NgForm){
    if(this.estudante.id !== undefined){
      this.estudantesService.updateEstudante(this.estudante).subscribe(() => {
        this.cleanForm(form);
      } )
    }else{
      this.estudantesService.postEstudante(this.estudante).subscribe(() => {
        this.cleanForm(form);
      })
    }
  }

  cleanForm(form: NgForm){
    form.resetForm;
    this.estudante = {} as IEstudante;

    this.router.navigateByUrl("/estudantes")
  }

}
