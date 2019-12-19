using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Agenda.Models
{
    public class ABMAgenda
    {
        private SqlConnection conexion;
        private void Conectar()
        {
            string conex = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
            conexion = new SqlConnection(conex);
        }


        public int Alta(Contacto cont)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert  into contacto(NombreContacto,ApellidoPaterno,ApellidoMaterno,sexo,direccion,Referencia,telefono)" +
                "values(@NombreContacto,@ApellidoPaterno,@ApellidoMaterno,@sexo,@direccion,@Referencia,@telefono)",conexion);
            comando.Parameters.Add("@NombreContacto", SqlDbType.VarChar);
            comando.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar);
            comando.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar);
            comando.Parameters.Add("@sexo", SqlDbType.VarChar);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@Referencia", SqlDbType.VarChar);
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters["@NombreContacto"].Value = cont.NombreContacto;
            comando.Parameters["@ApellidoPaterno"].Value = cont.ApellidoPaterno;
            comando.Parameters["@ApellidoMaterno"].Value = cont.ApellidoMaterno;
            comando.Parameters["@sexo"].Value = cont.sexo;
            comando.Parameters["@direccion"].Value = cont.direccion;
            comando.Parameters["@Referencia"].Value = cont.Referencia;
            comando.Parameters["@telefono"].Value = cont.telefono;
            conexion.Open();
            int i = comando.ExecuteNonQuery();
            conexion.Close();
            return i;
        }

        public List<Contacto> RecuperaContactos()
        {
            Conectar();
            List<Contacto> contactos = new List<Contacto>();
            SqlCommand comando = new SqlCommand("select Idcontacto,NombreContacto,ApellidoPaterno,ApellidoMaterno,sexo,direccion,Referencia,telefono from contacto", conexion);
            conexion.Open();
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Contacto cont = new Contacto
                {
                    Idcontacto = int.Parse(registros["IdContacto"].ToString()),
                    NombreContacto = registros["NombreContacto"].ToString(),
                    ApellidoPaterno = registros["ApellidoPaterno"].ToString(),
                    ApellidoMaterno = registros["ApellidoMaterno"].ToString(),
                    sexo = registros["sexo"].ToString(),
                    direccion = registros["direccion"].ToString(),
                    Referencia = registros["Referencia"].ToString(),
                    telefono = registros["telefono"].ToString()
                };
                contactos.Add(cont);
            }
            conexion.Close();
            return contactos;
        }
        
        public Contacto Recuperar(int Idcontacto)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Idcontacto, " +
                "NombreContacto, " +
                "ApellidoPaterno," +
                " ApellidoMaterno," +
                " sexo," +
                "direccion," +
                " Referencia, " +
                "telefono from contacto" +
                " where Idcontacto=@Idcontacto", conexion);
            comando.Parameters.Add("@IdContacto", SqlDbType.Int);
            comando.Parameters["@Idcontacto"].Value = Idcontacto;
            conexion.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Contacto contactos = new Contacto();
            if (registros.Read())
            {
                contactos.Idcontacto = int.Parse(registros["IdContacto"].ToString());
                contactos.NombreContacto = registros["NombreContacto"].ToString();
                contactos.ApellidoPaterno = registros["ApellidoPaterno"].ToString();
                contactos.ApellidoMaterno = registros["ApellidoMaterno"].ToString();
                contactos.sexo = registros["sexo"].ToString();
                contactos.direccion = registros["direccion"].ToString();
                contactos.Referencia = registros["Referencia"].ToString();
                contactos.telefono = registros["telefono"].ToString();
            };
            conexion.Close();
            return contactos;
            
        }
                    
    public int Modificar(Contacto cont)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update contacto set NombreContacto=@NombreContacto," +
                                                                    "ApellidoPaterno=@ApellidoPaterno," +
                                                                    "ApellidoMaterno=@ApellidoMaterno," +
                                                                    "sexo=@sexo,direccion=@direccion," +
                                                                    "Referencia=@Referencia," +
                                                                    "telefono=@telefono " +
                                                                    "where Idcontacto=@Idcontacto", conexion);
            comando.Parameters.Add("@Idcontacto", SqlDbType.Int);
            comando.Parameters["@Idcontacto"].Value = cont.Idcontacto;

            comando.Parameters.Add("@NombreContacto", SqlDbType.VarChar);
            comando.Parameters["@NombreContacto"].Value = cont.NombreContacto;

            comando.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar);
            comando.Parameters["@ApellidoPaterno"].Value = cont.ApellidoPaterno;

            comando.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar);
            comando.Parameters["@ApellidoMaterno"].Value = cont.ApellidoMaterno;

            comando.Parameters.Add("@sexo", SqlDbType.VarChar);
            comando.Parameters["@sexo"].Value = cont.sexo;

            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters["@direccion"].Value = cont.direccion;

            comando.Parameters.Add("@Referencia", SqlDbType.VarChar);
            comando.Parameters["@Referencia"].Value = cont.Referencia;

            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters["@telefono"].Value = cont.telefono;

            conexion.Open();
            int i = comando.ExecuteNonQuery();
            conexion.Close();
            return i;

        }
        public int Borrar(int Idcontacto)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from contacto where Idcontacto=@Idcontacto", conexion);
            comando.Parameters.Add("@Idcontacto", SqlDbType.Int);
            comando.Parameters["@Idcontacto"].Value = Idcontacto;
            conexion.Open();
            int i = comando.ExecuteNonQuery();
            conexion.Close();
            return i;
              

        }


        public Usuario Validacontacto(string usuario,string pass)
        {
           
            Conectar();
            SqlCommand comando = new SqlCommand("select usuario,pass,rol from Usuarios where usuario=@usuario and pass=@pass", conexion);

            comando.Parameters.Add("@usuario", SqlDbType.VarChar);
            comando.Parameters["@usuario"].Value =usuario;
            comando.Parameters.Add("@pass", SqlDbType.VarChar);
            comando.Parameters["@pass"].Value = pass;
            conexion.Open();

            SqlDataReader registros = comando.ExecuteReader();
            Usuario usu = new Usuario();
            if (registros.Read())
            {
                usu.usuario = registros["usuario"].ToString();
                usu.pass = registros["pass"].ToString();
                usu.rol = registros["rol"].ToString();
                usu.acc = true;

            }
            else
            {
                usu.acc = false;

            }
            conexion.Close();
            return usu;

        }

    }
}