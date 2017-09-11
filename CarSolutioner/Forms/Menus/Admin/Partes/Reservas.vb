'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerReservas
End Class


Partial Public Class frmMainMenu



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

    Public Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvReservas.CellMouseDoubleClick, dgvAlquileres.CellMouseDoubleClick

        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

            Dim selectedRow = dgvReservas.Rows(e.RowIndex)

            ReservaSeleccionada.IdReserva = selectedRow.Cells("idreserva").Value.ToString
            ReservaSeleccionada.IdCliente = selectedRow.Cells("idpersona").Value.ToString
            ReservaSeleccionada.FechaInicio = selectedRow.Cells("inicio").Value.ToString
            ReservaSeleccionada.FechaFin = selectedRow.Cells("fin").Value.ToString
            ReservaSeleccionada.CantKM = selectedRow.Cells("cantidad_km").Value.ToString
            ReservaSeleccionada.CostoTotal = selectedRow.Cells("costo").Value.ToString
            ReservaSeleccionada.FechaTramite = selectedRow.Cells("fecha_tramite").Value.ToString
            ReservaSeleccionada.NomCliente = selectedRow.Cells("nombre").Value.ToString
            ReservaSeleccionada.ApeCliente = selectedRow.Cells("apellido").Value.ToString()
            ReservaSeleccionada.Categoria = selectedRow.Cells("categoria").Value.ToString
            ReservaSeleccionada.Tipo = selectedRow.Cells("tipo").Value.ToString
            ReservaSeleccionada.SucursalInicio = selectedRow.Cells("sucursal_partida").Value.ToString
            ReservaSeleccionada.SucursalDestino = selectedRow.Cells("sucursal_destino").Value.ToString
            ReservaSeleccionada.Empleado = selectedRow.Cells("empleado").Value.ToString

            frmAlquilar.ShowDialog()

        End If
    End Sub


End Class
