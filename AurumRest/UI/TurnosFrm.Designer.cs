namespace AurumRest
{
	partial class TurnosFrm
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textoBoxp2 = new System.Windows.Forms.MaskedTextBox();
			this.textoBoxp1 = new AurumRest.TextoBoxp();
			this.textoBoxp3 = new System.Windows.Forms.MaskedTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.errorBar1 = new AurumRest.ErrorBar();
			this.labelindex = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comandBar1 = new AurumRest.comandBar();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox1.ForeColor = System.Drawing.Color.Gray;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 25;
			this.listBox1.Location = new System.Drawing.Point(32, 55);
			this.listBox1.MultiColumn = true;
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(241, 204);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Gray;
			this.label3.Location = new System.Drawing.Point(39, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 33);
			this.label3.TabIndex = 12;
			this.label3.Text = "Turno";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Gray;
			this.label4.Location = new System.Drawing.Point(39, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 33);
			this.label4.TabIndex = 13;
			this.label4.Text = "Horas";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textoBoxp2
			// 
			this.textoBoxp2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp2.ForeColor = System.Drawing.Color.Gray;
			this.textoBoxp2.Location = new System.Drawing.Point(149, 101);
			this.textoBoxp2.Mask = "00:00";
			this.textoBoxp2.Name = "textoBoxp2";
			this.textoBoxp2.Size = new System.Drawing.Size(100, 43);
			this.textoBoxp2.TabIndex = 1;
			this.textoBoxp2.ValidatingType = typeof(System.DateTime);
			// 
			// textoBoxp1
			// 
			this.textoBoxp1.Entry = null;
			this.textoBoxp1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp1.ForeColor = System.Drawing.Color.Gray;
			this.textoBoxp1.IsCode = false;
			this.textoBoxp1.IsDecimal = false;
			this.textoBoxp1.IsInteger = false;
			this.textoBoxp1.IsPercent = false;
			this.textoBoxp1.Location = new System.Drawing.Point(150, 32);
			this.textoBoxp1.Name = "textoBoxp1";
			this.textoBoxp1.Size = new System.Drawing.Size(287, 39);
			this.textoBoxp1.TabIndex = 0;
			// 
			// textoBoxp3
			// 
			this.textoBoxp3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp3.ForeColor = System.Drawing.Color.Gray;
			this.textoBoxp3.Location = new System.Drawing.Point(279, 101);
			this.textoBoxp3.Mask = "00:00";
			this.textoBoxp3.Name = "textoBoxp3";
			this.textoBoxp3.Size = new System.Drawing.Size(100, 43);
			this.textoBoxp3.TabIndex = 2;
			this.textoBoxp3.ValidatingType = typeof(System.DateTime);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textoBoxp3);
			this.groupBox1.Controls.Add(this.textoBoxp1);
			this.groupBox1.Controls.Add(this.textoBoxp2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
			this.groupBox1.Location = new System.Drawing.Point(279, 91);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(458, 166);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// errorBar1
			// 
			this.errorBar1.Location = new System.Drawing.Point(0, 263);
			this.errorBar1.Mensaje = null;
			this.errorBar1.Name = "errorBar1";
			this.errorBar1.Size = new System.Drawing.Size(796, 50);
			this.errorBar1.Status = AurumRest.errorType.Normal;
			this.errorBar1.TabIndex = 22;
			this.errorBar1.Visible = false;
			// 
			// labelindex
			// 
			this.labelindex.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelindex.ForeColor = System.Drawing.Color.Gray;
			this.labelindex.Location = new System.Drawing.Point(664, 68);
			this.labelindex.Name = "labelindex";
			this.labelindex.Size = new System.Drawing.Size(45, 33);
			this.labelindex.TabIndex = 20;
			this.labelindex.Text = "0";
			this.labelindex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Gray;
			this.label1.Location = new System.Drawing.Point(602, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 33);
			this.label1.TabIndex = 23;
			this.label1.Text = "Rec.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comandBar1
			// 
			this.comandBar1.confirma = false;
			this.comandBar1.Location = new System.Drawing.Point(-6, -3);
			this.comandBar1.Name = "comandBar1";
			this.comandBar1.previo = AurumRest.RecordAction.Save;
			this.comandBar1.Size = new System.Drawing.Size(751, 52);
			this.comandBar1.Status = AurumRest.RecordAction.Save;
			this.comandBar1.TabIndex = 24;
			// 
			// TurnosFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(741, 325);
			this.Controls.Add(this.comandBar1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelindex);
			this.Controls.Add(this.errorBar1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.listBox1);
			this.MaximumSize = new System.Drawing.Size(757, 364);
			this.MinimumSize = new System.Drawing.Size(757, 364);
			this.Name = "TurnosFrm";
			this.Text = "Turnos";
			this.Load += new System.EventHandler(this.TurnosFrm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.MaskedTextBox textoBoxp2;
		private TextoBoxp textoBoxp1;
		private System.Windows.Forms.MaskedTextBox textoBoxp3;
		private System.Windows.Forms.GroupBox groupBox1;
		private ErrorBar errorBar1;
		private System.Windows.Forms.Label labelindex;
		private System.Windows.Forms.Label label1;
		private comandBar comandBar1;
	}
}