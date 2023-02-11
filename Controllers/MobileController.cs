using IRRIGA.Dtos;
using IRRIGA.Models;
using IRRIGA.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IRRIGA.Controllers
{
    public class MobileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IInqueritosRepository _inqueritosRepository;
        private readonly IFieldsetsRepository _fieldsetsRepository;
        private readonly IInqueritoPerguntasRepository _inqueritoPerguntasRepository;
        private readonly IInqueritoRespostasRepository _inqueritoRespostasRepository;
        private readonly IBeneficiariosRepository _beneficiariosRepository;
        private readonly IOpcoesPerguntaRepository _opcoesPerguntaRepository;
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IResponsesInqueritoRepository _responsesInqueritoRepository;
        private readonly IRegadiosRepository _regadiosRepository;
        private readonly IAssociacoesRespository _associacoesRespository;
        private readonly IEscolaMachambasRepository _escolaMachambasRepository;
        private readonly ICulturasRepository _culturasRepository;
        private readonly IProvincesRepository _provincesRepository;


        public MobileController(IInqueritosRepository inqueritosRepository,
            IFieldsetsRepository fieldsetsRepository, IInqueritoPerguntasRepository inqueritoPerguntasRepository,
            IBeneficiariosRepository beneficiariosRepository, IOpcoesPerguntaRepository opcoesPerguntaRepository,
            IUsuariosRepository usuariosRepository, IResponsesInqueritoRepository responsesInqueritoRepository,
            IInqueritoRespostasRepository inqueritoRespostasRepository, UserManager<IdentityUser> userManager,
            IRegadiosRepository regadiosRepository, IAssociacoesRespository associacoesRespository,
            ICulturasRepository culturasRepository, IEscolaMachambasRepository escolaMachambasRepository,
            IProvincesRepository provincesRepository)
        {
            _inqueritosRepository = inqueritosRepository;
            _fieldsetsRepository = fieldsetsRepository;
            _inqueritoPerguntasRepository = inqueritoPerguntasRepository;
            _beneficiariosRepository = beneficiariosRepository;
            _opcoesPerguntaRepository = opcoesPerguntaRepository;
            _usuariosRepository = usuariosRepository;
            _responsesInqueritoRepository = responsesInqueritoRepository;
            _inqueritoRespostasRepository = inqueritoRespostasRepository;
            _regadiosRepository = regadiosRepository;
            _associacoesRespository = associacoesRespository;
            _culturasRepository = culturasRepository;
            _escolaMachambasRepository = escolaMachambasRepository;
            _provincesRepository = provincesRepository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("v1.0/postForm")]
        public async Task<IActionResult> PostForm([FromBody] ResponsesMobileDto responses)
        {

            if (responses != null)
            {

                var getInquerito = await _inqueritosRepository.GetInqueritoUserBy(Guid.Parse(responses.FormId));
                var userLog = await _userManager.FindByIdAsync(responses.User.ToString());

                if (getInquerito != null)
                {

                    //if (getInquerito.Id == Guid.Parse("abf1cb25-5ed6-47c2-9219-d414c373663b"))
                    //{

                    ResponsesInquerito resp = new ResponsesInquerito()
                    {
                            Id = Guid.NewGuid(),
                            CreatedOn = SyncController.UnixTimeStampToDateTime(long.Parse(responses.CreatedOn)),
                            IdInquerito = getInquerito.Id,
                            IdForMobile = ResponsesIdCounterAsync()
                        };

                        var responsesId = await _responsesInqueritoRepository.Create(resp);
                        Beneficiario beneficiario = new Beneficiario();

                        foreach (var r in responses.Responses)
                        {
                            if (getInquerito.Id == Guid.Parse("abf1cb25-5ed6-47c2-9219-d414c373663b"))
                            {
                                beneficiario.CreatedOn = SyncController.UnixTimeStampToDateTime(long.Parse(responses.CreatedOn));
                                beneficiario.CreatedBy = userLog.UserName;

                                if (r.Type.ToLower() == "capture")
                                {
                                    InqueritoRespostum reposta = new InqueritoRespostum()
                                    {
                                        IdInquerito = getInquerito.Id,
                                        IdPergunta = Int32.Parse(r.Value[0]),
                                        Descricao = SaveImage(r.Value[0]),
                                        IdResponses = responsesId.Id,
                                        CreatedOn = SyncController.UnixTimeStampToDateTime(long.Parse(responses.CreatedOn))
                                    };

                                    await _inqueritoRespostasRepository.Create(reposta);
                                }
                                else
                                {

                                if (r.Name.ToLower() == "Nome".ToLower())
                                    beneficiario.Nome = r.Value[0];
                                else if (r.Name.ToLower() == "Apelido".ToLower())
                                    beneficiario.Apelido = r.Value[0];
                                else if (r.Name.ToLower() == "Data de Nascimento".ToLower())
                                    beneficiario.DataNascimento = SyncController.UnixTimeStampToDateTime(long.Parse(r.Value[0]));
                                else if (r.Name.ToLower() == "Número de Telefone".ToLower())
                                    beneficiario.Telefone = r.Value[0];
                                else if (r.Name.ToLower() == "Tipo de Documento".ToLower())
                                    beneficiario.TipoDocIdentificacao = r.Value[0];
                                else if (r.Name.ToLower() == "Número de Documento de Identificação".ToLower())
                                    beneficiario.NumDodcIdenticacao = r.Value[0];
                                else if (r.Name.ToLower() == "Localidade".ToLower())
                                    beneficiario.Localidade = r.Value[0];
                                else if (r.Name.ToLower() == "Local de Residência".ToLower())
                                    beneficiario.Endereco = r.Value[0];
                                else if (r.Name.ToLower() == "Número de Homens no Agregado Familiar".ToLower())
                                    beneficiario.AgregadoHomens = Int32.Parse(r.Value[0]);
                                else if (r.Name.ToLower() == "Número de Trabalhadores Homens".ToLower())
                                    beneficiario.AgregadoHomensTrab = Int32.Parse(r.Value[0]);
                                else if (r.Name.ToLower() == "Número de Mulheres no Agregado Familiar".ToLower())
                                    beneficiario.AgregadoMulheres = Int32.Parse(r.Value[0]);
                                else if (r.Name.ToLower() == "Número de Trabalhadores Mulheres".ToLower())
                                    beneficiario.AgregadoMulheresTrab = Int32.Parse(r.Value[0]);
                                else if (r.Name.ToLower() == "Regadio".ToLower())
                                    beneficiario.IdRegadio = GetGuidIdBy(Int32.Parse(r.Value[0]), "Regadio").Result;
                                else if (r.Name.ToLower() == "Associação".ToLower())
                                    beneficiario.IdRegadio = GetGuidIdBy(Int32.Parse(r.Value[0]), "Associação").Result;
                                else
                                {
                                    string descricao = string.Empty;

                                    if (r.Value.Length > 1)
                                        foreach (var d in r.Value)
                                        {
                                            descricao += d + ";";
                                        }
                                    else
                                        descricao = r.Value[0];

                                    InqueritoRespostum reposta = new InqueritoRespostum()
                                    {
                                        IdInquerito = getInquerito.Id,
                                        IdPergunta = Int32.Parse(r.Id.ToString()),
                                        Descricao = descricao,
                                        IdResponses = responsesId.Id,
                                        CreatedOn = SyncController.UnixTimeStampToDateTime(long.Parse(responses.CreatedOn))
                                    };
                                    await _inqueritoRespostasRepository.Create(reposta);
                                }
                                }

                                if(beneficiario != null)
                                    await _beneficiariosRepository.Create(beneficiario);
                        }
                            else
                            {
                                if (r.Type.ToLower() == "capture")
                                {
                                    InqueritoRespostum reposta = new InqueritoRespostum()
                                    {
                                        IdInquerito = getInquerito.Id,
                                        IdPergunta = Int32.Parse(r.Id.ToString()),
                                        Descricao = SaveImage(r.Value[0]),
                                        IdResponses = responsesId.Id,
                                        CreatedOn = SyncController.UnixTimeStampToDateTime(long.Parse(responses.CreatedOn))
                                    };

                                    await _inqueritoRespostasRepository.Create(reposta);
                                }
                                else
                                {
                                    string descricao = string.Empty;

                                    if (r.Value.Length > 1)
                                        foreach (var d in r.Value)
                                        {
                                            descricao += d + ";";
                                        }
                                    else
                                        descricao = r.Value[0];

                                    InqueritoRespostum reposta = new InqueritoRespostum()
                                    {
                                        IdInquerito = getInquerito.Id,
                                        IdPergunta = Int32.Parse(r.Id.ToString()),
                                        Descricao = descricao,
                                        IdResponses = responsesId.Id,
                                        CreatedOn = SyncController.UnixTimeStampToDateTime(long.Parse(responses.CreatedOn))
                                    };

                                    await _inqueritoRespostasRepository.Create(reposta);
                                }


                            }

                        }

                    return Ok(new { status = "Sucess!!" });
                    //return Ok(new { idBeneficiario = saveBen.Id });
                    //}
                    //else if(getInquerito.Id == Guid.Parse("ac67b3d8-d52d-4bd8-8564-0729eaea531d"))
                    //{
                    //    Cultura newCulturas = new Cultura();
                    //    foreach (var r in responses.Responses)
                    //    {
                    //        if (r.Name.ToLower() == "Tipo de Cultura".ToLower())
                    //            newCulturas.Designacao = r.Value[0];
                    //        else if (r.Name.ToLower() == "Area Cultivada pela Cultura".ToLower())
                    //            newCulturas.AreaCultivada = decimal.Parse(r.Value[0]);
                    //        else if (r.Name.ToLower() == "Redimento da Cultura".ToLower())
                    //            newCulturas.AreaCultivada = decimal.Parse(r.Value[0]);
                    //    }

                    //    var saveCultura = await _culturasRepository.Create(newCulturas);

                    //    return Ok(new { idCultura = saveCultura.Id });
                    //}
                }

                return NotFound(new { status = "ID do formulário inválido" });

            }
            return NotFound(new { status = "Não foi possivel salvar o formulario" });
        }

        [HttpGet("v1.0/getForm")]
        public IActionResult GetFormBy(UserGetFormModel user)
        {
            IEnumerable<SubInquerito> inqueritos = _inqueritosRepository.GetInqueritoBy(user.FormId);

            if (inqueritos.Any() && user.IdUser != Guid.Empty)
            {
                var form = MapFormDto(inqueritos, user.IdUser);
                return Ok(new { form });
            }

            return NotFound("Formulário ou User não encontrado");
        }

        [HttpGet("v1.0/filterControlWithId")]
        public async Task<IActionResult> GetAsync([FromQuery] string id, [FromQuery] string name)
        {

            if(id != null && name != null)
            {
                if (id.ToLower() == "DISTRICT_BY_PROVINCE".ToLower())
                    return GetDistritosByAsync(Int32.Parse(name));
                else if(id.ToLower() == "ASSOCIACAO_POR_REGADIO".ToLower())
                    return await GetAllAssociacaoByAsync(Int32.Parse(name));
                else if (id.ToLower() == "REGADIO_POR_ASSOCIACAO".ToLower())
                    return await GetAllRegadioByAsync(Int32.Parse(name));
                else if (id.ToLower() == "REGADIO_POR_PROVINCIA".ToLower())
                    return GetRegadiosBy(Int32.Parse(name));
                else if (id.ToLower() == "BENEFICIARIO_POR_REGADIO".ToLower())
                    return GetBeneficiarioBy(Int32.Parse(name));
                else if (id.ToLower() == "BENEFICIARIO_POR_ASSOCIACAO".ToLower())
                    return GetBeneficiarioAssoBy(Int32.Parse(name));
                else if (id.ToLower() == "BENEFICIARIO_POR_ESCOLA".ToLower())
                    return GetBeneficiarioEscolaBy(Int32.Parse(name));
                else if (id.ToLower() == "OPCOES_POR_PERGUNTA".ToLower())
                    return GetOpcoesBy(Int32.Parse(name));
            }

            return NotFound("Params inválido!");

        }

        [HttpGet("v1.0/getDistritosBy/{idProvincia}")]
        public IActionResult GetDistritosByAsync([FromRoute] int idProvincia)
        {
            if (idProvincia != 0)
            {
                //string localJson = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\json\\provinces.json"));
                //string jsonProvincias = Regex.Replace(localJson, @"\s+", "");

                //var jsonProv = JsonConvert.DeserializeObject<List<Provincias>>(jsonProvincias);
                var listDistricts = new List<Options>();

                IEnumerable<District> districts = _provincesRepository.GetDistrictsBy(idProvincia);

                if (districts.Any())
                {
                    foreach (var dist in districts)
                    {
                        Options options = new Options();
                        options.Id = dist.Id;
                        options.Name = dist.Name;
                        listDistricts.Add(options);
                    }
                    return Ok(listDistricts);

                } else
                    return NotFound("Provincia sem Distritos.");
            }

            return NotFound("ID da província não encontrado!!");
        }
        
        [HttpGet("v1.0/getPostoAdminBy/{idDistrito}")]
        public IActionResult GetPostoAdminBy([FromRoute] int idDistrito)
        {
            //string localJson = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\json\\provincias.json"));
            //string jsonProvincias = Regex.Replace(localJson, @"\s+", "");

            //var jsonProv = JsonConvert.DeserializeObject<List<Provincias>>(jsonProvincias);

            //foreach(var prov in jsonProv)
            //{
            //    foreach()
            //    if(Int32.Parse(prov.CodeProv) == idDistrito)
            //    {
            //        return Ok(new { prov.Distritos });
            //    }
            //}

            return NotFound("Posto Administrativos não encontrados!!!");
        }

        [HttpGet("v1.0/getAllAssociacaoRegadiosBy/{idRegadio}")]
        public async Task<IActionResult> GetAllAssociacaoByAsync([FromRoute] int idRegadio)
        {
            var regadioId = await _regadiosRepository.GetRegadioGuidIdBy(idRegadio);
            if(regadioId != null)
            {
                IEnumerable<AssociacaoRegadio> associacoes = _associacoesRespository.GetAllAssociacaoBy(regadioId.Id);
                var listAssociacao = new List<Options>();

                if (associacoes.Any())
                {
                    foreach (var associacao in associacoes)
                    {
                        Options options = new Options();
                        options.Id = associacao.Id;
                        options.Name = associacao.IdAssociacaoNavigation.Designacao;
                        listAssociacao.Add(options);
                    }

                    return Ok(listAssociacao);
                }
                else
                    return NotFound("Associação sem Regadios.");
            }
            return NotFound("Associação sem Regadios.");
        }

        [HttpGet("v1.0/getAllRegadiosAssociacaoBy/{idAssociacao}")]
        public async Task<IActionResult> GetAllRegadioByAsync([FromRoute] int idAssociacao)
        {
            var asssociacaoId = await _associacoesRespository.GetAssociacaoGuidIdbBy(idAssociacao);
            IEnumerable<AssociacaoRegadio> regadios = _associacoesRespository.GetAllRegadiosBy(asssociacaoId.Id);

            var listRegadios = new List<Options>();

            if (regadios.Any())
            {
                foreach (var regadio in regadios)
                {
                    Options options = new Options();
                    options.Id = regadio.IdRegadioNavigation.IdForMobile.Value;
                    options.Name = regadio.IdRegadioNavigation.Designacao;
                    listRegadios.Add(options);
                }

                return Ok(listRegadios);
            }
            else
                return NotFound("idAssociacao não associado a nenhum Regadio.");

        }

        [HttpGet("v1.0/getRegadiosPovinciaBy/{idProvincia}")]
        public IActionResult GetRegadiosBy([FromRoute] int idProvincia)
        {

            IEnumerable<Regadio> regadios = _regadiosRepository.GetRegadiosBy(idProvincia);
            var listRegadios = new List<Options>();

            if (regadios.Any())
            {
                foreach (var regadio in regadios)
                {
                    Options options = new Options();
                    options.Id = regadio.IdForMobile.Value;
                    options.Name = regadio.Designacao;
                    listRegadios.Add(options);
                }

                return Ok(listRegadios);
            }
            else
                return NotFound("Provincia sem Regadios.");
        }

        [HttpGet("v1.0/getAllRegadiosBy/{idUser}")]
        public async Task<IActionResult> GetRegadiosBy([FromRoute] Guid idUser)
        {
            IEnumerable<UsuarioRegadio> getRegadios = _usuariosRepository.GetUsuarioRegadios(idUser.ToString());
            var listRegadios = new List<Regadios>();
            if (getRegadios.Any())
            {
                foreach (var r in getRegadios)
                {
                    Regadios newRegadios = new Regadios();

                    var getRegadio = await _regadiosRepository.GetRegadioBy(r.IdRegadio.Value);

                    newRegadios.Id = getRegadio.IdForMobile.Value;
                    newRegadios.Name = getRegadio.Designacao;
                    listRegadios.Add(newRegadios);

                }

                return Ok(new {userRegadios = listRegadios });
            }
            return null;
        }

        [HttpGet("v1.0/getAllAssociacaoBy/{idUser}")]
        public async Task<IActionResult> GetAssociacaoBy([FromRoute] Guid idUser)
        {
            IEnumerable<UsuarioAssociaco> getAssociacoes = _usuariosRepository.GetUsuarioAssociacoes(idUser.ToString());
            var listAssociacao = new List<Associacoes>();
            if (getAssociacoes.Any())
            {
                foreach (var a in getAssociacoes)
                {
                    Associacoes newAssociacoes = new Associacoes();

                    var getAssociacao = await _associacoesRespository.GetAssociacaoBy(a.IdAssociacao.Value);

                    newAssociacoes.Id = getAssociacao.Id;
                    newAssociacoes.Name = getAssociacao.Designacao;
                    listAssociacao.Add(newAssociacoes);

                }

                return Ok(new { userAssociacao = listAssociacao });
            }
            return null;
        }

        [HttpGet("v1.0/getAllEscolasBy/{idUser}")]
        public async Task<IActionResult> GetEscolaBy([FromRoute] Guid idUser)
        {
            IEnumerable<UsuarioEscola> getEscolas = _usuariosRepository.GetUsuarioEscolas(idUser.ToString());
            var listEscola= new List<Escolas>();
            if (getEscolas.Any())
            {
                foreach (var e in getEscolas)
                {
                    Escolas newEscolas = new Escolas();

                    var getEscola = await _escolaMachambasRepository.GetEscolaBy(e.IdEscola.Value);

                    newEscolas.Id = getEscola.Id;
                    newEscolas.Name = getEscola.Designacao;
                    listEscola.Add(newEscolas);

                }

                return Ok(new { userEscolas = listEscola });
            }
            return null;
        }

        [HttpGet("v1.0/getRegadioAllBeneficiariosBy/{idRegadio}")]
        public IActionResult GetBeneficiarioBy([FromRoute] int idRegadio)
        {
            IEnumerable<Beneficiario> allBeneficiario = _beneficiariosRepository.GetAllBeneficiariosBy(GetGuidIdBy(idRegadio, "Regadio").Result);

            if (allBeneficiario.Any())
            {
                var beneficiarios = MapBenefiiariosDto(allBeneficiario);
                return Ok(beneficiarios);
            }
            else
                return NotFound("Regadio sem Beneficiarios!!!");
        }

        [HttpGet("v1.0/getAssociacaoAllBeneficiariosBy/{idAssociacao}")]
        public IActionResult GetBeneficiarioAssoBy([FromRoute] int idAssociacao)
        {
            IEnumerable<Beneficiario> allBeneficiario = _beneficiariosRepository.GetAllBeneficiariosBy(GetGuidIdBy(idAssociacao, "Associacao").Result);

            if (allBeneficiario.Any())
            {
                var beneficiarios = MapBenefiiariosDto(allBeneficiario);
                return Ok(beneficiarios);
            }
            else
                return NotFound("Associação sem Beneficiarios!!!");
        }

        [HttpGet("v1.0/getEscolaAllBeneficiariosBy/{idEscola}")]
        public IActionResult GetBeneficiarioEscolaBy([FromRoute] int idEscola)
        {
            IEnumerable<Beneficiario> allBeneficiario = _beneficiariosRepository.GetAllBeneficiariosBy(GetGuidIdBy(idEscola, "Escola").Result);

            if (allBeneficiario.Any())
            {
                var beneficiarios = MapBenefiiariosDto(allBeneficiario);
                return Ok(beneficiarios);
            }
            else
                return NotFound("Escola sem Beneficiarios!!!");
        }

        [HttpGet("v1.0/getPerguntaOpcoesBy/{idPergunta}")]
        public IActionResult GetOpcoesBy([FromRoute] int idPergunta)
        {
            IEnumerable<PerguntaOpcao> allOpcoes = _opcoesPerguntaRepository.GetAllOpcoesBy(idPergunta);
            
            if(allOpcoes.Any())
            {
                var perguntaOpcoes = MapOpcoesDto(allOpcoes);
                return Ok(perguntaOpcoes);
            }
            else
                return NotFound("Opções da Pergunta não encontradas");
        }

        [HttpGet("v1.0/getCulturas")]
        public IActionResult GetCulturas()
        {
            IEnumerable<Cultura> culturas = _culturasRepository.GetAll();
            var listCulturas = new List<Options>();

            if (culturas.Any())
            {
                int index = 0;
                foreach (var cult in culturas)
                {
                    ++index;
                    Options options = new Options();
                    options.Id = index;
                    options.Name = cult.Designacao;
                    listCulturas.Add(options);
                }

                return Ok(new { cultures = listCulturas });
            }
            else
                return NotFound("Culturas não encontradas!!!");
        }

        private IEnumerable<PerguntaOpcoesDto> MapOpcoesDto(IEnumerable<PerguntaOpcao> opcoes)
        {
            IEnumerable<PerguntaOpcoesDto> result;
            result = opcoes.Select(o => new PerguntaOpcoesDto()
            {
                IdPergunta = o.IdPergunta.Value,
                Label = o.IdPerguntaNavigation.Descricao,
                DependOn = opcoes.GetHashCode(),
                Options = GetOptions(opcoes)
            });

            return result;
        }
        private IEnumerable<BeneficiariosMobileDto> MapBenefiiariosDto(IEnumerable<Beneficiario> beneficiarios)
        {
            IEnumerable<BeneficiariosMobileDto> result;
            result = beneficiarios.Select(b => new BeneficiariosMobileDto()
            {
                Id = b.Id,
                Name = b.Nome + " " + b.Apelido,
                IdRegadio = b.IdRegadio.Value,
                IsActive = !b.RemovedOn.HasValue ? true : false
            });

            return result;
        }

        private IEnumerable<FormMobileDto> MapFormDto(IEnumerable<SubInquerito> form, Guid userId)
        {
            IEnumerable<FormMobileDto> result;
            result = form.Select(f => new FormMobileDto()
            {
                Id = f.IdSubInquerito.Value,
                Name = f.IdSubInqueritoNavigation.Designacao.Replace("\r\n", "").Replace("\r", ""),

                Fieldset = Fieldsets(f.IdSubInqueritoNavigation.Fieldsets, userId)
            });
            return result;
        }

        private List<Options> GetOptions(IEnumerable<PerguntaOpcao> opcoes)
        {
            var listOptions = new List<Options>();
            foreach (var item in opcoes)
            {
                Options newOptions = new Options();
                newOptions.Id = item.Id;
                newOptions.Name = item.Descricao;

                listOptions.Add(newOptions);
            }

            return listOptions;
        }

        private int GetHasOpcoes(int idPergunta)
        {
            IEnumerable<PerguntaOpcao> allOpcoes = _opcoesPerguntaRepository.GetAllOpcoesBy(idPergunta);

            return allOpcoes.GetHashCode();
        }
        private List<FieldsetMobile> Fieldsets(IEnumerable<Fieldset> fieldsets, Guid idUser)
        {
            IEnumerable<UsuarioRegadio> userRegadios = _usuariosRepository.GetUsuarioRegadios(idUser.ToString());
            IEnumerable<UsuarioAssociaco> userAssociacoes = _usuariosRepository.GetUsuarioAssociacoes(idUser.ToString());
            IEnumerable<UsuarioEscola> userEscolas = _usuariosRepository.GetUsuarioEscolas(idUser.ToString());

            var listFieldset = new List<FieldsetMobile>();

            string localJson = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\json\\provinces.json"));
            string jsonProvincias = Regex.Replace(localJson, @"\s+", "");

            var jsonProv = JsonConvert.DeserializeObject<List<Provincias>>(jsonProvincias);

            foreach (var item in fieldsets.OrderBy(f => f.FieldsetsOrder).GroupBy(f => f.Id))
            {
                if (item.FirstOrDefault().IsRemoved == false || item.FirstOrDefault().IsRemoved == null)
                {

                    FieldsetMobile newFieldset = new FieldsetMobile();
                    var listControls = new List<Controls>();

                    newFieldset.Id = item.FirstOrDefault().Id;
                    newFieldset.Label = item.FirstOrDefault().Label.Replace("\r\n", "").Replace("\r", "");
                    newFieldset.Description = item.FirstOrDefault().Description.Replace("\r\n", "").Replace("\r", "");

                    if(item.FirstOrDefault().CaracteristicasComponente != null)
                    {
                        string jsonDataComponente = @item.FirstOrDefault().CaracteristicasComponente;
                        var jsonComponents = JsonConvert.DeserializeObject<FieldsetMobile>(jsonDataComponente);

                        newFieldset.DependOn = jsonComponents.DependOn;
                    }


                    IEnumerable<InqueritoPerguntum> fset = _inqueritoPerguntasRepository.GetPerguntasBy(item.FirstOrDefault().IdInquerito.Value, item.FirstOrDefault().Id);


                    foreach (var itens in fset.OrderBy(f => f.QuestionOrder))
                    {
                        if (itens.IsRemoved == false || itens.IsRemoved == null) {
                            string jsonDataControls = @itens.CaracteristicasComponente;
                            var jsonControls = JsonConvert.DeserializeObject<Controls>(jsonDataControls);

                            var jsonLocal = JsonConvert.DeserializeObject<LocalData>(jsonDataControls);

                            string jsonDataValidators = @itens.ValidacaoComponente;
                            var jsonValidators = JsonConvert.DeserializeObject<Validators>(jsonDataValidators);

                            Controls newControls = new Controls();
                            newControls.Id = itens.Id;
                            if (itens.Descricao != null)
                                newControls.Label = itens.Descricao.Replace("\r\n", "").Replace("\r", "");
                            newControls.Type = jsonControls.Type;

                            if (jsonControls.Placeholder != null)
                                newControls.Placeholder = jsonControls.Placeholder.Replace("\r\n", "").Replace("\r", "");

                            newControls.FilterId = jsonControls.FilterId;
                            newControls.FilterWithDropdown = jsonControls.FilterWithDropdown;
                            newControls.LabelField = jsonControls.LabelField;

                            if (itens.IdForm != null)
                                newControls.Value = itens.IdForm.ToString();

                            var listOptions = new List<Options>();

                            if (jsonLocal.IsLocal)
                            {

                                if (jsonLocal.LocalType == 6)
                                {
                                    foreach (var prov in jsonProv)
                                    {
                                        Options newOptions = new Options();
                                        newOptions.Id = prov.Id;
                                        newOptions.Name = prov.Name.Replace("\r\n", "").Replace("\r", "");
                                        listOptions.Add(newOptions);
                                    }
                                }
                                else if (jsonLocal.LocalType == 1)
                                {
                                    if (userRegadios.Any())
                                    {
                                        newControls.VerifyOn = userRegadios.GetHashCode();
                                        foreach (var reg in userRegadios)
                                        {
                                            if (reg.IdRegadio != null)
                                            {
                                                Options newOptions = new Options();
                                                newOptions.Id = Int32.Parse(reg.IdRegadioNavigation.CodeRegadio);
                                                newOptions.Name = reg.IdRegadioNavigation.Localizacao.Replace("\r\n", "").Replace("\r", "");
                                                listOptions.Add(newOptions);
                                            }

                                        }
                                    }
                                }
                                else if (jsonLocal.LocalType == 2)
                                {
                                    if (userAssociacoes.Any())
                                    {
                                        newControls.VerifyOn = userAssociacoes.GetHashCode();
                                        foreach (var assoc in userAssociacoes)
                                        {
                                            Options newOptions = new Options();
                                            newOptions.Id = assoc.IdAssociacaoNavigation.IdForMobile.Value;
                                            newOptions.Name = assoc.IdAssociacaoNavigation.Designacao.Replace("\r\n", "").Replace("\r", "");
                                            listOptions.Add(newOptions);
                                        }
                                    }
                                }
                                else if (jsonLocal.LocalType == 3)
                                {
                                    IEnumerable<Cultura> culturas = _culturasRepository.GetAll();

                                    if (culturas.Any())
                                    {
                                        newControls.VerifyOn = culturas.GetHashCode();
                                        int index = 0;
                                        foreach (var cult in culturas)
                                        {
                                            if (cult.IsPrincipal == true)
                                            {
                                                ++index;

                                                Options newOptions = new Options();
                                                newOptions.Id = index;
                                                newOptions.Name = cult.Designacao.Replace("\r\n", "").Replace("\r", "");
                                                listOptions.Add(newOptions);
                                            }
                                        }
                                    }
                                }
                                else if (jsonLocal.LocalType == 21)
                                {
                                    IEnumerable<Cultura> culturas = _culturasRepository.GetAll();

                                    if (culturas.Any())
                                    {
                                        int index = 0;
                                        newControls.VerifyOn = culturas.GetHashCode();
                                        foreach (var cult in culturas)
                                        {
                                            if (cult.IsPrincipal == false)
                                            {
                                                ++index;
                                                Options newOptions = new Options();
                                                newOptions.Id = index;
                                                newOptions.Name = cult.Designacao.Replace("\r\n", "").Replace("\r", "");
                                                listOptions.Add(newOptions);
                                            }

                                        }
                                    }
                                }
                                else if (jsonLocal.LocalType == 200)
                                {
                                    IEnumerable<TipoCultura> tipoCulturas = _culturasRepository.GetAllTipo();

                                    if (tipoCulturas.Any())
                                    {
                                        int index = 0;
                                        newControls.VerifyOn = tipoCulturas.GetHashCode();
                                        foreach (var tipoCult in tipoCulturas)
                                        {
                                            if (tipoCult.IsPrincipal == true)
                                            {
                                                ++index;

                                                Options newOptions = new Options();
                                                newOptions.Id = index;
                                                newOptions.Name = tipoCult.Designacao.Replace("\r\n", "").Replace("\r", "");
                                                listOptions.Add(newOptions);
                                            }
                                        }
                                    }
                                }
                                else if (jsonLocal.LocalType == 201)
                                {
                                    IEnumerable<TipoCultura> tipoCulturas = _culturasRepository.GetAllTipo();

                                    if (tipoCulturas.Any())
                                    {
                                        int index = 0;
                                        newControls.VerifyOn = tipoCulturas.GetHashCode();
                                        foreach (var tipoCult in tipoCulturas)
                                        {
                                            if (tipoCult.IsPrincipal == false)
                                            {
                                                ++index;

                                                Options newOptions = new Options();
                                                newOptions.Id = index;
                                                newOptions.Name = tipoCult.Designacao.Replace("\r\n", "").Replace("\r", "");
                                                listOptions.Add(newOptions);
                                            }
                                        }
                                    }
                                }
                                else if (jsonLocal.LocalType == 300)
                                {
                                    if (userEscolas.Any())
                                    {
                                        newControls.VerifyOn = userEscolas.GetHashCode();
                                        foreach (var escola in userEscolas)
                                        {
                                            Options newOptions = new Options();
                                            newOptions.Id = escola.IdEscolaNavigation.IdForMobile.Value;
                                            newOptions.Name = escola.IdEscolaNavigation.Designacao.Replace("\r\n", "").Replace("\r", "");
                                            listOptions.Add(newOptions);
                                        }
                                    }
                                }
                                else if (jsonLocal.LocalType == 80)
                                {
                                    if (fieldsets.Any())
                                    {
                                        newControls.VerifyOn = fieldsets.GetHashCode();
                                        foreach (var field in fieldsets)
                                        {
                                            if(field.FieldsetsOrder > 100)
                                            {
                                                Options newOptions = new Options();
                                                newOptions.Id = field.Id;
                                                newOptions.Name = field.Label.Replace("\r\n", "").Replace("\r", "");
                                                listOptions.Add(newOptions);
                                            }

                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (var op in itens.PerguntaOpcaos)
                                {
                                    if (op.IsOpcao == true)
                                    {
                                        Options newOptions = new Options();
                                        newOptions.Id = op.Id;
                                        newOptions.Name = op.Descricao.Replace("\r\n", "").Replace("\r", "");

                                        if (op.IdPaiOpcao != null)
                                            newControls.DependOn = op.IdPaiPergunta + "/" + op.IdPaiOpcao;

                                        listOptions.Add(newOptions);
                                    }
                                    else
                                    {
                                        if (op.IdPaiOpcao != null)
                                            newControls.DependOn = op.IdPaiPergunta + "/" + op.IdPaiOpcao;
                                        else if (itens.IdForm != null)
                                            newControls.DependOn = op.IdPaiPergunta.ToString();
                                    }

                                }
                            }


                            if (listOptions.Any() && jsonLocal.IsLocal == false)
                                newControls.VerifyOn = listOptions.GetHashCode();

                            newControls.Options = listOptions;

                            newControls.Validators = new Validators
                            {
                                Required = jsonValidators.Required,
                                Min = jsonValidators.Min,
                                Max = jsonValidators.Max,
                                ContentType = jsonValidators.ContentType
                            };

                            listControls.Add(newControls);
                        }
                    }

                    newFieldset.Controls = listControls;

                    listFieldset.Add(newFieldset);
                }
            }


            return listFieldset;
        }

        private async Task<string> GetFormIdBy(string nameForm)
        {
            try
            {
                var getForm = await _inqueritosRepository.GetInqueritoTaskBy(nameForm);
                return getForm.Id.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public string SaveImage(string base64Image)
        {
            try
            {
                String path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\responses");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var data = base64Image.Substring(0, 5);
                var extension = Extension(data);

                var imageName = string.Format(@"{0}", Guid.NewGuid()) + extension;
                string imgPath = Path.Combine(path, imageName);

                var imageBytes = Convert.FromBase64String(base64Image);
                var imagefile = new FileStream(imgPath, FileMode.Create);

                imagefile.Write(imageBytes, 0, imageBytes.Length);
                imagefile.Flush();

                return imgPath;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string Extension(string image)
        {
            var extension = "";
            switch (image.ToUpper())
            {
                case "IVBOR":
                    return extension = ".png";
                case "/9J/4":
                    return extension = ".jpg";
            }
            return extension;
        }

        public int ResponsesIdCounterAsync()
        {
            IEnumerable<ResponsesInquerito> responses = _responsesInqueritoRepository.GetAll();
            if (responses.Any())
                return responses.Count() + 1;
            else
                return 1;
        }

        public async Task<Guid> GetGuidIdBy(int idForMobile, string processo)
        {
            if(processo.ToLower() == "Associação".ToLower())
            {
                var getAssociacao = await _associacoesRespository.GetAssociacaoGuidIdbBy(idForMobile);
                return getAssociacao.Id;
            }
            else
            {
                var getRegadio = await _regadiosRepository.GetRegadioGuidIdBy(idForMobile);
                return getRegadio.Id;
            }
        }
    }
}
