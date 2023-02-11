using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record PerguntaOpcaoSync
    {
        public int Id { get; set; }
        public int? PerguntaId { get; set; }
        public string Descricao { get; set; }
        public int? ParentOpcaoId { get; set; }
        public int? ParentPerguntaId { get; set; }
        public bool? IsOpcao { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsRemoved { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string RemovedBy { get; set; }
    }
    public class PerguntaOpcaoMapper
    {
        public static PerguntaOpcaoSync Map(PerguntaOpcao perguntaOpcao)
        {
            return new PerguntaOpcaoSync()
            {
                Id = perguntaOpcao.Id,
                PerguntaId = perguntaOpcao.IdPergunta,
                Descricao = perguntaOpcao.Descricao,
                ParentOpcaoId = perguntaOpcao.IdPaiOpcao,
                ParentPerguntaId = perguntaOpcao.IdPaiPergunta,
                IsOpcao = perguntaOpcao.IsOpcao,
                CreatedOn = perguntaOpcao.CreatedOn,
                RemovedOn = perguntaOpcao.RemovedOn,
                UpdatedOn = perguntaOpcao.UpdatedOn,
                CreatedBy = perguntaOpcao.CreatedBy,
                IsRemoved = perguntaOpcao.IsRemoved,
                UpdatedBy = perguntaOpcao.UpdatedBy
            };

        }
    }
}
