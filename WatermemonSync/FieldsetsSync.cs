using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.WatermemonSync
{
    public record FieldsetsSync
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public Guid? InqueritoId { get; set; }
        public int? FieldsetsOrder { get; set; }
        public int? PerguntaId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsRemoved { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string RemovedBy { get; set; }
        public string CaracteristicasComponente { get; set; }
    }
    public class FieldsetsMapper
    {
        public static FieldsetsSync Map(Fieldset fieldset)
        {
            return new FieldsetsSync()
            {
                Id = fieldset.Id,
                Label = fieldset.Label,
                Description = fieldset.Description,
                InqueritoId = fieldset.IdInquerito,
                FieldsetsOrder = fieldset.FieldsetsOrder,
                PerguntaId = fieldset.IdPergunta,
                CreatedOn = fieldset.CreatedOn,
                RemovedOn = fieldset.RemovedOn,
                UpdatedOn = fieldset.UpdatedOn,
                CreatedBy = fieldset.CreatedBy,
                UpdatedBy = fieldset.UpdatedBy,
                IsRemoved = fieldset.IsRemoved,
                CaracteristicasComponente = fieldset.CaracteristicasComponente
            };

        }
    }
}
