using IRRIGA.WatermemonSync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Request
{
    public record PushRequest
    {
        public SyncRequest Changes { get; set; }
        public string User { get; set; }
        public string DeviceIMEI { get; set; }
    }
    public record SyncRequest
    {
        public RequestMapper<AssociacaoRegadioSync> AssociacaoRegadio { get; set; }
        public RequestMapper<AssociacaoSync> Associacao { get; set; }
        public RequestMapper<BeneficiarioEscolasSync> BeneficiarioEscolas { get; set; }
        public RequestMapper<BeneficiarioSync> Beneficiario { get; set; }
        public RequestMapper<CulturaSync> Cultura { get; set; }
        public RequestMapper<EscolaMachambaSync> EscolaMachamba { get; set; }
        public RequestMapper<EscolaRegadiosSync> EscolaRegadios { get; set; }
        public RequestMapper<FieldsetsSync> Fieldsets { get; set; }
        public RequestMapper<InqueritoPerguntaSync> InqueritoPergunta { get; set; }
        public RequestMapper<InqueritoRespostaSync> InqueritoResposta { get; set; }
        public RequestMapper<InqueritoSync> Inquerito { get; set; }
        public RequestMapper<PerguntaOpcaoSync> PerguntaOpcao { get; set; }
        public RequestMapper<ProvincesSync> Provinces { get; set; }
        public RequestMapper<DistrictsSync> Districts { get; set; }
        public RequestMapper<RegadioSync> Regadio { get; set; }
        public RequestMapper<ResponsesInqueritoSync> InqueritoResponses { get; set; }
        public RequestMapper<InqueritoResponsesAprovedSync> InqueritoResponsesApproved { get; set; }
        public RequestMapper<SubInqueritoSync> InqueritoSub { get; set; }
        public RequestMapper<TipoCulturaSync> CulturaTipo { get; set; }
        public RequestMapper<UsuarioAssociacoesSync> UsuarioAssociacoes { get; set; }
        public RequestMapper<UsuarioEscolasSync> UsuarioEscolas { get; set; }
        public RequestMapper<UsuarioInqueritosSync> UsuarioInqueritos { get; set; }
        public RequestMapper<UsuarioRegadiosSync> UsuarioRegadios { get; set; }
        public RequestMapper<UsuariosSync> Usuarios { get; set; }
    }
    public class PullResponse
    {
        public SyncRequest Changes { get; set; }
        public long Timestamp { get; set; }
    }

    public class RequestMapper<T>
    {
        public List<T> Created;
        public List<T> Updated;
        public List<string> Deleted;
    }
}
