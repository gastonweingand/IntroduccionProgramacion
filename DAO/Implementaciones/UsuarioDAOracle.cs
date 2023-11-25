using DAO.Interfaces;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementaciones
{
    class UsuarioDAOracle : IGenericCRUD<Usuario>
    {
        public void Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public void Insert(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
