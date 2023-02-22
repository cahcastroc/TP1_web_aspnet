using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Text.Json.Serialization;

namespace Web.Controllers
{
    public class AmigoController : Controller
    {
        private readonly IAmigoService _service;

        public AmigoController(IAmigoService service)
        {
            _service = service;
        }

        private void SetSession(List<int> selecionado)
        {
            var listaIdSelecionados = JsonConvert.SerializeObject(selecionado);
            HttpContext.Session.SetString("selecionado", listaIdSelecionados);
        }

        private List<int> ListaSelecionados()
        {
            var selecionado = HttpContext.Session.GetString("selecionado");

            if (string.IsNullOrEmpty(selecionado))
            {
                return new List<int>();
            }
            return JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("selecionado"));

        }

        public IActionResult Index()
        {
            var listaAmigos = _service.ListaTodas();
            var selecionado = ListaSelecionados();

            foreach (var amigo in listaAmigos)
            {
                amigo.Selecionado = selecionado.Contains(amigo.Id);
            }



            return View(listaAmigos);
        }

        [HttpPost]
        public IActionResult Detalhes(List<int> selecionado)
        {
            if (selecionado.Count > 0)
            {
                SetSession(selecionado);
            }
            var selecionados = ListaSelecionados();
            var lista = _service.ListaTodas();

            foreach (var amigo in lista)
            {
                amigo.Selecionado = selecionados.Contains(amigo.Id);

            }
            return View(lista);
        }
    }
}
