'MenuPrincipal (DISEÑO)
Public Class frmMainMenu

    Dim conexion As ConnectionBD = Login.conexion
    Dim Telefonos As DataTable = conexion.EjecutarSelect("SELECT idpersona, telefono::varchar(50) telefono from TelefonoPersona")
    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Le cambiamos el renderer al MenuStrip (cuestiones de diseño)
        CambiarRenderMenuStrip(mstMenuStrip)

        'Asignamos el tamaño de las tabs a 1 para ocultarlas.
        tbcTabControl.ItemSize = New Size(0, 1)

        '"Clickeamos" el botón Reservas (para que sea el botón presionado por defecto)
        btnReservas.PerformClick()

        CargarDatos()
        cbxTipoDocumFCliente.SelectedItem = "CI UY"
        cbxMarcaFVeh.SelectedItem = Nothing
        cbxMarcaAVeh.SelectedItem = Nothing

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

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click

        Me.WindowState = FormWindowState.Minimized

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
        For Each control In pnlSidebar.Controls.OfType(Of Button)

            control.BackColor = Color.Transparent
            control.ForeColor = Color.White
            control.FlatAppearance.MouseOverBackColor = Color.FromArgb(130, 55, 55)

        Next

    End Sub

    'TODO: Hacer otro tipo de cargas si es necesario, cargar también combobox y reportar estado de carga (otro formulario con barrita)
    Private Sub CargarDatos()

        'Cargas DataGridView

        conexion.RellenarDataGridView(dgvClientes, "SELECT tipodocumento Tipo, nrodocumento Documento, nombre Nombre, apellido Apellido, email Correo, fecnac Nacimiento, empresa Empresa FROM CLIENTE WHERE estado = 't'")





        'For i = 0 To 1

        '    

        '   
        '    'For Each row As DataRow In TelefonosCliente.Rows
        '    '    CType(dgvClientes.Rows(i).Cells(7), DataGridViewComboBoxCell).Items.Add(row("telefono"))
        '    'Next
        '    setCellComboBoxItems(dgvClientes, i, 7, TelefonosCliente)

        'Next

        'For i As Integer = 0 To 1

        '    Dim idpersona As String = conexion.EjecutarSelect("SELECT idpersona FROM cliente where nrodocumento = '" + dgvClientes.Rows(i).Cells(1).Value.ToString() + "'").Rows(0)(0).ToString()
        '    Dim TelefonosCliente = Telefonos.Select("idpersona = '" + idpersona + "'").CopyToDataTable

        '    Dim nrotel As String = TelefonosCliente.Rows(i)(0).ToString()

        '    Dim stateCell As DataGridViewComboBoxCell = DirectCast(dgvClientes.Rows(i).Cells(7), DataGridViewComboBoxCell)
        '    stateCell.Items.Add(TelefonosCliente.Rows(i)(0))
        '    stateCell.Value = nrotel

        'Next






        'conexion.RellenarDataGridView(dgvEmpleados, "Select usuario, tipo FROM EMPLEADO WHERE estado = 't'")
        'conexion.RellenarDataGridView(dgvVehiculos, "SELECT matricula, etc FROM VEHICULO WHERE estado = 't'")
        'conexion.RellenarDataGridView(dgvReservas, "SELECT FROM RESERVA where estado = '?'")

        'Cargas de ComboBox

        Dim Marcas As DataTable = conexion.EjecutarSelect("SELECT marca from marca")
        Marcas.Rows.Add("Otro")
        CargarDatosComboBox(cbxMarcaFVeh, Marcas, "marca")
        CargarDatosComboBox(cbxMarcaAVeh, Marcas, "marca")
        CargarDatosComboBox(cbxMarcaMVeh, Marcas, "marca")


        Dim Tipos As DataTable = conexion.EjecutarSelect("SELECT nombre from tipo")
        Tipos.Rows.Add("Otro")
        CargarDatosComboBox(cbxTipoAVeh, Tipos, "nombre")
        CargarDatosComboBox(cbxTipoFVeh, Tipos, "nombre")
        CargarDatosComboBox(cbxTipoMVeh, Tipos, "nombre")


        'Los modelos se cargan en el apartado "Vehiculos".

    End Sub

    Private Sub CargarDatos(dgv As DataGridView)

        Select Case dgv.Name
            Case "dgvClientes"
                conexion.RellenarDataGridView(dgvClientes, "SELECT tipodocumento Tipo, nrodocumento Documento, nombre Nombre, apellido Apellido, email Correo, fecnac Nacimiento, empresa Empresa FROM CLIENTE WHERE estado = 't'")

            Case "dgvEmpleados"
                'conexion.RellenarDataGridView(dgvEmpleados, "SELECT usuario, tipo FROM EMPLEADO WHERE estado = 't'")

            Case "dgvVehiculos"
                'conexion.RellenarDataGridView(dgvVehiculos, "SELECT matricula, etc FROM VEHICULO WHERE estado = 't'")

            Case "dgvReservas"
                'conexion.RellenarDataGridView(dgvReservas, "SELECT FROM RESERVA where estado = '?'")

        End Select

    End Sub

    Private Sub dgv_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvClientes.EditingControlShowing
        If TypeOf e.Control Is ComboBox Then
            Dim idpersona As String = conexion.EjecutarSelect("SELECT idpersona FROM cliente where nrodocumento = '" + dgvClientes.Rows(0).Cells(2).Value.ToString() + "'").Rows(0)(0).ToString()
            Dim TelefonosCliente = Telefonos.Select("idpersona = '" + idpersona + "'").CopyToDataTable
            With DirectCast(e.Control, ComboBox)
                .DropDownStyle = ComboBoxStyle.DropDownList
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .Items.Clear()
                .DataSource = TelefonosCliente
            End With
        End If
    End Sub
    Private Sub CargarDatosComboBox(cbx As ComboBox, dt As DataTable, columna As String)

        '(El "new BindingContext" es para que los comboboxes que hacen referencia a una misma tabla no se seleccionen a la vez)
        cbx.BindingContext = New BindingContext
        cbx.DataSource = dt.DefaultView
        cbx.DisplayMember = columna
        cbx.ValueMember = columna

    End Sub

End Class
