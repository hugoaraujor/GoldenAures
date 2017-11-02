namespace AurumRest
{
	partial class CierreZFrm
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
			this.components = new System.ComponentModel.Container();
			this.fechalabel = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.buttonCerrar = new System.Windows.Forms.Button();
			this.buttonrealizar = new System.Windows.Forms.Button();
			this.hastalabel = new System.Windows.Forms.Label();
			this.desdelabel = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.Seriallabel = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtxnrofacts = new System.Windows.Forms.TextBox();
			this.txttotal = new System.Windows.Forms.TextBox();
			this.txtxIva = new System.Windows.Forms.TextBox();
			this.txtNeto = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.errorBar1 = new AurumRest.ErrorBar();
			this.textoBoxp1 = new AurumRest.TextoBoxp();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.textoBoxp2 = new AurumRest.TextoBoxp();
			this.textoBoxp3 = new AurumRest.TextoBoxp();
			this.textoBoxp4 = new AurumRest.TextoBoxp();
			this.textoBoxp5 = new AurumRest.TextoBoxp();
			this.textoBoxp6 = new AurumRest.TextoBoxp();
			this.label2 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtApertura = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// fechalabel
			// 
			this.fechalabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fechalabel.ForeColor = System.Drawing.Color.RoyalBlue;
			this.fechalabel.Location = new System.Drawing.Point(176, 23);
			this.fechalabel.Name = "fechalabel";
			this.fechalabel.Size = new System.Drawing.Size(262, 25);
			this.fechalabel.TabIndex = 43;
			this.fechalabel.Text = "00/00/0000";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label12.Location = new System.Drawing.Point(29, 23);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(61, 25);
			this.label12.TabIndex = 42;
			this.label12.Text = "Fecha";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox2.ForeColor = System.Drawing.Color.Gray;
			this.checkBox2.Location = new System.Drawing.Point(751, 202);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(130, 21);
			this.checkBox2.TabIndex = 8;
			this.checkBox2.Text = "Informe Gerencial";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// buttonCerrar
			// 
			this.buttonCerrar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCerrar.Location = new System.Drawing.Point(751, 122);
			this.buttonCerrar.Name = "buttonCerrar";
			this.buttonCerrar.Size = new System.Drawing.Size(116, 56);
			this.buttonCerrar.TabIndex = 2;
			this.buttonCerrar.Text = "Cerrar";
			this.buttonCerrar.UseVisualStyleBackColor = true;
			// 
			// buttonrealizar
			// 
			this.buttonrealizar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonrealizar.Location = new System.Drawing.Point(751, 60);
			this.buttonrealizar.Name = "buttonrealizar";
			this.buttonrealizar.Size = new System.Drawing.Size(116, 56);
			this.buttonrealizar.TabIndex = 1;
			this.buttonrealizar.Text = "Realizar ";
			this.buttonrealizar.UseVisualStyleBackColor = true;
			this.buttonrealizar.Click += new System.EventHandler(this.buttonrealizar_Click);
			// 
			// hastalabel
			// 
			this.hastalabel.AutoSize = true;
			this.hastalabel.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hastalabel.ForeColor = System.Drawing.Color.Black;
			this.hastalabel.Location = new System.Drawing.Point(279, 281);
			this.hastalabel.Name = "hastalabel";
			this.hastalabel.Size = new System.Drawing.Size(73, 23);
			this.hastalabel.TabIndex = 38;
			this.hastalabel.Text = "0000000";
			// 
			// desdelabel
			// 
			this.desdelabel.AutoSize = true;
			this.desdelabel.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.desdelabel.ForeColor = System.Drawing.Color.Black;
			this.desdelabel.Location = new System.Drawing.Point(186, 281);
			this.desdelabel.Name = "desdelabel";
			this.desdelabel.Size = new System.Drawing.Size(73, 23);
			this.desdelabel.TabIndex = 37;
			this.desdelabel.Text = "0000000";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoEllipsis = true;
			this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox1.ForeColor = System.Drawing.Color.Gray;
			this.checkBox1.Location = new System.Drawing.Point(751, 229);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(130, 62);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Sin Cierre Fiscal (Reporte Automático)";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// Seriallabel
			// 
			this.Seriallabel.AutoSize = true;
			this.Seriallabel.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Seriallabel.ForeColor = System.Drawing.Color.Black;
			this.Seriallabel.Location = new System.Drawing.Point(186, 239);
			this.Seriallabel.Name = "Seriallabel";
			this.Seriallabel.Size = new System.Drawing.Size(87, 23);
			this.Seriallabel.TabIndex = 35;
			this.Seriallabel.Text = "Impresora";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.Black;
			this.label6.Location = new System.Drawing.Point(256, 281);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(17, 23);
			this.label6.TabIndex = 33;
			this.label6.Text = "-";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(31, 281);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(117, 23);
			this.label5.TabIndex = 32;
			this.label5.Text = "Facturas Nros.";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label4.Location = new System.Drawing.Point(31, 197);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 23);
			this.label4.TabIndex = 30;
			this.label4.Text = "# Facturas.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label3.Location = new System.Drawing.Point(31, 155);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(126, 23);
			this.label3.TabIndex = 28;
			this.label3.Text = "Total Facturado";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label1.Location = new System.Drawing.Point(31, 71);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 23);
			this.label1.TabIndex = 24;
			this.label1.Text = "Neto Facturas";
			// 
			// txtxnrofacts
			// 
			this.txtxnrofacts.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtxnrofacts.Location = new System.Drawing.Point(187, 193);
			this.txtxnrofacts.Name = "txtxnrofacts";
			this.txtxnrofacts.ReadOnly = true;
			this.txtxnrofacts.Size = new System.Drawing.Size(141, 30);
			this.txtxnrofacts.TabIndex = 7;
			this.txtxnrofacts.Text = "0";
			this.txtxnrofacts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txttotal
			// 
			this.txttotal.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txttotal.Location = new System.Drawing.Point(187, 151);
			this.txttotal.Name = "txttotal";
			this.txttotal.ReadOnly = true;
			this.txttotal.Size = new System.Drawing.Size(141, 30);
			this.txttotal.TabIndex = 6;
			this.txttotal.Text = "0";
			this.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtxIva
			// 
			this.txtxIva.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtxIva.Location = new System.Drawing.Point(187, 109);
			this.txtxIva.Name = "txtxIva";
			this.txtxIva.ReadOnly = true;
			this.txtxIva.Size = new System.Drawing.Size(141, 30);
			this.txtxIva.TabIndex = 5;
			this.txtxIva.Text = "0";
			this.txtxIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtNeto
			// 
			this.txtNeto.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNeto.Location = new System.Drawing.Point(187, 67);
			this.txtNeto.Name = "txtNeto";
			this.txtNeto.ReadOnly = true;
			this.txtNeto.Size = new System.Drawing.Size(141, 30);
			this.txtNeto.TabIndex = 4;
			this.txtNeto.Text = "0";
			this.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(186, 318);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(19, 23);
			this.label8.TabIndex = 49;
			this.label8.Text = "0";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.Black;
			this.label9.Location = new System.Drawing.Point(31, 318);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(108, 23);
			this.label9.TabIndex = 48;
			this.label9.Text = "Ultimo cierre";
			// 
			// errorBar1
			// 
			this.errorBar1.BackColor = System.Drawing.Color.White;
			this.errorBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.errorBar1.Location = new System.Drawing.Point(0, 409);
			this.errorBar1.Mensaje = null;
			this.errorBar1.Name = "errorBar1";
			this.errorBar1.Size = new System.Drawing.Size(909, 53);
			this.errorBar1.Status = AurumRest.errorType.Normal;
			this.errorBar1.TabIndex = 50;
			this.errorBar1.Visible = false;
			// 
			// textoBoxp1
			// 
			this.textoBoxp1.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.textoBoxp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textoBoxp1.Entry = null;
			this.textoBoxp1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp1.IsCode = false;
			this.textoBoxp1.IsDecimal = true;
			this.textoBoxp1.IsInteger = false;
			this.textoBoxp1.IsPercent = false;
			this.textoBoxp1.Location = new System.Drawing.Point(169, 24);
			this.textoBoxp1.Name = "textoBoxp1";
			this.textoBoxp1.Size = new System.Drawing.Size(160, 30);
			this.textoBoxp1.TabIndex = 6;
			this.textoBoxp1.Text = "0,00";
			this.textoBoxp1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textoBoxp1.Leave += new System.EventHandler(this.textoBoxp5_Leave);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.Black;
			this.label10.Location = new System.Drawing.Point(31, 239);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(87, 23);
			this.label10.TabIndex = 57;
			this.label10.Text = "Impresora";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label11.Location = new System.Drawing.Point(31, 113);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(89, 23);
			this.label11.TabIndex = 58;
			this.label11.Text = "Impuestos";
			// 
			// textoBoxp2
			// 
			this.textoBoxp2.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.textoBoxp2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textoBoxp2.Entry = null;
			this.textoBoxp2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp2.IsCode = false;
			this.textoBoxp2.IsDecimal = true;
			this.textoBoxp2.IsInteger = false;
			this.textoBoxp2.IsPercent = false;
			this.textoBoxp2.Location = new System.Drawing.Point(169, 66);
			this.textoBoxp2.Name = "textoBoxp2";
			this.textoBoxp2.Size = new System.Drawing.Size(160, 30);
			this.textoBoxp2.TabIndex = 7;
			this.textoBoxp2.Text = "0,00";
			this.textoBoxp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textoBoxp2.Leave += new System.EventHandler(this.textoBoxp5_Leave);
			// 
			// textoBoxp3
			// 
			this.textoBoxp3.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.textoBoxp3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textoBoxp3.Entry = null;
			this.textoBoxp3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp3.IsCode = false;
			this.textoBoxp3.IsDecimal = true;
			this.textoBoxp3.IsInteger = false;
			this.textoBoxp3.IsPercent = false;
			this.textoBoxp3.Location = new System.Drawing.Point(169, 150);
			this.textoBoxp3.Name = "textoBoxp3";
			this.textoBoxp3.Size = new System.Drawing.Size(160, 30);
			this.textoBoxp3.TabIndex = 9;
			this.textoBoxp3.Text = "0,00";
			this.textoBoxp3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textoBoxp3.Leave += new System.EventHandler(this.textoBoxp5_Leave);
			// 
			// textoBoxp4
			// 
			this.textoBoxp4.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.textoBoxp4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textoBoxp4.Entry = null;
			this.textoBoxp4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp4.IsCode = false;
			this.textoBoxp4.IsDecimal = true;
			this.textoBoxp4.IsInteger = false;
			this.textoBoxp4.IsPercent = false;
			this.textoBoxp4.Location = new System.Drawing.Point(169, 108);
			this.textoBoxp4.Name = "textoBoxp4";
			this.textoBoxp4.Size = new System.Drawing.Size(160, 30);
			this.textoBoxp4.TabIndex = 8;
			this.textoBoxp4.Text = "0,00";
			this.textoBoxp4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textoBoxp4.Leave += new System.EventHandler(this.textoBoxp5_Leave);
			// 
			// textoBoxp5
			// 
			this.textoBoxp5.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.textoBoxp5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textoBoxp5.Entry = null;
			this.textoBoxp5.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp5.IsCode = false;
			this.textoBoxp5.IsDecimal = true;
			this.textoBoxp5.IsInteger = false;
			this.textoBoxp5.IsPercent = false;
			this.textoBoxp5.Location = new System.Drawing.Point(169, 234);
			this.textoBoxp5.Name = "textoBoxp5";
			this.textoBoxp5.Size = new System.Drawing.Size(160, 30);
			this.textoBoxp5.TabIndex = 11;
			this.textoBoxp5.Text = "0,00";
			this.textoBoxp5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textoBoxp5.Leave += new System.EventHandler(this.textoBoxp5_Leave);
			// 
			// textoBoxp6
			// 
			this.textoBoxp6.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.textoBoxp6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textoBoxp6.Entry = null;
			this.textoBoxp6.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp6.IsCode = false;
			this.textoBoxp6.IsDecimal = true;
			this.textoBoxp6.IsInteger = false;
			this.textoBoxp6.IsPercent = false;
			this.textoBoxp6.Location = new System.Drawing.Point(169, 192);
			this.textoBoxp6.Name = "textoBoxp6";
			this.textoBoxp6.Size = new System.Drawing.Size(160, 30);
			this.textoBoxp6.TabIndex = 10;
			this.textoBoxp6.Text = "0,00";
			this.textoBoxp6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textoBoxp6.Leave += new System.EventHandler(this.textoBoxp5_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label2.Location = new System.Drawing.Point(18, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 23);
			this.label2.TabIndex = 67;
			this.label2.Text = "Efectivo";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label13.Location = new System.Drawing.Point(18, 70);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(61, 23);
			this.label13.TabIndex = 68;
			this.label13.Text = "Débito";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label14.Location = new System.Drawing.Point(18, 112);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(66, 23);
			this.label14.TabIndex = 69;
			this.label14.Text = "Crédito";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label15.Location = new System.Drawing.Point(18, 154);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(108, 23);
			this.label15.TabIndex = 70;
			this.label15.Text = "Cesta Tickets";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label16.Location = new System.Drawing.Point(18, 196);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(74, 23);
			this.label16.TabIndex = 71;
			this.label16.Text = "Cheque ";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label17.Location = new System.Drawing.Point(18, 238);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(115, 23);
			this.label17.TabIndex = 72;
			this.label17.Text = "Alimentación ";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label18.Location = new System.Drawing.Point(18, 287);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(101, 23);
			this.label18.TabIndex = 73;
			this.label18.Text = "Total Pagos";
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label19.Location = new System.Drawing.Point(165, 287);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(164, 23);
			this.label19.TabIndex = 74;
			this.label19.Text = "0,00";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textoBoxp5);
			this.groupBox1.Controls.Add(this.textoBoxp6);
			this.groupBox1.Controls.Add(this.textoBoxp3);
			this.groupBox1.Controls.Add(this.textoBoxp4);
			this.groupBox1.Controls.Add(this.textoBoxp2);
			this.groupBox1.Controls.Add(this.textoBoxp1);
			this.groupBox1.Location = new System.Drawing.Point(12, 51);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(356, 357);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.txtApertura);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.txtxnrofacts);
			this.groupBox2.Controls.Add(this.txttotal);
			this.groupBox2.Controls.Add(this.txtxIva);
			this.groupBox2.Controls.Add(this.txtNeto);
			this.groupBox2.Controls.Add(this.hastalabel);
			this.groupBox2.Controls.Add(this.desdelabel);
			this.groupBox2.Controls.Add(this.Seriallabel);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(374, 51);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(359, 357);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			// 
			// txtApertura
			// 
			this.txtApertura.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtApertura.Location = new System.Drawing.Point(187, 25);
			this.txtApertura.Name = "txtApertura";
			this.txtApertura.ReadOnly = true;
			this.txtApertura.Size = new System.Drawing.Size(141, 30);
			this.txtApertura.TabIndex = 59;
			this.txtApertura.Text = "0";
			this.txtApertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label7.Location = new System.Drawing.Point(31, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(77, 23);
			this.label7.TabIndex = 60;
			this.label7.Text = "Apertura";
			// 
			// CierreZFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(909, 462);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.errorBar1);
			this.Controls.Add(this.fechalabel);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.buttonCerrar);
			this.Controls.Add(this.buttonrealizar);
			this.Controls.Add(this.checkBox1);
			this.Name = "CierreZFrm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cierre";
			this.Load += new System.EventHandler(this.CierreZFrm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label fechalabel;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Button buttonCerrar;
		private System.Windows.Forms.Button buttonrealizar;
		private System.Windows.Forms.Label hastalabel;
		private System.Windows.Forms.Label desdelabel;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label Seriallabel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtxnrofacts;
		private System.Windows.Forms.TextBox txttotal;
		private System.Windows.Forms.TextBox txtxIva;
		private System.Windows.Forms.TextBox txtNeto;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Timer timer1;
		private ErrorBar errorBar1;
		private TextoBoxp textoBoxp1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private TextoBoxp textoBoxp2;
		private TextoBoxp textoBoxp3;
		private TextoBoxp textoBoxp4;
		private TextoBoxp textoBoxp5;
		private TextoBoxp textoBoxp6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtApertura;
	}
}