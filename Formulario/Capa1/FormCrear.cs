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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

        private void button1_Click(object sender, EventArgs e)
        {
            string servidor = "DESKTOP-2QR1BR7\\SQLEXPRESS";
            string bd = "Login";
            string usuario = "DESKTOP-2QR1BR7\\Equipo";

            //string connectionString = $"Data Source={servidor};Initial Catalog={bd};Integrated Security=True;User ID={usuario}";
            //SqlConnection conn = new SqlConnection(connectionString);

            //try
            //{
            //    conn.Open();
            //    MessageBox.Show("Conectado con la base de datos");

            //    string email2 = email;
            //    string pwd2 = pwd;

            //    // Consulta SQL para insertar datos
            //    string query = "INSERT INTO Login (nombre, contra) VALUES (@Email, @Password)";

            //    using (SqlCommand command = new SqlCommand(query, conn))
            //    {
            //        // Parametros para evitar la inyección de SQL
            //        command.Parameters.AddWithValue("@Email", email2);
            //        command.Parameters.AddWithValue("@Password", pwd2);

            //        // Ejecutar la consulta
            //        int rowsAffected = command.ExecuteNonQuery();

            //        if (rowsAffected > 0)
            //        {
            //            Console.WriteLine("Datos insertados correctamente.");
            //        }
            //        else
            //        {
            //            Console.WriteLine("No se pudo insertar datos.");
            //        }
            //    }

            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show("Fallo en la conexión: " + ex.ToString());
            //}
            //finally
            //{
            //    if (conn != null && conn.State == ConnectionState.Open)
            //    {
            //        conn.Close();
            //    }
            //}
            string nombre = input_nm.Text;
            string apellido = input_ape.Text;
            string correo = input_email.Text;
            string pwd1 = input_pw1.Text;
            string pwd2 = input_pw2.Text;

            if (pwd1 == pwd2)
            {

            }

            // Puedes hacer lo que quieras con los datos, por ejemplo, mostrarlos en un MessageBox
            MessageBox.Show("Nombre: " + nombre + "\nApellido: " + apellido);
        }
    }
}
