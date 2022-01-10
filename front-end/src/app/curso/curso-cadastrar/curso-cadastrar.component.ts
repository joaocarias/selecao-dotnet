import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ICurso } from 'src/app/interface/icurso';
import { CursosService } from 'src/app/servicos/cursos.service';

@Component({
  selector: 'app-curso-cadastrar',
  templateUrl: './curso-cadastrar.component.html',
  styleUrls: ['./curso-cadastrar.component.scss']
})
export class CursoCadastrarComponent implements OnInit {

  curso = {} as ICurso;

  constructor(private router: Router, private cursosService: CursosService) { }

  ngOnInit(): void {
  }

  saveCurso(form: NgForm){

      this.cursosService.postCurso(this.curso).subscribe(() => {
        this.cleanForm(form);
      })

  }

  cleanForm(form: NgForm){
    form.resetForm;
    this.curso = {} as ICurso;

    this.router.navigateByUrl("/cursos")
  }


}
