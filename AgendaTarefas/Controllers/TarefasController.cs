using AgendaTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
                dataAtual = dataAtual.AddDays(qtdDias);
                
            }
            return ListaDatas;
        }
    }
}
