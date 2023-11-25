using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Tools
{
    /// <summary>
    /// Clase que permite leer todas las config de mi aplicación...
    /// </summary>
    internal class ApplicationConfiguration
    {
        //El objeto instanciado por única vez quedará acá...
        //La propia instancia también debe ser static (Miembro de clase)
        private static ApplicationConfiguration instance;

        public string PathNoticias { get; set; }

        public string PathLog { get; set; }

        private ApplicationConfiguration()
        {
            PathNoticias = ConfigurationManager.AppSettings["PathNoticias"];
            PathLog = ConfigurationManager.AppSettings["PathBitacora"];
        }


        //Debemos aprender el concepto de static, dentro de una clase
        //El concepto hace referencia a miembros de clase y no de instancia...
        public static ApplicationConfiguration GetInstance()
        {
            //La primera vez que alguien llame, se creará la instancia, después de esto, 
            //Las demás llamadas retornarán siempre la misma instancia
            if (instance == null)
                instance = new ApplicationConfiguration();

            return instance;
        }

        //Debido a que la configuración es igual en toda la aplicación, necesitaría que ApplicationConfiguration
        //se instancie una sola vez -> Para esto tenemos un patrón de diseño, llamado SINGLETON

        //A la clase que quiera que sea singleton tiene que:
        //1) Constructor privado
        //2) La propia clase es dueña de su instancia
        //3) Proveer de un método de acceso global a esa instancia...

    }
}
