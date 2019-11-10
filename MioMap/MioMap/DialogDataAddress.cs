using modelo;
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

namespace MioMap
{
    public partial class DialogDataAddress : Form
    {
        Managment model;

        Boolean stopsR = false;
        Boolean datagramR = false;
        Boolean busR = false;
        Boolean estado = false;

        String messageError;
        Hashtable id;
        Form1 principal;


        public bool Estado { get => estado; set => estado = value; }

        public DialogDataAddress(Managment model)
        {
            this.model=model;
            iniciar();
            lb_Stop.Text = model.RELATIVE_PATH_STOPS;
            lb_Bus.Text = model.RELATIVE_PATH_BUS;
            lb_Datagram.Text = model.RELATIVE_PATH_DATAGRAM;
        }
        public void iniciar()
        {
            InitializeComponent();
           
            messageError = "";
            id = new Hashtable();
        }
        public DialogDataAddress(Form1 principal, Managment model)
        {
            this.model = model;
            this.principal = principal;
            iniciar();

        }
        private void Bt_Line_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files(*.csv)|*.csv";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String selected = ofd.FileName;
                // model.selectStops(selected);
                lb_Lines.Text = selected;
                if (!id.ContainsKey("4"))
                    id.Add(4, selected); stopsR = true;

            }
            estado = false;
        }

        //Busca el archivo buses

        private void Bt_Bus_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files(*.csv)|*.csv";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String selected = ofd.FileName;
                lb_Bus.Text = selected;
                if(!id.ContainsKey("3"))
                id.Add(3, selected);
                // model.selectBus(selected);
                busR = true;
            }
            estado = false;
        }

        //Busca el archivo datagram
        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files(*.csv)|*.csv";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String selected = ofd.FileName;
                //    model.selectDatagram(selected);
                lb_Datagram.Text = selected;
                if (!id.ContainsKey("2"))
                    id.Add(2, selected);
                datagramR = true;
            }
            estado = false;

        }


        //Busca el archivo Stop
        private void Bt_Stop_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files(*.csv)|*.csv";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String selected = ofd.FileName;
                // model.selectStops(selected);
                lb_Stop.Text = selected;
                if (!id.ContainsKey("1"))
                    id.Add(1, selected); stopsR = true;

            }
            estado = false;
        }

    
    


        //Cambia todos las rutas que estan malas
        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            
            estado = false;
            ICollection ids = id.Keys;
            messageError = "";
            foreach(int nuevo in ids)
            {
                model.editAbsolutePath(nuevo,((String)id[nuevo]).Replace(@"\","/" ));
            }
            model.Load();
            principal.Show();
        }

        internal void ErrorDatagram(String n)
        {
            messageError += "\n"+n;
        }

        internal void ErrorStop(String n)
        {
            messageError += "\n"+n;
         //   id.Add(1,lb_Stop.Text);

        }
        internal void ErrorBus(String m)
        {
            messageError += "\n"+m;
          //  id.Add(3, lb_Bus.Text);

        }

        internal void ErrorLine(String n)
        {
            messageError += "\n"+n;
            //id.Add(4,lb_Lines.Text);

        }

       


        public void DialogError()
        {
            MessageBox.Show(messageError, "Error seleccionar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void clearid()
        {
            id.Clear();
        }

    }

}
