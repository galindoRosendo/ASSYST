namespace ASSYST
{
    partial class MenuPrincipal
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
            this.layoutControl1 = new DevComponents.DotNetBar.Layout.LayoutControl();
            this.lblNombreEmpleado = new DevComponents.DotNetBar.LabelX();
            this.lblNombreEmpresa = new DevComponents.DotNetBar.LabelX();
            this.layoutGroup1 = new DevComponents.DotNetBar.Layout.LayoutGroup();
            this.layoutGroup2 = new DevComponents.DotNetBar.Layout.LayoutGroup();
            this.layoutControlItem1 = new DevComponents.DotNetBar.Layout.LayoutControlItem();
            this.layoutControlItem2 = new DevComponents.DotNetBar.Layout.LayoutControlItem();
            this.layoutControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.BackColor = System.Drawing.Color.White;
            this.layoutControl1.Controls.Add(this.lblNombreEmpleado);
            this.layoutControl1.Controls.Add(this.lblNombreEmpresa);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.ForeColor = System.Drawing.Color.Black;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            // 
            // 
            // 
            this.layoutControl1.RootGroup.Items.AddRange(new DevComponents.DotNetBar.Layout.LayoutItemBase[] {
            this.layoutGroup1,
            this.layoutGroup2,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControl1.Size = new System.Drawing.Size(1020, 667);
            this.layoutControl1.TabIndex = 7;
            // 
            // lblNombreEmpleado
            // 
            this.lblNombreEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNombreEmpleado.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblNombreEmpleado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombreEmpleado.ForeColor = System.Drawing.Color.Black;
            this.lblNombreEmpleado.Location = new System.Drawing.Point(4, 639);
            this.lblNombreEmpleado.Margin = new System.Windows.Forms.Padding(0);
            this.lblNombreEmpleado.Name = "lblNombreEmpleado";
            this.lblNombreEmpleado.Size = new System.Drawing.Size(502, 23);
            this.lblNombreEmpleado.TabIndex = 2;
            this.lblNombreEmpleado.Text = "Empleado";
            // 
            // lblNombreEmpresa
            // 
            this.lblNombreEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombreEmpresa.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblNombreEmpresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombreEmpresa.ForeColor = System.Drawing.Color.Black;
            this.lblNombreEmpresa.Location = new System.Drawing.Point(514, 639);
            this.lblNombreEmpresa.Margin = new System.Windows.Forms.Padding(0);
            this.lblNombreEmpresa.Name = "lblNombreEmpresa";
            this.lblNombreEmpresa.Size = new System.Drawing.Size(502, 23);
            this.lblNombreEmpresa.TabIndex = 3;
            this.lblNombreEmpresa.Text = "Empresa";
            this.lblNombreEmpresa.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // layoutGroup1
            // 
            this.layoutGroup1.Height = 10;
            this.layoutGroup1.HeightType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            this.layoutGroup1.MinSize = new System.Drawing.Size(120, 32);
            this.layoutGroup1.Name = "layoutGroup1";
            this.layoutGroup1.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top;
            this.layoutGroup1.Width = 100;
            this.layoutGroup1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // layoutGroup2
            // 
            this.layoutGroup2.Height = 90;
            this.layoutGroup2.HeightType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            this.layoutGroup2.MinSize = new System.Drawing.Size(120, 32);
            this.layoutGroup2.Name = "layoutGroup2";
            this.layoutGroup2.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top;
            this.layoutGroup2.Width = 100;
            this.layoutGroup2.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblNombreEmpleado;
            this.layoutControlItem1.Height = 31;
            this.layoutControlItem1.MinSize = new System.Drawing.Size(64, 18);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Width = 50;
            this.layoutControlItem1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lblNombreEmpresa;
            this.layoutControlItem2.Height = 31;
            this.layoutControlItem2.MinSize = new System.Drawing.Size(64, 18);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.TextAlignment = DevComponents.DotNetBar.Layout.eTextAlignment.Right;
            this.layoutControlItem2.Width = 50;
            this.layoutControlItem2.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 667);
            this.Controls.Add(this.layoutControl1);
            this.DoubleBuffered = true;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.layoutControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Layout.LayoutControl layoutControl1;
        private DevComponents.DotNetBar.LabelX lblNombreEmpleado;
        private DevComponents.DotNetBar.LabelX lblNombreEmpresa;
        private DevComponents.DotNetBar.Layout.LayoutGroup layoutGroup1;
        private DevComponents.DotNetBar.Layout.LayoutGroup layoutGroup2;
        private DevComponents.DotNetBar.Layout.LayoutControlItem layoutControlItem1;
        private DevComponents.DotNetBar.Layout.LayoutControlItem layoutControlItem2;
    }
}