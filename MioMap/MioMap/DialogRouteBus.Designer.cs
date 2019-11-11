namespace MioMap
{
    partial class DialogRouteBus
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rutas = new System.Windows.Forms.CheckedListBox();
            this.mover = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rutas del MIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccion la ruta que desea Mover";
            // 
            // rutas
            // 
            this.rutas.CheckOnClick = true;
            this.rutas.FormattingEnabled = true;
            this.rutas.Location = new System.Drawing.Point(47, 71);
            this.rutas.Name = "rutas";
            this.rutas.Size = new System.Drawing.Size(351, 94);
            this.rutas.TabIndex = 2;
            this.rutas.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox1_SelectedIndexChanged);
            // 
            // mover
            // 
            this.mover.Location = new System.Drawing.Point(188, 171);
            this.mover.Name = "mover";
            this.mover.Size = new System.Drawing.Size(75, 23);
            this.mover.TabIndex = 3;
            this.mover.Text = "Mover";
            this.mover.UseVisualStyleBackColor = true;
            this.mover.Click += new System.EventHandler(this.Mover_Click);
            // 
            // DialogRouteBus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 194);
            this.Controls.Add(this.mover);
            this.Controls.Add(this.rutas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DialogRouteBus";
            this.Text = "DialogRouteBus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox rutas;
        private System.Windows.Forms.Button mover;
    }
}