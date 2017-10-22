<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reserva
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCerrarMsgbox = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.btnAgregarDescuentoCliente = New System.Windows.Forms.Button()
        Me.lblFechaInicioReserva = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSucursalPartida = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSucursalDestino = New System.Windows.Forms.TextBox()
        Me.Label150 = New System.Windows.Forms.Label()
        Me.txtCategoriaElegida = New System.Windows.Forms.TextBox()
        Me.txtKMElegidos = New System.Windows.Forms.TextBox()
        Me.txtCantidadDias = New System.Windows.Forms.TextBox()
        Me.txtDescuentoCliente = New System.Windows.Forms.TextBox()
        Me.lblAdvertencia = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCostoAlqEstimado = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCostoTotalEstimado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnCerrarMsgbox)
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Controls.Add(Me.lblTitulo)
        Me.Panel2.Location = New System.Drawing.Point(0, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(698, 30)
        Me.Panel2.TabIndex = 58
        '
        'btnCerrarMsgbox
        '
        Me.btnCerrarMsgbox.BackColor = System.Drawing.Color.Transparent
        Me.btnCerrarMsgbox.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrarMsgbox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrarMsgbox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrarMsgbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrarMsgbox.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarMsgbox.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnCerrarMsgbox.Location = New System.Drawing.Point(662, -2)
        Me.btnCerrarMsgbox.Name = "btnCerrarMsgbox"
        Me.btnCerrarMsgbox.Size = New System.Drawing.Size(36, 37)
        Me.btnCerrarMsgbox.TabIndex = 53
        Me.btnCerrarMsgbox.Text = "✕"
        Me.btnCerrarMsgbox.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.Transparent
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnCerrar.Location = New System.Drawing.Point(1033, -2)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(36, 37)
        Me.btnCerrar.TabIndex = 32
        Me.btnCerrar.Text = "✕"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(3, 7)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(81, 17)
        Me.lblTitulo.TabIndex = 35
        Me.lblTitulo.Text = "Reserva de: "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.dtpFin)
        Me.Panel1.Controls.Add(Me.dtpInicio)
        Me.Panel1.Controls.Add(Me.btnAgregarDescuentoCliente)
        Me.Panel1.Controls.Add(Me.lblFechaInicioReserva)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtSucursalPartida)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtSucursalDestino)
        Me.Panel1.Controls.Add(Me.Label150)
        Me.Panel1.Controls.Add(Me.txtCategoriaElegida)
        Me.Panel1.Controls.Add(Me.txtKMElegidos)
        Me.Panel1.Controls.Add(Me.txtCantidadDias)
        Me.Panel1.Controls.Add(Me.txtDescuentoCliente)
        Me.Panel1.Controls.Add(Me.lblAdvertencia)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(399, 295)
        Me.Panel1.TabIndex = 59
        '
        'dtpFin
        '
        Me.dtpFin.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFin.Enabled = False
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFin.Location = New System.Drawing.Point(8, 88)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(129, 20)
        Me.dtpFin.TabIndex = 51
        '
        'dtpInicio
        '
        Me.dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpInicio.Enabled = False
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInicio.Location = New System.Drawing.Point(8, 38)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(132, 20)
        Me.dtpInicio.TabIndex = 50
        '
        'btnAgregarDescuentoCliente
        '
        Me.btnAgregarDescuentoCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnAgregarDescuentoCliente.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnAgregarDescuentoCliente.FlatAppearance.BorderSize = 0
        Me.btnAgregarDescuentoCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnAgregarDescuentoCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnAgregarDescuentoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarDescuentoCliente.Font = New System.Drawing.Font("Century Gothic", 8.5!)
        Me.btnAgregarDescuentoCliente.ForeColor = System.Drawing.Color.White
        Me.btnAgregarDescuentoCliente.Location = New System.Drawing.Point(308, 189)
        Me.btnAgregarDescuentoCliente.Name = "btnAgregarDescuentoCliente"
        Me.btnAgregarDescuentoCliente.Size = New System.Drawing.Size(18, 18)
        Me.btnAgregarDescuentoCliente.TabIndex = 49
        Me.btnAgregarDescuentoCliente.Text = "+"
        Me.btnAgregarDescuentoCliente.UseCompatibleTextRendering = True
        Me.btnAgregarDescuentoCliente.UseVisualStyleBackColor = False
        '
        'lblFechaInicioReserva
        '
        Me.lblFechaInicioReserva.AutoSize = True
        Me.lblFechaInicioReserva.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicioReserva.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblFechaInicioReserva.Location = New System.Drawing.Point(8, 18)
        Me.lblFechaInicioReserva.Name = "lblFechaInicioReserva"
        Me.lblFechaInicioReserva.Size = New System.Drawing.Size(102, 17)
        Me.lblFechaInicioReserva.TabIndex = 48
        Me.lblFechaInicioReserva.Text = "Fecha de inicio:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(8, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 17)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Fecha de fin:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(8, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 17)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Sucursal partida:"
        '
        'txtSucursalPartida
        '
        Me.txtSucursalPartida.Enabled = False
        Me.txtSucursalPartida.Location = New System.Drawing.Point(8, 138)
        Me.txtSucursalPartida.Name = "txtSucursalPartida"
        Me.txtSucursalPartida.Size = New System.Drawing.Size(129, 20)
        Me.txtSucursalPartida.TabIndex = 47
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(8, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 17)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "Sucursal destino:"
        '
        'txtSucursalDestino
        '
        Me.txtSucursalDestino.Enabled = False
        Me.txtSucursalDestino.Location = New System.Drawing.Point(8, 188)
        Me.txtSucursalDestino.Name = "txtSucursalDestino"
        Me.txtSucursalDestino.Size = New System.Drawing.Size(129, 20)
        Me.txtSucursalDestino.TabIndex = 47
        '
        'Label150
        '
        Me.Label150.AutoSize = True
        Me.Label150.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label150.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label150.Location = New System.Drawing.Point(173, 18)
        Me.Label150.Name = "Label150"
        Me.Label150.Size = New System.Drawing.Size(121, 17)
        Me.Label150.TabIndex = 48
        Me.Label150.Text = "Categoría elegida:"
        '
        'txtCategoriaElegida
        '
        Me.txtCategoriaElegida.Enabled = False
        Me.txtCategoriaElegida.Location = New System.Drawing.Point(176, 38)
        Me.txtCategoriaElegida.Name = "txtCategoriaElegida"
        Me.txtCategoriaElegida.Size = New System.Drawing.Size(129, 20)
        Me.txtCategoriaElegida.TabIndex = 47
        '
        'txtKMElegidos
        '
        Me.txtKMElegidos.Enabled = False
        Me.txtKMElegidos.Location = New System.Drawing.Point(176, 138)
        Me.txtKMElegidos.Name = "txtKMElegidos"
        Me.txtKMElegidos.Size = New System.Drawing.Size(129, 20)
        Me.txtKMElegidos.TabIndex = 47
        '
        'txtCantidadDias
        '
        Me.txtCantidadDias.Enabled = False
        Me.txtCantidadDias.Location = New System.Drawing.Point(176, 88)
        Me.txtCantidadDias.Name = "txtCantidadDias"
        Me.txtCantidadDias.Size = New System.Drawing.Size(129, 20)
        Me.txtCantidadDias.TabIndex = 47
        '
        'txtDescuentoCliente
        '
        Me.txtDescuentoCliente.Enabled = False
        Me.txtDescuentoCliente.Location = New System.Drawing.Point(176, 188)
        Me.txtDescuentoCliente.Name = "txtDescuentoCliente"
        Me.txtDescuentoCliente.Size = New System.Drawing.Size(129, 20)
        Me.txtDescuentoCliente.TabIndex = 47
        '
        'lblAdvertencia
        '
        Me.lblAdvertencia.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdvertencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblAdvertencia.Location = New System.Drawing.Point(34, 227)
        Me.lblAdvertencia.Name = "lblAdvertencia"
        Me.lblAdvertencia.Size = New System.Drawing.Size(295, 64)
        Me.lblAdvertencia.TabIndex = 48
        Me.lblAdvertencia.Text = "Atención: Esto quiere decir que el cliente podrá hacer un máximo de X KM en total" &
    " en todo el alquiler."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(173, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 17)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Descuento preferencial del cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(173, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 17)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Cantidad de KM elegida:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(173, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 17)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Cantidad de días:"
        '
        'txtCostoAlqEstimado
        '
        Me.txtCostoAlqEstimado.Enabled = False
        Me.txtCostoAlqEstimado.Location = New System.Drawing.Point(489, 73)
        Me.txtCostoAlqEstimado.Name = "txtCostoAlqEstimado"
        Me.txtCostoAlqEstimado.Size = New System.Drawing.Size(121, 20)
        Me.txtCostoAlqEstimado.TabIndex = 47
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(470, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(174, 17)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Costo estimado del alquiler:"
        '
        'txtDescuento
        '
        Me.txtDescuento.Enabled = False
        Me.txtDescuento.Location = New System.Drawing.Point(489, 123)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(121, 20)
        Me.txtDescuento.TabIndex = 47
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(509, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 17)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Descuento:"
        '
        'txtCostoTotalEstimado
        '
        Me.txtCostoTotalEstimado.Enabled = False
        Me.txtCostoTotalEstimado.Location = New System.Drawing.Point(489, 224)
        Me.txtCostoTotalEstimado.Name = "txtCostoTotalEstimado"
        Me.txtCostoTotalEstimado.Size = New System.Drawing.Size(121, 20)
        Me.txtCostoTotalEstimado.TabIndex = 47
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(479, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 17)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Costo total estimado:"
        '
        'btnAccept
        '
        Me.btnAccept.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAccept.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAccept.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnAccept.FlatAppearance.BorderSize = 0
        Me.btnAccept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnAccept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccept.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccept.ForeColor = System.Drawing.Color.White
        Me.btnAccept.Location = New System.Drawing.Point(502, 296)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(91, 30)
        Me.btnAccept.TabIndex = 60
        Me.btnAccept.Text = "Confirmar"
        Me.btnAccept.UseVisualStyleBackColor = False
        '
        'Reserva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 343)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtCostoAlqEstimado)
        Me.Controls.Add(Me.txtCostoTotalEstimado)
        Me.Controls.Add(Me.txtDescuento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Reserva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reserva"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCerrarMsgbox As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAgregarDescuentoCliente As Button
    Friend WithEvents Label150 As Label
    Friend WithEvents txtCategoriaElegida As TextBox
    Friend WithEvents txtKMElegidos As TextBox
    Friend WithEvents txtCantidadDias As TextBox
    Friend WithEvents txtDescuentoCliente As TextBox
    Friend WithEvents lblAdvertencia As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCostoAlqEstimado As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDescuento As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCostoTotalEstimado As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSucursalPartida As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSucursalDestino As TextBox
    Friend WithEvents dtpFin As DateTimePicker
    Friend WithEvents dtpInicio As DateTimePicker
    Friend WithEvents lblFechaInicioReserva As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnAccept As Button
End Class
