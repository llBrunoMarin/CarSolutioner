'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerVehiculos
End Class

'VEHICULOS
Partial Public Class frmMainMenu

    Private Sub CargasModelo(sender As ComboBox, e As EventArgs) Handles cbxMarcaAVeh.SelectionChangeCommitted, cbxMarcaFVeh.SelectionChangeCommitted, cbxMarcaMVeh.SelectionChangeCommitted

        If Not sender.SelectedValue Is Nothing Then

            If Not sender.SelectedValue.ToString = "" Then

                'Si el item seleccionado NO es "Otro":
                If Not DirectCast(sender, ComboBox).SelectedValue.ToString = "Otro" Then

                    If conexion.Modelos.Select("nombre = 'Otro'").Count = 0 Then
                        conexion.Modelos.Rows.Add(0, 0, "Otro", 0)
                    End If

                    If sender Is cbxMarcaAVeh Then

                        Dim MarcaSeleccionada As Integer = conexion.Marcas.Select("nombre = '" + cbxMarcaAVeh.SelectedValue.ToString + "'").CopyToDataTable.Rows(0)(0)
                        CargarDatosComboBox(cbxModeloAVeh, conexion.Modelos.Select("idmarca = '" + MarcaSeleccionada + "'").CopyToDataTable, "nombre")

                    ElseIf sender Is cbxMarcaFVeh Then

                        Dim MarcaSeleccionada As Integer = conexion.Marcas.Select("nombre = '" + cbxMarcaFVeh.SelectedValue.ToString + "'").CopyToDataTable.Rows(0)(0)
                        CargarDatosComboBox(cbxModeloFVeh, conexion.Modelos.Select("idmarca = '" + MarcaSeleccionada.ToString + "'").CopyToDataTable, "nombre")

                    End If

                    'Si el item seleccionado es "Otro"
                Else
                    frmCambiosGenerales.Show()
                    frmCambiosGenerales.btnMarcas.PerformClick()
                End If

            End If

        End If

    End Sub

    Private Sub CargasTipo(sender As ComboBox, e As EventArgs) Handles cbxModeloAVeh.SelectedValueChanged, cbxModeloFVeh.SelectedValueChanged

        If Not (sender.SelectedValue Is Nothing) Then
            'TODO: Ver por qué esto se ejecuta 2 veces la primera vez que cambiamos la marca
            If Not (sender.SelectedValue.ToString = "System.Data.DataRowView") Then

                Dim idmodeloselect As String = conexion.Modelos.Select("nombre = '" + sender.SelectedValue.ToString + "'").CopyToDataTable.Rows(0).Field(Of Integer)("idmodelo")
                Dim idtipo As String = conexion.Modelos.Select("idmodelo = " + idmodeloselect.ToString + "").CopyToDataTable.Rows(0).Field(Of Integer)("idtipo")
                Dim nombretipo As String = conexion.Tipos.Select("idtipo = " + idtipo + "").CopyToDataTable.Rows(0).Field(Of String)("nombre")

                Select Case sender.Name
                    Case "cbxModeloAVeh"
                        cbxTipoAVeh.SelectedValue = nombretipo
                        cbxTipoAVeh.Enabled = False
                    Case "cbxModeloFVeh"
                        cbxTipoFVeh.SelectedValue = nombretipo
                        cbxTipoFVeh.Enabled = False
                    Case Else

                End Select
            End If
        Else
            Select Case sender.Name
                Case "cbxModeloAVeh"
                    cbxTipoAVeh.Enabled = True
                Case "cbxModeloFVeh"
                    cbxTipoFVeh.Enabled = True
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


            Case "lblBorrarEstadoFVeh"
                If Not cbxEstadoFVeh.SelectedItem Is Nothing Then
                    cbxEstadoFVeh.SelectedItem = Nothing
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


    Private Sub RellenarDatosVehiculo(sender As Object, e As EventArgs) Handles dgvVehiculos.SelectionChanged

        If Not IsNothing(dgvVehiculos.CurrentRow) Then

            'cbxTipoDocumMCliente.SelectedItem = dgvClientes.CurrentRow.Cells(0).Value.ToString()
            'txtDocumMCliente.Text = dgvVehiculos.CurrentRow.Cells(1).Value.ToString()
            'txtNombreMCliente.Text = dgvVehiculos.CurrentRow.Cells(2).Value.ToString
            'txtApellidoMCliente.Text = dgvVehiculos.CurrentRow.Cells(3).Value.ToString()
            'txtCorreoMCliente.Text = dgvVehiculos.CurrentRow.Cells(4).Value.ToString()
            'dtpFecNacMCliente.Value = dgvVehiculos.CurrentRow.Cells(5).Value.ToString()
            'txtEmpresaMCliente.Text = dgvVehiculos.CurrentRow.Cells(6).Value.ToString()

            'txtNombreMCliente.Text = dgvClientes.CurrentRow.Cells(0).ToString()
            'txtNombreMCliente.Text = dgvClientes.CurrentRow.Cells(0).ToString()

        End If


    End Sub

    Private Sub lblBorrarMarcaFVeh_Click(sender As Object, e As EventArgs) Handles lblBorrarMarcaFVeh.Click
        cbxMarcaFVeh.SelectedItem = Nothing
        cbxMarcaFVeh.Text = "Todos"

    End Sub
End Class
