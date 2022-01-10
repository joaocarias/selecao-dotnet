import { IEstudante } from './iestudante';
export interface ICartao {
  id: string;
  estudanteId: string;
  estudante: IEstudante;
  numero: string;
  nomeTitular: string;
  validade: string;
  codigo: string;
}

