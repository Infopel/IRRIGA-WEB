using IRRIGA.Data;
using IRRIGA.Dtos;
using IRRIGA.Models;
using IRRIGA.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Controllers
{
    public class AccountMobileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IInqueritosRepository _inqueritosRepository;
        private readonly IRegadiosRepository _regadiosRepository;
        private readonly IEscolaMachambasRepository _escolaMachambasRepository;
        private readonly IAssociacoesRespository _associacoesRespository;
        private readonly dbIRRIGAContext _context;

        public AccountMobileController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            dbIRRIGAContext context, IUsuariosRepository usuariosRepository, IRegadiosRepository regadiosRepository, IInqueritosRepository inqueritosRepository,
            IEscolaMachambasRepository escolaMachambasRepository, IAssociacoesRespository associacoesRespository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usuariosRepository = usuariosRepository;
            _regadiosRepository = regadiosRepository;
            _inqueritosRepository = inqueritosRepository;
            _escolaMachambasRepository = escolaMachambasRepository;
            _associacoesRespository = associacoesRespository;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("v1.0/login")]
        public async Task<IActionResult> Login([FromBody] LoginMobileModel user)
        {

            if ( user.Password != null && user.Username != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);

                if (result.Succeeded)
                {
                    var userLog = await _userManager.FindByNameAsync(user.Username);
                    var roles = await _userManager.GetRolesAsync(userLog);
                    var roleLower = roles.FirstOrDefault().ToLower();

                    var usuarioMobile = new List<UsuarioMobileDto>();
                    var listMenus = new List<Menus>();
                    var listRegadios = new List<Regadios>();
                    var listEscolas = new List<Escolas>();
                    var listAssociacoes = new List<Associacoes>();

                    UsuarioMobileDto newUsuarioMobile = new UsuarioMobileDto();
                    IEnumerable<UsuarioInquerito> getUserInqueritos = _usuariosRepository.GetUsuarioInqueritos(userLog.Id.ToString());
                    IEnumerable<UsuarioEscola> getUserEscolas = _usuariosRepository.GetUsuarioEscolas(userLog.Id.ToString());
                    IEnumerable<UsuarioRegadio> getUserRegadios = _usuariosRepository.GetUsuarioRegadios(userLog.Id.ToString());
                    IEnumerable<UsuarioAssociaco> getUserAssociacoes = _usuariosRepository.GetUsuarioAssociacoes(userLog.Id.ToString());

                    newUsuarioMobile.Id = Guid.Parse(userLog.Id);
                    newUsuarioMobile.Username = user.Username;
                    newUsuarioMobile.Role = roleLower;

                    if (getUserInqueritos.Count() != 0)
                    {
                        foreach (var i in getUserInqueritos)
                        {
                            Menus newMenus = new Menus();

                            if (i.IdInquerito != null)
                            {
                                var getInquerito = await _inqueritosRepository.GetInqueritoUserBy(i.IdInquerito.Value);

                                newMenus.Id = getInquerito.Id;
                                newMenus.Name = getInquerito.Designacao;

                                listMenus.Add(newMenus);
                            }
                        }

                        newUsuarioMobile.Menu = listMenus;
                        
                    }
                    
                    if (getUserEscolas.Count() != 0) {
                        foreach (var e in getUserEscolas)
                        {
                            Escolas newEscolas = new Escolas();

                            if (e.IdEscola != null)
                            {
                                var getEscola = await _escolaMachambasRepository.GetEscolaBy(e.IdEscola.Value);
                                newEscolas.Id = getEscola.Id;
                                newEscolas.Name = getEscola.Designacao;
                                listEscolas.Add(newEscolas);
                            }

                            newUsuarioMobile.Escola = listEscolas;
                        }
                    } 

                    if (getUserRegadios.Count() != 0) {
                        foreach (var r in getUserRegadios)
                        {
                            Regadios newRegadios = new Regadios();
                            if (r.IdRegadio != null)
                            {
                                var getRegadio = await _regadiosRepository.GetRegadioBy(r.IdRegadio.Value);
                                newRegadios.Id = getRegadio.IdForMobile.Value;
                                newRegadios.Name = getRegadio.Designacao;
                                listRegadios.Add(newRegadios);
                            }
                            newUsuarioMobile.Regadio = listRegadios;
                        }
                    } 
                    
                    if (getUserAssociacoes.Count() != 0)
                    {
                        foreach (var a in getUserAssociacoes)
                        {
                            Associacoes newAssociacoes = new Associacoes();
                            if (a.IdAssociacao != null)
                            {
                                var getAssociacao = await _associacoesRespository.GetAssociacaoBy(a.IdAssociacao.Value);
                                newAssociacoes.Id = getAssociacao.Id;
                                newAssociacoes.Name = getAssociacao.Designacao;
                                listAssociacoes.Add(newAssociacoes);
                            }
                            newUsuarioMobile.Associacao = listAssociacoes;
                        }
                    }

                    usuarioMobile.Add(newUsuarioMobile);

                    return Ok(new { user = usuarioMobile });
                }
                else
                {
                    return NotFound(new { user = "incorrect username or password." });
                }
            }
            return NotFound(new { user = "Dados de user inválidos." });

        }

    }
}
