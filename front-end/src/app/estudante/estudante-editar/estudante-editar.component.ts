import { IEstudante } from './../../interface/iestudante';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EstudantesService } from 'src/app/servicos/estudantes.service';

@Component({
  selector: 'app-estudante-editar',
  templateUrl: './estudante-editar.component.html',
  styleUrls: ['./estudante-editar.component.scss']
})
export class EstudanteEditarComponent implements OnInit {

  estudante = {} as IEstudante;

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private estudantesService: EstudantesService) { }

  ngOnInit(): void {
    var id = this.activatedRoute.snapshot.paramMap.get("id");
    if(id?.length)
      this.obterEstudante(id);
  }

  obterEstudante(id: string) {
    this.estudantesService.obter(id).subscribe((estudante: IEstudante) => {
        this.estudante = estudante;
      }
    )
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

    this.router.navigateByUrl("/estudantes");

  }


}
