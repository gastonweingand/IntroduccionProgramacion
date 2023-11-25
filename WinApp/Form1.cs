using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp.Tools;

namespace WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenidos al mundo de los controles visuales y archivos!");
        }

        /// <summary>
        /// Puedo obtener quién disparó el evento
        /// </summary>
        /// <param name="sender">El objeto que invocó a este evento</param>
        /// <param name="e">Argumentos que cada evento define...</param>
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                //Relación de <use>
                FileTxtWriter fileTxtWriter = new FileTxtWriter();
                //Parametrización -> Posibilidad de enviar datos de configuración/seteos
                //desde un archivo externo a mi .exe, o mi app. (Suele ser un archivo .txt, .json, settings, app.config)
                //Esto evita que recompilemos en el caso de cambios...

                fileTxtWriter.EscribirNoticia(ApplicationConfiguration.GetInstance().PathNoticias, txtNoticia.Text);
                MessageBox.Show("Su noticia tan importante ha sido registrada!");
                txtNoticia.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLeerNoticia_Click(object sender, EventArgs e)
        {
            txtNoticiaExistente.Text = new FileTxtReader().LeerNoticia(ApplicationConfiguration.GetInstance().PathNoticias);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            lblPosicion.Text = "Posición: X: " + e.X + ", Y: " + e.Y;
            //btnGrabar.Location = new Point(e.X, 600);
        }

        private void btnArchivos_Click(object sender, EventArgs e)
        {
            lstFiles.DataSource = new DirectoryReader().ObtenerArchivos(txtNoticia.Text);
        }

        private void btnDirectorios_Click(object sender, EventArgs e)
        {
            lstFiles.DataSource = new DirectoryReader().ObtenerDirectorios(txtNoticia.Text);
        }
    }
}
