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
        Me.txtKMAuto = New System.Windows.Forms.TextBox()
        Me.txtCantidadDias = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCostoTotal = New System.Windows.Forms.TextBox()
        Me.lblCostoTotal = New System.Windows.Forms.Label()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.lblCostoYRecargo = New System.Windows.Forms.Label()
        Me.txtDescuentoCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCerrarMsgbox = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnAgregarDescuentoCliente = New System.Windows.Forms.Button()
        Me.btnAgregarDescuentoAlquiler = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label150
        '
        Me.Label150.AutoSize = True
        Me.Label150.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label150.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label150.Location = New System.Drawing.Point(9, 9)
        Me.Label150.Name = "Label150"
        Me.Label150.Size = New System.Drawing.Size(203, 17)
        Me.Label150.TabIndex = 48
        Me.Label150.Text = "KM del auto al finalizar el Alquiler"
        '
        'txtKMAuto
        '
        Me.txtKMAuto.Location = New System.Drawing.Point(9, 29)
        Me.txtKMAuto.Name = "txtKMAuto"
        Me.txtKMAuto.Size = New System.Drawing.Size(121, 20)
        Me.txtKMAuto.TabIndex = 47
        '
        'txtCantidadDias
        '
        Me.txtCantidadDias.Enabled = False
        Me.txtCantidadDias.Location = New System.Drawing.Point(9, 87)
        Me.txtCantidadDias.Name = "txtCantidadDias"
        Me.txtCantidadDias.Size = New System.Drawing.Size(121, 20)
        Me.txtCantidadDias.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 17)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Cantidad de días de ese Alquiler"
        '
        'txtCostoTotal
        '
        Me.txtCostoTotal.Enabled = False
        Me.txtCostoTotal.Location = New System.Drawing.Point(279, 65)
        Me.txtCostoTotal.Name = "txtCostoTotal"
        Me.txtCostoTotal.Size = New System.Drawing.Size(121, 20)
        Me.txtCostoTotal.TabIndex = 47
        '
        'lblCostoTotal
        '
        Me.lblCostoTotal.AutoSize = True
        Me.lblCostoTotal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblCostoTotal.Location = New System.Drawing.Point(276, 231)
        Me.lblCostoTotal.Name = "lblCostoTotal"
        Me.lblCostoTotal.Size = New System.Drawing.Size(75, 17)
        Me.lblCostoTotal.TabIndex = 48
        Me.lblCostoTotal.Text = "Costo Total"
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
        Me.btnAccept.Location = New System.Drawing.Point(292, 307)
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
        Me.lblCostoYRecargo.Location = New System.Drawing.Point(276, 44)
        Me.lblCostoYRecargo.Name = "lblCostoYRecargo"
        Me.lblCostoYRecargo.Size = New System.Drawing.Size(91, 17)
        Me.lblCostoYRecargo.TabIndex = 48
        Me.lblCostoYRecargo.Text = "Costo Alquiler"
        Me.lblCostoYRecargo.Visible = False
        '
        'txtDescuentoCliente
        '
        Me.txtDescuentoCliente.Enabled = False
        Me.txtDescuentoCliente.Location = New System.Drawing.Point(9, 150)
        Me.txtDescuentoCliente.Name = "txtDescuentoCliente"
        Me.txtDescuentoCliente.Size = New System.Drawing.Size(121, 20)
        Me.txtDescuentoCliente.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(217, 17)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Descuento preferencial del Cliente"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.btnAgregarDescuentoCliente)
        Me.Panel1.Controls.Add(Me.Label150)
        Me.Panel1.Controls.Add(Me.txtKMAuto)
        Me.Panel1.Controls.Add(Me.txtCantidadDias)
        Me.Panel1.Controls.Add(Me.txtDescuentoCliente)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(233, 302)
        Me.Panel1.TabIndex = 56
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(9, 228)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(214, 64)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Atención: Este cliente se pasó de los Kilómetros diarios permitidos. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Se cobra" &
    "rá un recargo"
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
        Me.btnAgregarDescuentoCliente.Location = New System.Drawing.Point(135, 151)
        Me.btnAgregarDescuentoCliente.Name = "btnAgregarDescuentoCliente"
        Me.btnAgregarDescuentoCliente.Size = New System.Drawing.Size(18, 18)
        Me.btnAgregarDescuentoCliente.TabIndex = 49
        Me.btnAgregarDescuentoCliente.Text = "+"
        Me.btnAgregarDescuentoCliente.UseCompatibleTextRendering = True
        Me.btnAgregarDescuentoCliente.UseVisualStyleBackColor = False
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
        Me.btnAgregarDescuentoAlquiler.Location = New System.Drawing.Point(406, 123)
        Me.btnAgregarDescuentoAlquiler.Name = "btnAgregarDescuentoAlquiler"
        Me.btnAgregarDescuentoAlquiler.Size = New System.Drawing.Size(18, 18)
        Me.btnAgregarDescuentoAlquiler.TabIndex = 49
        Me.btnAgregarDescuentoAlquiler.Text = "+"
        Me.btnAgregarDescuentoAlquiler.UseCompatibleTextRendering = True
        Me.btnAgregarDescuentoAlquiler.UseVisualStyleBackColor = False
        '
        'TextBox4
        '
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(279, 122)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(121, 20)
        Me.TextBox4.TabIndex = 47
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(278, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Descuento"
        Me.Label4.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.Enabled = False
        Me.TextBox5.Location = New System.Drawing.Point(279, 185)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(121, 20)
        Me.TextBox5.TabIndex = 47
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(276, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 17)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Recargo"
        Me.Label5.Visible = False
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(279, 251)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(121, 20)
        Me.TextBox6.TabIndex = 47
        '
        'FinalizarAlquiler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 351)
        Me.Controls.Add(Me.btnAgregarDescuentoAlquiler)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.lblCostoYRecargo)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.lblCostoTotal)
        Me.Controls.Add(Me.txtCostoTotal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FinalizarAlquiler"
        Me.Text = "FinalizarAlquiler"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label150 As Label
    Friend WithEvents txtKMAuto As TextBox
    Friend WithEvents txtCantidadDias As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCostoTotal As TextBox
    Friend WithEvents lblCostoTotal As Label
    Friend WithEvents btnAccept As Button
    Friend WithEvents lblCostoYRecargo As Label
    Friend WithEvents txtDescuentoCliente As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCerrarMsgbox As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents btnAgregarDescuentoCliente As Button
    Friend WithEvents btnAgregarDescuentoAlquiler As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox6 As TextBox
End Class
