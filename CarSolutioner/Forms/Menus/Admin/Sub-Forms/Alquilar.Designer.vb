<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAlquilar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlquilar))
        Me.dgvAlquilar = New System.Windows.Forms.DataGridView()
        Me.matricula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.modelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nrochasis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.anio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kilometraje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidaddepuertas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidaddepasajeros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidaddemaletas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aireacondicionado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.esmanual = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.deducible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idcategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idmodelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idsucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idmarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idtipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.categoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.mstMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAlquilar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.DataGridView6 = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFRfin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFAinicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFRInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbxSucLlegada = New System.Windows.Forms.ComboBox()
        CType(Me.dgvAlquilar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAlquilar
        '
        Me.dgvAlquilar.AllowUserToAddRows = False
        Me.dgvAlquilar.AllowUserToDeleteRows = False
        Me.dgvAlquilar.AllowUserToResizeColumns = False
        Me.dgvAlquilar.AllowUserToResizeRows = False
        Me.dgvAlquilar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvAlquilar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAlquilar.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvAlquilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlquilar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.matricula, Me.marca, Me.modelo, Me.nrochasis, Me.anio, Me.kilometraje, Me.cantidaddepuertas, Me.cantidaddepasajeros, Me.cantidaddemaletas, Me.aireacondicionado, Me.esmanual, Me.deducible, Me.idcategoria, Me.idmodelo, Me.idsucursal, Me.estado, Me.idmarca, Me.tipo, Me.idtipo, Me.categoria, Me.sucursal})
        Me.dgvAlquilar.Location = New System.Drawing.Point(12, 141)
        Me.dgvAlquilar.Name = "dgvAlquilar"
        Me.dgvAlquilar.ReadOnly = True
        Me.dgvAlquilar.RowHeadersVisible = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.dgvAlquilar.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAlquilar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAlquilar.Size = New System.Drawing.Size(1035, 476)
        Me.dgvAlquilar.TabIndex = 0
        '
        'matricula
        '
        Me.matricula.DataPropertyName = "matricula"
        Me.matricula.HeaderText = "Matrícula"
        Me.matricula.Name = "matricula"
        Me.matricula.ReadOnly = True
        '
        'marca
        '
        Me.marca.DataPropertyName = "marca"
        Me.marca.HeaderText = "Marca"
        Me.marca.Name = "marca"
        Me.marca.ReadOnly = True
        '
        'modelo
        '
        Me.modelo.DataPropertyName = "modelo"
        Me.modelo.HeaderText = "Modelo"
        Me.modelo.Name = "modelo"
        Me.modelo.ReadOnly = True
        '
        'nrochasis
        '
        Me.nrochasis.DataPropertyName = "nrochasis"
        Me.nrochasis.HeaderText = "nrochasis"
        Me.nrochasis.Name = "nrochasis"
        Me.nrochasis.ReadOnly = True
        Me.nrochasis.Visible = False
        '
        'anio
        '
        Me.anio.DataPropertyName = "anio"
        Me.anio.HeaderText = "Año"
        Me.anio.Name = "anio"
        Me.anio.ReadOnly = True
        '
        'kilometraje
        '
        Me.kilometraje.DataPropertyName = "kilometraje"
        Me.kilometraje.HeaderText = "Kilometraje"
        Me.kilometraje.Name = "kilometraje"
        Me.kilometraje.ReadOnly = True
        '
        'cantidaddepuertas
        '
        Me.cantidaddepuertas.DataPropertyName = "cantidaddepuertas"
        Me.cantidaddepuertas.HeaderText = "Puertas"
        Me.cantidaddepuertas.Name = "cantidaddepuertas"
        Me.cantidaddepuertas.ReadOnly = True
        '
        'cantidaddepasajeros
        '
        Me.cantidaddepasajeros.DataPropertyName = "cantidaddepasajeros"
        Me.cantidaddepasajeros.HeaderText = "Pasajeros"
        Me.cantidaddepasajeros.Name = "cantidaddepasajeros"
        Me.cantidaddepasajeros.ReadOnly = True
        '
        'cantidaddemaletas
        '
        Me.cantidaddemaletas.DataPropertyName = "cantidaddemaletas"
        Me.cantidaddemaletas.HeaderText = "Maletas"
        Me.cantidaddemaletas.Name = "cantidaddemaletas"
        Me.cantidaddemaletas.ReadOnly = True
        '
        'aireacondicionado
        '
        Me.aireacondicionado.DataPropertyName = "aireacondicionado"
        Me.aireacondicionado.HeaderText = "Aire"
        Me.aireacondicionado.Name = "aireacondicionado"
        Me.aireacondicionado.ReadOnly = True
        Me.aireacondicionado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.aireacondicionado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'esmanual
        '
        Me.esmanual.DataPropertyName = "esmanual"
        Me.esmanual.HeaderText = "Manual"
        Me.esmanual.Name = "esmanual"
        Me.esmanual.ReadOnly = True
        Me.esmanual.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.esmanual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'deducible
        '
        Me.deducible.DataPropertyName = "deducible"
        Me.deducible.HeaderText = "Deducible"
        Me.deducible.Name = "deducible"
        Me.deducible.ReadOnly = True
        '
        'idcategoria
        '
        Me.idcategoria.DataPropertyName = "idcategoria"
        Me.idcategoria.HeaderText = "idcategoria"
        Me.idcategoria.Name = "idcategoria"
        Me.idcategoria.ReadOnly = True
        Me.idcategoria.Visible = False
        '
        'idmodelo
        '
        Me.idmodelo.DataPropertyName = "idmodelo"
        Me.idmodelo.HeaderText = "idmodelo"
        Me.idmodelo.Name = "idmodelo"
        Me.idmodelo.ReadOnly = True
        Me.idmodelo.Visible = False
        '
        'idsucursal
        '
        Me.idsucursal.DataPropertyName = "idsucursal"
        Me.idsucursal.HeaderText = "idsucursal"
        Me.idsucursal.Name = "idsucursal"
        Me.idsucursal.ReadOnly = True
        Me.idsucursal.Visible = False
        '
        'estado
        '
        Me.estado.DataPropertyName = "estado"
        Me.estado.HeaderText = "estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Visible = False
        '
        'idmarca
        '
        Me.idmarca.DataPropertyName = "idmarca"
        Me.idmarca.HeaderText = "idmarca"
        Me.idmarca.Name = "idmarca"
        Me.idmarca.ReadOnly = True
        Me.idmarca.Visible = False
        '
        'tipo
        '
        Me.tipo.DataPropertyName = "tipo"
        Me.tipo.HeaderText = "Tipo"
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.Visible = False
        '
        'idtipo
        '
        Me.idtipo.DataPropertyName = "idtipo"
        Me.idtipo.HeaderText = "idtipo"
        Me.idtipo.Name = "idtipo"
        Me.idtipo.ReadOnly = True
        Me.idtipo.Visible = False
        '
        'categoria
        '
        Me.categoria.DataPropertyName = "categoria"
        Me.categoria.HeaderText = "Categoria"
        Me.categoria.Name = "categoria"
        Me.categoria.ReadOnly = True
        Me.categoria.Visible = False
        '
        'sucursal
        '
        Me.sucursal.DataPropertyName = "sucursal"
        Me.sucursal.HeaderText = "Sucursal"
        Me.sucursal.Name = "sucursal"
        Me.sucursal.ReadOnly = True
        Me.sucursal.Visible = False
        '
        'txtTipo
        '
        Me.txtTipo.Enabled = False
        Me.txtTipo.Location = New System.Drawing.Point(12, 61)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(100, 20)
        Me.txtTipo.TabIndex = 1
        '
        'txtCategoria
        '
        Me.txtCategoria.Enabled = False
        Me.txtCategoria.Location = New System.Drawing.Point(118, 59)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.Size = New System.Drawing.Size(100, 20)
        Me.txtCategoria.TabIndex = 2
        '
        'txtSucursal
        '
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Location = New System.Drawing.Point(224, 59)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(100, 20)
        Me.txtSucursal.TabIndex = 3
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(330, 59)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(187, 20)
        Me.txtCliente.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(8, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(236, 22)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Autos para esta reserva:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(12, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 17)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Tipo"
        '
        'mstMenuStrip
        '
        Me.mstMenuStrip.AutoSize = False
        Me.mstMenuStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.mstMenuStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mstMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.mstMenuStrip.Name = "mstMenuStrip"
        Me.mstMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.mstMenuStrip.Size = New System.Drawing.Size(1059, 30)
        Me.mstMenuStrip.TabIndex = 32
        Me.mstMenuStrip.Text = "MenuStrip1"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.Transparent
        Me.btnCerrar.Location = New System.Drawing.Point(1027, 0)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 30)
        Me.btnCerrar.TabIndex = 36
        Me.btnCerrar.Text = "✕"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(115, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Categoria"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(224, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 17)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Sucursal Actual"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(330, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 17)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Nombre Cliente"
        '
        'btnAlquilar
        '
        Me.btnAlquilar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAlquilar.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnAlquilar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnAlquilar.FlatAppearance.BorderSize = 0
        Me.btnAlquilar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnAlquilar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnAlquilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlquilar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlquilar.ForeColor = System.Drawing.Color.White
        Me.btnAlquilar.Location = New System.Drawing.Point(948, 104)
        Me.btnAlquilar.Name = "btnAlquilar"
        Me.btnAlquilar.Size = New System.Drawing.Size(99, 31)
        Me.btnAlquilar.TabIndex = 40
        Me.btnAlquilar.Text = "Alquilar"
        Me.btnAlquilar.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView1.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(712, 230)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(8, 8)
        Me.DataGridView2.TabIndex = 1
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(612, 147)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView3.TabIndex = 2
        '
        'DataGridView4
        '
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Location = New System.Drawing.Point(620, 154)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView4.TabIndex = 3
        '
        'DataGridView5
        '
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Location = New System.Drawing.Point(721, 206)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView5.TabIndex = 4
        '
        'DataGridView6
        '
        Me.DataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView6.Location = New System.Drawing.Point(507, 169)
        Me.DataGridView6.Name = "DataGridView6"
        Me.DataGridView6.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView6.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(12, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 17)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Fecha Reserva Inicio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(560, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 17)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Fecha Reserva Fin"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(224, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 17)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Fecha Alquiler Inicio"
        '
        'dtpFRfin
        '
        Me.dtpFRfin.CustomFormat = ""
        Me.dtpFRfin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFRfin.Location = New System.Drawing.Point(560, 104)
        Me.dtpFRfin.MaxDate = New Date(2200, 1, 30, 0, 0, 0, 0)
        Me.dtpFRfin.MinDate = New Date(1953, 12, 9, 0, 0, 0, 0)
        Me.dtpFRfin.Name = "dtpFRfin"
        Me.dtpFRfin.Size = New System.Drawing.Size(200, 20)
        Me.dtpFRfin.TabIndex = 53
        Me.dtpFRfin.Value = New Date(2000, 5, 3, 0, 0, 0, 0)
        '
        'dtpFAinicio
        '
        Me.dtpFAinicio.CustomFormat = ""
        Me.dtpFAinicio.Enabled = False
        Me.dtpFAinicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFAinicio.Location = New System.Drawing.Point(227, 103)
        Me.dtpFAinicio.MaxDate = New Date(2200, 1, 30, 0, 0, 0, 0)
        Me.dtpFAinicio.MinDate = New Date(1953, 12, 9, 0, 0, 0, 0)
        Me.dtpFAinicio.Name = "dtpFAinicio"
        Me.dtpFAinicio.Size = New System.Drawing.Size(200, 20)
        Me.dtpFAinicio.TabIndex = 52
        Me.dtpFAinicio.Value = New Date(2000, 5, 3, 0, 0, 0, 0)
        '
        'dtpFRInicio
        '
        Me.dtpFRInicio.CustomFormat = ""
        Me.dtpFRInicio.Enabled = False
        Me.dtpFRInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFRInicio.Location = New System.Drawing.Point(12, 104)
        Me.dtpFRInicio.MaxDate = New Date(2200, 1, 30, 0, 0, 0, 0)
        Me.dtpFRInicio.MinDate = New Date(1953, 12, 9, 0, 0, 0, 0)
        Me.dtpFRInicio.Name = "dtpFRInicio"
        Me.dtpFRInicio.Size = New System.Drawing.Size(200, 20)
        Me.dtpFRInicio.TabIndex = 58
        Me.dtpFRInicio.Value = New Date(2000, 5, 3, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(430, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 17)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Sucursal Llegada"
        '
        'cbxSucLlegada
        '
        Me.cbxSucLlegada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSucLlegada.FormattingEnabled = True
        Me.cbxSucLlegada.Items.AddRange(New Object() {"Flying Cars", "Uruguay Motors", "Rentafrank", "Punta Motors"})
        Me.cbxSucLlegada.Location = New System.Drawing.Point(433, 102)
        Me.cbxSucLlegada.Name = "cbxSucLlegada"
        Me.cbxSucLlegada.Size = New System.Drawing.Size(121, 21)
        Me.cbxSucLlegada.TabIndex = 56
        '
        'frmAlquilar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 629)
        Me.Controls.Add(Me.dtpFRInicio)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbxSucLlegada)
        Me.Controls.Add(Me.dtpFRfin)
        Me.Controls.Add(Me.dtpFAinicio)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnAlquilar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.mstMenuStrip)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtSucursal)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.dgvAlquilar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAlquilar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvAlquilar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvAlquilar As DataGridView
    Friend WithEvents txtTipo As TextBox
    Friend WithEvents txtCategoria As TextBox
    Friend WithEvents txtSucursal As TextBox
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents mstMenuStrip As MenuStrip
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnAlquilar As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents DataGridView5 As DataGridView
    Friend WithEvents DataGridView6 As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpFRfin As DateTimePicker
    Friend WithEvents dtpFAinicio As DateTimePicker
    Friend WithEvents dtpFRInicio As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents cbxSucLlegada As ComboBox
    Friend WithEvents matricula As DataGridViewTextBoxColumn
    Friend WithEvents marca As DataGridViewTextBoxColumn
    Friend WithEvents modelo As DataGridViewTextBoxColumn
    Friend WithEvents nrochasis As DataGridViewTextBoxColumn
    Friend WithEvents anio As DataGridViewTextBoxColumn
    Friend WithEvents kilometraje As DataGridViewTextBoxColumn
    Friend WithEvents cantidaddepuertas As DataGridViewTextBoxColumn
    Friend WithEvents cantidaddepasajeros As DataGridViewTextBoxColumn
    Friend WithEvents cantidaddemaletas As DataGridViewTextBoxColumn
    Friend WithEvents aireacondicionado As DataGridViewCheckBoxColumn
    Friend WithEvents esmanual As DataGridViewCheckBoxColumn
    Friend WithEvents deducible As DataGridViewTextBoxColumn
    Friend WithEvents idcategoria As DataGridViewTextBoxColumn
    Friend WithEvents idmodelo As DataGridViewTextBoxColumn
    Friend WithEvents idsucursal As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
    Friend WithEvents idmarca As DataGridViewTextBoxColumn
    Friend WithEvents tipo As DataGridViewTextBoxColumn
    Friend WithEvents idtipo As DataGridViewTextBoxColumn
    Friend WithEvents categoria As DataGridViewTextBoxColumn
    Friend WithEvents sucursal As DataGridViewTextBoxColumn
End Class
