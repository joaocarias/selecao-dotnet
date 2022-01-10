import { ICurso } from './icurso';
import { IEstudante } from "./iestudante";

export interface IMatricula {
  id: string;
  estudanteId: string;
  estudante: IEstudante;
  cursoId: string;
  curso: ICurso;
  dataCadastro: string;
}


