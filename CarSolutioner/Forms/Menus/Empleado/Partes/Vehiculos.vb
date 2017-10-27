'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerVehiculosEmpleado
End Class

'VEHICULOS
Partial Public Class frmMainMenuEmpleado

    Private Sub CargasModelo(sender As ComboBox, e As EventArgs) Handles cbxMarcaFVeh.SelectedValueChanged

        Dim Modelos As New DataTable

        Try
            If (Not (sender.SelectedValue Is Nothing)) Then

                If (Not (sender.SelectedValue.ToString = "")) Then

                    If (Not (sender.SelectedValue.ToString = "System.Data.DataRowView")) Then

                        'Si el item seleccionado NO es "Otro":
                        If Not (sender.SelectedIndex = sender.FindString("Nueva...")) Then

                            Select Case sender.Name

                                Case "cbxMarcaFVeh"
                                    CargarDatosComboBox(cbxModeloFVeh, conexion.Modelos.Select("idmarca = '" + cbxMarcaFVeh.SelectedValue.ToString + "' and estado = true").CopyToDataTable, "nombre", "idmodelo")
                                    cbxModeloFVeh.Enabled = True
                                    cbxModeloFVeh.SelectedItem = Nothing
                                    cbxTipoFVeh.SelectedItem = Nothing

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
                    Case "cbxMarcaFVeh"
                        cbxModeloFVeh.Enabled = False
                End Select
            End If
        Catch ex As NullReferenceException
        End Try
    End Sub

    Private Sub CargasTipo(sender As ComboBox, e As EventArgs) Handles cbxModeloFVeh.SelectedValueChanged
        'Si el valor seleccionado del modelo NO es Nada
        If (Not (sender.SelectedValue Is Nothing)) Then
            If (Not (sender.SelectedValue.ToString = "System.Data.DataRowView")) Then

                'Si el valor seleccionado del modelo NO es "Otro"

                Dim idmodeloselect As String = sender.SelectedValue
                Dim idtipo As String = conexion.Modelos.Select("idmodelo = " + idmodeloselect + "").CopyToDataTable.Rows(0).Field(Of Integer)("idtipo")

                Select Case sender.Name
                    Case "cbxModeloFVeh"
                        cbxTipoFVeh.SelectedValue = idtipo
                        cbxTipoFVeh.Enabled = False
                        lblBorrarTipoFVeh.Enabled = False
                End Select
            End If
        Else

            Select Case sender.Name
                Case "cbxModeloFVeh"
                    cbxTipoFVeh.Enabled = True
                    lblBorrarTipoFVeh.Enabled = True
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

    Private Sub VaciarFiltrosVehiculo(sender As Object, e As EventArgs) Handles lblBorrarCategoriaFVeh.Click, lblBorrarMaletasFVeh.Click, lblBorrarMarcaFVeh.Click, lblBorrarModeloFVeh.Click, lblBorrarPuertasFVeh.Click, lblBorrarSucursalFVeh.Click, lblBorrarTipoFVeh.Click, lblBorrarColorVeh.Click

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
            Case "lblBorrarColorVeh"
                If Not cbxColorFVehiculo.SelectedItem Is Nothing Then
                    cbxColorFVehiculo.SelectedItem = Nothing
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

    Private Sub SoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtAnioFVeh.KeyPress, txtDeducibleFVeh.KeyPress, txtKMFVeh.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True

        End If

        sender.focus()
    End Sub

    Private Sub FiltrarVehiculos(sender As Object, e As EventArgs) Handles txtNroChasisFVeh.TextChanged, txtMatriculaFVeh.TextChanged, cbxCategoriaFVeh.SelectionChangeCommitted, cbxMarcaFVeh.SelectionChangeCommitted, cbxModeloFVeh.SelectionChangeCommitted, cbxTipoFVeh.SelectionChangeCommitted, cbxSucursalFVeh.SelectionChangeCommitted, txtAnioFVeh.TextChanged, cbxMaletasFVeh.SelectionChangeCommitted, numPasajerosFVeh.ValueChanged, cbxPuertasFVeh.SelectionChangeCommitted, lblBorrarCategoriaFVeh.Click, lblBorrarMaletasFVeh.Click, lblBorrarMarcaFVeh.Click, lblBorrarModeloFVeh.Click, lblBorrarPuertasFVeh.Click, lblBorrarSucursalFVeh.Click, lblBorrarTipoFVeh.Click, cbxAireFVeh.SelectionChangeCommitted, cbxManualFVeh.SelectionChangeCommitted, chbxFiltroVehiculos.CheckedChanged, lblBorrarColorVeh.Click, cbxColorFVehiculo.SelectionChangeCommitted, btnVaciarFVeh.Click

        Dim Filtro As String
        Filtro = "nrochasis LIKE '%" + txtNroChasisFVeh.Text + "%' AND matricula LIKE '%" + txtMatriculaFVeh.Text + "%'" + TipoFiltro(cbxAireFVeh, "aireacondicionado") + TipoFiltro(cbxManualFVeh, "esmanual") + TipoFiltro(cbxMaletasFVeh, "cantidaddemaletas") + TipoFiltro(cbxPuertasFVeh, "cantidaddepuertas") + TipoFiltro(numPasajerosFVeh, "cantidaddepasajeros") + TipoFiltro(cbxCategoriaFVeh, "idcategoria") + TipoFiltro(cbxMarcaFVeh, "idmarca") + TipoFiltro(cbxModeloFVeh, "idmodelo") + TipoFiltro(cbxTipoFVeh, "idtipo") + TipoFiltro(cbxColorFVehiculo, "color") + TipoFiltro(cbxSucursalFVeh, "idsucursal") + If(IsNumeric(txtAnioFVeh.Text) And (Not (txtAnioFVeh.Text = "")), "AND Convert(anio, System.String) LIKE '" + txtAnioFVeh.Text + "%'", "")

        dgvVehiculos.DataSource.Filter = Filtro


    End Sub

    Private Sub antiSQLInjection(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtMatriculaFVeh.KeyPress
        e.Handled = Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsNumber(e.KeyChar)
    End Sub

End Class
