using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario.Capa1
{
    public partial class FormCrear : Form
    {
        public FormCrear()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormCrear_Load(object sender, EventArgs e)
        {
            try
            {
                //tamaño
                this.StartPosition = FormStartPosition.CenterScreen;
                this.MaximizeBox = false;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                //título de la ventana
                this.Text = "Crear Cuenta";
            }
            catch (Exception ex)
            {
                // Registra cualquier excepción que se pueda haber lanzado
                Console.WriteLine("Excepción en FormCrear_Load: " + ex.Message);
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
        }
    }
}
