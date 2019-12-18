using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Acceso.Models
{
    public class Validacion
    {
        private SqlConnection conexion;
        private void Conectar()
        {
            string conex = ConfigurationManager.ConnectionStrings["conexion"].ToString();
            conexion = new SqlConnection(conex);
        }

        public Usuario Recuperar(string usuario, string pass)
        {
            Boolean ac;
            Conectar();
            SqlCommand comando = new SqlCommand("select usuario, pass,rol from account_login where usuario=@usuario and pass=@pass",conexion);
            comando.Parameters.Add("@usuario", SqlDbType.VarChar);
            comando.Parameters["@usuario"].Value = usuario;
            comando.Parameters.Add("@pass", SqlDbType.VarChar);
            comando.Parameters["@pass"].Value = pass;
            conexion.Open();
            SqlDataReader registro = comando.ExecuteReader();
            Usuario acceso = new Usuario();
            if (registro.Read())
            {
                acceso.usuario = registro["usuario"].ToString();
                acceso.pass = registro["pass"].ToString();
                acceso.rol = registro["rol"].ToString();
                acceso.ac = true;
                
            }
            else
            {
             acceso.ac=false;

            }
            conexion.Close();
            return acceso;
        }
        
    }
}