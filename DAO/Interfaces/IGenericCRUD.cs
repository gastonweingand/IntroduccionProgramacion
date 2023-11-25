using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IGenericCRUD<T>
    {
        //clásico patrón CRUD: Agregar, traer, actualizar y eliminar
        void Update(T objeto);

        void Delete(T objeto);

        List<T> GetAll();

        T GetById(int id);

        List<T> GetByUserName(string filtro);

        void Insert(T objeto);
     }
}
