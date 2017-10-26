namespace AurumRest
{
	partial class comandBar
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(comandBar));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.AgregarBtn = new System.Windows.Forms.ToolStripButton();
			this.EditarBtn = new System.Windows.Forms.ToolStripButton();
			this.BorrarBtn = new System.Windows.Forms.ToolStripButton();
			this.LupaBtn = new System.Windows.Forms.ToolStripButton();
			this.GuardarBtn = new System.Windows.Forms.ToolStripButton();
			this.Deshacer = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.BackColor = System.Drawing.Color.White;
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgregarBtn,
            this.EditarBtn,
            this.BorrarBtn,
            this.LupaBtn,
            this.GuardarBtn,
            this.Deshacer});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.toolStrip1.Size = new System.Drawing.Size(1187, 52);
			this.toolStrip1.TabIndex = 11;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// AgregarBtn
			// 
			this.AgregarBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AgregarBtn.ForeColor = System.Drawing.Color.Gray;
			this.AgregarBtn.Image = ((System.Drawing.Image)(resources.GetObject("AgregarBtn.Image")));
			this.AgregarBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.AgregarBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AgregarBtn.Name = "AgregarBtn";
			this.AgregarBtn.Size = new System.Drawing.Size(94, 49);
			this.AgregarBtn.Text = "Agregar";
			this.AgregarBtn.Click += new System.EventHandler(this.AgregarBtn_Click);
			// 
			// EditarBtn
			// 
			this.EditarBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EditarBtn.ForeColor = System.Drawing.Color.Gray;
			this.EditarBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditarBtn.Image")));
			this.EditarBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.EditarBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditarBtn.Name = "EditarBtn";
			this.EditarBtn.Size = new System.Drawing.Size(78, 49);
			this.EditarBtn.Text = "Editar";
			this.EditarBtn.Click += new System.EventHandler(this.EditarBtn_Click);
			// 
			// BorrarBtn
			// 
			this.BorrarBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BorrarBtn.ForeColor = System.Drawing.Color.Gray;
			this.BorrarBtn.Image = ((System.Drawing.Image)(resources.GetObject("BorrarBtn.Image")));
			this.BorrarBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.BorrarBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BorrarBtn.Name = "BorrarBtn";
			this.BorrarBtn.Size = new System.Drawing.Size(82, 49);
			this.BorrarBtn.Text = "Borrar";
			this.BorrarBtn.Click += new System.EventHandler(this.BorrarBtn_Click);
			// 
			// LupaBtn
			// 
			this.LupaBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.LupaBtn.Image = ((System.Drawing.Image)(resources.GetObject("LupaBtn.Image")));
			this.LupaBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.LupaBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LupaBtn.Name = "LupaBtn";
			this.LupaBtn.Size = new System.Drawing.Size(36, 49);
			this.LupaBtn.Text = "Buscar";
			this.LupaBtn.Click += new System.EventHandler(this.LupaBtn_Click);
			// 
			// GuardarBtn
			// 
			this.GuardarBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GuardarBtn.ForeColor = System.Drawing.Color.Gray;
			this.GuardarBtn.Image = ((System.Drawing.Image)(resources.GetObject("GuardarBtn.Image")));
			this.GuardarBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.GuardarBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.GuardarBtn.Name = "GuardarBtn";
			this.GuardarBtn.Size = new System.Drawing.Size(102, 49);
			this.GuardarBtn.Text = "Guardar";
			this.GuardarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.GuardarBtn.Visible = false;
			this.GuardarBtn.Click += new System.EventHandler(this.GuardarBtn_Click);
			// 
			// Deshacer
			// 
			this.Deshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.Deshacer.Image = ((System.Drawing.Image)(resources.GetObject("Deshacer.Image")));
			this.Deshacer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.Deshacer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Deshacer.Name = "Deshacer";
			this.Deshacer.Size = new System.Drawing.Size(28, 49);
			this.Deshacer.Text = "Deshacer";
			this.Deshacer.Visible = false;
			this.Deshacer.Click += new System.EventHandler(this.Deshacer_Click);
			// 
			// comandBar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.toolStrip1);
			this.Name = "comandBar";
			this.Size = new System.Drawing.Size(1187, 52);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton AgregarBtn;
		private System.Windows.Forms.ToolStripButton EditarBtn;
		private System.Windows.Forms.ToolStripButton BorrarBtn;
		private System.Windows.Forms.ToolStripButton LupaBtn;
		private System.Windows.Forms.ToolStripButton GuardarBtn;
		private System.Windows.Forms.ToolStripButton Deshacer;
	}
}
