using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Formulario.Capa1
{
    public partial class Restablecer : Form
    {
        public string captchagenerado;
        public Restablecer()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; ;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //título de la ventana
            this.Text = "Restablecer Contraseña";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        // Generar un CAPTCHA
        private void GenerarNuevoCaptcha()
        {
            // Llamada para generar un CAPTCHA de 6 caracteres y mostrarlo en un Label llamado "Captcha"
            captchagenerado = GenerarCaptcha(6);
            Captcha.Text = captchagenerado;
        }
        //captcha
        private string GenerarCaptcha(int longitud)
        {
            const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder captcha = new StringBuilder();

            Random random = new Random();

            for (int i = 0; i < longitud; i++)
            {
                int indiceCaracter = random.Next(0, caracteresPermitidos.Length);
                captcha.Append(caracteresPermitidos[indiceCaracter]);
            }

            return captcha.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string captchabox = input_captcha.Text;
            string valor = Captcha.Text;
            string email = input_email.Text;
            string ape = input_ape.Text;
            string pwd = input_pwd.Text;

            if (valor == captchabox)
            {
                MessageBox.Show("Cambiando contraseña...");

                // instancia de conexión
                Conexion conexion = new Conexion();
                SqlConnection conn = conexion.ObtenerConexion();

                if (conn != null)
                {
                    try
                    {
                        // Consulta SQL insert
                        string query = "UPDATE DatosL SET Contraseña = @newpwd WHERE Correo = @correo AND Apellido = @ape";

                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            // Parametros para evitar inyecciones sql
                            command.Parameters.AddWithValue("@newpwd", pwd);
                            command.Parameters.AddWithValue("@correo", email);
                            command.Parameters.AddWithValue("@ape", ape);

                            // Ejecutar consulta
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Contraseña Cambiada con exito");

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
            }
            else
            {
                MessageBox.Show("Error en el Captcha ");
                return;
            }
        }
        private void Restablecer_Load(object sender, EventArgs e)
        {

            GenerarNuevoCaptcha();
        }

        private void input_pwd_TextChanged(object sender, EventArgs e)
        {
            input_pwd.PasswordChar = '*';
        }
    }
}
