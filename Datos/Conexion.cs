using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;

namespace PruebaEscritorio.Datos
{
    public class Conexion   
        
    {
        public static string ConexionBase = @"Server=EQUIPOHARRY\SQLHARRY;Database=BaseAPPEscritorio;Integrated Security=True;TrustServerCertificate=true;";

        public static SqlConnection Conectar = new SqlConnection(ConexionBase);
        public static void abrir()
        {
            try
            {
                if (Conectar.State == ConnectionState.Closed)
                {
                    Conectar.Open();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
           
        }

        public static void cerrar()
        {
            if (Conectar.State == ConnectionState.Open)
            {
                Conectar.Close();
            }
        }
    }
}
