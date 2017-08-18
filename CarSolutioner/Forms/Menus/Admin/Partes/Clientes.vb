'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerClientes
End Class

'CLIENTES
Partial Public Class MainMenu

    Private Sub FiltrosCliente(sender As Object, e As EventArgs) Handles txtDocumFClientes.TextChanged, txtNombreFClientes.TextChanged, txtApellidoFClientes.TextChanged, txtCorreoFClientes.TextChanged, txtEmpresaFClientes.TextChanged, cbxTipoDocumFCliente.SelectionChangeCommitted

        Dim filtro As String
        filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%' AND {10} LIKE '%{11}%'",
                               "nrodocumento", txtDocumFClientes.Text, "tipodocumento", cbxTipoDocumFCliente.SelectedItem.ToString, "nombre", txtNombreFClientes.Text, "apellido", txtApellidoFClientes.Text, "email", txtCorreoFClientes.Text, "empresa", txtEmpresaFClientes.Text)

        dgvClientes.DataSource.Filter = filtro

        filtro.Format("hola {0}, chau{1}", "pepe", "pepito")

    End Sub

    Private Sub btnVaciarFClientes_Click(sender As Object, e As EventArgs) Handles btnVaciarFClientes.Click
        For Each Control As Control In pnlFClientes.Controls
            'If Control.GetType Is TextBox Then

            'End If
        Next
    End Sub

End Class
