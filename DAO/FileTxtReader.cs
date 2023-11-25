using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FileTxtReader
    {
        public string LeerNoticia(string path)
        {
            string noticiaLeida = String.Empty;

            //using permite liberar recursos de memoria y evita tener que llamar a métodos como Close, Dispose, etc..
            using (StreamReader streamReader = new StreamReader(path))
            {
                noticiaLeida = streamReader.ReadToEnd();
            }

            return noticiaLeida;
        }
    }
}
