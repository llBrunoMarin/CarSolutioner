Public Class frmAlquilar

    Dim ReservaSeleccionada As ReservaSeleccionada = frmMainMenu.ReservaSeleccionada

    'Agregar resalquiler fin para cambiar con la q este en el form, por si la quiere cambiar 
    Private Sub Alquilar_Activated(sender As Object, e As EventArgs) Handles Me.Load

        'Rellenamos el DataGridView con los autos disponibles en ese momento, en esa sucursal, que no estén en mantenimiento
        Dim sentencia As String = "SELECT  V.*, Ma.nombre marca, Ma.idmarca, Mo.nombre modelo, T.nombre tipo, T.idtipo, C.nombre categoria, S.nombre Sucursal From Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S Where V.idsucursal = '" + ReservaSeleccionada.IdSucursalPartida.ToString + "' AND V.idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "' AND Mo.idtipo = '" + ReservaSeleccionada.IdTipo.ToString + "' AND V.idcategoria = C.idcategoria And V.idmodelo = Mo.idmodelo And Mo.Idmarca = Ma.Idmarca And Mo.Idtipo = T.idtipo And V.idsucursal = S.idsucursal And V.estado = 't' And  V.nrochasis Not IN (Select nrochasis FROM Mantenimiento WHERE fechainicio >=  TO_DATE('" + ReservaSeleccionada.FechaReservaInicio.ToString("dd/MM/yyyy HH:mm") + "', '%d/%m/%Y %H:%M') OR fechafin <= TO_DATE('" + ReservaSeleccionada.FechaReservaFin.ToString("dd/MM/yyyy HH:mm") + "', '%d/%m/%Y %H:%M')    )"
        conexion.RellenarDataGridView(dgvAlquilar, sentencia)

        CargarDatosComboBox(cbxSucLlegada, conexion.Sucursales, "nombre", "idsucursal")
        cbxSucLlegada.SelectedValue = ReservaSeleccionada.IdSucursalDestino

        'estos llenan los datetime picker
        'TODO: LAS FECHAS DE ALQUILER NO SE DEBEN SETEAR ASÍ
        dtpFRInicio.Value = ReservaSeleccionada.FechaReservaInicio
        dtpFRfin.Value = ReservaSeleccionada.FechaReservaFin
        dtpFAinicio.Value = DateTime.Today.ToShortDateString

        txtCliente.Text = ReservaSeleccionada.NomCliente
        txtTipo.Text = conexion.Tipos.Select("idtipo =" + ReservaSeleccionada.IdTipo.ToString() + "").CopyToDataTable.Rows(0)(1).ToString()
        txtCategoria.Text = conexion.Categorias.Select("idcategoria =" + ReservaSeleccionada.IdCategoria.ToString() + "").CopyToDataTable.Rows(0)(1).ToString()
        txtSucursal.Text = conexion.Sucursales.Select("idsucursal =" + ReservaSeleccionada.IdSucursalPartida.ToString() + "").CopyToDataTable.Rows(0)(1).ToString()

    End Sub

    'Doble click en el dgv alquilar, o click en el botón Alquilar
    Public Sub AlquilarAutoSeleccionado(sender As Object, e As EventArgs) Handles dgvAlquilar.CellMouseDoubleClick, btnAlquilar.Click

        Dim selectedRow As DataGridViewRow

        If sender Is dgvAlquilar Then
            selectedRow = dgvAlquilar.Rows(DirectCast(e, DataGridViewCellMouseEventArgs).RowIndex)
        Else
            selectedRow = dgvAlquilar.CurrentRow
        End If

        Dim NroChasis As String = selectedRow.Cells("nrochasis").Value.ToString

        'Dim resultado As DialogResult = MsgBox("Estas seguro que deseas alquilar el vehiculo?", MsgBoxStyle.YesNo, "Desea continuar?")
        Dim resultado As DialogResult = AmaranthMessagebox("¿Estás seguro que deseas alquilar el vehículo?", "Si/No")
        If resultado = vbYes Then

            'Actualiza la Reserva para que sea un ALQUILER, con NroChasis = al seleccionado, fechaalquilerinicio = hoy, fechareservafin = seleccionada (en caso que el cliente cambie su fecha reserva fin)
            conexion.EjecutarNonQuery("UPDATE Reserva SET nrochasis = '" + NroChasis + "', idsucursalllegada = '" + cbxSucLlegada.SelectedValue.ToString + "', fechaalquilerinicio = '" + DateTime.Today.Date.ToShortDateString + "', fechareservafin = '" + dtpFRfin.Value.ToShortDateString + "' WHERE idreserva = " + ReservaSeleccionada.IdReserva.ToString + " ")
            conexion.EjecutarNonQuery("UPDATE vehiculo set idsucursal = NULL WHERE nrochasis='" + NroChasis + "'")
            MsgBox("Alquiler Ingresado")
            frmMainMenu.CargarDatos()
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Hide()
    End Sub

End Class