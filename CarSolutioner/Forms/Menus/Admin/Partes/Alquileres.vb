'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerAlquileres
End Class


Partial Public Class frmMainMenu

    Public ReservaSeleccionadaFinalizarAlquiler As New ReservaSeleccionada

    Private Sub FiltrosAlquiler(sender As Object, e As EventArgs) Handles txtDocumFRes.TextChanged, txtCostoTotalFReserva.TextChanged, txtUsuarioFReserva.TextChanged, cbxCategoriaFRes.SelectionChangeCommitted, cbxTipoFRes.SelectionChangeCommitted, cbxKilomFRes.SelectionChangeCommitted, cbxSucLlegFRes.SelectionChangeCommitted, cbxSucSalFres.SelectionChangeCommitted, lblBorrarCategoriaFReserva.Click, lblBorrarKMFReserva.Click, lblBorrarSucLlegadaFReserva.Click, lblBorrarSucSalidaFReserva.Click, lblBorrarTipoFReserva.Click, chboxFechaFRes.CheckedChanged, chboxFechaTramiteFReserva.CheckedChanged, dtpDesdeFReserva.ValueChanged, dtpHastaFReserva.ValueChanged, dtpFechaTramiteFReserva.ValueChanged, chboxVerHoyFReserva.CheckedChanged, chboxInactivasFReserva.CheckedChanged

        Try
            Dim filtrado As String
            filtrado = ""
            'filtrado = "nrodocumento LIKE '" + txtDocumFRes.Text.ToString + "%' AND Convert(costototal, System.String) LIKE '%" + txtCostoTotalFReserva.Text.ToString + "%' AND usuarioempleado LIKE '%" + txtUsuarioFReserva.Text + "%'" + TipoFiltroReserva(chboxFechaFRes) + TipoFiltroReserva(chboxFechaTramiteFReserva) + TipoFiltroReserva(chboxInactivasFReserva) + TipoFiltroReserva(chboxVerHoyFReserva) + TipoFiltro(cbxCategoriaFRes, "idcategoria") + TipoFiltro(cbxTipoFRes, "idtipo") + TipoFiltro(cbxSucLlegFRes, "idsucursalllegada") + TipoFiltro(cbxSucSalFres, "idsucursalsalida") + TipoFiltro(cbxKilomFRes, "idcantidadkm")

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
            AmaranthMessagebox("Solo puede finalizar alquileres activos.", "Error")
        End If


    End Sub

End Class