'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerAlquileres
End Class


Partial Public Class frmMainMenu

    Public ReservaSeleccionadaFinalizarAlquiler As New ReservaSeleccionada

    Private Sub FechasCheckbox(sender As Object, e As EventArgs) Handles chbxFiltrarFechaFAlquileres.CheckedChanged, chbxFechaTramiteFAlquileres.CheckedChanged

        Select Case sender.Name
            Case "chbxFiltrarFechaFAlquileres"
                If sender.Checked Then
                    dtpDesdeFAlquileres.Enabled = True
                    dtpHastaFAlquileres.Enabled = True
                    lblDesdeFAlquiler.Enabled = True
                    lblHastaFAlquiler.Enabled = True

                Else
                    dtpDesdeFAlquileres.Enabled = False
                    dtpHastaFAlquileres.Enabled = False
                    lblDesdeFAlquiler.Enabled = False
                    lblHastaFAlquiler.Enabled = False
                End If

            Case "chbxFechaTramiteFAlquileres"
                If sender.Checked Then
                    dtpFechaTramiteFAlquileres.Enabled = True
                    lblFechaTramiteFAlquiler.Enabled = True
                Else
                    dtpFechaTramiteFAlquileres.Enabled = False
                    lblFechaTramiteFAlquiler.Enabled = False

                End If
        End Select

    End Sub


    Private Sub VaciarFiltroAlquiler(sender As Object, e As EventArgs) Handles lblBorrarCategoriaFAlquileres.Click, lblBorrarTipoFAlquileres.Click, lblBorrarKilomFAlquileres.Click, lblBorrarPartidaFAlquileres.Click, lblBorrarDestinoFAlquileres.Click

        Select Case sender.Name

            Case "lblBorrarCategoriaFAlquileres"
                If Not cbxCategoriaFAlquiler.SelectedItem Is Nothing Then
                    cbxCategoriaFAlquiler.SelectedItem = Nothing
                End If

            Case "lblBorrarTipoFAlquileres"
                If Not cbxSucursalPartidaFAlquileres.SelectedItem Is Nothing Then
                    cbxSucursalPartidaFAlquileres.SelectedItem = Nothing
                End If

            Case "lblBorrarKilomFAlquileres"
                If Not cbxKilometrajeFAlquileres.SelectedItem Is Nothing Then
                    cbxKilometrajeFAlquileres.SelectedItem = Nothing
                End If

            Case "lblBorrarPartidaFAlquileres"
                If Not cbxSucursalPartidaFAlquileres.SelectedItem Is Nothing Then
                    cbxSucursalPartidaFAlquileres.SelectedItem = Nothing
                End If

            Case "lblBorrarDestinoFAlquileres"
                If Not cbxSucursalDestinoFAlquileres.SelectedItem Is Nothing Then
                    cbxSucursalDestinoFAlquileres.SelectedItem = Nothing
                End If

        End Select
    End Sub

    Private Sub FiltrosAlquiler(sender As Object, e As EventArgs) Handles txtDocumentoFAlquileres.TextChanged, txtCostoFAlquileres.TextChanged, txtUsuarioFAlquileres.TextChanged, cbxCategoriaFAlquiler.SelectionChangeCommitted, cbxTipoFAlquileres.SelectionChangeCommitted, cbxKilometrajeFAlquileres.SelectionChangeCommitted, cbxSucursalDestinoFAlquileres.SelectionChangeCommitted, cbxSucursalPartidaFAlquileres.SelectionChangeCommitted, lblBorrarCategoriaFAlquileres.Click, lblBorrarKilomFAlquileres.Click, lblBorrarDestinoFAlquileres.Click, lblBorrarPartidaFAlquileres.Click, lblBorrarTipoFAlquileres.Click, chbxFiltrarFechaFAlquileres.CheckedChanged, chbxFechaTramiteFAlquileres.CheckedChanged, dtpDesdeFAlquileres.ValueChanged, dtpHastaFAlquileres.ValueChanged, dtpFechaTramiteFAlquileres.ValueChanged, chboxAlquileresProceso.CheckedChanged

        Try
            Dim filtrado As String

            filtrado = "nrodocumento LIKE '" + txtDocumentoFAlquileres.Text.ToString + "%' AND Convert(costototal, System.String) LIKE '" + txtCostoFAlquileres.Text.ToString + "%' AND usuarioempleado LIKE '%" + txtUsuarioFAlquileres.Text + "%'" + TipoFiltroAlquiler(chbxFiltrarFechaFAlquileres) + TipoFiltroAlquiler(chbxFechaTramiteFAlquileres) + TipoFiltroAlquiler(chboxAlquileresProceso) + TipoFiltro(cbxCategoriaFAlquiler, "idcategoria") + TipoFiltro(cbxTipoFAlquileres, "idtipo") + TipoFiltro(cbxSucursalDestinoFAlquileres, "idsucllegada") + TipoFiltro(cbxSucursalPartidaFAlquileres, "idsucsalida") + TipoFiltro(cbxKilometrajeFAlquileres, "idcantidadkm")

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
                    AmaranthMessagebox("No puede finalizar alquileres que terminen en otra sucursal. Modifique el alquiler de ser necesario.", "Error", Me)
                End If
            Else
                AmaranthMessagebox("Solo pueden finalizar alquileres que esten activos.", "Error", Me)
            End If
        End If


    End Sub

    Private Function TipoFiltroAlquiler(chbx As CheckBox) As String
        Select Case chbx.Name
            Case "chboxAlquileresProceso"
                If chboxAlquileresProceso.Checked = True Then
                    Return "AND fechaalquilerfin = 'En proceso'"
                Else
                    Return ""
                End If
            Case "chbxFechaTramiteFAlquileres"
                If chbxFechaTramiteFAlquileres.Checked = True Then
                    Return " AND fechatramitef = '" + dtpFechaTramiteFAlquileres.Value.ToString("dd/MM/yyyy") + "'"
                Else
                    Return ""
                End If

            Case "chbxFiltrarFechaFAlquileres"
                If chbxFiltrarFechaFAlquileres.Checked = True Then
                    Return " And fechaalquilerinicio >= '" + dtpDesdeFAlquileres.Value.ToString("dd/MM/yyyy HH:mm") + "' AND fechaalquilerfin < '" + dtpHastaFAlquileres.Value.ToString("dd/MM/yyyy HH:mm") + "'"
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
            AmaranthMessagebox("Alquiler modificado correctamente", "Continuar", Me)
            RecargarDatos(dgvAlquileres)

        Else
            AmaranthMessagebox("Modifique algo", "Advertencia", Me)
        End If

    End Sub



End Class