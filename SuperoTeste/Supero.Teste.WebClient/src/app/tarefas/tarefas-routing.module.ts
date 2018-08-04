import { Routes } from '@angular/router';

import { TarefaListarComponent } from './listar';
import { TarefaCadastroComponent } from './cadastro';
import { TarefasEdicaoComponent } from './edicao';

export const TarefaRoutes: Routes = [
    {
        path: 'tarefas',
        redirectTo: 'tarefas/listar'
    },
    {
        path: 'tarefas/listar',
        component: TarefaListarComponent
    },
    {
        path: 'tarefas/cadastro',
        component: TarefaCadastroComponent
    },
    {
        path: 'tarefas/edicao/:id',
        component: TarefasEdicaoComponent
    }
];