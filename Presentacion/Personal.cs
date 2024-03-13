using PruebaEscritorio.Datos;
using PruebaEscritorio.Logica;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaEscritorio.Presentacion
{
    public partial class Personal : UserControl
    {
        public Personal()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PanelCargos.Visible = false;
            PanelPaginado.Visible = false;
            PanelRegistroPersonal.Visible = true;
            PanelRegistroPersonal.Dock = DockStyle.Fill;
            btnGuardarPersonal.Visible = true;
            btnGuardarCambiosPersonal.Visible = false;
            Limpiar();


        }
        private void Limpiar()
        {
            txtNombres.Clear();
            txtIdentificacion.Clear();
            txtCargo.Clear();
            txtSueldo.Clear();
            BuscarCargos();
        }


        private void InsertaPersonal()
        {
            Lpersonal lpersonal = new Lpersonal();
            Dpersonal dpersonal = new Dpersonal();

            lpersonal.Nombre = txtNombres.Text;
            lpersonal.Identificacion = txtIdentificacion.Text;
            lpersonal.Pais = cbxPais.Text;
        }

        private void InsertarCargo()
        {
            if (!string.IsNullOrEmpty(txtCargoNew.Text))
            {
                if (!string.IsNullOrEmpty(txtSueldoNew.Text))
                {

                    Lcargo lcargo = new Lcargo();
                    Dcargos dcargos = new Dcargos();
                    lcargo.Cargo = txtCargoNew.Text;
                    lcargo.Sueldo = double.Parse(txtSueldoNew.Text);

                    if (dcargos.InsertarCargo(lcargo) == true)
                    {
                        txtCargoNew.Clear();
                        BuscarCargos();
                        PanelCargos.Visible = false;

                    }
                    else
                    {
                        MessageBox.Show("Agregue el sueldo", "Falta el sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Agregue el cargo", "Falta el cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BuscarCargos()
        {
            DataTable dt = new DataTable();
            Dcargos dcargos = new Dcargos();

            dcargos.BuscarCargos(ref dt, txtCargo.Text);
            DataListadoCargos.DataSource = dt;
            Bases.DiseñoDTV(ref DataListadoCargos);

        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {
            BuscarCargos();
        }

        private void AgregarCargo_Click(object sender, EventArgs e)
        {
            PanelCargos.Visible = true;
            PanelCargos.Dock = DockStyle.Fill;
            PanelCargos.BringToFront();
            btnGuardarc.Visible = false;
            btnGuardar.Visible = true;
            txtCargoNew.Clear();
            txtSueldoNew.Clear();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarCargo();
        }

        private void txtSueldoNew_sKeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimales(txtSueldoNew, e);
        }

        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimales(txtSueldo, e);
        }

        private void btnGuardarPersonal_Click(object sender, EventArgs e)
        {

        }
    }
}
