using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Expeciones;
namespace Entidades
{
    public static class DispositivoDAO
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;

        #region Constructor
        static DispositivoDAO()
        {
            conexion = new SqlConnection("Data Source = localhost; Initial Catalog = Tp3; Integrated security = true");
            comando = new SqlCommand();

            DispositivoDAO.comando.CommandType = CommandType.Text;
            comando.Connection = DispositivoDAO.conexion;
        }
        #endregion

        #region Metodos
        public static bool InsertarDispositivo(Dispositivos dispo) 
        {
            bool pudeInsertar = false;
            string sql = "INSERT INTO Dispositivos (nombre,cantidad,precio,modelo) values(@nombre, @cantidad, @precio, @modelo)";
            DispositivoDAO.comando.CommandText = sql;
            DispositivoDAO.comando.Parameters.AddWithValue("@nombre",dispo.Nombre);
            DispositivoDAO.comando.Parameters.AddWithValue("@cantidad", dispo.Cantidad);
            DispositivoDAO.comando.Parameters.AddWithValue("@precio", dispo.Precio);
            if (dispo is Celular)
            {
                Celular celular = (Celular)dispo;
                DispositivoDAO.comando.Parameters.AddWithValue("@modelo", celular.Modelo);
            }

            if (dispo is Notebook)
            {
                Notebook notebook = (Notebook)dispo;
                DispositivoDAO.comando.Parameters.AddWithValue("@modelo", notebook.Modelo.ToString());
            }


            try
            {
                if (DispositivoDAO.conexion.State != ConnectionState.Open)
                {
                    DispositivoDAO.conexion.Open();
                }

                int filasAfectadas = DispositivoDAO.comando.ExecuteNonQuery();

                pudeInsertar = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException("Falla al intentar conectar con la base de datos", e);
            }
            finally 
            {
                DispositivoDAO.conexion.Close();
            }
            return pudeInsertar;
        }

        public static List<Dispositivos> LeerTodo() 
        {
            List<Dispositivos> listaDispositivos = new List<Dispositivos>();

            try
            {
                DispositivoDAO.comando.CommandText = "SELECT * FROM Dispositivos";
                if (DispositivoDAO.conexion.State != ConnectionState.Open)
                {
                    DispositivoDAO.conexion.Open();
                }

                SqlDataReader reader = DispositivoDAO.comando.ExecuteReader();

                while (reader.Read())
                {
                    string tipo = reader["modelo"].ToString();
                    if (tipo == "HP" || tipo == "Thinkpad" || tipo == "Mac")
                    {
                        Notebook notebook = new Notebook();
                        Notebook.EModeloNotebook modelo;
                        Enum.TryParse(reader["modelo"].ToString(), out modelo);
                        notebook.Modelo = modelo;
                        notebook.Cantidad = (int)reader["cantidad"];
                        notebook.Precio = (float)reader["precio"];
                        notebook.Nombre = reader["nombre"].ToString();

                        listaDispositivos.Add(notebook);
                    }
                    else
                    {
                        Celular celular = new Celular();
                        Celular.EModeloCelulares modelo;
                        Enum.TryParse(reader["modelo"].ToString(), out modelo);
                        celular.Modelo = modelo;
                        celular.Cantidad = (int)reader["cantidad"];
                        celular.Precio = (double)reader["precio"];
                        celular.Nombre = reader["nombre"].ToString();

                        listaDispositivos.Add(celular);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al intentar leer de la base de datos", e);
            }
            finally 
            {
                if (DispositivoDAO.conexion.State == ConnectionState.Open)
                    DispositivoDAO.conexion.Close();
            }
            return listaDispositivos;
        }

        public static bool DeleteDispositivo(string nombre) 
        {
            bool pudeEliminar = false;
            string sql = "DELETE FROM Dispositivos WHERE nombre = @nombre";
            DispositivoDAO.comando.CommandText = sql;
            DispositivoDAO.comando.Parameters.AddWithValue("@nombre",nombre);

            try
            {
                if (DispositivoDAO.conexion.State != ConnectionState.Open)
                {
                    DispositivoDAO.conexion.Open();
                }

                int filasAfectadas = DispositivoDAO.comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    pudeEliminar = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al conectarse con la base de datos", e);
            }
            finally 
            {
                if (DispositivoDAO.conexion.State == ConnectionState.Open)
                {
                    DispositivoDAO.conexion.Close();
                }
                DispositivoDAO.comando.Parameters.Clear();
            }
            return pudeEliminar;
        }
        #endregion
    }
}
