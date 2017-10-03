'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerMantenimiento
End Class

'MANTENIMIENTO
Partial Public Class frmMainMenu
    Private Sub btnIngresarMant_Click(sender As Object, e As EventArgs) Handles btnIngresarMant.Click

        Dim nrochasisinsert As String
        nrochasisinsert = conexion.EjecutarSelect("SELECT nrochasis FROM vehiculo WHERE matricula ='" + txtMatriculaMant.Text.ToString + "'").Rows(0)(0).ToString

        conexion.EjecutarNonQuery("INSERT INTO mantenimiento VALUES (0,
                                  '" + cbxTipoMant.SelectedItem + "',
                                  '" + txtDescripcionMant.Text.ToString + "',
                                  '" + dtpFechaInicioMant.Value.ToShortDateString + "', 
                                  '" + dtpFechaFinMant.Value.ToShortDateString + "',
                                  '" + nrochasisinsert + "',
                                  't')")
        RecargarDatos(dgvMant)
    End Sub

    Private Sub RellenarDatosMantenimiento(sender As Object, e As EventArgs) Handles dgvMant.SelectionChanged
        If Not IsNothing(dgvMant.CurrentRow) Then

            txtModifMatriculaMant.Text = dgvMant.CurrentRow.Cells("matriculamant").Value.ToString()
            cbxModifTipoMant.SelectedIndex = cbxModifTipoMant.FindString(dgvMant.CurrentRow.Cells("tipomant").Value.ToString())
            dtpModifFechaInicioMant.Value = Date.Parse(dgvMant.CurrentRow.Cells("fechainiciomant").Value).ToShortDateString()
            dtpModifFechaFinMant.Value = Date.Parse(dgvMant.CurrentRow.Cells("fechafinmant").Value).ToShortDateString()
            txtModifDescripcionMant.Text = dgvMant.CurrentRow.Cells("descripcionmant").Value.ToString()


        End If
    End Sub

    Private Sub btnModifMant_Click(sender As Object, e As EventArgs) Handles btnModifMant.Click

        'Dim nrochasismodif As String
        'nrochasismodif = conexion.EjecutarSelect("SELECT nrochasis FROM vehiculo WHERE matricula ='" + txtModifMatriculaMant.Text.ToString + "'").Rows(0)(0).ToString
        '
        ' Dim idmantmodif As String
        'idmantmodif = dgvMant.CurrentRow.Cells("idmantenimientomant").Value.ToString()

        'conexion.EjecutarNonQuery("UPDATE mantenimiento SET tipo ='" + cbxModifTipoMant.SelectedItem + ",
        ' descripcion = '" + txtModifDescripcionMant.Text.ToString + "',
        'fechainicio = '" + dtpModifFechaInicioMant.Value.ToShortDateString + "',
        'fechafin = '" + dtpModifFechaFinMant.Value.ToShortDateString + "',
        'nrochasis = '" + nrochasismodif + "', estado = '' WHERE idmantenimiento= " + idmantmodif + ")")
    End Sub

End Class
