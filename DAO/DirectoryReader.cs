using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DirectoryReader
    {
        public List<string> ObtenerArchivos(string path)
        {
            List<string> archivos = new List<string>();

            foreach (var item in new DirectoryInfo(path).GetFiles())
            {
                archivos.Add(item.FullName);
            }

            return archivos;
        }

        public List<string> ObtenerDirectorios(string path)
        {
            List<string> directorios = new List<string>();

            foreach (var item in new DirectoryInfo(path).GetDirectories())
            {
                directorios.Add(item.FullName);
            }

            return directorios;
        }
    }
}
