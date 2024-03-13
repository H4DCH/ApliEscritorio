using PruebaEscritorio.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PruebaEscritorio.Datos
{
    public class Dpersonal
    {
        public bool InsertarPersonal(Lpersonal lpersonal)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarPersonal", Conexion.Conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", lpersonal.Nombre);
                cmd.Parameters.AddWithValue("@Identificacion", lpersonal.Identificacion);
                cmd.Parameters.AddWithValue("@Pais", lpersonal.Pais);
                cmd.Parameters.AddWithValue("@IdCargo", lpersonal.IdCargo);
                cmd.Parameters.AddWithValue("@Sueldo", lpersonal.Sueldo);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarPersonal(Lpersonal lpersonal)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarPersonal", Conexion.Conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPersonal", lpersonal.IdPersonal);
                cmd.Parameters.AddWithValue("@Nombre", lpersonal.Nombre);
                cmd.Parameters.AddWithValue("@Identificacion", lpersonal.Identificacion);
                cmd.Parameters.AddWithValue("@Pais", lpersonal.Pais);
                cmd.Parameters.AddWithValue("@IdCargo", lpersonal.IdCargo);
                cmd.Parameters.AddWithValue("@Sueldo", lpersonal.Sueldo);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarPersonal(Lpersonal lpersonal)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarPersonal", Conexion.Conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPersonal", lpersonal.IdPersonal);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarPersonal(ref DataTable dt, int Desde, int Hasta)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarPersonal", Conexion.Conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", Desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", Hasta);
                da.Fill(dt);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void BuscarPersonal(ref DataTable dt, int Desde, int Hasta, string Buscador)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("BuscarPersonal", Conexion.Conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", Desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", Hasta);
                da.SelectCommand.Parameters.AddWithValue("@Buscador", Buscador);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
