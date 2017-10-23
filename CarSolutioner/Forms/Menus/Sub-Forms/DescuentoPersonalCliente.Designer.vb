<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DescuentoPersonalCliente
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
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblTitulo2 = New System.Windows.Forms.Label()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.numDescuento = New System.Windows.Forms.NumericUpDown()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.numDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.pnlEncabezado.Controls.Add(Me.btnSalir)
        Me.pnlEncabezado.Location = New System.Drawing.Point(-1, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(285, 30)
        Me.pnlEncabezado.TabIndex = 58
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnSalir.Location = New System.Drawing.Point(249, -2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(36, 37)
        Me.btnSalir.TabIndex = 59
        Me.btnSalir.Text = "✕"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'lblTitulo2
        '
        Me.lblTitulo2.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblTitulo2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblTitulo2.Location = New System.Drawing.Point(7, 38)
        Me.lblTitulo2.Name = "lblTitulo2"
        Me.lblTitulo2.Size = New System.Drawing.Size(266, 48)
        Me.lblTitulo2.TabIndex = 60
        Me.lblTitulo2.Text = "Ingrese el descuento que desee para este cliente" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTitulo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDescuento
        '
        Me.lblDescuento.AutoSize = True
        Me.lblDescuento.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblDescuento.Location = New System.Drawing.Point(88, 123)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(94, 17)
        Me.lblDescuento.TabIndex = 61
        Me.lblDescuento.Text = "Descuento (%)"
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
        Me.btnAccept.Location = New System.Drawing.Point(91, 219)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(91, 30)
        Me.btnAccept.TabIndex = 62
        Me.btnAccept.Text = "Confirmar"
        Me.btnAccept.UseVisualStyleBackColor = False
        '
        'numDescuento
        '
        Me.numDescuento.Location = New System.Drawing.Point(73, 143)
        Me.numDescuento.Name = "numDescuento"
        Me.numDescuento.Size = New System.Drawing.Size(120, 20)
        Me.numDescuento.TabIndex = 63
        '
        'DescuentoPersonalCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 261)
        Me.Controls.Add(Me.numDescuento)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.lblDescuento)
        Me.Controls.Add(Me.lblTitulo2)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DescuentoPersonalCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DescuentoPersonalCliente"
        Me.pnlEncabezado.ResumeLayout(False)
        CType(Me.numDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblTitulo2 As Label
    Friend WithEvents lblDescuento As Label
    Friend WithEvents btnAccept As Button
    Friend WithEvents numDescuento As NumericUpDown
End Class
