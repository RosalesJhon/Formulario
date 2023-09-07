using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Formulario.Capa1;

namespace Formulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)

        {   
            //OCULTAR LOGIN

            this.Hide();
            FormCrear formCrear = new FormCrear();

            // Mostrar el form
            formCrear.Show();
        }

        //Inicio
        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //título de la ventana
            this.Text = "Acceso a cuenta";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = input_email.Text;
            string pwd = input_pwd.Text;

            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.ObtenerConexion();

            if (conn != null)
            {
                try
                {
                    string query = "SELECT * FROM Datos Correo = @Correo AND Contraseña = @pwd";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Correo", email);
                        command.Parameters.AddWithValue("@Password", pwd);

                        // Ejecutar consulta
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // Los datos coinciden, usuario autenticado
                            MessageBox.Show("Inicio de sesión exitoso.");
                            // Puedes realizar acciones adicionales después de la autenticación
                        }
                        else
                        {
                            // No se encontraron datos que coincidan
                            MessageBox.Show("Correo o contraseña incorrectos.");
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar datos: " + ex.Message);
                }
                finally
                {
                    // Cerrar la conexión
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Error en la conexión a la base de datos.");
            }

        }
    }
}
