using AgendaTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private readonly Contexto _Contexto;
        public TarefasController(Contexto contexto)
        {
            _Contexto = contexto;
        }
        public IActionResult Index()
        {
            return View(PegarDatas());
        }

        private List<DatasViewModel> PegarDatas()
        {
            DateTime dataAtual = DateTime.Now;
            DateTime dataLimite = DateTime.Now.AddDays(10);
            int qtdDias = 0;
            DatasViewModel data;
           List<DatasViewModel> ListaDatas = new List<DatasViewModel>();

            while(dataAtual < dataLimite)
            {
                data = new DatasViewModel();
                data.Data = dataAtual.ToShortDateString();
                data.Identificadores = "collapse" + dataAtual.ToShortDateString().Replace("/", "");
                ListaDatas.Add(data);
                qtdDias = qtdDias + 1;
                dataAtual = DateTime.Now.AddDays(qtdDias);
                
            }
            return ListaDatas;
        }
        [HttpGet]
        public IActionResult CriarTarefa(string dataTarefa)
        {
            Tarefa tarefa = new Tarefa
            {
                Data = dataTarefa
            };
            return View(tarefa);
        }
        [HttpPost]
        public async Task<IActionResult>CriarTarefa(Tarefa tarefa)
        {
            if(ModelState.IsValid)
            {
                _Contexto.Tarefas.Add(tarefa);
                await _Contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarTarefa(int tarefaId)
        {
            Tarefa tarefa = await _Contexto.Tarefas.FindAsync(tarefaId);

            if (tarefa == null)
                return NotFound();

            return View(tarefa);
        }
        [HttpPost]
        public async Task<IActionResult>AtualizarTarefa(Tarefa tarefa)
        {
            if(ModelState.IsValid)
            {
                _Contexto.Update(tarefa);
                await _Contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);


        }

    }
}
