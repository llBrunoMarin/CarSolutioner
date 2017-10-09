'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerReservas
End Class


Partial Public Class frmMainMenu
    Public ReservaSeleccionada As New ReservaSeleccionada()

    Private Sub EstadoFechas(sender As Object, e As EventArgs) Handles chboxFechaFRes.CheckedChanged, chboxFechaTramiteFReserva.CheckedChanged

        Select Case sender.Name
            Case "chboxFechaFRes"
                If sender.Checked = True Then

                    dtpDesdeFReserva.Enabled = False
                    dtpHastaFReserva.Enabled = False
                    lblDesde.Enabled = False
                    lblHasta.Enabled = False
                Else
                    dtpDesdeFReserva.Enabled = True
                    dtpHastaFReserva.Enabled = True
                    lblDesde.Enabled = True
                    lblHasta.Enabled = True
                End If

            Case "chboxFechaTramiteFReserva"
                If sender.Checked = True Then
                    dtpFechaTramiteFReserva.Enabled = True
                    lblFechaTramite.Enabled = True
                Else
                    dtpFechaTramiteFReserva.Enabled = False
                    lblFechaTramite.Enabled = False
                End If
        End Select

    End Sub
    Private Sub VaciarFiltrosReserva(sender As Object, e As EventArgs) Handles lblBorrarCategoriaFReserva.Click, lblBorrarKMFReserva.Click, lblBorrarSucLlegadaFReserva.Click, lblBorrarSucSalidaFReserva.Click, lblBorrarTipoFReserva.Click
        Select Case sender.Name

            Case "lblBorrarCategoriaFReserva"
                If Not cbxCategoriaFRes.SelectedItem Is Nothing Then
                    cbxCategoriaFRes.SelectedItem = Nothing
                End If

            Case "lblBorrarKMFReserva"
                If Not cbxKilomFRes.SelectedItem Is Nothing Then
                    cbxKilomFRes.SelectedItem = Nothing
                End If

            Case "lblBorrarSucLlegadaFReserva"
                If Not cbxSucLlegFRes.SelectedItem Is Nothing Then
                    cbxSucLlegFRes.SelectedItem = Nothing
                End If

            Case "lblBorrarSucSalidaFReserva"
                If Not cbxSucSalFres.SelectedItem Is Nothing Then
                    cbxSucSalFres.SelectedItem = Nothing
                End If

            Case "lblBorrarTipoFReserva"
                If Not cbxTipoFRes.SelectedItem Is Nothing Then
                    cbxTipoFRes.SelectedItem = Nothing
                End If

        End Select
    End Sub

    Private Sub FiltrosReserva(sender As Object, e As EventArgs) Handles txtDocumFRes.TextChanged, txtCostoTotalFReserva.TextChanged, txtUsuarioFReserva.TextChanged, cbxCategoriaFRes.SelectionChangeCommitted, cbxTipoFRes.SelectionChangeCommitted, cbxKilomFRes.SelectionChangeCommitted, cbxSucLlegFRes.SelectionChangeCommitted, cbxSucSalFres.SelectionChangeCommitted, lblBorrarCategoriaFReserva.Click, lblBorrarKMFReserva.Click, lblBorrarSucLlegadaFReserva.Click, lblBorrarSucSalidaFReserva.Click, lblBorrarTipoFReserva.Click ', chboxFechaFRes.CheckedChanged, chboxFechaTramiteFReserva.CheckedChanged, dtpDesdeFReserva.ValueChanged, dtpHastaFReserva.ValueChanged, dtpFechaTramiteFReserva.ValueChanged

        Dim filtro As String

        'Si quiero filtrar por fecha:
        If chboxFechaFRes.Checked = False Then
            'Si quiero filtrar por fecha de Tramite
            If chboxFechaTramiteFReserva.Checked = True Then
                filtro = "nrodocumento LIKE '" + txtDocumFRes.Text.ToString + "%' AND Convert(costototal, System.String) LIKE '%" + txtCostoTotalFReserva.Text.ToString + "%' AND usuarioempleado LIKE '%" + txtUsuarioFReserva.Text + "%' AND fechatramite = '" + dtpFechaTramiteFReserva.Value.ToShortDateString + "' AND fechareservainicio > '" + dtpDesdeFReserva.Value.ToShortDateString + "' AND fechareservafin < '" + dtpHastaFReserva.Value.ToShortDateString + "' " + TipoFiltro(cbxCategoriaFRes, "idcategoria") + TipoFiltro(cbxTipoFRes, "idtipo") + TipoFiltro(cbxSucLlegFRes, "idsucursalllegada") + TipoFiltro(cbxSucSalFres, "idsucursalsalida") + TipoFiltro(cbxKilomFRes, "idcantidadkm")
                dgvReservas.DataSource.Filter = filtro

                'Si quiero por fecha pero no por fecha de Trámite:
            Else
                filtro = "nrodocumento LIKE '" + txtDocumFRes.Text.ToString + "%' AND Convert(costototal, System.String) LIKE '%" + txtCostoTotalFReserva.Text.ToString + "%' AND usuarioempleado LIKE '%" + txtUsuarioFReserva.Text + "%' AND fechareservainicio > '" + dtpDesdeFReserva.Value.ToShortDateString + "' AND fechareservafin < '" + dtpHastaFReserva.Value.ToShortDateString + "'" + TipoFiltro(cbxCategoriaFRes, "idcategoria") + TipoFiltro(cbxTipoFRes, "idtipo") + TipoFiltro(cbxSucLlegFRes, "idsucursalllegada") + TipoFiltro(cbxSucSalFres, "idsucursalsalida") + TipoFiltro(cbxKilomFRes, "idcantidadkm")
                dgvReservas.DataSource.Filter = filtro
            End If

            'Si no quiero filtrar por fecha
        Else
            'Pero si por fecha tramite
            If chboxFechaTramiteFReserva.Checked = True Then

                filtro = "nrodocumento LIKE '" + txtDocumFRes.Text.ToString + "%' AND Convert(costototal, System.String) LIKE '%" + txtCostoTotalFReserva.Text.ToString + "%' AND usuarioempleado LIKE '%" + txtUsuarioFReserva.Text + "%' AND fechatramite = '" + dtpFechaTramiteFReserva.Value.ToShortDateString + "' " + TipoFiltro(cbxCategoriaFRes, "idcategoria") + TipoFiltro(cbxTipoFRes, "idtipo") + TipoFiltro(cbxSucLlegFRes, "idsucursalllegada") + TipoFiltro(cbxSucSalFres, "idsucursalsalida") + TipoFiltro(cbxKilomFRes, "idcantidadkm")
                dgvReservas.DataSource.Filter = filtro

                'Y no filtrar por fecha tramite
            Else

                filtro = "nrodocumento LIKE '" + txtDocumFRes.Text.ToString + "%' AND Convert(costototal, System.String) LIKE '%" + txtCostoTotalFReserva.Text.ToString + "%' AND usuarioempleado LIKE '%" + txtUsuarioFReserva.Text + "%' " + TipoFiltro(cbxCategoriaFRes, "idcategoria") + TipoFiltro(cbxTipoFRes, "idtipo") + TipoFiltro(cbxSucLlegFRes, "idsucursalllegada") + TipoFiltro(cbxSucSalFres, "idsucursalsalida") + TipoFiltro(cbxKilomFRes, "idcantidadkm")
                dgvReservas.DataSource.Filter = filtro
            End If

        End If
    End Sub

    Public Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvReservas.CellMouseDoubleClick

        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

            Dim selectedRow = dgvReservas.Rows(e.RowIndex)

            ReservaSeleccionada.IdReserva = selectedRow.Cells("idreserva").Value.ToString
            ReservaSeleccionada.IdCliente = selectedRow.Cells("idpersonareserva").Value.ToString
            ReservaSeleccionada.FechaReservaInicio = selectedRow.Cells("fechareservainicio").Value.ToString
            ReservaSeleccionada.FechaReservaFin = selectedRow.Cells("fechareservafin").Value.ToString
            ReservaSeleccionada.IdCantKM = selectedRow.Cells("idcantidadkm").Value.ToString
            ReservaSeleccionada.CostoTotal = selectedRow.Cells("costototalres").Value.ToString
            ReservaSeleccionada.FechaTramite = selectedRow.Cells("fechatramite").Value.ToString
            ReservaSeleccionada.NomCliente = selectedRow.Cells("nombreapellido").Value.ToString
            ReservaSeleccionada.IdCategoria = selectedRow.Cells("idcategoriareserva").Value.ToString
            ReservaSeleccionada.IdTipo = selectedRow.Cells("idtiporeserva").Value.ToString
            ReservaSeleccionada.IdSucursalPartida = selectedRow.Cells("idsucursalsalida").Value.ToString
            ReservaSeleccionada.IdSucursalDestino = selectedRow.Cells("idsucursalllegada").Value.ToString
            ReservaSeleccionada.UsuarioEmpleado = selectedRow.Cells("usuarioempleado").Value.ToString
            frmAlquilar.ShowDialog()

        End If
    End Sub

    Private Sub btnVaciarFiltrosReservaBoton(sender As Object, e As EventArgs) Handles btnVaciarFRes.Click
        For Each item In pnlFReserva.Controls

            If TypeOf item Is TextBox Then
                item.text = ""
            End If

            If TypeOf item Is ComboBox Then
                item.SelectedItem = Nothing
            End If

            If TypeOf item Is NumericUpDown Then
                DirectCast(item, NumericUpDown).Value = Nothing
            End If

            If TypeOf item Is Label Then

                VaciarFiltrosReserva(item, New EventArgs)

            End If
        Next
    End Sub
    Private Sub btnBajaBRes_Click(sender As Object, e As EventArgs) Handles btnBajaBRes.Click
        Dim reservaseleccionadaid As String
        reservaseleccionadaid = dgvReservas.CurrentRow.Cells("idreserva").Value.ToString
        If conexion.EjecutarNonQuery("Update reserva set estado = 2 where idreserva = " + reservaseleccionadaid.ToString + "") = True Then
            MsgBox("Reserva eliminada.", MsgBoxStyle.Information, "Notificacion")
            RecargarDatos(dgvReservas)
        Else
            MsgBox("No se pudo eliminar", MsgBoxStyle.Critical, "Notificacion")
        End If

    End Sub

    Private Sub CalculoCostoReserva(sender As Object, e As EventArgs) Handles cbxCategoriaARes.SelectionChangeCommitted, cbxKmARes.SelectionChangeCommitted, dtpInicioARes.ValueChanged, dtpFinARes.ValueChanged

        'Valores Seleccionados
        Dim IdCategoria As Integer = cbxCategoriaARes.SelectedValue
        Dim IdKm As Integer = cbxKilomFRes.SelectedValue
        Dim FechaInicio As Date = dtpInicioARes.Value
        Dim FechaFin As Date = dtpFinARes.Value
        Dim CantidadDias As Integer = (FechaFin - FechaInicio).Days

        Dim TarifaDiariaBase As Integer
        Dim TarifaDiariaKM As Integer
        Dim CostoTotal As Integer

        Select Case IdKm
            Case 1
                TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + IdCategoria.ToString + "'").CopyToDataTable.Rows(0).Item("tarifadiariabase").ToString)
                TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + IdCategoria.ToString + "'").CopyToDataTable.Rows(0).Item("tarifax150kmdia").ToString)
            Case 2
                TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + IdCategoria.ToString + "'").CopyToDataTable.Rows(0).Item("tarifadiariabase").ToString)
                TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + IdCategoria.ToString + "'").CopyToDataTable.Rows(0).Item("tarifax150kmdia").ToString)
            Case 3
                TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + IdCategoria.ToString + "'").CopyToDataTable.Rows(0).Item("tarifadiariabase").ToString)
                TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + IdCategoria.ToString + "'").CopyToDataTable.Rows(0).Item("tarifax150kmdia").ToString)

        End Select

        CostoTotal = (TarifaDiariaBase + TarifaDiariaKM) * CantidadDias
        txtCostoTotalAReserva.Text = CantidadDias.ToString()
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

End Class
