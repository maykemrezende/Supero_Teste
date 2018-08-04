import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';

import { TarefaService, Tarefa } from '../shared';

@Component({
  selector: 'app-tarefas-edicao',
  templateUrl: './tarefas-edicao.component.html',
  styleUrls: ['./tarefas-edicao.component.css']
})
export class TarefasEdicaoComponent implements OnInit {

  @ViewChild('tarefaForm') tarefaForm: NgForm;
  tarefa: Tarefa;

  constructor(private tarefaService: TarefaService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    let id = +this.route.snapshot.params['id'];
    this.tarefaService.getTarefaPorId(id)
    .subscribe( data => {
      this.tarefa = data;
    });;
  }

  editarTarefa(): void {
    if (this.tarefaForm.form.valid) {
      this.tarefaService.atualizaTarefa(this.tarefa);
      this.router.navigate(['/tarefas']);
    }
  }

}
