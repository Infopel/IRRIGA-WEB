using IRRIGA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly dbIRRIGAContext _context;
        public UsuariosRepository(dbIRRIGAContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Create(Usuario user)
        {
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<Usuario> GetUsuarioBy(string idAsp)
        {
            var usurario = await _context.Usuarios
                .Where(u => u.IdAspNetUser == idAsp && u.IsActive == true)
                .FirstOrDefaultAsync();

            return usurario;
        }

        public IEnumerable<UsuarioRegadio> GetUsuarioRegadios(string idAsp)
        {
            return _context.UsuarioRegadios
                .Where(u => u.IdUsuarioNavigation.IdAspNetUser == idAsp && u.IdUsuarioNavigation.IsActive == true)
                .Include(u => u.IdRegadioNavigation)
                .ToList();
        }

        public async Task UpdateUsuario(string idUser)
        {
            var user = await _context.Usuarios
                .Where(u => u.IdAspNetUser == idUser && u.IsActive == true)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                user.IsActive = false;
                user.RemovedOn = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUsuarioRegadio(Usuario usuario)
        {
            var user = await _context.Usuarios
                .Where(u => u.IdAspNetUser == usuario.IdAspNetUser && u.IdRegadio == usuario.IdRegadio && u.IsActive == true)
                .FirstAsync();

            if (user != null)
            {
                user.IsActive = false;
                user.RemovedOn = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios
                .ToList();
        }

        public IEnumerable<UsuarioInquerito> GetUsuarioInqueritos(string idAsp)
        {
            return _context.UsuarioInqueritos
                .Where(u => u.IdUsuarioNavigation.IdAspNetUser == idAsp && u.IdUsuarioNavigation.IsActive == true)
                .Include(u => u.IdInqueritoNavigation)
                .ToList();
        }

        public IEnumerable<UsuarioAssociaco> GetUsuarioAssociacoes(string idAsp)
        {
            return _context.UsuarioAssociacoes
                .Where(u => u.IdUsuarioNavigation.IdAspNetUser == idAsp && u.IdUsuarioNavigation.IsActive == true)
                .Include(u => u.IdAssociacaoNavigation)
                .ToList();
        }

        public IEnumerable<UsuarioEscola> GetUsuarioEscolas(string idAsp)
        {
            return _context.UsuarioEscolas
                .Where(u => u.IdUsuarioNavigation.IdAspNetUser == idAsp && u.IdUsuarioNavigation.IsActive == true)
                .Include(u => u.IdEscolaNavigation)
                .ToList();
        }

        public async Task<UsuarioAssociaco> CreateUsuarioAssociacao(UsuarioAssociaco user)
        {
            _context.UsuarioAssociacoes.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<UsuarioEscola> CreateUsuarioEscola(UsuarioEscola user)
        {
            _context.UsuarioEscolas.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<UsuarioInquerito> CreateUsuarioInquerito(UsuarioInquerito user)
        {
            _context.UsuarioInqueritos.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<UsuarioRegadio> CreateUsuarioRegadio(UsuarioRegadio user)
        {
            _context.UsuarioRegadios.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task UpdateUsuarioRegadios(UsuarioRegadio usuario)
        {
            var user = await _context.UsuarioRegadios
                .Where(u => u.IdUsuarioNavigation.Id == usuario.IdUsuario && u.IdRegadio == usuario.IdRegadio && u.IsRemoved == false)
                .FirstAsync();

            if (user != null)
            {
                user.IsRemoved = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUsuarioEscola(UsuarioEscola usuario)
        {
            var user = await _context.UsuarioEscolas
                .Where(u => u.IdUsuarioNavigation.Id == usuario.IdUsuario && u.IdEscola == usuario.IdEscola && u.IsRemoved == false)
                .FirstAsync();

            if (user != null)
            {
                user.IsRemoved = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUsuarioAssociaco(UsuarioAssociaco usuario)
        {
            var user = await _context.UsuarioAssociacoes
                .Where(u => u.IdUsuarioNavigation.Id == usuario.IdUsuario && u.IdAssociacao == usuario.IdAssociacao && u.IsRemoved == false)
                .FirstAsync();

            if (user != null)
            {
                user.IsRemoved = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUsuarioInquerito(UsuarioInquerito usuario)
        {
            var user = await _context.UsuarioInqueritos
                .Where(u => u.IdUsuarioNavigation.Id == usuario.IdUsuario && u.IdInquerito == usuario.IdInquerito && u.IsRemoved == false)
                .FirstAsync();

            if (user != null)
            {
                user.IsRemoved = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
