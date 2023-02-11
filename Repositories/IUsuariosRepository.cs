using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public interface IUsuariosRepository
    {
        Task<Usuario> Create(Usuario user);
        Task<UsuarioAssociaco> CreateUsuarioAssociacao(UsuarioAssociaco user);
        Task<UsuarioEscola> CreateUsuarioEscola(UsuarioEscola user);
        Task<UsuarioInquerito> CreateUsuarioInquerito(UsuarioInquerito user);
        Task<UsuarioRegadio> CreateUsuarioRegadio(UsuarioRegadio user);
        Task UpdateUsuario(string idUser);
        Task UpdateUsuarioRegadio(Usuario usuario);
        Task UpdateUsuarioRegadios(UsuarioRegadio usuario);
        Task UpdateUsuarioEscola(UsuarioEscola usuario);
        Task UpdateUsuarioAssociaco(UsuarioAssociaco usuario);
        Task UpdateUsuarioInquerito(UsuarioInquerito usuario);
        Task<Usuario> GetUsuarioBy(string idAsp);
        IEnumerable<UsuarioRegadio> GetUsuarioRegadios(string idAsp);
        IEnumerable<UsuarioInquerito> GetUsuarioInqueritos(string idAsp);
        IEnumerable<UsuarioAssociaco> GetUsuarioAssociacoes(string idAsp);
        IEnumerable<UsuarioEscola> GetUsuarioEscolas(string idAsp);
        IEnumerable<Usuario> GetAll();
    }
}
