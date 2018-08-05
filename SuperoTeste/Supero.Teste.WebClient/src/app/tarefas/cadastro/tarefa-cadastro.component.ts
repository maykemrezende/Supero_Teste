import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm} from '@angular/forms';

import { TarefaService, Tarefa } from '../shared';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-tarefa-cadastro',
  templateUrl: './tarefa-cadastro.component.html',
  styleUrls: ['./tarefa-cadastro.component.css']
})
export class TarefaCadastroComponent implements OnInit {

  @ViewChild('tarefaForm') tarefaForm: NgForm;
  tarefa: Tarefa;

  constructor(private tarefaService: TarefaService,
     private router: Router) { }

  ngOnInit() {
    this.tarefa = new Tarefa();
  }

  salvarTarefa(): void {
    if (this.tarefaForm.form.valid) {
      this.tarefaService.criaTarefa(this.tarefa)
        .toPromise()
        .then(data => alert("Tarefa incluída com sucesso."))
        .catch((data: HttpErrorResponse) => alert(data.error.Message));      
           
    }
  }

}
