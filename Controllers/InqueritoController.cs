using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRRIGA.Dtos;
using IRRIGA.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IRRIGA.Controllers
{
    public class InqueritoController : Controller
    {
        private readonly IInqueritosRepository _inqueritosRepository;

        public InqueritoController(IInqueritosRepository inqueritosRepository)
        {
            _inqueritosRepository = inqueritosRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetInqueritos()
        {
            IEnumerable<Inquerito> inquerito = _inqueritosRepository.GetAll();
            var listMenus = new List<Menus>();
            foreach (var i in inquerito)
            {
                Menus menus = new Menus();
                menus.Id = i.Id;
                menus.Name = i.Designacao.Replace("Formulário de ", "Cadastro de ");

                listMenus.Add(menus);
            };

            return Ok(new { d = listMenus });
        }
    }
}
