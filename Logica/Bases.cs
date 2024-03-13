using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaEscritorio.Logica
{
    public class Bases
    {
        public static void DiseñoDTV(ref DataGridView listados)
        {
            listados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; 


        }
        public static object Decimales( TextBox texto,KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                e.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]; 

            }
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
           else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(e.KeyChar=='.' && (~texto.Text.IndexOf("."))!=0)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return null;
        }
    }
}
