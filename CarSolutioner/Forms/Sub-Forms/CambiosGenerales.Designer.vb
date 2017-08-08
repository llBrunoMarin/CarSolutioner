<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCambiosGenerales
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMinimizar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.btnDocumento = New System.Windows.Forms.Button()
        Me.btnReservas = New System.Windows.Forms.Button()
        Me.btnMarcas = New System.Windows.Forms.Button()
        Me.btnModelos = New System.Windows.Forms.Button()
        Me.btnCategorias = New System.Windows.Forms.Button()
        Me.btnMantenimiento = New System.Windows.Forms.Button()
        Me.btnSucursales = New System.Windows.Forms.Button()
        Me.tbcTabControl = New System.Windows.Forms.TabControl()
        Me.tbpSucursales = New System.Windows.Forms.TabPage()
        Me.tbpMantenimiento = New System.Windows.Forms.TabPage()
        Me.tbpCategorias = New System.Windows.Forms.TabPage()
        Me.tbpModelos = New System.Windows.Forms.TabPage()
        Me.tbpMarcas = New System.Windows.Forms.TabPage()
        Me.tbpReservas = New System.Windows.Forms.TabPage()
        Me.tbpDocumento = New System.Windows.Forms.TabPage()
        Me.Panel1.SuspendLayout()
        Me.pnlSidebar.SuspendLayout()
        Me.tbcTabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnMinimizar)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(644, 30)
        Me.Panel1.TabIndex = 0
        '
        'btnMinimizar
        '
        Me.btnMinimizar.BackColor = System.Drawing.Color.Transparent
        Me.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimizar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinimizar.ForeColor = System.Drawing.Color.Transparent
        Me.btnMinimizar.Location = New System.Drawing.Point(580, -1)
        Me.btnMinimizar.Name = "btnMinimizar"
        Me.btnMinimizar.Size = New System.Drawing.Size(32, 38)
        Me.btnMinimizar.TabIndex = 31
        Me.btnMinimizar.Text = "—"
        Me.btnMinimizar.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.Transparent
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnCerrar.Location = New System.Drawing.Point(610, -2)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(36, 37)
        Me.btnCerrar.TabIndex = 32
        Me.btnCerrar.Text = "✕"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(3, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 17)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Cambios generales"
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.btnDocumento)
        Me.pnlSidebar.Controls.Add(Me.btnReservas)
        Me.pnlSidebar.Controls.Add(Me.btnMarcas)
        Me.pnlSidebar.Controls.Add(Me.btnModelos)
        Me.pnlSidebar.Controls.Add(Me.btnCategorias)
        Me.pnlSidebar.Controls.Add(Me.btnMantenimiento)
        Me.pnlSidebar.Controls.Add(Me.btnSucursales)
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 29)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(123, 432)
        Me.pnlSidebar.TabIndex = 33
        '
        'btnDocumento
        '
        Me.btnDocumento.BackColor = System.Drawing.Color.Transparent
        Me.btnDocumento.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnDocumento.FlatAppearance.BorderSize = 0
        Me.btnDocumento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnDocumento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDocumento.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDocumento.ForeColor = System.Drawing.Color.White
        Me.btnDocumento.Location = New System.Drawing.Point(0, 241)
        Me.btnDocumento.Name = "btnDocumento"
        Me.btnDocumento.Size = New System.Drawing.Size(125, 34)
        Me.btnDocumento.TabIndex = 40
        Me.btnDocumento.Text = "Documento"
        Me.btnDocumento.UseVisualStyleBackColor = False
        '
        'btnReservas
        '
        Me.btnReservas.BackColor = System.Drawing.Color.Transparent
        Me.btnReservas.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnReservas.FlatAppearance.BorderSize = 0
        Me.btnReservas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnReservas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReservas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReservas.ForeColor = System.Drawing.Color.White
        Me.btnReservas.Location = New System.Drawing.Point(0, 201)
        Me.btnReservas.Name = "btnReservas"
        Me.btnReservas.Size = New System.Drawing.Size(125, 34)
        Me.btnReservas.TabIndex = 39
        Me.btnReservas.Text = "Reservas"
        Me.btnReservas.UseVisualStyleBackColor = False
        '
        'btnMarcas
        '
        Me.btnMarcas.BackColor = System.Drawing.Color.Transparent
        Me.btnMarcas.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnMarcas.FlatAppearance.BorderSize = 0
        Me.btnMarcas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnMarcas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMarcas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarcas.ForeColor = System.Drawing.Color.White
        Me.btnMarcas.Location = New System.Drawing.Point(0, 161)
        Me.btnMarcas.Name = "btnMarcas"
        Me.btnMarcas.Size = New System.Drawing.Size(125, 34)
        Me.btnMarcas.TabIndex = 38
        Me.btnMarcas.Text = "Marcas"
        Me.btnMarcas.UseVisualStyleBackColor = False
        '
        'btnModelos
        '
        Me.btnModelos.BackColor = System.Drawing.Color.Transparent
        Me.btnModelos.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnModelos.FlatAppearance.BorderSize = 0
        Me.btnModelos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnModelos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnModelos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModelos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModelos.ForeColor = System.Drawing.Color.White
        Me.btnModelos.Location = New System.Drawing.Point(-2, 121)
        Me.btnModelos.Name = "btnModelos"
        Me.btnModelos.Size = New System.Drawing.Size(125, 34)
        Me.btnModelos.TabIndex = 37
        Me.btnModelos.Text = "Modelos"
        Me.btnModelos.UseVisualStyleBackColor = False
        '
        'btnCategorias
        '
        Me.btnCategorias.BackColor = System.Drawing.Color.Transparent
        Me.btnCategorias.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnCategorias.FlatAppearance.BorderSize = 0
        Me.btnCategorias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCategorias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCategorias.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategorias.ForeColor = System.Drawing.Color.White
        Me.btnCategorias.Location = New System.Drawing.Point(-2, 81)
        Me.btnCategorias.Name = "btnCategorias"
        Me.btnCategorias.Size = New System.Drawing.Size(125, 34)
        Me.btnCategorias.TabIndex = 36
        Me.btnCategorias.Text = "Categorias"
        Me.btnCategorias.UseVisualStyleBackColor = False
        '
        'btnMantenimiento
        '
        Me.btnMantenimiento.BackColor = System.Drawing.Color.Transparent
        Me.btnMantenimiento.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnMantenimiento.FlatAppearance.BorderSize = 0
        Me.btnMantenimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnMantenimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMantenimiento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMantenimiento.ForeColor = System.Drawing.Color.White
        Me.btnMantenimiento.Location = New System.Drawing.Point(0, 41)
        Me.btnMantenimiento.Name = "btnMantenimiento"
        Me.btnMantenimiento.Size = New System.Drawing.Size(125, 34)
        Me.btnMantenimiento.TabIndex = 35
        Me.btnMantenimiento.Text = "Mantenimiento"
        Me.btnMantenimiento.UseVisualStyleBackColor = False
        '
        'btnSucursales
        '
        Me.btnSucursales.BackColor = System.Drawing.Color.Transparent
        Me.btnSucursales.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnSucursales.FlatAppearance.BorderSize = 0
        Me.btnSucursales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnSucursales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnSucursales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSucursales.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSucursales.ForeColor = System.Drawing.Color.White
        Me.btnSucursales.Location = New System.Drawing.Point(-2, 1)
        Me.btnSucursales.Name = "btnSucursales"
        Me.btnSucursales.Size = New System.Drawing.Size(125, 34)
        Me.btnSucursales.TabIndex = 34
        Me.btnSucursales.Text = "Sucursales"
        Me.btnSucursales.UseVisualStyleBackColor = False
        '
        'tbcTabControl
        '
        Me.tbcTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbcTabControl.Controls.Add(Me.tbpSucursales)
        Me.tbcTabControl.Controls.Add(Me.tbpMantenimiento)
        Me.tbcTabControl.Controls.Add(Me.tbpCategorias)
        Me.tbcTabControl.Controls.Add(Me.tbpModelos)
        Me.tbcTabControl.Controls.Add(Me.tbpMarcas)
        Me.tbcTabControl.Controls.Add(Me.tbpReservas)
        Me.tbcTabControl.Controls.Add(Me.tbpDocumento)
        Me.tbcTabControl.Location = New System.Drawing.Point(116, 22)
        Me.tbcTabControl.Name = "tbcTabControl"
        Me.tbcTabControl.SelectedIndex = 0
        Me.tbcTabControl.Size = New System.Drawing.Size(534, 450)
        Me.tbcTabControl.TabIndex = 34
        '
        'tbpSucursales
        '
        Me.tbpSucursales.Location = New System.Drawing.Point(4, 25)
        Me.tbpSucursales.Name = "tbpSucursales"
        Me.tbpSucursales.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpSucursales.Size = New System.Drawing.Size(526, 421)
        Me.tbpSucursales.TabIndex = 0
        Me.tbpSucursales.Text = "Sucursales"
        Me.tbpSucursales.UseVisualStyleBackColor = True
        '
        'tbpMantenimiento
        '
        Me.tbpMantenimiento.Location = New System.Drawing.Point(4, 25)
        Me.tbpMantenimiento.Name = "tbpMantenimiento"
        Me.tbpMantenimiento.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpMantenimiento.Size = New System.Drawing.Size(526, 421)
        Me.tbpMantenimiento.TabIndex = 1
        Me.tbpMantenimiento.Text = "Mantenimiento"
        Me.tbpMantenimiento.UseVisualStyleBackColor = True
        '
        'tbpCategorias
        '
        Me.tbpCategorias.Location = New System.Drawing.Point(4, 25)
        Me.tbpCategorias.Name = "tbpCategorias"
        Me.tbpCategorias.Size = New System.Drawing.Size(526, 421)
        Me.tbpCategorias.TabIndex = 2
        Me.tbpCategorias.Text = "Categorias"
        Me.tbpCategorias.UseVisualStyleBackColor = True
        '
        'tbpModelos
        '
        Me.tbpModelos.Location = New System.Drawing.Point(4, 25)
        Me.tbpModelos.Name = "tbpModelos"
        Me.tbpModelos.Size = New System.Drawing.Size(526, 421)
        Me.tbpModelos.TabIndex = 3
        Me.tbpModelos.Text = "Modelos"
        Me.tbpModelos.UseVisualStyleBackColor = True
        '
        'tbpMarcas
        '
        Me.tbpMarcas.Location = New System.Drawing.Point(4, 25)
        Me.tbpMarcas.Name = "tbpMarcas"
        Me.tbpMarcas.Size = New System.Drawing.Size(526, 421)
        Me.tbpMarcas.TabIndex = 4
        Me.tbpMarcas.Text = "Marcas"
        Me.tbpMarcas.UseVisualStyleBackColor = True
        '
        'tbpReservas
        '
        Me.tbpReservas.Location = New System.Drawing.Point(4, 25)
        Me.tbpReservas.Name = "tbpReservas"
        Me.tbpReservas.Size = New System.Drawing.Size(526, 421)
        Me.tbpReservas.TabIndex = 5
        Me.tbpReservas.Text = "Reservas"
        Me.tbpReservas.UseVisualStyleBackColor = True
        '
        'tbpDocumento
        '
        Me.tbpDocumento.Location = New System.Drawing.Point(4, 25)
        Me.tbpDocumento.Name = "tbpDocumento"
        Me.tbpDocumento.Size = New System.Drawing.Size(526, 421)
        Me.tbpDocumento.TabIndex = 6
        Me.tbpDocumento.Text = "Documento"
        Me.tbpDocumento.UseVisualStyleBackColor = True
        '
        'frmCambiosGenerales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(645, 458)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Controls.Add(Me.tbcTabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCambiosGenerales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "i"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlSidebar.ResumeLayout(False)
        Me.tbcTabControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnMinimizar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnDocumento As Button
    Friend WithEvents btnReservas As Button
    Friend WithEvents btnMarcas As Button
    Friend WithEvents btnModelos As Button
    Friend WithEvents btnCategorias As Button
    Friend WithEvents btnMantenimiento As Button
    Friend WithEvents btnSucursales As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents tbcTabControl As TabControl
    Friend WithEvents tbpSucursales As TabPage
    Friend WithEvents tbpMantenimiento As TabPage
    Friend WithEvents tbpCategorias As TabPage
    Friend WithEvents tbpModelos As TabPage
    Friend WithEvents tbpMarcas As TabPage
    Friend WithEvents tbpReservas As TabPage
    Friend WithEvents tbpDocumento As TabPage
End Class
