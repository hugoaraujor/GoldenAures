namespace AurumRest
{
	partial class DescuentoDialog
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
			this.textoBoxp4 = new AurumRest.TextoBoxp();
			this.label2 = new System.Windows.Forms.Label();
			this.textoBoxp2 = new AurumRest.TextoBoxp();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textoBoxp4
			// 
			this.textoBoxp4.Enabled = false;
			this.textoBoxp4.Entry = null;
			this.textoBoxp4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp4.ForeColor = System.Drawing.Color.DimGray;
			this.textoBoxp4.IsCode = false;
			this.textoBoxp4.IsDecimal = false;
			this.textoBoxp4.IsInteger = true;
			this.textoBoxp4.IsPercent = false;
			this.textoBoxp4.Location = new System.Drawing.Point(189, 83);
			this.textoBoxp4.Name = "textoBoxp4";
			this.textoBoxp4.ReadOnly = true;
			this.textoBoxp4.Size = new System.Drawing.Size(207, 35);
			this.textoBoxp4.TabIndex = 1;
			this.textoBoxp4.Text = "0%";
			this.textoBoxp4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(32, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(215, 30);
			this.label2.TabIndex = 6;
			this.label2.Text = "Porcentaje Descuento";
			// 
			// textoBoxp2
			// 
			this.textoBoxp2.Entry = null;
			this.textoBoxp2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textoBoxp2.ForeColor = System.Drawing.Color.DimGray;
			this.textoBoxp2.IsCode = false;
			this.textoBoxp2.IsDecimal = true;
			this.textoBoxp2.IsInteger = false;
			this.textoBoxp2.IsPercent = false;
			this.textoBoxp2.Location = new System.Drawing.Point(295, 21);
			this.textoBoxp2.MaxLength = 5;
			this.textoBoxp2.Name = "textoBoxp2";
			this.textoBoxp2.Size = new System.Drawing.Size(101, 39);
			this.textoBoxp2.TabIndex = 0;
			this.textoBoxp2.Text = "0,00";
			this.textoBoxp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textoBoxp2.Leave += new System.EventHandler(this.textoBoxp2_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(32, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 30);
			this.label1.TabIndex = 8;
			this.label1.Text = "Descuento";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.DodgerBlue;
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.White;
			this.button2.Location = new System.Drawing.Point(97, 138);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(115, 35);
			this.button2.TabIndex = 2;
			this.button2.Text = "Aceptar";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(243, 138);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(115, 35);
			this.button1.TabIndex = 3;
			this.button1.Text = "Cancelar";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// DescuentoDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(433, 195);
			this.ControlBox = false;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textoBoxp4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textoBoxp2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(449, 234);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(449, 234);
			this.Name = "DescuentoDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cálculo de Descuento %";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.DescuentoDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TextoBoxp textoBoxp4;
		private System.Windows.Forms.Label label2;
		private TextoBoxp textoBoxp2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
	}
}