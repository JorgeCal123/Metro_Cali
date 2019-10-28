using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using modelo;
namespace MioMap
{


    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void porcentaje(int numero)
        {
            progressBar1.Value = numero/10485753*100;
            
           
        }
        public void open()
        {
            this.Show();
        }

        public void Close()
        {
            this.Hide();
        }
        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
