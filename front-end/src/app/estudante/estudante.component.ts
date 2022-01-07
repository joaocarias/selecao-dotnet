import { IEstudante } from './../interface/iestudante';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EstudantesService } from '../servicos/estudantes.service';

@Component({
  selector: 'app-estudante',
  templateUrl: './estudante.component.html',
  styleUrls: ['./estudante.component.scss']
})

export class EstudanteComponent implements OnInit {

  estudate = {} as IEstudante;
  lista: IEstudante[] = [];
  flagListaVazia: Boolean = false;

  constructor(private router: Router, private estudantesService: EstudantesService) { }

  ngOnInit(): void {
    this.obterTodos()
  }

  obterTodos() {
    this.estudantesService.obterTodos().subscribe((estudates: IEstudante[]) => {
        this.lista = estudates;
      }
    )
  }

  editEstudante(estudante: IEstudante){}

  deleteEstudante(estudante: IEstudante){}

}
