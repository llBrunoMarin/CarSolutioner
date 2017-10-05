'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerVehiculos
End Class

'VEHICULOS
Partial Public Class frmMainMenu

    Private Sub CargasModelo(sender As ComboBox, e As EventArgs) Handles cbxMarcaAVeh.SelectedValueChanged, cbxMarcaFVeh.SelectedValueChanged, cbxMarcaFVeh.SelectedValueChanged


        If (Not (sender.SelectedValue Is Nothing)) Then

            If (Not (sender.SelectedValue.ToString = "")) Then

                If (Not (sender.SelectedValue.ToString = "System.Data.DataRowView")) Then

                    'Si el item seleccionado NO es "Otro":
                    If Not sender.SelectedValue.ToString = "Otro" Then

                        'Si no existe el item "Otro", crearlo.
                        If conexion.Modelos.Select("nombre = 'Otro'").Count = 0 Then
                            conexion.Modelos.Rows.Add(0, 0, "Otro", 0)
                        End If

                        Select Case sender.Name
                            Case "cbxMarcaAVeh"
                                CargarDatosComboBox(cbxModeloAVeh, conexion.Modelos.Select("idmarca = '" + cbxMarcaAVeh.SelectedValue.ToString + "'").CopyToDataTable, "nombre", "idmodelo")
                                cbxModeloAVeh.Enabled = True
                                cbxModeloAVeh.SelectedItem = Nothing
                            Case "cbxMarcaFVeh"
                                CargarDatosComboBox(cbxModeloFVeh, conexion.Modelos.Select("idmarca = '" + cbxMarcaFVeh.SelectedValue.ToString + "'").CopyToDataTable, "nombre", "idmodelo")
                                cbxModeloFVeh.Enabled = True
                                cbxModeloFVeh.SelectedItem = Nothing
                            Case Else

                        End Select

                        'Si el item seleccionado es "Otro"
                    Else
                        frmCambiosGenerales.Show()
                        frmCambiosGenerales.btnMarcas.PerformClick()
                    End If
                End If
            End If
        Else

            Select Case sender.Name
                Case "cbxMarcaAVeh"
                    cbxModeloAVeh.Enabled = False
                Case "cbxMarcaFVeh"
                    cbxModeloFVeh.Enabled = False
                Case Else

            End Select

        End If

    End Sub

    Private Sub CargasTipo(sender As ComboBox, e As EventArgs) Handles cbxModeloAVeh.SelectedValueChanged, cbxModeloFVeh.SelectedValueChanged
        'Si el valor seleccionado del modelo NO es Nada
        If (Not (sender.SelectedValue Is Nothing)) Then
            If (Not (sender.SelectedValue.ToString = "System.Data.DataRowView")) Then

                'Si el valor seleccionado del modelo NO es "Otro"
                If Not sender.Text = "Otro" Then

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
                        Case Else

                    End Select

                Else
                    frmCambiosGenerales.Show()
                    frmCambiosGenerales.btnModelos.PerformClick()
                End If
            End If
        Else

            Select Case sender.Name
                Case "cbxModeloAVeh"
                    cbxTipoAVeh.Enabled = True
                Case "cbxModeloFVeh"
                    cbxTipoFVeh.Enabled = True
                    lblBorrarTipoFVeh.Enabled = True
                Case Else
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
            cbxSucursalMVeh.SelectedValue = dgvVehiculos.CurrentRow.Cells("idsucursalveh").Value.ToString()
            cbxMaletasMVeh.SelectedItem = dgvVehiculos.CurrentRow.Cells("cantidaddemaletas").Value.ToString()
            numPasajerosMVehiculo.Value = dgvVehiculos.CurrentRow.Cells("cantidaddepasajeros").Value.ToString()
            txtAnioMVeh.Text = dgvVehiculos.CurrentRow.Cells("aniov").Value.ToString()
            cbxPuertasMVeh.SelectedItem = dgvVehiculos.CurrentRow.Cells("cantidaddepuertas").Value.ToString()

        End If


    End Sub


End Class
