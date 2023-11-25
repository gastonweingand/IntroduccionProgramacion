using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Tools;

namespace DAO
{
    public class FileTxtWriter
    {
        public void EscribirNoticia(string path, string textoNoticia, bool append = true)
        {
            //StreamWriter streamWriter = new StreamWriter(path);

            //streamWriter.WriteLine(textoNoticia);

            //streamWriter.Close();

            //using permite liberar recursos de memoria y evita tener que llamar a métodos como Close, Dispose, etc..

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path, append))
                {
                    //Prueben de anexar la palabra PROGRAMACIÓN 1.000.000 a un str común vs un stringbuiler
                    // y vean cuanto tarda..

                    //string str = String.Empty;
                    //StringBuilder str = new StringBuilder();

                    //for (int i = 0; i < 10000000; i++)
                    //{
                    //    str += "PROGRAMACIÓN";


                    //    str.Append("PROGRAMACIÓN);
                    //}                  

                    //append -> true hace que agreguemos contenido a lo pre-existente
                    streamWriter.WriteLine(textoNoticia); //Podría no existir el directorio, CUIDADO!!!
                }

            }
            catch (Exception ex)
            {
                //Política de manejo de excepciones...
                //Generalmente las excepciones primero se escriben en un log...
                Bitacora.EscribirError(ex);
                throw new Exception("Hubo un error accediendo a los datos, contacte con el administrador.");
            }
            finally
            {
                Bitacora.Escribir("Siempre paso por acá, haya habido error o no", System.Diagnostics.TraceLevel.Info);
            }
        }
    }
}
