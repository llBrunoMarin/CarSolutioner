﻿'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerReservasGerente
End Class


Partial Public Class frmMainMenuGerente

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
            filtrado = "nrodocumento LIKE '" + txtDocumFRes.Text.ToString + "%' AND Convert(costototal, System.String) LIKE '" + txtCostoTotalFReserva.Text.ToString + "%' AND usuarioempleado LIKE '%" + txtUsuarioFReserva.Text + "%'" + TipoFiltroReserva(chboxFechaFRes) + TipoFiltroReserva(chboxFechaTramiteFReserva) + TipoFiltroReserva(chboxInactivasFReserva) + TipoFiltroReserva(chboxVerHoyFReserva) + TipoFiltro(cbxCategoriaFRes, "idcategoria") + TipoFiltro(cbxTipoFRes, "idtipo") + TipoFiltro(cbxSucLlegFRes, "idsucursalllegada") + TipoFiltro(cbxSucSalFres, "idsucursalsalida") + TipoFiltro(cbxKilomFRes, "idcantidadkm")

            dgvReservas.DataSource.Filter = filtrado

        Catch ex As NullReferenceException

        End Try

    End Sub

    Public Sub AlquilarReserva(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvReservas.CellMouseDoubleClick
        Dim ReservaSeleccionadaAlquiler As New ReservaSeleccionada()

        Dim selectedRow As DataGridViewRow

        If sender Is dgvReservas Then
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                selectedRow = dgvReservas.Rows(DirectCast(e, DataGridViewCellMouseEventArgs).RowIndex)
            End If
        Else
            selectedRow = dgvReservas.CurrentRow
        End If


        If Not selectedRow Is Nothing Then
            If selectedRow.Cells("idestadoreserva").Value = 1 Then

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

                Dim Disponibles As New DataTable
                Disponibles = conexion.EjecutarSelect("SELECT  V.*, Ma.nombre marca, Ma.idmarca, Mo.nombre modelo, T.nombre tipo, T.idtipo, C.nombre categoria, S.nombre Sucursal From Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S Where V.idsucursal = '" + ReservaSeleccionadaAlquiler.IdSucursalPartida.ToString + "' AND V.idcategoria = '" + ReservaSeleccionadaAlquiler.IdCategoria.ToString + "' AND Mo.idtipo = '" + ReservaSeleccionadaAlquiler.IdTipo.ToString + "' AND V.idcategoria = C.idcategoria And V.idmodelo = Mo.idmodelo And Mo.Idmarca = Ma.Idmarca And Mo.Idtipo = T.idtipo And V.idsucursal = S.idsucursal And V.estado = 't' And  V.nrochasis Not IN (Select nrochasis FROM Mantenimiento WHERE (TO_DATE('" + Date.Now.ToString("dd/MM/yyyy HH:mm") + "', '%d/%m/%Y %H:%M') BETWEEN fechainicio AND fechafin ))")
                ReservaSeleccionadaAlquiler.AutosDisponibles = Disponibles

                If selectedRow.Cells("fechareservainicio").Value < Date.Now.AddHours(2) Then
                    If (Date.Now.AddHours(-2) <= selectedRow.Cells("fechareservainicio").Value) AndAlso (selectedRow.Cells("fechareservainicio").Value <= Date.Now.AddHours(6)) Then

                        If Disponibles.Rows.Count <> 0 Then

                            Dim AlquilarReserva As New frmAlquilar(ReservaSeleccionadaAlquiler.AutosDisponibles, frmAlquilar.VistaAlquilar.Normal, ReservaSeleccionadaAlquiler)
                            Using AlquilarReserva
                                AlquilarReserva.ShowDialog(Me)
                            End Using
                        Else
                            Dim ModificarReserva As New frmModificarReserva(ReservaSeleccionadaAlquiler)
                            Using ModificarReserva
                                ModificarReserva.ShowDialog(Me)
                            End Using
                        End If

                    Else

                        Dim Diferencia As Integer = Math.Truncate((Date.Now - Date.Parse(selectedRow.Cells("fechareservainicio").Value.ToString())).TotalHours)
                        Dim resultado As DialogResult = AmaranthMessagebox("Esta reserva era para hace más de " + Diferencia.ToString + " horas atrás. ¿Está seguro que quiere realizar el Alquiler?", "Si/No", Me)

                        If resultado = vbYes Then
                            If Autorizar(Me) = vbYes Then
                                If Disponibles.Rows.Count <> 0 Then

                                    Dim AlquilarReserva As New frmAlquilar(ReservaSeleccionadaAlquiler.AutosDisponibles, frmAlquilar.VistaAlquilar.Normal, ReservaSeleccionadaAlquiler)
                                    Using AlquilarReserva
                                        AlquilarReserva.ShowDialog(Me)
                                    End Using
                                Else
                                    Dim ModificarReserva As New frmModificarReserva(ReservaSeleccionadaAlquiler)
                                    Using ModificarReserva
                                        ModificarReserva.ShowDialog(Me)
                                    End Using
                                End If
                            End If
                        End If

                    End If
                Else
                    AmaranthMessagebox("Solo puede alquilar reservas futuras con 2 horas de antelación como máximo. (#054)", "Error", Me)
                End If
            Else
                AmaranthMessagebox("Solo puede alquilar reservas activas. (#055)", "Error", Me)
            End If
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
        If Not dgvReservas.CurrentRow Is Nothing Then
            If dgvReservas.CurrentRow.Index >= 0 AndAlso dgvReservas.CurrentCell.ColumnIndex >= 0 Then
                If (AmaranthMessagebox("¿Está seguro que quiere anular esta reserva?", "Si/No", Me) = vbYes) Then

                    Dim reservaseleccionadaid As String
                    reservaseleccionadaid = dgvReservas.CurrentRow.Cells("idreserva").Value.ToString()


                    If conexion.EjecutarNonQuery("Update reserva set estado = 3 where idreserva = " + reservaseleccionadaid.ToString() + "") = True Then

                        RecargarDatos(dgvReservas)
                        AmaranthMessagebox("Reserva anulada satisfactoriamente.", "Continuar", Me)

                    Else
                        AmaranthMessagebox("No se pudo anular la reserva. (#053)", "Error", Me)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RellenarDatosReserva(sender As Object, e As EventArgs) Handles dgvReservas.SelectionChanged

        Try
            If Not IsNothing(dgvReservas.CurrentRow) Then
                Dim estadoReserva As String = dgvReservas.CurrentRow.Cells("estadoreserva").Value.ToString()
                If (estadoReserva = "Inactiva") Or estadoReserva = "Anulada " Then
                    pnlMres.Enabled = False
                    pnlBRes.Enabled = False
                    txtDocumMReserva.Text = ""
                    cbxCategoriaMReserva.SelectedItem = Nothing
                    cbxTipoMReserva.SelectedItem = Nothing
                    cbxKilomMReserva.SelectedItem = Nothing
                    cbxSucursalSalidaMReserva.SelectedItem = Nothing
                    cbxSucursalLlegadaMReserva.SelectedItem = Nothing

                Else
                    pnlMres.Enabled = True
                    pnlBRes.Enabled = True
                    txtDocumMReserva.Text = dgvReservas.CurrentRow.Cells("nrodocumentores").Value.ToString()
                    cbxCategoriaMReserva.SelectedValue = dgvReservas.CurrentRow.Cells("idcategoriareserva").Value.ToString()
                    cbxTipoMReserva.SelectedValue = dgvReservas.CurrentRow.Cells("idtiporeserva").Value.ToString()
                    cbxKilomMReserva.SelectedValue = dgvReservas.CurrentRow.Cells("idcantidadkm").Value.ToString()
                    cbxSucursalSalidaMReserva.SelectedValue = dgvReservas.CurrentRow.Cells("idsucursalsalida").Value.ToString()
                    cbxSucursalLlegadaMReserva.SelectedValue = dgvReservas.CurrentRow.Cells("idsucursalllegada").Value.ToString()

                    dtpFechaInicioMReserva.MinDate = dgvReservas.CurrentRow.Cells("fechareservainicio").Value.ToString()
                    dtpFechaInicioMReserva.MaxDate = dtpFiltrarFechaInicioMant.MaxDate
                    dtpFechaInicioMReserva.Value = dgvReservas.CurrentRow.Cells("fechareservainicio").Value.ToString()

                    dtpFechaFinMReserva.MinDate = Date.Now.Round()
                    dtpFechaFinMReserva.MaxDate = dtpFiltrarFechaInicioMant.MaxDate
                    dtpFechaFinMReserva.Value = dgvReservas.CurrentRow.Cells("fechareservafin").Value.ToString()

                End If

            End If


        Catch ex As NullReferenceException

        End Try
    End Sub

    Private Sub AgregarReserva(sender As Object, e As EventArgs) Handles btnReservarARes.Click

        Dim fechaActual As Date
        Dim ReservaSeleccionadaReserva As New ReservaSeleccionada()
        fechaActual = Date.Now

        If Not ((dtpInicioARes.Value < fechaActual.AddMinutes(-10)) Or (dtpFinARes.Value < fechaActual)) Then

                If Not dtpFinARes.Value <= dtpInicioARes.Value Then
                    If ((dtpFinARes.Value - dtpInicioARes.Value).Days >= 1) Then

                    Dim Persona As DataTable = conexion.EjecutarSelect("SELECT idpersona, nombre || ' ' || apellido nombreapellido, porcdescuento FROM Cliente WHERE nrodocumento = '" + txtDocumARes.Text + "' AND estado = 't'")

                    'Si la persona existe
                    If Persona.Rows.Count <> 0 Then

                        Dim IdPersona As String = Persona.Rows(0)(0).ToString
                        Dim NombreApellido As String = Persona.Rows(0)(1).ToString
                        Dim PorcDescuento As String = Persona.Rows(0)(2).ToString

                        'Si el cliente NO tiene reservas activas:
                        Dim sentencia As String = "SELECT idreserva FROM Reserva WHERE idpersona = '" + IdPersona + "' AND estado = 1 AND  ( ( '" + dtpInicioARes.Value.ToString("yyyy-MM-dd HH:mm") + "' BETWEEN fechareservainicio AND fechareservafin )  OR ('" + dtpFinARes.Value.ToString("yyyy-MM-dd HH:mm") + "' BETWEEN fechareservainicio AND fechareservafin )  )"
                        If conexion.EjecutarSelect(sentencia).Rows.Count = 0 Then

                            ReservaSeleccionadaReserva.IdCliente = IdPersona
                            ReservaSeleccionadaReserva.FechaReservaInicio = dtpInicioARes.Value
                            ReservaSeleccionadaReserva.FechaReservaFin = dtpFinARes.Value
                            ReservaSeleccionadaReserva.IdCantKM = cbxKmARes.SelectedValue
                            ReservaSeleccionadaReserva.FechaTramite = Date.Now
                            ReservaSeleccionadaReserva.NomCliente = NombreApellido
                            ReservaSeleccionadaReserva.IdCategoria = cbxCategoriaARes.SelectedValue
                            ReservaSeleccionadaReserva.IdTipo = cbxTipoAReserva.SelectedValue
                            ReservaSeleccionadaReserva.IdSucursalPartida = cbxSucSalidaARes.SelectedValue
                            ReservaSeleccionadaReserva.IdSucursalDestino = cbxSucLlegadaARes.SelectedValue
                            ReservaSeleccionadaReserva.UsuarioEmpleado = conexion.Usuario
                            ReservaSeleccionadaReserva.DescuentoCliente = PorcDescuento

                            Dim reserva As New Reserva(ReservaSeleccionadaReserva, Reserva.Tipo.Agregar)
                            Using reserva
                                reserva.ShowDialog(Me)
                            End Using

                            dtpInicioARes.MinDate = Date.Now.AddMinutes(5).Round()
                            dtpFinARes.MinDate = dtpInicioARes.Value.AddDays(1)

                        Else
                            AmaranthMessagebox("Ese cliente ya tiene un alquiler o reserva activos para esas fechas. (#048)", "Error", Me)
                        End If

                    Else
                        AmaranthMessagebox("Ese cliente no está registrado o está inactivo. (#049)", "Error", Me)
                    End If
                    Else
                    AmaranthMessagebox("Las reservas tienen que ser de mínimo 24 horas. (#050)", "Error", Me)
                End If
                Else
                AmaranthMessagebox("La fecha fin no puede ser menor a la de Inicio. (#051)", "Error", Me)
            End If
            Else
            AmaranthMessagebox("Las fechas no pueden ser menores a la de hoy. (#052)", "Error", Me)
        End If

    End Sub

    Private Sub ModificarReserva(sender As Object, e As EventArgs) Handles btnModificarReserva.Click
        If Not dgvReservas.CurrentRow Is Nothing Then

            Dim txtdocRI As String = dgvReservas.CurrentRow.Cells("nrodocumentores").Value.ToString()
            Dim categoriaRI As String = dgvReservas.CurrentRow.Cells("idcategoriareserva").Value.ToString()
            Dim tipoRI As String = dgvReservas.CurrentRow.Cells("idtiporeserva").Value.ToString()
            Dim kmRI As String = dgvReservas.CurrentRow.Cells("idcantidadkm").Value.ToString()
            Dim costoRI As String = dgvReservas.CurrentRow.Cells("costototalres").Value.ToString()
            Dim sucusalidaRI As String = dgvReservas.CurrentRow.Cells("idsucursalsalida").Value.ToString()
            Dim sucusallegaRI As String = dgvReservas.CurrentRow.Cells("idsucursalllegada").Value.ToString()
            Dim fechaINIRI As String = dgvReservas.CurrentRow.Cells("fechareservainicio").Value.ToString()
            Dim fechaFIRI As String = dgvReservas.CurrentRow.Cells("fechareservafin").Value.ToString()
            Dim format As String = "yyyy-MM-dd HH:mm"
            Dim fechafinResPANEL As String = dtpFechaFinMReserva.Value.ToString()
            Dim fechainicioResPANEL As String = dtpFechaInicioMReserva.Value.ToString()
            Dim kmRESPANEL As String = cbxKilomMReserva.SelectedValue.ToString()

            Dim fechaActual = Date.Now


            If Not (txtDocumMReserva.Text = txtdocRI And cbxCategoriaMReserva.SelectedValue.ToString = categoriaRI And cbxTipoMReserva.SelectedValue.ToString = tipoRI And kmRESPANEL = kmRI And cbxSucursalSalidaMReserva.SelectedValue.ToString = sucusalidaRI And cbxSucursalLlegadaMReserva.SelectedValue.ToString = sucusallegaRI And fechainicioResPANEL = fechaINIRI And fechafinResPANEL = fechaFIRI) Then
                If Not ((dtpFechaInicioMReserva.Value < fechaActual.AddMinutes(-10)) Or (dtpFechaFinMReserva.Value < fechaActual)) Then

                    If Not dtpFechaFinMReserva.Value <= dtpFechaInicioMReserva.Value Then
                        If ((dtpFechaFinMReserva.Value - dtpFechaInicioMReserva.Value).Days >= 1) Then
                            Dim ReservaSeleccionadaModificar As New ReservaSeleccionada()
                            Dim Persona As DataTable = conexion.EjecutarSelect("SELECT idpersona, nombre || ' ' || apellido nombreapellido, porcdescuento FROM Cliente WHERE nrodocumento = '" + txtDocumMReserva.Text + "' AND estado = 't'")

                            If Persona.Rows.Count <> 0 Then

                                Dim IdPersona As String = Persona.Rows(0)(0).ToString
                                Dim NombreApellido As String = Persona.Rows(0)(1).ToString
                                Dim PorcDescuento As String = Persona.Rows(0)(2).ToString
                                'Si la persona no tiene ninguna reserva activa por esas fechas (exceptuando la que se va a modificar)
                                Dim sentencia As String = "SELECT idreserva FROM Reserva WHERE idreserva != '" + dgvReservas.CurrentRow.Cells("idreserva").Value.ToString + "' AND idpersona = '" + IdPersona + "' AND estado != 3 AND ((fechareservafin BETWEEN '" + dtpFechaInicioMReserva.Value.ToString("yyyy-MM-dd HH:mm") + "' AND '" + dtpFechaFinMReserva.Value.ToString("yyyy-MM-dd HH:mm") + "') OR (fechareservainicio BETWEEN '" + dtpFechaInicioMReserva.Value.ToString("yyyy-MM-dd HH:mm") + "' AND '" + dtpFechaFinMReserva.Value.ToString("yyyy-MM-dd HH:mm") + "') OR (fechareservainicio < '" + dtpFechaInicioMReserva.Value.ToString("yyyy-MM-dd HH:mm") + "' AND fechareservafin > '" + dtpFechaFinMReserva.Value.ToString("yyyy-MM-dd HH:mm") + "'))"

                                If conexion.EjecutarSelect(sentencia).Rows.Count = 0 Then

                                    ReservaSeleccionadaModificar.IdReserva = dgvReservas.CurrentRow.Cells("idreserva").Value.ToString()
                                    ReservaSeleccionadaModificar.IdCliente = IdPersona
                                    ReservaSeleccionadaModificar.FechaReservaInicio = dtpFechaInicioMReserva.Value
                                    ReservaSeleccionadaModificar.FechaReservaFin = dtpFechaFinMReserva.Value
                                    ReservaSeleccionadaModificar.IdCantKM = cbxKilomMReserva.SelectedValue
                                    ReservaSeleccionadaModificar.FechaTramite = dgvReservas.CurrentRow.Cells("fechatramite").Value.ToString()
                                    ReservaSeleccionadaModificar.NomCliente = NombreApellido
                                    ReservaSeleccionadaModificar.IdCategoria = cbxCategoriaMReserva.SelectedValue
                                    ReservaSeleccionadaModificar.IdTipo = cbxTipoMReserva.SelectedValue
                                    ReservaSeleccionadaModificar.IdSucursalPartida = cbxSucursalSalidaMReserva.SelectedValue
                                    ReservaSeleccionadaModificar.IdSucursalDestino = cbxSucursalLlegadaMReserva.SelectedValue
                                    ReservaSeleccionadaModificar.UsuarioEmpleado = conexion.Usuario
                                    ReservaSeleccionadaModificar.DescuentoCliente = PorcDescuento

                                    Dim reserva As New Reserva(ReservaSeleccionadaModificar, Reserva.Tipo.Modificar)
                                    Using reserva
                                        reserva.ShowDialog(Me)
                                    End Using

                                Else
                                    AmaranthMessagebox("Ese cliente ya tiene una reserva activa entre esas fechas. (#048)", "Error", Me)
                                End If
                            Else
                                AmaranthMessagebox("Ese cliente no está registrado. (#049)", "Error", Me)
                            End If
                        Else
                            AmaranthMessagebox("Las reservas tienen que ser de mínimo 24 horas. (#050)", "Error", Me)
                        End If
                    Else
                        AmaranthMessagebox("La fecha fin no puede ser menor a la de Inicio. (#051)", "Error", Me)
                    End If
                Else
                    AmaranthMessagebox("Las fechas no pueden ser menores a la de hoy. (#052)", "Error", Me)
                End If
            Else
                AmaranthMessagebox("Tiene que realizar alguna modifiación. (#010)", "Error", Me)
            End If
        End If

    End Sub

    Private Function TipoFiltroReserva(chbx As CheckBox) As String
        Select Case chbx.Name
            Case "chboxFechaFRes"
                If chboxFechaFRes.Checked = True Then
                    Return " And fechareservainicio >= '" + dtpDesdeFReserva.Value.ToString("dd/MM/yyyy HH:mm") + "' AND fechareservafin < '" + dtpHastaFReserva.Value.ToString("dd/MM/yyyy HH:mm") + "'"
                Else
                    Return ""
                End If

            Case "chboxFechaTramiteFReserva"
                If chboxFechaTramiteFReserva.Checked = True Then
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
            Case Else
                Return ""
        End Select

    End Function

End Class
