using DAO.Interfaces;
using DAO.Tools;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementaciones
{
    public class UsuarioDAOSqlServer : IGenericCRUD<Usuario>
    {
        private string ConString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        private SqlConnection sqlConnection;

        public UsuarioDAOSqlServer()
        {
            sqlConnection = new SqlConnection(ConString);
        }

        public void Delete(Usuario usuario)
        {
            try
            {
                //1) Abrir conexión
                //2) Ejecutar comando -> ExecuteReader (Select) / ExecuteScalar (Insert) / ExecuteNonQuery (Update, Delete)
                //3) Cerrar conexión
                sqlConnection.Open();

                string comando = $"DELETE FROM Usuario " + 
                                 $"WHERE IdUsuario = {usuario.IdUsuario}";

                SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);

                //Una vez que ejecutar el Insert en la base de datos, nos vamos a traer el Id generado
                //por el motor a nuestro objeto IdUsuario...
                int filasAfectadas = sqlCommand.ExecuteNonQuery();

                Bitacora.Escribir($"Se ejecutó el comando {comando} con {filasAfectadas} filas afectadas", System.Diagnostics.TraceLevel.Info);

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Bitacora.EscribirError(ex);
                throw new Exception("Hubo un error accediendo a los datos, verifique logs.");
            }
        }

        public List<Usuario> GetAll()
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();

                //Transacción básica de base de datos implica un open, ejecutar un comando, close
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("select * from Usuario", sqlConnection);

                ReadUsers(usuarios, sqlCommand);

                sqlConnection.Close();

                return usuarios;
            }
            catch (Exception ex)
            {
                Bitacora.EscribirError(ex);
                throw new Exception("Hubo un error accediendo a los datos, verifique logs.");
            }
        }

        private static void ReadUsers(List<Usuario> usuarios, SqlCommand sqlCommand)
        {
            using (var reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    //Data mapper -> El reader me traer las columnas de sql server, 
                    //por el lado de la aplicación tengo el objeto usuario con sus properties
                    //Property -> Campo de la tabla
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = (int)reader[0];
                    usuario.UserName = reader[1].ToString();
                    usuario.Password = reader[2].ToString();
                    usuario.IntentosFallidos = int.Parse(reader[3].ToString());
                    usuario.NroDoc = reader[4].ToString();
                    usuarios.Add(usuario);
                }
            }
        }

        public Usuario GetById(int id)
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand($"select * from Usuario where Idusuario = {id}", sqlConnection);

                ReadUsers(usuarios, sqlCommand);

                sqlConnection.Close();

                return usuarios[0];
            }
            catch (Exception ex)
            {
                Bitacora.EscribirError(ex);
                throw new Exception("Hubo un error accediendo a los datos, verifique logs.");
            }
        }

        public List<Usuario> GetByUserName(string username)
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand($"select * from Usuario where username like '%{username}%'", sqlConnection);

                ReadUsers(usuarios, sqlCommand);

                sqlConnection.Close();

                return usuarios;
            }
            catch (Exception ex)
            {
                Bitacora.EscribirError(ex);
                throw new Exception("Hubo un error accediendo a los datos, verifique logs.");
            }
        }

        public void Insert(Usuario usuario)
        {
            try
            {
                //1) Abrir conexión
                //2) Ejecutar comando -> ExecuteReader (Select) / ExecuteScalar (Insert) / ExecuteNonQuery (Update, Delete)
                //3) Cerrar conexión
                sqlConnection.Open();

                string comando = $"INSERT INTO Usuario ([username],[password],[intentosFallidos],[dni]) " + 
                                 $"VALUES ('{usuario.UserName}', '{usuario.Password}', {usuario.IntentosFallidos}, '{usuario.NroDoc}') " + 
                                 "Select @@IDENTITY";

                SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);

                //Una vez que ejecutar el Insert en la base de datos, nos vamos a traer el Id generado
                //por el motor a nuestro objeto IdUsuario...
                object retorno = sqlCommand.ExecuteScalar();

                usuario.IdUsuario = int.Parse(retorno.ToString());

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Bitacora.EscribirError(ex);
                throw new Exception("Hubo un error accediendo a los datos, verifique logs.");
            }
        }

        public void Update(Usuario usuario)
        {
            try
            {
                //1) Abrir conexión
                //2) Ejecutar comando -> ExecuteReader (Select) / ExecuteScalar (Insert) / ExecuteNonQuery (Update, Delete)
                //3) Cerrar conexión
                sqlConnection.Open();

                string comando = $"UPDATE Usuario SET[username] = '{usuario.UserName}' ,[password] = '{usuario.Password}'" +
                                 $",[intentosFallidos] = {usuario.IntentosFallidos} ,[dni] = '{usuario.NroDoc}' WHERE IdUsuario = {usuario.IdUsuario}";

                SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);

                //Una vez que ejecutar el Insert en la base de datos, nos vamos a traer el Id generado
                //por el motor a nuestro objeto IdUsuario...
                int filasAfectadas = sqlCommand.ExecuteNonQuery();

                Bitacora.Escribir($"Se ejecutó el comando {comando} con {filasAfectadas} filas afectadas", System.Diagnostics.TraceLevel.Info);

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Bitacora.EscribirError(ex);
                throw new Exception("Hubo un error accediendo a los datos, verifique logs.");
            }
        }
    }
}
