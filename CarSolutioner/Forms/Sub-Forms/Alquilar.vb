Public Class frmAlquilar

    Dim ReservaSeleccionada As ReservaSeleccionada = frmMainMenu.ReservaSeleccionada

    'Agregar resalquiler fin para cambiar con la q este en el form, por si la quiere cambiar 
    Private Sub Alquilar_Activated(sender As Object, e As EventArgs) Handles Me.Activated, Me.Load
        'Juntamos nombre con apellido 
        Dim ClienteReserva As String = ReservaSeleccionada.NomCliente + " " + ReservaSeleccionada.ApeCliente
        CargarDatosComboBox(cbxSucLlegada, conexion.Sucursales, "nombre", "idsucursal")

        'estos llenan los datetime picker
        'TODO: LAS FECHAS DE ALQUILER NO SE DEBEN SETEAR ASÍ
        dtpFRInicio.Value = ReservaSeleccionada.FechaInicio
        dtpFRfin.Value = ReservaSeleccionada.FechaFin
        dtpFAinicio.Value = DateTime.Today.ToShortDateString


        txtTipo.Text = ReservaSeleccionada.Tipo
        txtCategoria.Text = ReservaSeleccionada.Categoria
        txtSucursal.Text = ReservaSeleccionada.SucursalInicio
        txtCliente.Text = ClienteReserva

        'Pasamos las variables date a string para poder hacer el insert
        'resfin2 = ResFin
        'res2 = ResInicio

        'Resta de fechas para saber los dias
        ReservaSeleccionada.Diasalquilados = (ReservaSeleccionada.FechaFin - ReservaSeleccionada.FechaInicio).Days


        'filtramos el dgv con las reservas para esa persona
        Dim filtro As String
        filtro = "categoria = '" + ReservaSeleccionada.Categoria + "' AND tipo = '" + ReservaSeleccionada.Tipo + "' AND sucursal = '" + ReservaSeleccionada.SucursalInicio + "'"

        dgvAlquilar.DataSource.Filter = filtro


    End Sub

    'Doble click en el dgv alquilar
    Public Sub AlquilarAutoSeleccionado(sender As Object, e As EventArgs) Handles dgvAlquilar.CellMouseDoubleClick, btnAlquilar.Click

        Dim selectedRow As DataGridViewRow


        If sender Is dgvAlquilar Then
            selectedRow = dgvAlquilar.Rows(DirectCast(e, DataGridViewCellMouseEventArgs).RowIndex)
        Else
            selectedRow = dgvAlquilar.CurrentRow
        End If

        Dim nrochasis As String = selectedRow.Cells("nrochasis").Value.ToString

        Dim resultado As MsgBoxResult = MsgBox("Estas seguro que deseas alquilar el vehiculo?", MsgBoxStyle.YesNo, "Desea continuar?")
        If resultado = vbYes Then

            'Actualiza la Reserva para que sea un ALQUILER, con NroChasis = al seleccionado, fechaalquilerinicio = hoy, fechareservafin = seleccionada (en caso que el cliente cambie su fecha reserva fin)
            conexion.EjecutarNonQuery("UPDATE Reserva SET nrochasis = '" + nrochasis + "', idsucursalllegada = '" + cbxSucLlegada.SelectedValue.ToString + "', fechaalquilerinicio = '" + DateTime.Today.Date.ToShortDateString + "', fechareservafin = '" + dtpFRfin.Value.ToShortDateString + "' WHERE idreserva = " + ReservaSeleccionada.IdReserva.ToString + " ")
            conexion.EjecutarNonQuery("UPDATE vehiculo set idsucursal = NULL WHERE nrochasis='" + nrochasis + "'")
            MsgBox("Alquiler Ingresado")
            frmMainMenu.RecargarDatos(dgvAlquilar)
            frmMainMenu.RecargarDatos(frmMainMenu.dgvReservas)
            frmMainMenu.RecargarDatos(frmMainMenu.dgvAlquileres)

            Me.Hide()

        End If
        'Cuentas para el precio final

        'Cuentas para el precio final 
        'TODO: TODO ESTO EN REALIDAD VA EN EL ALTA DE RESERVA. FALTA ARREGLAR COSAS
        'Dim precio As DataTable = conexion.EjecutarSelect("Select tarifadiariabase,tarifax150kmdia,tarifax300kmdia,tarifakmlibredia from categoria where nombre='" + CategoriaReserva + "'")

        'Select Case ReservaSeleccionada.CantKM

        '    Case 1
        '        precioxdia = precio.Rows(0).Item("tarifadiariabase")
        '        tarifakm = precio.Rows(0).Item("tarifax150kmdia")
        '        preciofinal = precioxdia * diasalquilados + tarifakm * diasalquilados
        '    Case 2
        '        precioxdia = precio.Rows(0).Item("tarifadiariabase")
        '        tarifakm = precio.Rows(0).Item("tarifax300kmdia")
        '        preciofinal = precioxdia * diasalquilados + tarifakm * diasalquilados
        '    Case 3
        '        precioxdia = precio.Rows(0).Item("tarifadiariabase")
        '        tarifakm = precio.Rows(0).Item("tarifakmlibredia")

        '    Case Else
        '        MsgBox("Error")

        'End Select
        'preciofinal = precioxdia * diasalquilados + tarifakm * diasalquilados



    End Sub

    'Boton cerrar
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Hide()
    End Sub

    Private Sub btnAlquilar_Click(sender As Object, e As EventArgs) Handles btnAlquilar.Click

    End Sub
End Class