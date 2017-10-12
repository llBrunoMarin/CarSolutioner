<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AmaranthMsgbox
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AmaranthMsgbox))
        Me.lblTexto = New System.Windows.Forms.Label()
        Me.btnSi = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCerrarMsgbox = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.pbxPregunta = New System.Windows.Forms.PictureBox()
        Me.pbxAdvertencia = New System.Windows.Forms.PictureBox()
        Me.pbxContinuar = New System.Windows.Forms.PictureBox()
        Me.pbxError = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.pbxPregunta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAdvertencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxContinuar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTexto
        '
        Me.lblTexto.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblTexto.Location = New System.Drawing.Point(106, 65)
        Me.lblTexto.Name = "lblTexto"
        Me.lblTexto.Size = New System.Drawing.Size(227, 75)
        Me.lblTexto.TabIndex = 0
        Me.lblTexto.Text = "Error: Texto de ejemplo para mostrar un error. Por favor verifique." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnSi
        '
        Me.btnSi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSi.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnSi.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnSi.FlatAppearance.BorderSize = 0
        Me.btnSi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnSi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSi.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSi.ForeColor = System.Drawing.Color.White
        Me.btnSi.Location = New System.Drawing.Point(73, 158)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(91, 30)
        Me.btnSi.TabIndex = 50
        Me.btnSi.Text = "Si"
        Me.btnSi.UseVisualStyleBackColor = False
        '
        'btnNo
        '
        Me.btnNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnNo.FlatAppearance.BorderSize = 0
        Me.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.ForeColor = System.Drawing.Color.White
        Me.btnNo.Location = New System.Drawing.Point(205, 158)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(91, 30)
        Me.btnNo.TabIndex = 51
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnCerrarMsgbox)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(383, 30)
        Me.Panel1.TabIndex = 52
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
        Me.btnCerrarMsgbox.Location = New System.Drawing.Point(337, -1)
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
        Me.lblTitulo.Size = New System.Drawing.Size(82, 17)
        Me.lblTitulo.TabIndex = 35
        Me.lblTitulo.Text = "Notificacion"
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
        Me.btnAccept.Location = New System.Drawing.Point(139, 158)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(91, 30)
        Me.btnAccept.TabIndex = 54
        Me.btnAccept.Text = "Aceptar"
        Me.btnAccept.UseVisualStyleBackColor = False
        '
        'pbxPregunta
        '
        Me.pbxPregunta.Image = Global.CarSolutioner.My.Resources.Resources.preg
        Me.pbxPregunta.Location = New System.Drawing.Point(0, 61)
        Me.pbxPregunta.Name = "pbxPregunta"
        Me.pbxPregunta.Size = New System.Drawing.Size(108, 79)
        Me.pbxPregunta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxPregunta.TabIndex = 53
        Me.pbxPregunta.TabStop = False
        '
        'pbxAdvertencia
        '
        Me.pbxAdvertencia.Image = Global.CarSolutioner.My.Resources.Resources.adv
        Me.pbxAdvertencia.Location = New System.Drawing.Point(0, 61)
        Me.pbxAdvertencia.Name = "pbxAdvertencia"
        Me.pbxAdvertencia.Size = New System.Drawing.Size(108, 79)
        Me.pbxAdvertencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxAdvertencia.TabIndex = 53
        Me.pbxAdvertencia.TabStop = False
        '
        'pbxContinuar
        '
        Me.pbxContinuar.Image = Global.CarSolutioner.My.Resources.Resources.ok
        Me.pbxContinuar.Location = New System.Drawing.Point(0, 61)
        Me.pbxContinuar.Name = "pbxContinuar"
        Me.pbxContinuar.Size = New System.Drawing.Size(108, 79)
        Me.pbxContinuar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxContinuar.TabIndex = 53
        Me.pbxContinuar.TabStop = False
        '
        'pbxError
        '
        Me.pbxError.Image = Global.CarSolutioner.My.Resources.Resources.error1
        Me.pbxError.Location = New System.Drawing.Point(0, 61)
        Me.pbxError.Name = "pbxError"
        Me.pbxError.Size = New System.Drawing.Size(108, 79)
        Me.pbxError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxError.TabIndex = 53
        Me.pbxError.TabStop = False
        '
        'AmaranthMsgbox
        '
        Me.AcceptButton = Me.btnSi
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.btnNo
        Me.ClientSize = New System.Drawing.Size(372, 202)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnSi)
        Me.Controls.Add(Me.lblTexto)
        Me.Controls.Add(Me.pbxPregunta)
        Me.Controls.Add(Me.pbxAdvertencia)
        Me.Controls.Add(Me.pbxContinuar)
        Me.Controls.Add(Me.pbxError)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AmaranthMsgbox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AmaranthMsgbox"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbxPregunta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAdvertencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxContinuar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTexto As Label
    Friend WithEvents btnSi As Button
    Friend WithEvents btnNo As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents btnCerrarMsgbox As Button
    Friend WithEvents pbxError As PictureBox
    Friend WithEvents btnAccept As Button
    Friend WithEvents pbxContinuar As PictureBox
    Friend WithEvents pbxAdvertencia As PictureBox
    Friend WithEvents pbxPregunta As PictureBox
End Class
