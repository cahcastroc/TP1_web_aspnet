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

        public IActionResult Index(List<int> selecionado)        {

            var listaAmigos = _service.ListaTodas();        
          
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
        
            var lista = _service.ListaTodas();

            foreach (var amigo in lista)
            {
                amigo.Selecionado = selecionado.Contains(amigo.Id);
            }
            return View(lista);
        }
    }
}
