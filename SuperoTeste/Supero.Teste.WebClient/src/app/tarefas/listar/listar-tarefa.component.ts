import { Component, OnInit } from '@angular/core';

import { TarefaService, Tarefa } from '../shared';

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
      .subscribe( data => {
        this.tarefas = data;
      });
  }

  excluirTarefa($event: any, tarefa: Tarefa): void {
    if (confirm('Deseja realmente excluir a tarefa "' + tarefa.titulo + '"?')) {
      this.tarefaService.excluiTarefa(tarefa).subscribe(data => this.listaTarefas());      
    }
  }

  alterarStatus(tarefa: Tarefa): void {
    this.tarefaService.concluiTarefa(tarefa).subscribe(data => this.listaTarefas());    
  }

}
