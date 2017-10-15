'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerVehiculos
End Class

'VEHICULOS
Partial Public Class frmMainMenu

    Private Sub CargasModelo(sender As ComboBox, e As EventArgs) Handles cbxMarcaAVeh.SelectedValueChanged, cbxMarcaFVeh.SelectedValueChanged, cbxMarcaFVeh.SelectedValueChanged

        Dim ModelosYOtro As New DataTable


        Try
            If (Not (sender.SelectedValue Is Nothing)) Then

                If (Not (sender.SelectedValue.ToString = "")) Then

                    If (Not (sender.SelectedValue.ToString = "System.Data.DataRowView")) Then

                        'Si el item seleccionado NO es "Otro":
                        If Not (sender.SelectedIndex = sender.FindString("Nueva...")) Then

                            Select Case sender.Name
                                Case "cbxMarcaAVeh"

                                    ModelosYOtro = conexion.Modelos.Select("idmarca = '" + cbxMarcaAVeh.SelectedValue.ToString + "' and estado = true").CopyToDataTable
                                    ModelosYOtro.Rows.Add(0, 0, "Nuevo...", 0, True)
                                    CargarDatosComboBox(cbxModeloAVeh, ModelosYOtro, "nombre", "idmodelo")
                                    cbxModeloAVeh.Enabled = True
                                    cbxModeloAVeh.SelectedItem = Nothing
                                    cbxTipoAVeh.SelectedItem = Nothing

                                Case "cbxMarcaFVeh"
                                    ModelosYOtro = conexion.Modelos.Select("idmarca = '" + cbxMarcaAVeh.SelectedValue.ToString + "' and estado = true").CopyToDataTable
                                    ModelosYOtro.Rows.Add(0, 0, "Nuevo...", 0, True)
                                    CargarDatosComboBox(cbxModeloFVeh, conexion.Modelos.Select("idmarca = '" + cbxMarcaAVeh.SelectedValue.ToString + "' and estado = true").CopyToDataTable, "nombre", "idmodelo")
                                    cbxModeloFVeh.Enabled = True
                                    cbxModeloFVeh.SelectedItem = Nothing
                                    cbxTipoFVeh.SelectedItem = Nothing

                                Case "cbxMarcaMVeh"
                                    ModelosYOtro = conexion.Modelos.Select("idmarca = '" + cbxMarcaAVeh.SelectedValue.ToString + "' and estado = true").CopyToDataTable
                                    ModelosYOtro.Rows.Add(0, 0, "Nuevo...", 0, True)
                                    CargarDatosComboBox(cbxModeloMVeh, ModelosYOtro, "nombre", "idmodelo")
                                    cbxModeloMVeh.Enabled = True
                                    cbxModeloMVeh.SelectedItem = Nothing
                                    cbxTipoMVeh.SelectedItem = Nothing
                                Case Else

                            End Select

                            'Si el item seleccionado es "Otro"
                        Else
                            frmCambiosGenerales.Show()
                            frmCambiosGenerales.btnVehiculo.PerformClick()
                        End If
                    End If
                End If
            Else

                Select Case sender.Name
                    Case "cbxMarcaAVeh"
                        cbxModeloAVeh.Enabled = False
                    Case "cbxMarcaFVeh"
                        cbxModeloFVeh.Enabled = False
                    Case "cbxMarcaMVeh"
                        cbxModeloMVeh.Enabled = False

                End Select

            End If
        Catch ex As NullReferenceException

        End Try


    End Sub

    Private Sub CargasTipo(sender As ComboBox, e As EventArgs) Handles cbxModeloAVeh.SelectedValueChanged, cbxModeloFVeh.SelectedValueChanged
        'Si el valor seleccionado del modelo NO es Nada
        If (Not (sender.SelectedValue Is Nothing)) Then
            If (Not (sender.SelectedValue.ToString = "System.Data.DataRowView")) Then

                'Si el valor seleccionado del modelo NO es "Otro"
                If Not (sender.SelectedIndex = sender.FindString("Nuevo...")) Then

                    Dim idmodeloselect As String = sender.SelectedValue
                    Dim idtipo As String = conexion.Modelos.Select("idmodelo = " + idmodeloselect + "").CopyToDataTable.Rows(0).Field(Of Integer)("idtipo")

                    Select Case sender.Name
                        Case "cbxModeloAVeh"
                            cbxTipoAVeh.SelectedValue = idtipo
                            cbxTipoAVeh.Enabled = False
                        Case "cbxModeloFVeh"
                            cbxTipoFVeh.SelectedValue = idtipo
                            cbxTipoFVeh.Enabled = False
                            lblBorrarTipoFVeh.Enabled = False
                        Case "cbxModeloMVeh"
                            cbxTipoMVeh.SelectedValue = idtipo
                            cbxTipoMVeh.Enabled = False
                    End Select

                Else
                    frmCambiosGenerales.Show()
                    frmCambiosGenerales.btnVehiculo.PerformClick()
                End If
            End If
        Else

            Select Case sender.Name
                Case "cbxModeloAVeh"
                    cbxTipoAVeh.Enabled = True
                Case "cbxModeloFVeh"
                    cbxTipoFVeh.Enabled = True
                    lblBorrarTipoFVeh.Enabled = True
                Case "cbxModeloMVeh"
                    cbxTipoMVeh.Enabled = True
            End Select

        End If

    End Sub

    Private Sub VaciarFiltrosVehiculoBoton(sender As Object, e As EventArgs) Handles btnVaciarFVeh.Click

        For Each item In pnlFVehi.Controls

            If TypeOf item Is TextBox Then
                item.text = ""
            End If

            If TypeOf item Is ComboBox Then
                item.SelectedItem = Nothing
            End If

            If TypeOf item Is NumericUpDown Then
                DirectCast(item, NumericUpDown).Value = Nothing
            End If
        Next

    End Sub

    Private Sub VaciarFiltrosVehiculo(sender As Object, e As EventArgs) Handles lblBorrarCategoriaFVeh.Click, lblBorrarEstadoFVeh.Click, lblBorrarMaletasFVeh.Click, lblBorrarMarcaFVeh.Click, lblBorrarModeloFVeh.Click, lblBorrarPuertasFVeh.Click, lblBorrarSucursalFVeh.Click, lblBorrarTipoFVeh.Click

        Select Case sender.Name

            Case "lblBorrarMarcaFVeh"
                If Not cbxMarcaFVeh.SelectedItem Is Nothing Then
                    cbxMarcaFVeh.SelectedItem = Nothing
                End If

                If Not cbxModeloFVeh.SelectedItem Is Nothing Then
                    cbxModeloFVeh.SelectedItem = Nothing
                End If

                If Not cbxTipoFVeh.SelectedItem Is Nothing Then
                    cbxTipoFVeh.SelectedItem = Nothing
                End If

            Case "lblBorrarModeloFVeh"
                If Not cbxModeloFVeh.SelectedItem Is Nothing Then
                    cbxModeloFVeh.SelectedItem = Nothing
                End If

                If Not cbxTipoFVeh.SelectedItem Is Nothing Then
                    cbxTipoFVeh.SelectedItem = Nothing
                End If

            Case "lblBorrarTipoFVeh"
                If Not cbxTipoFVeh.SelectedItem Is Nothing Then
                    cbxTipoFVeh.SelectedItem = Nothing
                End If

            Case "lblBorrarCategoriaFVeh"
                If Not cbxCategoriaFVeh.SelectedItem Is Nothing Then
                    cbxCategoriaFVeh.SelectedItem = Nothing
                End If

            Case "lblBorrarMaletasFVeh"
                If Not cbxMaletasFVeh.SelectedItem Is Nothing Then
                    cbxMaletasFVeh.SelectedItem = Nothing
                End If

            Case "lblBorrarPuertasFVeh"
                If Not cbxPuertasFVeh.SelectedItem Is Nothing Then
                    cbxPuertasFVeh.SelectedItem = Nothing
                End If
            Case "lblBorrarSucursalFVeh"
                If Not cbxSucursalFVeh.SelectedItem Is Nothing Then
                    cbxSucursalFVeh.SelectedItem = Nothing
                End If
        End Select

    End Sub

    Private Sub numPasajerosFVeh_ValueChanged(sender As Object, e As EventArgs) Handles numPasajerosFVeh.ValueChanged

        If sender.Value = 0 Then
            lblParamIgnore.Visible = True
        Else
            lblParamIgnore.Visible = False
        End If

    End Sub

    Private Sub FiltrarVehiculos(sender As Object, e As EventArgs) Handles txtNroChasisFVeh.TextChanged, txtMatriculaFVeh.TextChanged, cbxCategoriaFVeh.SelectionChangeCommitted, cbxMarcaFVeh.SelectionChangeCommitted, cbxModeloFVeh.SelectionChangeCommitted, cbxTipoFVeh.SelectionChangeCommitted, cbxSucursalFVeh.SelectionChangeCommitted, txtAnioFVeh.TextChanged, cbxMaletasFVeh.SelectionChangeCommitted, numPasajerosFVeh.ValueChanged, cbxPuertasFVeh.SelectionChangeCommitted, lblBorrarCategoriaFVeh.Click, lblBorrarEstadoFVeh.Click, lblBorrarMaletasFVeh.Click, lblBorrarMarcaFVeh.Click, lblBorrarModeloFVeh.Click, lblBorrarPuertasFVeh.Click, lblBorrarSucursalFVeh.Click, lblBorrarTipoFVeh.Click

        Dim Filtro As String
        Filtro = "nrochasis LIKE '%" + txtNroChasisFVeh.Text + "%' AND matricula LIKE '%" + txtMatriculaFVeh.Text + "%'" + TipoFiltro(cbxAireFVeh, "aire") + TipoFiltro(cbxAutomaticoFVeh, "automatico") + TipoFiltro(cbxMaletasFVeh, "maletas") + TipoFiltro(cbxPuertasFVeh, "puertas") + TipoFiltro(numPasajerosFVeh, "pasajeros") + TipoFiltro(cbxCategoriaFVeh, "idcategoria") + TipoFiltro(cbxMarcaFVeh, "idmarca") + TipoFiltro(cbxModeloFVeh, "idmodelo") + TipoFiltro(cbxTipoFVeh, "idtipo") + TipoFiltro(cbxSucursalFVeh, "idsucursal") + If(IsNumeric(txtAnioFVeh.Text) And (Not (txtAnioFVeh.Text = "")), "AND anio = " + txtAnioFVeh.Text + "", "")
        dgvVehiculos.DataSource.Filter = Filtro

    End Sub

    Private Sub RellenarDatosVehiculo(sender As Object, e As EventArgs) Handles dgvVehiculos.SelectionChanged

        If Not IsNothing(dgvVehiculos.CurrentRow) Then
            CargarDatosComboBox(cbxModeloMVeh, conexion.Modelos.Select("idmarca = '" + dgvVehiculos.CurrentRow.Cells("idmarcaveh").Value.ToString() + "'").CopyToDataTable, "nombre", "idmodelo")
            txtNroChasisMVeh.Text = dgvVehiculos.CurrentRow.Cells("nrochasis").Value.ToString()
            txtMatriculaMVeh.Text = dgvVehiculos.CurrentRow.Cells("matricula").Value.ToString()
            txtKMMVeh.Text = dgvVehiculos.CurrentRow.Cells("kilometraje").Value.ToString()
            txtDeducibleMVeh.Text = dgvVehiculos.CurrentRow.Cells("deducible").Value.ToString()
            cbxCategoriaMVeh.SelectedValue = dgvVehiculos.CurrentRow.Cells("idcategoriaveh").Value
            cbxMarcaMVeh.SelectedValue = dgvVehiculos.CurrentRow.Cells("idmarcaveh").Value.ToString()
            cbxModeloMVeh.SelectedValue = dgvVehiculos.CurrentRow.Cells("idmodeloveh").Value.ToString()
            cbxTipoMVeh.SelectedValue = dgvVehiculos.CurrentRow.Cells("idtipoveh").Value.ToString()
            If dgvVehiculos.CurrentRow.Cells("idsucursalveh").Value.ToString = "" Then
                cbxSucursalMVeh.Enabled = False
                cbxSucursalMVeh.SelectedItem = Nothing
            Else
                cbxSucursalMVeh.SelectedValue = dgvVehiculos.CurrentRow.Cells("idsucursalveh").Value.ToString()
                cbxSucursalMVeh.Enabled = True
            End If
            cbxMaletasMVeh.SelectedItem = dgvVehiculos.CurrentRow.Cells("cantidaddemaletas").Value.ToString()
            numPasajerosMVehiculo.Value = dgvVehiculos.CurrentRow.Cells("cantidaddepasajeros").Value.ToString()
            txtAnioMVeh.Text = dgvVehiculos.CurrentRow.Cells("aniov").Value.ToString()
            cbxPuertasMVeh.SelectedItem = dgvVehiculos.CurrentRow.Cells("cantidaddepuertas").Value.ToString()
        End If
    End Sub

    Private Sub SoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtDeducibleAVeh.KeyPress, txtKilometrajeAVeh.KeyPress, txtAnioAVeh.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub AltaVehiculo(sender As Object, e As EventArgs) Handles btnAltaAVeh.Click

        Dim FaltaDato As Boolean = False

        For Each ctrl As Control In pnlAVehi.Controls
            If TypeOf (ctrl) Is TextBox Then
                If Not ctrl.Name = "txtCorreoACliente" Then
                    If ctrl.Text = "" Then
                        FaltaDato = True
                        Exit For
                    End If
                End If
            Else
                If TypeOf (ctrl) Is ComboBox Then
                    If DirectCast(ctrl, ComboBox).SelectedItem Is Nothing Then
                        FaltaDato = True
                    End If
                End If
            End If
        Next

        Dim automaticoAVeh As String
        Dim aireAVeh
        Dim cantpasajeros As String
        Dim matricula As String
        Dim añoActual As String = Date.Now.Year
        Dim añoInsertar As Integer

        If Not (FaltaDato) Then
            'Me quedo con solo el 1er digito para hacer el insert despues
            automaticoAVeh = cbxAutomaticoAVeh.Checked.ToString.Substring(0, 1)
            aireAVeh = chbxAireAVeh.Checked.ToString.Substring(0, 1)

            cantpasajeros = numPasajerosAVeh.Value.ToString
            matricula = txtMatriculaAVeh.Text.ToString
            añoInsertar = txtAnioAVeh.Text

            If (matricula.Length = 7) Then

                Dim matriculaletras As String = matricula.Substring(0, 3)
                Dim matriculanumeros As String = matricula.Substring(3, 4)

                If Not (cantpasajeros = 0) Then

                    If IsNumeric(matriculaletras) = False And IsNumeric(matriculanumeros) = True Then

                        If Not (añoInsertar > añoActual) Then

                            Dim nrochasisrepetido As New DataTable
                            nrochasisrepetido = conexion.EjecutarSelect("select nrochasis from vehiculo where nrochasis = '" + txtNroChasisAVeh.Text.ToString + "'")

                            If Not (nrochasisrepetido.Rows.Count > 0) Then
                                Dim sentencia As String
                                sentencia = "insert into vehiculo values('" + txtNroChasisAVeh.Text.ToString + "','" + txtMatriculaAVeh.Text.ToString + "','" + txtAnioAVeh.Text.ToString + "','" + txtKilometrajeAVeh.Text.ToString + "','" + aireAVeh + "','" + cbxPuertasAVeh.SelectedItem.ToString + "','" + cantpasajeros + "','" + cbxMaletasAVeh.SelectedItem.ToString + "','" + automaticoAVeh + "','" + txtDeducibleAVeh.Text.ToString + "','" + cbxCategoriaAVeh.SelectedValue.ToString + "','" + cbxModeloAVeh.SelectedValue.ToString + "','" + cbxSucursalAVeh.SelectedValue.ToString + "','t')"
                                conexion.EjecutarNonQuery(sentencia)
                                RecargarDatos(dgvVehiculos)
                                MsgBox("bien")
                            Else
                                MsgBox("Ya posee un vehiculo con el mismo numero de chasis.")
                            End If
                        Else
                            MsgBox("Error en el año del vehiculo, no puede ser mayor al año actual.")
                        End If
                    Else
                        MsgBox("Error en la matricula, debe contar con 3 letras y 4 números.")
                    End If
                Else
                    MsgBox("La cantidad de pasajeros no puede ser 0.")
                End If
            Else
                MsgBox("Largo de matricula inválido.")
            End If
        Else
            MsgBox("por favor, rellene todos los campos.")
        End If
    End Sub


End Class
