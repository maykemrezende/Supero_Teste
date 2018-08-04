import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { TarefaService, TarefaConcluidaDirective } from './shared';
import { TarefaListarComponent } from './listar';
import { TarefaCadastroComponent } from './cadastro';
import { TarefasEdicaoComponent } from './edicao';


@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  declarations: [
    TarefaListarComponent,
    TarefaCadastroComponent,
    TarefasEdicaoComponent,
    TarefaConcluidaDirective
  ],
  providers: [
    TarefaService
  ]
})
export class TarefasModule { }
