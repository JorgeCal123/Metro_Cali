using System;
using System.Collections;
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
    public partial class DialogRouteBus : Form
    {
        Managment modelo;
        Form1 principal;
        public DialogRouteBus(Managment modelo, Form1 principal)
        {
            this.modelo = modelo;
            this.principal = principal;
            InitializeComponent();
            addItems();
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        public void addItems()
        {
            ICollection rut = modelo.Routes.Keys;

            foreach (String r in rut)
            {
                rutas.Items.Add(((Bus)modelo.Routes[r]).ShortName);
            }
        }

        private void Mover_Click(object sender, EventArgs e)
        {
            ICollection list = rutas.CheckedItems;
            if (list.Count==0)
            {
                MessageBox.Show("Debes Seleccionar por lo menos una ruta", "No seleccion de rutas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                principal.Selection1 = list;
                principal.StartTimer();
                this.Hide();
            }
          
        }
    }
}
