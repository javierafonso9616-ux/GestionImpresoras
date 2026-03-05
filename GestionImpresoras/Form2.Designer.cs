namespace GestionImpresoras
{
    partial class Form2
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
            this.txtBuscarInventario = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialCardGridPedidos = new MaterialSkin.Controls.MaterialCard();
            this.dgvPedidoWeb = new System.Windows.Forms.DataGridView();
            this.materialCardBotonesPedidos = new MaterialSkin.Controls.MaterialCard();
            this.txtBuscarSerie = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton6 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton5 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton4 = new MaterialSkin.Controls.MaterialButton();
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
            this.materialButton8 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton7 = new MaterialSkin.Controls.MaterialButton();
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
            this.materialCardBotonesInventario.Controls.Add(this.txtBuscarInventario);
            this.materialCardBotonesInventario.Controls.Add(this.materialButton3);
            this.materialCardBotonesInventario.Controls.Add(this.materialButton2);
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
            // txtBuscarInventario
            // 
            this.txtBuscarInventario.AnimateReadOnly = false;
            this.txtBuscarInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBuscarInventario.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBuscarInventario.Depth = 0;
            this.txtBuscarInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBuscarInventario.HideSelection = true;
            this.txtBuscarInventario.LeadingIcon = global::GestionImpresoras.Properties.Resources.search_32dp_1F1F1F_FILL0_wght400_GRAD0_opsz40;
            this.txtBuscarInventario.Location = new System.Drawing.Point(340, 32);
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
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(200, 31);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(95, 36);
            this.materialButton3.TabIndex = 2;
            this.materialButton3.Text = "Exportar";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(96, 31);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(96, 36);
            this.materialButton2.TabIndex = 1;
            this.materialButton2.Text = "Recargar";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
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
            this.materialCardBotonesPedidos.Controls.Add(this.materialButton6);
            this.materialCardBotonesPedidos.Controls.Add(this.materialButton5);
            this.materialCardBotonesPedidos.Controls.Add(this.materialButton4);
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
            this.txtBuscarSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBuscarSerie.Depth = 0;
            this.txtBuscarSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBuscarSerie.HideSelection = true;
            this.txtBuscarSerie.LeadingIcon = global::GestionImpresoras.Properties.Resources.search_32dp_1F1F1F_FILL0_wght400_GRAD0_opsz40;
            this.txtBuscarSerie.Location = new System.Drawing.Point(570, 47);
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
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(567, 15);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(138, 19);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "Buscar por Nº Serie";
            // 
            // materialButton6
            // 
            this.materialButton6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton6.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton6.Depth = 0;
            this.materialButton6.HighEmphasis = true;
            this.materialButton6.Icon = null;
            this.materialButton6.Location = new System.Drawing.Point(443, 31);
            this.materialButton6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton6.Name = "materialButton6";
            this.materialButton6.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton6.Size = new System.Drawing.Size(95, 36);
            this.materialButton6.TabIndex = 4;
            this.materialButton6.Text = "Exportar";
            this.materialButton6.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton6.UseAccentColor = false;
            this.materialButton6.UseVisualStyleBackColor = true;
            // 
            // materialButton5
            // 
            this.materialButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton5.Depth = 0;
            this.materialButton5.HighEmphasis = true;
            this.materialButton5.Icon = null;
            this.materialButton5.Location = new System.Drawing.Point(281, 31);
            this.materialButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton5.Name = "materialButton5";
            this.materialButton5.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton5.Size = new System.Drawing.Size(154, 36);
            this.materialButton5.TabIndex = 3;
            this.materialButton5.Text = "Registrar Pedido";
            this.materialButton5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton5.UseAccentColor = false;
            this.materialButton5.UseVisualStyleBackColor = true;
            // 
            // materialButton4
            // 
            this.materialButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton4.Depth = 0;
            this.materialButton4.HighEmphasis = true;
            this.materialButton4.Icon = null;
            this.materialButton4.Location = new System.Drawing.Point(183, 31);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton4.Size = new System.Drawing.Size(90, 36);
            this.materialButton4.TabIndex = 2;
            this.materialButton4.Text = "Mostrar";
            this.materialButton4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton4.UseAccentColor = false;
            this.materialButton4.UseVisualStyleBackColor = true;
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.AutoResize = false;
            this.cmbGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbGrupo.Depth = 0;
            this.cmbGrupo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbGrupo.DropDownHeight = 118;
            this.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupo.DropDownWidth = 121;
            this.cmbGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbGrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.IntegralHeight = false;
            this.cmbGrupo.ItemHeight = 29;
            this.cmbGrupo.Location = new System.Drawing.Point(17, 48);
            this.cmbGrupo.MaxDropDownItems = 4;
            this.cmbGrupo.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(121, 35);
            this.cmbGrupo.StartIndex = 0;
            this.cmbGrupo.TabIndex = 1;
            this.cmbGrupo.UseTallSize = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(17, 16);
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
            this.materialCardBotonesHistorialyPedidos.Controls.Add(this.materialButton8);
            this.materialCardBotonesHistorialyPedidos.Controls.Add(this.materialButton7);
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
            // materialButton8
            // 
            this.materialButton8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton8.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton8.Depth = 0;
            this.materialButton8.HighEmphasis = true;
            this.materialButton8.Icon = null;
            this.materialButton8.Location = new System.Drawing.Point(122, 39);
            this.materialButton8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton8.Name = "materialButton8";
            this.materialButton8.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton8.Size = new System.Drawing.Size(95, 36);
            this.materialButton8.TabIndex = 1;
            this.materialButton8.Text = "Exportar";
            this.materialButton8.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton8.UseAccentColor = false;
            this.materialButton8.UseVisualStyleBackColor = true;
            // 
            // materialButton7
            // 
            this.materialButton7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton7.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton7.Depth = 0;
            this.materialButton7.HighEmphasis = true;
            this.materialButton7.Icon = null;
            this.materialButton7.Location = new System.Drawing.Point(18, 39);
            this.materialButton7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton7.Name = "materialButton7";
            this.materialButton7.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton7.Size = new System.Drawing.Size(96, 36);
            this.materialButton7.TabIndex = 0;
            this.materialButton7.Text = "Recargar";
            this.materialButton7.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton7.UseAccentColor = false;
            this.materialButton7.UseVisualStyleBackColor = true;
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
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.materialCardBase);
            this.Name = "Form2";
            this.Text = "Gestión Impresoras";
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
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.DataGridView dgvInventario;
        private MaterialSkin.Controls.MaterialCard materialCardGridPedidos;
        private MaterialSkin.Controls.MaterialCard materialCardBotonesPedidos;
        private MaterialSkin.Controls.MaterialTextBox2 txtBuscarInventario;
        private MaterialSkin.Controls.MaterialComboBox cmbGrupo;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton materialButton6;
        private MaterialSkin.Controls.MaterialButton materialButton5;
        private MaterialSkin.Controls.MaterialButton materialButton4;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox2 txtBuscarSerie;
        private System.Windows.Forms.DataGridView dgvPedidoWeb;
        private System.Windows.Forms.TabPage tabPage3;
        private MaterialSkin.Controls.MaterialCard materialCardBotonesHistorialyPedidos;
        private MaterialSkin.Controls.MaterialTextBox2 txtBuscarHistorial;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton materialButton8;
        private MaterialSkin.Controls.MaterialButton materialButton7;
        private MaterialSkin.Controls.MaterialCard materialCardGridHISTORIAL;
        private MaterialSkin.Controls.MaterialCard materialCardGridTOTALES;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.DataGridView dgvTotales;
        private System.Windows.Forms.DataGridView dgvHistorial;
    }
}