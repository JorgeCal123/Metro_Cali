using System;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
<<<<<<< HEAD
            this.rbParadas = new System.Windows.Forms.RadioButton();
            this.rbEstaciones = new System.Windows.Forms.RadioButton();
            this.Lb_infoOption = new System.Windows.Forms.Label();
            this.rbTodo = new System.Windows.Forms.RadioButton();
            this.bt_Ruta = new System.Windows.Forms.Button();
=======
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bt_BusAllMove = new System.Windows.Forms.Button();
            this.Lb_UbicationTime = new System.Windows.Forms.Label();
            this.bt_Pause = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.bt_velMin = new System.Windows.Forms.Button();
            this.bt_velMax = new System.Windows.Forms.Button();
            this.Lb_infoSpeed = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
<<<<<<< HEAD
            this.panel4 = new System.Windows.Forms.Panel();
            this.lb_Title_Movement = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_Title_Station_Stop = new System.Windows.Forms.Label();
            this.cbZonas = new System.Windows.Forms.ComboBox();
            this.Lb_infoZone = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
=======
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
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
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
<<<<<<< HEAD
            this.gMapControl1.Size = new System.Drawing.Size(518, 513);
=======
            this.gMapControl1.Size = new System.Drawing.Size(518, 475);
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.GMapControl1_OnMapZoomChanged);
            this.gMapControl1.Resize += new System.EventHandler(this.Form1_Load);
            // 
<<<<<<< HEAD
            // rbParadas
            // 
            this.rbParadas.AutoSize = true;
            this.rbParadas.Location = new System.Drawing.Point(36, 100);
            this.rbParadas.Name = "rbParadas";
            this.rbParadas.Size = new System.Drawing.Size(77, 17);
            this.rbParadas.TabIndex = 1;
            this.rbParadas.Text = "Estaciones";
            this.rbParadas.UseVisualStyleBackColor = true;
            this.rbParadas.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // rbEstaciones
            // 
            this.rbEstaciones.AutoSize = true;
            this.rbEstaciones.Location = new System.Drawing.Point(36, 77);
            this.rbEstaciones.Name = "rbEstaciones";
            this.rbEstaciones.Size = new System.Drawing.Size(64, 17);
            this.rbEstaciones.TabIndex = 2;
            this.rbEstaciones.Text = "Paradas";
            this.rbEstaciones.UseVisualStyleBackColor = true;
            this.rbEstaciones.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // Lb_infoOption
            // 
            this.Lb_infoOption.AutoSize = true;
            this.Lb_infoOption.Location = new System.Drawing.Point(7, 38);
            this.Lb_infoOption.Name = "Lb_infoOption";
            this.Lb_infoOption.Size = new System.Drawing.Size(208, 13);
            this.Lb_infoOption.TabIndex = 3;
            this.Lb_infoOption.Text = "Selecciona una de las siguientes opciones";
            // 
            // rbTodo
            // 
            this.rbTodo.AutoSize = true;
            this.rbTodo.Location = new System.Drawing.Point(36, 54);
            this.rbTodo.Name = "rbTodo";
            this.rbTodo.Size = new System.Drawing.Size(50, 17);
            this.rbTodo.TabIndex = 4;
            this.rbTodo.Text = "Todo";
            this.rbTodo.UseVisualStyleBackColor = true;
            this.rbTodo.CheckedChanged += new System.EventHandler(this.rbTodo_CheckedChanged);
            // 
            // bt_Ruta
            // 
            this.bt_Ruta.Location = new System.Drawing.Point(10, 78);
            this.bt_Ruta.Name = "bt_Ruta";
            this.bt_Ruta.Size = new System.Drawing.Size(98, 39);
            this.bt_Ruta.TabIndex = 6;
            this.bt_Ruta.Text = "Mover Rutas";
            this.bt_Ruta.UseVisualStyleBackColor = true;
            this.bt_Ruta.Click += new System.EventHandler(this.Button2_Click);
=======
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
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // bt_BusAllMove
            // 
<<<<<<< HEAD
            this.bt_BusAllMove.Location = new System.Drawing.Point(10, 33);
            this.bt_BusAllMove.Name = "bt_BusAllMove";
            this.bt_BusAllMove.Size = new System.Drawing.Size(98, 39);
            this.bt_BusAllMove.TabIndex = 8;
            this.bt_BusAllMove.Text = "mover Todos Los Buses";
            this.bt_BusAllMove.UseVisualStyleBackColor = true;
            this.bt_BusAllMove.Click += new System.EventHandler(this.Button1_Click);
=======
            this.button1.Location = new System.Drawing.Point(15, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "mover Todos Los Buses";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
            // 
            // Lb_UbicationTime
            // 
            this.Lb_UbicationTime.AutoSize = true;
            this.Lb_UbicationTime.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Lb_UbicationTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_UbicationTime.Location = new System.Drawing.Point(5, 137);
            this.Lb_UbicationTime.Name = "Lb_UbicationTime";
            this.Lb_UbicationTime.Size = new System.Drawing.Size(0, 25);
            this.Lb_UbicationTime.TabIndex = 9;
            // 
            // bt_Pause
            // 
<<<<<<< HEAD
            this.bt_Pause.Location = new System.Drawing.Point(127, 33);
            this.bt_Pause.Name = "bt_Pause";
            this.bt_Pause.Size = new System.Drawing.Size(98, 39);
            this.bt_Pause.TabIndex = 10;
            this.bt_Pause.Text = "Pausar";
            this.bt_Pause.UseVisualStyleBackColor = true;
            this.bt_Pause.Click += new System.EventHandler(this.Button3_Click);
=======
            this.button3.Location = new System.Drawing.Point(132, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 39);
            this.button3.TabIndex = 10;
            this.button3.Text = "Pausar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
        //    this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // bt_velMin
            // 
<<<<<<< HEAD
            this.bt_velMin.Location = new System.Drawing.Point(181, 94);
            this.bt_velMin.Name = "bt_velMin";
            this.bt_velMin.Size = new System.Drawing.Size(25, 23);
            this.bt_velMin.TabIndex = 14;
            this.bt_velMin.Text = "--";
            this.bt_velMin.UseVisualStyleBackColor = true;
            this.bt_velMin.Click += new System.EventHandler(this.Button5_Click);
=======
            this.button5.Location = new System.Drawing.Point(186, 321);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "--";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
            // 
            // bt_velMax
            // 
<<<<<<< HEAD
            this.bt_velMax.Location = new System.Drawing.Point(150, 94);
            this.bt_velMax.Name = "bt_velMax";
            this.bt_velMax.Size = new System.Drawing.Size(25, 23);
            this.bt_velMax.TabIndex = 15;
            this.bt_velMax.Text = "+";
            this.bt_velMax.UseVisualStyleBackColor = true;
            this.bt_velMax.Click += new System.EventHandler(this.Button6_Click);
=======
            this.button6.Location = new System.Drawing.Point(155, 321);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(25, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
            // 
            // Lb_infoSpeed
            // 
<<<<<<< HEAD
            this.Lb_infoSpeed.AutoSize = true;
            this.Lb_infoSpeed.Location = new System.Drawing.Point(130, 78);
            this.Lb_infoSpeed.Name = "Lb_infoSpeed";
            this.Lb_infoSpeed.Size = new System.Drawing.Size(95, 13);
            this.Lb_infoSpeed.TabIndex = 16;
            this.Lb_infoSpeed.Text = "Cambiar Velocidad";
=======
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Cambiar Velocidad";
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
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
<<<<<<< HEAD
            this.panel1.Size = new System.Drawing.Size(533, 524);
=======
            this.panel1.Size = new System.Drawing.Size(533, 486);
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
            this.panel1.TabIndex = 19;
            this.panel1.Resize += new System.EventHandler(this.Form1_Load);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
<<<<<<< HEAD
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(543, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 532);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lb_Title_Movement);
            this.panel4.Controls.Add(this.bt_BusAllMove);
            this.panel4.Controls.Add(this.bt_velMin);
            this.panel4.Controls.Add(this.bt_velMax);
            this.panel4.Controls.Add(this.bt_Ruta);
            this.panel4.Controls.Add(this.bt_Pause);
            this.panel4.Controls.Add(this.Lb_UbicationTime);
            this.panel4.Controls.Add(this.Lb_infoSpeed);
            this.panel4.Location = new System.Drawing.Point(6, 296);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(239, 189);
            this.panel4.TabIndex = 20;
            // 
            // lb_Title_Movement
            // 
            this.lb_Title_Movement.AutoSize = true;
            this.lb_Title_Movement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Title_Movement.Location = new System.Drawing.Point(26, 0);
            this.lb_Title_Movement.Name = "lb_Title_Movement";
            this.lb_Title_Movement.Size = new System.Drawing.Size(145, 15);
            this.lb_Title_Movement.TabIndex = 20;
            this.lb_Title_Movement.Text = "Opciones Movimiento";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lb_Title_Station_Stop);
            this.panel3.Controls.Add(this.cbZonas);
            this.panel3.Controls.Add(this.rbParadas);
            this.panel3.Controls.Add(this.Lb_infoZone);
            this.panel3.Controls.Add(this.rbEstaciones);
            this.panel3.Controls.Add(this.Lb_infoOption);
            this.panel3.Controls.Add(this.rbTodo);
            this.panel3.Location = new System.Drawing.Point(3, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 187);
            this.panel3.TabIndex = 19;
            // 
            // lb_Title_Station_Stop
            // 
            this.lb_Title_Station_Stop.AutoSize = true;
            this.lb_Title_Station_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Title_Station_Stop.Location = new System.Drawing.Point(21, 13);
            this.lb_Title_Station_Stop.Name = "lb_Title_Station_Stop";
            this.lb_Title_Station_Stop.Size = new System.Drawing.Size(206, 15);
            this.lb_Title_Station_Stop.TabIndex = 19;
            this.lb_Title_Station_Stop.Text = "Opciones paradas y estaciones";
         //   this.lb_Title_Station_Stop.Click += new System.EventHandler(this.Label1_Click_1);
            // 
            // cbZonas
            // 
            this.cbZonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZonas.FormattingEnabled = true;
            this.cbZonas.Items.AddRange(new object[] {
            "Zona Norte",
            "Zona Este",
            "Zona Oeste",
            "Zona Sur"});
            this.cbZonas.Location = new System.Drawing.Point(36, 145);
            this.cbZonas.Name = "cbZonas";
            this.cbZonas.Size = new System.Drawing.Size(121, 21);
            this.cbZonas.TabIndex = 18;
            this.cbZonas.SelectedIndexChanged += new System.EventHandler(this.CbZonas_SelectedIndexChanged);
            // 
            // Lb_infoZone
            // 
            this.Lb_infoZone.AutoSize = true;
            this.Lb_infoZone.Location = new System.Drawing.Point(6, 123);
            this.Lb_infoZone.Name = "Lb_infoZone";
            this.Lb_infoZone.Size = new System.Drawing.Size(91, 13);
            this.Lb_infoZone.TabIndex = 17;
            this.Lb_infoZone.Text = "Mostrar por zonas";
=======
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
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(800, 548);
=======
            this.ClientSize = new System.Drawing.Size(800, 510);
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
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
<<<<<<< HEAD
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
=======
            this.panel2.PerformLayout();
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
<<<<<<< HEAD
        private System.Windows.Forms.RadioButton rbParadas;
        private System.Windows.Forms.RadioButton rbEstaciones;
        private System.Windows.Forms.Label Lb_infoOption;
        private System.Windows.Forms.RadioButton rbTodo;
        private System.Windows.Forms.Button bt_Ruta;
=======
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bt_BusAllMove;
        private System.Windows.Forms.Label Lb_UbicationTime;
        private System.Windows.Forms.Button bt_Pause;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button bt_velMin;
        private System.Windows.Forms.Button bt_velMax;
        private System.Windows.Forms.Label Lb_infoSpeed;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
<<<<<<< HEAD
        private System.Windows.Forms.Label Lb_infoZone;
        private System.Windows.Forms.ComboBox cbZonas;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_Title_Station_Stop;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lb_Title_Movement;
=======
        private System.Windows.Forms.ComboBox cbZonas;
        private System.Windows.Forms.CheckBox cbParadas;
        private System.Windows.Forms.CheckBox cbEstaciones;
        private System.Windows.Forms.CheckBox cbTodo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cargarBuses;
        private System.Windows.Forms.Button cargarDatagrama;
        private System.Windows.Forms.Button cargarParadas;
>>>>>>> 66edb958d0130e57815f50a493d2a1e6f2023bd4
    }
}

