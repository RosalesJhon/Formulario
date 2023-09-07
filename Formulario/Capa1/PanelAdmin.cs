using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Formulario.Capa1;

namespace Formulario.Capa1
{
    public partial class PanelAdmin : Form
    {
        public PanelAdmin()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen; ;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //título de la ventana
            this.Text = "Panel admin";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();
            SqlConnection conn = conexion.ObtenerConexion();

            if (conn != null)
            {
                try
                {
                    string query = "SELECT * FROM DatosL";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adaptador = new SqlDataAdapter(command);
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        dataGridView1.DataSource = tabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar usuarios: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void PanelAdmin_Load(object sender, EventArgs e)
        {
        }
    }
}