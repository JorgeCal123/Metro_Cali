namespace MioMap
{
    partial class DialogDataAddress
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_Stop = new System.Windows.Forms.Label();
            this.lb_Bus = new System.Windows.Forms.Label();
            this.lb_Datagram = new System.Windows.Forms.Label();
            this.bt_Stop = new System.Windows.Forms.Button();
            this.bt_Bus = new System.Windows.Forms.Button();
            this.bt_DataGram = new System.Windows.Forms.Button();
            this.bt_ACeptar = new System.Windows.Forms.Button();
            this.bt_Cancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.bt_Line = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_Lines = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Stop
            // 
            this.lb_Stop.Location = new System.Drawing.Point(44, 44);
            this.lb_Stop.Name = "lb_Stop";
            this.lb_Stop.Size = new System.Drawing.Size(201, 18);
            this.lb_Stop.TabIndex = 0;
            // 
            // lb_Bus
            // 
            this.lb_Bus.Location = new System.Drawing.Point(41, 73);
            this.lb_Bus.Name = "lb_Bus";
            this.lb_Bus.Size = new System.Drawing.Size(204, 18);
            this.lb_Bus.TabIndex = 1;
            // 
            // lb_Datagram
            // 
            this.lb_Datagram.Location = new System.Drawing.Point(44, 102);
            this.lb_Datagram.Name = "lb_Datagram";
            this.lb_Datagram.Size = new System.Drawing.Size(201, 18);
            this.lb_Datagram.TabIndex = 2;
            // 
            // bt_Stop
            // 
            this.bt_Stop.Location = new System.Drawing.Point(260, 44);
            this.bt_Stop.Name = "bt_Stop";
            this.bt_Stop.Size = new System.Drawing.Size(111, 23);
            this.bt_Stop.TabIndex = 3;
            this.bt_Stop.Text = "Cargar Paradas";
            this.bt_Stop.UseVisualStyleBackColor = true;
            this.bt_Stop.Click += new System.EventHandler(this.Bt_Stop_Click);
            // 
            // bt_Bus
            // 
            this.bt_Bus.Location = new System.Drawing.Point(260, 73);
            this.bt_Bus.Name = "bt_Bus";
            this.bt_Bus.Size = new System.Drawing.Size(111, 23);
            this.bt_Bus.TabIndex = 4;
            this.bt_Bus.Text = "Cargar Buses";
            this.bt_Bus.UseVisualStyleBackColor = true;
            this.bt_Bus.Click += new System.EventHandler(this.Bt_Bus_Click);
            // 
            // bt_DataGram
            // 
            this.bt_DataGram.Location = new System.Drawing.Point(260, 102);
            this.bt_DataGram.Name = "bt_DataGram";
            this.bt_DataGram.Size = new System.Drawing.Size(111, 23);
            this.bt_DataGram.TabIndex = 5;
            this.bt_DataGram.Text = "Cargar Datagram";
            this.bt_DataGram.UseVisualStyleBackColor = true;
            this.bt_DataGram.Click += new System.EventHandler(this.Button3_Click);
            // 
            // bt_ACeptar
            // 
            this.bt_ACeptar.Location = new System.Drawing.Point(99, 239);
            this.bt_ACeptar.Name = "bt_ACeptar";
            this.bt_ACeptar.Size = new System.Drawing.Size(75, 23);
            this.bt_ACeptar.TabIndex = 6;
            this.bt_ACeptar.Text = "Aceptar";
            this.bt_ACeptar.UseVisualStyleBackColor = true;
            this.bt_ACeptar.Click += new System.EventHandler(this.Button4_Click);
            // 
            // bt_Cancelar
            // 
            this.bt_Cancelar.Location = new System.Drawing.Point(212, 239);
            this.bt_Cancelar.Name = "bt_Cancelar";
            this.bt_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancelar.TabIndex = 7;
            this.bt_Cancelar.Text = "Cancelar";
            this.bt_Cancelar.UseVisualStyleBackColor = true;
           // this.bt_Cancelar.Click += new System.EventHandler(this.Button5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(129, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cargar Datos";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(260, 189);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(260, 160);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 13;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // bt_Line
            // 
            this.bt_Line.Location = new System.Drawing.Point(260, 131);
            this.bt_Line.Name = "bt_Line";
            this.bt_Line.Size = new System.Drawing.Size(111, 23);
            this.bt_Line.TabIndex = 12;
            this.bt_Line.Text = "CargarLine";
            this.bt_Line.UseVisualStyleBackColor = true;
            this.bt_Line.Click += new System.EventHandler(this.Bt_Line_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "label6";
            // 
            // lb_Lines
            // 
            this.lb_Lines.Location = new System.Drawing.Point(44, 131);
            this.lb_Lines.Name = "lb_Lines";
            this.lb_Lines.Size = new System.Drawing.Size(201, 18);
            this.lb_Lines.TabIndex = 9;
            // 
            // DialogDataAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 293);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.bt_Line);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_Lines);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bt_Cancelar);
            this.Controls.Add(this.bt_ACeptar);
            this.Controls.Add(this.bt_DataGram);
            this.Controls.Add(this.bt_Bus);
            this.Controls.Add(this.bt_Stop);
            this.Controls.Add(this.lb_Datagram);
            this.Controls.Add(this.lb_Bus);
            this.Controls.Add(this.lb_Stop);
            this.Name = "DialogDataAddress";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Stop;
        private System.Windows.Forms.Label lb_Bus;
        private System.Windows.Forms.Label lb_Datagram;
        private System.Windows.Forms.Button bt_Stop;
        private System.Windows.Forms.Button bt_Bus;
        private System.Windows.Forms.Button bt_DataGram;
        private System.Windows.Forms.Button bt_ACeptar;
        private System.Windows.Forms.Button bt_Cancelar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button bt_Line;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_Lines;
    }
}