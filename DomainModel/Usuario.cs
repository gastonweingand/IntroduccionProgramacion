using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    /// <summary>
    /// Generamos nuestras clases que representan a los datos de nuestra DB
    /// En gral. Tienen los mismos nombres las properties que los campos de la tabla
    /// </summary>
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int IntentosFallidos { get; set; }

        public string NroDoc { get; set; }

        public string GetFullName()
        {
            return UserName + " " + NroDoc;
        }
       
    }
}
