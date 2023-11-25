using DAO.Interfaces;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementaciones
{
    public class UsuarioDAOMemory : IGenericCRUD<Usuario>
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public UsuarioDAOMemory()
        {
            usuarios.Add(new Usuario() { IdUsuario = 1, UserName = "gaston" });
            usuarios.Add(new Usuario() { IdUsuario = 2, UserName = "kaukel" });
            usuarios.Add(new Usuario() { IdUsuario = 3, UserName = "fernanda" });
        }
        public void Delete(Usuario usuario)
        {
            usuarios.Remove(usuario);
        }

        public List<Usuario> GetAll()
        {
            return usuarios;
        }

        public Usuario GetById(int id)
        {
            //Programación funcional
            return usuarios.FirstOrDefault(o => o.IdUsuario == id);
        }

        public List<Usuario> GetByUserName(string username)
        {
            //Programación funcional -> LINQ -> Es la tecnología que implementa programación funcional en .NET
            return usuarios.Where(o => o.UserName == username).ToList();
        }

        public void Insert(Usuario usuario)
        {
            usuario.IdUsuario = 4;
            usuarios.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            Usuario usuarioDB = GetById(usuario.IdUsuario);
            usuarioDB.UserName = usuario.UserName;
            usuarioDB.IntentosFallidos = usuario.IntentosFallidos;
            usuarioDB.Password = usuario.Password;
            usuarioDB.NroDoc = usuario.NroDoc;
        }
    }
}
