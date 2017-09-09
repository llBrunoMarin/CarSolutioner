'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerReservas
End Class


Partial Public Class frmMainMenu
    Friend sucursal As String
    Friend tipo As String
    Friend categoria As String
    Friend cliente As String
    Private Sub FiltrosReserva(sender As Object, e As EventArgs) Handles cbxMostrarFRes.SelectionChangeCommitted, cbxEstadoFRes.SelectionChangeCommitted, txtDocumFRes.TextChanged, cbxCategoriaFRes.SelectionChangeCommitted, cbxSucSalFres.SelectionChangeCommitted, cbxSucLlegFRes.SelectionChangeCommitted, cbxKilomFRes.SelectionChangeCommitted

        'cbxMostrarFRes.SelectionChangeCommitted, cbxEstadoFRes.SelectionChangeCommitted, txtDocumFRes.TextChanged, cbxCatFRes.SelectionChangeCommitted, cbxSucSalFres.SelectionChangeCommitted, cbxSucLlegFRes.SelectionChangeCommitted, cbxKilomFRes.SelectionChangeCommitted
        'Dim filtro As String
        'filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%' AND {10} LIKE '%{11}%'",
        '                       "nrodocumento", txtDocumFClientes.Text, "tipodocumento", cbxTipoDocumFCliente.SelectedItem.ToString, "nombre", txtNombreFClientes.Text, "apellido", txtApellidoFClientes.Text, "email", txtCorreoFClientes.Text, "empresa", txtEmpresaFClientes.Text)

        'dgvClientes.DataSource.Filter = filtro



    End Sub


    Private Sub chboxFechaFRes_CheckedChanged(sender As Object, e As EventArgs) Handles chboxFechaFRes.CheckedChanged

        If chboxFechaFRes.Checked Then

            dtpFAResF.Enabled = True
            dtpFAResI.Enabled = True

        Else

            dtpFAResF.Enabled = False
            dtpFAResI.Enabled = False

        End If

    End Sub

    Public Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvReservas.CellMouseDoubleClick

        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow = dgvReservas.Rows(e.RowIndex)


            tipo = selectedRow.Cells(11).Value.ToString
            sucursal = selectedRow.Cells(12).Value.ToString
            cliente = selectedRow.Cells(9).Value.ToString
            categoria = selectedRow.Cells(10).Value.ToString
            Alquilar.Show()
        End If
    End Sub


End Class
