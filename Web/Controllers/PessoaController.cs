using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Web.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        private void SetSession(List<int> selecionados) {
            var listaIdSelecionados = JsonConvert.SerializeObject(selecionados);
            HttpContext.Session.SetString("pessoasSelecionadas", listaIdSelecionados);
        }

        private List<int> ListaSelecionados() {
            var selecionadosSessao = HttpContext.Session.GetString("pessoasSelecionadas");
            if(string.IsNullOrEmpty(selecionadosSessao) )
            {
                return new List<int>();
            }
            return JsonConvert.DeserializeObject<List<int>>(selecionadosSessao);
        
        }

        public IActionResult Index()
        {
            var selecionados = ListaSelecionados();
            return View(_service.ListaTodas());
        }

        [HttpPost]
        public IActionResult Selecionar(List<int> selecionados)
        {
            SetSession(selecionados);
            var listaSelecionados = _service.ListaSelecionados(selecionados);

            return View(listaSelecionados);
        }
    }
}
