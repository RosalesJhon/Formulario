using System;
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
            MessageBox.Show(valor);
            if (valor == captchabox)
            {
                MessageBox.Show("sON IGUALES");
                MessageBox.Show(valor);
            }
            else
            {
                MessageBox.Show("no son iguales");
                string captchaGenerado = GenerarCaptcha(6);
                Captcha.Text = captchaGenerado;
            }
        }
        private void Restablecer_Load(object sender, EventArgs e)
        {

            // Llamada para generar un CAPTCHA de 6 caracteres y mostrarlo en un Label llamado "labelCaptcha"
            string captchaGenerado = GenerarCaptcha(6);
            Captcha.Text = captchaGenerado;
        }
    }
}
