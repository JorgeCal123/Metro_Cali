﻿using System;

namespace MioMap
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.UbicationTime = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbZonas = new System.Windows.Forms.ComboBox();
            this.cbParadas = new System.Windows.Forms.CheckBox();
            this.cbEstaciones = new System.Windows.Forms.CheckBox();
            this.cbTodo = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cargarParadas = new System.Windows.Forms.Button();
            this.cargarDatagrama = new System.Windows.Forms.Button();
            this.cargarBuses = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl1.AutoSize = true;
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(4, 2);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(518, 475);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.GMapControl1_OnMapZoomChanged);
            this.gMapControl1.Load += new System.EventHandler(this.GMapControl1_Load);
            this.gMapControl1.Resize += new System.EventHandler(this.Form1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mostrar alguna de las siguientes opciones:";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 305);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 39);
            this.button2.TabIndex = 6;
            this.button2.Text = "Mover un bus";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "mover Todos Los Buses";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // UbicationTime
            // 
            this.UbicationTime.AutoSize = true;
            this.UbicationTime.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.UbicationTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UbicationTime.Location = new System.Drawing.Point(0, 319);
            this.UbicationTime.Name = "UbicationTime";
            this.UbicationTime.Size = new System.Drawing.Size(0, 25);
            this.UbicationTime.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(132, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 39);
            this.button3.TabIndex = 10;
            this.button3.Text = "Pausar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MioMap.Properties.Resources.img100495;
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(186, 321);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "--";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(155, 321);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(25, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Cambiar Velocidad";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gMapControl1);
            this.panel1.Location = new System.Drawing.Point(7, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 486);
            this.panel1.TabIndex = 19;
            this.panel1.Resize += new System.EventHandler(this.Form1_Load);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.cbZonas);
            this.panel2.Controls.Add(this.cbParadas);
            this.panel2.Controls.Add(this.cbEstaciones);
            this.panel2.Controls.Add(this.cbTodo);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.UbicationTime);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Location = new System.Drawing.Point(546, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(245, 486);
            this.panel2.TabIndex = 1;
            // 
            // cbZonas
            // 
            this.cbZonas.FormattingEnabled = true;
            this.cbZonas.Items.AddRange(new object[] {
            "Zona Norte",
            "Zona Sur",
            "Zona Oeste",
            "Zona Oriente"});
            this.cbZonas.Location = new System.Drawing.Point(33, 128);
            this.cbZonas.Name = "cbZonas";
            this.cbZonas.Size = new System.Drawing.Size(165, 21);
            this.cbZonas.TabIndex = 20;
            this.cbZonas.SelectedIndexChanged += new System.EventHandler(this.cbZonas_SelectedIndexChanged);
            // 
            // cbParadas
            // 
            this.cbParadas.AutoSize = true;
            this.cbParadas.Location = new System.Drawing.Point(33, 212);
            this.cbParadas.Name = "cbParadas";
            this.cbParadas.Size = new System.Drawing.Size(65, 17);
            this.cbParadas.TabIndex = 19;
            this.cbParadas.Text = "Paradas";
            this.cbParadas.UseVisualStyleBackColor = true;
            this.cbParadas.CheckedChanged += new System.EventHandler(this.cbParadas_CheckedChanged);
            // 
            // cbEstaciones
            // 
            this.cbEstaciones.AutoSize = true;
            this.cbEstaciones.Location = new System.Drawing.Point(33, 188);
            this.cbEstaciones.Name = "cbEstaciones";
            this.cbEstaciones.Size = new System.Drawing.Size(78, 17);
            this.cbEstaciones.TabIndex = 18;
            this.cbEstaciones.Text = "Estaciones";
            this.cbEstaciones.UseVisualStyleBackColor = true;
            this.cbEstaciones.CheckedChanged += new System.EventHandler(this.cbEstaciones_CheckedChanged);
            // 
            // cbTodo
            // 
            this.cbTodo.AutoSize = true;
            this.cbTodo.Location = new System.Drawing.Point(33, 164);
            this.cbTodo.Name = "cbTodo";
            this.cbTodo.Size = new System.Drawing.Size(51, 17);
            this.cbTodo.TabIndex = 17;
            this.cbTodo.Text = "Todo";
            this.cbTodo.UseVisualStyleBackColor = true;
            this.cbTodo.CheckedChanged += new System.EventHandler(this.cbTodo_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cargarBuses);
            this.panel3.Controls.Add(this.cargarDatagrama);
            this.panel3.Controls.Add(this.cargarParadas);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(17, 355);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(213, 123);
            this.panel3.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(7, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Con cada boton cargue \r\nlos archivos correspondientes\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            
            // 
            // cargarParadas
            // 
            this.cargarParadas.Location = new System.Drawing.Point(26, 40);
            this.cargarParadas.Name = "cargarParadas";
            this.cargarParadas.Size = new System.Drawing.Size(159, 23);
            this.cargarParadas.TabIndex = 1;
            this.cargarParadas.Text = "Cargar archivo de paradas";
            this.cargarParadas.UseVisualStyleBackColor = true;
            this.cargarParadas.Click += new System.EventHandler(this.cargarParadas_Click);
            // 
            // cargarDatagrama
            // 
            this.cargarDatagrama.Location = new System.Drawing.Point(26, 70);
            this.cargarDatagrama.Name = "cargarDatagrama";
            this.cargarDatagrama.Size = new System.Drawing.Size(159, 23);
            this.cargarDatagrama.TabIndex = 2;
            this.cargarDatagrama.Text = "Cargar archivo de datagrama";
            this.cargarDatagrama.UseVisualStyleBackColor = true;
            this.cargarDatagrama.Click += new System.EventHandler(this.cargarDatagrama_Click);
            // 
            // cargarBuses
            // 
            this.cargarBuses.Location = new System.Drawing.Point(26, 100);
            this.cargarBuses.Name = "cargarBuses";
            this.cargarBuses.Size = new System.Drawing.Size(159, 23);
            this.cargarBuses.TabIndex = 3;
            this.cargarBuses.Text = "Cargar archivo de buses";
            this.cargarBuses.UseVisualStyleBackColor = true;
            this.cargarBuses.Click += new System.EventHandler(this.cargarBuses_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Gestión de paradas y estaciones de MIO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label UbicationTime;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbZonas;
        private System.Windows.Forms.CheckBox cbParadas;
        private System.Windows.Forms.CheckBox cbEstaciones;
        private System.Windows.Forms.CheckBox cbTodo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cargarBuses;
        private System.Windows.Forms.Button cargarDatagrama;
        private System.Windows.Forms.Button cargarParadas;
    }
}

