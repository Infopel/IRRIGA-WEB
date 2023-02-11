using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IRRIGA
{
    [Table("Beneficiario")]
    public partial class Beneficiario
    {
        public Beneficiario()
        {
            BeneficiarioEscolas = new HashSet<BeneficiarioEscola>();
            ResponsesInqueritos = new HashSet<ResponsesInquerito>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("apelido")]
        public string Apelido { get; set; }
        [Column("genero")]
        [StringLength(50)]
        public string Genero { get; set; }
        [Column("dataNascimento", TypeName = "datetime")]
        public DateTime? DataNascimento { get; set; }
        [Column("telefone")]
        [StringLength(50)]
        public string Telefone { get; set; }
        [Column("tipoDocIdentificacao")]
        [StringLength(50)]
        public string TipoDocIdentificacao { get; set; }
        [Column("numDodcIdenticacao")]
        [StringLength(50)]
        public string NumDodcIdenticacao { get; set; }
        [Column("dataValidade", TypeName = "datetime")]
        public DateTime? DataValidade { get; set; }
        [Column("localizacao")]
        [StringLength(50)]
        public string Localizacao { get; set; }
        [Column("endereco")]
        [StringLength(50)]
        public string Endereco { get; set; }
        [Column("localidade")]
        [StringLength(50)]
        public string Localidade { get; set; }
        [Column("agregadoHomens")]
        public int? AgregadoHomens { get; set; }
        [Column("agregadoMulheres")]
        public int? AgregadoMulheres { get; set; }
        [Column("agregadoHomensTrab")]
        public int? AgregadoHomensTrab { get; set; }
        [Column("agregadoMulheresTrab")]
        public int? AgregadoMulheresTrab { get; set; }
        [Column("createdOn", TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("updatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column("updatedBy")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Column("createdBy")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("removedOn", TypeName = "datetime")]
        public DateTime? RemovedOn { get; set; }
        [Column("removedBy")]
        [StringLength(50)]
        public string RemovedBy { get; set; }
        [Column("codeBenificiario")]
        [StringLength(50)]
        public string CodeBenificiario { get; set; }
        [Column("idRegadio")]
        public Guid? IdRegadio { get; set; }
        [Column("idAssociacao")]
        public Guid? IdAssociacao { get; set; }
        [Column("idEscola")]
        public Guid? IdEscola { get; set; }
        [Column("isRemoved")]
        public bool? IsRemoved { get; set; }

        [ForeignKey(nameof(IdAssociacao))]
        [InverseProperty(nameof(Associacao.Beneficiarios))]
        public virtual Associacao IdAssociacaoNavigation { get; set; }
        [ForeignKey(nameof(IdRegadio))]
        [InverseProperty(nameof(Regadio.Beneficiarios))]
        public virtual Regadio IdRegadioNavigation { get; set; }
        [InverseProperty(nameof(BeneficiarioEscola.IdBeneficiarioNavigation))]
        public virtual ICollection<BeneficiarioEscola> BeneficiarioEscolas { get; set; }
        [InverseProperty(nameof(ResponsesInquerito.IdBeneficiarioNavigation))]
        public virtual ICollection<ResponsesInquerito> ResponsesInqueritos { get; set; }
    }
}
