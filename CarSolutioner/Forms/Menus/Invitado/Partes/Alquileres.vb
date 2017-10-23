'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerAlquileresInvitado
End Class


Partial Public Class frmMainMenuInvitado

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

        Dim TerminarAlquiler As New FinalizarAlquiler(ReservaSeleccionadaFinalizarAlquiler)
        TerminarAlquiler.ShowDialog()

        'If selectedRow.Cells("idestadoreserva").Value = 1 Then
        '    If selectedRow.Cells("fechareservainicio").Value < Date.Now Then
        '        If ((selectedRow.Cells("fechareservainicio").Value >= Date.Now) Or ((selectedRow.Cells("fechareservainicio").Value >= Date.Now And selectedRow.Cells("fechareservainicio").Value <= ((Date.Now).AddHours(6))))) Then


        '            frmAlquilar.ShowDialog()

        '        Else
        '            Dim Diferencia As Integer = Math.Truncate((Date.Now - Date.Parse(selectedRow.Cells("fechareservainicio").Value.ToString)).TotalHours)


        '            Dim resultado As DialogResult = AmaranthMessagebox("Esta reserva era para hace más de " + Diferencia.ToString + " horas atrás. ¿Está seguro que quiere realizar el Alquiler?", "Si/No")
        '            If resultado = vbYes Then
        '                ReservaSeleccionadaAlquiler.IdReserva = selectedRow.Cells("idreserva").Value.ToString
        '                ReservaSeleccionadaAlquiler.IdCliente = selectedRow.Cells("idpersonareserva").Value.ToString
        '                ReservaSeleccionadaAlquiler.FechaReservaInicio = selectedRow.Cells("fechareservainicio").Value.ToString
        '                ReservaSeleccionadaAlquiler.FechaReservaFin = selectedRow.Cells("fechareservafin").Value.ToString
        '                ReservaSeleccionadaAlquiler.IdCantKM = selectedRow.Cells("idcantidadkm").Value.ToString
        '                ReservaSeleccionadaAlquiler.CostoTotal = selectedRow.Cells("costototalres").Value.ToString
        '                ReservaSeleccionadaAlquiler.FechaTramite = selectedRow.Cells("fechatramite").Value.ToString
        '                ReservaSeleccionadaAlquiler.NomCliente = selectedRow.Cells("nombreapellido").Value.ToString
        '                ReservaSeleccionadaAlquiler.IdCategoria = selectedRow.Cells("idcategoriareserva").Value.ToString
        '                ReservaSeleccionadaAlquiler.IdTipo = selectedRow.Cells("idtiporeserva").Value.ToString
        '                ReservaSeleccionadaAlquiler.IdSucursalPartida = selectedRow.Cells("idsucursalsalida").Value.ToString
        '                ReservaSeleccionadaAlquiler.IdSucursalDestino = selectedRow.Cells("idsucursalllegada").Value.ToString
        '                ReservaSeleccionadaAlquiler.UsuarioEmpleado = selectedRow.Cells("usuarioempleado").Value.ToString
        '                frmAlquilar.ShowDialog()
        '            End If
        '        End If
        '    Else
        '        AmaranthMessagebox("Solo puede alquilar reservas que sean para hoy.", "Error")
        '    End If


        'Else
        '    AmaranthMessagebox("Solo puede alquilar reservas activas.", "Error")
        'End If



    End Sub

End Class