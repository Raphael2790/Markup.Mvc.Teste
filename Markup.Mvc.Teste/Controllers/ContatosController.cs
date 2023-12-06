using Markup.Business.Teste.Services.Interfaces;
using Markup.Models.Teste.Entities;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Markup.Mvc.Teste.Controllers
{
    public class ContatosController : Controller
    {
        private readonly IContatoBusinessService _contatoBusinessService;

        public ContatosController(IContatoBusinessService contatoBusinessService)
        {
            _contatoBusinessService = contatoBusinessService;
        }

        public async Task<ActionResult> Index()
        {
            var resultado = await _contatoBusinessService.ObterTodosContatosSalvos();

            if (!resultado.Sucesso)
                return View("Error");

            return View(resultado.Dados);
        }

        public async Task<ActionResult> Obter(int id)
        {
            var resultado = await _contatoBusinessService.ObterContato(id);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> CriarNovo(Contato contato)
        {
            var resultado = await _contatoBusinessService.CriarNovoContato(contato);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Atualizar(Contato contato)
        {
           
            var resultado = await _contatoBusinessService.AtualizarContato(contato);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Excluir(Contato contato)
        {
            var resultado = await _contatoBusinessService.ExcluirContato(contato);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}