<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reconectar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reconectar))
        Me.pboxreconnecting = New System.Windows.Forms.PictureBox()
        Me.pboxfija = New System.Windows.Forms.PictureBox()
        Me.lblreconnect = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnMinimizar = New System.Windows.Forms.Button()
        Me.mstMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btncontinuar = New System.Windows.Forms.Button()
        CType(Me.pboxreconnecting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxfija, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pboxreconnecting
        '
        Me.pboxreconnecting.Image = Global.CarSolutioner.My.Resources.Resources.loadingsquare
        Me.pboxreconnecting.Location = New System.Drawing.Point(121, 53)
        Me.pboxreconnecting.Name = "pboxreconnecting"
        Me.pboxreconnecting.Size = New System.Drawing.Size(99, 75)
        Me.pboxreconnecting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxreconnecting.TabIndex = 35
        Me.pboxreconnecting.TabStop = False
        Me.pboxreconnecting.Visible = False
        '
        'pboxfija
        '
        Me.pboxfija.Image = Global.CarSolutioner.My.Resources.Resources.logo
        Me.pboxfija.Location = New System.Drawing.Point(136, 64)
        Me.pboxfija.Name = "pboxfija"
        Me.pboxfija.Size = New System.Drawing.Size(70, 54)
        Me.pboxfija.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxfija.TabIndex = 36
        Me.pboxfija.TabStop = False
        '
        'lblreconnect
        '
        Me.lblreconnect.BackColor = System.Drawing.Color.Transparent
        Me.lblreconnect.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblreconnect.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblreconnect.Location = New System.Drawing.Point(-26, 131)
        Me.lblreconnect.Name = "lblreconnect"
        Me.lblreconnect.Size = New System.Drawing.Size(395, 15)
        Me.lblreconnect.TabIndex = 37
        Me.lblreconnect.Text = "Mensaje"
        Me.lblreconnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.btnCerrar.Location = New System.Drawing.Point(308, 0)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 30)
        Me.btnCerrar.TabIndex = 40
        Me.btnCerrar.Text = "✕"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'btnMinimizar
        '
        Me.btnMinimizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimizar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinimizar.ForeColor = System.Drawing.Color.Transparent
        Me.btnMinimizar.Location = New System.Drawing.Point(270, 0)
        Me.btnMinimizar.Name = "btnMinimizar"
        Me.btnMinimizar.Size = New System.Drawing.Size(32, 30)
        Me.btnMinimizar.TabIndex = 39
        Me.btnMinimizar.Text = "—"
        Me.btnMinimizar.UseVisualStyleBackColor = False
        '
        'mstMenuStrip
        '
        Me.mstMenuStrip.AutoSize = False
        Me.mstMenuStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.mstMenuStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mstMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.mstMenuStrip.Name = "mstMenuStrip"
        Me.mstMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.mstMenuStrip.Size = New System.Drawing.Size(341, 30)
        Me.mstMenuStrip.TabIndex = 38
        Me.mstMenuStrip.Text = "MenuStrip1"
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnLogin.Location = New System.Drawing.Point(121, 149)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(99, 27)
        Me.btnLogin.TabIndex = 41
        Me.btnLogin.Text = "Reconectar"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'btncontinuar
        '
        Me.btncontinuar.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btncontinuar.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btncontinuar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btncontinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncontinuar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncontinuar.ForeColor = System.Drawing.Color.Cornsilk
        Me.btncontinuar.Location = New System.Drawing.Point(121, 149)
        Me.btncontinuar.Name = "btncontinuar"
        Me.btncontinuar.Size = New System.Drawing.Size(99, 27)
        Me.btncontinuar.TabIndex = 42
        Me.btncontinuar.Text = "Continuar"
        Me.btncontinuar.UseVisualStyleBackColor = False
        '
        'Reconectar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(341, 180)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnMinimizar)
        Me.Controls.Add(Me.mstMenuStrip)
        Me.Controls.Add(Me.lblreconnect)
        Me.Controls.Add(Me.pboxreconnecting)
        Me.Controls.Add(Me.pboxfija)
        Me.Controls.Add(Me.btncontinuar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Reconectar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reconectar"
        CType(Me.pboxreconnecting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxfija, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pboxreconnecting As PictureBox
    Friend WithEvents pboxfija As PictureBox
    Friend WithEvents lblreconnect As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnMinimizar As Button
    Friend WithEvents mstMenuStrip As MenuStrip
    Friend WithEvents btnLogin As Button
    Friend WithEvents btncontinuar As Button
End Class
