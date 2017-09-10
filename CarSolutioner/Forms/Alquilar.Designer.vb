<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlquilar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        Me.dgvAlquilar = New System.Windows.Forms.DataGridView()
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
        Me.btnVaciarFRes = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.DataGridView6 = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxSucLlegada = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFRinicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFRfin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFAinicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFAfin = New System.Windows.Forms.DateTimePicker()
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
        Me.dgvAlquilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlquilar.Location = New System.Drawing.Point(4, 135)
        Me.dgvAlquilar.Name = "dgvAlquilar"
        Me.dgvAlquilar.Size = New System.Drawing.Size(1038, 487)
        Me.dgvAlquilar.TabIndex = 0
        '
        'txtTipo
        '
        Me.txtTipo.Enabled = False
        Me.txtTipo.Location = New System.Drawing.Point(12, 59)
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
        Me.Label10.Location = New System.Drawing.Point(10, 41)
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
        Me.Label1.Location = New System.Drawing.Point(115, 41)
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
        Me.Label2.Location = New System.Drawing.Point(224, 41)
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
        Me.Label3.Location = New System.Drawing.Point(330, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 17)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Nombre Cliente"
        '
        'btnVaciarFRes
        '
        Me.btnVaciarFRes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVaciarFRes.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnVaciarFRes.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnVaciarFRes.FlatAppearance.BorderSize = 0
        Me.btnVaciarFRes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnVaciarFRes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnVaciarFRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVaciarFRes.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVaciarFRes.ForeColor = System.Drawing.Color.White
        Me.btnVaciarFRes.Location = New System.Drawing.Point(948, 98)
        Me.btnVaciarFRes.Name = "btnVaciarFRes"
        Me.btnVaciarFRes.Size = New System.Drawing.Size(99, 31)
        Me.btnVaciarFRes.TabIndex = 40
        Me.btnVaciarFRes.Text = "Alquilar"
        Me.btnVaciarFRes.UseVisualStyleBackColor = False
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
        Me.Label4.Location = New System.Drawing.Point(53, 82)
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
        Me.Label5.Location = New System.Drawing.Point(285, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 17)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Fecha Reserva Fin"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(710, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 17)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Fecha Alquiler Fin"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(484, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 17)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Fecha Alquiler Inicio"
        '
        'cbxSucLlegada
        '
        Me.cbxSucLlegada.FormattingEnabled = True
        Me.cbxSucLlegada.Items.AddRange(New Object() {"Flying Cars", "Uruguay Motors", "Rentafrank", "Punta Motors"})
        Me.cbxSucLlegada.Location = New System.Drawing.Point(670, 58)
        Me.cbxSucLlegada.Name = "cbxSucLlegada"
        Me.cbxSucLlegada.Size = New System.Drawing.Size(121, 21)
        Me.cbxSucLlegada.TabIndex = 56
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(667, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 17)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Sucursal Llegada"
        '
        'dtpFRinicio
        '
        Me.dtpFRinicio.CustomFormat = ""
        Me.dtpFRinicio.Enabled = False
        Me.dtpFRinicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFRinicio.Location = New System.Drawing.Point(12, 102)
        Me.dtpFRinicio.MaxDate = New Date(2000, 5, 4, 0, 0, 0, 0)
        Me.dtpFRinicio.MinDate = New Date(1953, 12, 9, 0, 0, 0, 0)
        Me.dtpFRinicio.Name = "dtpFRinicio"
        Me.dtpFRinicio.Size = New System.Drawing.Size(200, 20)
        Me.dtpFRinicio.TabIndex = 54
        Me.dtpFRinicio.Value = New Date(2000, 5, 3, 0, 0, 0, 0)
        '
        'dtpFRfin
        '
        Me.dtpFRfin.CustomFormat = ""
        Me.dtpFRfin.Enabled = False
        Me.dtpFRfin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFRfin.Location = New System.Drawing.Point(224, 102)
        Me.dtpFRfin.MaxDate = New Date(2000, 5, 4, 0, 0, 0, 0)
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
        Me.dtpFAinicio.Location = New System.Drawing.Point(441, 102)
        Me.dtpFAinicio.MaxDate = New Date(2000, 5, 4, 0, 0, 0, 0)
        Me.dtpFAinicio.MinDate = New Date(1953, 12, 9, 0, 0, 0, 0)
        Me.dtpFAinicio.Name = "dtpFAinicio"
        Me.dtpFAinicio.Size = New System.Drawing.Size(200, 20)
        Me.dtpFAinicio.TabIndex = 52
        Me.dtpFAinicio.Value = New Date(2000, 5, 3, 0, 0, 0, 0)
        '
        'dtpFAfin
        '
        Me.dtpFAfin.CustomFormat = "dd/MM/yyyy"
        Me.dtpFAfin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFAfin.Location = New System.Drawing.Point(670, 102)
        Me.dtpFAfin.MaxDate = New Date(2000, 5, 4, 0, 0, 0, 0)
        Me.dtpFAfin.MinDate = New Date(1953, 12, 9, 0, 0, 0, 0)
        Me.dtpFAfin.Name = "dtpFAfin"
        Me.dtpFAfin.Size = New System.Drawing.Size(200, 20)
        Me.dtpFAfin.TabIndex = 51
        Me.dtpFAfin.Value = New Date(2000, 5, 3, 0, 0, 0, 0)
        '
        'frmAlquilar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 629)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbxSucLlegada)
        Me.Controls.Add(Me.dtpFRinicio)
        Me.Controls.Add(Me.dtpFRfin)
        Me.Controls.Add(Me.dtpFAinicio)
        Me.Controls.Add(Me.dtpFAfin)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnVaciarFRes)
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
        Me.Name = "frmAlquilar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alquilar"
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
    Friend WithEvents btnVaciarFRes As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents DataGridView5 As DataGridView
    Friend WithEvents DataGridView6 As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cbxSucLlegada As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpFRinicio As DateTimePicker
    Friend WithEvents dtpFRfin As DateTimePicker
    Friend WithEvents dtpFAinicio As DateTimePicker
    Friend WithEvents dtpFAfin As DateTimePicker
End Class
