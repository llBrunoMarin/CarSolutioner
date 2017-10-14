'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerReservas
End Class


Partial Public Class frmMainMenu

    Dim Semaforo As String = "Verde"

    Public ReservaSeleccionadaAlquiler As New ReservaSeleccionada()
    Public ReservaSeleccionadaReserva As New ReservaSeleccionada()

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
            filtrado = "nrodocumento LIKE '" + txtDocumFRes.Text.ToString + "%' AND Convert(costototal, System.String) LIKE '%" + txtCostoTotalFReserva.Text.ToString + "%' AND usuarioempleado LIKE '%" + txtUsuarioFReserva.Text + "%'" + TipoFiltroReserva(chboxFechaFRes) + TipoFiltroReserva(chboxFechaTramiteFReserva) + TipoFiltroReserva(chboxInactivasFReserva) + TipoFiltroReserva(chboxVerHoyFReserva) + TipoFiltro(cbxCategoriaFRes, "idcategoria") + TipoFiltro(cbxTipoFRes, "idtipo") + TipoFiltro(cbxSucLlegFRes, "idsucursalllegada") + TipoFiltro(cbxSucSalFres, "idsucursalsalida") + TipoFiltro(cbxKilomFRes, "idcantidadkm")

            dgvReservas.DataSource.Filter = filtrado

        Catch ex As NullReferenceException

        End Try

    End Sub

    Public Sub AlquilarReserva(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvReservas.CellMouseDoubleClick

        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

            Dim selectedRow = dgvReservas.Rows(e.RowIndex)

            ReservaSeleccionadaAlquiler.IdReserva = selectedRow.Cells("idreserva").Value.ToString
            ReservaSeleccionadaAlquiler.IdCliente = selectedRow.Cells("idpersonareserva").Value.ToString
            ReservaSeleccionadaAlquiler.FechaReservaInicio = selectedRow.Cells("fechareservainicio").Value.ToString
            ReservaSeleccionadaAlquiler.FechaReservaFin = selectedRow.Cells("fechareservafin").Value.ToString
            ReservaSeleccionadaAlquiler.IdCantKM = selectedRow.Cells("idcantidadkm").Value.ToString
            ReservaSeleccionadaAlquiler.CostoTotal = selectedRow.Cells("costototalres").Value.ToString
            ReservaSeleccionadaAlquiler.FechaTramite = selectedRow.Cells("fechatramite").Value.ToString
            ReservaSeleccionadaAlquiler.NomCliente = selectedRow.Cells("nombreapellido").Value.ToString
            ReservaSeleccionadaAlquiler.IdCategoria = selectedRow.Cells("idcategoriareserva").Value.ToString
            ReservaSeleccionadaAlquiler.IdTipo = selectedRow.Cells("idtiporeserva").Value.ToString
            ReservaSeleccionadaAlquiler.IdSucursalPartida = selectedRow.Cells("idsucursalsalida").Value.ToString
            ReservaSeleccionadaAlquiler.IdSucursalDestino = selectedRow.Cells("idsucursalllegada").Value.ToString
            ReservaSeleccionadaAlquiler.UsuarioEmpleado = selectedRow.Cells("usuarioempleado").Value.ToString
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

        chboxVerHoyFReserva.Checked = True
        chboxFechaFRes.Checked = False
        chboxFechaTramiteFReserva.Checked = False
    End Sub

    Private Sub btnBajaBRes_Click(sender As Object, e As EventArgs) Handles btnBajaBRes.Click
        Dim reservaseleccionadaid As String
        reservaseleccionadaid = dgvReservas.CurrentRow.Cells("idreserva").Value.ToString()

        If conexion.EjecutarNonQuery("Update reserva set estado = 3 where idreserva = " + reservaseleccionadaid.ToString() + "") = True Then
            RecargarDatos(dgvReservas)
            MsgBox("Reserva anulada satisfactoriamente.", MsgBoxStyle.Information, "Notificacion")

        Else
            MsgBox("No se pudo eliminar la reserva.", MsgBoxStyle.Critical, "Notificacion")
        End If

    End Sub

    Private Sub RellenarDatosReserva(sender As Object, e As EventArgs) Handles dgvReservas.SelectionChanged
        If Not IsNothing(dgvReservas.CurrentRow) Then

            txtDocumMReserva.Text = dgvReservas.CurrentRow.Cells("nrodocumentores").Value.ToString()
            cbxCategoriaMReserva.SelectedValue = dgvReservas.CurrentRow.Cells("idcategoriareserva").Value.ToString()
            cbxTipoMReserva.SelectedValue = dgvReservas.CurrentRow.Cells("idtiporeserva").Value.ToString()
            cbxKilomMReserva.SelectedValue = dgvReservas.CurrentRow.Cells("idcantidadkm").Value.ToString()
            txtCostoMReserva.Text = dgvReservas.CurrentRow.Cells("costototalres").Value.ToString()
            cbxSucursalSalidaMReserva.SelectedValue = dgvReservas.CurrentRow.Cells("idsucursalsalida").Value.ToString()
            cbxSucursalLlegadaMReserva.SelectedValue = dgvReservas.CurrentRow.Cells("idsucursalllegada").Value.ToString()
            Semaforo = "Rojo"
            dtpFechaFinMReserva.Value = dgvReservas.CurrentRow.Cells("fechareservafin").Value.ToString()
            dtpFechaInicioMReserva.Value = dgvReservas.CurrentRow.Cells("fechareservainicio").Value.ToString()
            Semaforo = "Verde"
            dtpFechaInicioMReserva.Value = dgvReservas.CurrentRow.Cells("fechareservainicio").Value.ToString()

        End If
    End Sub

    Private Sub CalculoCostoReservaModificar(sender As Object, e As EventArgs) Handles cbxCategoriaMReserva.SelectionChangeCommitted, cbxKilomMReserva.SelectionChangeCommitted, dtpFechaInicioMReserva.ValueChanged, dtpFechaFinMReserva.ValueChanged

        If Semaforo = "Verde" Then
            If Not dtpFechaFinMReserva.Value < dtpFechaInicioMReserva.Value Then
                'Valores Seleccionados
                Dim IdCategoria As Integer = cbxCategoriaMReserva.SelectedValue
                Dim IdKm As Integer = cbxKilomMReserva.SelectedValue
                Dim FechaInicio As Date = dtpFechaInicioMReserva.Value
                Dim FechaFin As Date = dtpFechaFinMReserva.Value
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
                txtCostoMReserva.Text = CostoTotal.ToString()
            Else
                AmaranthMessagebox("La fecha fin no puede ser menor a la de Inicio.", "Error")
            End If
        End If


    End Sub

    Private Sub AgregarReserva(sender As Object, e As EventArgs) Handles btnReservarARes.Click

        Dim fechaActual As Date
        fechaActual = Date.Today

        If Not ((dtpInicioARes.Value < fechaActual) Or (dtpFinARes.Value < fechaActual)) Then

            If Not dtpFinARes.Value < dtpInicioARes.Value Then

                Dim Persona As DataTable = conexion.EjecutarSelect("SELECT idpersona, nombre || ' ' || apellido nombreapellido, porcdescuento FROM Cliente WHERE nrodocumento = '" + txtDocumARes.Text + "' AND estado = 't'")

                'Si la persona existe
                If Persona.Rows.Count <> 0 Then

                    Dim IdPersona As String = Persona.Rows(0)(0).ToString
                    Dim NombreApellido As String = Persona.Rows(0)(1).ToString
                    Dim PorcDescuento As String = Persona.Rows(0)(2).ToString

                    'Si el cliente NO tiene reservas activas:
                    '
                    Dim sentencia As String = "SELECT idreserva FROM Reserva WHERE idpersona = '" + IdPersona + "' AND ((fechareservafin > '" + dtpInicioARes.Value.ToString("yyyy-MM-dd hh:mm") + "' AND fechareservainicio < '" + dtpInicioARes.Value.ToString("yyyy-MM-dd hh:mm") + "') OR (fechareservainicio > '" + dtpInicioARes.Value.ToString("yyyy-MM-dd hh:mm") + "' AND fechareservafin < '" + dtpFinARes.Value.ToString("yyyy-MM-dd hh:mm") + "') OR (fechareservainicio < '" + dtpFinARes.Value.ToString("yyyy-MM-dd hh:mm") + "' AND fechareservafin > '" + dtpFinARes.Value.ToString("yyyy-MM-dd hh:mm") + "'))"
                    If conexion.EjecutarSelect(sentencia).Rows.Count = 0 Then

                        ReservaSeleccionadaReserva.IdCliente = IdPersona
                        ReservaSeleccionadaReserva.FechaReservaInicio = dtpInicioARes.Value
                        ReservaSeleccionadaReserva.FechaReservaFin = dtpFinARes.Value
                        ReservaSeleccionadaReserva.IdCantKM = cbxKmARes.SelectedValue
                        ReservaSeleccionadaReserva.FechaTramite = Date.Today
                        ReservaSeleccionadaReserva.NomCliente = NombreApellido
                        ReservaSeleccionadaReserva.IdCategoria = cbxCategoriaARes.SelectedValue
                        ReservaSeleccionadaReserva.IdTipo = cbxTipoAReserva.SelectedValue
                        ReservaSeleccionadaReserva.IdSucursalPartida = cbxSucSalidaARes.SelectedValue
                        ReservaSeleccionadaReserva.IdSucursalDestino = cbxSucLlegadaARes.SelectedValue
                        ReservaSeleccionadaReserva.UsuarioEmpleado = conexion.Usuario
                        ReservaSeleccionadaReserva.DescuentoCliente = PorcDescuento

                        Reserva.ShowDialog()


                    Else
                        AmaranthMessagebox("Ese cliente ya tiene un alquiler o reserva activos para esas fechas.", "Error")
                    End If

                Else
                    AmaranthMessagebox("Ese cliente no está registrado o está inactivo.", "Error")
                End If

            Else
                AmaranthMessagebox("La fecha fin no puede ser menor a la de Inicio.", "Error")
                dtpInicioARes.Value = Date.Today
                dtpFinARes.Value = Date.Today
            End If

        Else
            AmaranthMessagebox("La fechas no puede ser menor a la de hoy", "Continuar")
        End If
    End Sub

    Private Sub ModificarReserva(sender As Object, e As EventArgs) Handles btnModificarReserva.Click

        Dim IdReserva As String
        IdReserva = dgvReservas.CurrentRow.Cells("idreserva").Value.ToString

        If Not dtpFechaFinMReserva.Value < dtpFechaInicioMReserva.Value Then

            Dim Persona As DataTable = conexion.EjecutarSelect("SELECT idpersona FROM Cliente WHERE nrodocumento = '" + txtDocumMReserva.Text + "'")

            'Si la persona existe
            If Persona.Rows.Count <> 0 Then

                Dim IdPersona As String = Persona.Rows(0)(0).ToString
                Dim sentencia As String

                'Si la persona no tiene ninguna reserva activa por esas fechas (exceptuando la que se va a modificar)
                sentencia = "SELECT idreserva FROM Reserva WHERE idreserva != '" + IdReserva + "' AND idpersona = '" + IdPersona + "' AND ((fechareservafin BETWEEN '" + dtpFechaInicioMReserva.Value.ToString("yyyy-MM-dd hh:mm") + "' AND '" + dtpFechaFinMReserva.Value.ToString("yyyy-MM-dd hh:mm") + "') OR (fechareservainicio BETWEEN '" + dtpFechaInicioMReserva.Value.ToString("yyyy-MM-dd hh:mm") + "' AND '" + dtpFechaFinMReserva.Value.ToString("yyyy-MM-dd hh:mm") + "') OR (fechareservainicio < '" + dtpFechaInicioMReserva.Value.ToString("yyyy-MM-dd hh:mm") + "' AND fechareservafin > '" + dtpFechaFinMReserva.Value.ToString("yyyy-MM-dd hh:mm") + "'))"
                If conexion.EjecutarSelect(sentencia).Rows.Count = 0 Then
                    Dim prueba As String
                    prueba = ("UPDATE RESERVA SET fechaalquilerinicio = NULL,
                                                  fechaalquilerfin = NULL, 
                                                  fechareservainicio = '" + dtpFechaInicioMReserva.Value.ToString("yyyy-MM-dd HH:mm") + "', 
                                                  fechareservafin = '" + dtpFechaFinMReserva.Value.ToString("yyyy-MM-dd HH:mm") + "',
                                                  cantidadkm = '" + cbxKilomMReserva.SelectedValue.ToString + "', 
                                                  costototal = '" + txtCostoMReserva.Text + "', estado = '1', 
                                                  nrochasis = NULL, idpersona = '" + IdPersona + "',
                                                  idcategoria = '" + cbxCategoriaMReserva.SelectedValue.ToString + "',
                                                  idtipo = '" + cbxTipoMReserva.SelectedValue.ToString + "',
                                                  idsucursalsalida = '" + cbxSucursalSalidaMReserva.SelectedValue.ToString + "', 
                                                  idsucursalllegada = '" + cbxSucursalLlegadaMReserva.SelectedValue.ToString + "'
                                                  WHERE idreserva = '" + IdReserva + "'")

                    conexion.EjecutarNonQuery(prueba)
                    RecargarDatos(dgvReservas)
                    AmaranthMessagebox("Reserva modificada correctamente", "Continuar")
                Else
                    AmaranthMessagebox("Ese cliente ya tiene una reserva activa entre esas fechas.", "Error")
                End If
            Else
                AmaranthMessagebox("Ese cliente no está registrado.", "Error")
            End If
        Else
            AmaranthMessagebox("La Fecha Fin no puede ser menor a la Fecha de Inicio.", "Error")
            Dim fechaIM As String = dgvReservas.CurrentRow.Cells("fechareservainicio").Value.ToString()
            Dim fechaFM As String = dgvReservas.CurrentRow.Cells("fechareservafin").Value.ToString()
            dtpFechaInicioMReserva.Value = fechaIM
            dtpFechaFinMReserva.Value = fechaFM
        End If
    End Sub

    Private Function TipoFiltroReserva(chbx As CheckBox) As String
        Select Case chbx.Name
            Case "chboxFechaFRes"
                If chboxFechaFRes.Checked = True Then
                    Return " And fechareservainicio >= '" + dtpDesdeFReserva.Value.ToString("dd/MM/yyyy hh:mm") + "' AND fechareservafin < '" + dtpHastaFReserva.Value.ToString("dd/MM/yyyy hh:mm") + "'"
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
                    Return " AND idestado = 1"
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
