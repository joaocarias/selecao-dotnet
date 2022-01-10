import { CursoCadastrarComponent } from './../curso/curso-cadastrar/curso-cadastrar.component';
import { Routes } from "@angular/router";
import { AppComponent } from "../app.component";
import { EstudanteComponent } from "../estudante/estudante.component";
import { ErrorComponent } from "../error/error.component";
import { HomeComponent } from "../home/home.component";
import { CursoComponent } from "../curso/curso.component";
import { EstudanteCadastrarComponent } from "../estudante/estudante-cadastrar/estudante-cadastrar.component";
import { EstudanteDetalharComponent } from "../estudante/estudante-detalhar/estudante-detalhar.component";
import { CartaoCadastrarComponent } from '../cartao/cartao-cadastrar/cartao-cadastrar.component';
import { PagamentoCadastrarComponent } from '../pagamento/pagamento-cadastrar/pagamento-cadastrar.component';
import { MatriculaCadastrarComponent } from '../matricula/matricula-cadastrar/matricula-cadastrar.component';

export const appRoutes: Routes = [
    { path: "", component: HomeComponent },

    { path: "estudantes", component: EstudanteComponent },
    { path: "estudantes/cadastrar", component: EstudanteCadastrarComponent },
    { path: "estudantes/:guid", component: EstudanteDetalharComponent },

    { path: "cartoes/cadastrar/:guid", component: CartaoCadastrarComponent },

    { path: "pagamentos/cadastrar/:guid", component: PagamentoCadastrarComponent },

    { path: "cursos", component: CursoComponent },
    { path: "cursos/cadastrar", component: CursoCadastrarComponent },

    { path: "matriculas/cadastrar/:guid", component: MatriculaCadastrarComponent },

    { path: "**", component: ErrorComponent },



]
