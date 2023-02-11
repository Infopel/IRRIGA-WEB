using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Dtos
{
    public record PerguntaOpcoesDto
    {
        public int IdPergunta { get; set; }
        public string Label { get; set; }
        public int DependOn { get; set; }
        public List<Options> Options { get; set; }
    }
}
