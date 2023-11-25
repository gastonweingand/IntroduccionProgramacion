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
    public partial class Usuarios : Form
    {
        private IGenericCRUD<Usuario> daoUsuarios = new UsuarioDAOSqlServer();
        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            RefrescarGrilla();
        }

        private void RefrescarGrilla()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = daoUsuarios.GetAll();
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.UserName = txtUserName.Text;
                usuario.NroDoc = txtDNI.Text;
                usuario.IntentosFallidos = 0;
                usuario.Password = (new Random().Next(1000, 10000)).ToString();

                daoUsuarios.Insert(usuario);

                MessageBox.Show("El usuario se ha insertado correctamente","Título",MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUserName.Text = String.Empty;
                txtDNI.Text = String.Empty;
                RefrescarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if(txtFiltro.Text.Length > 2)
            {
                //Voy a la base de datos para filtrar...
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = daoUsuarios.GetByUserName(txtFiltro.Text);
                
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Columna: " + e.ColumnIndex + ", Fila: " + e.RowIndex);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                Usuario usuario = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show($"¿Está seguro de eliminar a {usuario.UserName}?","Eliminando...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Ahora procedemos con la eliminación
                    daoUsuarios.Delete(usuario);
                    MessageBox.Show("Usuario eliminado");
                    RefrescarGrilla();
                }
                else
                {
                    MessageBox.Show("Gracias por arrepentirse...");
                }
            }
            else
            {
                MessageBox.Show("Usted no ha seleccionado ningún usuario para eliminar", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaModificacionUsuario altaModificacionUsuario = new AltaModificacionUsuario();
            //Oculto el formulario principal...
            this.Hide();
            if(altaModificacionUsuario.ShowDialog() == DialogResult.OK)
            {
                //Si hay un OK desde el segundo form, significa que hubo cambios Alta/Modificación
                RefrescarGrilla();
            }

            //Vuelvo a aparecer
            this.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                Usuario usuario = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;

                AltaModificacionUsuario altaModificacionUsuario = new AltaModificacionUsuario(usuario, false);
                //Oculto el formulario principal...
                this.Hide();
                if (altaModificacionUsuario.ShowDialog() == DialogResult.OK)
                {
                    //Si hay un OK desde el segundo form, significa que hubo cambios Alta/Modificación
                    RefrescarGrilla();
                }

                //Vuelvo a aparecer
                this.Show();
            }
            else
            {
                MessageBox.Show("Usted no ha seleccionado ningún usuario para modificar", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void Usuarios_Load(object sender, EventArgs e)
        {
           
            
        }

        private void dgvUsuarios_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //En la configuración general, pongo invisible la columna de los ids...
            dgvUsuarios.Columns["IdUsuario"].Visible = false;
            dgvUsuarios.Rows[e.RowIndex].Cells[2].Value = "*"; //Si quisiéramos modificar algo por fuera de los datos
            //que vienen, podemos tocar directamente el text de cada celda...
        }
    }
}
