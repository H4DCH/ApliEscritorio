using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaEscritorio.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            PanelBienvenida.Dock = DockStyle.Fill;
        }

        private void btn_Persona_Click(object sender, EventArgs e)
        {
            PanelPadre.Controls.Clear();
            Personal personal = new Personal();
            personal.Dock = DockStyle.Fill;
            PanelPadre.Controls.Add(personal);
        }
    }
}
