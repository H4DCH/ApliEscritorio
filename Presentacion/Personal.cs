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
        int idCargo = 0;
        int desde = 1;
        int hasta = 10;
        int contador;
        int idPersonal;
        private int temsxPagina = 10;
        string estado;
        int totalPaginas;
        private void button2_Click(object sender, EventArgs e)
        {

            LocalizarDataGridCargos();
            PanelCargos.Visible = false;
            PanelPaginado.Visible = false;
            PanelRegistroPersonal.Visible = true;
            PanelRegistroPersonal.Dock = DockStyle.Fill;
            btnGuardarPersonal.Visible = true;
            btnGuardarCambiosPersonal.Visible = false;
            Limpiar();
        }
        private void LocalizarDataGridCargos()
        {
            DataListadoCargos.Location = new Point(panel8.Location.X, panel8.Location.Y);
            DataListadoCargos.Size = new Size(261, 77);
            DataListadoCargos.Visible = true;
            lblSueldo.Visible = false;
            panelBtnGuardarPersonal.Visible = false;
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
            lpersonal.IdCargo = idCargo;
            lpersonal.Sueldo = double.Parse(txtSueldo.Text);
            if (dpersonal.InsertarPersonal(lpersonal) == true)
            {
                MostrarPersonal();
                PanelRegistroPersonal.Visible = false;

            }
        }
        private void MostrarPersonal()
        {
            DataTable dt = new DataTable();
            Dpersonal dpersonal = new Dpersonal();
            dpersonal.MostrarPersonal(ref dt, desde, hasta);
            dataListadoPersonal.DataSource = dt;
            DiseñarDataGridPersonal();

        }

        private void DiseñarDataGridPersonal()
        {
            Bases.DiseñoDTV(ref dataListadoPersonal);
            PanelPaginado.Visible = true;
            dataListadoPersonal.Columns[2].Visible = false;
            dataListadoPersonal.Columns[7].Visible = false;
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
            DataListadoCargos.Columns[1].Visible = false;
            DataListadoCargos.Columns[3].Visible = false;
            DataListadoCargos.Visible = true;


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
            if (!string.IsNullOrEmpty(txtNombres.Text))
            {
                if (!string.IsNullOrEmpty(txtIdentificacion.Text))
                {
                    if (!string.IsNullOrEmpty(cbxPais.Text))
                    {
                        if (idCargo > 0)
                        {
                            if (!string.IsNullOrEmpty(txtSueldo.Text))
                            {
                                InsertaPersonal();
                            }
                        }
                    }
                }
            }
        }

        private void DataListadoCargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataListadoCargos.Columns["editarC"].Index)
            {
                ObtenerCargosEditar();
            }
            if (e.ColumnIndex == DataListadoCargos.Columns["Cargo"].Index)
            {
                ObtenerDatosCargo();
            }
        }

        private void ObtenerDatosCargo()
        {
            idCargo = Convert.ToInt32(DataListadoCargos.SelectedCells[1].Value);
            txtCargo.Text = DataListadoCargos.SelectedCells[2].Value.ToString();
            txtSueldo.Text = DataListadoCargos.SelectedCells[3].Value.ToString();
            DataListadoCargos.Visible = false;
            panelBtnGuardarPersonal.Visible = true;
            lblSueldo.Visible = true;

        }

        private void ObtenerCargosEditar()
        {
            idCargo = Convert.ToInt32(DataListadoCargos.SelectedCells[1].Value);
            txtCargoNew.Text = DataListadoCargos.SelectedCells[2].Value.ToString();
            txtSueldoNew.Text = DataListadoCargos.SelectedCells[3].Value.ToString();

            btnGuardar.Visible = false;
            btnGuardarc.Visible = true;
            txtCargo.Focus();
            txtCargoNew.SelectAll();
            PanelCargos.Visible = true;
            PanelCargos.Dock = DockStyle.Fill;
            PanelCargos.BringToFront();
        }

        private void btnVolverCargos_Click(object sender, EventArgs e)
        {
            PanelCargos.Visible = false;

        }

        private void btnVolverPersonal_Click(object sender, EventArgs e)
        {
            PanelRegistroPersonal.Visible = false;
        }

        private void btnGuardarc_Click(object sender, EventArgs e)
        {
            EditarCargos();
        }

        private void EditarCargos()
        {

            Lcargo lcargo = new Lcargo();
            Dcargos dcargos = new Dcargos();

            lcargo.IdCargo = idCargo;
            lcargo.Cargo = txtCargoNew.Text;
            lcargo.Sueldo = double.Parse(txtSueldoNew.Text);
            if (dcargos.EditarCargo(lcargo) == true)
            {
                txtCargo.Clear();
                BuscarCargos();
                PanelCargos.Visible = false;
            }
        }

        private void Personal_Load(object sender, EventArgs e)
        {
            MostrarPersonal();
        }

        private void dataListadoPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if(e.ColumnIndex == dataListadoPersonal.Columns["Eliminar"].Index)
              {
                DialogResult result = MessageBox.Show("¿Solo se cambiara el estado para que no pueda acceder, desea continuar?"
                    ,"Eliminando Registro",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarPersonal();
                }
            }

            if (e.ColumnIndex == dataListadoPersonal.Columns["Editar"].Index)
            {
                ObtenerDatos();
            }
        }

        private void ObtenerDatos()
        {
            idPersonal = (int)dataListadoPersonal.SelectedCells[2].Value;
            estado = dataListadoPersonal.SelectedCells[8].Value.ToString();
            if (estado == "ELIMINADO")
            {
                Restaura_Personal();
            }
            else
            {
                txtNombres.Text = dataListadoPersonal.SelectedCells[3].Value.ToString();
                txtIdentificacion.Text = dataListadoPersonal.SelectedCells[4].Value.ToString();
                cbxPais.Text = dataListadoPersonal.SelectedCells[10].Value.ToString();
                txtCargo.Text = dataListadoPersonal.SelectedCells[6].Value.ToString();
                idCargo = (int)dataListadoPersonal.SelectedCells[7].Value;
                txtSueldo.Text = dataListadoPersonal.SelectedCells[5].Value.ToString();
                PanelPaginado.Visible = false;
                PanelRegistroPersonal.Visible = true;
                PanelRegistroPersonal.Dock = DockStyle.Fill;
                DataListadoCargos.Visible = false;
                lblSueldo.Visible = true;
                panelBtnGuardarPersonal.Visible = false;
                btnGuardarCambiosPersonal.Visible = true;
                PanelCargos.Visible = false;
            }
        }
        private void Restaura_Personal()
        {
            DialogResult result = MessageBox.Show("Este personal se ELIMINO,¿Desea Volver a habilitarlo?"
          , "Restauracion de Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Habilitar_Personal();
            }


        }
        private void Habilitar_Personal()
        {
            Lpersonal lpersonal = new Lpersonal();
            Dpersonal dpersonal = new Dpersonal();

            lpersonal.IdPersonal = idPersonal;
            if (dpersonal.RestaurarPersonal(lpersonal) == true)
            {
                MostrarPersonal();

            }
        }
        private void EliminarPersonal()
        {
            idPersonal = (int)dataListadoPersonal.SelectedCells[2].Value;
            Lpersonal lpersonal = new Lpersonal();
            Dpersonal dpersonal = new Dpersonal();
            lpersonal.IdPersonal = idPersonal;
            if (dpersonal.EliminarPersonal(lpersonal) == true)
            {
                MostrarPersonal();
            }
        }
    }
}
