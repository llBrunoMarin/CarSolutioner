'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerMantenimiento
End Class

'MANTENIMIENTO
Partial Public Class frmMainMenu

    Private Sub OcultarDTP(sender As Object, e As EventArgs) Handles chbxFiltrarFechaMant.CheckedChanged
        If chbxFiltrarFechaMant.Checked Then
            dtpFiltrarFechaFinMant.Enabled = True
            dtpFiltrarFechaInicioMant.Enabled = True
            lblFechaFinFiltradoMant.Enabled = True
            lblFechaInicioFiltradoMant.Enabled = True
        Else
            dtpFiltrarFechaFinMant.Enabled = False
            dtpFiltrarFechaInicioMant.Enabled = False
            lblFechaFinFiltradoMant.Enabled = False
            lblFechaInicioFiltradoMant.Enabled = False
        End If
    End Sub

    Private Sub btnIngresarMant_Click(sender As Object, e As EventArgs) Handles btnIngresarMant.Click

        Dim FaltaDato As Boolean = False
        For Each ctrl As Control In pnlAmant.Controls
            If TypeOf (ctrl) Is TextBox Then
                If ctrl.Text = "" Then
                    FaltaDato = True
                    Exit For
                End If
            Else
                If TypeOf (ctrl) Is ComboBox Then
                    If DirectCast(ctrl, ComboBox).SelectedItem Is Nothing Then
                        FaltaDato = True
                    End If
                End If
            End If
        Next
        If Not FaltaDato = True Then
            Dim nrochasisdt As New DataTable
            nrochasisdt = conexion.EjecutarSelect("SELECT nrochasis FROM vehiculo WHERE matricula ='" + txtMatriculaMant.Text.ToString + "'")
            Dim format As String = "yyyy-MM-dd HH:mm"

            Dim nrochasisinsert As String

            If (nrochasisdt.Rows.Count > 0) Then
                nrochasisinsert = nrochasisdt.Rows(0)(0).ToString()

                Dim verifalquiler As New DataTable
                Dim verifestadoveh As New DataTable
                Dim verifnrochasis As New DataTable
                verifalquiler = conexion.EjecutarSelect("SELECT * FROM reserva where nrochasis = '" + nrochasisinsert + "'")
                verifnrochasis = conexion.EjecutarSelect("SELECT * FROM mantenimiento WHERE nrochasis = '" + nrochasisinsert + "' AND descripcion = '" + cbxTipoMant.SelectedItem + "' AND ((fechafin BETWEEN '" + dtpFechaInicioMant.Value.ToString("yyyy-MM-dd HH:mm") + "' AND '" + dtpFechaFinMant.Value.ToString("yyyy-MM-dd HH:mm") + "') OR (fechainicio BETWEEN '" + dtpFechaInicioMant.Value.ToString("yyyy-MM-dd HH:mm") + "' AND '" + dtpFechaFinMant.Value.ToString("yyyy-MM-dd HH:mm") + "') OR (fechainicio < '" + dtpFechaInicioMant.Value.ToString("yyyy-MM-dd HH:mm") + "' AND fechafin > '" + dtpFechaFinMant.Value.ToString("yyyy-MM-dd HH:mm") + "'))")
                verifestadoveh = conexion.EjecutarSelect("SELECT * FROM vehiculo where nrochasis ='" + nrochasisinsert + "' AND estado= 'f'")

                If Not (verifestadoveh.Rows.Count <> 0) Then
                    If Not (verifalquiler.Rows.Count <> 0) Then
                        If Not (verifnrochasis.Rows.Count <> 0) Then
                            If dtpFechaInicioMant.Value.ToString(format) > dtpFechaFinMant.Value.ToString(format) Then
                                AmaranthMessagebox("No puede definir una fecha de inicio mayor a la fecha de fin", "Advertencia", Me)
                            Else

                                If (conexion.EjecutarNonQuery("INSERT into mantenimiento VALUES ('" + cbxTipoMant.SelectedItem.ToString() + "','" + dtpFechaInicioMant.Value.ToString(format) + "', '" + dtpFechaFinMant.Value.ToString(format) + "', '" + nrochasisinsert + "')") = True) Then

                                    Dim ip As String = GetIPAddress()
                                    Dim descripcion As String = "Ingreso un mantenimiento con la matricula : " + txtMatriculaMant.Text.ToString + ", con el tipo " + cbxTipoMant.SelectedItem.ToString() + ", fecha de inicio : " + dtpFechaInicioMant.Value.ToString(format) + " y fecha de fin : " + dtpFechaFinMant.Value.ToString(format) + " "
                                    conexion.EjecutarNonQuery("INSERT INTO accion VALUES('" + ip + "','" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "','" + descripcion + "','" + conexion.Usuario.ToString + "')")

                                    RecargarDatos(dgvMant)
                                    AmaranthMessagebox("Mantenimiento ingresado", "Continuar", Me)

                                Else
                                    AmaranthMessagebox("Mantenimiento ya existente", "Error", Me)

                                End If
                            End If
                        Else
                            AmaranthMessagebox("Existe un mantenimiento activo", "Error", Me)
                        End If
                    Else
                        AmaranthMessagebox("El vehículo se encuentra en alquiler", "Advertencia", Me)
                    End If
                Else
                    AmaranthMessagebox("El vehículo está inactivo", "Advertencia", Me)
                End If
            Else
                AmaranthMessagebox("Matricula no existe", "Error", Me)
            End If
        Else
            AmaranthMessagebox("No pueden quedar campos vacíos. (#009)", "Advertencia", Me)
        End If
    End Sub

    Private Sub RellenarDatosMantenimiento(sender As Object, e As EventArgs) Handles dgvMant.SelectionChanged
        If Not IsNothing(dgvMant.CurrentRow) Then
            Dim format As String = "yyyy-MM-dd HH:mm"
            txtModifMatriculaMant.Text = dgvMant.CurrentRow.Cells("matriculamant").Value.ToString()
            cbxModifTipoMant.SelectedIndex = cbxModifTipoMant.FindString(dgvMant.CurrentRow.Cells("tipomant").Value.ToString())
            dtpModifFechaInicioMant.Value = Date.Parse(dgvMant.CurrentRow.Cells("fechainiciomant").Value).ToString(Format)
            dtpModifFechaFinMant.Value = Date.Parse(dgvMant.CurrentRow.Cells("fechafinmant").Value).ToString(Format)
        End If
    End Sub

    Private Sub btnModifMant_Click(sender As Object, e As EventArgs) Handles btnModifMant.Click

        Dim format As String = "yyyy-MM-dd HH:mm"
        Dim nrochasismodif As String = dgvMant.CurrentRow.Cells("nrochasismant").Value.ToString()
        Dim fechainicioant As String = Date.Parse(dgvMant.CurrentRow.Cells("fechainiciomant").Value).ToString(format)
        Dim nrochasisant As String = dgvMant.CurrentRow.Cells("nrochasismant").Value.ToString()
        Dim tipoant As String = dgvMant.CurrentRow.Cells("tipomant").Value.ToString()
        Dim fechafinant As String = Date.Parse(dgvMant.CurrentRow.Cells("fechafinmant").Value).ToString(format)
        Dim matriculaant As String = dgvMant.CurrentRow.Cells("matriculamant").Value.ToString()
        Dim FaltaDato As Boolean = False

        For Each ctrl As Control In pnlmmant.Controls
            If TypeOf (ctrl) Is TextBox Then
                If ctrl.Text = "" Then
                    FaltaDato = True
                    Exit For
                End If
            Else
                If TypeOf (ctrl) Is ComboBox Then
                    If DirectCast(ctrl, ComboBox).SelectedItem Is Nothing Then
                        FaltaDato = True
                    End If
                End If
            End If
        Next

        If Not FaltaDato = True Then
            Dim nrochasisdt As New DataTable
            nrochasisdt = conexion.EjecutarSelect("SELECT nrochasis FROM vehiculo WHERE matricula ='" + txtModifMatriculaMant.Text.ToString + "'")
            Dim nrochasisinsert As String
            If (nrochasisdt.Rows.Count > 0) Then
                nrochasisinsert = nrochasisdt.Rows(0)(0).ToString()

                If Not (dtpModifFechaInicioMant.Value.ToString(format) = fechainicioant And dtpModifFechaFinMant.Value.ToString(format) = fechafinant And tipoant = cbxModifTipoMant.SelectedItem And txtModifMatriculaMant.Text = matriculaant) Then

                    If dtpModifFechaInicioMant.Value.ToString(format) > dtpModifFechaFinMant.Value.ToString(format) Then

                        AmaranthMessagebox("No puede definir una fecha de inicio mayor a la fecha de fin", "Advertencia", Me)

                    Else
                        If (conexion.EjecutarNonQuery("UPDATE mantenimiento SET descripcion ='" + cbxModifTipoMant.SelectedItem + "', fechainicio = '" + dtpModifFechaInicioMant.Value.ToString(format) + "', fechafin = '" + dtpModifFechaFinMant.Value.ToString(format) + "' WHERE nrochasis='" + nrochasisant + "' AND fechainicio = '" + fechainicioant + "' AND descripcion = '" + tipoant + "'") = True) Then

                            Dim ip As String = GetIPAddress()
                            Dim descripcion As String = "Modifico el mantenimiento con la matricula : " + matriculaant + ", con la fecha de inicio :" + dtpModifFechaInicioMant.Value.ToString(format) + ", la fecha fin :" + dtpModifFechaFinMant.Value.ToString(format) + " y la descripcion a :" + cbxModifTipoMant.SelectedItem + ""
                            conexion.EjecutarNonQuery("INSERT INTO accion VALUES('" + ip + "','" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "','" + descripcion + "','" + conexion.Usuario.ToString + "')")

                            AmaranthMessagebox("Modificación existosa", "Continuar", Me)
                            RecargarDatos(dgvMant)

                        Else
                            MsgBox("Error")
                        End If

                    End If
                Else
                    AmaranthMessagebox("No se han realizado cambios", "Advertencia", Me)
                End If

                Else
                AmaranthMessagebox("Matricula no existente", "Error", Me)
            End If
        Else
            AmaranthMessagebox("No pueden quedar campos vacios", "Advertencia", Me)
        End If
    End Sub

    Private Sub FiltroMantenimiento(sender As Object, e As EventArgs) Handles txtFiltrarMatriculaMant.TextChanged, chbxFiltrarEstadoMant.CheckedChanged, cbxFiltrarTipoMant.SelectionChangeCommitted, chbxFiltrarFechaMant.CheckStateChanged, dtpFiltrarFechaInicioMant.ValueChanged, dtpFiltrarFechaFinMant.ValueChanged
        Try
            Dim format As String = "dd/MM/yyyy HH:mm"
            Dim filtro As String

            If chbxFiltrarEstadoMant.Checked Then

                If chbxFiltrarFechaMant.Checked = True Then

                    filtro = String.Format("{0} Like '%{1}%' and ((fechainiciof <= '" + Date.Now.ToString(format) + "' and fechafinf >= '" + Date.Now.ToString(format) + "') OR (fechainiciof > '" + Date.Now.ToString(format) + "')) and fechainiciof >= '" + dtpFiltrarFechaInicioMant.Value.ToString(format) + "' and fechafinf <= '" + dtpFiltrarFechaFinMant.Value.ToString(format) + "'", "matricula", (txtFiltrarMatriculaMant.Text) + TipoFiltro(cbxFiltrarTipoMant, "descripcion"))

                    dgvMant.DataSource.Filter = filtro

                Else

                    filtro = String.Format("{0} Like '%{1}%' AND ((fechainiciof <= '" + Date.Now.ToString(format) + "' and fechafinf >= '" + Date.Now.ToString(format) + "') OR (fechainiciof > '" + Date.Now.ToString(format) + "')) ", "matricula", txtFiltrarMatriculaMant.Text) +
                TipoFiltro(cbxFiltrarTipoMant, "descripcion")

                    dgvMant.DataSource.Filter = filtro

                End If

            Else

                If chbxFiltrarFechaMant.Checked = True Then

                    filtro = String.Format("{0} LIKE '%{1}%' and fechainiciof >= '" + dtpFiltrarFechaInicioMant.Value.ToString(format) + "' and fechafinf <= '" + dtpFiltrarFechaFinMant.Value.ToString(format) + "'",
                                           "matricula", txtFiltrarMatriculaMant.Text) + TipoFiltro(cbxFiltrarTipoMant, "descripcion")
                    dgvMant.DataSource.Filter = filtro


                Else

                    filtro = String.Format("{0} LIKE '%{1}%'", "matricula", txtFiltrarMatriculaMant.Text) +
                  TipoFiltro(cbxFiltrarTipoMant, "descripcion")

                    dgvMant.DataSource.Filter = filtro

                End If
            End If
        Catch ex As NullReferenceException

        End Try
    End Sub

    Private Sub BorrarFiltroTipoMantenimiento(sender As Object, e As EventArgs) Handles lblBorraFiltroTipoManenimiento.Click
        cbxFiltrarTipoMant.SelectedItem = Nothing
        RecargarDatos(dgvMant)
    End Sub

    Private Sub VaciarFiltradoMantenimiento(sender As Object, e As EventArgs) Handles btnVaciarFiltradoMant.Click

        For Each item In pnlFmant.Controls

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
        dtpFiltrarFechaInicioMant.Value = Date.Now.Round()
        dtpFiltrarFechaFinMant.Value = Date.Now.Round().AddHours(1)
        chbxFiltrarFechaMant.Checked = False
        RecargarDatos(dgvMant)
    End Sub

    Private Sub btnBajamant_Click(sender As Object, e As EventArgs) Handles btnBajamant.Click

        Dim format As String = "yyyy-MM-dd HH:mm"
        Dim nrochasismodif As String
        nrochasismodif = dgvMant.CurrentRow.Cells("nrochasismant").Value.ToString()
        Dim fechainicioant As String
        fechainicioant = Date.Parse(dgvMant.CurrentRow.Cells("fechainiciomant").Value).ToString(format)
        Dim nrochasisant As String
        nrochasisant = dgvMant.CurrentRow.Cells("nrochasismant").Value.ToString()
        Dim tipoant As String
        tipoant = dgvMant.CurrentRow.Cells("tipomant").Value.ToString()
        Dim fechafinant As String
        fechafinant = Date.Parse(dgvMant.CurrentRow.Cells("fechafinmant").Value).ToString(format)
        Dim matriculaant As String
        matriculaant = dgvMant.CurrentRow.Cells("matriculamant").Value.ToString()
        Dim FaltaDato As Boolean = False

        If AmaranthMessagebox("Desea cambiar el estado de este mantenimiento?", "Si/No", Me) = vbYes Then

            If (conexion.EjecutarNonQuery("UPDATE mantenimiento SET  fechafin = '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "' WHERE nrochasis='" + nrochasisant + "' AND fechainicio = '" + fechainicioant + "' AND descripcion = '" + tipoant + "' ") = True) Then

                Dim ip As String = GetIPAddress()
                Dim descripcion As String = "Modifico el estado del mantenimiento con la matricula : " + matriculaant + ""
                conexion.EjecutarNonQuery("INSERT INTO accion VALUES('" + ip + "','" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "','" + descripcion + "','" + conexion.Usuario.ToString + "')")

                MsgBox("Modificación existosa")
                RecargarDatos(dgvMant)
            End If

        End If

    End Sub

End Class