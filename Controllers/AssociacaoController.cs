using IRRIGA.Dtos;
using IRRIGA.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Controllers
{
    public class AssociacaoController : Controller
    {
        private readonly IAssociacoesRespository _associacoesRespository;

        public AssociacaoController(IAssociacoesRespository associacoesRespository)
        {
            _associacoesRespository = associacoesRespository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAssociacoes()
        {
            IEnumerable<Associacao> associacoes = _associacoesRespository.GetAll();
            var listAssociacao = new List<Associacoes>();
            foreach (var a in associacoes)
            {
                Associacoes associacao = new Associacoes();
                associacao.Id = a.Id;
                associacao.Name = a.Designacao;

                listAssociacao.Add(associacao);
            };

            return Ok(new { d = listAssociacao });
        }
    }
}
