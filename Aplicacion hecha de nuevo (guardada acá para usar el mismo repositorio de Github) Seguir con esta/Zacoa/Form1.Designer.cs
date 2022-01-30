namespace CuentasClaras
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
            this.checkNacho = new System.Windows.Forms.CheckBox();
            this.CheckAmbos = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.barra = new System.Windows.Forms.ProgressBar();
            this.Historial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MontoEnposo = new System.Windows.Forms.TextBox();
            this.Guardar = new System.Windows.Forms.Button();
            this.MontoGastado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MontoAnto2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MontoNacho2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.radioCuenta = new System.Windows.Forms.RadioButton();
            this.radioDeudaAgregar = new System.Windows.Forms.RadioButton();
            this.RadioDeudaRestar = new System.Windows.Forms.RadioButton();
            this.checkAnto = new System.Windows.Forms.CheckBox();
            this.Full2 = new System.Windows.Forms.CheckBox();
            this.checkHalf = new System.Windows.Forms.CheckBox();
            this.VerHistorial = new System.Windows.Forms.Button();
            this.GenerarArchivo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkNacho
            // 
            this.checkNacho.AutoSize = true;
            this.checkNacho.Location = new System.Drawing.Point(157, 53);
            this.checkNacho.Name = "checkNacho";
            this.checkNacho.Size = new System.Drawing.Size(58, 17);
            this.checkNacho.TabIndex = 0;
            this.checkNacho.Text = "Nacho";
            this.checkNacho.UseVisualStyleBackColor = true;
            this.checkNacho.CheckedChanged += new System.EventHandler(this.checkBoxNacho_CheckedChanged);
            // 
            // CheckAmbos
            // 
            this.CheckAmbos.AutoSize = true;
            this.CheckAmbos.Location = new System.Drawing.Point(115, 93);
            this.CheckAmbos.Name = "CheckAmbos";
            this.CheckAmbos.Size = new System.Drawing.Size(58, 17);
            this.CheckAmbos.TabIndex = 2;
            this.CheckAmbos.Text = "Ambos";
            this.CheckAmbos.UseVisualStyleBackColor = true;
            this.CheckAmbos.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Historial";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // barra
            // 
            this.barra.Location = new System.Drawing.Point(326, 93);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(381, 23);
            this.barra.TabIndex = 4;
            // 
            // Historial
            // 
            this.Historial.Location = new System.Drawing.Point(326, 187);
            this.Historial.Multiline = true;
            this.Historial.Name = "Historial";
            this.Historial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Historial.Size = new System.Drawing.Size(398, 149);
            this.Historial.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fondo";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Gasto de:";
            // 
            // MontoEnposo
            // 
            this.MontoEnposo.Location = new System.Drawing.Point(326, 26);
            this.MontoEnposo.Name = "MontoEnposo";
            this.MontoEnposo.Size = new System.Drawing.Size(376, 20);
            this.MontoEnposo.TabIndex = 9;
            this.MontoEnposo.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(16, 324);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(224, 36);
            this.Guardar.TabIndex = 10;
            this.Guardar.Text = "Ejecutar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // MontoGastado
            // 
            this.MontoGastado.Location = new System.Drawing.Point(101, 12);
            this.MontoGastado.Name = "MontoGastado";
            this.MontoGastado.Size = new System.Drawing.Size(125, 20);
            this.MontoGastado.TabIndex = 12;
            this.MontoGastado.TextChanged += new System.EventHandler(this.MontoGastado_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Monto Total";
            // 
            // MontoAnto2
            // 
            this.MontoAnto2.Location = new System.Drawing.Point(129, 155);
            this.MontoAnto2.Name = "MontoAnto2";
            this.MontoAnto2.Size = new System.Drawing.Size(125, 20);
            this.MontoAnto2.TabIndex = 14;
            this.MontoAnto2.TextChanged += new System.EventHandler(this.MontoAnto2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Parte de Anto";
            // 
            // MontoNacho2
            // 
            this.MontoNacho2.Location = new System.Drawing.Point(129, 129);
            this.MontoNacho2.Name = "MontoNacho2";
            this.MontoNacho2.Size = new System.Drawing.Size(125, 20);
            this.MontoNacho2.TabIndex = 16;
            this.MontoNacho2.TextChanged += new System.EventHandler(this.MontoNacho2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Parte de Nacho";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Porcentaje de deuda Paga del: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(668, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(687, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "%";
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(524, 156);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(200, 20);
            this.fecha.TabIndex = 20;
            // 
            // radioCuenta
            // 
            this.radioCuenta.AutoSize = true;
            this.radioCuenta.Location = new System.Drawing.Point(48, 301);
            this.radioCuenta.Name = "radioCuenta";
            this.radioCuenta.Size = new System.Drawing.Size(156, 17);
            this.radioCuenta.TabIndex = 21;
            this.radioCuenta.TabStop = true;
            this.radioCuenta.Text = "Cerrar Cuenta fuera del App";
            this.radioCuenta.UseVisualStyleBackColor = true;
            this.radioCuenta.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioDeudaAgregar
            // 
            this.radioDeudaAgregar.AutoSize = true;
            this.radioDeudaAgregar.Location = new System.Drawing.Point(78, 200);
            this.radioDeudaAgregar.Name = "radioDeudaAgregar";
            this.radioDeudaAgregar.Size = new System.Drawing.Size(113, 17);
            this.radioDeudaAgregar.TabIndex = 22;
            this.radioDeudaAgregar.TabStop = true;
            this.radioDeudaAgregar.Text = "Quitar de la Zacoa";
            this.radioDeudaAgregar.UseVisualStyleBackColor = true;
            this.radioDeudaAgregar.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // RadioDeudaRestar
            // 
            this.RadioDeudaRestar.AutoSize = true;
            this.RadioDeudaRestar.Location = new System.Drawing.Point(78, 223);
            this.RadioDeudaRestar.Name = "RadioDeudaRestar";
            this.RadioDeudaRestar.Size = new System.Drawing.Size(114, 17);
            this.RadioDeudaRestar.TabIndex = 23;
            this.RadioDeudaRestar.TabStop = true;
            this.RadioDeudaRestar.Text = "Agregar a la zacoa";
            this.RadioDeudaRestar.UseVisualStyleBackColor = true;
            this.RadioDeudaRestar.CheckedChanged += new System.EventHandler(this.RadioDeudaRestar_CheckedChanged);
            // 
            // checkAnto
            // 
            this.checkAnto.AutoSize = true;
            this.checkAnto.Location = new System.Drawing.Point(78, 54);
            this.checkAnto.Name = "checkAnto";
            this.checkAnto.Size = new System.Drawing.Size(48, 17);
            this.checkAnto.TabIndex = 25;
            this.checkAnto.Text = "Anto";
            this.checkAnto.UseVisualStyleBackColor = true;
            this.checkAnto.CheckedChanged += new System.EventHandler(this.checkAnto_CheckedChanged);
            // 
            // Full2
            // 
            this.Full2.AutoSize = true;
            this.Full2.Location = new System.Drawing.Point(60, 261);
            this.Full2.Name = "Full2";
            this.Full2.Size = new System.Drawing.Size(42, 17);
            this.Full2.TabIndex = 26;
            this.Full2.Text = "Full";
            this.Full2.UseVisualStyleBackColor = true;
            this.Full2.CheckedChanged += new System.EventHandler(this.Full2_CheckedChanged);
            // 
            // checkHalf
            // 
            this.checkHalf.AutoSize = true;
            this.checkHalf.Location = new System.Drawing.Point(160, 261);
            this.checkHalf.Name = "checkHalf";
            this.checkHalf.Size = new System.Drawing.Size(45, 17);
            this.checkHalf.TabIndex = 27;
            this.checkHalf.Text = "Half";
            this.checkHalf.UseVisualStyleBackColor = true;
            this.checkHalf.CheckedChanged += new System.EventHandler(this.checkHalf_CheckedChanged);
            // 
            // VerHistorial
            // 
            this.VerHistorial.Location = new System.Drawing.Point(386, 155);
            this.VerHistorial.Name = "VerHistorial";
            this.VerHistorial.Size = new System.Drawing.Size(91, 23);
            this.VerHistorial.TabIndex = 28;
            this.VerHistorial.TabStop = false;
            this.VerHistorial.Text = "Ver  Completo";
            this.VerHistorial.UseVisualStyleBackColor = true;
            this.VerHistorial.Click += new System.EventHandler(this.button1_Click);
            // 
            // GenerarArchivo
            // 
            this.GenerarArchivo.Location = new System.Drawing.Point(538, 347);
            this.GenerarArchivo.Name = "GenerarArchivo";
            this.GenerarArchivo.Size = new System.Drawing.Size(164, 23);
            this.GenerarArchivo.TabIndex = 29;
            this.GenerarArchivo.Text = "Generar Archivo";
            this.GenerarArchivo.UseVisualStyleBackColor = true;
            this.GenerarArchivo.Click += new System.EventHandler(this.GenerarArchivo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 382);
            this.Controls.Add(this.GenerarArchivo);
            this.Controls.Add(this.VerHistorial);
            this.Controls.Add(this.checkHalf);
            this.Controls.Add(this.Full2);
            this.Controls.Add(this.checkAnto);
            this.Controls.Add(this.RadioDeudaRestar);
            this.Controls.Add(this.radioDeudaAgregar);
            this.Controls.Add(this.radioCuenta);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.MontoNacho2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MontoAnto2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MontoGastado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.MontoEnposo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Historial);
            this.Controls.Add(this.barra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckAmbos);
            this.Controls.Add(this.checkNacho);
            this.Name = "Form1";
            this.Text = "Zacoa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkNacho;
        private System.Windows.Forms.CheckBox CheckAmbos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar barra;
        private System.Windows.Forms.TextBox Historial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MontoEnposo;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.TextBox MontoGastado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MontoAnto2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MontoNacho2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.RadioButton radioCuenta;
        private System.Windows.Forms.RadioButton radioDeudaAgregar;
        private System.Windows.Forms.RadioButton RadioDeudaRestar;
        private System.Windows.Forms.CheckBox checkAnto;
        private System.Windows.Forms.CheckBox Full2;
        private System.Windows.Forms.CheckBox checkHalf;
        private System.Windows.Forms.Button VerHistorial;
        private System.Windows.Forms.Button GenerarArchivo;
    }
}

