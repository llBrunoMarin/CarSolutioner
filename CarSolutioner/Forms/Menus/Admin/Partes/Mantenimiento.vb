'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerMantenimiento
End Class

'MANTENIMIENTO
Partial Public Class frmMainMenu
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
            Dim verifnrochasis As String
            Dim nrochasisinsert As String
            If (nrochasisdt.Rows.Count > 0) Then
                nrochasisinsert = nrochasisdt.Rows(0)(0).ToString()

                Dim verifalquiler As New DataTable
                verifalquiler = conexion.EjecutarSelect("SELECT * FROM reserva where nrochasis = '" + nrochasisinsert + "'")
                verifnrochasis = "SELECT * FROM mantenimiento WHERE nrochasis = '" + nrochasisinsert + "' AND ((fechafin BETWEEN '" + dtpFechaInicioMant.Value.ToString("yyyy-MM-dd HH:mm") + "' AND '" + dtpFechaFinMant.Value.ToString("yyyy-MM-dd HH:mm") + "') OR (fechainicio BETWEEN '" + dtpFiltrarFechaInicioMant.Value.ToString("yyyy-MM-dd HH:mm") + "' AND '" + dtpFiltrarFechaFinMant.Value.ToString("yyyy-MM-dd HH:mm") + "') OR (fechainicio < '" + dtpFechaInicioMant.Value.ToString("yyyy-MM-dd HH:mm") + "' AND fechafin > '" + dtpFechaFinMant.Value.ToString("yyyy-MM-dd HH:mm") + "'))"




                If Not (verifalquiler.Rows.Count <> 0) Then

                    If (nrochasisdt.Rows.Count <> 0) Then

                        If dtpFechaInicioMant.Value.ToString(format) > dtpFechaFinMant.Value.ToString(format) Then
                            MsgBox("No puede definir una fecha de inicio mayor a la fecha de fin")
                        Else

                            If (conexion.EjecutarNonQuery("INSERT into mantenimiento VALUES ('" + cbxTipoMant.SelectedItem.ToString() + "','" + dtpFechaInicioMant.Value.ToString(format) + "', '" + dtpFechaFinMant.Value.ToString(format) + "', '" + nrochasisinsert + "')") = True) Then

                                RecargarDatos(dgvMant)
                                MsgBox("Mantenimiento ingresado")

                            Else
                                MsgBox("Mantenimiento ya existente")

                            End If
                        End If

                    Else
                        MsgBox("El vehículo se encuentra en mantenimiento")
                    End If
                Else
                    MsgBox("Existe un mantenimiento activo")
                End If
            Else
                MsgBox("Matricula no existe")
            End If
        Else
                MsgBox("No pueden quedar campos vacíos")
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
            nrochasisinsert = nrochasisdt.Rows(0)(0).ToString()
            Dim sentencia As String
            sentencia = "SELECT * FROM mantenimiento WHERE nrochasis = '" + nrochasisinsert + "' AND ((fechafin BETWEEN '" + dtpFechaInicioMant.Value.ToString("yyyy-MM-dd HH:mm") + "' AND '" + dtpFechaFinMant.Value.ToString("yyyy-MM-dd HH:mm") + "') OR (fechainicio BETWEEN '" + dtpFiltrarFechaInicioMant.Value.ToString("yyyy-MM-dd HH:mm") + "' AND '" + dtpFiltrarFechaFinMant.Value.ToString("yyyy-MM-dd HH:mm") + "') OR (fechainicio < '" + dtpFechaInicioMant.Value.ToString("yyyy-MM-dd HH:mm") + "' AND fechafin > '" + dtpFechaFinMant.Value.ToString("yyyy-MM-dd HH:mm") + "'))"

            If conexion.EjecutarSelect(sentencia).Rows.Count = 0 Then

                If Not (dtpModifFechaInicioMant.Value.ToString(format) = fechainicioant And dtpModifFechaFinMant.Value.ToString(format) = fechafinant And tipoant = cbxModifTipoMant.SelectedItem And txtModifMatriculaMant.Text = matriculaant) Then

                    If dtpModifFechaInicioMant.Value.ToString(format) > dtpModifFechaFinMant.Value.ToString(format) Then

                        MsgBox("No puede definir una fecha de inicio mayor a la fecha de fin")

                    Else

                        If (conexion.EjecutarNonQuery("UPDATE mantenimiento SET descripcion ='" + cbxModifTipoMant.SelectedItem + "', fechainicio = '" + dtpModifFechaInicioMant.Value.ToString(format) + "', fechafin = '" + dtpModifFechaFinMant.Value.ToString(format) + "' WHERE nrochasis='" + nrochasisant + "' AND fechainicio = '" + fechainicioant + "' AND descripcion = '" + tipoant + "' ") = True) Then
                            MsgBox("Modificación existosa")
                            RecargarDatos(dgvMant)
                        Else
                            MsgBox("Mantenimiento ya existente")
                        End If

                    End If
                Else
                    MsgBox("No se han cambiado datos")
                End If

            End If
        Else
            MsgBox("No pueden quedar campos vacios")
        End If
    End Sub

    Private Sub FiltroMantenimiento(sender As Object, e As EventArgs) Handles txtFiltrarMatriculaMant.TextChanged, chbxFiltrarEstadoMant.CheckedChanged, cbxFiltrarTipoMant.SelectionChangeCommitted, chbxFiltrarFechaMant.CheckStateChanged, dtpFiltrarFechaInicioMant.ValueChanged, dtpFiltrarFechaFinMant.ValueChanged
        Try
            Dim format As String = "dd/MM/yyyy HH:mm"
            Dim filtro As String

            If chbxFiltrarEstadoMant.Checked Then

                If chbxFiltrarFechaMant.Checked = True Then

                    filtro = String.Format("{0} Like '%{1}%' and fechainiciof = '" + dtpFiltrarFechaInicioMant.Value.ToString(format) + "' and fechafinf = '" + dtpFiltrarFechaFinMant.Value.ToString(format) + "'", "matricula", (txtFiltrarMatriculaMant.Text) + TipoFiltro(cbxFiltrarTipoMant, "descripcion"))

                    dgvMant.DataSource.Filter = filtro

                Else

                    filtro = String.Format("{0} Like '%{1}%' AND (fechainiciof > '" + Date.Now.ToString(format) + "' and fechafinf > '" + Date.Now.ToString(format) + "') OR (fechainiciof < '" + Date.Now.ToString(format) + "' and fechafinf > '" + Date.Now.ToString(format) + "') ", "matricula", txtFiltrarMatriculaMant.Text) +
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
        RecargarDatos(dgvMant)
    End Sub

    Private Sub VaciarModificarMantenimiento(sender As Object, e As EventArgs) Handles btnVaciarMant.Click
        For Each item In pnlmmant.Controls

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

    Private Sub btnVaciarIngresoMant_Click(sender As Object, e As EventArgs) Handles btnVaciarIngresoMant.Click
        For Each item In pnlAmant.Controls

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
End Class