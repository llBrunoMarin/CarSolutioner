'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerVehiculosInvitado
End Class

'VEHICULOS
Partial Public Class frmMainMenuInvitado

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

    Private Sub CargasTipo(sender As ComboBox, e As EventArgs) Handles cbxModeloFVeh.SelectedValueChanged         'Si el valor seleccionado del modelo NO es Nada
        If (Not (sender.SelectedValue Is Nothing)) Then
            If (Not (sender.SelectedValue.ToString = "System.Data.DataRowView")) Then

                'Si el valor seleccionado del modelo NO es "Otro"
                If Not (sender.SelectedIndex = sender.FindString("Nuevo...")) Then

                    Dim idmodeloselect As String = sender.SelectedValue
                    Dim idtipo As String = conexion.Modelos.Select("idmodelo = " + idmodeloselect + "").CopyToDataTable.Rows(0).Field(Of Integer)("idtipo")

                    Select Case sender.Name



                    End Select
                Else
                    frmCambiosGenerales.Show()
                    frmCambiosGenerales.btnVehiculo.PerformClick()
                End If
            End If
        Else

            Select Case sender.Name


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

    Private Sub VaciarFiltrosVehiculo(sender As Object, e As EventArgs) Handles lblBorrarMaletasFVeh.Click, lblBorrarMarcaFVeh.Click, lblBorrarModeloFVeh.Click, lblBorrarSucursalFVeh.Click
        Select Case sender.Name

            Case "lblBorrarMarcaFVeh"
                If Not cbxMarcaFVeh.SelectedItem Is Nothing Then
                    cbxMarcaFVeh.SelectedItem = Nothing
                End If

                If Not cbxModeloFVeh.SelectedItem Is Nothing Then
                    cbxModeloFVeh.SelectedItem = Nothing
                End If



            Case "lblBorrarModeloFVeh"
                If Not cbxModeloFVeh.SelectedItem Is Nothing Then
                    cbxModeloFVeh.SelectedItem = Nothing
                End If



            Case "lblBorrarTipoFVeh"


            Case "lblBorrarCategoriaFVeh"

            Case "lblBorrarMaletasFVeh"
                If Not cbxMaletasFVeh.SelectedItem Is Nothing Then
                    cbxMaletasFVeh.SelectedItem = Nothing
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

    Private Sub FiltrarVehiculos(sender As Object, e As EventArgs) Handles cbxMarcaFVeh.SelectionChangeCommitted, cbxModeloFVeh.SelectionChangeCommitted, cbxSucursalFVeh.SelectionChangeCommitted, txtAnioFVeh.TextChanged, cbxMaletasFVeh.SelectionChangeCommitted, numPasajerosFVeh.ValueChanged, lblBorrarMaletasFVeh.Click, lblBorrarMarcaFVeh.Click, lblBorrarModeloFVeh.Click, lblBorrarSucursalFVeh.Click, chbxFiltro.CheckedChanged, btnVaciarFVeh.Click

        Dim Filtro As String
        'TODO: filtrar por deducible, color, kilometraje
        'Siguen sin funcionar los cbx de aire y automatico
        Filtro = "nrochasis like '%%'" + TipoFiltro(cbxMaletasFVeh, "cantidaddemaletas") + TipoFiltro(numPasajerosFVeh, "cantidaddepasajeros") + TipoFiltro(cbxMarcaFVeh, "idmarca") + TipoFiltro(cbxModeloFVeh, "idmodelo") + TipoFiltro(cbxSucursalFVeh, "idsucursal") + If(IsNumeric(txtAnioFVeh.Text) And (Not (txtAnioFVeh.Text = "")), "AND anio = " + txtAnioFVeh.Text + "", "")

        dgvVehiculos.DataSource.Filter = Filtro

    End Sub

    Private Sub RellenarDatosVehiculo(sender As Object, e As EventArgs) Handles dgvVehiculos.SelectionChanged

        If Not IsNothing(dgvVehiculos.CurrentRow) Then

        End If
    End Sub


End Class
