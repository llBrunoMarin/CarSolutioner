Public Class MainMenu

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el tamaño de las tabs a 1 para ocultarlas.
        Asignarmenustrip(mstMenuStrip)
        tbcTabControl.ItemSize = New Size(0, 1)
        btnReservas.PerformClick()

    End Sub

    Private Sub Sidebar_Click(sender As Object, e As EventArgs) Handles btnMantenimiento.Click, btnReservas.Click, btnClientes.Click, btnVehiculos.Click, btnEmpleados.Click, pbxVehiculo.Click

        ResetColors()

        Select Case sender.Name

            Case "btnMantenimiento"
                tbcTabControl.SelectedTab = tbpMantenimiento
                Dim color As Color = Color.Silver
                SetColors(btnMantenimiento, tbpMantenimiento, color)
                btnMantenimiento.ForeColor = Color.FromArgb(100, 38, 38)
            Case "btnReservas"

                tbcTabControl.SelectedTab = tbpReservas
                Dim color As Color = Color.Silver
                SetColors(btnReservas, tbpReservas, color)
                btnReservas.ForeColor = Color.FromArgb(100, 38, 38)

            Case "btnClientes"
                tbcTabControl.SelectedTab = tbpClientes
                Dim color As Color = Color.Silver
                SetColors(btnClientes, tbpClientes, color)
                btnClientes.ForeColor = Color.FromArgb(100, 38, 38)

            Case "btnVehiculos"
                tbcTabControl.SelectedTab = tbpVehiculos
                Dim color As Color = Color.Silver
                SetColors(btnVehiculos, tbpVehiculos, color)
                btnVehiculos.ForeColor = Color.FromArgb(100, 38, 38)

            Case "btnEmpleados"
                tbcTabControl.SelectedTab = tbpEmpleados
                Dim color As Color = Color.Silver
                SetColors(btnEmpleados, tbpEmpleados, color)
                btnEmpleados.ForeColor = Color.FromArgb(100, 38, 38)

            Case "pbxVehiculo"
                tbcTabControl.SelectedTab = tbpMenuPrincipal
                tbpMenuPrincipal.BackColor = Color.Silver



        End Select

    End Sub

    Sub ResetColors()

        btnClientes.BackColor = Color.Transparent
        btnReservas.BackColor = Color.Transparent
        btnVehiculos.BackColor = Color.Transparent
        btnMantenimiento.BackColor = Color.Transparent
        btnEmpleados.BackColor = Color.Transparent
        btnClientes.ForeColor = Color.White
        btnEmpleados.ForeColor = Color.White
        btnReservas.ForeColor = Color.White
        btnVehiculos.ForeColor = Color.White
        btnMantenimiento.ForeColor = Color.White
    End Sub


    Private Sub SetColors(Button As Button, TabPage As TabPage, Color As Color)

        Button.BackColor = Color
        Button.FlatAppearance.MouseOverBackColor = Color
        TabPage.BackColor = Color

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chboxFechaFRes.CheckedChanged
        If chboxFechaFRes.Checked Then
            dtpFAResF.Enabled = True
            dtpFAResI.Enabled = True
        Else
            dtpFAResF.Enabled = False
            dtpFAResI.Enabled = False
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Login.Dispose()
        Me.Dispose()
    End Sub

    Private Sub btnVaciarFRes_Click(sender As Object, e As EventArgs) Handles btnVaciarFRes.Click

    End Sub

    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click
        tbpCambiosGenerales.Show()
    End Sub
End Class
