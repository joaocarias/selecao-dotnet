import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ICurso } from '../interface/icurso';
import { CursosService } from '../servicos/cursos.service';

@Component({
  selector: 'app-curso',
  templateUrl: './curso.component.html',
  styleUrls: ['./curso.component.scss']
})
export class CursoComponent implements OnInit {

  estudate = {} as ICurso;
  lista: ICurso[] = [];

  constructor(private router: Router, private cursosService: CursosService) { }

  ngOnInit(): void {
    this.obterTodos();
  }

  obterTodos() {
    this.cursosService.obterTodos().subscribe((cursos: ICurso[]) => {
        this.lista = cursos;
      }
    )
  }
}
