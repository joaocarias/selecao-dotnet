import { ICartao } from './icartao';
import { IEstudante } from "./iestudante";

export interface IPagamento {
  id: string;
  estudanteId: string;
  estudante: IEstudante;
  dataPagamento: string;
  valor: number;
  cartaoCreditoId: string;
  cartaoCredito: ICartao;
 }

