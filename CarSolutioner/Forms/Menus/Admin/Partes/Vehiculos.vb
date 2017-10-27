'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerVehiculos
End Class

'VEHICULOS
Partial Public Class frmMainMenu

    Private Sub CargasModelo(sender As ComboBox, e As EventArgs) Handles cbxMarcaAVeh.SelectedValueChanged, cbxMarcaFVeh.SelectedValueChanged, cbxMarcaMVeh.SelectedValueChanged

        Dim Modelos As New DataTable

        Try
            If (Not (sender.SelectedValue Is Nothing)) Then

                If (Not (sender.SelectedValue.ToString = "")) Then

                    If (Not (sender.SelectedValue.ToString = "System.Data.DataRowView")) Then

                        'Si el item seleccionado NO es "Otro":
                        If Not (sender.SelectedIndex = sender.FindString("Nueva...")) Then

                            Select Case sender.Name
                                Case "cbxMarcaAVeh"

                                    Modelos = conexion.Modelos.Select("idmarca = '" + cbxMarcaAVeh.SelectedValue.ToString + "' and estado = true").CopyToDataTable
                                    CargarDatosComboBox(cbxModeloAVeh, Modelos, "nombre", "idmodelo")
                                    cbxModeloAVeh.Enabled = True
                                    cbxModeloAVeh.SelectedItem = Nothing
                                    cbxTipoAVeh.SelectedItem = Nothing

                                Case "cbxMarcaFVeh"
                                    CargarDatosComboBox(cbxModeloFVeh, conexion.Modelos.Select("idmarca = '" + cbxMarcaFVeh.SelectedValue.ToString + "' and estado = true").CopyToDataTable, "nombre", "idmodelo")
                                    cbxModeloFVeh.Enabled = True
                                    cbxModeloFVeh.SelectedItem = Nothing
                                    cbxTipoFVeh.SelectedItem = Nothing

                                Case "cbxMarcaMVeh"
                                    CargarDatosComboBox(cbxModeloMVeh, conexion.Modelos.Select("idmarca = '" + cbxMarcaFVeh.SelectedValue.ToString + "' and estado = true").CopyToDataTable, "nombre", "idmodelo")
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

    Private Sub CargasTipo(sender As ComboBox, e As EventArgs) Handles cbxModeloAVeh.SelectedValueChanged, cbxModeloFVeh.SelectedValueChanged, cbxModeloMVeh.SelectedValueChanged
        'Si el valor seleccionado del modelo NO es Nada
        If (Not (sender.SelectedValue Is Nothing)) Then
            If (Not (sender.SelectedValue.ToString = "System.Data.DataRowView")) Then

                'Si el valor seleccionado del modelo NO es "Otro"

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

    Private Sub VaciarFiltrosVehiculo(sender As Object, e As EventArgs) Handles lblBorrarCategoriaFVeh.Click, lblBorrarEstadoFVeh.Click, lblBorrarMaletasFVeh.Click, lblBorrarMarcaFVeh.Click, lblBorrarModeloFVeh.Click, lblBorrarPuertasFVeh.Click, lblBorrarSucursalFVeh.Click, lblBorrarTipoFVeh.Click, lblBorrarColorVeh.Click

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

    Private Sub SoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtDeducibleAVeh.KeyPress, txtKilometrajeAVeh.KeyPress, txtAnioAVeh.KeyPress, txtDeducibleMVeh.KeyPress, txtKilometrajeAVeh.KeyPress, txtAnioMVeh.KeyPress, txtAnioFVeh.KeyPress, txtDeducibleFVeh.KeyPress, txtKMFVeh.KeyPress, txtDeducibleAVeh.KeyPress, txtKilometrajeAVeh.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True

        End If

        sender.focus()
    End Sub

    Private Sub FiltrarVehiculos(sender As Object, e As EventArgs) Handles txtNroChasisFVeh.TextChanged, txtMatriculaFVeh.TextChanged, cbxCategoriaFVeh.SelectionChangeCommitted, cbxMarcaFVeh.SelectionChangeCommitted, cbxModeloFVeh.SelectionChangeCommitted, cbxTipoFVeh.SelectionChangeCommitted, cbxSucursalFVeh.SelectionChangeCommitted, txtAnioFVeh.TextChanged, cbxMaletasFVeh.SelectionChangeCommitted, numPasajerosFVeh.ValueChanged, cbxPuertasFVeh.SelectionChangeCommitted, lblBorrarCategoriaFVeh.Click, lblBorrarEstadoFVeh.Click, lblBorrarMaletasFVeh.Click, lblBorrarMarcaFVeh.Click, lblBorrarModeloFVeh.Click, lblBorrarPuertasFVeh.Click, lblBorrarSucursalFVeh.Click, lblBorrarTipoFVeh.Click, cbxAireFVeh.SelectionChangeCommitted, cbxManualFVeh.SelectionChangeCommitted, chbxFiltroVehiculos.CheckedChanged, lblBorrarColorVeh.Click, cbxColorFVehiculo.SelectionChangeCommitted, btnVaciarFVeh.Click

        Dim Filtro As String
        Filtro = "nrochasis LIKE '%" + txtNroChasisFVeh.Text + "%' AND matricula LIKE '%" + txtMatriculaFVeh.Text + "%'" + TipoFiltro(cbxAireFVeh, "aireacondicionado") + TipoFiltro(cbxManualFVeh, "esmanual") + TipoFiltro(cbxMaletasFVeh, "cantidaddemaletas") + TipoFiltro(cbxPuertasFVeh, "cantidaddepuertas") + TipoFiltro(numPasajerosFVeh, "cantidaddepasajeros") + TipoFiltro(cbxCategoriaFVeh, "idcategoria") + TipoFiltro(cbxMarcaFVeh, "idmarca") + TipoFiltro(cbxModeloFVeh, "idmodelo") + TipoFiltro(cbxTipoFVeh, "idtipo") + TipoFiltro(cbxColorFVehiculo, "color") + TipoFiltro(cbxSucursalFVeh, "idsucursal") + If(IsNumeric(txtAnioFVeh.Text) And (Not (txtAnioFVeh.Text = "")), "AND Convert(anio, System.String) LIKE '" + txtAnioFVeh.Text + "%'", "")

        dgvVehiculos.DataSource.Filter = Filtro


    End Sub

    Private Sub RellenarDatosVehiculo(sender As Object, e As EventArgs) Handles dgvVehiculos.SelectionChanged

        If Not IsNothing(dgvVehiculos.CurrentRow) Then
            CargarDatosComboBox(cbxModeloMVeh, conexion.Modelos.Select("idmarca = '" + dgvVehiculos.CurrentRow.Cells("idmarcaveh").Value.ToString() + "'").CopyToDataTable, "nombre", "idmodelo")
            txtNroChasisMVeh.Enabled = True
            txtNroChasisMVeh.Text = dgvVehiculos.CurrentRow.Cells("nrochasis").Value.ToString()
            txtNroChasisMVeh.Enabled = False
            txtMatriculaMVeh.Text = dgvVehiculos.CurrentRow.Cells("matricula").Value.ToString()
            txtMatriculaBVeh.Text = dgvVehiculos.CurrentRow.Cells("matricula").Value.ToString()
            txtKMMVeh.Text = dgvVehiculos.CurrentRow.Cells("kilometraje").Value.ToString()
            txtDeducibleMVeh.Text = dgvVehiculos.CurrentRow.Cells("deducible").Value.ToString()
            cbxCategoriaMVeh.SelectedValue = dgvVehiculos.CurrentRow.Cells("idcategoriaveh").Value
            cbxMarcaMVeh.SelectedValue = dgvVehiculos.CurrentRow.Cells("idmarcaveh").Value.ToString()
            cbxModeloMVeh.SelectedValue = dgvVehiculos.CurrentRow.Cells("idmodeloveh").Value.ToString()
            cbxTipoMVeh.SelectedValue = dgvVehiculos.CurrentRow.Cells("idtipoveh").Value.ToString()
            If dgvVehiculos.CurrentRow.Cells("idsucursalveh").Value.ToString = "" Then
                cbxSucursalMVeh.Enabled = False
                cbxSucursalMVeh.SelectedItem = Nothing
                pnlMVehi.Enabled = False
            Else
                cbxSucursalMVeh.SelectedValue = dgvVehiculos.CurrentRow.Cells("idsucursalveh").Value.ToString()
                cbxSucursalMVeh.Enabled = True
                pnlMVehi.Enabled = True
            End If
            cbxMaletasMVeh.SelectedItem = dgvVehiculos.CurrentRow.Cells("cantidaddemaletas").Value.ToString()
            numPasajerosMVehiculo.Value = dgvVehiculos.CurrentRow.Cells("cantidaddepasajeros").Value.ToString()
            txtAnioMVeh.Text = dgvVehiculos.CurrentRow.Cells("aniov").Value.ToString()
            cbxPuertasMVeh.SelectedItem = dgvVehiculos.CurrentRow.Cells("cantidaddepuertas").Value.ToString()
            cbxColorMVehiculo.SelectedItem = dgvVehiculos.CurrentRow.Cells("colorvehdgv").Value.ToString()
            Dim chbxaireMvehI As Boolean = dgvVehiculos.CurrentRow.Cells("aireacondicionado").Value
            Dim chbxautomaticoMvehI As Boolean = dgvVehiculos.CurrentRow.Cells("esmanual").Value
            chbxAireMVeh.Checked = chbxaireMvehI
            cbxManualMVeh.Checked = chbxautomaticoMvehI
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
        Dim añoActual As String = Date.Now.Year
        Dim añoInsertar As Integer

        If Not (FaltaDato) Then
            If Not (txtDeducibleAVeh.Text = "" Or txtKilometrajeAVeh.Text = "" Or txtMatriculaAVeh.Text = "" Or txtAnioAVeh.Text = "") Then
                'Me quedo con solo el 1er digito para hacer el insert despues
                automaticoAVeh = cbxManualesAVeh.Checked.ToString.Substring(0, 1)
                aireAVeh = chbxAireAVeh.Checked.ToString.Substring(0, 1)

                cantpasajeros = numPasajerosAVeh.Value.ToString
                añoInsertar = txtAnioAVeh.Text


                If Not (cantpasajeros = 0) Then

                    If Not (añoInsertar > añoActual + 1) Then

                        Dim nrochasisrepetido As New DataTable
                        nrochasisrepetido = conexion.EjecutarSelect("select nrochasis from vehiculo where nrochasis = '" + txtNroChasisAVeh.Text.ToString + "'")


                        If Not (nrochasisrepetido.Rows.Count > 0) Then

                            Dim sentencia As String
                            sentencia = "insert into vehiculo values('" + txtNroChasisAVeh.Text.ToString + "','" + txtMatriculaAVeh.Text.ToString + "','" + txtAnioAVeh.Text.ToString + "','" + txtKilometrajeAVeh.Text.ToString + "','" + aireAVeh + "','" + cbxPuertasAVeh.SelectedItem.ToString + "','" + cantpasajeros + "','" + cbxMaletasAVeh.SelectedItem.ToString + "','" + automaticoAVeh + "','" + txtDeducibleAVeh.Text.ToString + "','" + cbxCategoriaAVeh.SelectedValue.ToString + "','" + cbxModeloAVeh.SelectedValue.ToString + "','" + cbxSucursalAVeh.SelectedValue.ToString + "','t', '" + cbxColorAVeh.SelectedItem.ToString + "')"
                            conexion.EjecutarNonQuery(sentencia)

                            Dim ip As String = GetIPAddress()
                            Dim descripcion As String = "Ingreso un vehiculo con el numero de chasis : " + txtNroChasisAVeh.Text + " la matricula : " + txtMatriculaAVeh.Text + " "
                            conexion.EjecutarNonQuery("INSERT INTO accion VALUES('" + ip + "','" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "','" + descripcion + "','" + conexion.Usuario.ToString + "')")

                            RecargarDatos(dgvVehiculos)
                            AmaranthMessagebox("Vehiculo agregado correctamente.", "Continuar", Me)
                        Else
                            AmaranthMessagebox("Ya posee un vehiculo con el mismo número de chasis. (#039)", "Advertencia", Me)
                        End If
                    Else
                        AmaranthMessagebox("El año del vehiculo no puede ser mayor a " + (añoActual + 1).ToString + " (#040)", "Error", Me)
                    End If
                Else
                    AmaranthMessagebox("La cantidad de pasajeros no puede ser 0. (#041)", "Error", Me)
                End If
            Else
                AmaranthMessagebox("Por favor, rellene todos los campos. (#009)", "Advertencia", Me)
            End If
        Else
            AmaranthMessagebox("Por favor, rellene todos los campos. (#009)", "Advertencia", Me)
        End If
    End Sub

    Private Sub ModificarVehiculo(sender As Object, e As EventArgs) Handles btnModificarVeh.Click
        If Not dgvVehiculos.CurrentRow Is Nothing Then

            Dim FaltaDato As Boolean = False

            For Each ctrl As Control In pnlMVehi.Controls
                If TypeOf (ctrl) Is TextBox Then
                    If ctrl.Text = "" Then
                        FaltaDato = True
                        Exit For
                    End If
                Else
                    If TypeOf (ctrl) Is ComboBox Then
                        If DirectCast(ctrl, ComboBox).SelectedItem Is Nothing Or DirectCast(ctrl, ComboBox).SelectedValue Is Nothing Then
                            FaltaDato = True
                        End If
                    End If
                End If
            Next

            Dim automaticoMVeh As String
            Dim aireMVeh As String
            Dim cantpasajeros As String
            Dim añoActual As String = Date.Now.Year
            Dim añoInsertar As String

            Dim nrochasisI As String = dgvVehiculos.CurrentRow.Cells("nrochasis").Value.ToString()
            Dim matriculaI As String = dgvVehiculos.CurrentRow.Cells("matricula").Value.ToString()
            Dim kmvehI As String = dgvVehiculos.CurrentRow.Cells("kilometraje").Value.ToString()
            Dim deducibleI As String = dgvVehiculos.CurrentRow.Cells("deducible").Value.ToString()
            Dim categoriaI As String = dgvVehiculos.CurrentRow.Cells("idcategoriaveh").Value
            Dim marcaI As String = dgvVehiculos.CurrentRow.Cells("idmarcaveh").Value.ToString()
            Dim modeloI As String = dgvVehiculos.CurrentRow.Cells("idmodeloveh").Value.ToString()
            Dim tipoI As String = dgvVehiculos.CurrentRow.Cells("idtipoveh").Value.ToString()
            Dim sucursalI As String = dgvVehiculos.CurrentRow.Cells("idsucursalveh").Value.ToString()
            Dim anioI As String = dgvVehiculos.CurrentRow.Cells("aniov").Value.ToString()
            Dim maletasI As String = dgvVehiculos.CurrentRow.Cells("cantidaddemaletas").Value.ToString()
            Dim nropasajerosI As String = dgvVehiculos.CurrentRow.Cells("cantidaddepasajeros").Value.ToString()
            Dim puertasI As String = dgvVehiculos.CurrentRow.Cells("cantidaddepuertas").Value.ToString()
            Dim chbxaireMvehI As String = dgvVehiculos.CurrentRow.Cells("aireacondicionado").Value
            Dim chbxautomaticoMvehI As String = dgvVehiculos.CurrentRow.Cells("esmanual").Value

            Dim aireMvehI As String = chbxaireMvehI.Substring(0, 1)
            Dim automaticoMvehI As String = chbxautomaticoMvehI.Substring(0, 1)


            'Me quedo con solo el 1er digito para hacer el insert despues
            automaticoMVeh = cbxManualMVeh.Checked.ToString.Substring(0, 1)
                aireMVeh = chbxAireMVeh.Checked.ToString.Substring(0, 1)
                cantpasajeros = numPasajerosMVehiculo.Value.ToString
                añoInsertar = txtAnioMVeh.Text

            If Not (txtMatriculaMVeh.Text = matriculaI And txtAnioMVeh.Text = anioI And txtKMMVeh.Text = kmvehI And chbxAireMVeh.Checked.ToString.Substring(0, 1) = aireMvehI And cbxPuertasMVeh.SelectedItem.ToString = puertasI And cantpasajeros = nropasajerosI And cbxManualMVeh.Checked.ToString.Substring(0, 1) = automaticoMvehI And txtDeducibleMVeh.Text.ToString = deducibleI And cbxCategoriaMVeh.SelectedValue.ToString = categoriaI And cbxModeloMVeh.SelectedValue.ToString = modeloI And cbxSucursalMVeh.SelectedValue.ToString = sucursalI And txtNroChasisMVeh.Text.ToString = nrochasisI And cbxTipoMVeh.SelectedValue.ToString = tipoI And cbxMarcaMVeh.SelectedValue.ToString = marcaI) Then

                If Not (cantpasajeros = 0) Then

                    If Not (añoInsertar > añoActual + 1) Then

                        'TODO: No controla si el mantenimiento esta activo.
                        Dim mantenimientoActivo As New DataTable
                        mantenimientoActivo = conexion.EjecutarSelect("SELECT nrochasis FROM Mantenimiento WHERE fechainicio <=  '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "' and fechafin >= '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "' and nrochasis = '" + nrochasisI + "'")

                        If (mantenimientoActivo.Rows.Count = 0) Then

                            Dim sentencia As String
                            sentencia = "UPDATE vehiculo SET matricula = '" + txtMatriculaMVeh.Text.ToString.ToUpper + "', anio ='" + txtAnioMVeh.Text + "',  kilometraje ='" + txtKMMVeh.Text + "', aireacondicionado ='" + aireMVeh + "',  cantidaddepuertas ='" + cbxPuertasMVeh.SelectedItem.ToString + "', cantidaddepasajeros='" + cantpasajeros + "',  cantidaddemaletas='" + cbxMaletasMVeh.SelectedItem.ToString + "', esmanual='" + automaticoMVeh + "',  deducible ='" + txtDeducibleMVeh.Text.ToString + "', idcategoria='" + cbxCategoriaMVeh.SelectedValue.ToString + "', idmodelo='" + cbxModeloMVeh.SelectedValue.ToString + "',  idsucursal='" + cbxSucursalMVeh.SelectedValue.ToString + "', estado ='T', color = '" + cbxColorMVehiculo.SelectedItem.ToString + "' WHERE nrochasis = '" + nrochasisI + "'"
                            conexion.EjecutarNonQuery(sentencia)
                            RecargarDatos(dgvVehiculos)
                            AmaranthMessagebox("Modificado correctamente.", "Continuar", Me)

                        Else
                            AmaranthMessagebox("Este vehiculo se encuentra en mantenimiento no puede modificarlo. (#042)", "Error", Me)
                        End If

                    Else
                        AmaranthMessagebox("El año del vehiculo no puede ser mayor a " + (añoActual + 1).ToString + " (#040)", "Error", Me)
                    End If
                Else
                    AmaranthMessagebox("La cantidad de pasajeros no puede ser 0. (#041)", "Error", Me)
                End If
            Else
                AmaranthMessagebox("Modifique algo por favor. (#010)", "Advertencia", Me)
            End If
        End If

    End Sub

    Private Sub ActualizarVehiculo(sender As Object, e As EventArgs) Handles btnBajaBVeh.Click
        If Not dgvVehiculos.CurrentRow Is Nothing Then

            Dim Valores As New Dictionary(Of Boolean, String)
            Valores.Add(True, "Activo")
            Valores.Add(False, "Inactivo")

            If Not (txtMatriculaBVeh.Text.ToString = "") Then

                Dim matriculaDT As New DataTable
                matriculaDT = conexion.EjecutarSelect("Select matricula, estado FROM vehiculo WHERE matricula='" + txtMatriculaBVeh.Text.ToString + "'")

                If (matriculaDT.Rows.Count <> 0) Then

                    Dim nrochasis As New DataTable
                    nrochasis = conexion.EjecutarSelect("SELECT nrochasis FROM vehiculo WHERE matricula = '" + txtMatriculaBVeh.Text.ToString + "'")

                    Dim nrochasisS As String
                    nrochasisS = nrochasis.Rows(0)("nrochasis").ToString()

                    Dim alquilerActivo As New DataTable
                    alquilerActivo = conexion.EjecutarSelect("SELECT nrochasis FROM vehiculo WHERE nrochasis = '" + nrochasisS + "' and idsucursal is null")

                    Dim mantenimientoActivo As New DataTable
                    mantenimientoActivo = conexion.EjecutarSelect("SELECT nrochasis FROM Mantenimiento WHERE fechainicio <=  '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "' and fechafin >= '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "' and nrochasis = '" + nrochasisS + "'")

                    If (mantenimientoActivo.Rows.Count = 0 And alquilerActivo.Rows.Count = 0) Then

                        If (AmaranthMessagebox("Seguro que quiere dar de baja este vehiculo?.", "Si/No", Me) = vbYes) Then

                            Dim matriculaI As String = matriculaDT.Rows(0)("matricula").ToString()
                            Dim EstadoActual As Boolean = matriculaDT.Rows(0)("estado")
                            Dim NuevoEstado As Boolean = Not EstadoActual
                            Dim sentencia As String
                            sentencia = "UPDATE vehiculo SET estado ='" + NuevoEstado.ToString().Substring(0, 1) + "' WHERE matricula = '" + matriculaI.ToString + "'"
                            If (conexion.EjecutarNonQuery(sentencia)) Then

                                MsgBox("Vehiculo pasó del estado " + Valores.Item(EstadoActual) + " a " + Valores.Item(NuevoEstado) + "")
                                RecargarDatos(dgvVehiculos)
                            End If
                        End If
                    Else
                        AmaranthMessagebox("No es posible dar de baja este vehiculo debido a que tiene un alquiler o mantenimiento activo, (#042,#043)0", "Advertencia", Me)
                    End If
                Else
                    AmaranthMessagebox("No existe esa matricula. (#044)", "Error", Me)
                End If
            Else
                AmaranthMessagebox("Ingrese una matricul. (#045)", "Advertencia", Me)
            End If
        End If

    End Sub

    Private Sub antiSQLInjection(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtMatriculaFVeh.KeyPress
        e.Handled = Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsNumber(e.KeyChar)
    End Sub

End Class
