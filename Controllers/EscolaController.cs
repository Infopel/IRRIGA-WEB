using IRRIGA.Dtos;
using IRRIGA.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Controllers
{
    public class EscolaController : Controller
    {
        private readonly IEscolaMachambasRepository _escolaMachambasRepository;

        public EscolaController(IEscolaMachambasRepository escolaMachambasRepository)
        {
            _escolaMachambasRepository = escolaMachambasRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetEscolas()
        {
            IEnumerable<EscolaMachamba> escolas = _escolaMachambasRepository.GetAll();
            var listEscola = new List<Escolas>();
            foreach (var e in escolas)
            {
                Escolas escola = new Escolas();
                escola.Id = e.Id;
                escola.Name = e.Designacao;

                listEscola.Add(escola);
            };

            return Ok(new { d = listEscola });
        }
    }
}
