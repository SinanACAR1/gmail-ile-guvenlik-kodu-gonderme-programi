using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int sayı;
        Random r = new Random();
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sayı = r.Next(10000,90000);
            MailMessage mesaj = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("mail adresiniz", "mail adresinizin şifresi");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            mesaj.To.Add (textBox2.Text);
            mesaj.From = new MailAddress("mail adresiniz");
            mesaj.Subject = "güvenlik kodu";
            mesaj.Body = sayı.ToString();
            istemci.Send(mesaj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == sayı.ToString())
            {
                label1.Text = "dogru";
                label1.ForeColor = Color.Green;
            }
            else
            { label1.Text = "yanlış"; label1.ForeColor = Color.Red; }

        }
    }
}
