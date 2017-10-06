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
            Dim nrochasisinsert As String
            nrochasisinsert = conexion.EjecutarSelect("SELECT nrochasis FROM vehiculo WHERE matricula ='" + txtMatriculaMant.Text.ToString + "'").Rows(0)(0).ToString

            Dim prueba As String
            prueba = ("INSERT INTO mantenimiento VALUES (
                                  '" + cbxTipoMant.SelectedItem + "',
                                  '" + dtpFechaInicioMant.Value.ToShortDateString + "', 
                                  '" + dtpFechaFinMant.Value.ToShortDateString + "',
                                  '" + nrochasisinsert + "  ',
                                  't')")
            conexion.EjecutarNonQuery(prueba)
            RecargarDatos(dgvMant)
        Else
            MsgBox("Los campos no deben quedar vacíos")
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

        Dim nrochasismodif As String
        nrochasismodif = dgvMant.CurrentRow.Cells("nrochasismant").Value.ToString()
        Dim fechainicioant As String
        fechainicioant = Date.Parse(dgvMant.CurrentRow.Cells("fechainiciomant").Value).ToShortDateString()
        Dim nrochasisant As String
        nrochasisant = dgvMant.CurrentRow.Cells("nrochasismant").Value.ToString()
        Dim tipoant As String
        tipoant = dgvMant.CurrentRow.Cells("tipomant").Value.ToString()

        If (conexion.EjecutarNonQuery("UPDATE mantenimiento SET descripcion ='" + cbxModifTipoMant.SelectedItem + "', fechainicio = '" + dtpModifFechaInicioMant.Value.ToShortDateString + "', fechafin = '" + dtpModifFechaFinMant.Value.ToShortDateString + "', estado = 't' WHERE nrochasis='" + nrochasisant + "' AND fechainicio = '" + fechainicioant + "' AND descripcion = '" + tipoant + "' ") = True) Then
            MsgBox("Modificación existosa")
            RecargarDatos(dgvMant)
        End If
    End Sub

    Private Sub FiltroMantenimiento(sender As Object, e As EventArgs) Handles txtFiltrarMatriculaMant.TextChanged, chbxFiltrarEstadoMant.CheckedChanged,
        cbxFiltrarTipoMant.SelectionChangeCommitted,
       chbxFiltrarFechaMant.CheckStateChanged,
       dtpFiltrarFechaInicioMant.ValueChanged,
       dtpFiltrarFechaFinMant.ValueChanged

        Try
            Dim filtro As String

            If chbxFiltrarEstadoMant.Checked Then

                If chbxFiltrarFechaMant.Checked = True Then

                    filtro = String.Format("{0} Like '%{1}%' and fechainicio >= '" + dtpFiltrarFechaInicioMant.Value.ToShortDateString + "' and fechafin <= '" + dtpFiltrarFechaFinMant.Value.ToShortDateString + "'",
                                           "matricula", txtFiltrarMatriculaMant.Text) + TipoFiltro(cbxFiltrarTipoMant, "descripcion")
                    dgvMant.DataSource.Filter = filtro

                Else

                    filtro = String.Format("{0} Like '%{1}%' ", "matricula", txtFiltrarMatriculaMant.Text) +
                    TipoFiltro(cbxFiltrarTipoMant, "descripcion")

                    dgvMant.DataSource.Filter = filtro

                End If
            Else
                If chbxFiltrarFechaMant.Checked = True Then

                    filtro = String.Format("{0} LIKE '%{1}%' and fechainicio >= '" + dtpFiltrarFechaInicioMant.Value.ToShortDateString + "' and fechafin <= '" + dtpFiltrarFechaFinMant.Value.ToShortDateString + "'",
                                           "matricula", txtFiltrarMatriculaMant.Text) + TipoFiltro(cbxFiltrarTipoMant, "descripcion")
                    dgvMant.DataSource.Filter = filtro

                Else

                    filtro = String.Format("{0} LIKE '%{1}%' and estado = true ", "matricula", txtFiltrarMatriculaMant.Text) +
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
