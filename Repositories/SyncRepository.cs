using IRRIGA.Data;
using IRRIGA.Models;
using IRRIGA.Request;
using IRRIGA.WatermemonSync;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class SyncRepository
    {
        private readonly dbIRRIGAContext _context;
        public SyncRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public SyncRequest Pull(DateTime? lastPulledAt, string user, string device)
        {
            //AssociacaoRegadio
            var createdAssociacaoRegadio = _context.AssociacaoRegadios.Where((a) => a.CreatedOn >= lastPulledAt && (a.IsRemoved == null || a.IsRemoved == false))
                .Select(AssociacaoRegadioMapper.Map)
                .ToList();

            var updatedAssociacaoRegadio = _context.AssociacaoRegadios.Where((a) => a.CreatedOn < lastPulledAt && a.UpdatedOn > lastPulledAt && (a.IsRemoved == null || a.IsRemoved == false))
                .Select(AssociacaoRegadioMapper.Map)
                .ToList();

            var deletedAssociacaoRegadio = _context.AssociacaoRegadios.Where((a) => a.CreatedOn < lastPulledAt && a.RemovedOn > lastPulledAt && a.IsRemoved == true)
                .Select(a => a.Id.ToString())
                .ToList();

            //Associacao
            var createdAssociacaos = _context.Associacaos.Where((a) => a.CreatedOn >= lastPulledAt && (a.IsRemoved == null || a.IsRemoved == false))
                .Select(AssociacaoMapper.Map)
                .ToList();

            var updatedAssociacaos = _context.Associacaos.Where((a) => a.CreatedOn < lastPulledAt && a.UpdatedOn > lastPulledAt && (a.IsRemoved == null || a.IsRemoved == false))
                .Select(AssociacaoMapper.Map)
                .ToList();

            var deletedAssociacaos = _context.Associacaos.Where((a) => a.CreatedOn < lastPulledAt && a.RemovedOn > lastPulledAt && a.IsRemoved == true)
                .Select(a => a.Id.ToString())
                .ToList();

            //BeneficiarioEscolas
            var createdBeneficiarioEscolas = _context.BeneficiarioEscolas.Where((b) => b.CreatedOn >= lastPulledAt && (b.IsRemoved == null || b.IsRemoved == false))
                .Select(BeneficiarioEscolasMapper.Map)
                .ToList();

            var updatedBeneficiarioEscolas = _context.BeneficiarioEscolas.Where((b) => b.CreatedOn < lastPulledAt && b.UpdatedOn > lastPulledAt && (b.IsRemoved == null || b.IsRemoved == false))
                .Select(BeneficiarioEscolasMapper.Map)
                .ToList();

            var deletedBeneficiarioEscolas = _context.BeneficiarioEscolas.Where((b) => b.CreatedOn < lastPulledAt && b.RemovedOn > lastPulledAt && b.IsRemoved == true)
                .Select(b => b.Id.ToString())
                .ToList();

            //Beneficiario
            var createdBeneficiario = _context.Beneficiarios.Where((b) => b.CreatedOn >= lastPulledAt && (b.IsRemoved == null || b.IsRemoved == false))
                .Select(BeneficiarioMapper.Map)
                .ToList();

            var updatedBeneficiario = _context.Beneficiarios.Where((b) => b.CreatedOn < lastPulledAt && b.UpdatedOn > lastPulledAt && (b.IsRemoved == null || b.IsRemoved == false))
                .Select(BeneficiarioMapper.Map)
                .ToList();

            var deletedBeneficiario = _context.Beneficiarios.Where((b) => b.CreatedOn < lastPulledAt && b.RemovedOn > lastPulledAt && b.IsRemoved == true)
                .Select(b => b.Id.ToString())
                .ToList();

            //Cultura
            var createdCultura = _context.Culturas.Where((c) => c.CreatedOn >= lastPulledAt && (c.IsRemoved == null || c.IsRemoved == false))
                .Select(CulturaMapper.Map)
                .ToList();

            var updatedCultura = _context.Culturas.Where((c) => c.CreatedOn < lastPulledAt && c.UpdatedOn > lastPulledAt && (c.IsRemoved == null || c.IsRemoved == false))
                .Select(CulturaMapper.Map)
                .ToList();

            var deletedCultura = _context.Culturas.Where((c) => c.CreatedOn < lastPulledAt && c.RemovedOn > lastPulledAt && c.IsRemoved == true)
                .Select(c => c.Id.ToString())
                .ToList();

            //EscolaMachamba
            var createdEscolaMachamba = _context.EscolaMachambas.Where((e) => e.CreatedOn >= lastPulledAt && (e.IsRemoved == null || e.IsRemoved == false))
                .Select(EscolaMachambaMapper.Map)
                .ToList();

            var updatedEscolaMachamba = _context.EscolaMachambas.Where((e) => e.CreatedOn < lastPulledAt && e.UpdatedOn > lastPulledAt && (e.IsRemoved == null || e.IsRemoved == false))
                .Select(EscolaMachambaMapper.Map)
                .ToList();

            var deletedEscolaMachamba = _context.EscolaMachambas.Where((e) => e.CreatedOn < lastPulledAt && e.RemovedOn > lastPulledAt && e.IsRemoved == true)
                .Select(e => e.Id.ToString())
                .ToList();

            //EscolaRegadios
            var createdEscolaRegadios = _context.EscolaRegadios.Where((e) => e.CreatedOn >= lastPulledAt && (e.IsRemoved == null || e.IsRemoved == false))
                .Select(EscolaRegadiosMapper.Map)
                .ToList();

            var updatedEscolaRegadios = _context.EscolaRegadios.Where((e) => e.CreatedOn < lastPulledAt && e.UpdatedOn > lastPulledAt && (e.IsRemoved == null || e.IsRemoved == false))
                .Select(EscolaRegadiosMapper.Map)
                .ToList();

            var deletedEscolaRegadios = _context.EscolaRegadios.Where((e) => e.CreatedOn < lastPulledAt && e.RemovedOn > lastPulledAt && e.IsRemoved == true)
                .Select(e => e.Id.ToString())
                .ToList();


            //Fieldsets
            var createdFieldsets = _context.Fieldsets.Where((f) => f.CreatedOn >= lastPulledAt && (f.IsRemoved == null || f.IsRemoved == false))
                .Select(FieldsetsMapper.Map)
                .ToList();

            var updatedFieldsets = _context.Fieldsets.Where((f) => f.CreatedOn < lastPulledAt && f.UpdatedOn > lastPulledAt && (f.IsRemoved == null || f.IsRemoved == false))
                .Select(FieldsetsMapper.Map)
                .ToList();

            var deletedFieldsets = _context.Fieldsets.Where((f) => f.CreatedOn < lastPulledAt && f.RemovedOn > lastPulledAt && f.IsRemoved == true)
                .Select(f => f.Id.ToString())
                .ToList();

            //InqueritoPergunta
            var createdInqueritoPergunta = _context.InqueritoPergunta.Where((i) => i.CreatedOn >= lastPulledAt && (i.IsRemoved == null || i.IsRemoved == false))
                .Select(InqueritoPerguntaMapper.Map)
                .ToList();

            var updatedInqueritoPergunta = _context.InqueritoPergunta.Where((i) => i.CreatedOn < lastPulledAt && i.UpdateOn > lastPulledAt && (i.IsRemoved == null || i.IsRemoved == false))
                .Select(InqueritoPerguntaMapper.Map)
                .ToList();

            var deletedInqueritoPergunta = _context.InqueritoPergunta.Where((i) => i.CreatedOn < lastPulledAt && i.RemovedOn > lastPulledAt && i.IsRemoved == true)
                .Select(i => i.Id.ToString())
                .ToList();

            //InqueritoResposta
            var createdInqueritoResposta = _context.InqueritoResposta.Where((i) => i.CreatedOn >= lastPulledAt && (i.IsRemoved == null || i.IsRemoved == false))
                .Select(InqueritoRespostaMapper.Map)
                .ToList();

            var updatedInqueritoResposta = _context.InqueritoResposta.Where((i) => i.CreatedOn < lastPulledAt && i.UpdatedOn > lastPulledAt && (i.IsRemoved == null || i.IsRemoved == false))
                .Select(InqueritoRespostaMapper.Map)
                .ToList();

            var deletedInqueritoResposta = _context.InqueritoResposta.Where((i) => i.CreatedOn < lastPulledAt && i.RemovedOn > lastPulledAt && i.IsRemoved == true)
                .Select(i => i.Id.ToString())
                .ToList();

            //Inquerito
            var createdInquerito = _context.Inqueritos.Where((i) => i.CreatedOn >= lastPulledAt && i.IsMobile == true && i.RemovedOn == null)
                .Select(InqueritoMapper.Map)
                .ToList();

            var updatedInquerito = _context.Inqueritos.Where((i) => i.CreatedOn < lastPulledAt && i.UpdatedOn > lastPulledAt && i.IsMobile == true)
                .Select(InqueritoMapper.Map)
                .ToList();

            var deletedInquerito = _context.Inqueritos.Where((i) => i.CreatedOn < lastPulledAt && i.RemovedOn > lastPulledAt && i.IsMobile == true)
                .Select(i => i.Id.ToString())
                .ToList();

            //PerguntaOpcao
            var createdPerguntaOpcao = _context.PerguntaOpcaos.Where((p) => p.CreatedOn >= lastPulledAt && (p.IsRemoved == null || p.IsRemoved == false))
                .Select(PerguntaOpcaoMapper.Map)
                .ToList();

            var updatedPerguntaOpcao = _context.PerguntaOpcaos.Where((p) => p.CreatedOn < lastPulledAt && p.UpdatedOn > lastPulledAt && (p.IsRemoved == null || p.IsRemoved == false))
                .Select(PerguntaOpcaoMapper.Map)
                .ToList();

            var deletedPerguntaOpcao = _context.PerguntaOpcaos.Where((p) => p.CreatedOn < lastPulledAt && p.RemovedOn > lastPulledAt && p.IsRemoved == true)
                .Select(i => i.Id.ToString())
                .ToList();

            //Provincias
            var createdProvincias = _context.Provinces.Where((i) => i.CreatedOn >= lastPulledAt && i.RemovedOn == null)
                .Select(ProvinciasMapper.Map)
                .ToList();

            var updatedProvincias = _context.Provinces.Where((p) => p.CreatedOn < lastPulledAt && p.UpdatedOn > lastPulledAt)
                .Select(ProvinciasMapper.Map)
                .ToList();

            var deletedProvincias = _context.Provinces.Where((p) => p.CreatedOn < lastPulledAt && p.RemovedOn > lastPulledAt)
                .Select(p => p.Id.ToString())
                .ToList();

            //Districts
            var createdDistricts = _context.Districts.Where((i) => i.CreatedOn >= lastPulledAt && i.RemovedOn == null)
                .Select(DistrictsMapper.Map)
                .ToList();

            var updatedDistricts = _context.Districts.Where((p) => p.CreatedOn < lastPulledAt && p.UpdatedOn > lastPulledAt)
                .Select(DistrictsMapper.Map)
                .ToList();

            var deletedDistricts = _context.Districts.Where((p) => p.CreatedOn < lastPulledAt && p.RemovedOn > lastPulledAt)
                .Select(p => p.Id.ToString())
                .ToList();

            //Regadio
            var createdRegadio = _context.Regadios.Where((r) => r.CreatedOn >= lastPulledAt && (r.IsRemoved == null || r.IsRemoved == false))
                .Select(RegadioMapper.Map)
                .ToList();

            var updatedRegadio = _context.Regadios.Where((r) => r.CreatedOn < lastPulledAt && r.UpdatedOn > lastPulledAt && (r.IsRemoved == null || r.IsRemoved == false))
                .Select(RegadioMapper.Map)
                .ToList();

            var deletedRegadio = _context.Regadios.Where((r) => r.CreatedOn < lastPulledAt && r.RemovedOn > lastPulledAt && r.IsRemoved == true)
                .Select(r => r.Id.ToString())
                .ToList();

            //InqueritoResponses
            var createdResponsesInquerito = _context.ResponsesInqueritos.Where((r) => r.CreatedOn >= lastPulledAt && (r.IsRemoved == null || r.IsRemoved == false) && r.ApprovedOn == null)
                .Select(ResponsesInqueritoMapper.Map)
                .ToList();

            var updatedResponsesInquerito = _context.ResponsesInqueritos.Where((r) => r.CreatedOn < lastPulledAt && r.UpdatedOn > lastPulledAt && (r.IsRemoved == null || r.IsRemoved == false) && r.ApprovedOn == null)
                .Select(ResponsesInqueritoMapper.Map)
                .ToList();

            var deletedResponsesInquerito = _context.ResponsesInqueritos.Where((r) => r.CreatedOn < lastPulledAt && r.RemovedOn > lastPulledAt && r.IsRemoved == true && r.ApprovedOn == null)
                .Select(r => r.Id.ToString())
                .ToList();

            //InqueritoResponsesApproved
            var createdInqueritoResponsesApproved = _context.ResponsesInqueritos.Where((r) => r.ApprovedOn >= lastPulledAt && (r.IsRemoved == null || r.IsRemoved == false))
                .Select(InqueritoResponsesAprovedMapper.Map)
                .ToList();

            var updatedInqueritoResponsesApproved = _context.ResponsesInqueritos.Where((r) => r.ApprovedOn < lastPulledAt && r.UpdatedOn > lastPulledAt && (r.IsRemoved == null || r.IsRemoved == false))
                .Select(InqueritoResponsesAprovedMapper.Map)
                .ToList();

            var deletedInqueritoResponsesApproved = _context.ResponsesInqueritos.Where((r) => r.ApprovedOn < lastPulledAt && r.RemovedOn > lastPulledAt && r.IsRemoved == true)
                .Select(r => r.Id.ToString())
                .ToList();

            //SubInquerito
            var createdSubInquerito = _context.SubInqueritos.Where((s) => s.CreatedOn >= lastPulledAt && (s.IsRemoved == null || s.IsRemoved == false))
                .Select(SubInqueritoMapper.Map)
                .ToList();

            var updatedSubInquerito = _context.SubInqueritos.Where((s) => s.CreatedOn < lastPulledAt && s.UpdatedOn > lastPulledAt && (s.IsRemoved == null || s.IsRemoved == false))
                .Select(SubInqueritoMapper.Map)
                .ToList();

            var deletedSubInquerito = _context.SubInqueritos.Where((s) => s.CreatedOn < lastPulledAt && s.RemovedOn > lastPulledAt && s.IsRemoved == true)
                .Select(s => s.Id.ToString())
                .ToList();

            //TipoCultura
            var createdTipoCultura = _context.TipoCulturas.Where((t) => t.CreatedOn >= lastPulledAt && (t.IsRemoved == null || t.IsRemoved == false))
                .Select(TipoCulturaMapper.Map)
                .ToList();

            var updatedTipoCultura = _context.TipoCulturas.Where((t) => t.CreatedOn < lastPulledAt && t.UpdatedOn > lastPulledAt && (t.IsRemoved == null || t.IsRemoved == false))
                .Select(TipoCulturaMapper.Map)
                .ToList();

            var deletedTipoCultura = _context.TipoCulturas.Where((t) => t.CreatedOn < lastPulledAt && t.RemovedOn > lastPulledAt && t.IsRemoved == true)
                .Select(t => t.Id.ToString())
                .ToList();

            //UsuarioAssociacoes
            var createdUsuarioAssociacoes = _context.UsuarioAssociacoes.Where((usuario) => usuario.CreatedOn >= lastPulledAt && (usuario.IsRemoved == null || usuario.IsRemoved == false))
                .Select(UsuarioAssociacoesMapper.Map)
                .ToList();

            var updatedUsuarioAssociacoes = _context.UsuarioAssociacoes.Where((usuario) => usuario.CreatedOn < lastPulledAt && usuario.UpdatedOn > lastPulledAt && (usuario.IsRemoved == null || usuario.IsRemoved == false))
                .Select(UsuarioAssociacoesMapper.Map)
                .ToList();

            var deletedUsuarioAssociacoes = _context.UsuarioAssociacoes.Where((usuario) => usuario.CreatedOn < lastPulledAt && usuario.RemovedOn > lastPulledAt && usuario.IsRemoved == true)
                .Select(u => u.Id.ToString())
                .ToList();

            //UsuarioEscolas
            var createdUsuarioEscolas = _context.UsuarioEscolas.Where((usuario) => usuario.CreatedOn >= lastPulledAt && (usuario.IsRemoved == null || usuario.IsRemoved == false))
                .Select(UsuarioEscolasMapper.Map)
                .ToList();

            var updatedUsuarioEscolas = _context.UsuarioEscolas.Where((usuario) => usuario.CreatedOn < lastPulledAt && usuario.UpdatedOn > lastPulledAt && (usuario.IsRemoved == null || usuario.IsRemoved == false))
                .Select(UsuarioEscolasMapper.Map)
                .ToList();

            var deletedUsuarioEscolas = _context.UsuarioEscolas.Where((usuario) => usuario.CreatedOn < lastPulledAt && usuario.RemovedOn > lastPulledAt && usuario.IsRemoved == true)
                .Select(u => u.Id.ToString())
                .ToList();

            //UsuarioInqueritos
            var createdUsuarioInqueritos = _context.UsuarioInqueritos.Where((usuario) => usuario.CreatedOn >= lastPulledAt && (usuario.IsRemoved == null || usuario.IsRemoved == false))
                .Select(UsuarioInqueritosMapper.Map)
                .ToList();

            var updatedUsuarioInqueritos = _context.UsuarioInqueritos.Where((usuario) => usuario.CreatedOn < lastPulledAt && usuario.UpdatedOn > lastPulledAt && (usuario.IsRemoved == null || usuario.IsRemoved == false))
                .Select(UsuarioInqueritosMapper.Map)
                .ToList();

            var deletedUsuarioInqueritos = _context.UsuarioInqueritos.Where((usuario) => usuario.CreatedOn < lastPulledAt && usuario.RemovedOn > lastPulledAt && usuario.IsRemoved == true)
                .Select(u => u.Id.ToString())
                .ToList();

            //UsuarioRegadios
            var createdUsuarioRegadios = _context.UsuarioRegadios.Where((usuario) => usuario.CreatedOn >= lastPulledAt && (usuario.IsRemoved == null || usuario.IsRemoved == false))
                .Select(UsuarioRegadiosMapper.Map)
                .ToList();

            var updatedUsuarioRegadios = _context.UsuarioRegadios.Where((usuario) => usuario.CreatedOn < lastPulledAt && usuario.UpdatedOn > lastPulledAt && (usuario.IsRemoved == null || usuario.IsRemoved == false))
                .Select(UsuarioRegadiosMapper.Map)
                .ToList();

            var deletedUsuarioRegadios = _context.UsuarioRegadios.Where((usuario) => usuario.CreatedOn < lastPulledAt && usuario.RemovedOn > lastPulledAt && usuario.IsRemoved == true)
                .Select(u => u.Id.ToString())
                .ToList();

            //Usuarios
            var createdUsuarios = _context.Usuarios.Where((usuario) => usuario.CreatedOn >= lastPulledAt && (usuario.IsRemoved == null || usuario.IsRemoved == false))
                .Select(UsuariosMapper.Map)
                .ToList();

            var updatedUsuarios = _context.Usuarios.Where((usuario) => usuario.CreatedOn < lastPulledAt && usuario.UpdatedOn > lastPulledAt && (usuario.IsRemoved == null || usuario.IsRemoved == false))
                .Select(UsuariosMapper.Map)
                .ToList();

            var deletedUsuarios = _context.Usuarios.Where((usuario) => usuario.CreatedOn < lastPulledAt && usuario.RemovedOn > lastPulledAt && usuario.IsRemoved == true)
                .Select(u => u.Id.ToString())
                .ToList();

            //Save Sync Mobile Date
            if (lastPulledAt != null) { 
                var mobile =  Create(new MobileSync()
                {
                    SyncOn = lastPulledAt,
                    SyncedBy = user,
                    DeviceImei = device,
                    Tipo = "GET"
                });
            }
            else
            {
                var mobile = Create(new MobileSync()
                {
                    SyncOn = DateTime.Now,
                    SyncedBy = user,
                    DeviceImei = device,
                    Tipo = "GET"
                });
            }

            return new SyncRequest()
            {
                Associacao = new RequestMapper<AssociacaoSync> { Created = createdAssociacaos, Updated = updatedAssociacaos, Deleted = deletedAssociacaos },
                BeneficiarioEscolas = new RequestMapper<BeneficiarioEscolasSync> { Created = createdBeneficiarioEscolas, Updated = updatedBeneficiarioEscolas, Deleted = deletedBeneficiarioEscolas },
                Beneficiario = new RequestMapper<BeneficiarioSync> { Created = createdBeneficiario, Updated = updatedBeneficiario, Deleted = deletedBeneficiario },
                Cultura = new RequestMapper<CulturaSync> { Created = createdCultura, Updated = updatedCultura, Deleted = deletedCultura },
                CulturaTipo = new RequestMapper<TipoCulturaSync> { Created = createdTipoCultura, Updated = updatedTipoCultura, Deleted = deletedTipoCultura },
                EscolaMachamba = new RequestMapper<EscolaMachambaSync> { Created = createdEscolaMachamba, Updated = updatedEscolaMachamba, Deleted = deletedEscolaMachamba },
                Regadio = new RequestMapper<RegadioSync> { Created = createdRegadio, Updated = updatedRegadio, Deleted = deletedRegadio },
                EscolaRegadios = new RequestMapper<EscolaRegadiosSync> { Created = createdEscolaRegadios, Updated = updatedEscolaRegadios, Deleted = deletedEscolaRegadios },
                AssociacaoRegadio = new RequestMapper<AssociacaoRegadioSync> { Created = createdAssociacaoRegadio, Updated = updatedAssociacaoRegadio, Deleted = deletedAssociacaoRegadio },
                Fieldsets = new RequestMapper<FieldsetsSync> { Created = createdFieldsets, Updated = updatedFieldsets, Deleted = deletedFieldsets },
                Inquerito = new RequestMapper<InqueritoSync> { Created = createdInquerito, Updated = updatedInquerito, Deleted = deletedInquerito },
                InqueritoPergunta = new RequestMapper<InqueritoPerguntaSync> { Created = createdInqueritoPergunta, Updated = updatedInqueritoPergunta, Deleted = deletedInqueritoPergunta },
                InqueritoResponses = new RequestMapper<ResponsesInqueritoSync> { Created = createdResponsesInquerito, Updated = updatedResponsesInquerito, Deleted = deletedResponsesInquerito },
                InqueritoResponsesApproved = new RequestMapper<InqueritoResponsesAprovedSync> { Created = createdInqueritoResponsesApproved, Updated = updatedInqueritoResponsesApproved, Deleted = deletedInqueritoResponsesApproved },
                InqueritoResposta = new RequestMapper<InqueritoRespostaSync> { Created = createdInqueritoResposta, Updated = updatedInqueritoResposta, Deleted = deletedInqueritoResposta },
                PerguntaOpcao = new RequestMapper<PerguntaOpcaoSync> { Created = createdPerguntaOpcao, Updated = updatedPerguntaOpcao, Deleted = deletedPerguntaOpcao },
                Provinces = new RequestMapper<ProvincesSync> { Created = createdProvincias, Updated = updatedProvincias, Deleted = deletedProvincias },
                Districts = new RequestMapper<DistrictsSync> { Created = createdDistricts, Updated = updatedDistricts, Deleted = deletedDistricts },
                InqueritoSub = new RequestMapper<SubInqueritoSync> { Created = createdSubInquerito, Updated = updatedSubInquerito, Deleted = deletedSubInquerito },
                Usuarios = new RequestMapper<UsuariosSync> { Created = createdUsuarios, Updated = updatedUsuarios, Deleted = deletedUsuarios },
                UsuarioAssociacoes = new RequestMapper<UsuarioAssociacoesSync> { Created = createdUsuarioAssociacoes, Updated = updatedUsuarioAssociacoes, Deleted = deletedUsuarioAssociacoes },
                UsuarioEscolas = new RequestMapper<UsuarioEscolasSync> { Created = createdUsuarioEscolas, Updated = updatedUsuarioEscolas, Deleted = deletedUsuarioEscolas },
                UsuarioInqueritos = new RequestMapper<UsuarioInqueritosSync> { Created = createdUsuarioInqueritos, Updated = updatedUsuarioInqueritos, Deleted = deletedUsuarioInqueritos },
                UsuarioRegadios = new RequestMapper<UsuarioRegadiosSync> { Created = createdUsuarioRegadios, Updated = updatedUsuarioRegadios, Deleted = deletedUsuarioRegadios },
                
            };

        }
        public string Push(SyncRequest request, string user, string deviceIME)
        {
            var time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            try { 
            //Associacao
            if (request.Associacao.Created.Count > 0)
            {
                _context.Associacaos.AddRange(request.Associacao.Created.ConvertAll((associacao) => new Associacao()
                {
                    Id = associacao.Id,
                    Designacao = associacao.Designacao,
                    IdRegadio = associacao.RegadioId,
                    NumHomens = associacao.NumHomens,
                    NumMulheres = associacao.NumMulheres,
                    CreatedOn = associacao.CreatedOn,
                    CreatedBy = associacao.CreatedBy,
                    IsRemoved = false
                }));
            }
            if (request.Associacao.Updated.Count > 0)
            {
                _context.Associacaos.UpdateRange(request.Associacao.Updated.ConvertAll((associacao) => new Associacao()
                {
                    Designacao = associacao.Designacao,
                    IdRegadio = associacao.RegadioId,
                    NumHomens = associacao.NumHomens,
                    NumMulheres = associacao.NumMulheres,
                    CreatedOn = associacao.CreatedOn,
                    RemovedOn = associacao.RemovedOn,
                    RemovedBy = associacao.RemovedBy,
                    UpdatedOn = associacao.UpdatedOn,
                    UpdatedBy =  associacao.UpdatedBy,
                    CreatedBy = associacao.CreatedBy,
                    IsRemoved = associacao.IsRemoved
                }));
            }
            if (request.Associacao.Deleted.Count > 0)
            {
                var deletedAssociacao = _context.Associacaos.Where((associacao) => request.Associacao.Deleted.Any(x => x == associacao.Id.ToString())).ToList();
                _context.Associacaos.RemoveRange(deletedAssociacao);
            }

            _context.SaveChanges();

            //Beneficiario
            if (request.Beneficiario.Created.Count > 0)
            {
                _context.Beneficiarios.AddRange(request.Beneficiario.Created.ConvertAll((beneficiario) => new Beneficiario()
                {
                    Id = beneficiario.Id,
                    Nome = beneficiario.Nome,
                    Apelido = beneficiario.Apelido,
                    Genero = beneficiario.Genero,
                    DataNascimento = beneficiario.DataNascimento,
                    Telefone = beneficiario.Telefone,
                    TipoDocIdentificacao = beneficiario.TipoDocIdentificacao,
                    NumDodcIdenticacao = beneficiario.NumDodcIdenticacao,
                    DataValidade = beneficiario.DataValidade,
                    Localidade = beneficiario.Localidade,
                    Endereco = beneficiario.Endereco,
                    Localizacao = beneficiario.Localizacao,
                    AgregadoHomens = beneficiario.AgregadoHomens,
                    AgregadoMulheres = beneficiario.AgregadoMulheres,
                    AgregadoHomensTrab = beneficiario.AgregadoHomensTrab,
                    AgregadoMulheresTrab = beneficiario.AgregadoMulheresTrab,
                    CodeBenificiario = beneficiario.CodeBenificiario,
                    IdAssociacao = beneficiario.AssociacaoId,
                    IdRegadio = beneficiario.RegadioId,
                    IdEscola = beneficiario.EscolaId,
                    CreatedOn = beneficiario.CreatedOn,
                    CreatedBy = beneficiario.CreatedBy,
                    IsRemoved = false
                }));
            }
            if (request.Beneficiario.Updated.Count > 0)
            {
                _context.Beneficiarios.UpdateRange(request.Beneficiario.Updated.ConvertAll((beneficiario) => new Beneficiario()
                {
                    Nome = beneficiario.Nome,
                    Apelido = beneficiario.Apelido,
                    Genero = beneficiario.Genero,
                    DataNascimento = beneficiario.DataNascimento,
                    Telefone = beneficiario.Telefone,
                    TipoDocIdentificacao = beneficiario.TipoDocIdentificacao,
                    NumDodcIdenticacao = beneficiario.NumDodcIdenticacao,
                    DataValidade = beneficiario.DataValidade,
                    Localidade = beneficiario.Localidade,
                    Endereco = beneficiario.Endereco,
                    Localizacao = beneficiario.Localizacao,
                    AgregadoHomens = beneficiario.AgregadoHomens,
                    AgregadoMulheres = beneficiario.AgregadoMulheres,
                    AgregadoHomensTrab = beneficiario.AgregadoHomensTrab,
                    AgregadoMulheresTrab = beneficiario.AgregadoMulheresTrab,
                    CodeBenificiario = beneficiario.CodeBenificiario,
                    IdAssociacao = beneficiario.AssociacaoId,
                    IdRegadio = beneficiario.RegadioId,
                    IdEscola = beneficiario.EscolaId,
                    CreatedOn = beneficiario.CreatedOn,
                    CreatedBy = beneficiario.CreatedBy,
                    IsRemoved = beneficiario.IsRemoved,
                    RemovedBy = beneficiario.RemovedBy,
                    RemovedOn = beneficiario.RemovedOn,
                    UpdatedBy = beneficiario.UpdatedBy,
                    UpdatedOn = beneficiario.UpdatedOn
                }));
            }
            if (request.Beneficiario.Deleted.Count > 0)
            {
                var deletedBeneficiario = _context.Beneficiarios.Where((beneficiario) => request.Beneficiario.Deleted.Any(a => a == beneficiario.Id.ToString())).ToList();
                _context.Beneficiarios.RemoveRange(deletedBeneficiario);
            }

            _context.SaveChanges();

            //TipoCultura
            if (request.CulturaTipo.Created.Count > 0)
            {
                _context.TipoCulturas.AddRange(request.CulturaTipo.Created.ConvertAll((tipo) => new TipoCultura()
                {
                    Id = tipo.Id,
                    Designacao = tipo.Designacao,
                    IsRemoved = false,
                    CreatedBy = tipo.CreatedBy,
                    CreatedOn = tipo.CreatedOn,
                }));
            }
            if (request.CulturaTipo.Updated.Count > 0)
            {
                _context.TipoCulturas.UpdateRange(request.CulturaTipo.Updated.ConvertAll((tipo) => new TipoCultura()
                {
                    Designacao = tipo.Designacao,
                    CreatedOn = tipo.CreatedOn,
                    CreatedBy = tipo.CreatedBy,
                    RemovedOn = tipo.RemovedOn,
                    RemovedBy = tipo.RemovedBy,
                    IsRemoved = tipo.IsRemoved,
                    UpdatedOn = tipo.UpdatedOn,
                    UpdatedBy = tipo.UpdatedBy
                }));
            }
            if (request.CulturaTipo.Deleted.Count > 0)
            {
                var deletedTipoCultura = _context.TipoCulturas.Where((tipo) => request.CulturaTipo.Deleted.Any(i => i == tipo.Id.ToString())).ToList();
                _context.TipoCulturas.RemoveRange(deletedTipoCultura);
            }
            _context.SaveChanges();

            //Cultura
            if (request.Cultura.Created.Count > 0)
            {
                _context.Culturas.AddRange(request.Cultura.Created.ConvertAll((cultura) => new Cultura()
                {
                    Id = cultura.Id,
                    Designacao = cultura.Designacao,
                    AreaCultivada = cultura.AreaCultivada,
                    Redimento = cultura.Redimento,
                    IdTipoCultura = cultura.TipoCulturaId,
                    CreatedOn = cultura.CreatedOn,
                    CreatedBy = cultura.CreatedBy,
                    IsRemoved = false
                }));
            }
            if (request.Cultura.Updated.Count > 0)
            {
                _context.Culturas.UpdateRange(request.Cultura.Updated.ConvertAll((cultura) => new Cultura()
                {
                    Designacao = cultura.Designacao,
                    AreaCultivada = cultura.AreaCultivada,
                    Redimento = cultura.Redimento,
                    IdTipoCultura = cultura.TipoCulturaId,
                    CreatedOn = cultura.CreatedOn,
                    CreatedBy = cultura.CreatedBy,
                    RemovedOn = cultura.RemovedOn,
                    RemovedBy = cultura.RemovedBy,
                    UpdatedOn = cultura.UpdatedOn,
                    UpdatedBy = cultura.UpdatedBy,
                    IsRemoved = cultura.IsRemoved
                }));
            }
            if (request.Cultura.Deleted.Count > 0)
            {
                var deletedCultura = _context.Culturas.Where((cultura) => request.Cultura.Deleted.Any(a => a == cultura.Id.ToString())).ToList();
                _context.Culturas.RemoveRange(deletedCultura);
            }

            _context.SaveChanges();

            //EscolaMachamba
            if (request.EscolaMachamba.Created.Count > 0)
            {
                _context.EscolaMachambas.AddRange(request.EscolaMachamba.Created.ConvertAll((escola) => new EscolaMachamba()
                {
                    Id = escola.Id,
                    Designacao = escola.Designacao,
                    NumHomens = escola.NumHomens,
                    NumMulheres = escola.NumMulheres,
                    Metodologia = escola.Metodologia,
                    AreaEscola = escola.AreaEscola,
                    Localizacao = escola.Localizacao,
                    CreatedBy = escola.CreatedBy,
                    IsRemoved = false
                }));
            }
            if (request.EscolaMachamba.Updated.Count > 0)
            {
                _context.EscolaMachambas.UpdateRange(request.EscolaMachamba.Updated.ConvertAll((escola) => new EscolaMachamba()
                {
                    Designacao = escola.Designacao,
                    NumHomens = escola.NumHomens,
                    NumMulheres = escola.NumMulheres,
                    Metodologia = escola.Metodologia,
                    AreaEscola = escola.AreaEscola,
                    Localizacao = escola.Localizacao,
                    CreatedOn = escola.CreatedOn,
                    CreatedBy = escola.CreatedBy,
                    RemovedOn = escola.RemovedOn,
                    RemovedBy = escola.RemovedBy,
                    UpdatedOn = escola.UpdatedOn,
                    UpdatedBy = escola.UpdatedBy,
                    IsRemoved = escola.IsRemoved
                }));
            }
            if (request.EscolaMachamba.Deleted.Count > 0)
            {
                var deletedEscolaMachamba = _context.EscolaMachambas.Where((escola) => request.EscolaMachamba.Deleted.Any(a => a == escola.Id.ToString())).ToList();
                _context.EscolaMachambas.RemoveRange(deletedEscolaMachamba);
            }

            _context.SaveChanges();

            //BeneficiarioEscolas
            if (request.BeneficiarioEscolas.Created.Count > 0)
            {
                _context.BeneficiarioEscolas.AddRange(request.BeneficiarioEscolas.Created.ConvertAll((beneficiario) => new BeneficiarioEscola()
                {
                    Id = beneficiario.Id,
                    IdBeneficiario = beneficiario.BeneficiarioId,
                    IdEscola = beneficiario.EscolaId,
                    CreatedOn = beneficiario.CreatedOn,
                    CreatedBy = beneficiario.CreatedBy,
                    IsRemoved = false
                }));
            }
            if (request.BeneficiarioEscolas.Updated.Count > 0)
            {
                _context.BeneficiarioEscolas.UpdateRange(request.BeneficiarioEscolas.Updated.ConvertAll((beneficiario) => new BeneficiarioEscola()
                {
                    IdBeneficiario = beneficiario.BeneficiarioId,
                    IdEscola = beneficiario.EscolaId,
                    CreatedOn = beneficiario.CreatedOn,
                    CreatedBy = beneficiario.CreatedBy,
                    RemovedOn = beneficiario.RemovedOn,
                    RemovedBy = beneficiario.RemovedBy,
                    UpdatedOn = beneficiario.UpdatedOn,
                    UpdatedBy = beneficiario.UpdatedBy,
                    IsRemoved = beneficiario.IsRemoved
                }));
            }
            if (request.BeneficiarioEscolas.Deleted.Count > 0)
            {
                var deletedBeneficiarioEscolas = _context.BeneficiarioEscolas.Where((beneficiario) => request.BeneficiarioEscolas.Deleted.Any(a => a == beneficiario.Id.ToString())).ToList();
                _context.BeneficiarioEscolas.RemoveRange(deletedBeneficiarioEscolas);
            }

            _context.SaveChanges();

            //Regadio
            if (request.Regadio.Created.Count > 0)
            {
                _context.Regadios.AddRange(request.Regadio.Created.ConvertAll((regadio) => new Regadio()
                {
                    Id = regadio.Id,
                    CodeRegadio = regadio.CodeRegadio,
                    Localizacao = regadio.Localizacao,
                    Designacao = regadio.Designacao,
                    IdAssociacao = regadio.AssociacaoId,
                    IdEscola = regadio.EscolaId,
                    CreatedBy = regadio.CreatedBy,
                    CreatedOn = regadio.CreatedOn,
                    IsRemoved = false
                }));
            }
            if (request.Regadio.Updated.Count > 0)
            {
                _context.Regadios.UpdateRange(request.Regadio.Updated.ConvertAll((regadio) => new Regadio()
                {
                    CodeRegadio = regadio.CodeRegadio,
                    Localizacao = regadio.Localizacao,
                    Designacao = regadio.Designacao,
                    IdAssociacao = regadio.AssociacaoId,
                    IdEscola = regadio.EscolaId,
                    CreatedOn = regadio.CreatedOn,
                    CreatedBy = regadio.CreatedBy,
                    RemovedOn = regadio.RemovedOn,
                    RemovedBy = regadio.RemovedBy,
                    UpdatedOn = regadio.UpdatedOn,
                    UpdatedBy = regadio.UpdatedBy,
                    IsRemoved = regadio.IsRemoved
                }));
            }
            if (request.Regadio.Deleted.Count > 0)
            {
                var deletedRegadio = _context.Regadios.Where((regadio) => request.Regadio.Deleted.Any(r => r == regadio.Id.ToString())).ToList();
                _context.Regadios.RemoveRange(deletedRegadio);
            }
            _context.SaveChanges();

            //EscolaRegadios
            if (request.EscolaRegadios.Created.Count > 0)
            {
                _context.EscolaRegadios.AddRange(request.EscolaRegadios.Created.ConvertAll((escola) => new EscolaRegadio()
                {
                    Id = escola.Id,
                    IdEscola = escola.EscolaId,
                    IdRegadio = escola.RegadioId,
                    CreatedBy = escola.CreatedBy,
                    CreatedOn = escola.CreatedOn,
                    IsRemoved = false
                }));
            }
            if (request.EscolaRegadios.Updated.Count > 0)
            {
                _context.EscolaRegadios.UpdateRange(request.EscolaRegadios.Updated.ConvertAll((escola) => new EscolaRegadio()
                {
                    IdEscola = escola.EscolaId,
                    IdRegadio = escola.RegadioId,
                    CreatedOn = escola.CreatedOn,
                    CreatedBy = escola.CreatedBy,
                    RemovedOn = escola.RemovedOn,
                    RemovedBy = escola.RemovedBy,
                    UpdatedOn = escola.UpdatedOn,
                    UpdatedBy = escola.UpdatedBy,
                    IsRemoved = escola.IsRemoved
                }));
            }
            if (request.EscolaRegadios.Deleted.Count > 0)
            {
                var deletedEscolaRegadios = _context.EscolaRegadios.Where((escola) => request.EscolaRegadios.Deleted.Any(a => a == escola.Id.ToString())).ToList();
                _context.EscolaRegadios.RemoveRange(deletedEscolaRegadios);
            }
            _context.SaveChanges();

            //AssociacaoRegadios
            if (request.AssociacaoRegadio.Created.Count > 0)
            {
                _context.AssociacaoRegadios.AddRange(request.AssociacaoRegadio.Created.ConvertAll((associacaoRegadios) => new AssociacaoRegadio()
                {
                    Id = associacaoRegadios.Id,
                    IdAssociacao = associacaoRegadios.AssociacaoId,
                    IdRegadio = associacaoRegadios.RegadioId,
                    CreatedOn = associacaoRegadios.CreatedOn,
                    CreatedBy = associacaoRegadios.CreatedBy,
                    IsRemoved = false
                }));
            }
            if (request.AssociacaoRegadio.Updated.Count > 0)
            {
                _context.AssociacaoRegadios.UpdateRange(request.AssociacaoRegadio.Updated.ConvertAll((associacaoRegadios) => new AssociacaoRegadio()
                {
                    IdAssociacao = associacaoRegadios.AssociacaoId,
                    IdRegadio = associacaoRegadios.RegadioId,
                    RemovedBy = associacaoRegadios.RemovedBy,
                    RemovedOn = associacaoRegadios.RemovedOn,
                    UpdatedOn = associacaoRegadios.UpdatedOn,
                    IsRemoved = associacaoRegadios.IsRemoved,
                    CreatedOn = associacaoRegadios.CreatedOn,
                    CreatedBy = associacaoRegadios.CreatedBy,
                    UpdatedBy = associacaoRegadios.UpdatedBy
                }));
            }
            if (request.AssociacaoRegadio.Deleted.Count > 0)
            {
                var deletedAssociacaoRegadio = _context.AssociacaoRegadios.Where((associacaoRegadios) => request.AssociacaoRegadio.Deleted.Any(x => x == associacaoRegadios.Id.ToString())).ToList();
                _context.AssociacaoRegadios.RemoveRange(deletedAssociacaoRegadio);
            }

            _context.SaveChanges();

            //Fieldsets
            if (request.Fieldsets.Created.Count > 0)
            {
                _context.Fieldsets.AddRange(request.Fieldsets.Created.ConvertAll((fieldset) => new Fieldset()
                {
                    Id = fieldset.Id,
                    Label = fieldset.Label,
                    Description = fieldset.Description,
                    IdInquerito = fieldset.InqueritoId,
                    FieldsetsOrder = fieldset.FieldsetsOrder,
                    IdPergunta = fieldset.PerguntaId,
                    CreatedBy = fieldset.CreatedBy,
                    CreatedOn = fieldset.CreatedOn,
                    IsRemoved = false
                }));
            }
            if (request.Fieldsets.Updated.Count > 0)
            {
                _context.Fieldsets.UpdateRange(request.Fieldsets.Updated.ConvertAll((fieldset) => new Fieldset()
                {
                    Label = fieldset.Label,
                    Description = fieldset.Description,
                    IdInquerito = fieldset.InqueritoId,
                    FieldsetsOrder = fieldset.FieldsetsOrder,
                    IdPergunta = fieldset.PerguntaId,
                    CreatedOn = fieldset.CreatedOn,
                    CreatedBy = fieldset.CreatedBy,
                    RemovedOn = fieldset.RemovedOn,
                    RemovedBy = fieldset.RemovedBy,
                    UpdatedOn = fieldset.UpdatedOn,
                    UpdatedBy = fieldset.UpdatedBy,
                    IsRemoved = fieldset.IsRemoved
                }));
            }
            if (request.Fieldsets.Deleted.Count > 0)
            {
                var deletedFieldsets = _context.Fieldsets.Where((fieldset) => request.Fieldsets.Deleted.Any(f => f == fieldset.Id.ToString())).ToList();
                _context.Fieldsets.RemoveRange(deletedFieldsets);
            }
            _context.SaveChanges();

            //Inquerito
            if (request.Inquerito.Created.Count > 0)
            {
                _context.Inqueritos.AddRange(request.Inquerito.Created.ConvertAll((inquerito) => new Inquerito()
                {
                    Id = inquerito.Id,
                    Designacao = inquerito.Designacao,
                    Descricao = inquerito.Descricao,
                    IdInqueritoPai = inquerito.ParentInqueritoId,
                    Versao = inquerito.Versao,
                    IsMobile = true,
                    IsPrincipal = inquerito.IsPrincipal,
                    CreatedBy = inquerito.CreatedBy,
                    CreatedOn = inquerito.CreatedOn,
                }));
            }
            if (request.Inquerito.Updated.Count > 0)
            {
                _context.Inqueritos.UpdateRange(request.Inquerito.Updated.ConvertAll((inquerito) => new Inquerito()
                {
                    Designacao = inquerito.Designacao,
                    Descricao = inquerito.Descricao,
                    IdInqueritoPai = inquerito.ParentInqueritoId,
                    Versao = inquerito.Versao,
                    IsMobile = true,
                    IsPrincipal = inquerito.IsPrincipal,
                    CreatedOn = inquerito.CreatedOn,
                    CreatedBy = inquerito.CreatedBy,
                    RemovedOn = inquerito.RemovedOn,
                    RemovedBy = inquerito.RemovedBy,
                    UpdatedOn = inquerito.UpdatedOn,
                    UpdatedBy = inquerito.UpdatedBy
                }));
            }
            if (request.Inquerito.Deleted.Count > 0)
            {
                var deletedInquerito = _context.Inqueritos.Where((inquerito) => request.Inquerito.Deleted.Any(i => i == inquerito.Id.ToString())).ToList();
                _context.Inqueritos.RemoveRange(deletedInquerito);
            }
            _context.SaveChanges();

            //SubInquerito
            if (request.InqueritoSub.Created.Count > 0)
            {
                _context.SubInqueritos.AddRange(request.InqueritoSub.Created.ConvertAll((inquerito) => new SubInquerito()
                {
                    Id = inquerito.Id,
                    IdInquerito = inquerito.InqueritoId,
                    IdSubInquerito = inquerito.SubInqueritoId,
                    OrderInquerito = inquerito.InqueritoOrder,
                    CreatedBy = inquerito.CreatedBy,
                    CreatedOn = inquerito.CreatedOn,
                }));
            }
            if (request.InqueritoSub.Updated.Count > 0)
            {
                _context.SubInqueritos.UpdateRange(request.InqueritoSub.Updated.ConvertAll((inquerito) => new SubInquerito()
                {
                    IdInquerito = inquerito.InqueritoId,
                    IdSubInquerito = inquerito.SubInqueritoId,
                    OrderInquerito = inquerito.InqueritoOrder,
                    CreatedOn = inquerito.CreatedOn,
                    CreatedBy = inquerito.CreatedBy,
                    RemovedOn = inquerito.RemovedOn,
                    RemovedBy = inquerito.RemovedBy,
                    UpdatedOn = inquerito.UpdatedOn,
                    UpdatedBy = inquerito.UpdatedBy,
                    IsRemoved = inquerito.IsRemoved
                }));
            }
            if (request.InqueritoSub.Deleted.Count > 0)
            {
                var deletedSubInquerito = _context.SubInqueritos.Where((inquerito) => request.InqueritoSub.Deleted.Any(i => i == inquerito.Id.ToString())).ToList();
                _context.SubInqueritos.RemoveRange(deletedSubInquerito);
            }
            _context.SaveChanges();

            //InqueritoPergunta
            if (request.InqueritoPergunta.Created.Count > 0)
            {
                _context.InqueritoPergunta.AddRange(request.InqueritoPergunta.Created.ConvertAll((inquerito) => new InqueritoPerguntum()
                {
                    Id = inquerito.Id,
                    Descricao = inquerito.Descricao,
                    IdInquerito = inquerito.InqueritoId,
                    ValidacaoComponente = inquerito.ValidacaoComponente,
                    CaracteristicasComponente = inquerito.CaracteristicasComponente,
                    QuestionOrder = inquerito.QuestionOrder,
                    IdFieldset = inquerito.FieldsetId,
                    IdForm = inquerito.FormId,
                    CreatedBy = inquerito.CreatedBy,
                    CreatedOn = inquerito.CreatedOn,
                    IsRemoved = false
                }));
            }
            if (request.InqueritoPergunta.Updated.Count > 0)
            {
                _context.InqueritoPergunta.UpdateRange(request.InqueritoPergunta.Updated.ConvertAll((inquerito) => new InqueritoPerguntum()
                {
                    Descricao = inquerito.Descricao,
                    IdInquerito = inquerito.InqueritoId,
                    ValidacaoComponente = inquerito.ValidacaoComponente,
                    CaracteristicasComponente = inquerito.CaracteristicasComponente,
                    QuestionOrder = inquerito.QuestionOrder,
                    IdFieldset = inquerito.FieldsetId,
                    IdForm = inquerito.FormId,
                    CreatedOn = inquerito.CreatedOn,
                    CreatedBy = inquerito.CreatedBy,
                    RemovedOn = inquerito.RemovedOn,
                    RemovedBy = inquerito.RemovedBy,
                    UpdatedOn = inquerito.UpdatedOn,
                    UpdatedBy = inquerito.UpdatedBy,
                    IsRemoved = inquerito.IsRemoved
                }));
            }
            if (request.InqueritoPergunta.Deleted.Count > 0)
            {
                var deletedInqueritoPergunta = _context.InqueritoPergunta.Where((inquerito) => request.InqueritoPergunta.Deleted.Any(i => i == inquerito.Id.ToString())).ToList();
                _context.InqueritoPergunta.RemoveRange(deletedInqueritoPergunta);
            }
            _context.SaveChanges();

            //InqueritoResponses
            if (request.InqueritoResponses.Created.Count > 0)
            {
                _context.ResponsesInqueritos.AddRange(request.InqueritoResponses.Created.ConvertAll((responses) => new ResponsesInquerito()
                {
                    Id = responses.Id,
                    IdInquerito = responses.InqueritoId,
                    LastStep = responses.LastStep,
                    CreatedBy = responses.CreatedBy,
                    CreatedOn = responses.CreatedOn,
                    IsRemoved = false,
                    IdBeneficiario = responses.BeneficiarioId,
                    IdEscola = responses.EscolaId,
                    IdRegadio = responses.RegadioId,
                    IdInqueritoPai = responses.ParentInqueritoId,
                    IdResponsesPai = responses.ParentResponseId
                }));
            }
            if (request.InqueritoResponses.Updated.Count > 0)
            {
                _context.ResponsesInqueritos.UpdateRange(request.InqueritoResponses.Updated.ConvertAll((responses) => new ResponsesInquerito()
                {
                    IdInquerito = responses.InqueritoId,
                    LastStep = responses.LastStep,
                    CreatedOn = responses.CreatedOn,
                    CreatedBy = responses.CreatedBy,
                    RemovedOn = responses.RemovedOn,
                    RemovedBy = responses.RemovedBy,
                    UpdatedOn = responses.UpdatedOn,
                    UpdatedBy = responses.UpdatedBy,
                    IsRemoved = responses.IsRemoved,
                    IdBeneficiario = responses.BeneficiarioId,
                    IdEscola = responses.EscolaId,
                    IdRegadio = responses.RegadioId,
                    IdInqueritoPai = responses.ParentInqueritoId,
                    IdResponsesPai = responses.ParentResponseId
                }));
            }
            if (request.InqueritoResponses.Deleted.Count > 0)
            {
                var deletedResponsesInquerito = _context.ResponsesInqueritos.Where((responses) => request.InqueritoResponses.Deleted.Any(r => r == responses.Id.ToString())).ToList();
                _context.ResponsesInqueritos.RemoveRange(deletedResponsesInquerito);
            }
            _context.SaveChanges();

            //InqueritoResposta
            if (request.InqueritoResposta.Created.Count > 0)
            {
                _context.InqueritoResposta.AddRange(request.InqueritoResposta.Created.ConvertAll((inquerito) => new InqueritoRespostum()
                {
                    Id = inquerito.Id,
                    Descricao = inquerito.Descricao,
                    IdInquerito = inquerito.InqueritoId,
                    IdPergunta = inquerito.PerguntaId,
                    Code = inquerito.Code,
                    IdResponses = inquerito.ResponseId,
                    Tipo = inquerito.Tipo,
                    IdFieldsets = inquerito.FieldsetId,
                    CreatedBy = inquerito.CreatedBy,
                    CreatedOn = inquerito.CreatedOn,
                    IsRemoved = false,
                    
                }));
            }
            if (request.InqueritoResposta.Updated.Count > 0)
            {
                _context.InqueritoResposta.UpdateRange(request.InqueritoResposta.Updated.ConvertAll((inquerito) => new InqueritoRespostum()
                {
                    Descricao = inquerito.Descricao,
                    IdInquerito = inquerito.InqueritoId,
                    IdPergunta = inquerito.PerguntaId,
                    Code = inquerito.Code,
                    IdResponses = inquerito.ResponseId,
                    Tipo = inquerito.Tipo,
                    CreatedOn = inquerito.CreatedOn,
                    CreatedBy = inquerito.CreatedBy,
                    RemovedOn = inquerito.RemovedOn,
                    RemovedBy = inquerito.RemovedBy,
                    UpdatedOn = inquerito.UpdatedOn,
                    UpdatedBy = inquerito.UpdatedBy,
                    IsRemoved = inquerito.IsRemoved
                }));
            }
            if (request.InqueritoResposta.Deleted.Count > 0)
            {
                var deletedInqueritoResposta = _context.InqueritoResposta.Where((inquerito) => request.InqueritoResposta.Deleted.Any(i => i == inquerito.Id.ToString())).ToList();
                _context.InqueritoResposta.RemoveRange(deletedInqueritoResposta);
            }
            _context.SaveChanges();

            //PerguntaOpcao
            if (request.PerguntaOpcao.Created.Count > 0)
            {
                _context.PerguntaOpcaos.AddRange(request.PerguntaOpcao.Created.ConvertAll((pergunta) => new PerguntaOpcao()
                {
                    Id = pergunta.Id,
                    IdPergunta = pergunta.PerguntaId,
                    Descricao = pergunta.Descricao,
                    IdPaiOpcao = pergunta.ParentOpcaoId,
                    IdPaiPergunta = pergunta.ParentPerguntaId,
                    IsOpcao = pergunta.IsOpcao,
                    CreatedBy = pergunta.CreatedBy,
                    CreatedOn = pergunta.CreatedOn,
                }));
            }
            if (request.PerguntaOpcao.Updated.Count > 0)
            {
                _context.PerguntaOpcaos.UpdateRange(request.PerguntaOpcao.Updated.ConvertAll((pergunta) => new PerguntaOpcao()
                {
                    IdPergunta = pergunta.PerguntaId,
                    Descricao = pergunta.Descricao,
                    IdPaiOpcao = pergunta.ParentOpcaoId,
                    IdPaiPergunta = pergunta.ParentPerguntaId,
                    IsOpcao = pergunta.IsOpcao,
                    CreatedOn = pergunta.CreatedOn,
                    CreatedBy = pergunta.CreatedBy,
                    RemovedOn = pergunta.RemovedOn,
                    RemovedBy = pergunta.RemovedBy,
                    UpdatedOn = pergunta.UpdatedOn,
                    UpdatedBy = pergunta.UpdatedBy,
                    IsRemoved = pergunta.IsRemoved
                }));
            }
            if (request.PerguntaOpcao.Deleted.Count > 0)
            {
                var deletedPerguntaOpcao = _context.PerguntaOpcaos.Where((pergunta) => request.PerguntaOpcao.Deleted.Any(p => p == pergunta.Id.ToString())).ToList();
                _context.PerguntaOpcaos.RemoveRange(deletedPerguntaOpcao);
            }
            _context.SaveChanges();

            //Provinces
            if (request.Provinces.Created.Count > 0)
            {
                _context.Provinces.AddRange(request.Provinces.Created.ConvertAll((provinces) => new Province()
                {
                    Id = provinces.Id,
                    Name = provinces.Name,
                    CreatedOn = provinces.CreatedOn
                }));
            }
            if (request.Provinces.Updated.Count > 0)
            {
                _context.Provinces.UpdateRange(request.Provinces.Updated.ConvertAll((provinces) => new Province()
                {
                    Name = provinces.Name,
                    CreatedOn = provinces.CreatedOn,
                    RemovedOn = provinces.RemovedOn,
                    UpdatedOn = provinces.UpdatedOn
                }));
            }
            if (request.Provinces.Deleted.Count > 0)
            {
                var deletedProvince = _context.Provinces.Where((provinces) => request.Provinces.Deleted.Any(i => i == provinces.Id.ToString())).ToList();
                _context.Provinces.RemoveRange(deletedProvince);
            }
            _context.SaveChanges();

            //Districts
            if (request.Districts.Created.Count > 0)
            {
                _context.Districts.AddRange(request.Districts.Created.ConvertAll((districts) => new District()
                {
                    Id = districts.Id,
                    Name = districts.Name,
                    IdProvincia = districts.ProvinciaId,
                    CreatedOn = districts.CreatedOn
                }));
            }
            if (request.Districts.Updated.Count > 0)
            {
                _context.Districts.UpdateRange(request.Districts.Updated.ConvertAll((districts) => new District()
                {
                    Name = districts.Name,
                    IdProvincia = districts.ProvinciaId,
                    CreatedOn = districts.CreatedOn,
                    RemovedOn = districts.RemovedOn,
                    UpdatedOn = districts.UpdatedOn
                }));
            }
            if (request.Districts.Deleted.Count > 0)
            {
                var deletedPDistrict= _context.Districts.Where((districts) => request.Districts.Deleted.Any(i => i == districts.Id.ToString())).ToList();
                _context.Districts.RemoveRange(deletedPDistrict);
            }
            _context.SaveChanges();

            //Usuarios
            if (request.Usuarios.Created.Count > 0)
            {
                _context.Usuarios.AddRange(request.Usuarios.Created.ConvertAll((usuario) => new Usuario()
                {
                    Id = usuario.Id,
                    IdAspNetUser = usuario.AspNetUserId,
                    IdInquerito = usuario.InqueritoId,
                    IdRegadio = usuario.RegadioId,
                    IsActive = true,
                    IsRemoved = false,
                    CreatedBy = usuario.CreatedBy,
                    CreatedOn = usuario.CreatedOn,
                }));
            }
            if (request.Usuarios.Updated.Count > 0)
            {
                _context.Usuarios.UpdateRange(request.Usuarios.Updated.ConvertAll((usuario) => new Usuario()
                {
                    IdAspNetUser = usuario.AspNetUserId,
                    IdInquerito = usuario.InqueritoId,
                    IdRegadio = usuario.RegadioId,
                    IsActive = true,
                    CreatedOn = usuario.CreatedOn,
                    CreatedBy = usuario.CreatedBy,
                    RemovedOn = usuario.RemovedOn,
                    RemovedBy = usuario.RemovedBy,
                    IsRemoved = usuario.IsRemoved,
                    UpdatedOn = usuario.UpdatedOn,
                    UpdatedBy = usuario.UpdatedBy
                }));
            }
            if (request.Usuarios.Deleted.Count > 0)
            {
                var deletedUsuarios = _context.Usuarios.Where((usuario) => request.Usuarios.Deleted.Any(i => i == usuario.Id.ToString())).ToList();
                _context.Usuarios.RemoveRange(deletedUsuarios);
            }
            _context.SaveChanges();

            //UsuarioAssociacoes
            if (request.UsuarioAssociacoes.Created.Count > 0)
            {
                _context.UsuarioAssociacoes.AddRange(request.UsuarioAssociacoes.Created.ConvertAll((usuario) => new UsuarioAssociaco()
                {
                    Id = usuario.Id,
                    IdUsuario = usuario.UsuarioId,
                    IdAssociacao = usuario.AssociacaoId,
                    IsRemoved = false,
                    CreatedBy = usuario.CreatedBy,
                    CreatedOn = usuario.CreatedOn,
                }));
            }
            if (request.UsuarioAssociacoes.Updated.Count > 0)
            {
                _context.UsuarioAssociacoes.UpdateRange(request.UsuarioAssociacoes.Updated.ConvertAll((usuario) => new UsuarioAssociaco()
                {
                    IdUsuario = usuario.UsuarioId,
                    IdAssociacao = usuario.AssociacaoId,
                    CreatedOn = usuario.CreatedOn,
                    CreatedBy = usuario.CreatedBy,
                    RemovedOn = usuario.RemovedOn,
                    RemovedBy = usuario.RemovedBy,
                    IsRemoved = usuario.IsRemoved,
                    UpdatedOn = usuario.UpdatedOn,
                    UpdatedBy = usuario.UpdatedBy
                }));
            }
            if (request.UsuarioAssociacoes.Deleted.Count > 0)
            {
                var deletedUsuarioAssociacoes = _context.UsuarioAssociacoes.Where((usuario) => request.UsuarioAssociacoes.Deleted.Any(i => i == usuario.Id.ToString())).ToList();
                _context.UsuarioAssociacoes.RemoveRange(deletedUsuarioAssociacoes);
            }
            _context.SaveChanges();

            //UsuarioEscolas
            if (request.UsuarioEscolas.Created.Count > 0)
            {
                _context.UsuarioEscolas.AddRange(request.UsuarioEscolas.Created.ConvertAll((usuario) => new UsuarioEscola()
                {
                    Id = usuario.Id,
                    IdUsuario = usuario.UsuarioId,
                    IdEscola = usuario.EscolaId,
                    IsRemoved = false,
                    CreatedBy = usuario.CreatedBy,
                    CreatedOn = usuario.CreatedOn,
                }));
            }
            if (request.UsuarioEscolas.Updated.Count > 0)
            {
                _context.UsuarioEscolas.UpdateRange(request.UsuarioEscolas.Updated.ConvertAll((usuario) => new UsuarioEscola()
                {
                    IdUsuario = usuario.UsuarioId,
                    IdEscola = usuario.EscolaId,
                    CreatedOn = usuario.CreatedOn,
                    CreatedBy = usuario.CreatedBy,
                    RemovedOn = usuario.RemovedOn,
                    RemovedBy = usuario.RemovedBy,
                    IsRemoved = usuario.IsRemoved,
                    UpdatedOn = usuario.UpdatedOn,
                    UpdatedBy = usuario.UpdatedBy
                }));
            }
            if (request.UsuarioEscolas.Deleted.Count > 0)
            {
                var deletedUsuarioEscolas = _context.UsuarioEscolas.Where((usuario) => request.UsuarioEscolas.Deleted.Any(i => i == usuario.Id.ToString())).ToList();
                _context.UsuarioEscolas.RemoveRange(deletedUsuarioEscolas);
            }
            _context.SaveChanges();

            //UsuarioInqueritos
            if (request.UsuarioInqueritos.Created.Count > 0)
            {
                _context.UsuarioInqueritos.AddRange(request.UsuarioInqueritos.Created.ConvertAll((usuario) => new UsuarioInquerito()
                {
                    Id = usuario.Id,
                    IdUsuario = usuario.UsuarioId,
                    IdInquerito = usuario.InqueritoId,
                    IsRemoved = false,
                    CreatedBy = usuario.CreatedBy,
                    CreatedOn = usuario.CreatedOn,
                }));
            }
            if (request.UsuarioInqueritos.Updated.Count > 0)
            {
                _context.UsuarioInqueritos.UpdateRange(request.UsuarioInqueritos.Updated.ConvertAll((usuario) => new UsuarioInquerito()
                {
                    IdUsuario = usuario.UsuarioId,
                    IdInquerito = usuario.InqueritoId,
                    CreatedOn = usuario.CreatedOn,
                    CreatedBy = usuario.CreatedBy,
                    RemovedOn = usuario.RemovedOn,
                    RemovedBy = usuario.RemovedBy,
                    IsRemoved = usuario.IsRemoved,
                    UpdatedOn = usuario.UpdatedOn,
                    UpdatedBy = usuario.UpdatedBy
                }));
            }
            if (request.UsuarioInqueritos.Deleted.Count > 0)
            {
                var deletedUsuarioInqueritos = _context.UsuarioInqueritos.Where((usuario) => request.UsuarioInqueritos.Deleted.Any(i => i == usuario.Id.ToString())).ToList();
                _context.UsuarioInqueritos.RemoveRange(deletedUsuarioInqueritos);
            }
            _context.SaveChanges();

            //UsuarioRegadios
            if (request.UsuarioRegadios.Created.Count > 0)
            {
                _context.UsuarioRegadios.AddRange(request.UsuarioRegadios.Created.ConvertAll((usuario) => new UsuarioRegadio()
                {
                    Id = usuario.Id,
                    IdUsuario = usuario.UsuarioId,
                    IdRegadio = usuario.RegadioId,
                    IsRemoved = false,
                    CreatedBy = usuario.CreatedBy,
                    CreatedOn = usuario.CreatedOn,
                }));
            }
            if (request.UsuarioRegadios.Updated.Count > 0)
            {
                _context.UsuarioRegadios.UpdateRange(request.UsuarioRegadios.Updated.ConvertAll((usuario) => new UsuarioRegadio()
                {
                    IdUsuario = usuario.UsuarioId,
                    IdRegadio = usuario.RegadioId,
                    CreatedOn = usuario.CreatedOn,
                    CreatedBy = usuario.CreatedBy,
                    RemovedOn = usuario.RemovedOn,
                    RemovedBy = usuario.RemovedBy,
                    IsRemoved = usuario.IsRemoved,
                    UpdatedOn = usuario.UpdatedOn,
                    UpdatedBy = usuario.UpdatedBy
                }));
            }
            if (request.UsuarioRegadios.Deleted.Count > 0)
            {
                var deletedUsuarioRegadios = _context.UsuarioRegadios.Where((usuario) => request.UsuarioRegadios.Deleted.Any(i => i == usuario.Id.ToString())).ToList();
                _context.UsuarioRegadios.RemoveRange(deletedUsuarioRegadios);
            }
            _context.SaveChanges();

            //Save Sync Mobile Date
                var mobile = Create(new MobileSync()
                {
                    SyncOn = DateTime.Now,
                    SyncedBy = user,
                    DeviceImei = deviceIME,
                    Tipo = "POST"
                });
            } catch (Exception ex)
            {
                return ex.InnerException.Message;
            }

            return time.ToString();
        }

        public async Task<MobileSync> Create(MobileSync mobileSync)
        {

            _context.MobileSyncs.Add(mobileSync);
            await _context.SaveChangesAsync();

            return mobileSync;
        }

        public async Task<MobileSync> GetMobileSyncBy(string user, string device, DateTime SyncDate)
        {
            var usurario = await _context.MobileSyncs
                .Where(m => m.SyncedBy == user && m.SyncOn == SyncDate && m.DeviceImei == device)
                .FirstOrDefaultAsync();

            return usurario;
        }
    }
}
