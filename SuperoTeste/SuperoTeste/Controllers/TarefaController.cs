using Microsoft.AspNetCore.Mvc;
using Supero.Teste.Entidades;
using Supero.Teste.Entidades.Enum;
using Supero.Teste.Excecoes.TarefaExceptions;
using Supero.Teste.Service.Interface.Interfaces;
using System;

namespace Supero.Teste.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Tarefa")]
    public class TarefaController : Controller
    {
        private readonly ITarefaService tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            this.tarefaService = tarefaService;
        }

        [HttpPut("AdicionaTarefa")]
        public IActionResult AdicionaTarefa([FromBody]Tarefa tarefa)
        {
            try
            { 
                if (tarefaService.Salva(tarefa))
                {
                    return Ok();
                }

                return BadRequest(
                    new TarefaException(TarefaExceptionEnum.ERRO_SALVAR.Codigo,
                                        TarefaExceptionEnum.ERRO_SALVAR.Valor)
                                        );
            } catch(TarefaException tex)
            {
                return BadRequest(new TarefaException(tex.Codigo, tex.Mensagem));
            }
}

        [HttpPut("AtualizaTarefa")]
        public IActionResult AtualizaTarefa([FromBody]Tarefa tarefa)
        {
            try
            {
                if (tarefaService.Atualiza(tarefa))
                {
                    return Ok();
                }

                return BadRequest(
                    new TarefaException(TarefaExceptionEnum.ERRO_ALTERAR.Codigo, 
                                        TarefaExceptionEnum.ERRO_ALTERAR.Valor)
                                        );
            } catch(TarefaException tex)
            {
                return BadRequest(new TarefaException(tex.Codigo, tex.Mensagem));
            }
        }

        [HttpDelete("ExcluiTarefa/{id}")]
        public IActionResult ExcluiTarefa(int id)
        {
            try
            {
                if (tarefaService.Exclui(id))
                {
                    return Ok();
                }

                return BadRequest(
                    new TarefaException(TarefaExceptionEnum.ERRO_EXCLUIR.Codigo,
                                        TarefaExceptionEnum.ERRO_EXCLUIR.Valor)
                                        );
            } catch (TarefaException tex)
            {
                return BadRequest(new TarefaException(tex.Codigo, tex.Mensagem));
            } catch (Exception ex)
            {
                return BadRequest(new Exception(ex.Message));
            }
        }

        [HttpGet("RetornaTodasTarefas")]
        public IActionResult RetornaTodasTarefas()
        {
            return Ok(tarefaService.RetornaTodasTarefas());
        }

        [HttpGet("RetornaTarefaPorId/{id}")]
        public IActionResult RetornaTarefaPorId(int id)
        {
            Tarefa tarefa = tarefaService.PesquisaTarefaPor(id);

            if (tarefa != default(Tarefa))
            { 
                return Ok(tarefa);
            }

            return BadRequest(
                new TarefaException(TarefaExceptionEnum.TAREFA_INEXISTENTE.Codigo,
                                    TarefaExceptionEnum.TAREFA_INEXISTENTE.Valor)
                                    );
        }

        [HttpGet("AlterarStatusTarefa/{id}/{status}")]
        public IActionResult AlterarStatusTarefa(int id, bool status)
        {
            Tarefa tarefa = tarefaService.PesquisaTarefaPor(id);

            if (tarefa != default(Tarefa))
            {
                tarefaService.AlteraStatusTarefa(id, status);
                return Ok();
            }

            return BadRequest(
                new TarefaException(TarefaExceptionEnum.TAREFA_INEXISTENTE.Codigo,
                                    TarefaExceptionEnum.TAREFA_INEXISTENTE.Valor)
                                    );
        }
    }
}