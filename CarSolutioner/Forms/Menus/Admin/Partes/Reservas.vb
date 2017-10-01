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

    Public Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvReservas.CellMouseDoubleClick

        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

            Dim selectedRow = dgvReservas.Rows(e.RowIndex)


            ReservaSeleccionada.IdCliente = selectedRow.Cells("idpersonareserva").Value.ToString
            ReservaSeleccionada.FechaInicio = selectedRow.Cells("fechareservainicio").Value.ToString
            ReservaSeleccionada.FechaFin = selectedRow.Cells("fechareservafin").Value.ToString
            ReservaSeleccionada.CantKM = selectedRow.Cells("cantidadkm").Value.ToString
            ReservaSeleccionada.CostoTotal = selectedRow.Cells("costototal").Value.ToString
            ReservaSeleccionada.FechaTramite = selectedRow.Cells("fechatramite").Value.ToString
            ReservaSeleccionada.NomCliente = selectedRow.Cells("nombreapellido").Value.ToString
            ReservaSeleccionada.ApeCliente = selectedRow.Cells("nombreapellido").Value.ToString()
            ReservaSeleccionada.Categoria = selectedRow.Cells("categoriareserva").Value.ToString
            ReservaSeleccionada.Tipo = selectedRow.Cells("tiporeserva").Value.ToString
            ReservaSeleccionada.SucursalInicio = selectedRow.Cells("salida").Value.ToString
            ReservaSeleccionada.SucursalDestino = selectedRow.Cells("llegada").Value.ToString
            ReservaSeleccionada.Empleado = selectedRow.Cells("usuarioempleado").Value.ToString

            frmAlquilar.ShowDialog()

        End If
    End Sub

    Private Sub btnBajaBRes_Click(sender As Object, e As EventArgs) Handles btnBajaBRes.Click
        Dim reservaseleccionadaid As String
        reservaseleccionadaid = dgvReservas.CurrentRow.Cells("idreserva").Value.ToString
        If conexion.EjecutarNonQuery("Update reserva set estado = 2 where idreserva = " + reservaseleccionadaid.ToString + "") = True Then
            MsgBox("Reserva eliminada.", MsgBoxStyle.Information, "Notificacion")
            RecargarDatos(dgvReservas)
        Else
            MsgBox("No se pudo eliminar", MsgBoxStyle.Critical, "Notificacion")
        End If

    End Sub

End Class
