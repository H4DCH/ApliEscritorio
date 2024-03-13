using PruebaEscritorio.Logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PruebaEscritorio.Datos
{
    public class Dcargos
    {
        public bool InsertarCargo(Lcargo lcargo)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarCargo", Conexion.Conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cargo", lcargo.Cargo);
                cmd.Parameters.AddWithValue("@Sueldo", lcargo.Sueldo);
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
        public bool EditarCargo(Lcargo lcargo)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarCargo", Conexion.Conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCargo",lcargo.IdCargo);
                cmd.Parameters.AddWithValue("@Cargo", lcargo.Cargo);
                cmd.Parameters.AddWithValue("@Sueldo",lcargo.Sueldo);
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
        public void BuscarCargos(ref DataTable dt,string Buscador)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("BuscarCargos", Conexion.Conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
