import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Tarefa } from './';

@Injectable()
export class TarefaService {

  constructor(private http: HttpClient) { }
  baseUrl: string = "http://localhost:64827/api/Tarefa/";

  getTarefas() {
    return this.http.get<Tarefa[]>(this.baseUrl + "RetornaTodasTarefas");
  }

  getTarefaPorId(id: number) {
    return this.http.get<Tarefa>(this.baseUrl + 'RetornaTarefaPorId/' + id);
  }

  criaTarefa(tarefa: Tarefa) {
    return this.http.put(this.baseUrl + 'AdicionaTarefa', tarefa);
  }

  atualizaTarefa(tarefa: Tarefa) {
    return this.http.put(this.baseUrl + 'AtualizaTarefa', tarefa);
  }

  excluiTarefa(tarefa: Tarefa) {
    return this.http.delete(this.baseUrl + 'ExcluiTarefa/' + tarefa.id);
  }

  concluiTarefa(tarefa: Tarefa) {
    return this.http.get<Tarefa>(this.baseUrl + 'AlterarStatusTarefa/' + tarefa.id + '/' + true);
  }

}
