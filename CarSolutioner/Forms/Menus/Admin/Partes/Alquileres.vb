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

    Private Sub TerminarAlquiler(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAlquileres.CellMouseDoubleClick

        Dim selectedRow As DataGridViewRow = dgvAlquileres.CurrentRow

        If selectedRow.Cells("idestado").Value = 1 Then
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
            TerminarAlquiler.ShowDialog()
        Else
            AmaranthMessagebox("Solo pueden finalizar alquileres que esten activos.", "Error")
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
End Class