using DAO.Implementaciones;
using DAO.Interfaces;
using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class AltaModificacionUsuario : Form
    {
        public bool Alta { get; set; }

        public Usuario Usuario { get; set; }

        private IGenericCRUD<Usuario> daoUsuarios = new UsuarioDAOSqlServer();

        public AltaModificacionUsuario(Usuario usuario = null, bool alta = true)
        {
            this.Usuario = usuario;
            this.Alta = alta;
            InitializeComponent();

            if (!Alta)
                MostrarDatosUsuarioParaActualizar(usuario);
        }

        private void MostrarDatosUsuarioParaActualizar(Usuario usuario)
        {
            //Hacemos el mapping de los datos del objeto con la interfaz del usuario...
            txtUserName.Text = usuario.UserName;
            txtDNI.Text = usuario.NroDoc;
            txtPassword.Text = usuario.Password;
            numFallidos.Value = usuario.IntentosFallidos;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //Acá tengo que llamar al dao para hacer el insert
            try
            {
                Usuario usuario = new Usuario();
                usuario.UserName = txtUserName.Text;
                usuario.NroDoc = txtDNI.Text;
                usuario.IntentosFallidos = int.Parse(numFallidos.Value.ToString());
                
                if (Alta)
                {
                    usuario.Password = (new Random().Next(1000, 10000)).ToString();
                    daoUsuarios.Insert(usuario);
                    MessageBox.Show("El usuario se ha insertado correctamente", "Título", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Estos dos datos no los vamos a modificar, por lo tanto los copiamos del objeto que llegó originalmente...
                    usuario.IdUsuario = Usuario.IdUsuario;
                    usuario.Password = Usuario.Password;

                    daoUsuarios.Update(usuario);
                    MessageBox.Show("El usuario se ha modificado correctamente", "Título", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
