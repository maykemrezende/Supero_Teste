using Supero.Teste.Entidades;
using Supero.Teste.Entidades.Enum;
using Supero.Teste.Excecoes.TarefaExceptions;
using Supero.Teste.QueryEspecificacoes.TarefaEspecificacoes;
using Supero.Teste.Repository.Interface.RepositorioBase;
using Supero.Teste.Repository.Interface.UnitOfWork;
using Supero.Teste.Service.Interface.Interfaces;
using Supero.Teste.Validacoes.Tarefas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supero.Teste.Service.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepositorioBase<Tarefa> tarefaRepositorio; 

        public TarefaService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            tarefaRepositorio = unitOfWork.RetornaRepositorioDe<Tarefa>();
        }

        public bool Atualiza(Tarefa tarefa)
        {
            if (TarefaNaoNula(tarefa))
            {
                var tarefaValida = EstaValida(tarefa);

                if (tarefaValida)
                {
                    if (tarefa.EstaConcluida)
                    {
                        tarefa.DataConclusao = DateTime.Now;
                    }
                    return tarefaRepositorio.Atualiza(tarefa);
                }
            }

            throw new TarefaException(TarefaExceptionEnum.TAREFA_NULA.Codigo,
                                        TarefaExceptionEnum.TAREFA_NULA.Valor);
        }

        public bool Exclui(int id)
        {
            Tarefa tarefa = PesquisaTarefaPor(id);
            if (TarefaNaoNula(tarefa))
            {
                return tarefaRepositorio.Exclui(tarefa);
            }

            throw new TarefaException(TarefaExceptionEnum.TAREFA_NULA.Codigo,
                                        TarefaExceptionEnum.TAREFA_NULA.Valor);
        }

        public Tarefa PesquisaTarefaPor(int id)
        {
            return tarefaRepositorio
                .PesquisaPor(new EspecificacaoSelecionaTarefaPorId(id))
                .FirstOrDefault();
        }

        public IReadOnlyList<Tarefa> RetornaTodasTarefas()
        {
            return tarefaRepositorio.RetornaTodosRegistros();
        }

        public bool AlteraStatusTarefa(int id, bool status)
        {
            Tarefa tarefa = PesquisaTarefaPor(id);
            if (TarefaNaoNula(tarefa))
            {
                tarefa.EstaConcluida = status;
                return Atualiza(tarefa);
            }

            throw new TarefaException(TarefaExceptionEnum.TAREFA_NULA.Codigo,
                                        TarefaExceptionEnum.TAREFA_NULA.Valor);
        }

        public bool Salva(Tarefa tarefa)
        {
            if (TarefaNaoNula(tarefa))
            {
                var tarefaValida = EstaValida(tarefa);

                if (tarefaValida)
                {
                    return tarefaRepositorio.Salva(tarefa);
                }
            }

            throw new TarefaException(TarefaExceptionEnum.TAREFA_NULA.Codigo,
                                        TarefaExceptionEnum.TAREFA_NULA.Valor);
        }

        private bool EstaValida(Tarefa tarefa)
        {
            TarefaValidacoes tarefaValidacoes = new TarefaValidacoes();

            if (tarefaValidacoes
                .Validate(tarefa)
                .Errors.Any(e => 
                            e.ErrorCode.Equals(TarefaExceptionEnum.TITULO_VAZIO.Codigo.ToString()
                            )))
            {
                throw new TarefaException(TarefaExceptionEnum.TITULO_VAZIO.Codigo, 
                                            TarefaExceptionEnum.TITULO_VAZIO.Valor);
            }

            return true;
        }

        private bool TarefaNaoNula(Tarefa tarefa)
        {
            return tarefa != default(Tarefa);
        }
    }
}
