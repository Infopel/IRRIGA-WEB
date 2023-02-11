using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRRIGA.Dtos;
using IRRIGA.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IRRIGA.Controllers
{
    public class RegadioController : Controller
    {
        private readonly IRegadiosRepository _regadiosRepository;

        public RegadioController(IRegadiosRepository regadiosRepository)
        {
            _regadiosRepository = regadiosRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetRegadios()
        {
            IEnumerable<Regadio> regadios = _regadiosRepository.GetAll();
            var listRegadios = new List<Regadios>();
            foreach (var r in regadios)
            {
                Regadios regadio = new Regadios();
                regadio.Id = r.IdForMobile.Value;
                regadio.Name = r.Designacao;

                listRegadios.Add(regadio);
            };

            return Ok(new { d = listRegadios });
        }
    }
}
