using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Tools
{
    internal static class Bitacora
    {
        public static void Escribir(string msg, System.Diagnostics.TraceLevel nivelMensaje)
        {
            try
            {
                using (StreamWriter str = new StreamWriter(ApplicationConfiguration.PathInfo, true))
                {
                    //Armamos un formato de mensaje para que tenga sentido lo que estoy guardando...
                    string mensaje = $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} {nivelMensaje}, mensaje: {msg}";

                    str.WriteLine(mensaje);
                }
            }
            catch (Exception ex)
            {
                //Si estoy, es porque ni siquiera puedo guardar info de mi app.
                //Tengo que seguir aplicando políticas, por ejemplo: Intentar escribir en el eventviewer
                //Puedo enviar un email a un administrador
                //Puedo enviar un wp
                //Puedo enviar un mensaje a un canal de telegram
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public static void EscribirError(Exception exception)
        {
            try
            {
                using (StreamWriter str = new StreamWriter(ApplicationConfiguration.PathLog, true))
                {
                    //Armamos un formato de mensaje para que tenga sentido lo que estoy guardando...
                    string mensaje = $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} [Error], mensaje: {exception.Message}, StackTrace: {exception.StackTrace}";
                    

                    str.WriteLine(mensaje);
                }
            }
            catch (Exception ex)
            {
                //Si estoy, es porque ni siquiera puedo guardar los errores de mi app.
                //Tengo que seguir aplicando políticas, por ejemplo: Intentar escribir en el eventviewer
                //Puedo enviar un email a un administrador
                //Puedo enviar un wp
                //Puedo enviar un mensaje a un canal de telegram
                Console.WriteLine(ex.Message);
                throw;
            }
           
        }
    }
}
