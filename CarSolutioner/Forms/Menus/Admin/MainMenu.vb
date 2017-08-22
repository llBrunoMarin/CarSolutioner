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

        CargarDatos()

    End Sub

    Private Sub Sidebar_Click(sender As Object, e As EventArgs) Handles btnMantenimiento.Click, btnReservas.Click, btnClientes.Click, btnVehiculos.Click, btnEmpleados.Click, pbxVehiculo.Click

        ResetColors()

        Select Case sender.Name

            Case "btnMantenimiento"
                SetTabAndColors(btnMantenimiento, tbpMantenimiento, Color.Silver, dtvmant)

            Case "btnReservas"
                SetTabAndColors(btnReservas, tbpReservas, Color.Silver, dgvReservas)

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




    Private Sub CargarDatos()

        'TODO: Hacer bien las cargas, cargar también combobox y reportar estado de carga (otro formulario con barrita)
        conexion.RellenarDataGridView(dgvClientes, "SELECT tipodocumento Tipo, nrodocumento Documento, nombre Nombre, apellido Apellido, email Correo, fecnac Nacimiento, empresa Empresa FROM CLIENTE WHERE estado = 't'")
        'conexion.RellenarDataGridView(dgvEmpleados, "SELECT usuario, tipo FROM EMPLEADO WHERE estado = 't'")
        'conexion.RellenarDataGridView(dgvVehiculos, "SELECT matricula, etc FROM VEHICULO WHERE estado = 't'")
        'conexion.RellenarDataGridView(dgvReservas, "SELECT FROM RESERVA where estado = '?'")
    End Sub

End Class
