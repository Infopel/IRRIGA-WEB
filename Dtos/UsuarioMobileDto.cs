using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Dtos
{
    public record UsuarioMobileDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public List<Menus> Menu { get; set; }
        public List<Regadios> Regadio { get; set; }
        public List<Escolas> Escola { get; set; }
        public List<Associacoes> Associacao { get; set; }
    }

    public record Menus
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public record Regadios
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public record Escolas
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public record Associacoes
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
