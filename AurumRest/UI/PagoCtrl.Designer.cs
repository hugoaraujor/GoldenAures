namespace AurumRest
{
	partial class PagoCtrl
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

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textoBoxp19 = new AurumRest.TextoBoxp();
			this.button2 = new System.Windows.Forms.Button();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Efectivo",
            "Débito",
            "Crédito",
            "Cesta Ticket",
            "Cheque",
            "Alimentación"});
			this.comboBox1.Location = new System.Drawing.Point(9, 3);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(137, 38);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
			this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_Leave);
			this.comboBox1.Leave += new System.EventHandler(this.comboBox1_Leave);
			// 
			// textoBoxp19
			// 
			this.textoBoxp19.Entry = null;
			this.textoBoxp19.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp19.ForeColor = System.Drawing.Color.Black;
			this.textoBoxp19.IsCode = false;
			this.textoBoxp19.IsDecimal = true;
			this.textoBoxp19.IsInteger = false;
			this.textoBoxp19.IsPercent = false;
			this.textoBoxp19.Location = new System.Drawing.Point(455, 3);
			this.textoBoxp19.Name = "textoBoxp19";
			this.textoBoxp19.Size = new System.Drawing.Size(157, 39);
			this.textoBoxp19.TabIndex = 3;
			this.textoBoxp19.Text = "0,00";
			this.textoBoxp19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textoBoxp19.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textoBoxp19_KeyDown);
			this.textoBoxp19.Leave += new System.EventHandler(this.textoBoxp19_Leave);
			// 
			// button2
			// 
			this.button2.BackgroundImage = global::AurumRest.Properties.Resources.mas;
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(618, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(45, 35);
			this.button2.TabIndex = 0;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// comboBox3
			// 
			this.comboBox3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "Efectivo",
            "Débito",
            "Crédito",
            "Cesta Ticket",
            "Cheque",
            "Alimentación"});
			this.comboBox3.Location = new System.Drawing.Point(152, 3);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(297, 38);
			this.comboBox3.TabIndex = 2;
			this.comboBox3.Leave += new System.EventHandler(this.comboBox3_Leave);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(638, 44);
			this.label1.TabIndex = 21;
			// 
			// PagoCtrl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.textoBoxp19);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Name = "PagoCtrl";
			this.Size = new System.Drawing.Size(666, 44);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public System.Windows.Forms.ComboBox comboBox1;
		public TextoBoxp textoBoxp19;
		public System.Windows.Forms.Button button2;
		public System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label1;
	}
}
