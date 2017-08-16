'MenuPrincipal (DISEÑO)
Public Class MainMenu

    Dim conexion As ConnectionBD = Login.conexion

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Le cambiamos el renderer al MenuStrip (cuestiones de diseño)
        CambiarRenderMenuStrip(mstMenuStrip)

        'Asignamos el tamaño de las tabs a 1 para ocultarlas.
        tbcTabControl.ItemSize = New Size(0, 1)

        '"Clickeamos" el botón Reservas (para que sea el botón presionado por defecto)
        btnReservas.PerformClick()

        cbxTipoDocumFCliente.SelectedItem = cbxTipoDocumFCliente.Items(0)

        'TODO: Hacer bien las cargas, cargar también combobox y reportar estado de carga (otro formulario con barrita)
        conexion.RellenarDataGridView(dgvClientes, "SELECT tipodocumento, nrodocumento, nombre, apellido, email, fecnac, empresa FROM CLIENTE")
        conexion.RellenarDataGridView(dgvEmpleados, "SELECT usuario, tipo FROM EMPLEADO")



    End Sub

    Private Sub Sidebar_Click(sender As Object, e As EventArgs) Handles btnMantenimiento.Click, btnReservas.Click, btnClientes.Click, btnVehiculos.Click, btnEmpleados.Click, pbxVehiculo.Click

        ResetColors()

        Select Case sender.Name

            Case "btnMantenimiento"
                SetTabAndColors(btnMantenimiento, tbpMantenimiento, Color.Silver, dtvmant)

            Case "btnReservas"
                SetTabAndColors(btnReservas, tbpReservas, Color.Silver, dtvRes)

            Case "btnClientes"
                SetTabAndColors(btnClientes, tbpClientes, Color.Silver, dgvClientes)

            Case "btnVehiculos"
                SetTabAndColors(btnVehiculos, tbpVehiculos, Color.Silver, dgvVehiculos)

            Case "btnEmpleados"
                SetTabAndColors(btnEmpleados, tbpEmpleados, Color.Silver, dgvEmpleados)

            Case "pbxVehiculo"
                tbcTabControl.SelectedTab = tbpMenuPrincipal
                tbpMenuPrincipal.BackColor = Color.Silver

        End Select

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Login.Dispose()
        Me.Dispose()

    End Sub


    Private Sub tsitemCambiosGenerales_Click(sender As Object, e As EventArgs) Handles tsitemCambiosGenerales.Click

        frmCambiosGenerales.Show()

    End Sub




    Private Sub SetTabAndColors(boton As Button, pagina As TabPage, Color As Color, dgv As DataGridView)

        boton.BackColor = Color
        boton.FlatAppearance.MouseOverBackColor = Color
        boton.FlatAppearance.MouseDownBackColor = Color
        boton.ForeColor = Color.FromArgb(100, 38, 38)

        pagina.BackColor = Color
        tbcTabControl.SelectedTab = pagina

        'TODO: SACAR EL IF, ESTA SOLO PQ EN RESERVAS NO HAY NADA CARGADO Y TIRA ERROR
        If (Not (dgv Is dtvRes)) Then
            If (Not (dgv Is dtvmant)) Then
                If (Not (dgv Is dgvVehiculos)) Then
                    dgv.Rows(0).Selected = False
                End If

            End If

        End If


    End Sub

    Sub ResetColors()

        'Recorrer todos los controles del panel Sidebar
        For Each control In pnlSidebar.Controls
            'Si el control es un botón
            If TypeOf control Is Button Then
                control.BackColor = Color.Transparent
                control.ForeColor = Color.White
                control.FlatAppearance.MouseOverBackColor = Color.FromArgb(130, 55, 55)
            End If

        Next

    End Sub

    Private Sub btnVaciarFClientes_Click(sender As Object, e As EventArgs) Handles btnVaciarFClientes.Click
        dgvClientes.CurrentRow.Selected = False
    End Sub
End Class
