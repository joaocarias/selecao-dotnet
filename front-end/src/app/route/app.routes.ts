import { Routes } from "@angular/router";
import { AppComponent } from "../app.component";
import { EstudanteComponent } from "../estudante/estudante.component";
import { ErrorComponent } from "../error/error.component";
import { HomeComponent } from "../home/home.component";
import { CursoComponent } from "../curso/curso.component";
import { EstudanteCadastrarComponent } from "../estudante/estudante-cadastrar/estudante-cadastrar.component";

export const appRoutes: Routes = [
    { path: "", component: HomeComponent },

    { path: "estudantes", component: EstudanteComponent },
    { path: "estudantes/cadastrar", component: EstudanteCadastrarComponent },

    { path: "cursos", component: CursoComponent },
    { path: "**", component: ErrorComponent }


]
