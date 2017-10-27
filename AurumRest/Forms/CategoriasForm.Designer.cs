namespace AurumRest
{
	partial class CategoriasForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriasForm));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.comandBar1 = new AurumRest.comandBar();
			this.errorBar1 = new AurumRest.ErrorBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelindex = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textoBoxp2 = new AurumRest.TextoBoxp();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.comandBar1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.errorBar1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.58824F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.41177F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(579, 343);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// comandBar1
			// 
			this.comandBar1.confirma = false;
			this.comandBar1.Location = new System.Drawing.Point(3, 3);
			this.comandBar1.Name = "comandBar1";
			this.comandBar1.previo = AurumRest.RecordAction.Save;
			this.comandBar1.Size = new System.Drawing.Size(573, 50);
			this.comandBar1.Status = AurumRest.RecordAction.Save;
			this.comandBar1.TabIndex = 1;
			this.comandBar1.Load += new System.EventHandler(this.comandBar1_Load);
			// 
			// errorBar1
			// 
			this.errorBar1.Location = new System.Drawing.Point(3, 275);
			this.errorBar1.Mensaje = null;
			this.errorBar1.Name = "errorBar1";
			this.errorBar1.Size = new System.Drawing.Size(573, 65);
			this.errorBar1.Status = AurumRest.errorType.Normal;
			this.errorBar1.TabIndex = 2;
			this.errorBar1.Visible = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.labelindex);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.checkBox2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.textoBoxp2);
			this.panel1.Enabled = false;
			this.panel1.Location = new System.Drawing.Point(3, 59);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(573, 210);
			this.panel1.TabIndex = 0;
			// 
			// labelindex
			// 
			this.labelindex.AutoSize = true;
			this.labelindex.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelindex.ForeColor = System.Drawing.Color.Gray;
			this.labelindex.Location = new System.Drawing.Point(457, 20);
			this.labelindex.Name = "labelindex";
			this.labelindex.Size = new System.Drawing.Size(19, 21);
			this.labelindex.TabIndex = 7;
			this.labelindex.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Gray;
			this.label1.Location = new System.Drawing.Point(392, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 21);
			this.label1.TabIndex = 6;
			this.label1.Text = "Record";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox2.ForeColor = System.Drawing.Color.Gray;
			this.checkBox2.Location = new System.Drawing.Point(114, 132);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(72, 25);
			this.checkBox2.TabIndex = 5;
			this.checkBox2.Text = "Activo";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Gray;
			this.label2.Location = new System.Drawing.Point(15, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 21);
			this.label2.TabIndex = 4;
			this.label2.Text = "Descripción";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox1.ForeColor = System.Drawing.Color.Gray;
			this.checkBox1.Location = new System.Drawing.Point(114, 103);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(61, 25);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "Peso";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// textoBoxp2
			// 
			this.textoBoxp2.Entry = "<Grupo o Categoria>";
			this.textoBoxp2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp2.ForeColor = System.Drawing.Color.LightGray;
			this.textoBoxp2.IsCode = false;
			this.textoBoxp2.IsDecimal = false;
			this.textoBoxp2.Location = new System.Drawing.Point(114, 56);
			this.textoBoxp2.MaxLength = 29;
			this.textoBoxp2.Name = "textoBoxp2";
			this.textoBoxp2.Size = new System.Drawing.Size(369, 29);
			this.textoBoxp2.TabIndex = 1;
			this.textoBoxp2.Text = "<Grupo o Categoria>";
			// 
			// CategoriasForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(579, 343);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CategoriasForm";
			this.Text = "Categorias";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private comandBar comandBar1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox1;
		private TextoBoxp textoBoxp2;
		private ErrorBar errorBar1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Label labelindex;
		private System.Windows.Forms.Label label1;
	}
}