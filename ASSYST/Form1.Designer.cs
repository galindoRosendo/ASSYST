namespace ASSYST
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblEmpleadoNombre = new DevComponents.DotNetBar.LabelX();
            this.symbolBox1 = new DevComponents.DotNetBar.Controls.SymbolBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dgvEmpresas = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnEntrar = new DevComponents.DotNetBar.ButtonX();
            this.btnNuevaEmpresa = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmpleadoNombre
            // 
            // 
            // 
            // 
            this.lblEmpleadoNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEmpleadoNombre.Location = new System.Drawing.Point(12, 523);
            this.lblEmpleadoNombre.Name = "lblEmpleadoNombre";
            this.lblEmpleadoNombre.Size = new System.Drawing.Size(162, 23);
            this.lblEmpleadoNombre.TabIndex = 5;
            this.lblEmpleadoNombre.Text = "Empleado";
            // 
            // symbolBox1
            // 
            // 
            // 
            // 
            this.symbolBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.symbolBox1.Location = new System.Drawing.Point(273, 114);
            this.symbolBox1.Name = "symbolBox1";
            this.symbolBox1.Size = new System.Drawing.Size(36, 23);
            this.symbolBox1.TabIndex = 8;
            this.symbolBox1.Text = "symbolBox1";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(333, 114);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(253, 23);
            this.labelX1.TabIndex = 7;
            this.labelX1.Text = "Bienvenido, Selecciona una empresa";
            // 
            // dgvEmpresas
            // 
            this.dgvEmpresas.AllowUserToAddRows = false;
            this.dgvEmpresas.AllowUserToDeleteRows = false;
            this.dgvEmpresas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpresas.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpresas.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmpresas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmpresas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvEmpresas.Location = new System.Drawing.Point(222, 143);
            this.dgvEmpresas.Name = "dgvEmpresas";
            this.dgvEmpresas.ReadOnly = true;
            this.dgvEmpresas.RowHeadersVisible = false;
            this.dgvEmpresas.Size = new System.Drawing.Size(398, 216);
            this.dgvEmpresas.TabIndex = 6;
            // 
            // btnEntrar
            // 
            this.btnEntrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEntrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEntrar.Location = new System.Drawing.Point(545, 401);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(75, 23);
            this.btnEntrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEntrar.TabIndex = 9;
            this.btnEntrar.Text = "Aceptar";
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnNuevaEmpresa
            // 
            this.btnNuevaEmpresa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNuevaEmpresa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNuevaEmpresa.Location = new System.Drawing.Point(445, 401);
            this.btnNuevaEmpresa.Name = "btnNuevaEmpresa";
            this.btnNuevaEmpresa.Size = new System.Drawing.Size(94, 23);
            this.btnNuevaEmpresa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNuevaEmpresa.TabIndex = 10;
            this.btnNuevaEmpresa.Text = "Nueva Empresa";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(878, 558);
            this.Controls.Add(this.btnNuevaEmpresa);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.dgvEmpresas);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.symbolBox1);
            this.Controls.Add(this.lblEmpleadoNombre);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASSYST";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblEmpleadoNombre;
        private DevComponents.DotNetBar.Controls.SymbolBox symbolBox1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvEmpresas;
        private DevComponents.DotNetBar.ButtonX btnEntrar;
        private DevComponents.DotNetBar.ButtonX btnNuevaEmpresa;


    }
}

