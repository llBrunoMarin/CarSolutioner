﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTelefonosCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTelefonosCliente))
        Me.dgvTelefonos = New System.Windows.Forms.DataGridView()
        Me.telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblAyuda = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAgregarTelefonos = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblNombrePersona = New System.Windows.Forms.Label()
        CType(Me.dgvTelefonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvTelefonos
        '
        Me.dgvTelefonos.AllowUserToResizeColumns = False
        Me.dgvTelefonos.AllowUserToResizeRows = False
        Me.dgvTelefonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTelefonos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvTelefonos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTelefonos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.telefono})
        Me.dgvTelefonos.Location = New System.Drawing.Point(12, 36)
        Me.dgvTelefonos.MultiSelect = False
        Me.dgvTelefonos.Name = "dgvTelefonos"
        Me.dgvTelefonos.RowHeadersVisible = False
        Me.dgvTelefonos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.dgvTelefonos.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTelefonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTelefonos.Size = New System.Drawing.Size(163, 131)
        Me.dgvTelefonos.TabIndex = 0
        '
        'telefono
        '
        Me.telefono.DataPropertyName = "telefono"
        Me.telefono.HeaderText = "Teléfonos"
        Me.telefono.MaxInputLength = 30
        Me.telefono.Name = "telefono"
        '
        'lblAyuda
        '
        Me.lblAyuda.Font = New System.Drawing.Font("Century Gothic", 8.0!)
        Me.lblAyuda.Location = New System.Drawing.Point(9, 170)
        Me.lblAyuda.Name = "lblAyuda"
        Me.lblAyuda.Size = New System.Drawing.Size(263, 132)
        Me.lblAyuda.TabIndex = 2
        Me.lblAyuda.Text = resources.GetString("lblAyuda.Text")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblNombrePersona)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 30)
        Me.Panel1.TabIndex = 33
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.Transparent
        Me.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnCerrar.Location = New System.Drawing.Point(251, 0)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 30)
        Me.btnCerrar.TabIndex = 29
        Me.btnCerrar.Text = "✕"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'btnAgregarTelefonos
        '
        Me.btnAgregarTelefonos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregarTelefonos.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnAgregarTelefonos.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnAgregarTelefonos.FlatAppearance.BorderSize = 0
        Me.btnAgregarTelefonos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnAgregarTelefonos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnAgregarTelefonos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarTelefonos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarTelefonos.ForeColor = System.Drawing.Color.White
        Me.btnAgregarTelefonos.Location = New System.Drawing.Point(181, 85)
        Me.btnAgregarTelefonos.Name = "btnAgregarTelefonos"
        Me.btnAgregarTelefonos.Size = New System.Drawing.Size(91, 30)
        Me.btnAgregarTelefonos.TabIndex = 50
        Me.btnAgregarTelefonos.Text = "Confirmar"
        Me.btnAgregarTelefonos.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel7.Location = New System.Drawing.Point(278, 26)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(10, 283)
        Me.Panel7.TabIndex = 40
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(-5, 28)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(10, 288)
        Me.Panel2.TabIndex = 41
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(2, 306)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(283, 10)
        Me.Panel3.TabIndex = 51
        '
        'lblNombrePersona
        '
        Me.lblNombrePersona.AutoSize = True
        Me.lblNombrePersona.ForeColor = System.Drawing.Color.White
        Me.lblNombrePersona.Location = New System.Drawing.Point(9, 8)
        Me.lblNombrePersona.Name = "lblNombrePersona"
        Me.lblNombrePersona.Size = New System.Drawing.Size(75, 13)
        Me.lblNombrePersona.TabIndex = 30
        Me.lblNombrePersona.Text = "Teléfonos de: "
        '
        'frmTelefonosCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(284, 316)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnAgregarTelefonos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.lblAyuda)
        Me.Controls.Add(Me.dgvTelefonos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmTelefonosCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Telefonos"
        Me.TopMost = True
        CType(Me.dgvTelefonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvTelefonos As DataGridView
    Friend WithEvents lblAyuda As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnAgregarTelefonos As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents telefono As DataGridViewTextBoxColumn
    Friend WithEvents lblNombrePersona As Label
End Class