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
using Formulario;

namespace Formulario.Capa1
{
    public partial class FormCrear : Form
    {
        public FormCrear()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; ;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //título de la ventana
            this.Text = "Crear cuenta";
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
            // Obtener datos de los textbox
            string nombre = input_nm.Text;
            string apellido = input_ape.Text;
            string correo = input_email.Text;
            string pwd1 = input_pw1.Text;
            string pwd2 = input_pw2.Text;

            //verificar campos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(pwd1) || string.IsNullOrEmpty(pwd2))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (pwd1 != pwd2)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return; //si las contraseñas no coinciden
            }

            // instancia de conexión
            Conexion conexion = new Conexion();

            SqlConnection conn = conexion.ObtenerConexion();

            if (conn != null)
            {
                try
                {
                    // Consulta SQL insert
                    string query = "INSERT INTO DatosL (nombre,apellido,correo,contraseña) VALUES (@Nombre, @Apellido, @Correo, @Password)";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        // Parametros para evitar inyecciones sql
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Apellido", apellido);
                        command.Parameters.AddWithValue("@Correo", correo);
                        command.Parameters.AddWithValue("@Password", pwd1);

                        // Ejecutar consulta
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Usuario creado correctamente");

                            this.Hide();
                            //FormCrear cerrar = new FormCrear();
                            //cerrar.
                            Form1 login = new Form1();
                            login.Show();
                            
                        }
                        else
                        {
                            MessageBox.Show("No se pudo crear usuario");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar datos: " + ex.Message);
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

        private void input_pw1_TextChanged(object sender, EventArgs e)
        {
            input_pw1.PasswordChar = '*';
        }

        private void input_pw2_TextChanged(object sender, EventArgs e)
        {
            input_pw2.PasswordChar = '*';

        }
    }
}
