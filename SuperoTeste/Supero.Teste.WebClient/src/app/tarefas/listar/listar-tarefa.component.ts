import { Component, OnInit } from '@angular/core';

import { TarefaService, Tarefa } from '../shared';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-listar-tarefa',
  templateUrl: './listar-tarefa.component.html',
  styleUrls: ['./listar-tarefa.component.css']
})
export class TarefaListarComponent implements OnInit {

  tarefas: Tarefa[];

  constructor(private tarefaService: TarefaService) { }

  ngOnInit() {
    this.listaTarefas();
  }

  listaTarefas() {
    this.tarefaService.getTarefas()
      .toPromise()
      .then( data => {
        this.tarefas = data;
      });
  }

  excluirTarefa($event: any, tarefa: Tarefa): void {
    if (confirm('Deseja realmente excluir a tarefa "' + tarefa.titulo + '"?')) {
      this.tarefaService.excluiTarefa(tarefa).toPromise()
      .then(data => this.listaTarefas())
      .catch((data: HttpErrorResponse) => alert(data.error.Message));      
    }
  }

  alterarStatus(tarefa: Tarefa): void {
    this.tarefaService.concluiTarefa(tarefa).toPromise()
    .then(data => this.listaTarefas())
    .catch((data: HttpErrorResponse) => alert(data.error.Message));    
  }

}
