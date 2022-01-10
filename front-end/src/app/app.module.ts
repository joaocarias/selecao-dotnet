import { MatriculasService } from 'src/app/servicos/matriculas.service';
import { PagamentosService } from 'src/app/servicos/pagamentos.service';
import { EmailsService } from './servicos/emails.service';
import { CartoesService } from './servicos/cartoes.service';
import { Globals } from './globals';
import { CursosService } from './servicos/cursos.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ActivatedRoute, RouterModule } from '@angular/router';

import { appRoutes } from './route/app.routes';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { EstudanteComponent } from './estudante/estudante.component';
import { ErrorComponent } from './error/error.component';
import { HomeComponent } from './home/home.component';
import { CursoComponent } from './curso/curso.component';
import { EstudanteCadastrarComponent } from './estudante/estudante-cadastrar/estudante-cadastrar.component';
import { EstudantesService } from './servicos/estudantes.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { EstudanteDetalharComponent } from './estudante/estudante-detalhar/estudante-detalhar.component';
import { CursoCadastrarComponent } from './curso/curso-cadastrar/curso-cadastrar.component';
import { CartaoCadastrarComponent } from './cartao/cartao-cadastrar/cartao-cadastrar.component';
import { PagamentoCadastrarComponent } from './pagamento/pagamento-cadastrar/pagamento-cadastrar.component';
import { MatriculaCadastrarComponent } from './matricula/matricula-cadastrar/matricula-cadastrar.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    EstudanteComponent,
    ErrorComponent,
    HomeComponent,
    CursoComponent,
    EstudanteCadastrarComponent,
    EstudanteDetalharComponent,
    CursoCadastrarComponent,
    CartaoCadastrarComponent,
    PagamentoCadastrarComponent,
    MatriculaCadastrarComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule
  ],

  providers: [
    EstudantesService,
    CursosService,
    CartoesService,
    EmailsService,
    PagamentosService,
    MatriculasService,
    Globals
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
