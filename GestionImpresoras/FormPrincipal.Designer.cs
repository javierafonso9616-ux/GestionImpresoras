namespace GestionImpresoras
{
    partial class FormPrincipal
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
            this.materialCardBase = new MaterialSkin.Controls.MaterialCard();
            this.tabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialCardGridInventario = new MaterialSkin.Controls.MaterialCard();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.materialCardBotonesInventario = new MaterialSkin.Controls.MaterialCard();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBuscarInventario = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnExportarInventario = new MaterialSkin.Controls.MaterialButton();
            this.btnCargarInventario = new MaterialSkin.Controls.MaterialButton();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialCardGridPedidos = new MaterialSkin.Controls.MaterialCard();
            this.dgvPedidoWeb = new System.Windows.Forms.DataGridView();
            this.materialCardBotonesPedidos = new MaterialSkin.Controls.MaterialCard();
            this.txtBuscarSerie = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.btnExportarPedidos = new MaterialSkin.Controls.MaterialButton();
            this.btnRegistrarPedido = new MaterialSkin.Controls.MaterialButton();
            this.cmbGrupo = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.materialCardGridTOTALES = new MaterialSkin.Controls.MaterialCard();
            this.dgvTotales = new System.Windows.Forms.DataGridView();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialCardGridHISTORIAL = new MaterialSkin.Controls.MaterialCard();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialCardBotonesHistorialyPedidos = new MaterialSkin.Controls.MaterialCard();
            this.txtBuscarHistorial = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.btnExportarHistorial = new MaterialSkin.Controls.MaterialButton();
            this.btnRecargarHistorialYTotales = new MaterialSkin.Controls.MaterialButton();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialCardBase.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.materialCardGridInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.materialCardBotonesInventario.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.materialCardGridPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoWeb)).BeginInit();
            this.materialCardBotonesPedidos.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.materialCardGridTOTALES.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).BeginInit();
            this.materialCardGridHISTORIAL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.materialCardBotonesHistorialyPedidos.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCardBase
            // 
            this.materialCardBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardBase.Controls.Add(this.tabControl1);
            this.materialCardBase.Controls.Add(this.materialTabSelector1);
            this.materialCardBase.Depth = 0;
            this.materialCardBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCardBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardBase.Location = new System.Drawing.Point(3, 64);
            this.materialCardBase.Margin = new System.Windows.Forms.Padding(14);
            this.materialCardBase.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardBase.Name = "materialCardBase";
            this.materialCardBase.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardBase.Size = new System.Drawing.Size(1914, 1013);
            this.materialCardBase.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Depth = 0;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(14, 62);
            this.tabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1886, 937);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.materialCardGridInventario);
            this.tabPage1.Controls.Add(this.materialCardBotonesInventario);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1878, 911);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inventario";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // materialCardGridInventario
            // 
            this.materialCardGridInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardGridInventario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialCardGridInventario.Controls.Add(this.dgvInventario);
            this.materialCardGridInventario.Depth = 0;
            this.materialCardGridInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCardGridInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardGridInventario.Location = new System.Drawing.Point(3, 103);
            this.materialCardGridInventario.Margin = new System.Windows.Forms.Padding(14);
            this.materialCardGridInventario.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardGridInventario.Name = "materialCardGridInventario";
            this.materialCardGridInventario.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardGridInventario.Size = new System.Drawing.Size(1872, 805);
            this.materialCardGridInventario.TabIndex = 1;
            // 
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.Location = new System.Drawing.Point(14, 14);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(1842, 775);
            this.dgvInventario.TabIndex = 0;
            // 
            // materialCardBotonesInventario
            // 
            this.materialCardBotonesInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardBotonesInventario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialCardBotonesInventario.Controls.Add(this.materialLabel6);
            this.materialCardBotonesInventario.Controls.Add(this.txtBuscarInventario);
            this.materialCardBotonesInventario.Controls.Add(this.btnExportarInventario);
            this.materialCardBotonesInventario.Controls.Add(this.btnCargarInventario);
            this.materialCardBotonesInventario.Controls.Add(this.materialButton1);
            this.materialCardBotonesInventario.Depth = 0;
            this.materialCardBotonesInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialCardBotonesInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardBotonesInventario.Location = new System.Drawing.Point(3, 3);
            this.materialCardBotonesInventario.Margin = new System.Windows.Forms.Padding(14);
            this.materialCardBotonesInventario.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardBotonesInventario.Name = "materialCardBotonesInventario";
            this.materialCardBotonesInventario.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardBotonesInventario.Size = new System.Drawing.Size(1872, 100);
            this.materialCardBotonesInventario.TabIndex = 0;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(323, 20);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(138, 19);
            this.materialLabel6.TabIndex = 4;
            this.materialLabel6.Text = "Buscar por Nº Serie";
            // 
            // txtBuscarInventario
            // 
            this.txtBuscarInventario.AnimateReadOnly = false;
            this.txtBuscarInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBuscarInventario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarInventario.Depth = 0;
            this.txtBuscarInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBuscarInventario.HideSelection = true;
            this.txtBuscarInventario.LeadingIcon = global::GestionImpresoras.Properties.Resources.search_32dp_1F1F1F_FILL0_wght400_GRAD0_opsz40;
            this.txtBuscarInventario.Location = new System.Drawing.Point(326, 42);
            this.txtBuscarInventario.MaxLength = 32767;
            this.txtBuscarInventario.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBuscarInventario.Name = "txtBuscarInventario";
            this.txtBuscarInventario.PasswordChar = '\0';
            this.txtBuscarInventario.PrefixSuffixText = null;
            this.txtBuscarInventario.ReadOnly = false;
            this.txtBuscarInventario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBuscarInventario.SelectedText = "";
            this.txtBuscarInventario.SelectionLength = 0;
            this.txtBuscarInventario.SelectionStart = 0;
            this.txtBuscarInventario.ShortcutsEnabled = true;
            this.txtBuscarInventario.Size = new System.Drawing.Size(250, 36);
            this.txtBuscarInventario.TabIndex = 3;
            this.txtBuscarInventario.TabStop = false;
            this.txtBuscarInventario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarInventario.TrailingIcon = null;
            this.txtBuscarInventario.UseSystemPasswordChar = false;
            this.txtBuscarInventario.UseTallSize = false;
            this.txtBuscarInventario.TextChanged += new System.EventHandler(this.txtBuscarInventario_TextChanged);
            // 
            // btnExportarInventario
            // 
            this.btnExportarInventario.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExportarInventario.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExportarInventario.Depth = 0;
            this.btnExportarInventario.HighEmphasis = true;
            this.btnExportarInventario.Icon = null;
            this.btnExportarInventario.Location = new System.Drawing.Point(200, 31);
            this.btnExportarInventario.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExportarInventario.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExportarInventario.Name = "btnExportarInventario";
            this.btnExportarInventario.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnExportarInventario.Size = new System.Drawing.Size(95, 36);
            this.btnExportarInventario.TabIndex = 2;
            this.btnExportarInventario.Text = "Exportar";
            this.btnExportarInventario.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExportarInventario.UseAccentColor = false;
            this.btnExportarInventario.UseVisualStyleBackColor = true;
            this.btnExportarInventario.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnCargarInventario
            // 
            this.btnCargarInventario.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCargarInventario.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCargarInventario.Depth = 0;
            this.btnCargarInventario.HighEmphasis = true;
            this.btnCargarInventario.Icon = null;
            this.btnCargarInventario.Location = new System.Drawing.Point(96, 31);
            this.btnCargarInventario.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCargarInventario.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCargarInventario.Name = "btnCargarInventario";
            this.btnCargarInventario.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCargarInventario.Size = new System.Drawing.Size(96, 36);
            this.btnCargarInventario.TabIndex = 1;
            this.btnCargarInventario.Text = "Recargar";
            this.btnCargarInventario.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCargarInventario.UseAccentColor = false;
            this.btnCargarInventario.UseVisualStyleBackColor = true;
            this.btnCargarInventario.Click += new System.EventHandler(this.btnCargarInventario_Click);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(18, 31);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(70, 36);
            this.materialButton1.TabIndex = 0;
            this.materialButton1.Text = "Nuevo";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.materialCardGridPedidos);
            this.tabPage2.Controls.Add(this.materialCardBotonesPedidos);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1878, 911);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pedidos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialCardGridPedidos
            // 
            this.materialCardGridPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardGridPedidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialCardGridPedidos.Controls.Add(this.dgvPedidoWeb);
            this.materialCardGridPedidos.Depth = 0;
            this.materialCardGridPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCardGridPedidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardGridPedidos.Location = new System.Drawing.Point(3, 103);
            this.materialCardGridPedidos.Margin = new System.Windows.Forms.Padding(14);
            this.materialCardGridPedidos.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardGridPedidos.Name = "materialCardGridPedidos";
            this.materialCardGridPedidos.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardGridPedidos.Size = new System.Drawing.Size(1872, 805);
            this.materialCardGridPedidos.TabIndex = 1;
            // 
            // dgvPedidoWeb
            // 
            this.dgvPedidoWeb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidoWeb.Location = new System.Drawing.Point(14, 14);
            this.dgvPedidoWeb.Name = "dgvPedidoWeb";
            this.dgvPedidoWeb.Size = new System.Drawing.Size(1842, 775);
            this.dgvPedidoWeb.TabIndex = 0;
            // 
            // materialCardBotonesPedidos
            // 
            this.materialCardBotonesPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardBotonesPedidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialCardBotonesPedidos.Controls.Add(this.txtBuscarSerie);
            this.materialCardBotonesPedidos.Controls.Add(this.materialLabel2);
            this.materialCardBotonesPedidos.Controls.Add(this.btnExportarPedidos);
            this.materialCardBotonesPedidos.Controls.Add(this.btnRegistrarPedido);
            this.materialCardBotonesPedidos.Controls.Add(this.cmbGrupo);
            this.materialCardBotonesPedidos.Controls.Add(this.materialLabel1);
            this.materialCardBotonesPedidos.Depth = 0;
            this.materialCardBotonesPedidos.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialCardBotonesPedidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardBotonesPedidos.Location = new System.Drawing.Point(3, 3);
            this.materialCardBotonesPedidos.Margin = new System.Windows.Forms.Padding(14);
            this.materialCardBotonesPedidos.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardBotonesPedidos.Name = "materialCardBotonesPedidos";
            this.materialCardBotonesPedidos.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardBotonesPedidos.Size = new System.Drawing.Size(1872, 100);
            this.materialCardBotonesPedidos.TabIndex = 0;
            // 
            // txtBuscarSerie
            // 
            this.txtBuscarSerie.AnimateReadOnly = false;
            this.txtBuscarSerie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBuscarSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarSerie.Depth = 0;
            this.txtBuscarSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBuscarSerie.HideSelection = true;
            this.txtBuscarSerie.LeadingIcon = global::GestionImpresoras.Properties.Resources.search_32dp_1F1F1F_FILL0_wght400_GRAD0_opsz40;
            this.txtBuscarSerie.Location = new System.Drawing.Point(190, 47);
            this.txtBuscarSerie.MaxLength = 32767;
            this.txtBuscarSerie.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBuscarSerie.Name = "txtBuscarSerie";
            this.txtBuscarSerie.PasswordChar = '\0';
            this.txtBuscarSerie.PrefixSuffixText = null;
            this.txtBuscarSerie.ReadOnly = false;
            this.txtBuscarSerie.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBuscarSerie.SelectedText = "";
            this.txtBuscarSerie.SelectionLength = 0;
            this.txtBuscarSerie.SelectionStart = 0;
            this.txtBuscarSerie.ShortcutsEnabled = true;
            this.txtBuscarSerie.Size = new System.Drawing.Size(250, 36);
            this.txtBuscarSerie.TabIndex = 6;
            this.txtBuscarSerie.TabStop = false;
            this.txtBuscarSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarSerie.TrailingIcon = null;
            this.txtBuscarSerie.UseSystemPasswordChar = false;
            this.txtBuscarSerie.UseTallSize = false;
            this.txtBuscarSerie.TextChanged += new System.EventHandler(this.txtBuscarSerie_TextChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(179, 15);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(138, 19);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "Buscar por Nº Serie";
            // 
            // btnExportarPedidos
            // 
            this.btnExportarPedidos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExportarPedidos.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExportarPedidos.Depth = 0;
            this.btnExportarPedidos.HighEmphasis = true;
            this.btnExportarPedidos.Icon = null;
            this.btnExportarPedidos.Location = new System.Drawing.Point(661, 31);
            this.btnExportarPedidos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExportarPedidos.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExportarPedidos.Name = "btnExportarPedidos";
            this.btnExportarPedidos.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnExportarPedidos.Size = new System.Drawing.Size(95, 36);
            this.btnExportarPedidos.TabIndex = 4;
            this.btnExportarPedidos.Text = "Exportar";
            this.btnExportarPedidos.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExportarPedidos.UseAccentColor = false;
            this.btnExportarPedidos.UseVisualStyleBackColor = true;
            this.btnExportarPedidos.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRegistrarPedido
            // 
            this.btnRegistrarPedido.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegistrarPedido.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRegistrarPedido.Depth = 0;
            this.btnRegistrarPedido.HighEmphasis = true;
            this.btnRegistrarPedido.Icon = null;
            this.btnRegistrarPedido.Location = new System.Drawing.Point(491, 31);
            this.btnRegistrarPedido.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRegistrarPedido.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRegistrarPedido.Name = "btnRegistrarPedido";
            this.btnRegistrarPedido.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRegistrarPedido.Size = new System.Drawing.Size(154, 36);
            this.btnRegistrarPedido.TabIndex = 3;
            this.btnRegistrarPedido.Text = "Registrar Pedido";
            this.btnRegistrarPedido.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRegistrarPedido.UseAccentColor = false;
            this.btnRegistrarPedido.UseVisualStyleBackColor = true;
            this.btnRegistrarPedido.Click += new System.EventHandler(this.btnRegistrarPedido_Click);
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.AutoResize = false;
            this.cmbGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbGrupo.Depth = 0;
            this.cmbGrupo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbGrupo.DropDownHeight = 176;
            this.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupo.DropDownWidth = 121;
            this.cmbGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbGrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.IntegralHeight = false;
            this.cmbGrupo.ItemHeight = 29;
            this.cmbGrupo.Location = new System.Drawing.Point(24, 48);
            this.cmbGrupo.MaxDropDownItems = 6;
            this.cmbGrupo.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(121, 35);
            this.cmbGrupo.StartIndex = 0;
            this.cmbGrupo.TabIndex = 1;
            this.cmbGrupo.UseTallSize = false;
            this.cmbGrupo.SelectedIndexChanged += new System.EventHandler(this.cmbGrupo_SelectedIndexChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(16, 16);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(44, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Grupo";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.materialCardGridTOTALES);
            this.tabPage3.Controls.Add(this.materialCardGridHISTORIAL);
            this.tabPage3.Controls.Add(this.materialCardBotonesHistorialyPedidos);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1878, 911);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Historial y Totales";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // materialCardGridTOTALES
            // 
            this.materialCardGridTOTALES.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardGridTOTALES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialCardGridTOTALES.Controls.Add(this.dgvTotales);
            this.materialCardGridTOTALES.Controls.Add(this.materialLabel5);
            this.materialCardGridTOTALES.Depth = 0;
            this.materialCardGridTOTALES.Dock = System.Windows.Forms.DockStyle.Right;
            this.materialCardGridTOTALES.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardGridTOTALES.Location = new System.Drawing.Point(939, 100);
            this.materialCardGridTOTALES.Margin = new System.Windows.Forms.Padding(14);
            this.materialCardGridTOTALES.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardGridTOTALES.Name = "materialCardGridTOTALES";
            this.materialCardGridTOTALES.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardGridTOTALES.Size = new System.Drawing.Size(939, 811);
            this.materialCardGridTOTALES.TabIndex = 2;
            // 
            // dgvTotales
            // 
            this.dgvTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTotales.Location = new System.Drawing.Point(14, 33);
            this.dgvTotales.Name = "dgvTotales";
            this.dgvTotales.Size = new System.Drawing.Size(909, 762);
            this.dgvTotales.TabIndex = 2;
            this.dgvTotales.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTotales_KeyDown);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(14, 14);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(115, 19);
            this.materialLabel5.TabIndex = 1;
            this.materialLabel5.Text = "Pedidos Totales";
            // 
            // materialCardGridHISTORIAL
            // 
            this.materialCardGridHISTORIAL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardGridHISTORIAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialCardGridHISTORIAL.Controls.Add(this.dgvHistorial);
            this.materialCardGridHISTORIAL.Controls.Add(this.materialLabel4);
            this.materialCardGridHISTORIAL.Depth = 0;
            this.materialCardGridHISTORIAL.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialCardGridHISTORIAL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardGridHISTORIAL.Location = new System.Drawing.Point(0, 100);
            this.materialCardGridHISTORIAL.Margin = new System.Windows.Forms.Padding(14);
            this.materialCardGridHISTORIAL.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardGridHISTORIAL.Name = "materialCardGridHISTORIAL";
            this.materialCardGridHISTORIAL.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardGridHISTORIAL.Size = new System.Drawing.Size(936, 811);
            this.materialCardGridHISTORIAL.TabIndex = 1;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.Location = new System.Drawing.Point(14, 33);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(906, 762);
            this.dgvHistorial.TabIndex = 1;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(14, 14);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(64, 19);
            this.materialLabel4.TabIndex = 0;
            this.materialLabel4.Text = "Histórico";
            // 
            // materialCardBotonesHistorialyPedidos
            // 
            this.materialCardBotonesHistorialyPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCardBotonesHistorialyPedidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialCardBotonesHistorialyPedidos.Controls.Add(this.txtBuscarHistorial);
            this.materialCardBotonesHistorialyPedidos.Controls.Add(this.materialLabel3);
            this.materialCardBotonesHistorialyPedidos.Controls.Add(this.btnExportarHistorial);
            this.materialCardBotonesHistorialyPedidos.Controls.Add(this.btnRecargarHistorialYTotales);
            this.materialCardBotonesHistorialyPedidos.Depth = 0;
            this.materialCardBotonesHistorialyPedidos.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialCardBotonesHistorialyPedidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCardBotonesHistorialyPedidos.Location = new System.Drawing.Point(0, 0);
            this.materialCardBotonesHistorialyPedidos.Margin = new System.Windows.Forms.Padding(14);
            this.materialCardBotonesHistorialyPedidos.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCardBotonesHistorialyPedidos.Name = "materialCardBotonesHistorialyPedidos";
            this.materialCardBotonesHistorialyPedidos.Padding = new System.Windows.Forms.Padding(14);
            this.materialCardBotonesHistorialyPedidos.Size = new System.Drawing.Size(1878, 100);
            this.materialCardBotonesHistorialyPedidos.TabIndex = 0;
            // 
            // txtBuscarHistorial
            // 
            this.txtBuscarHistorial.AnimateReadOnly = false;
            this.txtBuscarHistorial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBuscarHistorial.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBuscarHistorial.Depth = 0;
            this.txtBuscarHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBuscarHistorial.HideSelection = true;
            this.txtBuscarHistorial.LeadingIcon = global::GestionImpresoras.Properties.Resources.search_32dp_1F1F1F_FILL0_wght400_GRAD0_opsz40;
            this.txtBuscarHistorial.Location = new System.Drawing.Point(251, 42);
            this.txtBuscarHistorial.MaxLength = 32767;
            this.txtBuscarHistorial.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBuscarHistorial.Name = "txtBuscarHistorial";
            this.txtBuscarHistorial.PasswordChar = '\0';
            this.txtBuscarHistorial.PrefixSuffixText = null;
            this.txtBuscarHistorial.ReadOnly = false;
            this.txtBuscarHistorial.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBuscarHistorial.SelectedText = "";
            this.txtBuscarHistorial.SelectionLength = 0;
            this.txtBuscarHistorial.SelectionStart = 0;
            this.txtBuscarHistorial.ShortcutsEnabled = true;
            this.txtBuscarHistorial.Size = new System.Drawing.Size(250, 36);
            this.txtBuscarHistorial.TabIndex = 3;
            this.txtBuscarHistorial.TabStop = false;
            this.txtBuscarHistorial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarHistorial.TrailingIcon = null;
            this.txtBuscarHistorial.UseSystemPasswordChar = false;
            this.txtBuscarHistorial.UseTallSize = false;
            this.txtBuscarHistorial.TextChanged += new System.EventHandler(this.txtBuscarHistorial_TextChanged);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(248, 20);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(138, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Buscar por Nº Serie";
            // 
            // btnExportarHistorial
            // 
            this.btnExportarHistorial.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExportarHistorial.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExportarHistorial.Depth = 0;
            this.btnExportarHistorial.HighEmphasis = true;
            this.btnExportarHistorial.Icon = null;
            this.btnExportarHistorial.Location = new System.Drawing.Point(122, 39);
            this.btnExportarHistorial.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExportarHistorial.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExportarHistorial.Name = "btnExportarHistorial";
            this.btnExportarHistorial.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnExportarHistorial.Size = new System.Drawing.Size(95, 36);
            this.btnExportarHistorial.TabIndex = 1;
            this.btnExportarHistorial.Text = "Exportar";
            this.btnExportarHistorial.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExportarHistorial.UseAccentColor = false;
            this.btnExportarHistorial.UseVisualStyleBackColor = true;
            this.btnExportarHistorial.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRecargarHistorialYTotales
            // 
            this.btnRecargarHistorialYTotales.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRecargarHistorialYTotales.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRecargarHistorialYTotales.Depth = 0;
            this.btnRecargarHistorialYTotales.HighEmphasis = true;
            this.btnRecargarHistorialYTotales.Icon = null;
            this.btnRecargarHistorialYTotales.Location = new System.Drawing.Point(18, 39);
            this.btnRecargarHistorialYTotales.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRecargarHistorialYTotales.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRecargarHistorialYTotales.Name = "btnRecargarHistorialYTotales";
            this.btnRecargarHistorialYTotales.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRecargarHistorialYTotales.Size = new System.Drawing.Size(96, 36);
            this.btnRecargarHistorialYTotales.TabIndex = 0;
            this.btnRecargarHistorialYTotales.Text = "Recargar";
            this.btnRecargarHistorialYTotales.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRecargarHistorialYTotales.UseAccentColor = false;
            this.btnRecargarHistorialYTotales.UseVisualStyleBackColor = true;
            this.btnRecargarHistorialYTotales.Click += new System.EventHandler(this.btnCargarHistorial_Click);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BackColor = System.Drawing.Color.White;
            this.materialTabSelector1.BaseTabControl = this.tabControl1;
            this.materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialTabSelector1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector1.Location = new System.Drawing.Point(14, 14);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1886, 48);
            this.materialTabSelector1.TabIndex = 0;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.materialCardBase);
            this.Name = "FormPrincipal";
            this.Text = "Gestión Impresoras";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.materialCardBase.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.materialCardGridInventario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.materialCardBotonesInventario.ResumeLayout(false);
            this.materialCardBotonesInventario.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.materialCardGridPedidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoWeb)).EndInit();
            this.materialCardBotonesPedidos.ResumeLayout(false);
            this.materialCardBotonesPedidos.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.materialCardGridTOTALES.ResumeLayout(false);
            this.materialCardGridTOTALES.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).EndInit();
            this.materialCardGridHISTORIAL.ResumeLayout(false);
            this.materialCardGridHISTORIAL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.materialCardBotonesHistorialyPedidos.ResumeLayout(false);
            this.materialCardBotonesHistorialyPedidos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCardBase;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialCard materialCardGridInventario;
        private MaterialSkin.Controls.MaterialCard materialCardBotonesInventario;
        private MaterialSkin.Controls.MaterialButton btnExportarInventario;
        private MaterialSkin.Controls.MaterialButton btnCargarInventario;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        
        private MaterialSkin.Controls.MaterialCard materialCardGridPedidos;
        private MaterialSkin.Controls.MaterialCard materialCardBotonesPedidos;
        private MaterialSkin.Controls.MaterialTextBox2 txtBuscarInventario;
        private MaterialSkin.Controls.MaterialComboBox cmbGrupo;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton btnExportarPedidos;
        private MaterialSkin.Controls.MaterialButton btnRegistrarPedido;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox2 txtBuscarSerie;
        private System.Windows.Forms.DataGridView dgvPedidoWeb;
        private System.Windows.Forms.TabPage tabPage3;
        private MaterialSkin.Controls.MaterialCard materialCardBotonesHistorialyPedidos;
        private MaterialSkin.Controls.MaterialTextBox2 txtBuscarHistorial;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton btnExportarHistorial;
        private MaterialSkin.Controls.MaterialButton btnRecargarHistorialYTotales;
        private MaterialSkin.Controls.MaterialCard materialCardGridHISTORIAL;
        private MaterialSkin.Controls.MaterialCard materialCardGridTOTALES;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.DataGridView dgvTotales;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridView dgvInventario;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
    }
}