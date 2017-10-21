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
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cbxSucLlegada = New System.Windows.Forms.ComboBox()
        Me.gbxReserva = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbxFecNacFCliente = New System.Windows.Forms.GroupBox()
        Me.btnDescuentoCliente = New System.Windows.Forms.Button()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.txtCostoTotalEsperado = New System.Windows.Forms.TextBox()
        Me.lblCostoYRecargo = New System.Windows.Forms.Label()
        Me.lblCostoTotal = New System.Windows.Forms.Label()
        Me.txtCostoEsperado = New System.Windows.Forms.TextBox()
        Me.txtCantidadDias = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDescuentoReserva = New System.Windows.Forms.Button()
        Me.lblDescuentoReserva = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblAdvertencia = New System.Windows.Forms.Label()
        Me.cbxKilometraje = New System.Windows.Forms.ComboBox()
        Me.numDescuentoReserva = New System.Windows.Forms.NumericUpDown()
        Me.numDescuentoCliente = New System.Windows.Forms.NumericUpDown()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtDeducible = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCategoriaAntigua = New System.Windows.Forms.TextBox()
        Me.lblCategoriaAntigua = New System.Windows.Forms.Label()
        Me.chboxCobrarEstaCat = New System.Windows.Forms.CheckBox()
        CType(Me.dgvAlquilar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxReserva.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbxFecNacFCliente.SuspendLayout()
        CType(Me.numDescuentoReserva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDescuentoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.dgvAlquilar.Location = New System.Drawing.Point(12, 266)
        Me.dgvAlquilar.Name = "dgvAlquilar"
        Me.dgvAlquilar.ReadOnly = True
        Me.dgvAlquilar.RowHeadersVisible = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.dgvAlquilar.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAlquilar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAlquilar.Size = New System.Drawing.Size(1111, 476)
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
        Me.txtTipo.Location = New System.Drawing.Point(17, 173)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(131, 20)
        Me.txtTipo.TabIndex = 1
        '
        'txtCategoria
        '
        Me.txtCategoria.Enabled = False
        Me.txtCategoria.Location = New System.Drawing.Point(17, 220)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.Size = New System.Drawing.Size(131, 20)
        Me.txtCategoria.TabIndex = 2
        '
        'txtSucursal
        '
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSucursal.Location = New System.Drawing.Point(23, 53)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(131, 20)
        Me.txtSucursal.TabIndex = 3
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Century Gothic", 12.25!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(6, 4)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(224, 21)
        Me.lblTitulo.TabIndex = 25
        Me.lblTitulo.Text = "Autos para la reserva de:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(14, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 17)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Tipo de Vehiculo"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.Color.Transparent
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.Transparent
        Me.btnCerrar.Location = New System.Drawing.Point(1098, 1)
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
        Me.Label1.Location = New System.Drawing.Point(14, 199)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 17)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Categoria Vehiculo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(23, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 17)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Sucursal Actual"
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
        Me.btnAlquilar.Location = New System.Drawing.Point(986, 229)
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
        Me.Label4.Location = New System.Drawing.Point(14, 33)
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
        Me.Label5.Location = New System.Drawing.Point(180, 33)
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
        Me.Label7.Location = New System.Drawing.Point(14, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 17)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Fecha Alquiler Inicio"
        '
        'dtpFRfin
        '
        Me.dtpFRfin.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFRfin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpFRfin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFRfin.Location = New System.Drawing.Point(183, 53)
        Me.dtpFRfin.MaxDate = New Date(2200, 1, 30, 0, 0, 0, 0)

        Me.dtpFRfin.Value = New Date(2017, 10, 20, 0, 0, 0, 0)
        Me.dtpFRfin.Name = "dtpFRfin"
        Me.dtpFRfin.Size = New System.Drawing.Size(131, 20)
        Me.dtpFRfin.TabIndex = 53
        Me.dtpFRfin.Value = New Date(2017, 10, 20, 21, 49, 7, 0)
        '
        'dtpFAinicio
        '
        Me.dtpFAinicio.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFAinicio.Enabled = False
        Me.dtpFAinicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpFAinicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFAinicio.Location = New System.Drawing.Point(17, 53)
        Me.dtpFAinicio.MaxDate = New Date(2200, 1, 30, 0, 0, 0, 0)
        Me.dtpFAinicio.MinDate = New Date(1953, 12, 9, 0, 0, 0, 0)
        Me.dtpFAinicio.Name = "dtpFAinicio"
        Me.dtpFAinicio.Size = New System.Drawing.Size(131, 20)
        Me.dtpFAinicio.TabIndex = 52
        Me.dtpFAinicio.Value = New Date(2017, 10, 20, 21, 49, 15, 0)
        '
        'dtpFRInicio
        '
        Me.dtpFRInicio.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFRInicio.Enabled = False
        Me.dtpFRInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpFRInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFRInicio.Location = New System.Drawing.Point(17, 53)
        Me.dtpFRInicio.MaxDate = New Date(2200, 1, 30, 0, 0, 0, 0)
        Me.dtpFRInicio.MinDate = New Date(1953, 12, 9, 0, 0, 0, 0)
        Me.dtpFRInicio.Name = "dtpFRInicio"
        Me.dtpFRInicio.Size = New System.Drawing.Size(131, 20)
        Me.dtpFRInicio.TabIndex = 58
        Me.dtpFRInicio.Value = New Date(2017, 10, 20, 21, 49, 11, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(170, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 17)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Sucursal Llegada"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(172, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 17)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Fecha Alquiler Fin"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TextBox1.Location = New System.Drawing.Point(175, 53)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(131, 20)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "Se establece al finalizar"
        '
        'cbxSucLlegada
        '
        Me.cbxSucLlegada.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxSucLlegada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSucLlegada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbxSucLlegada.FormattingEnabled = True
        Me.cbxSucLlegada.Items.AddRange(New Object() {"Flying Cars", "Uruguay Motors", "Rentafrank", "Punta Motors"})
        Me.cbxSucLlegada.Location = New System.Drawing.Point(173, 52)
        Me.cbxSucLlegada.Name = "cbxSucLlegada"
        Me.cbxSucLlegada.Size = New System.Drawing.Size(131, 21)
        Me.cbxSucLlegada.TabIndex = 56
        '
        'gbxReserva
        '
        Me.gbxReserva.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gbxReserva.Controls.Add(Me.Label5)
        Me.gbxReserva.Controls.Add(Me.dtpFRInicio)
        Me.gbxReserva.Controls.Add(Me.Label4)
        Me.gbxReserva.Controls.Add(Me.dtpFRfin)
        Me.gbxReserva.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.gbxReserva.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.gbxReserva.Location = New System.Drawing.Point(12, 44)
        Me.gbxReserva.Name = "gbxReserva"
        Me.gbxReserva.Size = New System.Drawing.Size(330, 98)
        Me.gbxReserva.TabIndex = 59
        Me.gbxReserva.TabStop = False
        Me.gbxReserva.Text = "Reserva"
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.dtpFAinicio)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(406, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 98)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Alquiler"
        '
        'gbxFecNacFCliente
        '
        Me.gbxFecNacFCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gbxFecNacFCliente.Controls.Add(Me.Label2)
        Me.gbxFecNacFCliente.Controls.Add(Me.cbxSucLlegada)
        Me.gbxFecNacFCliente.Controls.Add(Me.txtSucursal)
        Me.gbxFecNacFCliente.Controls.Add(Me.Label8)
        Me.gbxFecNacFCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.gbxFecNacFCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.gbxFecNacFCliente.Location = New System.Drawing.Point(793, 44)
        Me.gbxFecNacFCliente.Name = "gbxFecNacFCliente"
        Me.gbxFecNacFCliente.Size = New System.Drawing.Size(330, 98)
        Me.gbxFecNacFCliente.TabIndex = 62
        Me.gbxFecNacFCliente.TabStop = False
        Me.gbxFecNacFCliente.Text = "Sucursales"
        '
        'btnDescuentoCliente
        '
        Me.btnDescuentoCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnDescuentoCliente.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnDescuentoCliente.FlatAppearance.BorderSize = 0
        Me.btnDescuentoCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnDescuentoCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnDescuentoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDescuentoCliente.Font = New System.Drawing.Font("Century Gothic", 8.5!)
        Me.btnDescuentoCliente.ForeColor = System.Drawing.Color.White
        Me.btnDescuentoCliente.Location = New System.Drawing.Point(767, 221)
        Me.btnDescuentoCliente.Name = "btnDescuentoCliente"
        Me.btnDescuentoCliente.Size = New System.Drawing.Size(18, 18)
        Me.btnDescuentoCliente.TabIndex = 69
        Me.btnDescuentoCliente.Text = "+"
        Me.btnDescuentoCliente.UseCompatibleTextRendering = True
        Me.btnDescuentoCliente.UseVisualStyleBackColor = False
        '
        'lblDescuento
        '
        Me.lblDescuento.AutoSize = True
        Me.lblDescuento.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblDescuento.Location = New System.Drawing.Point(630, 197)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(141, 17)
        Me.lblDescuento.TabIndex = 66
        Me.lblDescuento.Text = "Descuento del Cliente"
        '
        'txtCostoTotalEsperado
        '
        Me.txtCostoTotalEsperado.Enabled = False
        Me.txtCostoTotalEsperado.Location = New System.Drawing.Point(804, 173)
        Me.txtCostoTotalEsperado.Name = "txtCostoTotalEsperado"
        Me.txtCostoTotalEsperado.Size = New System.Drawing.Size(121, 20)
        Me.txtCostoTotalEsperado.TabIndex = 63
        '
        'lblCostoYRecargo
        '
        Me.lblCostoYRecargo.AutoSize = True
        Me.lblCostoYRecargo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoYRecargo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblCostoYRecargo.Location = New System.Drawing.Point(630, 153)
        Me.lblCostoYRecargo.Name = "lblCostoYRecargo"
        Me.lblCostoYRecargo.Size = New System.Drawing.Size(106, 17)
        Me.lblCostoYRecargo.TabIndex = 67
        Me.lblCostoYRecargo.Text = "Costo esperado:"
        '
        'lblCostoTotal
        '
        Me.lblCostoTotal.AutoSize = True
        Me.lblCostoTotal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblCostoTotal.Location = New System.Drawing.Point(801, 153)
        Me.lblCostoTotal.Name = "lblCostoTotal"
        Me.lblCostoTotal.Size = New System.Drawing.Size(75, 17)
        Me.lblCostoTotal.TabIndex = 68
        Me.lblCostoTotal.Text = "Costo Total"
        '
        'txtCostoEsperado
        '
        Me.txtCostoEsperado.Enabled = False
        Me.txtCostoEsperado.Location = New System.Drawing.Point(633, 173)
        Me.txtCostoEsperado.Name = "txtCostoEsperado"
        Me.txtCostoEsperado.Size = New System.Drawing.Size(130, 20)
        Me.txtCostoEsperado.TabIndex = 65
        '
        'txtCantidadDias
        '
        Me.txtCantidadDias.Enabled = False
        Me.txtCantidadDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCantidadDias.Location = New System.Drawing.Point(154, 173)
        Me.txtCantidadDias.Name = "txtCantidadDias"
        Me.txtCantidadDias.Size = New System.Drawing.Size(131, 20)
        Me.txtCantidadDias.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(151, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 17)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Cantidad de dias"
        '
        'btnDescuentoReserva
        '
        Me.btnDescuentoReserva.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnDescuentoReserva.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnDescuentoReserva.FlatAppearance.BorderSize = 0
        Me.btnDescuentoReserva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnDescuentoReserva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnDescuentoReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDescuentoReserva.Font = New System.Drawing.Font("Century Gothic", 8.5!)
        Me.btnDescuentoReserva.ForeColor = System.Drawing.Color.White
        Me.btnDescuentoReserva.Location = New System.Drawing.Point(974, 174)
        Me.btnDescuentoReserva.Name = "btnDescuentoReserva"
        Me.btnDescuentoReserva.Size = New System.Drawing.Size(18, 18)
        Me.btnDescuentoReserva.TabIndex = 69
        Me.btnDescuentoReserva.Text = "+"
        Me.btnDescuentoReserva.UseCompatibleTextRendering = True
        Me.btnDescuentoReserva.UseVisualStyleBackColor = False
        '
        'lblDescuentoReserva
        '
        Me.lblDescuentoReserva.AutoSize = True
        Me.lblDescuentoReserva.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblDescuentoReserva.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblDescuentoReserva.Location = New System.Drawing.Point(926, 155)
        Me.lblDescuentoReserva.Name = "lblDescuentoReserva"
        Me.lblDescuentoReserva.Size = New System.Drawing.Size(66, 16)
        Me.lblDescuentoReserva.TabIndex = 68
        Me.lblDescuentoReserva.Text = "Descuento"
        Me.lblDescuentoReserva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(151, 200)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 17)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Kilometros por día"
        '
        'lblAdvertencia
        '
        Me.lblAdvertencia.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdvertencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblAdvertencia.Location = New System.Drawing.Point(291, 219)
        Me.lblAdvertencia.Name = "lblAdvertencia"
        Me.lblAdvertencia.Size = New System.Drawing.Size(336, 31)
        Me.lblAdvertencia.TabIndex = 70
        Me.lblAdvertencia.Text = "Esto quiere decir que el cliente podrá realizar un total de X kilómetros en total" &
    " de toda la reserva."
        '
        'cbxKilometraje
        '
        Me.cbxKilometraje.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxKilometraje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxKilometraje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbxKilometraje.FormattingEnabled = True
        Me.cbxKilometraje.Items.AddRange(New Object() {"Flying Cars", "Uruguay Motors", "Rentafrank", "Punta Motors"})
        Me.cbxKilometraje.Location = New System.Drawing.Point(154, 219)
        Me.cbxKilometraje.Name = "cbxKilometraje"
        Me.cbxKilometraje.Size = New System.Drawing.Size(131, 21)
        Me.cbxKilometraje.TabIndex = 56
        '
        'numDescuentoReserva
        '
        Me.numDescuentoReserva.Enabled = False
        Me.numDescuentoReserva.Location = New System.Drawing.Point(931, 173)
        Me.numDescuentoReserva.Name = "numDescuentoReserva"
        Me.numDescuentoReserva.Size = New System.Drawing.Size(40, 20)
        Me.numDescuentoReserva.TabIndex = 71
        '
        'numDescuentoCliente
        '
        Me.numDescuentoCliente.Enabled = False
        Me.numDescuentoCliente.Location = New System.Drawing.Point(633, 220)
        Me.numDescuentoCliente.Name = "numDescuentoCliente"
        Me.numDescuentoCliente.Size = New System.Drawing.Size(129, 20)
        Me.numDescuentoCliente.TabIndex = 71
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1136, 30)
        Me.Panel1.TabIndex = 72
        '
        'txtDeducible
        '
        Me.txtDeducible.Enabled = False
        Me.txtDeducible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDeducible.Location = New System.Drawing.Point(804, 220)
        Me.txtDeducible.Name = "txtDeducible"
        Me.txtDeducible.Size = New System.Drawing.Size(121, 20)
        Me.txtDeducible.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(801, 200)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 17)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Deducible"
        '
        'txtCategoriaAntigua
        '
        Me.txtCategoriaAntigua.Enabled = False
        Me.txtCategoriaAntigua.Location = New System.Drawing.Point(309, 173)
        Me.txtCategoriaAntigua.Name = "txtCategoriaAntigua"
        Me.txtCategoriaAntigua.Size = New System.Drawing.Size(131, 20)
        Me.txtCategoriaAntigua.TabIndex = 1
        '
        'lblCategoriaAntigua
        '
        Me.lblCategoriaAntigua.AutoSize = True
        Me.lblCategoriaAntigua.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoriaAntigua.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblCategoriaAntigua.Location = New System.Drawing.Point(309, 153)
        Me.lblCategoriaAntigua.Name = "lblCategoriaAntigua"
        Me.lblCategoriaAntigua.Size = New System.Drawing.Size(136, 17)
        Me.lblCategoriaAntigua.TabIndex = 37
        Me.lblCategoriaAntigua.Text = "Categoria Reservada"
        '
        'chboxCobrarEstaCat
        '
        Me.chboxCobrarEstaCat.AutoCheck = False
        Me.chboxCobrarEstaCat.Font = New System.Drawing.Font("Century Gothic", 7.25!)
        Me.chboxCobrarEstaCat.Location = New System.Drawing.Point(446, 174)
        Me.chboxCobrarEstaCat.Name = "chboxCobrarEstaCat"
        Me.chboxCobrarEstaCat.Size = New System.Drawing.Size(163, 20)
        Me.chboxCobrarEstaCat.TabIndex = 73
        Me.chboxCobrarEstaCat.Text = "Cobrar con esta Categoria"
        Me.chboxCobrarEstaCat.UseVisualStyleBackColor = True
        '
        'frmAlquilar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 754)
        Me.Controls.Add(Me.chboxCobrarEstaCat)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.numDescuentoCliente)
        Me.Controls.Add(Me.numDescuentoReserva)
        Me.Controls.Add(Me.lblAdvertencia)
        Me.Controls.Add(Me.cbxKilometraje)
        Me.Controls.Add(Me.btnDescuentoReserva)
        Me.Controls.Add(Me.btnDescuentoCliente)
        Me.Controls.Add(Me.lblDescuento)
        Me.Controls.Add(Me.txtDeducible)
        Me.Controls.Add(Me.txtCantidadDias)
        Me.Controls.Add(Me.txtCostoTotalEsperado)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblCategoriaAntigua)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblCostoYRecargo)
        Me.Controls.Add(Me.lblDescuentoReserva)
        Me.Controls.Add(Me.lblCostoTotal)
        Me.Controls.Add(Me.txtCostoEsperado)
        Me.Controls.Add(Me.gbxFecNacFCliente)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbxReserva)
        Me.Controls.Add(Me.btnAlquilar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.txtCategoriaAntigua)
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
        Me.gbxReserva.ResumeLayout(False)
        Me.gbxReserva.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbxFecNacFCliente.ResumeLayout(False)
        Me.gbxFecNacFCliente.PerformLayout()
        CType(Me.numDescuentoReserva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDescuentoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvAlquilar As DataGridView
    Friend WithEvents txtTipo As TextBox
    Friend WithEvents txtCategoria As TextBox
    Friend WithEvents txtSucursal As TextBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
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
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cbxSucLlegada As ComboBox
    Friend WithEvents gbxReserva As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents gbxFecNacFCliente As GroupBox
    Friend WithEvents btnDescuentoCliente As Button
    Friend WithEvents lblDescuento As Label
    Friend WithEvents txtCostoTotalEsperado As TextBox
    Friend WithEvents lblCostoYRecargo As Label
    Friend WithEvents lblCostoTotal As Label
    Friend WithEvents txtCostoEsperado As TextBox
    Friend WithEvents txtCantidadDias As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnDescuentoReserva As Button
    Friend WithEvents lblDescuentoReserva As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblAdvertencia As Label
    Friend WithEvents cbxKilometraje As ComboBox
    Friend WithEvents numDescuentoReserva As NumericUpDown
    Friend WithEvents numDescuentoCliente As NumericUpDown
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtDeducible As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCategoriaAntigua As TextBox
    Friend WithEvents lblCategoriaAntigua As Label
    Friend WithEvents chboxCobrarEstaCat As CheckBox
End Class
