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

                    dtpDesdeFReserva.Enabled = True
                    dtpHastaFReserva.Enabled = True
                    lblDesde.Enabled = True
                    lblHasta.Enabled = True
                Else
                    dtpDesdeFReserva.Enabled = False
                    dtpHastaFReserva.Enabled = False
                    lblDesde.Enabled = False
                    lblHasta.Enabled = False
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

    Private Sub FiltrosReserva(sender As Object, e As EventArgs) Handles txtDocumFRes.TextChanged, txtCostoTotalFReserva.TextChanged, txtUsuarioFReserva.TextChanged, cbxCategoriaFRes.SelectionChangeCommitted, cbxTipoFRes.SelectionChangeCommitted, cbxKilomFRes.SelectionChangeCommitted, cbxSucLlegFRes.SelectionChangeCommitted, cbxSucSalFres.SelectionChangeCommitted, lblBorrarCategoriaFReserva.Click, lblBorrarKMFReserva.Click, lblBorrarSucLlegadaFReserva.Click, lblBorrarSucSalidaFReserva.Click, lblBorrarTipoFReserva.Click, chboxFechaFRes.CheckedChanged, chboxFechaTramiteFReserva.CheckedChanged, dtpDesdeFReserva.ValueChanged, dtpHastaFReserva.ValueChanged, dtpFechaTramiteFReserva.ValueChanged, chboxVerHoyFReserva.CheckedChanged, chboxInactivasFReserva.CheckedChanged

        Try
            Dim filtrado As String
            filtrado = "nrodocumento LIKE '" + txtDocumFRes.Text.ToString + "%' AND Convert(costototal, System.String) LIKE '%" + txtCostoTotalFReserva.Text.ToString + "%' AND usuarioempleado LIKE '%" + txtUsuarioFReserva.Text + "%'" + TipoFiltroReserva(chboxFechaFRes) + TipoFiltroReserva(chboxFechaTramiteFReserva) + TipoFiltroReserva(chboxInactivasFReserva) + TipoFiltroReserva(chboxVerHoyFReserva)

            dgvReservas.DataSource.Filter = filtrado

        Catch ex As NullReferenceException

        End Try

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

        If Not dtpFinARes.Value < dtpInicioARes.Value Then
            'Valores Seleccionados
            Dim IdCategoria As Integer = cbxCategoriaARes.SelectedValue
            Dim IdKm As Integer = cbxKmARes.SelectedValue
            Dim FechaInicio As Date = dtpInicioARes.Value
            Dim FechaFin As Date = dtpFinARes.Value
            Dim CantidadDias As Integer = (FechaFin - FechaInicio).Days + 1

            Dim TarifaDiariaBase As Integer
            Dim TarifaDiariaKM As Integer
            Dim CostoTotal As Integer

            Select Case IdKm
                Case 1
                    TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                    TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(2).ToString)
                Case 2
                    TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                    TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(3).ToString)
                Case 3
                    TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                    TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(4).ToString)

            End Select

            CostoTotal = (TarifaDiariaBase + TarifaDiariaKM) * CantidadDias
            txtCostoTotalAReserva.Text = CostoTotal.ToString()
        Else
            AmaranthMessagebox("La fecha fin no puede ser menor a la de Inicio.", "Error")
        End If

    End Sub

    Private Sub AgregarReserva(sender As Object, e As EventArgs) Handles btnReservarARes.Click
        If Not dtpFinARes.Value < dtpInicioARes.Value Then
            Dim Persona As DataTable = conexion.EjecutarSelect("SELECT idpersona FROM Cliente WHERE nrodocumento = '" + txtDocumARes.Text + "'")

            'Si la persona existe
            If Persona.Rows.Count <> 0 Then

                Dim IdPersona As String = Persona.Rows(0)(0).ToString
                Dim sentencia As String
                sentencia = "SELECT idreserva FROM Reserva WHERE idpersona = '" + IdPersona + "' AND (('" + dtpInicioARes.Value.ToString("dd/MM/yyyy hh:mm") + "' > fechareservainicio AND '" + dtpInicioARes.Value.ToString("dd/MM/yyyy hh:mm") + "' < fechareservafin) OR ('" + dtpFinARes.Value.ToString("dd/MM/yyyy hh:mm") + "' > fechareservainicio AND '" + dtpFinARes.Value.ToString("dd/MM/yyyy hh:mm") + "' < fechareservafin)) "
                If conexion.EjecutarSelect(sentencia).Rows.Count <> 0 Then

                Else
                    AmaranthMessagebox("Ese cliente ya tiene una reserva activa.", "Error")
                End If
            End If

        Else
            AmaranthMessagebox("La fecha fin no puede ser menor a la de Inicio.", "Error")
        End If

    End Sub


    Private Function TipoFiltroReserva(chbx As CheckBox) As String
        Select Case chbx.Name
            Case "chboxFechaFRes"
                If chboxFechaFRes.Checked = True Then
                    Return " AND fechareservainicio >= '" + dtpDesdeFReserva.Value.ToString("dd/MM/yyyy hh:mm") + "' AND fechareservafin < '" + dtpHastaFReserva.Value.ToString("dd/MM/yyyy hh:mm") + "'"
                Else
                    Return ""
                End If

            Case "chboxFechaTramiteFReserva"
                If chboxFechaTramiteFReserva.Checked = True Then
                    Return " AND fechatramite = '" + dtpFechaTramiteFReserva.Value.ToString("dd/MM/yyyy hh:mm") + "'"
                Else
                    Return ""
                End If


            Case "chboxInactivasFReserva"
                If chboxInactivasFReserva.Checked = True Then
                    Return ""
                Else
                    Return " AND estado = 1"
                End If
            Case "chboxVerHoyFReserva"
                If chboxVerHoyFReserva.Checked = True Then
                    Return " AND fechareservainiciof = '" + Date.Today.ToString("dd/MM/yyyy") + "'"
                Else
                    Return ""
                End If

        End Select

        Return ""
    End Function
End Class
