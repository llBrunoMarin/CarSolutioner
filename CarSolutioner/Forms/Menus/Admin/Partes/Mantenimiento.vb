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

            If (nrochasisdt.Rows.Count <> 0) Then
                Dim nrochasisinsert As String
                nrochasisinsert = nrochasisdt.Rows(0)(0).ToString()

                Dim format As String = "dd/mm/yyyy hh:mm"

                If (conexion.EjecutarNonQuery("insert into mantenimiento values ('" + cbxTipoMant.SelectedItem.ToString() + "', to_date('" + dtpFechaInicioMant.Value.ToString(format) + "', '%d/%m/%y %h:%m'), to_date('" + dtpFechaFinMant.Value.ToString(format) + "', '%d/%m/%y %h:%m'),'" + nrochasisinsert + "')") = True) Then
                    RecargarDatos(dgvMant)
                    MsgBox("Mantenimiento ingresado")

                    'Else
                    '    MsgBox("Mantenimiento ya existente")

                End If
            Else
                MsgBox("La matricula ingresada no pertenece a un vehículo existente")
            End If

        End If
    End Sub

    Private Sub RellenarDatosMantenimiento(sender As Object, e As EventArgs) Handles dgvMant.SelectionChanged
        If Not IsNothing(dgvMant.CurrentRow) Then

            txtModifMatriculaMant.Text = dgvMant.CurrentRow.Cells("matriculamant").Value.ToString()
            cbxModifTipoMant.SelectedIndex = cbxModifTipoMant.FindString(dgvMant.CurrentRow.Cells("tipomant").Value.ToString())
            dtpModifFechaInicioMant.Value = Date.Parse(dgvMant.CurrentRow.Cells("fechainiciomant").Value).ToShortDateString()
            dtpModifFechaFinMant.Value = Date.Parse(dgvMant.CurrentRow.Cells("fechafinmant").Value).ToShortDateString()
        End If
    End Sub

    Private Sub btnModifMant_Click(sender As Object, e As EventArgs) Handles btnModifMant.Click

        Dim format As String = "dd/MM/yyyy HH:mm"
        Dim nrochasismodif As String
        nrochasismodif = dgvMant.CurrentRow.Cells("nrochasismant").Value.ToString()
        Dim fechainicioant As String
        fechainicioant = Date.Parse(dgvMant.CurrentRow.Cells("fechainiciomant").Value).ToString(format)
        Dim nrochasisant As String
        nrochasisant = dgvMant.CurrentRow.Cells("nrochasismant").Value.ToString()
        Dim tipoant As String
        tipoant = dgvMant.CurrentRow.Cells("tipomant").Value.ToString()


        If (conexion.EjecutarNonQuery("UPDATE mantenimiento SET descripcion ='" + cbxModifTipoMant.SelectedItem + "', fechainicio = TO_DATE('" + dtpFiltrarFechaInicioMant.Value.ToString(format) + "', '%d/%m/%Y %H:%M'), fechafin = TO_DATE('" + dtpFiltrarFechaFinMant.Value.ToString(format) + "', '%d/%m/%Y %H:%M'), estado = 't' WHERE nrochasis='" + nrochasisant + "' AND fechainicio = TO_DATE('" + fechainicioant + "', '%d/%m/%Y %H:%M') AND descripcion = '" + tipoant + "' ") = True) Then
            MsgBox("Modificación existosa")
            RecargarDatos(dgvMant)

        Else
            MsgBox("Mantenimiento ya existente")
        End If

    End Sub

    Private Sub FiltroMantenimiento(sender As Object, e As EventArgs) Handles txtFiltrarMatriculaMant.TextChanged, chbxFiltrarEstadoMant.CheckedChanged,
        cbxFiltrarTipoMant.SelectionChangeCommitted,
       chbxFiltrarFechaMant.CheckStateChanged,
       dtpFiltrarFechaInicioMant.ValueChanged,
       dtpFiltrarFechaFinMant.ValueChanged

        Try
            Dim format As String = "dd/MM/yyyy HH:mm"
            Dim filtro As String

            If chbxFiltrarEstadoMant.Checked Then

                If chbxFiltrarFechaMant.Checked = True Then

                    filtro = String.Format("{0} Like '%{1}%' and fechainiciof = '" + dtpFiltrarFechaInicioMant.Value + "' and fechafinf = '" + dtpFiltrarFechaFinMant.Value + "'", "matricula", (txtFiltrarMatriculaMant.Text) + TipoFiltro(cbxFiltrarTipoMant, "descripcion"))

                    dgvMant.DataSource.Filter = filtro

                Else

                    filtro = String.Format("{0} Like '%{1}%' AND (fechainiciof > '" + DateTime.Today.ToString(format) + "' and fechafinf > '" + DateTime.Today.ToString(format) + "') OR (fechainiciof < '" + DateTime.Today.ToString(format) + "' and fechafinf > '" + DateTime.Today.ToString(format) + "') ", "matricula", txtFiltrarMatriculaMant.Text) +
                    TipoFiltro(cbxFiltrarTipoMant, "descripcion")

                    dgvMant.DataSource.Filter = filtro

                End If
            Else
                If chbxFiltrarFechaMant.Checked = True Then

                    filtro = String.Format("{0} LIKE '%{1}%' and fechainiciof >= '" + dtpFiltrarFechaInicioMant.Value + "' and fechafinf <= '" + dtpFiltrarFechaFinMant.Value + "'",
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

End Class