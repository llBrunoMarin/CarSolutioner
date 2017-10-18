Public Class frmAlquilar

    Dim ReservaSeleccionada As ReservaSeleccionada = frmMainMenu.ReservaSeleccionadaAlquiler

    'Agregar resalquiler fin para cambiar con la q este en el form, por si la quiere cambiar 
    Private Sub Alquilar_Activated(sender As Object, e As EventArgs) Handles Me.Load

        'Rellenamos el DataGridView con los autos disponibles en ese momento, en esa sucursal, que no estén en mantenimiento
        Dim sentencia As String = "SELECT  V.*, Ma.nombre marca, Ma.idmarca, Mo.nombre modelo, T.nombre tipo, T.idtipo, C.nombre categoria, S.nombre Sucursal From Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S Where V.idsucursal = '" + ReservaSeleccionada.IdSucursalPartida.ToString + "' AND V.idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "' AND Mo.idtipo = '" + ReservaSeleccionada.IdTipo.ToString + "' AND V.idcategoria = C.idcategoria And V.idmodelo = Mo.idmodelo And Mo.Idmarca = Ma.Idmarca And Mo.Idtipo = T.idtipo And V.idsucursal = S.idsucursal And V.estado = 't' And  V.nrochasis Not IN (Select nrochasis FROM Mantenimiento WHERE fechainicio >=  TO_DATE('" + ReservaSeleccionada.FechaReservaInicio.ToString("dd/MM/yyyy HH:mm") + "', '%d/%m/%Y %H:%M') OR fechafin <= TO_DATE('" + ReservaSeleccionada.FechaReservaFin.ToString("dd/MM/yyyy HH:mm") + "', '%d/%m/%Y %H:%M')    )"
        Dim AutosDisponibles As DataTable = conexion.EjecutarSelect(sentencia)
        If AutosDisponibles.Rows.Count = 0 Then
            AmaranthMessagebox("No hay vehiculos disponibles para hoy con esas características. Por favor, búsque los disponibles para hoy y modifique la reserva de manera acorde.", "Advertencia")
            Me.Dispose()
        Else
            conexion.RellenarDataGridView(dgvAlquilar, "", AutosDisponibles)

            CargarDatosComboBox(cbxSucLlegada, conexion.Sucursales, "nombre", "idsucursal")
            cbxSucLlegada.SelectedValue = ReservaSeleccionada.IdSucursalDestino

            CargarDatosComboBox(cbxKilometraje, conexion.Kilometros, "km", "id")
            cbxKilometraje.SelectedValue = ReservaSeleccionada.IdCantKM
            cbxKilometraje.Enabled = False

            'estos llenan los datetime picker
            'TODO: LAS FECHAS DE ALQUILER NO SE DEBEN SETEAR ASÍ
            dtpFRInicio.Value = ReservaSeleccionada.FechaReservaInicio
            dtpFRfin.Value = ReservaSeleccionada.FechaReservaFin
            dtpFRfin.MinDate = Date.Now.AddHours(24)
            dtpFAinicio.Value = Date.Now.ToString("dd/MM/yyyy HH:mm")

            lblTitulo.Text = "Vehiculos para la reserva de: " + ReservaSeleccionada.NomCliente
            txtTipo.Text = conexion.Tipos.Select("idtipo =" + ReservaSeleccionada.IdTipo.ToString() + "").CopyToDataTable.Rows(0)(1).ToString()
            txtCategoria.Text = conexion.Categorias.Select("idcategoria =" + ReservaSeleccionada.IdCategoria.ToString() + "").CopyToDataTable.Rows(0)(5).ToString()
            txtSucursal.Text = conexion.Sucursales.Select("idsucursal =" + ReservaSeleccionada.IdSucursalPartida.ToString() + "").CopyToDataTable.Rows(0)(1).ToString()
            txtCantidadDias.Text = (dtpFRfin.Value - dtpFAinicio.Value).Days.ToString
            numDescuentoCliente.Value = CargarDescuentoCliente(ReservaSeleccionada.IdCliente)
            txtCostoEsperado.Text = ReservaSeleccionada.CostoTotal.ToString

        End If

    End Sub

    Private Sub CalculoCosto(sender As Object, e As EventArgs) Handles dtpFRfin.ValueChanged, dtpFAinicio.ValueChanged, numDescuentoCliente.ValueChanged, numDescuentoReserva.ValueChanged

        Dim TarifaDiariaBase As Integer
        Dim TarifaDiariaKM As Integer
        Dim CostoReservaEstimado As Integer
        Dim DescuentoCalcCliente As Integer
        Dim DescuentoCalcReserva As Integer
        Dim CostoTotal As Integer

        Select Case ReservaSeleccionada.IdCantKM
            Case 1
                lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer un total de " + (150 * (dtpFRfin.Value - dtpFAinicio.Value).Days).ToString + " kilómetros en total de toda la reserva."
                TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(2).ToString)

            Case 2
                lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer un total de " + (300 * (dtpFRfin.Value - dtpFAinicio.Value).Days).ToString + " kilómetros en total de toda la reserva."
                TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(3).ToString)
            Case 3
                lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer los kilómetros que quiera en toda la reserva."
                TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(4).ToString)
        End Select


        CostoReservaEstimado = (TarifaDiariaBase + TarifaDiariaKM) * ((dtpFRfin.Value - dtpFAinicio.Value).Days)
        DescuentoCalcCliente = (CostoReservaEstimado * numDescuentoCliente.Value) / 100

        CostoTotal = CostoReservaEstimado - DescuentoCalcCliente

        DescuentoCalcReserva = (CostoTotal * numDescuentoReserva.Value) / 100
        CostoTotal = CostoTotal - DescuentoCalcReserva

        ReservaSeleccionada.CostoTotal = CostoTotal

        txtCostoEsperado.Text = CostoReservaEstimado.ToString()
        txtCostoTotalEsperado.Text = CostoTotal.ToString()
        txtCantidadDias.Text = (dtpFRfin.Value - dtpFAinicio.Value).Days.ToString

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
            conexion.EjecutarNonQuery("UPDATE Reserva SET nrochasis = '" + NroChasis + "', idsucursalllegada = '" + cbxSucLlegada.SelectedValue.ToString + "', fechaalquilerinicio = '" + Date.Now.Date.ToString("yyyy-MM-dd HH:mm") + "', fechareservafin = '" + dtpFRfin.Value.ToString("yyyy-MM-dd HH:mm") + "' WHERE idreserva = " + ReservaSeleccionada.IdReserva.ToString + " ")
            conexion.EjecutarNonQuery("UPDATE vehiculo set idsucursal = NULL WHERE nrochasis='" + NroChasis + "'")
            MsgBox("Alquiler Ingresado")
            Me.Dispose()
            frmMainMenu.CargarDatos()


        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub


    Private Function CargarDescuentoCliente(id As Integer) As Integer
        Return CInt(conexion.EjecutarSelect("SELECT porcdescuento FROM Cliente WHERE idpersona = '" + id.ToString + "'").Rows(0)(0).ToString)
    End Function

    Private Sub btnDescuentoCliente_Click(sender As Object, e As EventArgs) Handles btnDescuentoCliente.Click
        If Autorizar() = vbYes Then

            Dim descuento As New DescuentoPersonalCliente(ReservaSeleccionada.IdCliente)
            descuento.ShowDialog()
            numDescuentoCliente.Enabled = True
            numDescuentoCliente.Value = CargarDescuentoCliente(ReservaSeleccionada.IdCliente)
            numDescuentoCliente.Enabled = False
        Else

        End If
    End Sub

    Private Sub btnDescuentoReserva_Click(sender As Object, e As EventArgs) Handles btnDescuentoReserva.Click
        If Autorizar() = vbYes Then
            numDescuentoReserva.Enabled = True
            lblDescuentoReserva.Text = "(Haga click para aplicar descuento) " + vbNewLine + " Escriba un numero y presione Enter"
        End If
    End Sub
End Class