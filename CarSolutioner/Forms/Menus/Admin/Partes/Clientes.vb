'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerClientes
End Class

'CLIENTES
Partial Public Class MainMenu

    Private Sub FiltrosCliente(sender As Object, e As EventArgs) Handles txtDocumFClientes.TextChanged, txtNombreFClientes.TextChanged, txtApellidoFClientes.TextChanged, txtCorreoFClientes.TextChanged, txtEmpresaFClientes.TextChanged, cbxTipoDocumFCliente.SelectionChangeCommitted, chbxFechaFClientes.CheckStateChanged, dtpFecNacFCliente.TextChanged

        Dim filtro As String

        If chbxFechaFClientes.Checked = True Then

            filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%' AND {10} LIKE '%{11}%' AND {12} = '{13}'",
                                   "Documento", txtDocumFClientes.Text, "Tipo", cbxTipoDocumFCliente.SelectedItem.ToString, "Nombre", txtNombreFClientes.Text, "Apellido", txtApellidoFClientes.Text, "Correo", txtCorreoFClientes.Text, "Empresa", txtEmpresaFClientes.Text, "Nacimiento", dtpFecNacFCliente.Value.ToShortDateString)

            dgvClientes.DataSource.Filter = filtro

        Else

            filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%' AND {10} LIKE '%{11}%'",
                                   "Documento", txtDocumFClientes.Text, "Tipo", cbxTipoDocumFCliente.SelectedItem.ToString, "Nombre", txtNombreFClientes.Text, "Apellido", txtApellidoFClientes.Text, "Correo", txtCorreoFClientes.Text, "Empresa", txtEmpresaFClientes.Text)

            dgvClientes.DataSource.Filter = filtro
        End If


    End Sub

    Private Sub btnIngresarACliente_Click(sender As Object, e As EventArgs) Handles btnIngresarACliente.Click
        Dim sentencia As String

        sentencia.Format("INSERT INTO Cliente (tipodocumento, nrodocumento, nombre, apellido, email, fecnac, empresa, estado) VALUES ( {0}, {1}, {2}, {3}, {4}, {5}, {6}, 't' )",
                         cbxTipoDocumentoACliente, txtDocumACliente, txtNombreACliente, txtApellidoACliente, txtCorreoACliente, dtpFecNacACliente, txtEmpresaACliente)
        conexion.EjecutarNonQuery(sentencia)
    End Sub

    Private Sub btnVaciarFClientes_Click(sender As Object, e As EventArgs) Handles btnVaciarFClientes.Click

        For Each control As Control In pnlFClientes.Controls
            If TypeOf control Is TextBox Then
                control.Text = ""
            End If
        Next
    End Sub

    Private Sub chboxFechaFClientes_CheckedChanged(sender As Object, e As EventArgs) Handles chbxFechaFClientes.CheckedChanged
        If chbxFechaFClientes.Checked Then
            dtpFecNacFCliente.Enabled = True
        Else
            dtpFecNacFCliente.Enabled = False
        End If
    End Sub

End Class
