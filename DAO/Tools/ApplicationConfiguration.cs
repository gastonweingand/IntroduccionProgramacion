using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Tools
{

    /// <summary>
    /// No se recomienda abusar de este uso para los singleton porque no permite herencia...
    /// </summary>
    internal static class ApplicationConfiguration
    {
        public static string PathLog { get; set; } = ConfigurationManager.AppSettings["PathBitacora"];

        public static string PathInfo { get; set; } = ConfigurationManager.AppSettings["PathInfo"];
    }
}
