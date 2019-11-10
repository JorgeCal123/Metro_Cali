using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using modelo;
namespace MioMap
{


    public partial class Form2 : Form
    {
        Managment model;
        public Form2(Managment model)
        {
            this.model = model;
            InitializeComponent();
        }

        public void porcentaje(int numero)
        {
            progressBar1.Value = 80;

         //   double a = ((numero / 10485753) * 100);
          //  Console.WriteLine(a);
            
           
        }
        public void open()
        {
            this.ShowDialog();
           // this.Load();
        }

        public void Close()
        {
            this.Hide();
        }
        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        public void Load()
        {

            //      Thread cargar = new Thread(loadStops);
            //    cargar.Start();
            model.loadStops();
            model.createBus();
            model.timeReading();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            model.loadStops();
            model.createBus();
            model.timeReading();
        }
    }
}
