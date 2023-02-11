using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record BeneficiarioSync
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string TipoDocIdentificacao { get; set; }
        public string NumDodcIdenticacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public string Localizacao { get; set; }
        public string Endereco { get; set; }
        public string Localidade { get; set; }
        public int? AgregadoHomens { get; set; }
        public int? AgregadoMulheres { get; set; }
        public int? AgregadoHomensTrab { get; set; }
        public int? AgregadoMulheresTrab { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? RemovedOn { get; set; }
        public string RemovedBy { get; set; }
        public string CodeBenificiario { get; set; }
        public Guid? RegadioId { get; set; }
        public Guid? AssociacaoId { get; set; }
        public Guid? EscolaId { get; set; }
        public bool? IsRemoved { get; set; }
    }
    public class BeneficiarioMapper
    {
        public static BeneficiarioSync Map(Beneficiario beneficiario)
        {
            return new BeneficiarioSync()
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
                Localizacao = beneficiario.Localizacao,
                Endereco = beneficiario.Endereco,
                Localidade = beneficiario.Localidade,
                AgregadoHomens = beneficiario.AgregadoHomens,
                AgregadoMulheres = beneficiario.AgregadoMulheres,
                AgregadoHomensTrab = beneficiario.AgregadoHomensTrab,
                AgregadoMulheresTrab = beneficiario.AgregadoMulheresTrab,
                CreatedOn = beneficiario.CreatedOn,
                UpdatedOn = beneficiario.UpdatedOn,
                UpdatedBy = beneficiario.UpdatedBy,
                CreatedBy = beneficiario.CreatedBy,
                RemovedOn = beneficiario.RemovedOn,
                RemovedBy = beneficiario.RemovedBy,
                CodeBenificiario = beneficiario.CodeBenificiario,
                RegadioId = beneficiario.IdRegadio,
                AssociacaoId = beneficiario.IdAssociacao,
                EscolaId = beneficiario.IdEscola,
                IsRemoved = beneficiario.IsRemoved
            };

        }
    }
}
