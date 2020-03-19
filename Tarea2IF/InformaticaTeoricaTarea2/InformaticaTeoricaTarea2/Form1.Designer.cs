namespace InformaticaTeoricaTarea2
{
    partial class FNC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FNC));
            this.labIngresaGramatica = new System.Windows.Forms.Label();
            this.txtGramatica = new System.Windows.Forms.TextBox();
            this.scrollGramatica = new System.Windows.Forms.VScrollBar();
            this.butGramatica = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.labNoAlcanzables = new System.Windows.Forms.Label();
            this.labNoTerminales = new System.Windows.Forms.Label();
            this.labAnulables = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoAlcanzables = new System.Windows.Forms.TextBox();
            this.txtNoTerminales = new System.Windows.Forms.TextBox();
            this.txtAnulables = new System.Windows.Forms.TextBox();
            this.cbUnitarias = new System.Windows.Forms.ComboBox();
            this.txtUnitarias = new System.Windows.Forms.TextBox();
            this.butLimpiar = new System.Windows.Forms.Button();
            this.labResultado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labIngresaGramatica
            // 
            this.labIngresaGramatica.AutoSize = true;
            this.labIngresaGramatica.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIngresaGramatica.Location = new System.Drawing.Point(12, 108);
            this.labIngresaGramatica.Name = "labIngresaGramatica";
            this.labIngresaGramatica.Size = new System.Drawing.Size(222, 27);
            this.labIngresaGramatica.TabIndex = 1;
            this.labIngresaGramatica.Text = "Ingresa una GIC";
            this.labIngresaGramatica.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtGramatica
            // 
            this.txtGramatica.Location = new System.Drawing.Point(12, 138);
            this.txtGramatica.Multiline = true;
            this.txtGramatica.Name = "txtGramatica";
            this.txtGramatica.Size = new System.Drawing.Size(310, 262);
            this.txtGramatica.TabIndex = 2;
            this.txtGramatica.TextChanged += new System.EventHandler(this.txtGramatica_TextChanged);
            // 
            // scrollGramatica
            // 
            this.scrollGramatica.Location = new System.Drawing.Point(305, 138);
            this.scrollGramatica.Name = "scrollGramatica";
            this.scrollGramatica.Size = new System.Drawing.Size(17, 262);
            this.scrollGramatica.TabIndex = 4;
            this.scrollGramatica.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // butGramatica
            // 
            this.butGramatica.Location = new System.Drawing.Point(81, 406);
            this.butGramatica.Name = "butGramatica";
            this.butGramatica.Size = new System.Drawing.Size(153, 32);
            this.butGramatica.TabIndex = 5;
            this.butGramatica.Text = "Generar Gramatica FNC";
            this.butGramatica.UseVisualStyleBackColor = true;
            this.butGramatica.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::InformaticaTeoricaTarea2.Properties.Resources.banner;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 92);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "banner";
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.Enabled = false;
            this.txtResultado.Location = new System.Drawing.Point(393, 138);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(358, 185);
            this.txtResultado.TabIndex = 6;
            this.txtResultado.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labNoAlcanzables
            // 
            this.labNoAlcanzables.AutoSize = true;
            this.labNoAlcanzables.Location = new System.Drawing.Point(390, 337);
            this.labNoAlcanzables.Name = "labNoAlcanzables";
            this.labNoAlcanzables.Size = new System.Drawing.Size(81, 13);
            this.labNoAlcanzables.TabIndex = 7;
            this.labNoAlcanzables.Text = "No Alcanzables";
            // 
            // labNoTerminales
            // 
            this.labNoTerminales.AutoSize = true;
            this.labNoTerminales.Location = new System.Drawing.Point(390, 366);
            this.labNoTerminales.Name = "labNoTerminales";
            this.labNoTerminales.Size = new System.Drawing.Size(75, 13);
            this.labNoTerminales.TabIndex = 8;
            this.labNoTerminales.Text = "No Terminales";
            // 
            // labAnulables
            // 
            this.labAnulables.AutoSize = true;
            this.labAnulables.Location = new System.Drawing.Point(390, 396);
            this.labAnulables.Name = "labAnulables";
            this.labAnulables.Size = new System.Drawing.Size(53, 13);
            this.labAnulables.TabIndex = 9;
            this.labAnulables.Text = "Anulables";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Unitarias";
            // 
            // txtNoAlcanzables
            // 
            this.txtNoAlcanzables.Location = new System.Drawing.Point(477, 334);
            this.txtNoAlcanzables.Name = "txtNoAlcanzables";
            this.txtNoAlcanzables.Size = new System.Drawing.Size(156, 20);
            this.txtNoAlcanzables.TabIndex = 11;
            this.txtNoAlcanzables.TextChanged += new System.EventHandler(this.txtNoAlcanzables_TextChanged);
            // 
            // txtNoTerminales
            // 
            this.txtNoTerminales.Location = new System.Drawing.Point(477, 366);
            this.txtNoTerminales.Name = "txtNoTerminales";
            this.txtNoTerminales.Size = new System.Drawing.Size(156, 20);
            this.txtNoTerminales.TabIndex = 12;
            this.txtNoTerminales.TextChanged += new System.EventHandler(this.txtNoTerminales_TextChanged);
            // 
            // txtAnulables
            // 
            this.txtAnulables.Location = new System.Drawing.Point(477, 396);
            this.txtAnulables.Name = "txtAnulables";
            this.txtAnulables.Size = new System.Drawing.Size(156, 20);
            this.txtAnulables.TabIndex = 13;
            this.txtAnulables.TextChanged += new System.EventHandler(this.txtAnulables_TextChanged);
            // 
            // cbUnitarias
            // 
            this.cbUnitarias.FormattingEnabled = true;
            this.cbUnitarias.Location = new System.Drawing.Point(477, 422);
            this.cbUnitarias.Name = "cbUnitarias";
            this.cbUnitarias.Size = new System.Drawing.Size(90, 21);
            this.cbUnitarias.TabIndex = 14;
            this.cbUnitarias.SelectedIndexChanged += new System.EventHandler(this.cbUnitarias_SelectedIndexChanged);
            // 
            // txtUnitarias
            // 
            this.txtUnitarias.Location = new System.Drawing.Point(583, 422);
            this.txtUnitarias.Name = "txtUnitarias";
            this.txtUnitarias.Size = new System.Drawing.Size(128, 20);
            this.txtUnitarias.TabIndex = 15;
            this.txtUnitarias.TextChanged += new System.EventHandler(this.txtUnitarias_TextChanged);
            // 
            // butLimpiar
            // 
            this.butLimpiar.Location = new System.Drawing.Point(657, 336);
            this.butLimpiar.Name = "butLimpiar";
            this.butLimpiar.Size = new System.Drawing.Size(116, 79);
            this.butLimpiar.TabIndex = 16;
            this.butLimpiar.Text = "Limpiar Todo";
            this.butLimpiar.UseVisualStyleBackColor = true;
            this.butLimpiar.Click += new System.EventHandler(this.butLimpiar_Click);
            // 
            // labResultado
            // 
            this.labResultado.AutoSize = true;
            this.labResultado.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labResultado.Location = new System.Drawing.Point(397, 108);
            this.labResultado.Name = "labResultado";
            this.labResultado.Size = new System.Drawing.Size(320, 27);
            this.labResultado.TabIndex = 17;
            this.labResultado.Text = "Gramatica FNC Generada";
            // 
            // FNC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 452);
            this.Controls.Add(this.labResultado);
            this.Controls.Add(this.butLimpiar);
            this.Controls.Add(this.txtUnitarias);
            this.Controls.Add(this.cbUnitarias);
            this.Controls.Add(this.txtAnulables);
            this.Controls.Add(this.txtNoTerminales);
            this.Controls.Add(this.txtNoAlcanzables);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labAnulables);
            this.Controls.Add(this.labNoTerminales);
            this.Controls.Add(this.labNoAlcanzables);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.butGramatica);
            this.Controls.Add(this.scrollGramatica);
            this.Controls.Add(this.txtGramatica);
            this.Controls.Add(this.labIngresaGramatica);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FNC";
            this.Text = "Forma Normal Chomsky FNC";
            this.Load += new System.EventHandler(this.FNC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labIngresaGramatica;
        private System.Windows.Forms.TextBox txtGramatica;
        private System.Windows.Forms.VScrollBar scrollGramatica;
        private System.Windows.Forms.Button butGramatica;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label labNoAlcanzables;
        private System.Windows.Forms.Label labNoTerminales;
        private System.Windows.Forms.Label labAnulables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoAlcanzables;
        private System.Windows.Forms.TextBox txtNoTerminales;
        private System.Windows.Forms.TextBox txtAnulables;
        private System.Windows.Forms.ComboBox cbUnitarias;
        private System.Windows.Forms.TextBox txtUnitarias;
        private System.Windows.Forms.Button butLimpiar;
        private System.Windows.Forms.Label labResultado;
    }
}

