using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace GestionImpresoras.DatosImpresoras
{
    public class AccesoDatos
    {
        private string cadena = ConfigurationManager.ConnectionStrings["ConexionImpresoras"].ConnectionString;

        public DataTable ObtenerDatos(string consulta, SqlParameter[] parametros = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(consulta, conn);
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex) { MessageBox.Show("Error SQL (Obtener): " + ex.Message); }
            }
            return dt;
        }

        public void EjecutarComando(string consulta, SqlParameter[] parametros)
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(consulta, conn);
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show("Error SQL (Ejecutar): " + ex.Message); }
            }
        }
    }
}