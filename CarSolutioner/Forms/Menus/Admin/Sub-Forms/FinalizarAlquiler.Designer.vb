<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FinalizarAlquiler
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
        Me.Label150 = New System.Windows.Forms.Label()
        Me.txtKMAutoAhora = New System.Windows.Forms.TextBox()
        Me.txtCantidadDias = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCostoTotal = New System.Windows.Forms.TextBox()
        Me.lblCostoTotal = New System.Windows.Forms.Label()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.lblCostoYRecargo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtKMAutoAntes = New System.Windows.Forms.TextBox()
        Me.lblAdvertencia = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCerrarMsgbox = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.txtRecargo = New System.Windows.Forms.TextBox()
        Me.lblRecargo = New System.Windows.Forms.Label()
        Me.txtCostoTotalTotal = New System.Windows.Forms.TextBox()
        Me.btnAgregarDescuentoAlquiler = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label150
        '
        Me.Label150.AutoSize = True
        Me.Label150.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label150.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label150.Location = New System.Drawing.Point(4, 67)
        Me.Label150.Name = "Label150"
        Me.Label150.Size = New System.Drawing.Size(226, 17)
        Me.Label150.TabIndex = 48
        Me.Label150.Text = "KM del vehiculo al finalizar el alquiler"
        '
        'txtKMAutoAhora
        '
        Me.txtKMAutoAhora.Location = New System.Drawing.Point(9, 87)
        Me.txtKMAutoAhora.Name = "txtKMAutoAhora"
        Me.txtKMAutoAhora.Size = New System.Drawing.Size(121, 20)
        Me.txtKMAutoAhora.TabIndex = 47
        '
        'txtCantidadDias
        '
        Me.txtCantidadDias.Enabled = False
        Me.txtCantidadDias.Location = New System.Drawing.Point(9, 147)
        Me.txtCantidadDias.Name = "txtCantidadDias"
        Me.txtCantidadDias.Size = New System.Drawing.Size(121, 20)
        Me.txtCantidadDias.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 17)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Cantidad de días de ese alquiler"
        '
        'txtCostoTotal
        '
        Me.txtCostoTotal.Enabled = False
        Me.txtCostoTotal.Location = New System.Drawing.Point(276, 65)
        Me.txtCostoTotal.Name = "txtCostoTotal"
        Me.txtCostoTotal.Size = New System.Drawing.Size(121, 20)
        Me.txtCostoTotal.TabIndex = 47
        '
        'lblCostoTotal
        '
        Me.lblCostoTotal.AutoSize = True
        Me.lblCostoTotal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblCostoTotal.Location = New System.Drawing.Point(275, 172)
        Me.lblCostoTotal.Name = "lblCostoTotal"
        Me.lblCostoTotal.Size = New System.Drawing.Size(75, 17)
        Me.lblCostoTotal.TabIndex = 48
        Me.lblCostoTotal.Text = "Costo total"
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
        Me.btnAccept.Location = New System.Drawing.Point(294, 253)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(91, 30)
        Me.btnAccept.TabIndex = 55
        Me.btnAccept.Text = "Confirmar"
        Me.btnAccept.UseVisualStyleBackColor = False
        '
        'lblCostoYRecargo
        '
        Me.lblCostoYRecargo.AutoSize = True
        Me.lblCostoYRecargo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoYRecargo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblCostoYRecargo.Location = New System.Drawing.Point(275, 45)
        Me.lblCostoYRecargo.Name = "lblCostoYRecargo"
        Me.lblCostoYRecargo.Size = New System.Drawing.Size(90, 17)
        Me.lblCostoYRecargo.TabIndex = 48
        Me.lblCostoYRecargo.Text = "Costo alquiler"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label150)
        Me.Panel1.Controls.Add(Me.txtKMAutoAntes)
        Me.Panel1.Controls.Add(Me.txtKMAutoAhora)
        Me.Panel1.Controls.Add(Me.txtCantidadDias)
        Me.Panel1.Controls.Add(Me.lblAdvertencia)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(233, 268)
        Me.Panel1.TabIndex = 56
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(4, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(208, 17)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "KM del vehiculo antes del alquiler"
        '
        'txtKMAutoAntes
        '
        Me.txtKMAutoAntes.Enabled = False
        Me.txtKMAutoAntes.Location = New System.Drawing.Point(9, 30)
        Me.txtKMAutoAntes.Name = "txtKMAutoAntes"
        Me.txtKMAutoAntes.Size = New System.Drawing.Size(121, 20)
        Me.txtKMAutoAntes.TabIndex = 47
        '
        'lblAdvertencia
        '
        Me.lblAdvertencia.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdvertencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblAdvertencia.Location = New System.Drawing.Point(4, 184)
        Me.lblAdvertencia.Name = "lblAdvertencia"
        Me.lblAdvertencia.Size = New System.Drawing.Size(214, 64)
        Me.lblAdvertencia.TabIndex = 48
        Me.lblAdvertencia.Text = "Atención: Este cliente se pasó de los Kilómetros diarios permitidos. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Se cobra" &
    "rá un recargo"
        Me.lblAdvertencia.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnCerrarMsgbox)
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Controls.Add(Me.lblTitulo)
        Me.Panel2.Location = New System.Drawing.Point(0, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(436, 30)
        Me.Panel2.TabIndex = 57
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
        Me.btnCerrarMsgbox.Location = New System.Drawing.Point(401, -3)
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
        Me.lblTitulo.Size = New System.Drawing.Size(78, 17)
        Me.lblTitulo.TabIndex = 35
        Me.lblTitulo.Text = "Alquiler de: "
        '
        'txtRecargo
        '
        Me.txtRecargo.Enabled = False
        Me.txtRecargo.Location = New System.Drawing.Point(276, 122)
        Me.txtRecargo.Name = "txtRecargo"
        Me.txtRecargo.Size = New System.Drawing.Size(121, 20)
        Me.txtRecargo.TabIndex = 47
        '
        'lblRecargo
        '
        Me.lblRecargo.AutoSize = True
        Me.lblRecargo.Enabled = False
        Me.lblRecargo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecargo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblRecargo.Location = New System.Drawing.Point(273, 102)
        Me.lblRecargo.Name = "lblRecargo"
        Me.lblRecargo.Size = New System.Drawing.Size(59, 17)
        Me.lblRecargo.TabIndex = 48
        Me.lblRecargo.Text = "Recargo"
        '
        'txtCostoTotalTotal
        '
        Me.txtCostoTotalTotal.Enabled = False
        Me.txtCostoTotalTotal.Location = New System.Drawing.Point(278, 192)
        Me.txtCostoTotalTotal.Name = "txtCostoTotalTotal"
        Me.txtCostoTotalTotal.Size = New System.Drawing.Size(121, 20)
        Me.txtCostoTotalTotal.TabIndex = 47
        '
        'btnAgregarDescuentoAlquiler
        '
        Me.btnAgregarDescuentoAlquiler.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnAgregarDescuentoAlquiler.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnAgregarDescuentoAlquiler.FlatAppearance.BorderSize = 0
        Me.btnAgregarDescuentoAlquiler.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnAgregarDescuentoAlquiler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnAgregarDescuentoAlquiler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarDescuentoAlquiler.Font = New System.Drawing.Font("Century Gothic", 8.5!)
        Me.btnAgregarDescuentoAlquiler.ForeColor = System.Drawing.Color.White
        Me.btnAgregarDescuentoAlquiler.Location = New System.Drawing.Point(403, 123)
        Me.btnAgregarDescuentoAlquiler.Name = "btnAgregarDescuentoAlquiler"
        Me.btnAgregarDescuentoAlquiler.Size = New System.Drawing.Size(18, 18)
        Me.btnAgregarDescuentoAlquiler.TabIndex = 49
        Me.btnAgregarDescuentoAlquiler.Text = "+"
        Me.btnAgregarDescuentoAlquiler.UseCompatibleTextRendering = True
        Me.btnAgregarDescuentoAlquiler.UseVisualStyleBackColor = False
        '
        'FinalizarAlquiler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 311)
        Me.Controls.Add(Me.btnAgregarDescuentoAlquiler)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.lblRecargo)
        Me.Controls.Add(Me.txtCostoTotalTotal)
        Me.Controls.Add(Me.txtRecargo)
        Me.Controls.Add(Me.lblCostoYRecargo)
        Me.Controls.Add(Me.lblCostoTotal)
        Me.Controls.Add(Me.txtCostoTotal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FinalizarAlquiler"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FinalizarAlquiler"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label150 As Label
    Friend WithEvents txtKMAutoAhora As TextBox
    Friend WithEvents txtCantidadDias As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCostoTotal As TextBox
    Friend WithEvents lblCostoTotal As Label
    Friend WithEvents btnAccept As Button
    Friend WithEvents lblCostoYRecargo As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblAdvertencia As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCerrarMsgbox As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents txtRecargo As TextBox
    Friend WithEvents lblRecargo As Label
    Friend WithEvents txtCostoTotalTotal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtKMAutoAntes As TextBox
    Friend WithEvents btnAgregarDescuentoAlquiler As Button
End Class
