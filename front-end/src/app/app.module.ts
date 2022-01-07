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
import { EstudanteEditarComponent } from './estudante/estudante-editar/estudante-editar.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    EstudanteComponent,
    ErrorComponent,
    HomeComponent,
    CursoComponent,
    EstudanteCadastrarComponent,
    EstudanteEditarComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule
  ],

  providers: [
    EstudantesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
