<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Reconectar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reconectar))
        Me.pboxreconnecting = New System.Windows.Forms.PictureBox()
        Me.pboxfija = New System.Windows.Forms.PictureBox()
        Me.lblreconnect = New System.Windows.Forms.Label()
        Me.mstMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.btnreconectar = New System.Windows.Forms.Button()
        Me.btncontinuar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bgwcargando = New System.ComponentModel.BackgroundWorker()
        CType(Me.pboxreconnecting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxfija, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pboxreconnecting
        '
        Me.pboxreconnecting.Image = Global.CarSolutioner.My.Resources.Resources.loadingsquare
        Me.pboxreconnecting.Location = New System.Drawing.Point(96, 48)
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
        Me.pboxfija.Location = New System.Drawing.Point(111, 59)
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
        Me.lblreconnect.Location = New System.Drawing.Point(12, 124)
        Me.lblreconnect.Name = "lblreconnect"
        Me.lblreconnect.Size = New System.Drawing.Size(272, 38)
        Me.lblreconnect.TabIndex = 37
        Me.lblreconnect.Text = "Se ha perdido la conexión"
        Me.lblreconnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mstMenuStrip
        '
        Me.mstMenuStrip.AutoSize = False
        Me.mstMenuStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.mstMenuStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mstMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.mstMenuStrip.Name = "mstMenuStrip"
        Me.mstMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.mstMenuStrip.Size = New System.Drawing.Size(296, 30)
        Me.mstMenuStrip.TabIndex = 38
        Me.mstMenuStrip.Text = "MenuStrip1"
        '
        'btnreconectar
        '
        Me.btnreconectar.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnreconectar.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnreconectar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnreconectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreconectar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreconectar.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnreconectar.Location = New System.Drawing.Point(96, 165)
        Me.btnreconectar.Name = "btnreconectar"
        Me.btnreconectar.Size = New System.Drawing.Size(99, 27)
        Me.btnreconectar.TabIndex = 41
        Me.btnreconectar.Text = "Reconectar"
        Me.btnreconectar.UseVisualStyleBackColor = False
        '
        'btncontinuar
        '
        Me.btncontinuar.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btncontinuar.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btncontinuar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btncontinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncontinuar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncontinuar.ForeColor = System.Drawing.Color.Cornsilk
        Me.btncontinuar.Location = New System.Drawing.Point(96, 165)
        Me.btncontinuar.Name = "btncontinuar"
        Me.btncontinuar.Size = New System.Drawing.Size(99, 27)
        Me.btncontinuar.TabIndex = 42
        Me.btncontinuar.Text = "Continuar"
        Me.btncontinuar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-8, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(307, 17)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Alerta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bgwcargando
        '
        Me.bgwcargando.WorkerReportsProgress = True
        '
        'Reconectar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(296, 203)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnreconectar)
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
    Friend WithEvents mstMenuStrip As MenuStrip
    Friend WithEvents btnreconectar As Button
    Friend WithEvents btncontinuar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents bgwcargando As System.ComponentModel.BackgroundWorker
End Class
