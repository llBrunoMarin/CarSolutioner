'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerAlquileres
End Class


Partial Public Class frmMainMenu

    Public ReservaSeleccionadaFinalizarAlquiler As New ReservaSeleccionada

    Private Sub FiltrosAlquiler(sender As Object, e As EventArgs) Handles txtDocumFRes.TextChanged, txtCostoTotalFReserva.TextChanged, txtUsuarioFReserva.TextChanged, cbxCategoriaFRes.SelectionChangeCommitted, cbxTipoFRes.SelectionChangeCommitted, cbxKilomFRes.SelectionChangeCommitted, cbxSucLlegFRes.SelectionChangeCommitted, cbxSucSalFres.SelectionChangeCommitted, lblBorrarCategoriaFReserva.Click, lblBorrarKMFReserva.Click, lblBorrarSucLlegadaFReserva.Click, lblBorrarSucSalidaFReserva.Click, lblBorrarTipoFReserva.Click, chboxFechaFRes.CheckedChanged, chboxFechaTramiteFReserva.CheckedChanged, dtpDesdeFReserva.ValueChanged, dtpHastaFReserva.ValueChanged, dtpFechaTramiteFReserva.ValueChanged, chboxVerHoyFReserva.CheckedChanged, chboxInactivasFReserva.CheckedChanged

        Try
            Dim filtrado As String

            'filtrado = "nrodocumento LIKE '" + txtDocumentoFAlquileres.Text.ToString + "%' AND Convert(costototal, System.String) LIKE '%" + txtCostoFAlquileres.Text.ToString + "%' AND usuarioempleado LIKE '%" + txtUsuarioFAlquileres.Text + "%'" + TipoFiltroAlquiler(chbxFiltrarFechaFAlquileres) + TipoFiltroAlquiler(chbxFechaTramiteFAlquileres) + TipoFiltroAlquiler(chboxAlquileresProceso) + TipoFiltro(cbxCategoriaFAlquiler, "idcategoria") + TipoFiltro(cbxTipoFAlquileres, "idtipo") + TipoFiltro(cbxSucursalDestinoFAlquileres, "idsucursalllegada") + TipoFiltro(cbxSucursalPartidaFAlquileres, "idsucursalsalida") + TipoFiltro(cbxKilometrajeFAlquileres, "idcantidadkm")

            dgvAlquileres.DataSource.Filter = filtrado

        Catch ex As NullReferenceException

        End Try

    End Sub

    Private Sub TerminarAlquiler(sender As Object, e As EventArgs) Handles dgvAlquileres.CellMouseDoubleClick, btnFinalizarAlquiler.Click

        Dim selectedRow As DataGridViewRow

        If sender Is dgvAlquileres Then
            If DirectCast(e, DataGridViewCellMouseEventArgs).RowIndex >= 0 AndAlso DirectCast(e, DataGridViewCellMouseEventArgs).ColumnIndex >= 0 Then
                selectedRow = dgvAlquileres.Rows(DirectCast(e, DataGridViewCellMouseEventArgs).RowIndex)
            End If
        Else
            selectedRow = dgvAlquileres.CurrentRow
        End If


        If Not selectedRow Is Nothing Then
            If selectedRow.Cells("idestado").Value = 1 Then
                If selectedRow.Cells("idsucursalllegadaalq").Value = conexion.IdSucursalUsuario Then

                    ReservaSeleccionadaFinalizarAlquiler.IdReserva = selectedRow.Cells("idreservaalquiler").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.IdCliente = selectedRow.Cells("idpersonaalquiler").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.Matricula = selectedRow.Cells("matriculaalq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.FechaReservaInicio = selectedRow.Cells("fechareservainicioalq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.FechaReservaFin = selectedRow.Cells("fechareservafinalq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.FechaAlquilerInicio = selectedRow.Cells("fechaalquilerinicio").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.IdCantKM = selectedRow.Cells("cantidadkmalq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.CostoTotal = selectedRow.Cells("costototalalq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.FechaTramite = selectedRow.Cells("fechatramitealq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.NomCliente = selectedRow.Cells("nombreapellidoalq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.NroChasis = selectedRow.Cells("nrochasisalq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.IdCategoria = selectedRow.Cells("idcategoriaalq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.IdTipo = selectedRow.Cells("idtipoalq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.IdSucursalPartida = selectedRow.Cells("idsucursalsalidaalq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.IdSucursalDestino = selectedRow.Cells("idsucursalllegadaalq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.UsuarioEmpleado = selectedRow.Cells("usuarioempleadoalq").Value.ToString
                    ReservaSeleccionadaFinalizarAlquiler.DeducibleVehiculo = selectedRow.Cells("deduciblealq").Value

                    Dim TerminarAlquiler As New FinalizarAlquiler(ReservaSeleccionadaFinalizarAlquiler)
                    Using TerminarAlquiler
                        TerminarAlquiler.ShowDialog(Me)
                    End Using
                Else
                    AmaranthMessagebox("No puede finalizar alquileres que terminen en otra sucursal. Modifique el alquiler de ser necesario.", "Error")
                End If
            Else
                AmaranthMessagebox("Solo pueden finalizar alquileres que esten activos.", "Error")
            End If
        End If


    End Sub

    Private Function TipoFiltroAlquiler(chbx As CheckBox) As String
        Select Case chbx.Name
            Case "chboxAlquileresProceso"
                If chboxAlquileresProceso.Checked = True Then
                    Return " And fechaalquilerinicio >= '" + dtpDesdeFReserva.Value.ToString("dd/MM/yyyy HH:mm") + "' AND fechaalquilerfin = 'En proceso'"
                Else
                    Return ""
                End If
            Case "chboxAlquileresProceso"
                If chboxAlquileresProceso.Checked = True Then
                    Return " And fechaalquilerinicio >= '" + dtpDesdeFReserva.Value.ToString("dd/MM/yyyy HH:mm") + "' AND fechaalquilerfin = 'En proceso'"
                Else
                    Return ""
                End If
            Case "chbxFechaTramiteFAlquileres"
                If chbxFechaTramiteFAlquileres.Checked = True Then
                    Return " AND fechatramite = '" + dtpFechaTramiteFReserva.Value.ToString("dd/MM/yyyy HH:mm") + "'"
                Else
                    Return ""
                End If

            Case "chboxInactivasFReserva"
                If chboxInactivasFReserva.Checked = True Then
                    Return ""
                Else
                    Return " AND idestado = 1"
                End If

            Case "chboxVerHoyFReserva"
                If chboxVerHoyFReserva.Checked = True Then
                    Return " AND fechareservainiciof = '" + Date.Now.ToString("dd/MM/yyyy") + "'"
                Else
                    Return ""
                End If

        End Select

        Return ""
    End Function

    Private Sub CargarDatosAlquiler(sender As Object, e As EventArgs) Handles dgvAlquileres.SelectionChanged

        If Not IsNothing(dgvAlquileres.CurrentRow) Then
            Dim estadoAlquiler As String = dgvAlquileres.CurrentRow.Cells("estadoalq").Value.ToString()
            If (estadoAlquiler = "Inactiva" Or estadoAlquiler = "Anulada ") Then
                pnlMAlq.Enabled = False
                pnlFinAlq.Enabled = False
            Else
                pnlMAlq.Enabled = True
                pnlFinAlq.Enabled = True
            End If
            txtDocumentoMAlquileres.Text = dgvAlquileres.CurrentRow.Cells("nrodocumalq").Value.ToString()
            txtCostoMAlquileres.Text = dgvAlquileres.CurrentRow.Cells("costototalalq").Value.ToString
            txtNombreMAlq.Text = dgvAlquileres.CurrentRow.Cells("nombreapellidoalq").Value.ToString()
            cbxKilomMAlquileres.SelectedValue = dgvAlquileres.CurrentRow.Cells("cantidadkmalq").Value.ToString
            cbxDestinoMAlquileres.SelectedValue = dgvAlquileres.CurrentRow.Cells("idsucursalllegadaalq").Value.ToString()

        End If
    End Sub

    Private Sub ModificarAlquiler(sender As Object, e As EventArgs) Handles btnModificarAlquiler.Click

        Dim kilometrajeI As String = dgvAlquileres.CurrentRow.Cells("cantidadkmalq").Value.ToString
        Dim sucursalDestinoI As String = dgvAlquileres.CurrentRow.Cells("idsucursalllegadaalq").Value.ToString()
        Dim idreservaI As String = dgvAlquileres.CurrentRow.Cells("idreservaalquiler").Value.ToString()

        If Not (cbxKilomMAlquileres.SelectedValue.ToString = kilometrajeI And cbxDestinoMAlquileres.SelectedValue.ToString = sucursalDestinoI) Then

            conexion.EjecutarNonQuery("UPDATE reserva SET  cantidadkm = " + cbxKilomMAlquileres.SelectedValue.ToString + ",  idsucursalllegada = '" + cbxDestinoMAlquileres.SelectedValue.ToString + "' WHERE idreserva = " + idreservaI + " ")
            AmaranthMessagebox("Alquiler modificado correctamente", "Continuar")
            RecargarDatos(dgvAlquileres)

        Else
            AmaranthMessagebox("Modifique algo", "Advertencia")
        End If

    End Sub


End Class