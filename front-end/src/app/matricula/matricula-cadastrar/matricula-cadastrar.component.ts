import { ICurso } from './../../interface/icurso';
import { IMatricula } from './../../interface/imatricula';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatriculasService } from 'src/app/servicos/matriculas.service';
import { CursosService } from 'src/app/servicos/cursos.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-matricula-cadastrar',
  templateUrl: './matricula-cadastrar.component.html',
  styleUrls: ['./matricula-cadastrar.component.scss']
})
export class MatriculaCadastrarComponent implements OnInit {

  matricula = {} as IMatricula;
  listaCurso: ICurso[] = [];

  constructor(
    private activatedroute: ActivatedRoute,
    private router: Router,
    private matriculasService: MatriculasService,
    private cursosService: CursosService,
  ) { }

  ngOnInit(): void {
    this.activatedroute.paramMap.subscribe(params => {
      console.log(params);
      var guid = params.get('guid');
       this.matricula.estudanteId = guid+"";
     });

     this.obterCursos();
  }

  obterCursos(){
    this.cursosService.obterTodos().subscribe((cursos: ICurso[]) => {
      this.listaCurso = cursos;
    });
  }

  save(form: NgForm){

    this.matriculasService.postCadastro(this.matricula).subscribe(() => {
      this.cleanForm(form);
    })

  }

  cleanForm(form: NgForm){
    form.resetForm;
    var estudanteId = this.matricula.estudanteId;
    this.matricula = {} as IMatricula;
    this.router.navigateByUrl("/estudantes/"+ estudanteId);
  }

}
