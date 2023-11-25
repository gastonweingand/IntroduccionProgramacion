using DAO.Interfaces;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementaciones
{
    public class PersonaDAOSqlServer : IGenericCRUD<Persona>
    {
        public void Delete(Persona objeto)
        {
            throw new NotImplementedException();
        }

        public List<Persona> GetAll()
        {
            throw new NotImplementedException();
        }

        public Persona GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Persona> GetByUserName(string filtro)
        {
            throw new NotImplementedException();
        }

        public void Insert(Persona objeto)
        {
            throw new NotImplementedException();
        }

        public void Update(Persona objeto)
        {
            throw new NotImplementedException();
        }
    }
}
